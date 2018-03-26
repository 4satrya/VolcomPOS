Imports System.Runtime.InteropServices
Public Class FormFront
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2
    Public connection_problem As Boolean = False
    Public first_open As Boolean = True

    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr,
      ByVal Msg As Integer, ByVal wParam As Integer,
      ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub TIExitProg_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Cursor = Cursors.WaitCursor
        End
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFront_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TIInv_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub TIPOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

    End Sub

    Private Sub FormFront_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        apply_skin()
        Cursor = Cursors.WaitCursor
        Try
            read_database_configuration()
            check_connection(True, "", "", "", "")
            Cursor = Cursors.Default
            Opacity = 100
        Catch ex As Exception
            Cursor = Cursors.Default
            connection_problem = True
            FormDatabase.id_type = "2"
            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False
            Exit Sub
        End Try
        info()
        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."

        'sync startup
        Dim check_sync_startup As String = execute_query("SELECT sync_startup FROM tb_opt", 0, True, "", "", "", "")
        If check_sync_startup = "1" Then
            syncProcess()
        End If
    End Sub

    Sub syncProcess()
        'sync
        SplashScreenManager1.ShowWaitForm()
        Dim sy As New ClassSync()
        Dim query As String = "SELECT * FROM tb_sync_data ORDER BY id_sync_data ASC"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 1 To dt.Rows.Count
            sy.sync_list.Add(i.ToString)
        Next
        sy.synchronize()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FormFront_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            '20x2
            Dim sp As New IO.Ports.SerialPort()

            sp.PortName = "COM4"
            sp.BaudRate = 9600
            sp.Open()
            sp.WriteLine("                                        ")
            sp.Close()
            sp.Dispose()
            sp = Nothing


            'Cursor = Cursors.WaitCursor
            'Dim sy As New ClassSync()
            'sy.BackupCustomTable()
            'Cursor = Cursors.Default
            'Dim prn As New ClassPOS()
            'prn.printPos(90, False)
            ' FormPOSCopy.ShowDialog()
            'ReportPOSCopy.id = "89"
            'Dim Report As New ReportPOSCopy()
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.PreviewForm.PrintControl.Zoom = 2.0F
            'Tool.PreviewForm.FormBorderStyle = FormBorderStyle.None
            'Tool.ShowPreviewDialog()
        ElseIf e.KeyCode = Keys.F2 Then
            Dim sp As New IO.Ports.SerialPort()

            sp.PortName = "COM4"
            sp.BaudRate = 9600
            sp.Open()
            sp.Write(Convert.ToString(ChrW(12)))
            sp.WriteLine("1st line")
            sp.WriteLine(ChrW(13) & "2nd line")
            sp.Close()
            sp.Dispose()
            sp = Nothing
        End If
    End Sub

    Private Sub TIEnd_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        End
    End Sub

    Private Sub PCClose_Click(sender As Object, e As EventArgs) Handles PCClose.Click
        End
    End Sub

    Private Sub PIInv_Click(sender As Object, e As EventArgs) Handles PIInv.Click
        Opacity = 0
        FormLoginInv.ShowDialog()
    End Sub

    Private Sub PIPOS_Click(sender As Object, e As EventArgs) Handles PIPOS.Click
        FormLogin.is_open_form = True
        FormLogin.menu_acc = "14"
        FormLogin.ShowDialog()
    End Sub

    Sub info()
        Dim query As String = "select * from tb_opt o JOIN (SELECT DATE_FORMAT(NOW(),'%W, %d %M %Y') AS dt) d"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LabelStoreName.Text = data.Rows(0)("outlet_name").ToString
        LabelFooter.Text = data.Rows(0)("company_name").ToString + " - " + data.Rows(0)("company_tagline").ToString
        LabelDate.Text = data.Rows(0)("dt").ToString.ToUpper

        Dim str As String = ""
        Dim csh As String = ""
        Dim id_pos_dev As String = ""
        Dim pos As New ClassPOS()
        Dim dt_comp As DataTable = pos.getPOSDev()
        If dt_comp.Rows.Count <= 0 Then
            str += "This computer is not registered "
        Else
            id_pos_dev = dt_comp.Rows(0)("id_pos_dev").ToString
            str += "POS#" + dt_comp.Rows(0)("pos_dev").ToString + " "
        End If

        'cek sudah ada inisialize atau belum
        Dim query_open As String = pos.queryShift("AND s.id_pos_dev=" + id_pos_dev + " AND s.is_open=1", "2")
        Dim dt_open As DataTable = execute_query(query_open, -1, True, "", "", "", "")
        If dt_open.Rows.Count <= 0 Then
            str += "/ NO SHIFT "
            csh += "CASHIER ACTIVE : -"
        Else
            str += "/ SHIFT " + dt_open.Rows(0)("shift_type").ToString
            csh += "CASHIER ACTIVE : " + dt_open.Rows(0)("username").ToString.ToUpper
        End If
        LabelInfo.Text = str
        LabelCsh.Text = csh

        'vfd
        If Not first_open Then
            Cursor = Cursors.WaitCursor
            Threading.Thread.Sleep(1000)
            pos.vfdDisplayText(data.Rows(0)("vfd_greet1").ToString, data.Rows(0)("vfd_greet2").ToString)
            Cursor = Cursors.Default
        Else
            pos.vfdDisplayText(data.Rows(0)("vfd_greet1").ToString, data.Rows(0)("vfd_greet2").ToString)
        End If
        first_open = True
    End Sub

    Private Sub PISync_Click(sender As Object, e As EventArgs) Handles PISync.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want sync these data?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            syncProcess()
        End If
    End Sub

    Private Sub PanelControl4_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelControl4.MouseDown
        Cursor = Cursors.SizeAll
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN,
               HT_CAPTION, 0)
        End If
    End Sub

    Private Sub PanelControl4_MouseHover(sender As Object, e As EventArgs) Handles PanelControl4.MouseHover
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub PanelControl4_MouseLeave(sender As Object, e As EventArgs) Handles PanelControl4.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub PCClose_MouseHover(sender As Object, e As EventArgs) Handles PCClose.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub PCClose_MouseLeave(sender As Object, e As EventArgs) Handles PCClose.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFront_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        info()
    End Sub

    Private Sub PictureEdit1_Click(sender As Object, e As EventArgs) Handles PIStock.Click
        Cursor = Cursors.WaitCursor
        FormStock.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class