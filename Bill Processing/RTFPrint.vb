Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

Public Class RichTextBoxPrintCtrl
        Inherits RichTextBox

        ' Convert the unit that is used by the .NET framework 
        ' (1/100 inch) and the unit that is used by Win32 API calls  
        ' (twips 1/1440 inch)
        Private Const AnInch As Double = 14.4

        Private WithEvents m_PrintDocument As Printing.PrintDocument
        Private intCharactersToPrint As Integer
        Private intCurrentPosition As Integer

        <StructLayout(LayoutKind.Sequential)>
        Private Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Private Structure CHARRANGE
            ' First character of range (0 for start of doc)
            Public cpMin As Integer
            ' Last character of range (-1 for end of doc)
            Public cpMax As Integer
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Private Structure FORMATRANGE
            ' Actual DC to draw on
            Public hdc As IntPtr
            ' Target DC for determining text formatting
            Public hdcTarget As IntPtr
            ' Region of the DC to draw to (in twips)
            Public rc As RECT
            ' Region of the whole DC (page size) (in twips)
            Public rcPage As RECT
            ' Range of text to draw (see above declaration)
            Public chrg As CHARRANGE
        End Structure

        Private Const WM_USER As Integer = &H400
        Private Const EM_FORMATRANGE As Integer = WM_USER + 57

        Private Declare Function SendMessage Lib "USER32" Alias _
            "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer,
            ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

        Public Sub SelPrint()

            'print only the selected text if any is selected
            If Me.SelectionLength > 0 Then
                intCharactersToPrint = Me.SelectionStart + Me.SelectionLength
                intCurrentPosition = Me.SelectionStart
            Else
                'otherwise print the entire document
                intCharactersToPrint = Me.TextLength
                intCurrentPosition = 0
            End If

            m_PrintDocument.Print()

        End Sub
        ' Render the contents of the RichTextBox for printing
        ' Return the last character printed + 1 (printing start from 
        ' this point for next page)
        Private Function Print(ByVal charFrom As Integer,
ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

            ' Mark starting and ending character
            Dim cRange As CHARRANGE
            cRange.cpMin = charFrom
            cRange.cpMax = charTo

            ' Calculate the area to render and print
            Dim rectToPrint As RECT
            rectToPrint.Top = e.MarginBounds.Top * AnInch
            rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
            rectToPrint.Left = e.MarginBounds.Left * AnInch
            rectToPrint.Right = e.MarginBounds.Right * AnInch

            ' Calculate the size of the page
            Dim rectPage As RECT
            rectPage.Top = e.PageBounds.Top * AnInch
            rectPage.Bottom = e.PageBounds.Bottom * AnInch
            rectPage.Left = e.PageBounds.Left * AnInch
            rectPage.Right = e.PageBounds.Right * AnInch

            Dim hdc As IntPtr = e.Graphics.GetHdc()

            Dim fmtRange As FORMATRANGE
            ' Indicate character from to character to
            fmtRange.chrg = cRange
            ' Use the same DC for measuring and rendering
            fmtRange.hdc = hdc
            ' Point at printer hDC
            fmtRange.hdcTarget = hdc
            ' Indicate the area on page to print
            fmtRange.rc = rectToPrint
            ' Indicate whole size of page
            fmtRange.rcPage = rectPage

            Dim res As IntPtr = IntPtr.Zero

            Dim wparam As IntPtr = IntPtr.Zero
            wparam = New IntPtr(1)

            ' Move the pointer to the FORMATRANGE structure in 
            ' memory
            Dim lparam As IntPtr = IntPtr.Zero
            lparam =
Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
            Marshal.StructureToPtr(fmtRange, lparam, False)

            ' Send the rendered data for printing
            res =
SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

            ' Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam)

            ' Release the device context handle obtained by a 
            ' previous call
            e.Graphics.ReleaseHdc(hdc)

            'return the last + 1 character printed
            Return res.ToInt32

        End Function
        Public ReadOnly Property PrintDocument() As Printing.PrintDocument
            Get
                If m_PrintDocument Is Nothing Then
                    m_PrintDocument = New Printing.PrintDocument
                End If

                Return m_PrintDocument
            End Get
        End Property

        Private Sub m_PrintDocument_PrintPage(ByVal sender As _
Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
Handles m_PrintDocument.PrintPage
            ' Print the content of the RichTextBox. 
            ' Store the last character printed.

            intCurrentPosition = Me.Print(intCurrentPosition,
intCharactersToPrint, e)

            ' Look for more pages by checking 
            If intCurrentPosition < intCharactersToPrint Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If

        End Sub
End Class