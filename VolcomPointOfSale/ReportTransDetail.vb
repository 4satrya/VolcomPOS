Public Class ReportTransDetail
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportTransDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCTransDetail.DataSource = dt
    End Sub

    Private Sub GVTransDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVTransDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class