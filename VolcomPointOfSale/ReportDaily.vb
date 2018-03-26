Public Class ReportDaily
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportDaily_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDaily.DataSource = dt
    End Sub
End Class