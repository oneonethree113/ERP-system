Imports System.Collections.Generic


Public Class frmCopyQut

    Inherits System.Windows.Forms.Form

    Public ma As QUM00001
    Dim drNewRow As DataRow
    Dim sFilter As String
    Dim dr() As DataRow
    Dim rs_IMXCHK As New DataSet
    Private Const sMODULE As String = "QU"

    Public rs_qutitmlst As New DataSet
    Public rs_qutivnlst As New DataSet
    Public rs_CUBASINF_P As New DataSet
    Public rs_CUBASINF_S As New DataSet
    Public rs_QUOTNDTL_COPY As New DataSet
    Public ans As Integer
    Public strQutNo As String

    Public strOriCocde As String
    Public strModule As String

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If ma.cboCoCde.Text.Trim = "" Then
            ma.cboCoCde.Text = cboCoCde.Text
        End If

        If ma.cboCoCde.Text.Trim = "" Then
            ma.cboCoCde.Text = "UCPP"
        End If

        Call ma.qutcopied(ma.cboCoCde.Text, ma.txtQutNo.Text)

        Me.Close()
    End Sub

    Private Sub frmCopyQut_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged

    End Sub

    Private Sub frmCopyQut_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
     

    End Sub

    Private Sub frmCopyQut_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      
    End Sub

    Private Sub frmCopyQut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
       
    End Sub

    Private Sub frmCopyQut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
    
    End Sub

    Private Sub frmCopyQut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Call CompComboFill(gsUsrID, ma.cboCoCde)         'Get availble Company
        Call display_combo(ma.cboCoCde.Text, cboCoCde)
        strOriCocde = ma.cboCoCde.Text

        Call fillPri()
        Call display_combo(matchPri(ma.cboCus1No.Text), cboPriCus)

        Call cboPriCusClick()

        If ma.cboCus2No.Text <> "" Then
            Call display_combo(matchSec(ma.cboCus2No.Text), cboSecCus)
        End If

        'cboCoCde.Enabled = False
        'cboPriCus.Enabled = False
        'cboSecCus.Enabled = False

        Cursor = Cursors.Default
    End Sub




    Public Sub CompComboFill(ByVal userid As String, ByVal cbobox As ComboBox)
        Dim rs_SYMUSRCO As New DataSet
        Dim gspStr As String
        Dim frm As Form
        frm = CType(cbobox.FindForm, Form)

        Me.cboCoCde.Items.Clear()

        If gsConnStr = "" Then
            gsConnStr = getConnStr(gsConnStr, rtnStr, "CON-DB")
        End If

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_SYUSRGRP_COMP '','" & gsUsrID & "','" & frm.Name.ToString & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYUSRGRP_COMP : " & rtnStr)
        Else
            For Each dr As DataRow In rs_SYMUSRCO.Tables("RESULT").Rows
                If gsCompanyGroup = "UCG" Then
                    If dr.Item("yuc_cocde").ToString <> "MS" Then
                        Me.cboCoCde.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                ElseIf gsCompanyGroup = "MSG" Then
                    If dr.Item("yuc_cocde").ToString = "MS" Then
                        Me.cboCoCde.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                End If
            Next
        End If
        rs_SYMUSRCO.Tables.Clear()
    End Sub

    Private Sub fillPri()
        'S = "㊣CUBASINF_PC※S※" & gsUsrID & "※" & strModule & "※Primary"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & cboCoCde.Text & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fillParameter sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
            cboPriCus.Items.Clear()
            cboPriCus.Text = ""
            cboSecCus.Items.Clear()
            cboSecCus.Text = ""

            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")

            If Not dr Is Nothing Then
                If dr.Length > 0 Then
                    For index As Integer = 0 To dr.Length - 1
                        cboPriCus.Items.Add(dr(index)("cbi_cusno") + " - " + dr(index)("cbi_cussna"))
                    Next
                End If
            End If
        Else
            MsgBox("There is no function, please contact EDP or System Administrator.")
            Exit Sub
        End If

        'OptPrcIM.Value = True
        'optprcQut.Enabled = False
        'OptPrcIM.Enabled = False
    End Sub

    Private Function matchPri(ByVal priNo As String) As String
        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & priNo.Substring(0, 5))

        matchPri = dr(0)("cbi_cusno") + " - " + dr(0)("cbi_cussna")
    End Function

    Private Function matchSec(ByVal secNo As String) As String
        dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus = " & secNo.Substring(0, 5))
        If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then
            matchSec = ""
            Exit Function
        End If
        matchSec = dr(0)("csc_seccus") + " - " + dr(0)("cbi_cussna")
    End Function

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        gsCompany = cboCoCde.Text
        Call Update_gs_Value(gsCompany)
        fillPri()

        Call ma.copy_to_new_cocus(Trim(Split(cboCoCde.Text, "-")(0)), Trim(Split(cboPriCus.Text, "-")(0)), Trim(Split(cboSecCus.Text, "-")(0)))

    End Sub

    Private Sub cboCoCde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        Call auto_search_combo(cboCoCde)
    End Sub

    Private Sub cboPriCus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPriCus.KeyPress
        If e.KeyChar = Chr(13) Then
            Call cboPriCusClick()
        End If
    End Sub

    Private Sub cboPriCus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCus.KeyUp
        Call auto_search_combo(cboPriCus)
    End Sub

    Private Sub cboPriCus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriCus.SelectedIndexChanged
        Call cboPriCusClick()
        Call ma.copy_to_new_cocus(Trim(Split(cboCoCde.Text, "-")(0)), Trim(Split(cboPriCus.Text, "-")(0)), Trim(Split(cboSecCus.Text, "-")(0)))

    End Sub

    Private Sub cboPriCusClick()
        If cboPriCus.Text <> "" Then
            'S = "㊣CUBASINF_Q※S※" & Left(cboPriCus.Text, InStr(cboPriCus.Text, " - ") - 1) & "※Secondary"
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            Cursor = Cursors.WaitCursor

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboPriCus.Text, InStr(cboPriCus.Text, " - ") - 1) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboPriCus_Click sp_select_CUBASINF_Q :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                cboSecCus.Text = ""
                cboSecCus.Enabled = False
            Else
                cboSecCus.Enabled = True

                cboSecCus.Items.Clear()

                For index As Integer = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
                    cboSecCus.Items.Add(rs_CUBASINF_S.Tables("RESULT").Rows(index)("csc_seccus").ToString + _
                                        " - " + rs_CUBASINF_S.Tables("RESULT").Rows(index)("cbi_cussna").ToString)
                Next
            End If
        End If
    End Sub

    Private Sub cboSecCus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSecCus.KeyUp
        Call auto_search_combo(cboSecCus)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If Trim(cboCoCde.Text) = "" Or Trim(cboPriCus.Text) = "" Then Exit Sub

        If Trim(cboCoCde.Text) <> "" Then
            ma.copyQutCoCde = cboCoCde.Text
        Else
            ma.copyQutCoCde = ""
        End If
 

        If Trim(cboPriCus.Text) <> "" Then
            ma.copyQutCus1no = Split(cboPriCus.Text, "-")(0)
            '            ma.copyQutCus1no = Microsoft.VisualBasic.Left(cboPriCus.Text, InStr(cboPriCus.Text, " - ") - 1)

            ma.copyQutCus1noFull = cboPriCus.Text
        Else
            ma.copyQutCus1no = ""
            ma.copyQutCus1noFull = ""
        End If

        If Trim(cboSecCus.Text) <> "" Then
            ma.copyQutCus2no = Microsoft.VisualBasic.Left(cboSecCus.Text, InStr(cboSecCus.Text, " - ") - 1)
            ma.copyQutCus2noFull = cboSecCus.Text
        Else
            ma.copyQutCus2no = ""
            ma.copyQutCus2noFull = ""
        End If

        ma.qut.ShowDialog()

        Me.Close()
    End Sub







    Private Sub cboSecCus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCus.SelectedIndexChanged

        Call ma.qutcopied_cus2(Me.cboSecCus.Text.Trim)
        Call ma.copy_to_new_cocus(Trim(Split(cboCoCde.Text, "-")(0)), Trim(Split(cboPriCus.Text, "-")(0)), Trim(Split(cboSecCus.Text, "-")(0)))


    End Sub
End Class