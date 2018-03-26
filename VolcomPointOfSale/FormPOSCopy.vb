Public Class FormPOSCopy
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim prn As New ClassPOS()
        prn.printPos(90, False)
    End Sub
End Class