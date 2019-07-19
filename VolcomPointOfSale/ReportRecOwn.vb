Public Class ReportRecOwn
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportRecOwn_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = dt
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class