Imports System.Collections
Imports System.Net.Mail
Public Class QCM00003
    Const strModule As String = "SC"

    Public rs_QCM00003Hdr As DataSet
    Public rs_QCM00003Dtl As DataSet
    Public rs_QCM00003Dtl_2 As DataSet
    Public rs_email As DataSet
    Dim MailToAddress As String = "michaelchiu@ucp.com.hk"
    Private Sub QCM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Formstartup(Me.Name)

        FillCompCombo(gsUsrID, cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        txtResult.Text = ""
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Dim rs_Result As DataSet
        Dim rs_Right As DataSet

        Dim optStr As String
        Dim temp As String
        Dim t As String
        Dim r As String
        Dim action As String = ""

        gsCompany = Trim(cboCoCde.Text)
        Update_gs_Value(gsCompany)
        '------------------------------------------

        txtResult.Text = ""
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If optRel.Checked = True Then
            optStr = "Y"
        ElseIf optRel.Checked = False And optUnr.Checked = False Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Missing Release/Unrelease Action")
            Exit Sub
        Else
            optStr = "N"
        End If

        gspStr = "sp_select_QCM00003 '" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading QCM00003 sp_select_QCM00003 : " & rtnStr)
            Exit Sub
        End If

        Dim tbl_Result As DataTable = rs_Result.Tables("RESULT")
        If tbl_Result.Rows.Count > 0 Then

            'Check Rights
            gspStr = "sp_select_QCM00003 '" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "','Y','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading QCM00003 sp_select_QCM00003 : " & rtnStr)
                Exit Sub
            End If

            If rs.Tables(0).Rows.Count <> rs_Result.Tables(0).Rows.Count Then
                MsgBox("You do not have access right on all QC")
                Cursor = Cursors.Default
                Exit Sub
            End If




            Dim dr() As DataRow

            'Checking all QC have same Status
            If optStr = "Y" Then
                dr = rs_Result.Tables("RESULT").Select("qch_qcsts = 'OPE'")
                If dr.Length <> tbl_Result.Rows.Count Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("All QC No. to be released must be opened", MsgBoxStyle.Exclamation, "Warning")
                    Exit Sub
                End If
            Else
                dr = rs_Result.Tables("RESULT").Select("qch_qcsts = 'REL'")
                If dr.Length <> tbl_Result.Rows.Count Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("All QC No. to be unreleased must be released", MsgBoxStyle.Exclamation, "Warning")
                    Exit Sub
                End If
            End If

            'Checking Access Right






            gspStr = "sp_select_QCM00003Hdr '" & txtFromFactory.Text & "','" & txtToFactory.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_QCM00003Hdr, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_select_QCM0003Hdr:" & rtnStr)
                Exit Sub
            End If


            Dim emailFlag As Boolean = False

            'Release or Unrelease
            For i As Integer = 0 To tbl_Result.Rows.Count - 1

                gspStr = "sp_release_QCM00003 '" & tbl_Result.Rows(i).Item("qch_qcno") & "','" & _
                            optStr & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading  sp_release_QCM00003 : " & rtnStr)
                    Exit Sub
                End If

                Dim tmpstr As String
                tmpstr = If(optStr = "Y", "Release ", "Unrelease ")
                tmpstr = tmpstr & tbl_Result.Rows(i).Item("qch_qcno") & " Success! " & Environment.NewLine
                txtResult.Text = txtResult.Text & tmpstr









                If optStr = "Y" Then
                    action = "R"
                Else
                    action = "U"
                End If

                If action <> "" Then
                    If tbl_Result.Rows(i).Item("qch_inspweek") = GetCurrentWeek() And tbl_Result.Rows(i).Item("qch_inspyear") = Date.Today.Year Then
                        'MsgBox("QCR in current week is released. A remind email will be send")
                        AlertCurrentWeekRequestRelease(action, i)
                        emailFlag = True
                    Else
                        ' MsgBox("QCR not in current week is released")
                    End If
                End If


            Next

            If emailFlag Then
                'Dim MailToAddress As String = "henryli@ucp.com.hk;chrisleung@ucp.com.hk;marco@ucp.com.hk;michaelchiu@ucp.com.hk;terry.ng@ucpsz.com;ken.zhang@ucpsz.com"
                MsgBox("Send email to " & MailToAddress)
            End If


        Else
            MsgBox("No QC found")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.Default
        Exit Sub


        'gspStr = "sp_select_SCORDHDRR '" & gsCompany & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','" & optStr & "'"

        'rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    MsgBox("Error on loading SHR00002 #001 sp_select_SCORDHDRR : " & rtnStr)
        '    Exit Sub
        'End If

        'If rs_Result.Tables("RESULT").Rows.Count > 0 Then
        '    temp = ""
        '    For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
        '        temp = temp & rs_Result.Tables("RESULT").Rows(i)("soh_ordno") & " " & rs_Result.Tables("RESULT").Rows(i)("soh_ordsts") & Environment.NewLine
        '    Next
        '    txtResult.Text = temp
        '    temp = ""

        '    Me.Cursor = Windows.Forms.Cursors.Default
        '    If optStr = "Y" Then
        '        MsgBox("All SC No. to be released must be active", MsgBoxStyle.Exclamation, "Warning")
        '    Else
        '        MsgBox("All SC No. to be unreleased must be released", MsgBoxStyle.Exclamation, "Warning")
        '    End If
        '    Exit Sub
        'Else
        '    ' Added by Joe on 2010514
        '    gspStr = "sp_select_SYUSRRIGHT_Rel_Check '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & _
        '             txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "','" & strModule & "'"
        '    rtnLong = execute_SQLStatement(gspStr, rs_Right, rtnStr)
        '    If rtnLong <> RC_SUCCESS Then
        '        Me.Cursor = Windows.Forms.Cursors.Default
        '        MsgBox("Error on loading SHR00002 #002 sp_select_SYUSRRIGHT_Rel_Check : " & rtnStr)
        '        Exit Sub
        '    Else
        '        If Not rs_Right.Tables("RESULT").Rows.Count = 0 Then
        '            Me.Cursor = Windows.Forms.Cursors.Default
        '            MsgBox("All SC No. should have access rights", MsgBoxStyle.Exclamation, "Warning")
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If rs_Result.Tables("RESULT").Rows.Count > 0 Then
            'Check if all QC have the same status
            temp = ""
            For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
                temp = temp & rs_Result.Tables("RESULT").Rows(i)("qch_qcno") & " " & rs_Result.Tables("RESULT").Rows(i)("qch_qcsts") & Environment.NewLine
            Next
            txtResult.Text = temp
            temp = ""

            Me.Cursor = Windows.Forms.Cursors.Default
            If optStr = "Y" Then
                MsgBox("All QC No. to be released must be opened", MsgBoxStyle.Exclamation, "Warning")
            Else
                MsgBox("All QC No. to be unreleased must be released", MsgBoxStyle.Exclamation, "Warning")
            End If
            Exit Sub
        Else
            'Check Rights

            '   gspStr = "sp_select_SYUSRRIGHT_Rel_Check '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & _
            '       txtToFactory.Text & "','" & optStr & "','" & gsUsrID & "','" & strModule & "'"
            '   rtnLong = execute_SQLStatement(gspStr, rs_Right, rtnStr)
            '   If rtnLong <> RC_SUCCESS Then
            '       Me.Cursor = Windows.Forms.Cursors.Default
            '       MsgBox("Error on loading SHR00002 #002 sp_select_SYUSRRIGHT_Rel_Check : " & rtnStr)
            '       Exit Sub
            '   Else
            '       If Not rs_Right.Tables("RESULT").Rows.Count = 0 Then
            '           Me.Cursor = Windows.Forms.Cursors.Default
            '           MsgBox("All SC No. should have access rights", MsgBoxStyle.Exclamation, "Warning")
            '           Exit Sub
            '       End If
            '   End If
        End If






        'gspStr = "sp_select_SCM00002 '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & _
        '         "','" & optStr & "','" & gsUsrID & "'"

        't = "sp_select_SHR00002 '" & cboCoCde.Text & "','" & txtFromFactory.Text & "','" & txtToFactory.Text & "','0'"
        'r = ", PO is Generated "

        'If gspStr <> "" Then  '*** if there is something to do with s ...
        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '    If rtnLong <> RC_SUCCESS Then  '*** An error has occured
        '        Me.Cursor = Windows.Forms.Cursors.Default
        '        MsgBox("Error on loading SHR00002 #003 sp_select_SCM00002 : " & rtnStr)
        '        Exit Sub
        '    Else
        '        If rs.Tables.Count > 0 Then
        '            If rs.Tables("RESULT").Rows.Count > 0 Then
        '                Me.Cursor = Windows.Forms.Cursors.Default
        '                MsgBox("Operation Fail - " & rs.Tables("RESULT").Rows(0)(0), MsgBoxStyle.Information, "Information")
        '                Exit Sub
        '            End If
        '        End If
        '        If t <> "" Then  '*** if there is something to do with s ...
        '            gspStr = t
        '            rs_Result = Nothing
        '            rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        '            If rtnLong <> RC_SUCCESS Then
        '                Me.Cursor = Windows.Forms.Cursors.Default
        '                MsgBox("Error on loading SHR00002 #004 sp_select_SHR00002 : " & rtnStr)
        '                Exit Sub
        '            End If

        '            For i As Integer = 0 To rs_Result.Tables("RESULT").Rows.Count - 1
        '                temp = temp & _
        '                       "Pri Cust: " & rs_Result.Tables("RESULT").Rows(i)(0).ToString.PadRight(6) & _
        '                       "Sec Cust: " & rs_Result.Tables("RESULT").Rows(i)(1).ToString.PadRight(6) & _
        '                       "SC No.: " & rs_Result.Tables("RESULT").Rows(i)(2).ToString.PadRight(14) & _
        '                       "PO No.: " & rs_Result.Tables("RESULT").Rows(i)(3).ToString.PadRight(14) & _
        '                       "CV: " & rs_Result.Tables("RESULT").Rows(i)(4).ToString.PadRight(10) & _
        '                       "PV: " & rs_Result.Tables("RESULT").Rows(i)(5).ToString & _
        '                       Environment.NewLine
        '            Next
        '        End If
        '        txtResult.Text = temp
        '        Me.Cursor = Windows.Forms.Cursors.Default
        '        MsgBox("Operation Successful " & r)
        '    End If
        'End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtFromFactory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFromFactory.TextChanged
        txtToFactory.Text = txtFromFactory.Text
    End Sub

    Private Sub AlertCurrentWeekRequestRelease(ByVal action As String, ByVal index As Integer)
        Dim emailHost As String = "192.168.1.235"
        Dim MailMsg As String = ""
        Dim MailFrAddress As String = "erpalert@ucp.com.hk"
        ' Dim MailToAddress As String = "henryli@ucp.com.hk;chrisleung@ucp.com.hk;marco@ucp.com.hk;michaelchiu@ucp.com.hk;terry.ng@ucpsz.com;ken.zhang@ucpsz.com"
        MailToAddress = "michaelchiu@ucp.com.hk"
        Dim toAddressList
        Dim mail As New MailMessage()
        Dim SmtpServer As New SmtpClient()
        'MsgBox("Send email to " & MailToAddress)
        Dim mailBody As String = ""
        '  Dim tmpItem As String = ""
        Try

            gspStr = "sp_select_SYEMLALT '" & "QC" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_email, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading QCM00003 sp_select_EMLALTMAP : " & rtnStr)
                Exit Sub
            End If


            MailToAddress = rs_email.Tables("RESULT").Rows(0).Item("sea_email")
            toAddressList = MailToAddress.Split(";")

            mail.From = New MailAddress("erpalert@ucp.com.hk")
            For toIndex As Integer = 0 To toAddressList.Length - 1
                If toAddressList(toIndex) <> "" Then
                    mail.To.Add(toAddressList(toIndex))
                End If
            Next
            mail.Subject = ""
            mailBody = ""
            If action = "R" Then
                gspStr = "sp_select_QCM00002Dtl '" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_QCM00003Dtl, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading sp_select_QCM00002Dtl:" & rtnStr)
                    Exit Sub
                End If

                gspStr = "sp_select_QCM00002Dtl_2 '" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_QCM00003Dtl_2, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading sp_select_QCM00002Dtl_2:" & rtnStr)
                    Exit Sub
                End If


                mail.Subject = "User " & gsUsrID & " has just released a QC request " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & " in " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_venno") & _
                  "-" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("vbi_vensna") & _
                  " for " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_prmcus") & "-" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("cbi_cussna") & _
                  " with " & rs_QCM00003Dtl_2.Tables("RESULT").Rows.Count & " item(s) " & _
                  " on week " & GetCurrentWeek()

                mailBody = "The released QC request is " & rs_QCM00003Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & vbCrLf


                mailBody = mailBody & "The released QC request contains following PR#:" & vbCrLf

                For i As Integer = 0 To rs_QCM00003Dtl.Tables("RESULT").Rows.Count - 1
                    ' If tmpItem <> rs_QCM00003Dtl.Tables("RESULT").Rows(i).Item("qcd_purord") Then
                    mailBody = mailBody & rs_QCM00003Dtl.Tables("RESULT").Rows(i).Item("qcd_purord") & vbCrLf
                    'tmpItem = rs_QCM00003Dtl.Tables("RESULT").Rows(i).Item("qcd_purord")
                    ' End If
                Next

                mailBody = mailBody & "The released QC request contains following Item#:" & vbCrLf

                'tmpItem = ""
                For i As Integer = 0 To rs_QCM00003Dtl_2.Tables("RESULT").Rows.Count - 1
                    ' If tmpItem <> rs_QCM00003Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno") Then
                    mailBody = mailBody & rs_QCM00003Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno") & vbCrLf
                    ' tmpItem = rs_QCM00003Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno")
                    'End If
                Next



                mail.Body = mailBody




            ElseIf action = "U" Then
                mail.Subject = "User " & gsUsrID & " has just unreleased a QC request " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & " in " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_venno") & _
                  "-" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("vbi_vensna") & _
                  " for " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_prmcus") & "-" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("cbi_cussna") & _
                  " with " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("res_itmcount") & " item(s) " & _
                  " on week " & GetCurrentWeek()
                mail.Body = "The unreleased QC request is " & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & _
                    ". The QC request's status changed from Released to Unreleased."
            End If

            SmtpServer.Port = 25
            SmtpServer.Credentials = New System.Net.NetworkCredential("192.168.1.235", "basic")
            SmtpServer.Host = emailHost

            SmtpServer.Send(mail)


        Catch ex As Exception
            MessageBox.Show("The QC Request is saved but Mail cannot be send. Please contart the QC with other method. The reason fail to send is :\n------------" & ex.ToString)
        End Try
        'MessageBox.Show("mail Send")

        ''

        If action = "R" Then
            gspStr = "sp_update_QCREQACT '" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & "','" & _
               rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_verno") & "'" & _
                ",'R'" & _
                ",'" & gsUsrID & "'" & _
                 ",'E'"

        ElseIf action = "U" Then
            gspStr = "sp_update_QCREQACT '" & rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_qcno") & "','" & _
               rs_QCM00003Hdr.Tables("RESULT").Rows(index).Item("qch_verno") & "'" & _
                ",'U'" & _
                ",'" & gsUsrID & "'" & _
                 ",'E'"
        End If

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_update_QCREQACT:" & rtnStr)
            Exit Sub
        End If
    End Sub
End Class