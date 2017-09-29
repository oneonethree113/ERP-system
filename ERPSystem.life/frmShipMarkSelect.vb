Imports System.IO

Public Class frmShipMarkSelect
    Dim rs_SHCUSHMK As DataSet
    Dim rs_SYSHPMKC As DataSet
    Public rs_SHRMKVAL As New DataSet
    Public rs_SCSHPMRK As New DataSet



    Public ma As SHM00001

     
    Private Sub frmShipMarkSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dr() As DataRow
        'Dim ma As SHM00001


        gspStr = "sp_list_SCSHPMRK_SHM00001 '" & ma.cboCoCde.Text & "','" & ma.cboOrdNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SCSHPMRK, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtShpNoKeyPress sp_select_SCSHPMRK :" & rtnStr)
            Exit Sub
        End If

        If rs_SCSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            'MsgBox("No Record Found!")
            ' Exit Sub
        End If

        'For i As Integer = 0 To rs_SCSHPMRK.Tables("RESULT").Columns.Count - 1
        '    rs_SCSHPMRK.Tables("RESULT").Columns(i).ReadOnly = False
        'Next i


        '        txtImgNam.Text = rs_SCSHPMRK.Tables("RESULT").Rows(0)("ssm_imgnam")
        If rs_SCSHPMRK.Tables("RESULT").Rows.Count > 0 Then
            txtSC.Text = rs_SCSHPMRK.Tables("RESULT").Rows(0)("ssm_engdsc")
        End If
        '       txtImgPth.Text = rs_SCSHPMRK.Tables("RESULT").Rows(0)("ssm_imgpth")
        '      txtEngRmk.Text = rs_SCSHPMRK.Tables("RESULT").Rows(0)("ssm_engrmk")

        'If txtImgPth.Text.Trim <> "" Then
        '    Picture1.Load(gs_PDO_SMImg & txtImgPth.Text.Trim)
        '    Picture1.SizeMode = PictureBoxSizeMode.Zoom
        '    Picture1.Visible = True
        'End If
        'txtSC.Text = ma.txtEngDsc.Text

        gspStr = "sp_select_SHRMKVAL '','P','" & Split(ma.cboCus1No.Text.Trim, " - ")(0) & "',''  "
        rtnLong = execute_SQLStatement(gspStr, rs_SHRMKVAL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading   sp_select_SHRMKVAL   : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_SHRMKVAL.Tables("RESULT").Columns.Count - 1
                rs_SHRMKVAL.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            'rs_SHRMKVAL_ori = rs_SHRMKVAL.Copy()

            '''
            cboSMT.Items.Clear()
            cboSMT.Items.Add("")
            rs_SHRMKVAL.Tables("RESULT").DefaultView.RowFilter = "hrt_rmkcde = 'ship_marks' "
            For index1 As Integer = 0 To rs_SHRMKVAL.Tables("RESULT").DefaultView.Count - 1
                cboSMT.Items.Add(rs_SHRMKVAL.Tables("RESULT").DefaultView(index1)("hrt_rmkdsc"))
            Next

            txtCust.Text = ""
            rs_SHRMKVAL.Tables("RESULT").DefaultView.RowFilter = "hrt_rmkcde = 'ship_marks'  and hrt_flgdef ='Y' and hrt_pricustno = '" & Split(ma.cboCus1No.Text.Trim, " - ")(0) & "'"
            '            rs_SHRMKVAL.Tables("RESULT").DefaultView.RowFilter = "hrt_rmkcde = 'packlist_footer'  and hrt_flgdef ='Y' "
            If rs_SHRMKVAL.Tables("RESULT").DefaultView.Count > 0 Then
                txtCust.Text = rs_SHRMKVAL.Tables("RESULT").DefaultView(0)("hrt_rmkval")
            End If

        End If



        ' cboSMT.SelectedIndex = 0
        'gspStr = "sp_select_SYSHPMKC ''"
        'rtnLong = execute_SQLStatement(gspStr, rs_SYSHPMKC, rtnStr)
        'gspStr = ""
        ''''''' Cursor = Cursors.Default

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading fillParameter sp_select_SYSHPMKC :" & rtnStr)
        '    Exit Sub
        'End If

        'If rs_SYSHPMKC.Tables("RESULT").Rows.Count > 0 Then
        '    cboSMT.Items.Clear()
        '    cboSMT.Text = ""


        '    dr = rs_SYSHPMKC.Tables("RESULT").Select(" 2 > 1 ")


        '    If Not dr Is Nothing Then
        '        If dr.Length > 0 Then
        '            For index As Integer = 0 To dr.Length - 1
        '                cboSMT.Items.Add(dr(index)("yci_smtcde") + " - " + dr(index)("yci_smtdsc"))
        '            Next index
        '        End If
        '    End If
        'Else
        '    MsgBox("There is no function, please contact EDP or System Administrator.")
        '    Exit Sub
        'End If




        'gspStr = "sp_select_SHCUSHMK '" & Split(ma.cboCus1No.Text.Trim, " - ")(0) & "','" & cboSMT.Text.Trim & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_SHCUSHMK, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading txtShpNoKeyPress sp_select_SYUSRRIGHT_Check :" & rtnStr)
        '    Exit Sub
        'End If

        'If rs_SHCUSHMK.Tables("RESULT").Rows.Count = 0 Then
        'Else
        '    txtCust.Text = rs_SHCUSHMK.Tables("RESULT").Rows(0)("hcs_sm")
        'End If

    End Sub

    Private Sub cboSMT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSMT.SelectedIndexChanged
        If rs_SHRMKVAL.Tables("RESULT") Is Nothing Then Exit Sub

        rs_SHRMKVAL.Tables("RESULT").DefaultView.RowFilter = " hrt_rmkcde = 'ship_marks'   and    hrt_rmkdsc = '" & cboSMT.Text.Trim.Replace("'", "") & "' "

        If rs_SHRMKVAL.Tables("RESULT").DefaultView.Count > 0 Then
            txtCust.Text = rs_SHRMKVAL.Tables("RESULT").DefaultView(0)("hrt_rmkval")
        End If

    End Sub

    Private Sub cmdSc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSc.Click
        ma.txtEngDsc.Text = txtSC.Text
        Me.Close()
    End Sub

    Private Sub cmdcust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcust.Click
        ma.txtEngDsc.Text = txtCust.Text
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub
End Class