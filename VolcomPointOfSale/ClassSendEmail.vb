Imports System.IO
Imports System.Net.Mail

Public Class ClassSendEmail
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"
    Public opt As String = "1"

    'comment mail
    Public season As String = ""
    Public date_string As String = ""
    Public comment_by As String = ""
    Public comment As String = ""
    Public design As String = ""
    Public design_code As String = ""
    Public type_email As String = "4"
    Public par1 As String = ""
    Public par2 As String = ""
    Public dt As DataTable

    Sub send_email()
        'get param
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString
        Dim client As SmtpClient = New SmtpClient()
        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        If report_mark_type = "14" Then
            'POS => opt=> 1 : cancel transaction
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Cancel Transaction - Volcom POS")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=md.`id_employee`
            WHERE md.report_mark_type=14 AND md.opt=1 "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                If data_send_to.Rows(i)("is_to").ToString = "1" Then
                    Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                    mail.To.Add(to_mail)
                Else
                    Dim to_mail_cc As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                    mail.CC.Add(to_mail_cc)
                End If
            Next

            Dim body_temp As String = ""

            mail.Subject = "" + design.ToUpper + " ORDER " + design_code + " - SO"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        End If
    End Sub
End Class
