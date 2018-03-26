Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FormImportExcel
    Private dataset_field As DataSet
    Public id_pop_up As String = "-1"
    ' List of id popup
    ' 1 = Sample Purchase
    ' 2 = Sample Planning
    Private Sub TBFileAddress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFileAddress.EditValueChanged
        If Not TBFileAddress.Text = "" Then
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub CBWorksheetName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBWorksheetName.EditValueChanged
        If Not CBWorksheetName.EditValue = "" Then
            Cursor = Cursors.WaitCursor
            fill_field_grid()
            Cursor = Cursors.Default
        End If
    End Sub
    Sub fill_combo_worksheet()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim ExcelTables As DataTable
        'Try
        Dim extension As String = IO.Path.GetExtension(TBFileAddress.Text)
        If extension.ToLower = ".xlsx" Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        ElseIf extension.ToLower = ".xls" Then
            strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;""", TBFileAddress.Text.ToLower)
            'strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        Else
            stopCustom("Make sure your file in .xls or .xlsx format.")
            Exit Sub
        End If

        oledbconn.ConnectionString = strConn
        oledbconn.Open()
        ExcelTables = oledbconn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
        oledbconn.Close()
        oledbconn.Dispose()
        Dim dr As DataRow
        Dim i As Integer = 0
        CBWorksheetName.Properties.Items.Clear()
        CBWorksheetName.EditValue = ""
        For Each dr In ExcelTables.Rows
            If dr.Item(3).ToString = "TABLE" Then
                If InStr(dr.Item(2), "$") > 0 Then
                    i += 1
                    CBWorksheetName.Properties.Items.Add(dr.Item(2).ToString)
                    If i = 1 Then
                        CBWorksheetName.SelectedItem = dr.Item(2).ToString
                    End If
                End If
            End If
        Next
        ExcelTables.Dispose()
        'Catch ex As Exception
        '    stopCustom("Please make sure your file not open and available to read.")
        'End Try
    End Sub
    Sub fill_field_grid()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        GCData.DataSource = Nothing

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        If id_pop_up = "2" Or id_pop_up = "3" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] GROUP BY code", oledbconn)
        Else
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        End If

        'Try
        MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        'Catch ex As Exception
        '    stopCustom("Input must be in accordance with the format specified !")
        '    Exit Sub
        'End Try

        If id_pop_up = "1" Then
            'MASTER PRODUCT
            Try
                'size
                Dim query_size As String = "SELECT * FROM tb_size"
                Dim dt_size As DataTable = execute_query(query_size, -1, True, "", "", "", "")

                Dim dt As DataTable = execute_query("SELECT * FROM tb_item", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim tb3 = dt_size.AsEnumerable()
                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join item In tb2
                            On xls("code") Equals item("item_code") Into codejoin = Group
                            From resultcode In codejoin.DefaultIfEmpty()
                            Group Join size In tb3 'left join xls dgn color menjadi colorjoin 'On xls("color").ToString.ToLower Equals color("display_name").ToString.ToLower And New {ID = trans.id, Flow = (Byte)1} Into colorjoin = Group
                            On xls("size").ToString Equals size("size").ToString Into sizejoin = Group
                            From resultsize In sizejoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls.Field(Of String)("code").ToString,
                                .Description = xls.Field(Of String)("description").ToString,
                                .IdSize = If(resultsize Is Nothing, 0, resultsize("id_size").ToString),
                                .Size = xls("size"),
                                .Price = xls("price"),
                                .Status = If(resultcode Is Nothing, If(resultsize Is Nothing, "Size not registered", "OK"), "Product code is already exist")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("IdSize").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "2" Or id_pop_up = "3" Then
            'Adjustment IN/Out
            Try
                Dim i As New ClassItem()
                Dim qry As String = i.queryMain("AND i.is_active=1", "1", False)
                Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join item In tb2
                            On xls("code") Equals item("item_code") Into codejoin = Group
                            From resultcode In codejoin.DefaultIfEmpty()
                            Select New With
                            {
                                .id_item = If(resultcode Is Nothing, 0, resultcode("id_item").ToString),
                                .Code = xls.Field(Of String)("code").ToString,
                                .Description = If(resultcode Is Nothing, "-", resultcode("item_name").ToString),
                                .Size = If(resultcode Is Nothing, "-", resultcode("size").ToString),
                                .Price = If(resultcode Is Nothing, 0, resultcode("price")),
                                .Qty = xls("qty"),
                                .Status = If(resultcode Is Nothing, "Code not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
                GVData.Columns("id_item").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        End If
        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub
    Private Sub BBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            TBFileAddress.Text = ""
            TBFileAddress.Text = fdlg.FileName
        End If
        fdlg.Dispose()
    End Sub

    Private Sub GVData_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If id_pop_up = "1" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        ElseIf id_pop_up = "2" Or id_pop_up = "3" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormImportExcel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        Cursor = Cursors.WaitCursor
        Try

        Catch ex As Exception
            stopCustom("Import failed. Please make sure : " & vbNewLine & "- Row data not empty" & vbNewLine & "- Value in correct format")
        End Try
        If Not GVData.RowCount > 0 Then
            infoCustom("No data imported.")
            Close()
        Else
            If id_pop_up = "1" Then
                'MASTER PRODUCT
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_item(id_size, item_code, item_name, price) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim item_code As String = addSlashes(GVData.GetRowCellValue(l, "Code").ToString)
                            Dim item_name As String = addSlashes(GVData.GetRowCellValue(l, "Description").ToString)
                            Dim price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)
                            Dim id_size As String = addSlashes(GVData.GetRowCellValue(l, "IdSize").ToString)
                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_size + "','" + item_code + "', '" + item_name + "', '" + price + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormItem.viewItem()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "2" Then
                'adj out
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor

                        'ins
                        FormAdjOut.viewDetail()
                        Dim l_i As Integer = 0
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_item As String = addSlashes(GVData.GetRowCellValue(l, "id_item").ToString)
                            Dim item_code As String = addSlashes(GVData.GetRowCellValue(l, "Code").ToString)
                            Dim item_name As String = addSlashes(GVData.GetRowCellValue(l, "Description").ToString)
                            Dim price As Decimal = GVData.GetRowCellValue(l, "Price")
                            Dim qty As Decimal = GVData.GetRowCellValue(l, "Qty")
                            Dim size As String = GVData.GetRowCellValue(l, "Size").ToString

                            FormAdjOut.addRows(id_item, item_code, item_name, size, qty, price)
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "3" Then
                'adj in
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor

                        'ins
                        FormAdjIn.viewDetail()
                        Dim l_i As Integer = 0
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_item As String = addSlashes(GVData.GetRowCellValue(l, "id_item").ToString)
                            Dim item_code As String = addSlashes(GVData.GetRowCellValue(l, "Code").ToString)
                            Dim item_name As String = addSlashes(GVData.GetRowCellValue(l, "Description").ToString)
                            Dim price As Decimal = GVData.GetRowCellValue(l, "Price")
                            Dim qty As Decimal = GVData.GetRowCellValue(l, "Qty")
                            Dim size As String = GVData.GetRowCellValue(l, "Size").ToString

                            FormAdjIn.addRows(id_item, item_code, item_name, size, qty, price)
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "List Import Excel")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GVData.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currentDataView As DataView = TryCast(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).DataSource, DataView)
        If view.FocusedColumn.FieldName = "Code" Then
            'check duplicate code
            Dim currentCode As String = e.Value.ToString()
            For i As Integer = 0 To currentDataView.Count - 1
                If i <> view.GetDataSourceRowIndex(view.FocusedRowHandle) Then
                    If currentDataView(i)("Code").ToString() = currentCode Then
                        MsgBox("Duplicate Code detected.")
                        e.ErrorText = "Duplicate Code detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FormImportExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        If id_pop_up = "6" Or id_pop_up = "18" Then
            TBFileAddress.Text = My.Application.Info.DirectoryPath.ToString & "\import\sales_pos.xlsx"
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub FormImportExcel_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub PanelControl5_Click(sender As Object, e As EventArgs) Handles PanelControl5.Click
        Close()
    End Sub
End Class