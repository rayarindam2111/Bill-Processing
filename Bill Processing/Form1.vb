Public Class frmMain
    Public table(,) As String
    Public total As Integer
    Public quantity As New List(Of Label)
    Public grossamount As Double
    Public tax As Double = 5
    Public billTime As String = ""

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data As String = ""
        Do
            Try
                data = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\list.ini")
            Catch ex As Exception
                If (MsgBox("Error in loading item list. Make sure the required file exists, is not in use by another application and contains valid entries." &
                           vbNewLine & vbNewLine & "[" & ex.Message & "]", vbCritical Or vbRetryCancel, "Bill Maker") = vbCancel) Then
                    End
                End If
            End Try
        Loop While data = ""

        Try
            tax = My.Settings.t_rate
            rtfBill.PrintDocument.DefaultPageSettings.Margins = New Printing.Margins(My.Settings.marginLeft, My.Settings.marginRight, My.Settings.marginTop, My.Settings.marginBottom)
        Catch ex As Exception
            MsgBox("Error reading previously saved settings from disk. The Service Charge rate has been set to 5%, and page margins to 0.1 inch. Please change them if you want to!", vbExclamation, "Bill Maker")
            tax = 5
            rtfBill.PrintDocument.DefaultPageSettings.Margins = New Printing.Margins(3, 0, 10, 10)
        End Try

        Dim items() As String = data.Split(vbNewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        Dim i As Integer = -1
        Dim mat(items.Length, 2) As String
        panelItems.Controls.Clear()
        For Each value As String In items
            i += 1
            Dim temp() As String = value.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            '0:item_name 1:price 2:quantity
            mat(i, 0) = temp(0)
            If temp.Length > 1 Then
                mat(i, 1) = temp(1)
                mat(i, 2) = "0"
            Else
                mat(i, 1) = "0"
                mat(i, 2) = "0"
            End If


            Dim item As Label = New Label
            item.Name = "item" & i.ToString()
            item.Padding = New Padding(3)
            item.Font = New Font("Tahoma", 10.0)
            item.UseMnemonic = False
            item.Text = temp(0)
            item.TextAlign = ContentAlignment.MiddleLeft
            If temp.Length > 1 Then
                item.BackColor = Color.FromArgb(255, 9, 0)
            Else
                item.BackColor = Color.FromArgb(50, 170, 170)
            End If

            item.Left = 2
            item.Height = 40
            item.Width = 180
            item.Top = 5 + i * 42

            Dim add As Button = New Button
            Dim item2 As Label = New Label
            Dim subt As Button = New Button

            If temp.Length > 1 Then

                add.Name = "add" & i.ToString()
                add.Padding = New Padding(5)
                add.Font = New Font("Tahoma", 12.0)
                add.Text = "+"
                add.TextAlign = ContentAlignment.MiddleCenter
                add.Left = 184
                add.Height = 40
                add.Width = 40
                add.Top = 5 + i * 42
                add.Tag = i
                AddHandler add.Click, AddressOf Me.addItem


                item2.Name = "price" & i.ToString()
                item2.Padding = New Padding(10)
                item2.Font = New Font("Tahoma", 12.0)
                item2.Text = temp(1)
                item2.TextAlign = ContentAlignment.MiddleRight
                item2.BackColor = Color.FromArgb(255, 9, 0)
                item2.Left = 226
                item2.Height = 40
                item2.Width = 80
                item2.Top = 5 + i * 42


                subt.Name = "sub" & i.ToString()
                subt.Padding = New Padding(5)
                subt.Font = New Font("Tahoma", 12.0)
                subt.Text = "-"
                subt.TextAlign = ContentAlignment.MiddleCenter
                subt.Left = 308
                subt.Height = 40
                subt.Width = 40
                subt.Top = 5 + i * 42
                subt.Tag = i
                AddHandler subt.Click, AddressOf Me.removeItem
            End If


            Dim quant As Label = New Label
            quant.Name = "quant" & i.ToString()
            quant.Padding = New Padding(2)
            quant.Font = New Font("Tahoma", 12.0)
            quant.Text = 0
            quant.TextAlign = ContentAlignment.MiddleRight
            quant.BackColor = Color.FromArgb(50, 170, 170)
            quant.Left = 350
            quant.Height = 40
            quant.Width = 40
            quant.Top = 5 + i * 42
            quantity.Add(quant)

            panelItems.Controls.Add(item)
            If temp.Length > 1 Then
                panelItems.Controls.Add(add)
                panelItems.Controls.Add(item2)
                panelItems.Controls.Add(subt)
                panelItems.Controls.Add(quant)
            End If

        Next
        total = i
        table = mat
        panelItems.Refresh()
    End Sub

    Sub addItem(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim index As Integer = Val(CType(sender, Button).Tag)
        table(index, 2) = (Val(table(index, 2)) + 1).ToString()
        quantity(index).Text = table(index, 2)
        quantity(index).BackColor = Color.Red
    End Sub

    Sub removeItem(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim index As Integer = Val(CType(sender, Button).Tag)
        If (Val(table(index, 2)) > 0) Then
            table(index, 2) = (Val(table(index, 2)) - 1).ToString()
            quantity(index).Text = table(index, 2)
            If Val(table(index, 2)) = 0 Then
                quantity(index).BackColor = Color.FromArgb(50, 170, 170)
            Else
                quantity(index).BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btnMake_Click(sender As Object, e As EventArgs) Handles btnMake.Click
        makeBill()
    End Sub

    Sub makeBill()
        billTime = Date.Today.Date.ToShortDateString() & " " & TimeOfDay.ToLongTimeString()
        grossamount = 0
        rtfBill.Clear()
        rtfBill.SelectionFont = New Font("Tahoma", 20)
        rtfBill.SelectionAlignment = HorizontalAlignment.Left

        rtfBill.AppendText("CAFÉ BONG BINGE" & vbNewLine)
        rtfBill.SelectionFont = New Font("Tahoma", 9)

        rtfBill.AppendText("22/270 Jodhpur Gardens, KOL - 45" & vbNewLine)
        rtfBill.SelectionFont = New Font("Tahoma", 13)
        rtfBill.AppendText("--------------------------------------------" & vbNewLine)
        rtfBill.SelectionFont = New Font("Tahoma", 8)
        rtfBill.AppendText(billTime & vbNewLine & vbNewLine)
        rtfBill.SelectionFont = New Font("Tahoma", 5)
        rtfBill.AppendText(vbNewLine)

        rtfBill.SelectionFont = New Font("Tahoma", 10, FontStyle.Underline)
        rtfBill.AppendText("Item")
        rtfBill.SelectionFont = New Font("Tahoma", 10, FontStyle.Regular)
        rtfBill.AppendText(vbTab & vbTab & vbTab & " ")
        rtfBill.SelectionFont = New Font("Tahoma", 10, FontStyle.Underline)
        rtfBill.AppendText("Qty")
        rtfBill.SelectionFont = New Font("Tahoma", 10, FontStyle.Regular)
        rtfBill.AppendText(vbTab & " ")
        rtfBill.SelectionFont = New Font("Tahoma", 10, FontStyle.Underline)
        rtfBill.AppendText("Price")
        rtfBill.SelectionFont = New Font("Tahoma", 3, FontStyle.Regular)
        rtfBill.AppendText(vbNewLine & vbNewLine)

        For i As Integer = 0 To total
            If (table(i, 2) <> 0) Then
                rtfBill.SelectionFont = New Font("Tahoma", 10)
                rtfBill.AppendText(table(i, 0))
                rtfBill.AppendText(" " & table(i, 2) & vbTab & " ")
                rtfBill.AppendText(FormatNumber(Val(table(i, 2)) * Val(table(i, 1)), 2))
                rtfBill.AppendText(vbNewLine)
                grossamount = grossamount + (Val(table(i, 2)) * Val(table(i, 1)))
            End If
        Next

        rtfBill.SelectionFont = New Font("Tahoma", 5)
        rtfBill.AppendText(vbNewLine)

        rtfBill.SelectionFont = New Font("Tahoma", 13)
        rtfBill.AppendText("--------------------------------------------" & vbNewLine)

        rtfBill.SelectionFont = New Font("Tahoma", 10)
        rtfBill.AppendText("Gross Amount:" & vbTab & vbTab & vbTab)
        rtfBill.AppendText(FormatNumber(grossamount, 2))

        rtfBill.SelectionFont = New Font("Tahoma", 10)
        rtfBill.AppendText(vbNewLine & "Service Charge(" & tax.ToString() & "%):" & vbTab & vbTab)
        rtfBill.AppendText(FormatNumber(grossamount * tax / 100, 2))

        grossamount = grossamount + (grossamount * tax / 100)

        rtfBill.SelectionFont = New Font("Tahoma", 13)
        rtfBill.AppendText(vbNewLine & "--------------------------------------------" & vbNewLine)

        rtfBill.SelectionFont = New Font("Tahoma", 11)
        rtfBill.AppendText("Net Amount:" & vbTab & vbTab & vbTab)
        rtfBill.AppendText(FormatNumber(grossamount, 2))

        rtfBill.SelectionFont = New Font("Tahoma", 13)
        rtfBill.AppendText(vbNewLine & "--------------------------------------------" & vbNewLine)
        lblfinal.Text = FormatNumber(grossamount, 2)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim saved As Boolean = False
        Dim printed As Boolean = False
        Dim path As String = ""

        Do
            Try
                'Shell("write /p " & """" & My.Computer.FileSystem.SpecialDirectories.Temp & "\bill.rtf" & """")
                'OR:  write /pt filename printername
                printDialog.Document = rtfBill.PrintDocument
                printDialog.Document.DocumentName = "CAFE BONG BINGE BILL"
                rtfBill.SelPrint()
                printed = True
            Catch ex As Exception
                If (MsgBox("Error in printing!" & vbNewLine & vbNewLine & "[" & ex.Message & "]", vbCritical Or vbRetryCancel, "Bill Maker") = vbCancel) Then
                    Exit Do
                End If
            End Try
        Loop While printed = False

        Do
            Try
                If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Bills") = False Then
                    My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\Bills")
                End If
                If billTime = "" Then
                    path = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Bills\" & Date.Today.Date.ToShortDateString().Replace("/", "-") & " " & TimeOfDay.ToLongTimeString().Replace(":", "-") & ".rtf"
                Else
                    path = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Bills\" & billTime.Replace("/", "-").Replace(":", "-") & ".rtf"
                End If
                rtfBill.SaveFile(path)
                saved = True
            Catch ex As Exception
                If (MsgBox("Error in saving bill for printing. If the problem persists, clear the folder (" & My.Computer.FileSystem.SpecialDirectories.Desktop &
                    "\Bills) and try again." & vbNewLine & vbNewLine & "[" & ex.Message & "]", vbCritical Or vbRetryCancel, "Bill Maker") = vbCancel) Then
                    Exit Do
                End If
            End Try
        Loop While saved = False

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        grossamount = 0
        lblfinal.Text = "0000.00"
        billTime = ""
        For i As Integer = 0 To total
            table(i, 2) = "0"
            quantity(i).Text = "0"
            quantity(i).BackColor = Color.FromArgb(50, 170, 170)
        Next
        rtfBill.Clear()
    End Sub

    Private Sub btnRate_Click(sender As Object, e As EventArgs) Handles btnRate.Click
        Dim loopagain As Boolean = False
        Dim displayString1 As String = "Current Service Charge rate = " & tax.ToString() & "%" & vbNewLine &
                                       "Enter new Service Charge rate" & vbNewLine & "(For e.g. enter 14.5 for 14.5% Service Charge" &
                                       vbNewLine & "Enter nothing to keep current rate):"
        Dim displayString0 As String = "Enter correct value!" & vbNewLine & vbNewLine

        Dim reply As String = ""
        Dim pass As String = InputBox("Enter passKey:", "Bill Maker", "")
        If pass = "dimtarka" Then
            Do
                If loopagain Then
                    reply = InputBox(displayString0 & displayString1, "Bill Maker", tax.ToString())
                Else
                    reply = InputBox(displayString1, "Bill Maker", tax.ToString())
                End If

                If IsNumeric(reply) Then
                    tax = Val(reply)

                    Try
                        My.Settings.t_rate = tax
                        My.Settings.Save()
                    Catch ex As Exception
                        MsgBox("Error saving VAT rate on disk. The VAT rate is set for the current session, but you will have to reset it the next time you start the application.", vbExclamation, "Bill Maker")
                    End Try

                    loopagain = False
                ElseIf String.IsNullOrEmpty(reply) = False Then
                    loopagain = True
                Else
                    loopagain = False
                End If
            Loop While loopagain = True
        End If
    End Sub

    Private Sub btnSetup_Click(sender As Object, e As EventArgs) Handles btnSetup.Click
        pageSetupDialog.Document = rtfBill.PrintDocument
        If pageSetupDialog.ShowDialog() = DialogResult.OK Then
            Try
                My.Settings.marginTop = pageSetupDialog.Document.DefaultPageSettings.Margins.Top
                My.Settings.marginBottom = pageSetupDialog.Document.DefaultPageSettings.Margins.Bottom
                My.Settings.marginLeft = pageSetupDialog.Document.DefaultPageSettings.Margins.Left
                My.Settings.marginRight = pageSetupDialog.Document.DefaultPageSettings.Margins.Right
                My.Settings.Save()
            Catch ex As Exception
                MsgBox("Error saving page margin values on disk. It is set for the current session, but you will have to reset it the next time you start the application.", vbExclamation, "Bill Maker")
            End Try
        End If
    End Sub

    Private Sub btnPrintDialog_Click(sender As Object, e As EventArgs) Handles btnPrintDialog.Click
        Dim printed As Boolean = False
        Do
            Try
                printDialog.Document = rtfBill.PrintDocument
                printDialog.Document.DocumentName = "CAFE BONG BINGE BILL"
                If printDialog.ShowDialog() = DialogResult.OK Then
                    rtfBill.SelPrint()
                End If
                printed = True
            Catch ex As Exception
                If (MsgBox("Error in printing!" & vbNewLine & vbNewLine & "[" & ex.Message & "]", vbCritical Or vbRetryCancel, "Bill Maker") = vbCancel) Then
                    Exit Do
                End If
            End Try
        Loop While printed = False
    End Sub

End Class
