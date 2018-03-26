Public Class FormItemDet
    Public action As String = ""
    Public id As String = "-1"
    Public old_price As String = ""

    Private Sub FormItemDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSize()
        viewCat()
        viewColor()
        viewClass()
        viewSupp()
        viewSoType()
        actionLoad()
        SLESize.ShowPopup()
    End Sub

    Sub viewSize()
        Dim query As String = "SELECT * FROM tb_size ORDER BY size ASC "
        viewSearchLookupQuery(SLESize, query, "id_size", "size", "id_size")
    End Sub

    Sub viewCat()
        Dim query As String = "SELECT * FROM tb_lookup_design_cat ORDER BY design_cat ASC "
        viewSearchLookupQuery(SLECat, query, "id_design_cat", "design_cat", "id_design_cat")
    End Sub

    Sub viewColor()
        Dim query As String = "SELECT * FROM tb_color ORDER BY color ASC "
        viewSearchLookupQuery(SLEColor, query, "id_color", "color", "id_color")
    End Sub


    Sub viewClass()
        Dim query As String = "SELECT * FROM tb_class ORDER BY class_display ASC "
        viewSearchLookupQuery(SLEClass, query, "id_class", "class_display", "id_class")
    End Sub

    Sub viewSupp()
        Dim supp As New ClassComp()
        Dim query As String = supp.queryMain("-1", "1", False)
        viewSearchLookupQuery(SLESupplier, query, "id_comp", "comp", "id_comp")
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a WHERE a.id_so_type>0 ORDER BY a.id_so_type ASC "
        viewSearchLookupQuery(SLEType, query, "id_so_type", "so_type", "id_so_type")
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim i As New ClassItem()
            Dim query As String = i.queryMain("AND i.id_item=" + id + "", "1", False)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtCode.Text = data.Rows(0)("item_code").ToString
            TxtDesc.Text = data.Rows(0)("item_name").ToString
            TxtPrice.EditValue = data.Rows(0)("price")
            SLEColor.EditValue = data.Rows(0)("id_color").ToString
            SLEClass.EditValue = data.Rows(0)("id_class").ToString
            SLESize.EditValue = data.Rows(0)("id_size").ToString
            SLECat.EditValue = data.Rows(0)("id_design_cat").ToString
            SLEType.EditValue = data.Rows(0)("id_so_type").ToString
            SLESupplier.EditValue = data.Rows(0)("id_comp_sup").ToString
            TxtComm.EditValue = data.Rows(0)("comm")
            getCommVal()
            old_price = decimalSQL(TxtPrice.EditValue.ToString)
            If data.Rows(0)("is_active").ToString = "2" Then
                CEActive.EditValue = True
            Else
                CEActive.EditValue = False
            End If

            viewPrice()
            XTPHist.PageVisible = True
        Else
            TxtPrice.EditValue = 0
            TxtComm.EditValue = 0
            TxtCommVal.EditValue = 0
            TxtCost.EditValue = 0
            XTPHist.PageVisible = False
        End If
    End Sub

    Sub viewPrice()
        Dim query As String = "SELECT * FROM tb_item_price a WHERE a.id_item=" + id + " ORDER BY a.price_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPrice.DataSource = data
    End Sub

    Private Sub FormItemDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim item_code As String = addSlashes(TxtCode.Text)
        Dim item_name As String = addSlashes(TxtDesc.Text)
        Dim price As String = decimalSQL(TxtPrice.EditValue.ToString)
        Dim id_size As String = SLESize.EditValue.ToString
        Dim id_design_cat As String = SLECat.EditValue.ToString
        Dim id_color As String = SLEColor.EditValue.ToString
        Dim id_class As String = SLEClass.EditValue.ToString
        Dim id_so_type As String = SLEType.EditValue.ToString
        Dim id_comp_sup As String = SLESupplier.EditValue.ToString
        Dim comm As String = decimalSQL(TxtComm.EditValue.ToString)
        Dim is_active As String = ""
        If CEActive.EditValue Then
            is_active = "2"
        Else
            is_active = "1"
        End If


        'cek duplikat
        Dim check As Boolean = True
        'Dim query_cek As String = "SELECT COUNT(*) FROM tb_item WHERE item_code='" + item_code + "' "
        'If action = "upd" Then
        '    query_cek += "AND id_item<>'" + id + "'"
        'End If
        'Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
        'If jum_cek > "0" Then
        '    check = False
        'Else
        '    check = True
        'End If

        If item_code = "" Or item_name = "" Or price = "" Then
            stopCustom("Data can't blank")
        ElseIf Not check
            stopCustom("Product code is already exist")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                If action = "ins" Then
                    Dim query As String = "INSERT INTO tb_item(item_code, item_name, id_size, id_design_cat, price, price_date, id_color, id_class, id_so_type, id_comp_sup, comm, is_active) 
                                           VALUES('" + item_code + "', '" + item_name + "', '" + id_size + "', '" + id_design_cat + "','" + price + "', NOW(), '" + id_color + "', '" + id_class + "', '" + id_so_type + "', '" + id_comp_sup + "', '" + comm + "', '" + is_active + "'); SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")

                    FormItem.viewItem()
                    FormItem.GVItem.FocusedRowHandle = find_row(FormItem.GVItem, "id_item", id)
                    Close()
                    'action = "upd"
                    'actionLoad()
                Else
                    Dim query As String = "UPDATE tb_item SET item_code='" + item_code + "', 
                    item_name='" + item_name + "', id_size='" + id_size + "', id_design_cat ='" + id_design_cat + "', 
                    id_color='" + id_color + "', id_class='" + id_class + "', id_so_type='" + id_so_type + "', id_comp_sup='" + id_comp_sup + "', comm='" + comm + "', is_active='" + is_active + "' "
                    If price <> old_price Then
                        query += ", price='" + price + "', price_date=NOW() "
                    End If
                    query += "WHERE id_item='" + id + "' "
                    execute_non_query(query, True, "", "", "", "")

                    FormItem.viewItem()
                    FormItem.GVItem.FocusedRowHandle = find_row(FormItem.GVItem, "id_item", id)
                    action = "upd"
                    actionLoad()
                End If
            End If
        End If
    End Sub
    Private Sub SLESize_Focus(sender As Object, e As EventArgs) Handles SLESize.GotFocus
        SLESize.ShowPopup()
    End Sub

    Sub checkCode()
        'find existing code
        Dim code As String = addSlashes(TxtCode.Text)
        Dim find As New ClassItem()
        Dim cond As String = "AND i.item_code='" + code + "' "
        If action = "upd" Then
            cond += "AND i.id_item<>" + id + " "
        End If
        Dim data As DataTable = execute_query(find.queryMain(cond, "1", False), -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            stopCustom("Code already used")
            TxtCode.Text = ""
            TxtCode.Focus()
        Else
            TxtDesc.Focus()
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            checkCode()
        End If
    End Sub

    Private Sub TxtDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLEColor.Focus()
            SLEColor.ShowPopup()
        End If
    End Sub

    Private Sub SLEColor_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEColor.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLEClass.Focus()
            SLEClass.ShowPopup()
        End If
    End Sub

    Private Sub SLEClass_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEClass.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLESize.Focus()
            SLESize.ShowPopup()
        End If
    End Sub

    Private Sub TxtCode_Leave(sender As Object, e As EventArgs) Handles TxtCode.Leave
        checkCode()
    End Sub

    Private Sub SLESize_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESize.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLECat.Focus()
            SLECat.ShowPopup()
        End If
    End Sub

    Private Sub SLEType_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLESupplier.Focus()
            SLESupplier.ShowPopup()
        End If
    End Sub

    Private Sub SLESupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESupplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrice.Focus()
        End If
    End Sub

    Private Sub TxtPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtComm.Focus()
        End If
    End Sub

    Private Sub TxtPrice_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtPrice.KeyUp
        getCommVal()
    End Sub

    Private Sub TxtComm_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtComm.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        Else
            getCommVal()
        End If
    End Sub

    Private Sub TxtComm_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtComm.KeyUp
        getCommVal()
    End Sub

    Private Sub DERefDate_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            BtnSave.Focus()
        End If
    End Sub



    Sub getCommVal()
        Dim comm As Decimal = 0
        Try
            comm = TxtComm.EditValue
        Catch ex As Exception
        End Try
        Dim prc As Decimal = 0
        Try
            prc = TxtPrice.EditValue
        Catch ex As Exception
        End Try
        Dim res As Decimal = prc * (comm / 100)
        TxtCommVal.EditValue = res
    End Sub

    Private Sub TxtCommVal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtCommVal.EditValueChanged
        Dim comm_val As Decimal = 0
        Try
            comm_val = TxtCommVal.EditValue
        Catch ex As Exception
        End Try
        Dim prc As Decimal = 0
        Try
            prc = TxtPrice.EditValue
        Catch ex As Exception
        End Try
        TxtCost.EditValue = prc - comm_val
    End Sub

    Private Sub CEActive_CheckedChanged(sender As Object, e As EventArgs) Handles CEActive.CheckedChanged

    End Sub

    Private Sub SLESize_EditValueChanged(sender As Object, e As EventArgs) Handles SLESize.EditValueChanged

    End Sub

    Private Sub SLECat_KeyDown(sender As Object, e As KeyEventArgs) Handles SLECat.KeyDown
        If e.KeyCode = Keys.Enter Then
            SLEType.Focus()
            SLEType.ShowPopup()
        End If
    End Sub
End Class