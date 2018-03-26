Public Class FormPrint
    Private Sub FormPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Const eClear As String = Chr(27) + "@"
    Public Const eCentre As String = Chr(27) + Chr(97) + "1"
    Public Const eLeft As String = Chr(27) + Chr(77) + "1" + Chr(27) + Chr(97) + "0"
    Public Const eRight As String = Chr(27) + Chr(97) + "2"
    Public Const eDrawer As String = eClear + Chr(27) + "p" + Chr(0) + ".}"
    Public Const eCut As String = Chr(27) + "i" + vbCrLf
    Public Const eSmlText As String = Chr(27) + "!" + Chr(1)
    Public Const eNmlText As String = Chr(27) + "!" + Chr(0)
    Public Const eInit As String = eNmlText + Chr(13) + Chr(27) + "3" + Chr(18) + vbCrLf
    Public Const eBigCharOn As String = Chr(27) + "!" + Chr(56)
    Public Const eBigCharOff As String = Chr(27) + "!" + Chr(0)

    Private prn As New ClassRawPrint

    Private PrinterName As String = "EPSON LQ-300+ /II ESC/P 2"

    Public Sub StartPrint()
        prn.OpenPrint(PrinterName)
    End Sub

    Public Sub PrintHeader()
        Print(eInit + eCentre + Chr(27) + Chr(33) + Chr(16) + "PT VOLCOM INDONESIA")
        Print(eNmlText + Chr(27) + Chr(77) + "1" + "**** TRUE TO THIS ****")
        Print(Chr(27) + Chr(77) + "1" + "JL KARTIKA PLAZA 10")
        Print(Chr(27) + Chr(77) + "1" + "NPWP : 01.913.122.111.000")
        Print(Chr(27) + Chr(77) + "1" + "PKP :01-07-2006" + eLeft)
        PrintDashes()
    End Sub

    Public Sub PrintBody()
        'Dim no As String = " 1.  " '5
        'Dim code As String = "1234567890        " '18
        'Dim qty As String = "12" '2
        'Dim amount As String = "     1234567890" '15
        'For i = 1 To 10
        '    If i < 10 Then
        '        no = " " + i.ToString + "."
        '    Else
        '        no = i.ToString + "."
        '    End If

        '    qty = i.ToString
        '    If qty.Length = 1 Then
        '        qty = " " + qty.ToString
        '    Else
        '        qty = qty.ToString
        '    End If
        '    Print(eLeft + no + code + qty + amount)
        '    Print(eLeft + "     " + "PRODUCT DESCRIPTION " + i.ToString)
        'Next

        Print(eLeft + "100096" + Chr(13) + eRight + "15/11/2016")
        Print(eLeft + "CASHIER 1" + Chr(13) + eRight + "14:29")
        Print(eLeft + "No.--------Code--------Qty--------Amount")
        printItem("1", "101002056931", "MTS BRICKSTONE BLK", "1", "500.000")
        printItem("2", "1010020569313451", "COBA COBA COBA", "23", "1.200.000")
        printItem("3", "101003056931", "MTS BRICKSTONE WHT", "1", "700.000")

        PrintDashes()
        Print(eLeft + "Total" + Chr(13) + eRight + "0")
        Print(eLeft + "Dasar Kena PPN" + Chr(13) + eRight + "0")
        Print(eLeft + "PPN" + Chr(13) + eRight + "0")
        Print(eLeft + "Cash" + Chr(13) + eRight + "0")
        Print(eLeft + "Card" + Chr(13) + eRight + "0")
        Print(eLeft + "Voucher" + Chr(13) + eRight + "0")
        Print(eLeft + "Change" + Chr(13) + eRight + "0")

        'jika ada card/voucher
        'Print(vbLf)
        'Print(eLeft + "       Card Type" + "    : " + "DEBIT BCA")
        'Print(eLeft + "       Number" + "       : " + "12345")
        'Print(eLeft + "       Holder" + "       : " + "KOMANG")
        'Print(eLeft + "       Voucher No." + "  : " + "123445")

        Print(vbLf)
    End Sub

    Sub printItem(ByVal no As String, code As String, desc As String, qty As String, amount As String)
        'no=5; code=18; qty=2; amount=15
        If no.Length = "1" Then
            no = " " + no + ".  "
        Else
            no = no + ".  "
        End If

        Dim code_max As Integer = 18
        If code.Length < code_max Then
            For c = 1 To (code_max - code.Length)
                code += " "
            Next
        Else
            code = code
        End If

        If qty.Length = "1" Then
            qty = " " + qty
        Else
            qty = qty
        End If

        Dim amount_max As Integer = 15
        If amount.Length < amount_max Then
            For a = 1 To (amount_max - amount.Length)
                amount = " " + amount
            Next
        Else
            amount = amount
        End If
        Print(eLeft + no + code + qty + amount)
        Print(eLeft + "     " + desc)
    End Sub

    Public Sub PrintFooter()
        Print(eCentre + "Thank you and see you again soon")
        Print(eCentre + "Please note that all sales are final")
        Print(eCentre + "HARGA SUDAH TERMASUK PPN")
        Print(eCentre + "WWW.VOLCOM.CO.ID")
        Print(vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + vbLf + eCut + eDrawer)
    End Sub

    Public Sub Print(Line As String)
        prn.SendStringToPrinter(PrinterName, Line + vbLf)
    End Sub

    Public Sub PrintDashes()
        Print(eLeft + eNmlText + "-".PadRight(33, "-"))
    End Sub

    Public Sub EndPrint()
        prn.ClosePrint()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        StartPrint()

        If prn.PrinterIsOpen = True Then
            PrintHeader()

            PrintBody()

            PrintFooter()

            EndPrint()
        End If
    End Sub
End Class