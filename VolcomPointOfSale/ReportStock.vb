Public Class ReportStock
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportStock_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCStock.DataSource = dt
    End Sub
End Class