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
            If opt = "1" Then
                Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Cancelled Transaction - Volcom POS")
                Dim mail As MailMessage = New MailMessage()
                mail.From = from_mail

                'Send to => design_code : email; design : contact person;
                Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name`, is_to
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

                Dim qtc As String = "SELECT p.pos_number AS `number`, DATE_FORMAT(p.pos_closed_date, '%d %M %Y %H:%i:%s') AS `cancel_date`, o.outlet_name AS `store`,
            e.employee_name AS `cashier_by`, es.employee_name AS `cancel_by`, p.note AS `reason`,
            i.item_code AS `barcode`, i.item_name AS `name`, s.size, CAST((pd.qty * pd.price) AS DECIMAL(15,0)) AS `amount`
            FROM tb_pos p 
            LEFT JOIN tb_pos_det pd ON pd.id_pos = p.id_pos
            LEFT JOIN tb_item i ON i.id_item = pd.id_item
            LEFT JOIN tb_size s ON s.id_size = i.id_size
            INNER JOIN tb_m_employee e ON e.id_employee = p.id_user_employee
            INNER JOIN tb_m_employee es ON es.id_employee = p.id_user_employee_cancel
            JOIN tb_opt o 
            WHERE p.id_pos=" + id_report + " "
                Dim dtc As DataTable = execute_query(qtc, -1, True, "", "", "", "")
                Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
            <tbody><tr>
              <td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
              <div align='center'>

              <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
               <tbody><tr>
                <td style='padding:0in 0in 0in 0in'></td>
               </tr>
               <tr>
                <td style='padding:0in 0in 0in 0in'>
                <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank' data-saferedirecturl='https://www.google.com/url?hl=en&amp;q=http://www.volcom.co.id/&amp;source=gmail&amp;ust=1480121870771000&amp;usg=AFQjCNEjXvEZWgDdR-Wlke7nn0fmc1ZUuA'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://ci3.googleusercontent.com/proxy/x-zXDZUS-2knkEkbTh3HzgyAAusw1Wz7dqV-lbnl39W_4F6T97fJ2_b9doP3nYi0B6KHstdb-tK8VAF_kOaLt2OH=s0-d-e1-ft#http://www.volcom.co.id/enews/img/volcom.jpg' alt='Volcom' class='CToWUd'></span></a><u></u><u></u></p>
                </td>
               </tr>
               <tr>
                <td style='padding:0in 0in 0in 0in'></td>
               </tr>
               <tr>
                <td style='padding:0in 0in 0in 0in'>
                <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                 <tbody><tr>
                  <td style='padding:0in 0in 0in 0in'>

                  </td>
                 </tr>
                </tbody></table>


                <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
                <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>CANCELLED TRANSACTION</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>



                 <tr>
                  <td colspan='3'>
                      <table width='100%' style='padding:5.0pt 5.0pt 0.0pt 14.0pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;' border='0'>
                        <tr>
                          <td width='20%'>Register No.</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("number").ToString + "</td>
                        </tr>

                        <tr>
                          <td width='20%'>Date & Time</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("cancel_date").ToString + "</td>
                        </tr>

                        <tr>
                          <td width='20%'>Store</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("store").ToString + "</td>
                        </tr>

                        <tr>
                          <td width='20%'>Cashier</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("cashier_by").ToString + "</td>
                        </tr>

                        <tr>
                          <td width='20%'>Cancelled by</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("cancel_by").ToString + "</td>
                        </tr>

                        <tr>
                          <td width='20%'>Reason</td>
                          <td width='2%'>:</td>
                          <td width='77%'>" + dtc.Rows(0)("reason").ToString + "</td>
                        </tr>
                     
                      </table>
                   </td>
                 </tr>         
         
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <span style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'><b>Detail Items</b></span>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>No</th>
                      <th>Barcode</th>
                      <th>Description</th>
                      <th>Size</th>
                      <th>Amount</th>
                    </tr> "

                Dim no As Integer = 0
                If dtc.Rows.Count > 0 And dtc.Rows(0)("barcode").ToString <> "" Then
                    For i As Integer = 0 To dtc.Rows.Count - 1
                        no += 1
                        body_temp += "<tr>
                        <td>" + no.ToString + "</td>
                        <td>" + dtc.Rows(i)("barcode").ToString + "</td>
                        <td>" + dtc.Rows(i)("name").ToString + "</td>
                        <td>" + dtc.Rows(i)("size").ToString + "</td>
                        <td>" + Decimal.Parse(dtc.Rows(i)("amount").ToString).ToString("N0") + "</td>
                    </tr>"
                    Next
                End If

                body_temp += "</table>
                  </td>

                 </tr>

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom POS</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


                <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                <div align='center'>
                

                <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody><tr>
                  <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                    <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
                  <p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
                  </td>
                 </tr>
                </tbody></table>
                </div>
                </td>
               </tr>
              </tbody></table>
              </div>
              </td>
             </tr>
            </tbody>
        </table> "

                mail.Subject = dtc.Rows(0)("number").ToString + " - CANCELLED TRANSACTION"
                mail.IsBodyHtml = True
                mail.Body = body_temp
                client.Send(mail)
            End If
        End If
    End Sub
End Class
