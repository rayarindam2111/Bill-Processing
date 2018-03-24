<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.panelItems = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnMake = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblfinal = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnRate = New System.Windows.Forms.Button()
        Me.btnSetup = New System.Windows.Forms.Button()
        Me.btnPrintDialog = New System.Windows.Forms.Button()
        Me.printDialog = New System.Windows.Forms.PrintDialog()
        Me.pageSetupDialog = New System.Windows.Forms.PageSetupDialog()
        Me.rtfBill = New Bill_Processing.RichTextBoxPrintCtrl()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.panelItems)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 519)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Items"
        '
        'panelItems
        '
        Me.panelItems.AutoScroll = True
        Me.panelItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelItems.Location = New System.Drawing.Point(3, 16)
        Me.panelItems.Name = "panelItems"
        Me.panelItems.Size = New System.Drawing.Size(418, 500)
        Me.panelItems.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtfBill)
        Me.GroupBox2.Location = New System.Drawing.Point(536, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 455)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bill"
        '
        'btnMake
        '
        Me.btnMake.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMake.ForeColor = System.Drawing.Color.Red
        Me.btnMake.Location = New System.Drawing.Point(448, 228)
        Me.btnMake.Name = "btnMake"
        Me.btnMake.Size = New System.Drawing.Size(75, 70)
        Me.btnMake.TabIndex = 0
        Me.btnMake.Text = ">"
        Me.btnMake.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(664, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 48)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "PAY:"
        '
        'lblfinal
        '
        Me.lblfinal.AutoSize = True
        Me.lblfinal.Font = New System.Drawing.Font("Tahoma", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinal.ForeColor = System.Drawing.Color.Red
        Me.lblfinal.Location = New System.Drawing.Point(751, 486)
        Me.lblfinal.Name = "lblfinal"
        Me.lblfinal.Size = New System.Drawing.Size(164, 48)
        Me.lblfinal.TabIndex = 5
        Me.lblfinal.Text = "0000.00"
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.DarkCyan
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(518, 476)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(117, 60)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "PRINT"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Teal
        Me.btnNew.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(442, 476)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(73, 58)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "NEW"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnRate
        '
        Me.btnRate.Location = New System.Drawing.Point(448, 304)
        Me.btnRate.Name = "btnRate"
        Me.btnRate.Size = New System.Drawing.Size(75, 23)
        Me.btnRate.TabIndex = 3
        Me.btnRate.Text = "%"
        Me.btnRate.UseVisualStyleBackColor = True
        '
        'btnSetup
        '
        Me.btnSetup.Location = New System.Drawing.Point(636, 476)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.Size = New System.Drawing.Size(30, 23)
        Me.btnSetup.TabIndex = 4
        Me.btnSetup.Text = "P1"
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'btnPrintDialog
        '
        Me.btnPrintDialog.Location = New System.Drawing.Point(636, 513)
        Me.btnPrintDialog.Name = "btnPrintDialog"
        Me.btnPrintDialog.Size = New System.Drawing.Size(30, 23)
        Me.btnPrintDialog.TabIndex = 5
        Me.btnPrintDialog.Text = "P2"
        Me.btnPrintDialog.UseVisualStyleBackColor = True
        '
        'printDialog
        '
        Me.printDialog.UseEXDialog = True
        '
        'rtfBill
        '
        Me.rtfBill.BackColor = System.Drawing.Color.White
        Me.rtfBill.DetectUrls = False
        Me.rtfBill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfBill.Location = New System.Drawing.Point(3, 16)
        Me.rtfBill.Name = "rtfBill"
        Me.rtfBill.ReadOnly = True
        Me.rtfBill.Size = New System.Drawing.Size(396, 436)
        Me.rtfBill.TabIndex = 0
        Me.rtfBill.TabStop = False
        Me.rtfBill.Text = ""
        Me.rtfBill.WordWrap = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 548)
        Me.Controls.Add(Me.btnPrintDialog)
        Me.Controls.Add(Me.btnSetup)
        Me.Controls.Add(Me.btnRate)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblfinal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMake)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bill Maker - CAFÉ BONG BINGE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtfBill As RichTextBoxPrintCtrl
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents panelItems As Panel
    Friend WithEvents btnMake As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblfinal As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents btnRate As Button
    Friend WithEvents btnSetup As Button
    Friend WithEvents btnPrintDialog As Button
    Friend WithEvents printDialog As PrintDialog
    Friend WithEvents pageSetupDialog As PageSetupDialog
End Class
