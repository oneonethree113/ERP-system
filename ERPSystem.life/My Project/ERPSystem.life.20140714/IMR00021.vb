Public Class IMR00021


    Public rs_CUBASINF As DataSet
    Public rs_IMR00021 As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_SYSETINF As DataSet
    Public objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"
    Public dr() As DataRow



    Private Sub cmdItemList_Click()
        'frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        'txtItemList.Text = frmItemList.strSel
    End Sub

    Private Sub cmdShow_Click()


    End Sub

    Private Sub Form_Load()


        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        'optItmTyp_REG.Value = True
        'Call optItmTyp_Reg_Click()
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Dim S As String
        Dim itmType As String
        Dim resultType As String
        Dim rs() As ADOR.Recordset

        If Len(Trim(Me.txtItemList.Text)) <= 0 Then
            MsgBox("Please Input Item Number!")
            Exit Sub
        End If

        ' Rem by Mark Lau 20090519
        '    itmType = "ASS"
        '    'If Me.optItmTyp_BOM.Value = True Then itmType = "BOM"
        '
        '    resultType = "ASS"
        '    'If Me.optResult_Reg.Value = True Then resultType = "REG"
        '    'If Me.optResult_Both.Value = True Then resultType = "BOTH"

        If Me.optItmTyp_BOM.Checked = True Then itmType = "BOM"
        If Me.optItmTyp_REG.Checked = True Then itmType = "REG"
        If Me.optItmTyp_ASS.Checked = True Then itmType = "ASS"

        resultType = "BOTH"



        gspStr = "temp_sp_list_IMR00021   '','" + Trim(Me.txtItemList.Text) + "','" + itmType + "','" + resultType + "'"



        'gspStr = " sp_list_IMR00021 'UCP','F10OM24158MIC,10A001A001A01,13B400-FDER080','ASS','BOTH'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMR00021, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMR00021 : " & rtnStr)
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.Default


        If rs_IMR00021.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("IMR00021 no record!")
            Exit Sub
        End If


        Dim objRpt As New IMR00021Rpt
        objRpt.SetDataSource(rs_IMR00021.Tables("RESULT"))

        Dim frmReportView As New frmReport
        frmReportView.CrystalReportViewer.ReportSource = objRpt
        frmReportView.Show()



    End Sub

    Private Sub cmdItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemList.Click
        frmItemList.strItem = txtItemList.Text
        'frmItemList.Show(vbModal)
        Call frmItemList.getform("IMR00021")
        frmItemList.ShowDialog()
        txtItemList.Text = frmItemList.strSel
    End Sub

    Public Function settxtItemList(ByVal strA As String)
        Me.txtItemList.Text = strA
        'Me.Show()
        'Me.Refresh()


    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub txtItemList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemList.TextChanged

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
    Private Sub optItmTyp_BOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_BOM.CheckedChanged

    End Sub
    Private Sub optItmTyp_REG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_REG.CheckedChanged

    End Sub
    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub
    Private Sub optItmTyp_ASS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optItmTyp_ASS.CheckedChanged

    End Sub
    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub optResult_Ass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResult_Ass.CheckedChanged

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub grpSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSearch.Enter

    End Sub
End Class