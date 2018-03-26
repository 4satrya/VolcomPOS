Public Class ClassUser
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT u.id_user, u.id_role, r.role, u.id_employee, e.employee_code,e.employee_name, u.username, u.password, u.is_change 
        FROM tb_user u 
        INNER JOIN tb_role r ON r.id_role = u.id_role 
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee 
        WHERE u.id_user>0 "
        query += condition + " "
        query += "ORDER BY u.id_user " + order_type
        Return query
    End Function

    Public Function queryRole(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT * FROM tb_role r 
        WHERE r.id_role >0 "
        query += condition + " "
        query += "ORDER BY r.id_role " + order_type
        Return query
    End Function

    Public Sub access(e As KeyEventArgs, form As DevExpress.XtraEditors.XtraForm)
        Dim form_name As String = form.Name.ToString
        Dim is_allow_view As Boolean = False
        Dim is_allow_new As Boolean = True
        Dim is_allow_edit As Boolean = True
        Dim is_allow_delete As Boolean = False

        If e.KeyCode = Keys.Escape Then 'close
            form.Close()
        ElseIf e.KeyCode = Keys.Insert And is_allow_new Then 'new
            If form_name = "FormUser" Then
                If FormUser.XTCUser.SelectedTabPageIndex = 0 Then 'role
                    FormUserRole.action = "ins"
                    FormUserRole.ShowDialog()
                Else

                End If
            End If
        ElseIf e.KeyCode = Keys.Enter And is_allow_edit Then 'edit
            If form_name = "FormUser" Then
                If FormUser.XTCUser.SelectedTabPageIndex = 0 Then 'role
                    FormUserRole.id = FormUser.GVRole.GetFocusedRowCellValue("id_role").ToString
                    FormUserRole.action = "upd"
                    FormUserRole.ShowDialog()
                Else 'user

                End If
            End If

        ElseIf e.KeyCode = Keys.Delete And is_allow_delete Then 'delete
            If form_name = "FormUser" Then

            End If
        End If
    End Sub

    Public Sub hideMenu()
        For m As Integer = 0 To FormHome.TileControl1.Groups.Count - 1
            Dim group As DevExpress.XtraEditors.TileGroup = TryCast(FormHome.TileControl1.Groups(m), DevExpress.XtraEditors.TileGroup)
            For i As Integer = 0 To group.Items.Count - 1
                If TypeOf group.Items(i) Is DevExpress.XtraEditors.TileItem Then
                    Dim item As DevExpress.XtraEditors.TileItem = TryCast(group.Items(i), DevExpress.XtraEditors.TileItem)
                    If item.Name.ToString <> "TIExit" And item.Name.ToString <> "TIAccount" And item.Name.ToString <> "TINotif" Then
                        item.Visible = False
                    End If
                End If
            Next i
        Next
    End Sub

    Public Sub showMenu()
        Dim query As String = "SELECT a.id_role, a.id_menu, m.menu, m.menu_tile 
        FROM tb_menu_access a 
        INNER JOIN tb_menu m ON m.id_menu = a.id_menu
        WHERE a.id_role=" + id_role_login + " "
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        For m As Integer = 0 To FormHome.TileControl1.Groups.Count - 1
            Dim group As DevExpress.XtraEditors.TileGroup = TryCast(FormHome.TileControl1.Groups(m), DevExpress.XtraEditors.TileGroup)
            For i As Integer = 0 To group.Items.Count - 1
                If TypeOf group.Items(i) Is DevExpress.XtraEditors.TileItem Then
                    Dim item As DevExpress.XtraEditors.TileItem = TryCast(group.Items(i), DevExpress.XtraEditors.TileItem)
                    If item.Name.ToString <> "TIExit" And item.Name.ToString <> "TIAccount" And item.Name.ToString <> "TINotif" Then
                        Dim dtf As DataRow() = dt.Select("[menu_tile]='" + item.Name.ToString + "'")
                        If dtf.Length > 0 Then
                            item.Visible = True
                        Else
                            item.Visible = False
                        End If
                    End If
                End If
            Next i
        Next
    End Sub

    Public Sub setMenuAccess()
        For m As Integer = 0 To FormHome.TileControl1.Groups.Count - 1
            Dim group As DevExpress.XtraEditors.TileGroup = TryCast(FormHome.TileControl1.Groups(m), DevExpress.XtraEditors.TileGroup)
            For i As Integer = 0 To group.Items.Count - 1
                If TypeOf group.Items(i) Is DevExpress.XtraEditors.TileItem Then
                    Dim item As DevExpress.XtraEditors.TileItem = TryCast(group.Items(i), DevExpress.XtraEditors.TileItem)
                    Dim data_filter As DataRow() = dt_acc.Select("[menu]='" + item.Name.ToString + "'")
                    If data_filter.Length > 0 Then
                        item.Visible = True
                    End If
                End If
            Next i
        Next
    End Sub

    Public Sub setDataAccess()
        Dim query As String = "SELECT * FROM tb_menu_access a
        INNER JOIN tb_menu m ON m.id_menu = a.id_menu
        WHERE a.id_role = '" + id_role_login + "'"
        dt_acc = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Public Sub clearDataAccess()
        dt_acc.Clear()
    End Sub

    Public Sub logout()
        Try
            id_user = Nothing
            id_role_login = Nothing
            role_login = Nothing
            username_user = Nothing
            name_user = Nothing
            is_change_pass_user = Nothing
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    'check access menu user
    Public Sub checkAccess(ByVal id_menu As String, open_form As Boolean)
        Dim query As String = "SELECT COUNT(*) FROM tb_menu_access a
        INNER JOIN tb_menu m ON m.id_menu = a.id_menu
        WHERE a.id_role='" + id_role_login + "' AND m.id_menu='" + id_menu + "' "
        Dim jum As String = execute_query(query, 0, True, "", "", "", "")
        If jum > 0 Then
            If open_form Then
                If id_menu = "1" Then
                    'ADMIN SETUP
                    FormUser.ShowDialog()
                ElseIf id_menu = "2" Then
                    'MASTER PRODUCT
                    FormItem.ShowDialog()
                ElseIf id_menu = "14" Then
                    'POS
                    FormPOS.ShowDialog()
                End If
            Else
                is_auth = True
            End If
        Else
            stopCustom("Access denied")
        End If
    End Sub

    Function getHostName() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Return strHostName
    End Function

    Function getIP() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim strIPAddress As String = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function

    Function getMacAddress()
        Dim nics() As Net.NetworkInformation.NetworkInterface = Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        Return nics(0).GetPhysicalAddress.ToString
    End Function
End Class
