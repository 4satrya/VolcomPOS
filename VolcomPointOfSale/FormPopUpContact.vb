Public Class FormPopUpContact
    Public id_pop_up As String = "-1"
    Public id_comp_contact As String = "-1"
    Public id_cat As String = "-1"
    Public id_departement As String = "-1"
    Public id_so_type As String = "-1"
    Public cond As String = ""
    'id use of pop up
    '1 = comp_to sample purchase det

    Private Sub FormPopUpContact_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub FormPopUpContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_company()
        If id_comp_contact <> "-1" Then
            Dim id_comp As String
            id_comp = get_id_company(id_comp_contact)
            GVCompany.FocusedRowHandle = find_row(GVCompany, "id_comp", id_comp)
            GVCompanyContactList.FocusedRowHandle = find_row(GVCompanyContactList, "id_comp_contact", id_comp_contact)
        End If
    End Sub

    Private Sub FormPopUpContact_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GVCompany.ShowFindPanel()
        GVCompany.ShowFindPanel()
    End Sub

    Sub view_contact(ByVal id_company As String)
        If id_company = "" Or id_company < "0" Then
            id_company = "-1"
        End If

        Dim data As DataTable = execute_query(String.Format("SELECT id_comp_contact, getCompByContact(id_comp_contact, 4) AS `id_wh_drawer`, getCompByContact(id_comp_contact, 6) AS `id_wh_rack`, getCompByContact(id_comp_contact, 7) AS `id_wh_locator`, contact_person,contact_number,is_default FROM tb_m_comp_contact WHERE id_comp='{0}' ORDER BY is_default AND contact_person", id_company), -1, True, "", "", "", "")
        GCCompanyContactList.DataSource = data
        If Not data.Rows.Count > 0 Or id_company = "-1" Then
            BtnSave.Enabled = False
        Else
            BtnSave.Enabled = True
        End If
    End Sub

    Sub view_company()
        Dim query As String = "SELECT tb_m_comp.comp_commission,tb_m_comp.id_comp as id_comp,tb_m_comp.comp_number as comp_number,tb_m_comp.comp_name as comp_name,tb_m_comp.address_primary as address_primary,tb_m_comp.is_active as is_active,tb_m_comp_cat.comp_cat_name as company_category,tb_m_comp_group.comp_group, tb_m_comp.id_wh_type "
        query += " FROM tb_m_comp INNER JOIN tb_m_comp_cat ON tb_m_comp.id_comp_cat=tb_m_comp_cat.id_comp_cat "
        query += " INNER JOIN tb_m_comp_group ON tb_m_comp_group.id_comp_group=tb_m_comp.id_comp_group "
        If id_cat <> "-1" Then
            query += "AND tb_m_comp.id_comp_cat = '" + id_cat + "' "
        End If
        If id_departement <> "-1" Then
            query += "AND tb_m_comp.id_departement = '" + id_departement + "' "
        End If
        If id_so_type <> "-1" Then
            If id_so_type = "0" Then
                query += "AND (tb_m_comp.id_so_type = '" + id_so_type + "' OR ISNULL(tb_m_comp.id_so_type)) "
            Else
                query += "AND tb_m_comp.id_so_type = '" + id_so_type + "' "
            End If
        End If

        'by condition
        If cond <> "" Then
            query += cond + " "
        End If

        query += "ORDER BY comp_name "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.OptionsBehavior.AutoExpandAllGroups = True
        If data.Rows.Count > 0 Then
            GVCompany.FocusedRowHandle = 0
            view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
        Else
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub GVCompany_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCompany.FocusedRowChanged
        view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
    End Sub

    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            'REC FROM
            FormRecDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormRecDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormRecDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormRecDet.viewDetail()
            Close()
        ElseIf id_pop_up = "2" Then
            'REC TO
            FormRecDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormRecDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormRecDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "3" Then
            ' RET FROM
            FormRetDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormRetDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormRetDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "4" Then
            'RET TO
            FormRetDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormRetDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormRetDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormRetDet.viewDetail()
            Close()
        ElseIf id_pop_up = "5" Then
            'TRF FROM
            FormTrfDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormTrfDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormTrfDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormTrfDet.viewDetail()
            Close()
        ElseIf id_pop_up = "6" Then
            'TRF TO
            FormTrfDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormTrfDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormTrfDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "7" Then
            'Stock Opname
            FormSODet.id_comp = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormSODet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSODet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSODet.viewDetail()
            Close()
        ElseIf id_pop_up = "8" Then
            'Adj Out
            FormAdjOut.id_comp = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormAdjOut.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormAdjOut.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormAdjOut.viewDetail()
            Close()
        ElseIf id_pop_up = "9" Then
            'Adj In
            FormAdjIn.id_comp = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormAdjIn.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormAdjIn.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormAdjIn.viewDetail()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpContact_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVCompany_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCompany.ColumnFilterChanged
        view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
    End Sub

    Private Sub BAddComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddComp.Click
        FormMasterCompanySingle.id_company = "-1"
        FormMasterCompanySingle.id_pop_up = "1"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BEditComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditComp.Click
        FormMasterCompanySingle.id_company = GVCompany.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanySingle.id_pop_up = "1"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BDelComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelComp.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this company ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_company As String = GVCompany.GetFocusedRowCellValue("id_comp").ToString

        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_comp WHERE id_comp = '{0}'", id_company)
                execute_non_query(query, True, "", "", "", "")
                view_company()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BContact.Click
        FormMasterCompanyContact.id_company = GVCompany.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanyContact.id_pop_up = "1"
        FormMasterCompanyContact.ShowDialog()
    End Sub
End Class