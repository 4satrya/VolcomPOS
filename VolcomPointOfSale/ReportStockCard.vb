﻿Public Class ReportStockCard
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportStockCard_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCCard.DataSource = dt
    End Sub
End Class