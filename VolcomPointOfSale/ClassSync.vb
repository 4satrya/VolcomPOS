﻿Imports MySql.Data.MySqlClient

Public Class ClassSync
    Dim curr_time As String = getTimeDBServer()
    Dim last_upd As String = ""
    Public sync_list As New List(Of String)
    Dim host_main As String = ""
    Dim username_main As String = ""
    Dim pass_main As String = ""
    Dim db_main As String = ""
    Dim host_sync_main As String = ""
    Dim username_sync_main As String = ""
    Dim pass_sync_main As String = ""
    Dim db_sync_main As String = ""
    Public splash As String = "-1"
    Dim is_reset_config As String = "-1"
    Dim dtl As DataTable
    Dim id_comp_sup_normal As String = "-1"
    Dim id_comp_sup_sale As String = "-1"
    Public show_log As Boolean = False
    Dim id_outlet_current As String = ""

    Public Sub New(ByVal id_sync_data As String)
        show_log = False
        Dim query As String = "SELECT * FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'koneksi office
        host_main = data.Rows(0)("host_main").ToString
        username_main = data.Rows(0)("username_main").ToString
        pass_main = data.Rows(0)("pass_main").ToString
        db_main = data.Rows(0)("db_main").ToString

        'koneksi local
        host_sync_main = data.Rows(0)("host_sync_main").ToString
        username_sync_main = data.Rows(0)("username_sync_main").ToString
        pass_sync_main = data.Rows(0)("pass_sync_main").ToString
        db_sync_main = data.Rows(0)("db_sync_main").ToString

        'other
        is_reset_config = data.Rows(0)("is_reset_config").ToString
        id_comp_sup_normal = data.Rows(0)("acc_normal_origin").ToString
        id_comp_sup_sale = data.Rows(0)("acc_sale_origin").ToString
        id_outlet_current = data.Rows(0)("id_outlet").ToString

        'get sync list
        Dim cond As String = ""
        If id_sync_data <> "0" Then
            cond = "AND d.id_sync_data='" + id_sync_data + "' "
        End If
        Dim qs As String = "SELECT * FROM tb_sync_data d WHERE d.id_sync_data>0 " + cond + " ORDER BY d.`index` ASC "
        dtl = execute_query(qs, -1, True, "", "", "", "")
    End Sub

    Public Sub syncCodeDet()
        Dim err As String = ""

        '-----CLASS
        Try
            'update
            Dim qupd_cls As String = "UPDATE tb_class cls 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
            ) src ON src.id_code_detail = cls.id_code_detail 
            SET cls.class = src.code_detail_name, 
            cls.class_display = src.display_name "
            execute_non_query(qupd_cls, True, "", "", "", "")
        Catch ex As Exception
            err = ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_cls As String = "INSERT INTO tb_class(class, class_display, id_code_detail)
            SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
            FROM tb_class cls
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=30
            ) cd ON cd.id_code_detail = cls.id_code_detail
            WHERE ISNULL(cls.id_class) "
            execute_non_query(qins_cls, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        '-----SIZE
        Try
            'update
            Dim qupd_sz As String = "UPDATE tb_size sz 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
            ) src ON src.id_code_detail = sz.id_code_detail 
            SET sz.size = src.code_detail_name "
            execute_non_query(qupd_sz, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_sz As String = "INSERT INTO tb_size(size, id_code_detail)
            SELECT cd.code_detail_name, cd.id_code_detail
            FROM tb_size sz
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=33
            ) cd ON cd.id_code_detail = sz.id_code_detail
            WHERE ISNULL(sz.id_size) "
            execute_non_query(qins_sz, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        '--COLOR
        Try
            'update
            Dim qupd_col As String = "UPDATE tb_color col 
            INNER JOIN(
                SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
            ) src ON src.id_code_detail = col.id_code_detail 
            SET col.color = src.code_detail_name,
            col.color_display = src.display_name "
            execute_non_query(qupd_col, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_col As String = "INSERT INTO tb_color(color, color_display, id_code_detail)
            SELECT cd.code_detail_name, cd.display_name, cd.id_code_detail
            FROM tb_color col
            RIGHT JOIN (
	            SELECT a.id_code_detail, a.code_detail_name, a.display_name FROM db_sync.tb_m_code_detail a WHERE a.id_code=14
            ) cd ON cd.id_code_detail = col.id_code_detail
            WHERE ISNULL(col.id_color) "
            execute_non_query(qins_col, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '1', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Public Sub syncComp()
        Dim err As String = ""
        Try
            'update
            Dim qupd_cls As String = "UPDATE tb_m_comp comp 
            INNER JOIN(
                SELECT * FROM db_sync.tb_m_comp a
            ) src ON src.id_comp = comp.id_comp 
            SET comp.id_comp_cat = src.id_comp_cat, 
            comp.comp_number = src.comp_number,
            comp.id_city =src.id_city,
            comp.comp_name =src.comp_name,
            comp.comp_display_name =src.comp_display_name,
            comp.address_primary =src.address_primary,
            comp.address_other =src.address_other,
            comp.fax =src.fax,
            comp.postal_code =src.postal_code,
            comp.email =src.email,
            comp.website =src.website,
            comp.id_tax =src.id_tax,
            comp.npwp =src.npwp,
            comp.is_active =src.is_active,
            comp.id_departement =src.id_departement,
            comp.comp_commission =src.comp_commission,
            comp.id_store_type =src.id_store_type,
            comp.id_area =src.id_area,
            comp.id_employee_rep =src.id_employee_rep,
            comp.id_comp_group =src.id_comp_group,
            comp.id_pd_alloc =src.id_pd_alloc,
            comp.id_wh_type =src.id_wh_type,
            comp.id_wh =src.id_wh,
            comp.id_so_type =src.id_so_type,
            comp.is_own_store =src.is_own_store "
            execute_non_query(qupd_cls, True, "", "", "", "")
        Catch ex As Exception
            err = ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '4', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Public Sub syncItem()
        Dim err As String = ""
        Try
            'update
            Dim qupd_cls As String = "UPDATE tb_item i 
            INNER JOIN(
                SELECT syn.id_product, syn.code, syn.name, syn.id_design_cat, syn.price, syn.price_date,
                cls.id_class, col.id_color, sz.id_size, IF(syn.id_design_cat=1,o.acc_normal, o.acc_sale) AS `id_comp_sup`,
                IF(syn.id_design_cat=1,nml.comp_commission, sale.comp_commission) AS `comm`
                FROM db_sync.tb_product_sync syn
                INNER JOIN tb_class cls ON cls.id_code_detail =  syn.id_class_det
                INNER JOIN tb_color col ON col.id_code_detail = syn.id_color_det
                INNER JOIN tb_size sz ON sz.id_code_detail = syn.id_size_det
                JOIN tb_opt o
                INNER JOIN tb_m_comp nml ON nml.id_comp = o.acc_normal
                INNER JOIN tb_m_comp sale ON sale.id_comp = o.acc_sale
            ) src ON src.id_product = i.id_product AND src.id_design_cat = i.id_design_cat
            SET i.id_size = src.id_size, 
            i.id_class = src.id_class, 
            i.id_color = src.id_color, 
            i.id_comp_sup = src.id_comp_sup, 
            i.id_so_type = 1,
            i.id_design_cat = src.id_design_cat,
            i.item_code = src.code,
            i.item_name = src.name,
            i.price = src.price,
            i.price_date = src.price_date,
            i.comm = src.comm "
            execute_non_query(qupd_cls, True, "", "", "", "")
        Catch ex As Exception
            err = ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_col As String = "INSERT INTO tb_item(id_size, id_class, id_color, id_comp_sup, id_so_type, id_design_cat, item_code, item_name, price, price_date, comm, id_product)
            SELECT ix.id_size, ix.id_class, ix.id_color, ix.id_comp_sup, 1, ix.id_design_cat, ix.code, ix.name, ix.price, ix.price_date, ix.comm, ix.id_product 
            FROM tb_item i
            RIGHT JOIN(
	            SELECT syn.id_product, syn.code, syn.name, syn.id_design_cat, syn.price, syn.price_date,
	            cls.id_class, col.id_color, sz.id_size, IF(syn.id_design_cat=1,o.acc_normal, o.acc_sale) AS `id_comp_sup`,
	            IF(syn.id_design_cat=1,nml.comp_commission, sale.comp_commission) AS `comm`
	            FROM db_sync.tb_product_sync syn
	            INNER JOIN tb_class cls ON cls.id_code_detail =  syn.id_class_det
	            INNER JOIN tb_color col ON col.id_code_detail = syn.id_color_det
	            INNER JOIN tb_size sz ON sz.id_code_detail = syn.id_size_det
	            JOIN tb_opt o
	            INNER JOIN tb_m_comp nml ON nml.id_comp = o.acc_normal
	            INNER JOIN tb_m_comp sale ON sale.id_comp = o.acc_sale
            ) ix ON ix.id_product = i.id_product AND ix.id_design_cat = i.id_design_cat
            WHERE ISNULL(i.id_item)  "
            execute_non_query(qins_col, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '3', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Public Sub syncEmp()
        Dim err As String = ""

        '-----CLASS
        Try
            'update
            Dim qupd_cls As String = "UPDATE tb_m_employee emp 
            INNER JOIN(
               SELECT * FROM db_sync.tb_m_employee a
            ) src ON src.id_employee = emp.id_employee 
            SET 
            emp.id_sex = src.id_sex,
            emp.id_departement = src.id_departement,
            emp.id_blood_type = src.id_blood_type,
            emp.id_religion =src.id_religion,
            emp.id_country =src.id_country,
            emp.id_education= src.id_education,
            emp.id_employee_status=src.id_employee_status,
            emp.start_period =src.start_period,
            emp.end_period =src.end_period,
            emp.id_employee_active=src.id_employee_active,
            emp.employee_code =src.employee_code,
            emp.employee_name =src.employee_name,
            emp.employee_nick_name=src.employee_nick_name,
            emp.employee_initial_name= src.employee_initial_name,
            emp.employee_pob =src.employee_pob,
            emp.employee_dob =src.employee_dob,
            emp.employee_ethnic= src.employee_ethnic,
            emp.employee_join_date= src.employee_join_date,
            emp.employee_last_date =src.employee_last_date,
            emp.employee_position =src.employee_position,
            emp.id_employee_level =src.id_employee_level,
            emp.email_lokal =src.email_lokal,
            emp.email_lokal_pass =src.email_lokal_pass,
            emp.email_external =src.email_external,
            emp.email_external_pass =src.email_external_pass,
            emp.email_other =src.email_other,
            emp.email_other_pass=src.email_other_pass,
            emp.phone =src.phone,
            emp.phone_mobile=src.phone_mobile,
            emp.phone_ext =src.phone_ext,
            emp.employee_ktp= src.employee_ktp,
            emp.employee_ktp_period=src.employee_ktp_period,
            emp.employee_passport =src.employee_passport,
            emp.employee_passport_period=src.employee_passport_period, 
            emp.employee_bpjs_tk =src.employee_bpjs_tk,
            emp.employee_bpjs_tk_date=src.employee_bpjs_tk_date, 
            emp.employee_bpjs_kesehatan= src.employee_bpjs_kesehatan,
            emp.employee_bpjs_kesehatan_date=src.employee_bpjs_kesehatan_date, 
            emp.employee_npwp =src.employee_npwp,
            emp.address_primary= src.address_primary,
            emp.address_additional= src.address_additional,
            emp.id_marriage_status =src.id_marriage_status,
            emp.husband =src.husband,
            emp.wife =src.wife,
            emp.child1 =src.child1,
            emp.child2 =src.child2,
            emp.child3 =src.child3,
            emp.basic_salary=src.basic_salary, 
            emp.allow_job =src.allow_job,
            emp.allow_meal =src.allow_meal,
            emp.allow_trans =src.allow_trans,
            emp.allow_house =src.allow_house,
            emp.allow_car =src.allow_car "
            execute_non_query(qupd_cls, True, "", "", "", "")
        Catch ex As Exception
            err = ex.ToString + "; "
        End Try

        Try
            'insert
            Dim qins_cls As String = "INSERT INTO tb_m_employee(
            id_employee,
            id_sex,
            id_departement, 
            id_blood_type ,
            id_religion ,
            id_country ,
            id_education,
            id_employee_status,
            start_period ,
            end_period ,
            id_employee_active,
            employee_code,
            employee_name ,
            employee_nick_name,
            employee_initial_name,
            employee_pob,
            employee_dob ,
            employee_ethnic,
            employee_join_date,
            employee_last_date,
            employee_position,
            id_employee_level,
            email_lokal ,
            email_lokal_pass, 
            email_external ,
            email_external_pass,
            email_other,
            email_other_pass,
            phone,
            phone_mobile,
            phone_ext ,
            employee_ktp,
            employee_ktp_period,
            employee_passport ,
            employee_passport_period,
            employee_bpjs_tk ,
            employee_bpjs_tk_date,
            employee_bpjs_kesehatan,
            employee_bpjs_kesehatan_date,
            employee_npwp ,
            address_primary,
            address_additional,
            id_marriage_status ,
            husband ,
            wife ,
            child1, 
            child2 ,
            child3 ,
            basic_salary, 
            allow_job ,
            allow_meal ,
            allow_trans,
            allow_house,
            allow_car )
            SELECT
            ad.id_employee,
            ad.id_sex,
            ad.id_departement, 
            ad.id_blood_type ,
            ad.id_religion ,
            ad.id_country ,
            ad.id_education,
            ad.id_employee_status,
            ad.start_period ,
            ad.end_period ,
            ad.id_employee_active,
            ad.employee_code,
            ad.employee_name ,
            ad.employee_nick_name,
            ad.employee_initial_name,
            ad.employee_pob,
            ad.employee_dob ,
            ad.employee_ethnic,
            ad.employee_join_date,
            ad.employee_last_date,
            ad.employee_position,
            ad.id_employee_level,
            ad.email_lokal ,
            ad.email_lokal_pass, 
            ad.email_external ,
            ad.email_external_pass,
            ad.email_other,
            ad.email_other_pass,
            ad.phone,
            ad.phone_mobile,
            ad.phone_ext ,
            ad.employee_ktp,
            ad.employee_ktp_period,
            ad.employee_passport ,
            ad.employee_passport_period,
            ad.employee_bpjs_tk ,
            ad.employee_bpjs_tk_date,
            ad.employee_bpjs_kesehatan,
            ad.employee_bpjs_kesehatan_date,
            ad.employee_npwp ,
            ad.address_primary,
            ad.address_additional,
            ad.id_marriage_status ,
            ad.husband ,
            ad.wife ,
            ad.child1, 
            ad.child2 ,
            ad.child3 ,
            ad.basic_salary, 
            ad.allow_job ,
            ad.allow_meal ,
            ad.allow_trans,
            ad.allow_house,
            ad.allow_car
            FROM tb_m_employee emp
            RIGHT JOIN (
	            SELECT a.* FROM db_sync.tb_m_employee a
            ) ad ON ad.id_employee = emp.id_employee
            WHERE ISNULL(emp.id_employee) "
            execute_non_query(qins_cls, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try


        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '4', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Sub syncDS()
        Dim err As String = ""
        Try
            Dim query As String = "INSERT INTO tb_delivery_slip (
	            `id_pl_sales_order_del`,
	            `number`,
	            `id_wh`,
	            `id_store`,
	            `created_date`,
	            `approved_date`,
	            `id_product`,
	            `id_design`,
	            `id_pl_prod_order_rec_det_unique`,
	            `id_class`,
	            `id_color`,
	            `id_size`,
	            `item_code`,
                `item_code_group`,
	            `item_name`,
	            `qty`,
	            `id_design_cat`,
                `id_design_price`,
	            `price`,
	            `is_combine`,
                `is_unique_code`
            ) 
            SELECT 
            src.`id_pl_sales_order_del`,
            `number`,
            `id_wh`,
            `id_store`,
            `created_date`,
            `approved_date`,
            `id_product`,
            `id_design`,
            `id_pl_prod_order_rec_det_unique`,
            `id_class`,
            `id_color`,
            `id_size`,
            `item_code`,
            `item_code_group`,
            `item_name`,
            `qty`,
            `id_design_cat`,
            `id_design_price`,
            `price`,
            `is_combine`,
            `is_unique_code`
            FROM db_sync.tb_sync_delivery src
            LEFT JOIN (
                SELECT ds.id_pl_sales_order_del FROM tb_delivery_slip ds GROUP BY ds.id_pl_sales_order_del
            ) main ON main.id_pl_sales_order_del = src.id_pl_sales_order_del 
            WHERE ISNULL(main.id_pl_sales_order_del) "
            execute_non_query(query, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try

        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '2', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Sub syncItemPrice()
        Dim err As String = ""
        Try
            Dim qry As String = "UPDATE tb_item main 
            INNER JOIN(
                SELECT a.id_design, a.id_design_cat, a.id_design_price, a.price, a.price_date  
                FROM db_sync.tb_sync_design_price a
            ) src ON src.id_design = main.id_design
            SET main.id_design_cat = src.id_design_cat,
            main.id_design_price = src.id_design_price,
            main.price = src.price,
            main.price_date = src.price_date,
            main.id_comp_sup = IF(src.id_design_cat=1," + id_comp_sup_normal + "," + id_comp_sup_sale + "); "
            execute_non_query(qry, True, "", "", "", "")
        Catch ex As Exception
            err += ex.ToString + "; "
        End Try


        Dim is_success = ""
        If err = "" Then
            is_success = "1"
        Else
            is_success = "2"
            show_log = True
        End If
        Dim qlast As String = "INSERT INTO tb_sync_log(sync_time, id_sync_data, is_success, remark) VALUES('" + curr_time + "', '3', '" + is_success + "','" + addSlashes(err) + "') "
        execute_non_query(qlast, True, "", "", "", "")
    End Sub

    Public Sub startofSync()
        For i As Integer = 0 To dtl.Rows.Count - 1
            Dim ix As String = dtl.Rows(i)("id_sync_data").ToString
            If ix = "1" Then 'code det
                If splash = "-1" Then
                    FormFront.SplashScreenManager1.SetWaitFormDescription("Sync master data")
                ElseIf splash = "1" Then
                    FormUser.SplashScreenManager1.SetWaitFormDescription("Sync master data")
                End If
                syncCodeDet()
            ElseIf ix = "2" Then 'delivery slip
                If splash = "-1" Then
                    FormFront.SplashScreenManager1.SetWaitFormDescription("Sync delivery slip")
                ElseIf splash = "1" Then
                    FormUser.SplashScreenManager1.SetWaitFormDescription("Sync delivery slip")
                End If
                syncDS()
            ElseIf ix = "3" Then 'item price
                If splash = "-1" Then
                    FormFront.SplashScreenManager1.SetWaitFormDescription("Sync product price")
                ElseIf splash = "1" Then
                    FormUser.SplashScreenManager1.SetWaitFormDescription("Sync product price")
                End If
                syncItemPrice()
            ElseIf ix = "4" Then 'company
                If splash = "-1" Then
                    FormFront.SplashScreenManager1.SetWaitFormDescription("Sync company")
                ElseIf splash = "1" Then
                    FormUser.SplashScreenManager1.SetWaitFormDescription("Sync company")
                End If
                syncComp()
            ElseIf ix = "5" Then 'employee
                'If splash = "-1" Then
                '    FormFront.SplashScreenManager1.SetWaitFormDescription("Sync employee")
                'ElseIf splash = "1" Then
                '    FormUser.SplashScreenManager1.SetWaitFormDescription("Sync employee")
                'End If
                'syncEmp()
            End If
        Next
    End Sub


    Public Sub synchronize()
        If is_reset_config = "2" Then
            BackupCustomTable()
            RestoreCustomTable()
            startofSync()
            If show_log Then
                stopCustom("There are some synchronization processes that failed.")
                FormLogSync.ShowDialog()
            End If
        End If
    End Sub

    Public Sub BackupCustomTable()
        last_upd = ""
        Dim constring As String = "server=" + host_main + ";user=" + username_main + ";pwd=" + pass_main + ";database=" + db_main + ";"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)

        'dictionary
        Dim dic As New Dictionary(Of String, String)()
        For i As Integer = 0 To dtl.Rows.Count - 1
            Dim ix As String = dtl.Rows(i)("id_sync_data").ToString

            If ix = "1" Then 'code det
                Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=1 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                If dql.Rows.Count > 0 Then
                    last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Else
                    last_upd = "1945-08-17 00:00:10"
                End If
                dic.Add("tb_m_code_detail", "SELECT cd.* FROM tb_m_code_detail cd JOIN tb_opt o WHERE (cd.id_code= 14 OR cd.id_code=30 OR id_code=33) AND cd.last_updated>'" + last_upd + "';")
            ElseIf ix = "2" Then 'delivery slip
                Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=2 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                If dql.Rows.Count > 0 Then
                    last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Else
                    last_upd = "1945-08-17 00:00:10"
                End If

                'get account origin normal & sale
                Dim qa As String = "SELECT o.acc_normal_origin, o.acc_sale_origin FROM tb_opt o "
                Dim da As DataTable = execute_query(qa, -1, True, "", "", "", "")
                Dim acc_normal As String = da.Rows(0)("acc_normal_origin").ToString
                Dim acc_sale As String = da.Rows(0)("acc_sale_origin").ToString

                execute_non_query("CALL generate_delivery_slip(" + acc_normal + ", " + acc_sale + ", '" + last_upd + "')", False, host_main, username_main, pass_main, db_main)
                dic.Add("tb_sync_delivery", "SELECT * FROM tb_sync_delivery;")
            ElseIf ix = "3" Then 'item price    
                'old method
                'Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=3 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                'Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                'If dql.Rows.Count > 0 Then
                'last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                'Else
                'last_upd = "1945-08-17 00:00:10"
                'End If

                'cari item active
                Dim qa As String = "SELECT 
                GROUP_CONCAT(DISTINCT i.id_design ORDER BY i.id_design ASC SEPARATOR ',') AS `id_design`
                FROM tb_item i
                WHERE i.is_active=1 "
                Dim id_dsg_par As String = execute_query(qa, 0, True, "", "", "", "")

                execute_non_query("CALL generate_design_price_active(" + id_outlet_current + ", '" + id_dsg_par + "')", False, host_main, username_main, pass_main, db_main)
                dic.Add("tb_sync_design_price", "SELECT * FROM tb_sync_design_price WHERE id_outlet='" + id_outlet_current + "';")
            ElseIf ix = "4" Then 'comp
                Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=4 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                If dql.Rows.Count > 0 Then
                    last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Else
                    last_upd = "1945-08-17 00:00:10"
                End If
                dic.Add("tb_m_comp", "SELECT * FROM tb_m_comp c WHERE c.last_updated>'" + last_upd + "';")
            ElseIf ix = "5" Then 'employee
                'Dim ql As String = "SELECT a.sync_time FROM tb_sync_log a WHERE a.id_sync_data=4 AND a.is_success=1 ORDER BY a.sync_time DESC LIMIT 1"
                'Dim dql As DataTable = execute_query(ql, -1, True, "", "", "", "")
                'If dql.Rows.Count > 0 Then
                '    last_upd = DateTime.Parse(dql.Rows(0)("sync_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                'Else
                '    last_upd = "1945-08-17 00:00:10"
                'End If
                'Dim id_outlet As String = execute_query("SELECT id_outlet FROM tb_opt", 0, True, "", "", "", "")
                'dic.Add("tb_m_employee", "SELECT * FROM tb_m_employee emp WHERE id_departement=" + id_outlet + " AND emp.last_updated>'" + last_upd + "';")
            End If
        Next

        Using conn As New MySqlConnection(constring)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ExportInfo.AddCreateDatabase = False
                    mb.ExportInfo.ExportTableStructure = True
                    mb.ExportInfo.ExportRows = True
                    mb.ExportInfo.TablesToBeExportedDic = dic
                    mb.ExportInfo.ExportProcedures = False
                    mb.ExportInfo.ExportFunctions = False
                    mb.ExportInfo.ExportTriggers = False
                    mb.ExportInfo.ExportEvents = False
                    mb.ExportInfo.ExportViews = False
                    mb.ExportInfo.EnableEncryption = True
                    mb.ExportInfo.EncryptionPassword = "csmtafc"
                    mb.ExportToFile(file)
                End Using
            End Using
        End Using
    End Sub


    Public Sub RestoreCustomTable()
        Dim constring As String = "server=" + host_sync_main + ";user=" + username_sync_main + ";pwd=" + pass_sync_main + ";database=" + db_sync_main + ";"
        Dim path_root As String = Application.StartupPath
        Dim fileName As String = "bup" + ".sql"
        Dim file As String = IO.Path.Combine(path_root, fileName)
        Using conn As New MySqlConnection(constring)
            Using cmd As New MySqlCommand()
                Using mb As New MySqlBackup(cmd)
                    cmd.Connection = conn
                    conn.Open()
                    mb.ImportInfo.TargetDatabase = "db_sync"
                    mb.ImportInfo.EnableEncryption = True
                    mb.ImportInfo.EncryptionPassword = "csmtafc"
                    mb.ImportFromFile(file)
                    conn.Close()
                End Using
            End Using
        End Using
    End Sub

End Class