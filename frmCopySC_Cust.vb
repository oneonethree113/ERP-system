Public Class frmCopySC_Cust

    Public myOwner As SCM00001

    Public rs_CUBASINF_P As DataSet
    Public rs_CUBASINF_S As DataSet

    Const strModule As String = "SC"

    Dim strOriCocde As String

    Private Sub frmCopySC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillcboCoCde()
        display_combo(gsCompany, cboCoCde)
        strOriCocde = gsCompany

        display_combo(Split(myOwner.cboPriCust.Text, " - ")(0), cboPriCust)
        display_combo(Split(myOwner.cboSecCust.Text, " - ")(0), cboSecCust)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If (Trim(cboSecCust.Text) = "") Then
            myOwner.CopySC_SUB.SecCust = ""
        Else
            myOwner.CopySC_SUB.SecCust = Split(cboSecCust.Text, " - ")(0)
        End If
        myOwner.CopySC_SUB.PriCust = Split(cboPriCust.Text, " - ")(0)
        myOwner.CopySC_SUB.CuFml = myOwner.Custfml
        myOwner.CopySC_SUB.ShowDialog()


        myOwner.strPriCust_Copy = Split(cboPriCust.Text, " - ")(0)
        If cboSecCust.Text <> "" Then
            myOwner.strSecCust_Copy = Split(cboSecCust.Text, " - ")(0)
        Else
            myOwner.strSecCust_Copy = ""
        End If

        cmdCancel.PerformClick()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub fillcboCoCde()
        Dim rs As New DataSet

        gspStr = "sp_select_SYUSRGRP_COMP '','" & gsUsrID & "','SCM00001'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> "0" Then  '*** An error has occured
            MsgBox("Error on loading frmCopySC_Cust #001 sp_select_SYUSRGRP_COMP : " & rtnStr)
        Else
            For i As Integer = 0 To rs.Tables("RESULT").Rows.Count - 1
                If gsCompanyGroup = "UCG" Then
                    If rs.Tables("RESULT").Rows(i)("yuc_cocde").ToString <> "MS" Then
                        cboCoCde.Items.Add(rs.Tables("RESULT").Rows(i)("yuc_cocde").ToString)
                    End If
                Else
                    If rs.Tables("RESULT").Rows(i)("yuc_cocde").ToString = "MS" Then
                        cboCoCde.Items.Add(rs.Tables("RESULT").Rows(i)("yuc_cocde").ToString)
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        gsCompany = cboCoCde.Text
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & strModule & "','Primary'"

        rs_CUBASINF_P = Nothing

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmCopySC_Cust #002 sp_select_CUBASINF_PC : " & rtnStr)
            Exit Sub
        Else
            fillcboPriCust()
        End If
    End Sub

    Private Sub fillcboPriCust()
        Dim dr() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")

        If dr.Length > 0 Then
            cboPriCust.Text = ""
            cboPriCust.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboPriCust.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If


        cboPriCust.SelectedIndex = -1

    End Sub

    Private Sub ValidateKeyPress_Cust(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPriCust.KeyPress, cboSecCust.KeyPress
        If Asc(e.KeyChar) = 8 Then
            Exit Sub
        ElseIf Asc(e.KeyChar) = 13 Then
            sender.SelectAll()
        ElseIf Asc(e.KeyChar) >= 47 And Asc(e.KeyChar) <= 57 Then
            Exit Sub
        Else
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Autosearch_Cust(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCust.KeyUp, cboSecCust.KeyUp
        If (e.KeyValue >= 47 And e.KeyValue <= 57) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Then
            If Split(sender.Text, " - ")(0).Length <= 5 Then
                auto_search_combo(sender)
            End If
        End If
    End Sub


    Private Sub cboPriCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCust.SelectedIndexChanged
        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Split(cboPriCust.Text, " - ")(0) & "','Secondary'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading frmCopySC_Cust #003 sp_select_CUBASINF_Q : " & rtnStr)
        Else
            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                cboSecCust.Text = ""
                'cboSecCust.Enabled = False
                SetComboStatus(cboSecCust, "Disable")
            Else
                ' cboSecCust.Enabled = True
                SetComboStatus(cboSecCust, "Enable")
                cboSecCust.Items.Clear()

                cboSecCust.Items.Add("")
                For i As Integer = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
                    cboSecCust.Items.Add(rs_CUBASINF_S.Tables("RESULT").Rows(i)("csc_seccus").ToString & " - " & rs_CUBASINF_S.Tables("RESULT").Rows(i)("cbi_cussna").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub SetComboStatus(ByVal combo As ComboBox, ByVal mode As String)
        If mode = "Enable" Then
            combo.Enabled = True
            combo.DropDownStyle = ComboBoxStyle.DropDown
        Else
            combo.DropDownStyle = ComboBoxStyle.DropDownList
            combo.Enabled = False
        End If
    End Sub
End Class