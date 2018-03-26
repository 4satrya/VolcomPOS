Imports System.Runtime.InteropServices
Public Class FormUser
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr,
      ByVal Msg As Integer, ByVal wParam As Integer,
      ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GVRole.Focus()
        viewRole()
        viewUser()
        viewPOS()

        'opt
        Dim qopt As String = "SELECT * FROM tb_opt"
        Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
        TxtCompName.Text = dopt.Rows(0)("company_name").ToString
        TxtTagline.Text = dopt.Rows(0)("company_tagline").ToString
        TxtOutletName.Text = dopt.Rows(0)("outlet_name").ToString
        TxtOutletId.Text = dopt.Rows(0)("id_outlet").ToString
        TxtSupervisor.Text = dopt.Rows(0)("spv").ToString
        TxtHost.Text = dopt.Rows(0)("host_main").ToString
        TxtUsername.Text = dopt.Rows(0)("username_main").ToString
        TxtPass.Text = dopt.Rows(0)("pass_main").ToString
        TxtDB.Text = dopt.Rows(0)("db_main").ToString
        TxtH1.Text = dopt.Rows(0)("header_1").ToString
        TxtH2.Text = dopt.Rows(0)("header_2").ToString
        TxtH3.Text = dopt.Rows(0)("header_3").ToString
        TxtH4.Text = dopt.Rows(0)("header_4").ToString
        TxtH5.Text = dopt.Rows(0)("header_5").ToString
        TxtH6.Text = dopt.Rows(0)("header_closing").ToString
        TxtF1.Text = dopt.Rows(0)("footer_1").ToString
        TxtF2.Text = dopt.Rows(0)("footer_2").ToString
        TxtF3.Text = dopt.Rows(0)("footer_3").ToString
        TxtF4.Text = dopt.Rows(0)("footer_4").ToString
        TxtGreet1.Text = dopt.Rows(0)("vfd_greet1").ToString
        TxtGreet2.Text = dopt.Rows(0)("vfd_greet2").ToString
        TxtFW1.Text = dopt.Rows(0)("vfd_bye1").ToString
        TxtFW2.Text = dopt.Rows(0)("vfd_bye2").ToString

        'sync
        Dim qs As String = "SELECT *, 'No' as `is_select` FROM tb_sync_data a ORDER BY a.id_sync_data ASC "
        Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
        GCData.DataSource = ds
    End Sub

    Sub logData()
        Dim id_sync_data = "-1"
        Try
            id_sync_data = GVData.GetFocusedRowCellValue("id_sync_data").ToString()
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT *, IF(is_success=1,'Success', 'Failure') AS `status` FROM tb_sync_log WHERE id_sync_data = " + id_sync_data + " ORDER BY sync_time DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLog.DataSource = data
    End Sub

    Sub viewRole()
        Dim role As New ClassUser()
        Dim query As String = role.queryRole("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
    End Sub

    Sub viewPOS()
        Dim query As String = "SELECT * FROM tb_pos_dev pd ORDER BY pd.id_pos_dev ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOS.DataSource = data
    End Sub

    Sub viewUser()
        Dim user As New ClassUser()
        Dim query As String = user.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUser.DataSource = data
    End Sub

    Private Sub FormUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim acc As New ClassUser()
        acc.logout()
        Dispose()
    End Sub

    Sub editRole()
        Cursor = Cursors.WaitCursor
        FormUserRole.id = GVRole.GetFocusedRowCellValue("id_role").ToString
        FormUserRole.action = "upd"
        FormUserRole.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub editUser()
        Cursor = Cursors.WaitCursor
        FormUserDet.id = GVUser.GetFocusedRowCellValue("id_user").ToString
        FormUserDet.action = "upd"
        FormUserDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUser_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Escape Then 'close
            Close()
        ElseIf e.KeyCode = Keys.F8 Then 'new
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                FormUserRole.action = "ins"
                FormUserRole.ShowDialog()
            ElseIf XTCUser.SelectedTabPageIndex = 1 Then
                FormUserDet.action = "ins"
                FormUserDet.ShowDialog()
            ElseIf XTCUser.SelectedTabPageIndex = 2 Then
                TxtPOSID.Text = ""
                TxtPOS.Text = ""
                TxtMac.Text = ""
                TxtPOS.Focus()
            End If
        ElseIf e.KeyCode = Keys.F7 Then 'edit
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                editRole()
            ElseIf XTCUser.SelectedTabPageIndex = 1 Then
                editUser()
            ElseIf XTCUser.SelectedTabPageIndex = 2 Then
                TxtPOSID.Text = GVPOS.GetFocusedRowCellValue("id_pos_dev").ToString
                TxtPOS.Text = GVPOS.GetFocusedRowCellValue("pos_dev").ToString
                TxtMac.Text = GVPOS.GetFocusedRowCellValue("mac_address").ToString
                TxtPOS.Focus()
            End If
        ElseIf e.KeyCode = Keys.F9 Then 'delete
            If XTCUser.SelectedTabPageIndex = 0 Then 'role
                If GVRole.FocusedRowHandle >= 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Try
                            Dim id As String = GVRole.GetFocusedRowCellValue("id_role").ToString
                            Dim query As String = "DELETE FROM tb_role WHERE id_role=" + id + " "
                            execute_non_query(query, True, "", "", "", "")
                            viewRole()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                End If
            ElseIf XTCUser.SelectedTabPageIndex = 1 Then
                If GVUser.FocusedRowHandle >= 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Try
                            Dim id As String = GVUser.GetFocusedRowCellValue("id_user").ToString
                            Dim query As String = "DELETE FROM tb_user WHERE id_user=" + id + " "
                            execute_non_query(query, True, "", "", "", "")
                            viewUser()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                End If
            ElseIf XTCUser.SelectedTabPageIndex = 2 Then
                If GVPOS.FocusedRowHandle >= 0 Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = DialogResult.Yes Then
                        Try
                            Dim id As String = GVPOS.GetFocusedRowCellValue("id_pos_dev").ToString
                            Dim query As String = "DELETE FROM tb_pos_dev WHERE id_pos_dev=" + id + " "
                            execute_non_query(query, True, "", "", "", "")
                            viewPOS()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCUser_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUser.SelectedPageChanged
        If XTCUser.SelectedTabPageIndex = 0 Then
            GVRole.Focus()
        ElseIf XTCUser.SelectedTabPageIndex = 1 Then
            GVUser.Focus()
        End If
    End Sub

    Private Sub GVRole_DoubleClick(sender As Object, e As EventArgs) Handles GVRole.DoubleClick
        If GVRole.FocusedRowHandle >= 0 And GVRole.RowCount > 0 Then
            editRole()
        End If
    End Sub

    Private Sub GVUser_DoubleClick(sender As Object, e As EventArgs) Handles GVUser.DoubleClick
        editUser()
    End Sub

    Private Sub PanelControlBack_MouseHover(sender As Object, e As EventArgs) Handles PanelControlBack.MouseHover
        PanelControlBack.Cursor = Cursors.Hand
    End Sub

    Private Sub PanelControlBack_MouseLeave(sender As Object, e As EventArgs) Handles PanelControlBack.MouseLeave
        PanelControlBack.Cursor = Cursors.Default
    End Sub

    Private Sub PanelControlBack_Click(sender As Object, e As EventArgs) Handles PanelControlBack.Click
        Close()
    End Sub

    Private Sub FormUser_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN,
               HT_CAPTION, 0)
        End If
    End Sub

    Private Sub BtnSaveProfile_Click(sender As Object, e As EventArgs) Handles BtnSaveProfile.Click
        Dim company_name As String = addSlashes(TxtCompName.Text)
        Dim company_tagline As String = addSlashes(TxtTagline.Text)
        Dim outlet_name As String = addSlashes(TxtOutletName.Text)
        Dim id_outlet As String = addSlashes(TxtOutletId.Text)
        Dim spv As String = addSlashes(TxtSupervisor.Text)
        Try
            Dim query As String = "UPDATE tb_opt SET 
            company_name = '" + company_name + "',
            company_tagline  = '" + company_tagline + "',
            outlet_name = '" + outlet_name + "',
            id_outlet ='" + id_outlet + "',
            spv='" + spv + "' "
            execute_non_query(query, True, "", "", "", "")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub BtnSaveSvr_Click(sender As Object, e As EventArgs) Handles BtnSaveSvr.Click
        Dim host_main As String = addSlashes(TxtHost.Text)
        Dim username_main As String = addSlashes(TxtUsername.Text)
        Dim pass_main As String = addSlashes(TxtPass.Text)
        Dim db_main As String = addSlashes(TxtDB.Text)
        Try
            Dim query As String = "UPDATE tb_opt SET 
            host_main = '" + host_main + "',
            username_main  = '" + username_main + "',
            pass_main = '" + pass_main + "',
            db_main ='" + db_main + "' "
            execute_non_query(query, True, "", "", "", "")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub BtnOutlet_Click(sender As Object, e As EventArgs) Handles BtnOutlet.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormDept.ShowDialog()
        FormBlack.Close()
        BringToFront()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSPV_Click(sender As Object, e As EventArgs) Handles BtnSPV.Click
        Cursor = Cursors.WaitCursor
        FormBlack.Show()
        FormEmp.ShowDialog()
        FormBlack.Close()
        BringToFront()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveRc_Click(sender As Object, e As EventArgs) Handles BtnSaveRc.Click
        Dim header_1 As String = addSlashes(TxtH1.Text)
        Dim header_2 As String = addSlashes(TxtH2.Text)
        Dim header_3 As String = addSlashes(TxtH3.Text)
        Dim header_4 As String = addSlashes(TxtH4.Text)
        Dim header_5 As String = addSlashes(TxtH5.Text)
        Dim header_closing As String = addSlashes(TxtH6.Text)
        Dim footer_1 As String = addSlashes(TxtF1.Text)
        Dim footer_2 As String = addSlashes(TxtF2.Text)
        Dim footer_3 As String = addSlashes(TxtF3.Text)
        Dim footer_4 As String = addSlashes(TxtF4.Text)
        Try
            Dim query As String = "UPDATE tb_opt SET 
            header_1  = '" + header_1 + "',
            header_2  = '" + header_2 + "',
            header_3  = '" + header_3 + "',
            header_4  = '" + header_4 + "',
            header_5  = '" + header_5 + "',
            header_closing  = '" + header_closing + "',
            footer_1  = '" + footer_1 + "',
            footer_2  = '" + footer_2 + "',
            footer_3  = '" + footer_3 + "',
            footer_4  = '" + footer_4 + "' "
            execute_non_query(query, True, "", "", "", "")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        GCLog.DataSource = Nothing
    End Sub

    Private Sub BtnSync_Click(sender As Object, e As EventArgs) Handles BtnSync.Click
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want sync these data?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                SplashScreenManager1.ShowWaitForm()
                Dim sy As New ClassSync()
                sy.splash = "1"
                For i As Integer = 0 To GVData.RowCount - 1
                    sy.sync_list.Add(GVData.GetRowCellValue(i, "id_sync_data").ToString)
                Next
                sy.synchronize()
                SplashScreenManager1.CloseWaitForm()
            End If
        End If
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        logData()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnVFD_Click(sender As Object, e As EventArgs) Handles BtnVFD.Click
        Dim vfd_greet1 As String = addSlashes(TxtGreet1.Text)
        Dim vfd_greet2 As String = addSlashes(TxtGreet2.Text)
        Dim vfd_bye1 As String = addSlashes(TxtFW1.Text)
        Dim vfd_bye2 As String = addSlashes(TxtFW2.Text)
        Try
            Dim query As String = "UPDATE tb_opt SET 
            vfd_greet1  = '" + vfd_greet1 + "',
            vfd_greet2  = '" + vfd_greet2 + "',
            vfd_bye1  = '" + vfd_bye1 + "',
            vfd_bye2  = '" + vfd_bye2 + "' "
            execute_non_query(query, True, "", "", "", "")
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GCData_Click(sender As Object, e As EventArgs) Handles GCData.Click

    End Sub

    Private Sub BtnOff_Click(sender As Object, e As EventArgs) Handles BtnOff.Click
        execute_non_query("UPDATE tb_opt SET sync_startup=2", True, "", "", "", "")
    End Sub

    Private Sub BtnOn_Click(sender As Object, e As EventArgs) Handles BtnOn.Click
        execute_non_query("UPDATE tb_opt SET sync_startup=1", True, "", "", "", "")
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPOS.EditValueChanged

    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub TxtPOSID_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPOSID.EditValueChanged

    End Sub

    Private Sub TxtPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMac.Focus()
        End If
    End Sub

    Private Sub TxtMac_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMac.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnPOS.Focus()
        End If
    End Sub

    Private Sub BtnPOS_Click(sender As Object, e As EventArgs) Handles BtnPOS.Click
        Cursor = Cursors.WaitCursor
        Dim id As String = TxtPOSID.Text
        Dim pos_dev As String = addSlashes(TxtPOS.Text)
        Dim mac_address As String = addSlashes(TxtMac.Text)
        If id = "" Then
            Dim query As String = "INSERT INTO tb_pos_dev(pos_dev, mac_address) VALUES('" + pos_dev + "', '" + mac_address + "') "
            execute_non_query(query, True, "", "", "", "")
        Else
            Dim query As String = "UPDATE tb_pos_dev SET pos_dev='" + pos_dev + "', mac_address='" + mac_address + "' WHERE id_pos_dev=" + id + ""
            execute_non_query(query, True, "", "", "", "")
        End If
        TxtPOSID.Text = ""
        TxtPOS.Text = ""
        TxtMac.Text = ""
        viewPOS()
        Cursor = Cursors.Default
    End Sub
End Class