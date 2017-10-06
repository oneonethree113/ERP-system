Imports CrystalDecisions.Shared
Public Class CLR00001

    Inherits System.Windows.Forms.Form
    Public rs_CLR00001 As New DataSet
    Public rs_CAORDDTL As New DataSet
    Public rs_CUBASINF_P As New DataSet
    Public rs_CUBASINF_S As New DataSet
    Public rs_VNBASINF As New DataSet
    Public rs_SYCLMTYP As New DataSet
    Public rs_CAORDHDR_ClaimNo As New DataSet
    Public rs_SYUSRRIGHT_Check As New DataSet



    Private Sub CLR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call txtdocno_MouseClick()
        Call Formstartup(Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Me.Cursor = Cursors.WaitCursor

        If txtdocno.Text <> "" Then
            gspStr = "sp_select_CLR00001 '','" & Me.txtdocno.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CLR00001, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLR00001 #001 sp_select_CLR00001 : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_CAORDDTL'" & gsCompany & "','" & txtdocno.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLR00001 sp_select_CAORDDTL : " & rtnStr)

                Exit Sub
            End If


            gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & txtdocno.Text.Trim & "','" & "CL" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtQutNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
                Exit Sub
            End If
            If Not rs_SYUSRRIGHT_Check.Tables("RESULT") Is Nothing Then
                If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document Or Document not found!")
                    Me.Cursor = Windows.Forms.Cursors.Default


                    Exit Sub
                Else
                End If
            Else
                MsgBox("Rights access error.")
                Me.Cursor = Windows.Forms.Cursors.Default

                Exit Sub
            End If





            If rs_CLR00001.Tables("RESULT").Rows.Count > 0 Then
                Dim objRpt As New CLR00001Rptb
                objRpt.SetDataSource(rs_CLR00001.Tables("RESULT"))

                Dim frm As New frmReport
                frm.CrystalReportViewer.ReportSource = objRpt
                frm.Show()
            Else
                MsgBox("There is no Claim No that you type")
                Me.txtdocno.Focus()
                Exit Sub
            End If

        End If
        If txtdocno.Text = "" Then
            MsgBox("Please enter Claim Order No.")
            Call CLR00001_Load(Nothing, Nothing)
            Me.txtdocno.Focus()

        End If


        Me.Cursor = Cursors.Default
    End Sub



    Private Sub txtdocno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocno.KeyPress

        If e.KeyChar.Equals(Chr(13)) Then

            Call Me.cmdShow_Click(sender, e)
        End If
    End Sub





    'Private Sub format_gbClaimBy_Add(ByVal opt As String)
    '    If opt = "C" Then
    '        Me.cboPriCust.Enabled = True
    '        Me.cboSecCust.Enabled = True
    '        Me.cboVendor.Enabled = False
    '    ElseIf opt = "V" Then
    '        Me.cboPriCust.Enabled = False
    '        Me.cboSecCust.Enabled = False
    '        Me.cboVendor.Enabled = True
    '    Else
    '        Me.cboPriCust.Enabled = True
    '        Me.cboSecCust.Enabled = True
    '        Me.cboVendor.Enabled = True
    '    End If
    'End Sub

    'Private Sub rbClaimBy_C_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClaimBy_C.CheckedChanged
    '    If rbClaimBy_C.Checked = True Then
    '        format_gbClaimBy_Add("C")
    '        txtdocno.Text = ""
    '        cmdShow.Enabled = False
    '        cmdShow2.Enabled = True
    '        cboClaimNo.Text = ""
    '        cboPriCust.Text = ""
    '        cboSecCust.Text = ""
    '        cboVendor.Text = ""
    '        Call format_cboPriCust()

    '        Call format_cboSecCust2()


    '    End If
    'End Sub


    'Private Sub rbClaimBy_V_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClaimBy_V.CheckedChanged
    '    If rbClaimBy_V.Checked = True Then
    '        Call format_gbClaimBy_Add("V")
    '        txtdocno.Text = ""
    '        cmdShow.Enabled = False
    '        cmdShow2.Enabled = True
    '        cboClaimNo.Text = ""
    '        cboPriCust.Text = ""
    '        cboSecCust.Text = ""
    '        cboVendor.Text = ""
    '        Call format_cboVenno()

    '    End If
    'End Sub

    'Private Sub rbClaimBy_U_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbClaimBy_U.CheckedChanged
    '    If rbClaimBy_U.Checked = True Then
    '        format_gbClaimBy_Add("U")
    '        txtdocno.Text = ""
    '        cmdShow.Enabled = False
    '        cmdShow2.Enabled = True
    '        cboClaimNo.Text = ""
    '        cboPriCust.Text = ""
    '        cboSecCust.Text = ""
    '        cboVendor.Text = ""
    '        Call format_cboPriCust()

    '        Call format_cboSecCust2()
    '        Call format_cboVenno()

    '    End If
    'End Sub

    Private Sub txtdocno_MouseClick() Handles txtdocno.MouseClick
        'cboPriCust.Enabled = False
        'cboSecCust.Enabled = False
        'cboClaimNo.Enabled = False

        'cboClaimNo.Enabled = False
        'cboVendor.Enabled = False


        'cboClaimNo.Text = ""
        'cboPriCust.Text = ""
        'cboSecCust.Text = ""
        'cboVendor.Text = ""

        'rbClaimBy_C.Checked = False
        'rbClaimBy_U.Checked = False
        'rbClaimBy_V.Checked = False
        'cmdShow2.Enabled = False
        cmdShow.Enabled = True
    End Sub

    'Private Sub format_cboPriCust()
    '    Dim i As Integer
    '    Dim strList As String

    '    cboPriCust.Items.Clear()

    '    gspStr = "sp_list_CUBASINF '','PA'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading CLR00001_Load sp_list_CUBASINF : " & rtnStr)
    '        Exit Sub
    '    End If

    '    If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
    '        For i = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
    '            strList = ""
    '            If rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
    '                strList = rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna")
    '            End If

    '            If strList <> "" Then
    '                cboPriCust.Items.Add(strList)
    '            End If
    '        Next i
    '    End If
    'End Sub
    'Private Sub format_cboSecCust2()

    '    cboSecCust.Items.Clear()

    '    gspStr = "sp_select_CUBASINF_PC '" & gsDefaultCompany & "','" & gsUsrID & "','SC','Secondary'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading CLR00001 #002 sp_list_CUBASINF : " & rtnStr)
    '        Exit Sub
    '    End If


    '    Dim i As Integer
    '    Dim strList As String

    '    If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
    '        For i = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
    '            strList = ""
    '            strList = rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna")
    '            If strList <> "" Then
    '                cboSecCust.Items.Add(strList)
    '            End If
    '        Next i
    '    End If
    'End Sub

    'Private Sub format_cboSecCust(ByVal SecCust As String)

    '    cboSecCust.Items.Clear()

    '    gspStr = "sp_select_CUBASINF_Q '','" & SecCust & "','Secondary'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading CLR00001 #002 sp_list_CUBASINF : " & rtnStr)
    '        Exit Sub
    '    End If


    '    Dim i As Integer
    '    Dim strList As String

    '    If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
    '        For i = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
    '            strList = ""
    '            strList = rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("csc_seccus") & " - " & rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna")
    '            If strList <> "" Then
    '                cboSecCust.Items.Add(strList)
    '            End If
    '        Next i
    '    End If
    'End Sub

    'Private Sub format_cboVenno()
    '    Dim i As Integer
    '    Dim strList As String

    '    cboVendor.Items.Clear()
    '    gspStr = "sp_list_VNBASINF ''"
    '    rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading CLR00001_Load sp_list_VNBASINF : " & rtnStr)
    '        Exit Sub
    '    End If
    '    If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
    '        For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
    '            strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
    '            If strList <> "" Then
    '                cboVendor.Items.Add(strList)
    '            End If
    '        Next i
    '    End If
    'End Sub






    'Private Sub format_cboClaimNo()
    '    Dim i As Integer
    '    Dim strList As String

    '    cboClaimNo.Text = ""
    '    cboClaimNo.Items.Clear()
    '    gspStr = "sp_select_CAORDHDR_ClaimNo'" & Split(cboPriCust.Text.Trim, " - ")(0) & "','" & Split(cboSecCust.Text.Trim, " - ")(0) & "','" & Split(cboVendor.Text.Trim, " - ")(0) & "'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_CAORDHDR_ClaimNo, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        MsgBox("Error on loading CLR00001_Load sp_select_CAORDHDR_ClaimNo : " & rtnStr)
    '        Exit Sub
    '    End If

    '    If rs_CAORDHDR_ClaimNo.Tables("RESULT").Rows.Count > 0 Then

    '        For i = 0 To rs_CAORDHDR_ClaimNo.Tables("RESULT").Rows.Count - 1
    '            strList = rs_CAORDHDR_ClaimNo.Tables("RESULT").Rows(i).Item("cah_caordno")


    '            cboClaimNo.Enabled = True
    '            cboClaimNo.Items.Add(strList)



    '        Next i
    '    Else
    '        If rbClaimBy_C.Checked = True Then
    '            If cboPriCust.Text <> "" And cboSecCust.Text = "" Then
    '                MsgBox("There is no Claim related to Primary Customer")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text = "" And cboSecCust.Text <> "" Then
    '                MsgBox("There is no Claim related to Secondary Customer")
    '                cboSecCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text <> "" And cboSecCust.Text <> "" Then
    '                MsgBox("There is no Claim related to Primary Customer and Secondary Customer")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            End If
    '        End If

    '        If rbClaimBy_V.Checked = True Then
    '            If cboVendor.Text <> "" Then
    '                MsgBox("There is no Claim related to Vendor")
    '                cboVendor.Focus()
    '                Exit Sub
    '            End If
    '        End If

    '        If rbClaimBy_U.Checked = True Then
    '            If cboPriCust.Text <> "" And cboSecCust.Text = "" And cboVendor.Text = "" Then
    '                MsgBox("There is no Claim related to Primary Customer")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text = "" And cboSecCust.Text <> "" And cboVendor.Text = "" Then
    '                MsgBox("There is no Claim related to Secondary Customer")
    '                cboSecCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text = "" And cboSecCust.Text = "" And cboVendor.Text <> "" Then
    '                MsgBox("There is no Claim related to Vendor")
    '                cboVendor.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text <> "" And cboSecCust.Text <> "" And cboVendor.Text = "" Then
    '                MsgBox("There is no Claim related to Primary Customer and Secondary Customer")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text = "" And cboSecCust.Text <> "" And cboVendor.Text <> "" Then
    '                MsgBox("There is no Claim related to Secondary Customer and Vendor")
    '                cboSecCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text <> "" And cboSecCust.Text = "" And cboVendor.Text <> "" Then
    '                MsgBox("There is no Claim related to Primary Customer and Vendor")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            ElseIf cboPriCust.Text <> "" And cboSecCust.Text <> "" And cboVendor.Text <> "" Then
    '                MsgBox("There is no Claim related to Primary Customer, Secondary Customer and Vendor")
    '                cboPriCust.Focus()
    '                Exit Sub
    '            End If
    '        End If
    '    End If

    'End Sub

    'Private Sub format_inputClaimBy_after()

    '    gbClaimBy.Enabled = False

    'End Sub





    'Private Sub cboPriCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCust.SelectedIndexChanged

    '    cboClaimNo.Enabled = True
    '    Call format_cboClaimNo()
    'End Sub

    'Private Sub cboSecCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCust.SelectedIndexChanged
    '    cboClaimNo.Enabled = True
    '    Call format_cboClaimNo()
    'End Sub

    'Private Sub cboVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendor.SelectedIndexChanged
    '    cboClaimNo.Enabled = True
    '    Call format_cboClaimNo()
    'End Sub

    'Private Sub cmdShow2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow2.Click
    '    If cboClaimNo.Text <> "" Then
    '        gspStr = "sp_select_CLR00001 '','" & Me.cboClaimNo.Text.Trim & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CLR00001, rtnStr)
    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading CLR00001 #001 sp_select_CLR00001 : " & rtnStr)
    '            Exit Sub
    '        End If

    '        gspStr = "sp_select_CAORDDTL'" & gsCompany & "','" & txtdocno.Text.Trim & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CAORDDTL, rtnStr)
    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading CLR00001 sp_list_CAORDDTL : " & rtnStr)

    '            Exit Sub
    '        End If


    '        Dim objRpt As New CLR00001Rpt
    '        objRpt.SetDataSource(rs_CLR00001.Tables("RESULT"))

    '        Dim frm As New frmReport
    '        frm.CrystalReportViewer.ReportSource = objRpt
    '        frm.Show()

    '    End If
    '    If cboClaimNo.Text = "" Then
    '        MsgBox("Please input Claim Order No.")

    '        Me.cboClaimNo.Focus()

    '    End If


    'End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click

        Dim strDir As String
        strDir = "C:\CLAIM_PDF"
        Me.Cursor = Cursors.WaitCursor

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        If txtdocno.Text <> "" Then
            gspStr = "sp_select_CLR00001 '','" & Me.txtdocno.Text.Trim & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CLR00001, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLR00001 #001 sp_select_CLR00001 : " & rtnStr)
                Exit Sub
            End If
            If rs_CLR00001.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No record!")
                Exit Sub
            End If


            gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & txtdocno.Text.Trim & "','" & "CL" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT_Check, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtQutNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
                Exit Sub
            End If
            If Not rs_SYUSRRIGHT_Check.Tables("RESULT") Is Nothing Then
                If rs_SYUSRRIGHT_Check.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document Or Document not found!")
                    Me.Cursor = Windows.Forms.Cursors.Default


                    Exit Sub
                Else
                End If
            Else
                MsgBox("Rights access error.")
                Me.Cursor = Windows.Forms.Cursors.Default

                Exit Sub
            End If



            Dim objRpt As New CLR00001Rptb
            objRpt.SetDataSource(rs_CLR00001.Tables("RESULT"))

            ''''pdf start
            Dim dir As New IO.DirectoryInfo(strDir)
            If dir.Exists = False Then
                MsgBox("The Following Directory Does not exist: " & strDir & "     Please create the directory.")
                Exit Sub
            End If

            If rs_CLR00001.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No record found !")
                Exit Sub
            Else
                objRpt.Database.Tables("CLR00001Rpt2").SetDataSource(rs_CLR00001.Tables("RESULT"))
                'Export to PDF
                objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, strDir & "\" & txtdocno.Text & ".pdf")
                MsgBox("File Saved: " & strDir & "\" & txtdocno.Text & ".pdf")
            End If


        Else
            MsgBox("There is no Claim No that you type")
            Me.txtdocno.Focus()
            Exit Sub
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''

        If txtdocno.Text = "" Then
            MsgBox("Please enter Claim Order No.")
            Call CLR00001_Load(Nothing, Nothing)
            Me.txtdocno.Focus()
        End If
        Me.Cursor = Cursors.Default

    End Sub
End Class