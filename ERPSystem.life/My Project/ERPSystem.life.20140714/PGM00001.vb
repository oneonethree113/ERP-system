Imports System.IO

Public Class PGM00001
    Const pkg_imgsvr As String = "\\Uchkimgsrv\Pkgimg\Item\"

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim mode As String
    Dim rs_CUBASINF_P As DataSet
    Dim rs_CUBASINF_S As DataSet
    Dim rs_SYPAKCAT As DataSet
    Dim rs_PKIMBAIF As DataSet
    Dim Add_flag As Boolean = False
    Dim recordstatus As Boolean = False
    Dim flag_panpack_keypress As Boolean
    Dim rs_SYSETINF As DataSet



    Private Sub PGM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right


        format_cboStatus() ' Status
        format_cboYear()


        gspStr = "sp_select_CUBASINF_VNEXCCUS"       ' from quotation

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00001_Load sp_select_CUBASINF_PC : " & rtnStr)
        Else
            If rs_CUBASINF_P.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            Else
                Call fillCus1No() '*** Fill up Currency combo box
            End If
        End If

        gspStr = "sp_list_CUBASINF_SAM00003_1 '" & gsCompany & "','S'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00001_Load sp_list_CUBASINF_SAM00003_1 : " & rtnStr)
        End If



        gspStr = "sp_list_SYSETINF ''"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00001_Load sp_list_SYSETINF : " & rtnStr)
        End If

        gspStr = "sp_list_SYPAKCAT ''"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYPAKCAT, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00001_Load sp_list_SYPAKCAT : " & rtnStr)
        Else
            If rs_SYPAKCAT.Tables("RESULT").Rows.Count <> 0 Then
                fillCate()
            End If
        End If

        mode = "INIT"
        formInit(mode)
        'format_cboPrcTrm()
        'format_cboCty()
        'format_cbopaytrm()
        'format_cboCurCde()
        'format_cboThcCry()
        'format_cboVndFlag()
        'txtVenNo.Enabled = True
        format_material()
        fillSeason()
        recordstatus = False
        txtPKITMNO.Select()


       


    End Sub

    Private Function CountCharacter(ByVal value As String, ByVal ch As String) As Integer
        Dim counter As Integer
        Dim a As Array
        a = Split(value, " - ")
        counter = a.Length - 1
        Return counter
    End Function

    Private Sub format_material()
        cboMatri.Items.Clear()
        cboTcknes.Items.Clear()
        cboPrtMtd.Items.Clear()
        cboForntCol.Items.Clear()
        cboBackCol.Items.Clear()
        cboFinish.Items.Clear()


        For i As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "32" Then
                cboMatri.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If

            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "33" Then
                cboTcknes.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If

            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "34" Then
                cboPrtMtd.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If

            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "35" Then
                cboForntCol.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
                cboForntFin.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If

            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "36" Then
                cboBackCol.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
                cboBackFin.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If

            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "37" Then
                cboFinish.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If


        Next




    End Sub

    Private Sub fillSeason()
        cboSeason.Items.Clear()
        cboSeason.Items.Add("")
        cboSeason.Text = ""

        For i As Integer = 0 To rs_SYSETINF.Tables("RESULT").Rows.Count - 1
            If rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_typ") = "19" Then
                cboSeason.Items.Add(rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF.Tables("RESULT").Rows(i).Item("ysi_dsc"))
            End If
        Next

    End Sub

    Private Sub fillCate()
        cboCat.Items.Clear()
        cboCat.Items.Add("")
        cboCat.Text = ""
        For i As Integer = 0 To rs_SYPAKCAT.Tables("RESULT").Rows.Count - 1
            cboCat.Items.Add(rs_SYPAKCAT.Tables("RESULT").Rows(i).Item("ypc_code") & " - " & rs_SYPAKCAT.Tables("RESULT").Rows(i).Item("ypc_pakna"))
        Next
    End Sub

    Private Sub fillCus1No()
        'Dim sFilter As String
        ' Marco added 20031028 start
        Dim add_flag As Boolean = True
        cboPricust.Items.Clear()
        cboPricust.Items.Add("")
        cboPricust.Text = ""

        Dim dv_sort_cus1no As DataView
        Dim dt_sort_cus1no As DataTable
        dv_sort_cus1no = rs_CUBASINF_P.Tables("RESULT").DefaultView
        dv_sort_cus1no.Sort = "cbi_cussna"
        dt_sort_cus1no = dv_sort_cus1no.ToTable


        If add_flag = True Then
            'sFilter = "cbi_cusno >= '50000'"
            Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno < '6000'", "cbi_cussna")
            If Not drCUBASINF_P Is Nothing Then
                For i As Integer = 0 To drCUBASINF_P.Length - 1
                    'filter the discontinue and inactive customer 
                    If Not (drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Discontinue") Or drCUBASINF_P(i).Item("cbi_cussna").ToString.Contains("Inactive")) Then
                        'MsgBox(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)

                        cboPricust.Items.Add(drCUBASINF_P(i).Item("cbi_cussna").ToString & " - " & drCUBASINF_P(i).Item("cbi_cusno").ToString)
                    End If
                Next
            End If
        Else
            For i As Integer = 0 To dt_sort_cus1no.Rows.Count - 1
                cboPricust.Items.Add(dt_sort_cus1no.Rows(i).Item("cbi_cussna").ToString & " - " & dt_sort_cus1no.Rows(i).Item("cbi_cusno").ToString)
            Next
        End If
        'Marco added 20031028 start
        'If Add_flag = True Then
        'sFilter = ""
        'rs_CUBASINF_P.Tables("RESULT").DefaultView.RowFilter = sFilter
        'End If
        'Marco added 20031028 end
    End Sub
    Private Sub format_cboStatus()
        cboStatus.Items.Clear()
        cboStatus.Items.Add("CMP - Complete Item")
        cboStatus.Items.Add("INC - Incomplete Item")


        'cboStatus.Items.Add("HLD - Item on Hold")
        'cboStatus.Items.Add("DIS - Discontinue Item")
        'cboStatus.Items.Add("TBC - To Be Confirmed")
        'cboStatus.Items.Add("INA - Inactive Item")
        'cboStatus.Items.Add("CLO - Closed Item")
        'cboStatus.Items.Add("OLD - Old Item")

        'cboStatus.Text = ""
    End Sub

    Private Sub format_cboYear()
        cboYear.Items.Clear()

        cboYear.Items.Add("")


        Dim year As Integer = Convert.ToInt32(Date.Now.Year)

        ' cboYear.Items.Add(year - 1.ToString)
        cboYear.Items.Add(year.ToString)
        cboYear.Items.Add(year + 1.ToString)


        'For i As Integer = 0 To 1
        '    year = year - 1
        '    cboYear.Items.Add(year.ToString)
        'Next






    End Sub


    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Call clearAllDisplay(Me)
        End If

        Call resetcmdButton(m)

        Call resetdisplay(m)

        'Me.StatusBar.Text = m
        SetStatusBar(m)

    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "INIT" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Add"
        ElseIf mode = "UPDATE" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub



    Private Sub resetcmdButton(ByVal Mode As String)
        If Mode = "INIT" Then
            cmdAdd.Enabled = Enq_right_local
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            cmdFind.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True


            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            'Add_flag = False
            txtPKITMNO.Enabled = True


            '   cmdAddCat.Enabled = False '''

        ElseIf Mode = "DisableAll" Then 'For copy disable
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdClear.Enabled = False
            cmdSearch.Enabled = False


            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            cmdCancel.Enabled = False

            'txtVenNam.Enabled = False
            'txtVenChnNam.Enabled = False
            'chkfty.Enabled = False
            'txtVenSna.Enabled = False
            'chkDiCoTi.Enabled = False
            'chkActivate.Enabled = False
            'ChkMOQChg.Enabled = False




        End If

    End Sub


    Private Sub resetdisplay(ByVal mode As String)
        If mode = "INIT" Then



            Me.StatusBar.Items("lblLeft").Text = ""
            Me.StatusBar.Items("lblRight").Text = ""
            cboCat.Text = ""
            cboStatus.Text = ""
            cboYear.Text = ""
            txtChinDesc.Text = ""
            txtEngDesc.Text = ""
            txtRemark.Text = ""
            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtECSizeW.Text = ""
            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""
            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""
            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish1.Text = ""
            RdoBarA.Checked = False
            RdoBarB.Checked = False
            RdoBarC.Checked = False
            cboPricust.Text = ""
            cboSecCust.Text = ""
            pboxImg.Image = Nothing


            cboMatri.Text = ""
            cboTcknes.Text = ""
            cboPrtMtd.Text = ""
            cboForntCol.Text = ""
            cboBackCol.Text = ""
            cboFinish.Text = ""
            cboForntFin.Text = ""
            cboBackFin.Text = ""


            txtFinish.Text = ""
            txtMatriDesc.Text = ""
            txtTcknesDesc.Text = ""
            txtPrtMtdDesc.Text = ""

            cboSeason.Text = ""



            chkA.Checked = False
            chkB.Checked = False
            chkC.Checked = False

            cmdUpload.Enabled = False
            'lstCty.DataSource = Nothing
            'lstCty.Visible = False

        ElseIf mode = "ReadOnly" Then


            txtPKITMNO.Enabled = False
            cboCat.Enabled = False
            cboStatus.Enabled = False
            cboYear.Enabled = False
            txtChinDesc.Enabled = False
            txtEngDesc.Enabled = False
            txtRemark.Enabled = False
            txtECSizeH.Enabled = False
            txtECSizeL.Enabled = False
            txtECSizeW.Enabled = False
            txtEISizeH.Enabled = False
            txtEISizeL.Enabled = False
            txtEISizeW.Enabled = False
            txtFCSizeH.Enabled = False
            txtFCSizeL.Enabled = False
            txtFCSizeW.Enabled = False
            txtFISizeH.Enabled = False
            txtFISizeL.Enabled = False
            txtFISizeW.Enabled = False
            txtMatri.Enabled = False
            txtTcknes.Enabled = False
            txtPrtMtd.Enabled = False
            txtForntCol.Enabled = False
            txtBackCol.Enabled = False
            txtFinish1.Enabled = False
            GroupBox1.Enabled = False
            RdoBarA.Enabled = False
            RdoBarB.Enabled = False
            RdoBarC.Enabled = False
            cboPricust.Enabled = False
            cboSecCust.Enabled = False
            pboxImg.Enabled = False
            cboMatri.Enabled = False
            cboTcknes.Enabled = False
            cboPrtMtd.Enabled = False
            cboForntCol.Enabled = False
            cboBackCol.Enabled = False
            cboForntFin.Enabled = False
            cboBackFin.Enabled = False
            cboFinish.Enabled = False
            cmdUpload.Enabled = False


            cmdFind.Enabled = False
            cmdAdd.Enabled = False
            cmdSave.Enabled = False




            txtFinish.Enabled = False
            txtMatriDesc.Enabled = False
            txtTcknesDesc.Enabled = False
            txtPrtMtdDesc.Enabled = False


            chkA.Enabled = False
            chkB.Enabled = False
            chkC.Enabled = False


            cboSeason.Enabled = False

            Call SetStatusBar(mode)



        ElseIf mode = "UPDATE" Then
            txtPKITMNO.Enabled = False
            cboCat.Enabled = False
            cboStatus.Enabled = False
            cboYear.Enabled = False
            txtChinDesc.Enabled = True
            txtEngDesc.Enabled = True
            txtRemark.Enabled = True
            txtECSizeH.Enabled = True
            txtECSizeL.Enabled = True
            txtECSizeW.Enabled = True
            txtEISizeH.Enabled = True
            txtEISizeL.Enabled = True
            txtEISizeW.Enabled = True
            txtFCSizeH.Enabled = True
            txtFCSizeL.Enabled = True
            txtFCSizeW.Enabled = True
            txtFISizeH.Enabled = True
            txtFISizeL.Enabled = True
            txtFISizeW.Enabled = True
            txtMatri.Enabled = True
            txtTcknes.Enabled = True
            txtPrtMtd.Enabled = True
            txtForntCol.Enabled = True
            txtBackCol.Enabled = True
            txtFinish1.Enabled = True
            GroupBox1.Enabled = True
            RdoBarA.Enabled = True
            RdoBarB.Enabled = True
            RdoBarC.Enabled = True
            cboPricust.Enabled = True
            cboSecCust.Enabled = True
            pboxImg.Enabled = True
            cboMatri.Enabled = True
            cboTcknes.Enabled = True
            cboPrtMtd.Enabled = True
            cboForntCol.Enabled = True
            cboBackCol.Enabled = True
            cboForntFin.Enabled = True
            cboBackFin.Enabled = True
            cboFinish.Enabled = True

            cmdUpload.Enabled = True


            cmdFind.Enabled = False
            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local



            txtFinish.Enabled = True
            txtMatriDesc.Enabled = True
            txtTcknesDesc.Enabled = True
            txtPrtMtdDesc.Enabled = True

            chkA.Enabled = True
            chkB.Enabled = True
            chkC.Enabled = True

            cboSeason.Enabled = True

            Call SetStatusBar(mode)
        ElseIf mode = "ADD" Then



            txtPKITMNO.Text = ""
            cboCat.Enabled = True
            cboStatus.Enabled = False
            cboStatus.SelectedIndex = 0

            cboYear.Enabled = True
            txtChinDesc.Enabled = True
            txtEngDesc.Enabled = True
            txtRemark.Enabled = True
            txtECSizeH.Enabled = True
            txtECSizeL.Enabled = True
            txtECSizeW.Enabled = True
            txtEISizeH.Enabled = True
            txtEISizeL.Enabled = True
            txtEISizeW.Enabled = True
            txtFCSizeH.Enabled = True
            txtFCSizeL.Enabled = True
            txtFCSizeW.Enabled = True
            txtFISizeH.Enabled = True
            txtFISizeL.Enabled = True
            txtFISizeW.Enabled = True
            txtMatri.Enabled = True
            txtTcknes.Enabled = True
            txtPrtMtd.Enabled = True
            txtForntCol.Enabled = True
            txtBackCol.Enabled = True
            txtFinish1.Enabled = True
            GroupBox1.Enabled = True
            RdoBarA.Enabled = True
            RdoBarB.Enabled = True
            RdoBarC.Enabled = True
            cboPricust.Enabled = True
            cboSecCust.Enabled = True
            pboxImg.Enabled = True
            cboMatri.Enabled = True
            cboTcknes.Enabled = True
            cboPrtMtd.Enabled = True
            cboForntCol.Enabled = True
            cboBackCol.Enabled = True
            cboForntFin.Enabled = True
            cboBackFin.Enabled = True
            cboFinish.Enabled = True

            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = False
            cmdFind.Enabled = False
            cmdAdd.Enabled = False
            cmdSearch.Enabled = False
            cmdCopy.Enabled = False

            cmdUpload.Enabled = False
            txtFinish.Enabled = True
            txtMatriDesc.Enabled = True
            txtTcknesDesc.Enabled = True
            txtPrtMtdDesc.Enabled = True




            chkA.Enabled = True
            chkB.Enabled = True
            chkC.Enabled = True

            cboSeason.Enabled = True


            Call SetStatusBar(mode)





        End If



    End Sub
    Private Sub clearAllDisplay(ByVal fv As Control)
        Dim v As Control
        For Each v In fv.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call clearAllDisplay(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call clearAllDisplay(v)
                v.Enabled = False
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then
                    v.Text = ""
                    v.Enabled = False
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    lb = v
                    lb.Items.Clear()
                    v.Enabled = False
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    cb = v
                    cb.Checked = False
                    v.Enabled = False
                ElseIf TypeOf v Is DataGridView Then
                    Dim dg As DataGridView
                    dg = v
                    dg.DataSource = Nothing
                End If
            End If
        Next v

    End Sub

    Public Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        mode = "ADD"
        Add_flag = True
        txtPKITMNO.Enabled = False
        resetdisplay(mode)
        DefaultAddValue()
        cboCat.Select()

    End Sub
    Private Sub DefaultAddValue()

        txtEISizeH.Text = 0
        txtEISizeL.Text = 0
        txtEISizeW.Text = 0
        txtECSizeH.Text = 0
        txtECSizeW.Text = 0
        txtECSizeL.Text = 0

        txtFISizeH.Text = 0
        txtFISizeL.Text = 0
        txtFISizeW.Text = 0
        txtFCSizeH.Text = 0
        txtFCSizeW.Text = 0
        txtFCSizeL.Text = 0


        format_cboStatus()



    End Sub
    Private Sub txtPKITMNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPKITMNO.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then

            Call cmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtPKITMNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKITMNO.TextChanged

    End Sub

    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        Me.Cursor = Cursors.WaitCursor

        txtPKITMNO.Text = UCase(txtPKITMNO.Text)


        If Enq_right_local Then
            mode = "UPDATE"
        Else
            mode = "ReadOnly"
        End If

        If Trim(txtPKITMNO.Text) = "" Then
            MsgBox("Please input Item No.")
            txtPKITMNO.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_PKIMBAIF  '" & txtPKITMNO.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_PKIMBAIF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            For i As Integer = 0 To rs_PKIMBAIF.Tables("RESULT").Columns.Count - 1
                rs_PKIMBAIF.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If



        If rs_PKIMBAIF.Tables("RESULT").Rows.Count <= 0 Then
            MsgBox("Not Record Found")
            txtPKITMNO.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub

        Else

            Call display()
            Call resetdisplay(mode) 'do

        End If

        Add_flag = False
        recordstatus = False
        Me.Cursor = Cursors.Default






    End Sub

    Private Sub display()
        Call display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate"), cboCat) ' cboCat
        Call display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_status"), cboStatus) ' cboStatus
        cboYear.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_year").ToString
        txtChinDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc").ToString
        txtEngDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc").ToString
        txtRemark.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark").ToString
        txtEISizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
        txtEISizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL").ToString
        txtEISizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW").ToString
        txtECSizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH").ToString
        txtECSizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL").ToString
        txtECSizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW").ToString

        txtFISizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchH").ToString
        txtFISizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL").ToString
        txtFISizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchW").ToString
        txtFCSizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH").ToString
        txtFCSizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL").ToString
        txtFCSizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW").ToString

        Call display_combo_Specail(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cus1no"), cboPricust)
        Call display_combo_Specail(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cus2no"), cboSecCust)
        'txtMatri.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral").ToString
        'txtTcknes.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes").ToString
        'txtPrtMtd.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd").ToString
        'txtForntCol.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot").ToString
        'txtBackCol.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck").ToString
        'txtFinish.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish").ToString

        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral").ToString, cboMatri)
        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes").ToString, cboTcknes)
        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd").ToString, cboPrtMtd)
        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot").ToString, cboForntCol)
        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck").ToString, cboBackCol)
        display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_season").ToString, cboSeason)
        'display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish").ToString, cboFinish)
        'display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finfot").ToString, cboForntFin)
        'display_combo(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finbck").ToString, cboBackFin)

        txtFinish.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish")
        txtMatriDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc")
        txtTcknesDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc")
        txtPrtMtdDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc")



        If rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_barcde").ToString = "A" Then
            chkA.Checked = True
        ElseIf rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_barcde").ToString = "B" Then
            chkB.Checked = True
        ElseIf rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_barcde").ToString = "C" Then
            chkC.Checked = True
        End If

        If File.Exists(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_img")) = True Then
            pboxImg.Load(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_img"))
            pboxImg.SizeMode = PictureBoxSizeMode.Zoom
            pboxImg.Visible = True
        End If

        Me.StatusBar.Items("lblRight").Text = Convert.ToDateTime(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_credat")).ToString("dd/MM/yyyy") & " " _
        & Convert.ToDateTime(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_upddat")).ToString("dd/MM/yyyy") _
        & " " & rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_updusr")


        'PictureBox1 
    End Sub



    Private Sub display_combo_Specail(ByVal val As String, ByVal combo As ComboBox)

        If val = "" Then
            combo.Text = val
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To combo.Items.Count - 1
            If combo.Items(i).ToString <> "" Then
                Dim count As Integer
                Dim a As Array
                a = Split(combo.Items(i).ToString, " - ")
                count = a.Length - 1

                If val = Split(combo.Items(i), " - ")(count) Then
                    combo.Text = combo.Items(i)
                    Exit Sub
                End If
            End If
        Next i

        combo.Text = val
    End Sub




    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If check_PG() = False Then
            Exit Sub
        End If

        If Save_PKIMBAIF() = True Then
            MsgBox("Record Saved")
            recordstatus = False
            Dim tmp_itmno As String = txtPKITMNO.Text
            formInit("INIT")
            txtPKITMNO.Text = tmp_itmno
            txtPKITMNO.Select()

        End If
    End Sub

    Private Function check_PG() As Boolean
        If Trim(cboCat.Text) = "" Then
            MsgBox("Please input Category.")
            check_PG = False
            cboCat.Focus()
            Exit Function
        End If

        If Trim(cboYear.Text) = "" Then
            MsgBox("Please input Year.")
            check_PG = False
            cboYear.Focus()
            Exit Function
        End If



        If Trim(txtEngDesc.Text) = "" Then
            MsgBox("Please input English Desc for packaging item.")
            check_PG = False
            txtEngDesc.Focus()
            Exit Function
        End If


        Dim eisizel As Decimal
        Dim eisizew As Decimal

        If IsNumeric(txtEISizeL.Text) = True Then
            eisizel = txtEISizeL.Text
        Else
            MsgBox("Please input integer value for Size!")
            check_PG = False
            txtEISizeL.Focus()
            Exit Function
        End If



        If IsNumeric(txtEISizeW.Text) = True Then
            eisizew = txtEISizeW.Text
        Else
            MsgBox("Please input integer value for Size!")
            check_PG = False
            txtEISizeW.Focus()
            Exit Function
        End If





        If (Trim(txtEISizeL.Text) = "" Or eisizel = 0) Or (Trim(txtEISizeW.Text) = "" Or eisizew = 0) Then
            MsgBox("Please input Expanded Size!")
            check_PG = False
            If (Trim(txtEISizeL.Text) = "" Or eisizel = 0) Then
                txtEISizeL.Focus()
            Else
                txtEISizeW.Focus()
            End If
            Exit Function
        End If


        If Trim(cboSeason.Text) = "" Then
            MsgBox("Please select Season!")
            check_PG = False
            cboSeason.Focus()
            Exit Function
        End If




        check_PG = True

    End Function


    Private Function Save_PKIMBAIF() As Boolean
        Dim pib_pgitmno As String
        Dim pib_cate As String
        Dim pib_year As String
        Dim pib_status As String
        Dim pib_chndsc As String
        Dim pib_engdsc As String
        Dim pib_remark As String
        Dim pib_EInchL As Decimal
        Dim pib_EInchW As Decimal
        Dim pib_EInchH As Decimal
        Dim pib_EcmL As Decimal
        Dim pib_EcmW As Decimal
        Dim pib_EcmH As Decimal
        Dim pib_FInchL As Decimal
        Dim pib_FInchW As Decimal
        Dim pib_FInchH As Decimal
        Dim pib_FcmL As Decimal
        Dim pib_FcmW As Decimal
        Dim pib_FcmH As Decimal
        Dim pib_cus1no As String
        Dim pib_cus2no As String
        Dim pib_matral As String
        Dim pib_tiknes As String
        Dim pib_prtmtd As String
        Dim pib_clrfot As String
        Dim pib_clrbck As String
        Dim pib_finish As String
        Dim pib_barcde As String
        Dim pib_img As String
        Dim user As String
        Dim pib_matDsc As String
        Dim pib_tikDsc As String
        Dim pib_prtDsc As String
        Dim pib_season As String
        'Dim pib_finfot As String
        'Dim pib_finbck As String


        pib_pgitmno = Trim(txtPKITMNO.Text)
        pib_cate = Split(cboCat.Text, " - ")(0)
        pib_year = cboYear.Text
        pib_status = Split(cboStatus.Text, " - ")(0)
        pib_chndsc = Replace(txtChinDesc.Text, "'", "''")
        pib_engdsc = Replace(txtEngDesc.Text, "'", "''")
        pib_remark = Replace(txtRemark.Text, "'", "''")
        pib_EInchL = txtEISizeL.Text
        pib_EInchW = txtEISizeW.Text
        pib_EInchH = txtEISizeH.Text
        pib_EcmL = txtECSizeL.Text
        pib_EcmW = txtECSizeW.Text
        pib_EcmH = txtECSizeH.Text
        pib_FInchL = txtFISizeL.Text
        pib_FInchW = txtFISizeW.Text
        pib_FInchH = txtFISizeH.Text
        pib_FcmL = txtFCSizeL.Text
        pib_FcmW = txtFCSizeW.Text
        pib_FcmH = txtFCSizeH.Text

        Dim count As Integer
        count = CountCharacter(cboPricust.Text, " - ")
        pib_cus1no = Split(cboPricust.Text, " - ")(count)
        count = CountCharacter(cboSecCust.Text, " - ")
        pib_cus2no = Split(cboSecCust.Text, " - ")(count)
        pib_matral = Replace(cboMatri.Text, "'", "''")
        pib_tiknes = Replace(cboTcknes.Text, "'", "''")
        pib_prtmtd = Replace(cboPrtMtd.Text, "'", "''")
        pib_clrfot = Replace(cboForntCol.Text, "'", "''")
        pib_clrbck = Replace(cboBackCol.Text, "'", "''")
        pib_finish = Replace(txtFinish.Text, "'", "''")
        pib_matDsc = Replace(txtMatriDesc.Text, "'", "''")
        pib_tikDsc = Replace(txtTcknesDesc.Text, "'", "''")
        pib_prtDsc = Replace(txtPrtMtdDesc.Text, "'", "''")
        'pib_finfot = Replace(cboForntFin.Text, "'", "''")
        'pib_finbck = Replace(cboBackFin.Text, "'", "''")

        pib_season = Split(cboSeason.Text, " - ")(0)

        If chkA.Checked = True Then
            pib_barcde = "A"
        ElseIf chkB.Checked = True Then
            pib_barcde = "B"
        ElseIf chkC.Checked = True Then
            pib_barcde = "C"
        Else
            pib_barcde = ""
        End If

        If mode <> "ADD" Then
            pib_img = rs_PKIMBAIF.Tables("RESULT").Rows(0)("pib_img")
        Else
            pib_img = ""
        End If

        If Add_flag = True Then  '''''''''''''''''''''Copy flag


            gspStr = "sp_insert_PKIMBAIF '" & pib_pgitmno & "','" & pib_cate & "','" & pib_year & "','" & pib_status & "','" & _
                  pib_chndsc & "','" & pib_engdsc & "','" & pib_remark & "'," & pib_EInchL & "," & pib_EInchW & _
                    "," & pib_EInchH & "," & pib_EcmL & "," & pib_EcmW & "," & pib_EcmH & "," & _
                  pib_FInchL & "," & pib_FInchW & "," & pib_FInchH & "," & pib_FcmL & "," & pib_FcmW & "," & pib_FcmH & _
                  ",'" & pib_cus1no & "','" & pib_cus2no & "','" & pib_matral & "','" & pib_tiknes & "','" & pib_prtmtd & _
                   "','" & pib_clrfot & "','" & pib_clrbck & "','" & pib_finish & "','" & pib_matDsc & "','" & pib_tikDsc & "','" & pib_prtDsc & "','" & pib_barcde & "','" & _
                   pib_img & "','" & pib_season & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading Save_PKIMBAIF sp_insert_PKIMBAIF :" & rtnStr)
                Save_PKIMBAIF = False
                Exit Function
            End If


            txtPKITMNO.Text = rs.Tables("RESULT").Rows(0).Item("ItemNo")

        Else

            gspStr = "sp_update_PKIMBAIF '" & pib_pgitmno & "','" & pib_cate & "','" & pib_year & "','" & pib_status & "','" & _
                 pib_chndsc & "','" & pib_engdsc & "','" & pib_remark & "'," & pib_EInchL & "," & pib_EInchW & _
                   "," & pib_EInchH & "," & pib_EcmL & "," & pib_EcmW & "," & pib_EcmH & "," & _
                 pib_FInchL & "," & pib_FInchW & "," & pib_FInchH & "," & pib_FcmL & "," & pib_FcmW & "," & pib_FcmH & _
                 ",'" & pib_cus1no & "','" & pib_cus2no & "','" & pib_matral & "','" & pib_tiknes & "','" & pib_prtmtd & _
                  "','" & pib_clrfot & "','" & pib_clrbck & "','" & pib_finish & "','" & pib_matDsc & "','" & pib_tikDsc & "','" & pib_prtDsc & "','" & pib_barcde & "','" & _
                  pib_img & "','" & pib_season & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading Save_PKIMBAIF sp_update_PKIMBAIF :" & rtnStr)
                Save_PKIMBAIF = False
                Exit Function
            End If




        End If

        Save_PKIMBAIF = True




    End Function
    Private Sub cboPricust_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPricust.KeyPress
        fillCus2No(cboPricust.Text)
    End Sub
    Private Sub fillCus2No(ByVal prmcus As String)
        'cboCus1No.Items.Clear()
        'If Add_flag = True Then
        '    Dim drCUBASINF_P() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        '    For i As Integer = 0 To drCUBASINF_P.Length - 1
        '        cboCus1No.Items.Add(drCUBASINF_P(i).Item("cbi_cusno").ToString & " - " & drCUBASINF_P(i).Item("cbi_cussna").ToString)
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_P.Tables("RESULT").Rows.Count - 1
        '        cboCus1No.Items.Add(rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cusno").ToString & " - " & rs_CUBASINF_P.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString)
        '    Next
        'End If


        '======
        cboSecCust.Items.Clear()
        cboSecCust.Text = ""


        Dim count As Integer
        count = CountCharacter(prmcus, " - ")



        Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(count) + "'", "cbi_cussna")
        If drCUBASINF_S.Length > 0 Then
            'rs_CUBASINF_S.MoveFirst()
            cboSecCust.Items.Clear()
            '    cboCus2No.AddItem ""

            'While Not rs_CUBASINF_S.EOF
            For i As Integer = 0 To drCUBASINF_S.Length - 1
                'cboCus2No.Items.Add(Trim(rs_CUBASINF_S("cbi_cus2no")) + " - " + Trim(rs_CUBASINF_S("cbi_cussna")))
                cboSecCust.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString))
                'rs_CUBASINF_S.MoveNext() cbi_cussna cbi_cus2no
            Next

            'End While
        End If
        'rs_CUBASINF_S.Filter = ""
        '=====
        'If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
        '    Dim drCUBASINF_S() As DataRow = rs_CUBASINF_S.Tables("RESULT").Select("cbi_cus1no = '" + Split(prmcus, " - ")(0) + "'")
        '    For i As Integer = 0 To drCUBASINF_S.Length - 1
        '        cboCus2No.Items.Add(Trim(drCUBASINF_S(i).Item("cbi_cus2no").ToString) + " - " + Trim(drCUBASINF_S(i).Item("cbi_cussna").ToString))
        '    Next
        'Else
        '    For i As Integer = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
        '        cboCus2No.Items.Add(Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cus2no").ToString) + " - " + Trim(rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna").ToString))
        '    Next
        'End If
        'rs_CUBASINF_S.Tables("RESULT").DefaultView.RowFilter = ""
    End Sub

    Private Sub cboPricust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPricust.KeyUp
        auto_search_combo(cboPricust, e.KeyCode)
    End Sub

    Private Sub cboPricust_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPricust.Leave


    End Sub

    Private Sub cboSecCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSecCust.KeyUp
        auto_search_combo(cboSecCust, e.KeyCode)
    End Sub


    Private Sub cboSecCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCust.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboCat_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCat.KeyUp
        auto_search_combo(cboCat)
    End Sub

    Private Sub cboCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCat.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboCat_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCat.Validated
        If Trim(cboCat.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboCat, cboCat.Text) = False Then
            MsgBox("Data Invalid")
            cboCat.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboYear_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboYear.KeyUp
        auto_search_combo(cboYear)
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboYear_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboYear.Validated
        If Trim(cboYear.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboYear, cboYear.Text) = False Then
            MsgBox("Data Invalid")
            cboYear.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboStatus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStatus.KeyUp
        auto_search_combo(cboStatus)
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.Validated
        If Trim(cboStatus.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboStatus, cboStatus.Text) = False Then
            MsgBox("Data Invalid")
            cboStatus.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboPricust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPricust.SelectedIndexChanged
        If cboPricust.Text <> "" And Validate() = True Then

            Dim ee As New System.Windows.Forms.KeyPressEventArgs(Chr(13)) 'Enter
            cboPricust_KeyPress(sender, ee)
        End If
        recordstatus = True
    End Sub

    Private Sub cboPricust_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPricust.Validated
        If Trim(cboPricust.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPricust, cboPricust.Text) = False Then
            MsgBox("Data Invalid")
            cboPricust.Text = ""
            cboPricust.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cboSecCust_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSecCust.Validated
        If Trim(cboSecCust.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboSecCust, cboSecCust.Text) = False Then
            MsgBox("Data Invalid")
            cboSecCust.Text = ""
            cboSecCust.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtEISizeL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEISizeL.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        recordstatus = True
        flag_panpack_keypress = True

        'If mode = "UPDATE" Then
        '    Recordstatus = True
        'End If
    End Sub

    Private Sub txtEISizeL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEISizeL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtEISizeL.Text) Then
                innercmL = txtEISizeL.Text * In_CM
                txtECSizeL.Text = innercmL
            End If
        End If

    End Sub

    Private Sub txtEISizeW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEISizeW.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtEISizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEISizeW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtEISizeW.Text) Then
                innercmL = txtEISizeW.Text * In_CM
                txtECSizeW.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtEISizeH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEISizeH.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True

    End Sub

    Private Sub txtEISizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEISizeH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtEISizeH.Text) Then
                innercmL = txtEISizeH.Text * In_CM
                txtECSizeH.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtECSizeL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtECSizeL.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtECSizeL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtECSizeL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtECSizeL.Text) Then
                innerinchL = txtECSizeL.Text * CM_In
                txtEISizeL.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtECSizeW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtECSizeW.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtECSizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtECSizeW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtECSizeW.Text) Then
                innerinchL = txtECSizeW.Text * CM_In
                txtEISizeW.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtECSizeH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtECSizeH.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtECSizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtECSizeH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtECSizeH.Text) Then
                innerinchL = txtECSizeH.Text * CM_In
                txtEISizeH.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtFISizeL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFISizeL.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFISizeL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFISizeL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtFISizeL.Text) Then
                innercmL = txtFISizeL.Text * In_CM
                txtFCSizeL.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtFISizeW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFISizeW.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFISizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFISizeW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtFISizeW.Text) Then
                innercmL = txtFISizeW.Text * In_CM
                txtFCSizeW.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtFISizeH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFISizeH.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFISizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFISizeH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innercmL As Decimal
            If IsNumeric(txtFISizeH.Text) Then
                innercmL = txtFISizeH.Text * In_CM
                txtFCSizeH.Text = innercmL
            End If
        End If
    End Sub

    Private Sub txtFCSizeL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFCSizeL.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFCSizeL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFCSizeL.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtFCSizeL.Text) Then
                innerinchL = txtFCSizeL.Text * CM_In
                txtFISizeL.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtFCSizeW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFCSizeW.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFCSizeW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFCSizeW.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtFCSizeW.Text) Then
                innerinchL = txtFCSizeW.Text * CM_In
                txtFISizeW.Text = innerinchL
            End If
        End If
    End Sub

    Private Sub txtFCSizeH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFCSizeH.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        recordstatus = True
        flag_panpack_keypress = True
    End Sub

    Private Sub txtFCSizeH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFCSizeH.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            Dim innerinchL As Decimal
            If IsNumeric(txtFCSizeH.Text) Then
                innerinchL = txtFCSizeH.Text * CM_In
                txtFISizeH.Text = innerinchL
            End If
        End If
    End Sub









    Private Sub txtMatri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMatri.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtMatri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatri.TextChanged

    End Sub

    Private Sub txtTcknes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTcknes.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtTcknes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTcknes.TextChanged

    End Sub

    Private Sub txtPrtMtd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrtMtd.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtPrtMtd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrtMtd.TextChanged

    End Sub

    Private Sub txtForntCol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtForntCol.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtForntCol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForntCol.TextChanged

    End Sub

    Private Sub txtBackCol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBackCol.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtBackCol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBackCol.TextChanged

    End Sub

    Private Sub txtFinish_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinish1.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtFinish_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinish1.TextChanged

    End Sub

    Private Sub RdoBarA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBarA.CheckedChanged

    End Sub

    Private Sub RdoBarA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoBarA.Click
        recordstatus = True
    End Sub

    Private Sub RdoBarB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBarB.CheckedChanged

    End Sub

    Private Sub RdoBarB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoBarB.Click
        recordstatus = True
    End Sub

    Private Sub RdoBarC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoBarC.CheckedChanged

    End Sub

    Private Sub RdoBarC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdoBarC.Click
        recordstatus = True
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim tmp_itmno As String = txtPKITMNO.Text
        If recordstatus = True Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call cmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    formInit("INIT")
                    txtPKITMNO.Text = tmp_itmno
                    txtPKITMNO.Select()
                    Me.Cursor = Cursors.Default
            End Select
        Else
            formInit("INIT")
            txtPKITMNO.Text = tmp_itmno
            txtPKITMNO.Select()
            Me.Cursor = Cursors.Default
        End If


        recordstatus = False

    End Sub

    Private Sub txtEISizeL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEISizeL.Validating
        If Trim(txtEISizeL.Text) = "" Then
            txtEISizeL.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtEISizeL.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtEISizeW_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEISizeW.Validating
        If Trim(txtEISizeW.Text) = "" Then
            txtEISizeW.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtEISizeW.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtEISizeH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEISizeH.Validating
        If Trim(txtEISizeH.Text) = "" Then
            txtEISizeH.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtEISizeH.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtECSizeL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtECSizeL.Validating
        If Trim(txtECSizeL.Text) = "" Then
            txtECSizeL.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtECSizeL.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtECSizeW_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtECSizeW.Validating
        If Trim(txtECSizeW.Text) = "" Then
            txtECSizeW.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtECSizeW.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtECSizeH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtECSizeH.Validating
        If Trim(txtECSizeH.Text) = "" Then
            txtECSizeH.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtECSizeH.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFISizeL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFISizeL.Validating
        If Trim(txtFISizeL.Text) = "" Then
            txtFISizeL.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFISizeL.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFISizeW_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFISizeW.Validating
        If Trim(txtFISizeW.Text) = "" Then
            txtFISizeW.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFISizeW.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFISizeH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFISizeH.Validating
        If Trim(txtFISizeH.Text) = "" Then
            txtFISizeH.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFISizeH.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFCSizeL_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFCSizeL.Validating
        If Trim(txtFCSizeL.Text) = "" Then
            txtFCSizeL.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFCSizeL.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFCSizeW_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFCSizeW.Validating
        If Trim(txtFCSizeW.Text) = "" Then
            txtFCSizeW.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFCSizeW.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtFCSizeH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFCSizeH.Validating
        If Trim(txtFCSizeH.Text) = "" Then
            txtFCSizeH.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtFCSizeH.Text) = False Then
            MsgBox("Please input integer value")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If recordstatus = True Then
            cmdClear_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub cboMatri_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMatri.KeyUp
        auto_search_combo(cboMatri, e.KeyCode)
    End Sub

    Private Sub cboMatri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMatri.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboTcknes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTcknes.KeyUp
        auto_search_combo(cboTcknes, e.KeyCode)
    End Sub

    Private Sub cboTcknes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTcknes.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboPrtMtd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrtMtd.KeyUp
        auto_search_combo(cboPrtMtd, e.KeyCode)
    End Sub

    Private Sub cboPrtMtd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrtMtd.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboForntCol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboForntCol.KeyUp
        auto_search_combo(cboForntCol, e.KeyCode)
    End Sub

    Private Sub cboForntCol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboForntCol.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboBackCol_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBackCol.KeyUp
        auto_search_combo(cboBackCol, e.KeyCode)
    End Sub

    Private Sub cboBackCol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBackCol.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboFinish_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFinish.KeyUp
        auto_search_combo(cboFinish, e.KeyCode)
    End Sub

    Private Sub cboFinish_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFinish.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboMatri_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboMatri.Validating
        Dim tmpstr As String
        tmpstr = cboMatri.Text

        If cboMatri.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboMatri.Text = ""
        End If
    End Sub

    Private Sub cboTcknes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTcknes.Validating
        Dim tmpstr As String
        tmpstr = cboTcknes.Text

        If cboTcknes.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboTcknes.Text = ""
        End If
    End Sub

    Private Sub cboPrtMtd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrtMtd.Validating
        Dim tmpstr As String
        tmpstr = cboPrtMtd.Text

        If cboPrtMtd.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboPrtMtd.Text = ""
        End If
    End Sub

    Private Sub cboForntCol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboForntCol.Validating
        Dim tmpstr As String
        tmpstr = cboForntCol.Text

        If cboForntCol.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboForntCol.Text = ""
        End If
    End Sub

    Private Sub cboBackCol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboBackCol.Validating
        Dim tmpstr As String
        tmpstr = cboBackCol.Text

        If cboBackCol.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboBackCol.Text = ""
        End If
    End Sub

    Private Sub cboFinish_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboFinish.Validating
        Dim tmpstr As String
        tmpstr = cboFinish.Text

        If cboFinish.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboFinish.Text = ""
        End If
    End Sub

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        browseFileDialog.Title = "Select an image file to upload"
        browseFileDialog.Filter = "JPEG File (*.jpg)|*.jpg"
        browseFileDialog.InitialDirectory = "C:\"
        browseFileDialog.FileName = ""
        browseFileDialog.ShowDialog()
    End Sub

    Private Sub browseFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles browseFileDialog.FileOk
        Dim strm As System.IO.Stream
        Dim filepath_src As String
        Dim filepath_dst As String

        strm = browseFileDialog.OpenFile()
        filepath_src = browseFileDialog.FileName.ToString()
        If MsgBox("Confirm to upload file: " & Environment.NewLine & filepath_src, MsgBoxStyle.YesNo, Me.Name & " - Upload Image Attachment") = MsgBoxResult.Yes Then
            ' Determine destination filename
            filepath_dst = pkg_imgsvr & Trim(Split(cboYear.Text, " - ")(0)) & "\" & Trim(Split(cboCat.Text, " - ")(0)) & "\" & Trim(Replace(UCase(txtPKITMNO.Text), "-", "_")) & ".jpg"

            ' Check destination Directory
            If Directory.Exists(pkg_imgsvr & Trim(Split(cboYear.Text, " - ")(0)) & "\" & Trim(Split(cboCat.Text, " - ")(0)) & "\") = False Then
                Directory.CreateDirectory(pkg_imgsvr & Trim(Split(cboYear.Text, " - ")(0)) & "\" & Trim(Split(cboCat.Text, " - ")(0)) & "\")
            End If

            ' Check for destination file existence
            If File.Exists(filepath_dst) = True Then
                If MsgBox("File already exists. Confirm to overwrite?", MsgBoxStyle.YesNo, Me.Name & " - Upload Image Attachment") = MsgBoxResult.Yes Then
                    Try
                        File.Delete(filepath_dst)
                    Catch ex As Exception
                        MsgBox("Error has occurred during deleting" & Environment.NewLine & filepath_dst & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Name & " - Upload Image Attachment")
                        MsgBox("Upload Terminated", MsgBoxStyle.Information, Me.Name & " - Upload Image Attachment")
                        Exit Sub
                    End Try
                Else
                    MsgBox("Upload Terminated", MsgBoxStyle.Information, Me.Name & " - Upload Image Attachment")
                    Exit Sub
                End If
            End If

            ' Copy file to destination
            Try
                File.Copy(filepath_src, filepath_dst)
            Catch ex As Exception
                MsgBox("Error has occurred during copying" & Environment.NewLine & filepath_src & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Name & " - Upload Image Attachment")
            End Try

            If File.Exists(filepath_dst) = True Then
                rs_PKIMBAIF.Tables("RESULT").Rows(0)("pib_img") = filepath_dst
                recordstatus = True
                pboxImg.Load(filepath_dst)
                pboxImg.SizeMode = PictureBoxSizeMode.Zoom
                pboxImg.Visible = True
                MsgBox("Upload Complete")
            Else
                MsgBox("Upload Not Successful")
            End If
        End If
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtPKITMNO.Name
        frmSYM00018.strModule = "PK"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub cboForntFin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboForntFin.KeyUp
        auto_search_combo(cboForntFin, e.KeyCode)
    End Sub

    Private Sub cboForntFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboForntFin.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboBackFin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBackFin.KeyUp
        auto_search_combo(cboBackFin, e.KeyCode)
    End Sub

    Private Sub cboBackFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBackFin.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboForntFin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboForntFin.Validating
        Dim tmpstr As String
        tmpstr = cboForntFin.Text

        If cboForntFin.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboForntFin.Text = ""
        End If
    End Sub

    Private Sub cboBackFin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboBackFin.Validating
        Dim tmpstr As String
        tmpstr = cboBackFin.Text

        If cboBackFin.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboBackFin.Text = ""
        End If
    End Sub

    Private Sub txtFinish_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinish.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtFinish_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinish.TextChanged

    End Sub

    Private Sub txtMatriDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMatriDesc.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtMatriDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatriDesc.TextChanged

    End Sub

    Private Sub txtTcknesDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTcknesDesc.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtTcknesDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTcknesDesc.TextChanged

    End Sub

    Private Sub txtPrtMtdDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrtMtdDesc.KeyPress
        recordstatus = True
    End Sub

 
    Private Sub chkA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkA.CheckedChanged

    End Sub

    Private Sub chkA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkA.Click
        If chkA.Checked = True Then
            chkB.Checked = False
            chkC.Checked = False
        End If
    End Sub

    Private Sub chkB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkB.CheckedChanged

    End Sub

    Private Sub chkB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkB.Click
        If chkB.Checked = True Then
            chkA.Checked = False
            chkC.Checked = False
        End If
    End Sub

    Private Sub chkC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkC.CheckedChanged

    End Sub

    Private Sub chkC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkC.Click
        If chkC.Checked = True Then
            chkA.Checked = False
            chkB.Checked = False
        End If
    End Sub

    Private Sub txtEngDesc_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEngDesc.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtEngDesc_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngDesc.TextChanged

    End Sub

    Private Sub txtChinDesc_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChinDesc.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtChinDesc_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChinDesc.TextChanged

    End Sub

    Private Sub txtRemark_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemark.KeyPress
        recordstatus = True
    End Sub

    Private Sub txtRemark_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemark.TextChanged

    End Sub

    Private Sub pboxImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxImg.Click

    End Sub

    Private Sub pboxImg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pboxImg.DoubleClick
        If pboxImg.Image Is Nothing Then
            Exit Sub
        End If

        If File.Exists(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_img")) = True Then
            Try
                frmImage.pbImage.Load(rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_img"))
            Catch ex As Exception

            End Try

            frmImage.ShowDialog()
        End If

       
    End Sub

    Private Sub cboSeason_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSeason.KeyUp
        auto_search_combo(cboSeason, e.KeyCode)
    End Sub

    Private Sub cboSeason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSeason.SelectedIndexChanged
        recordstatus = True
    End Sub

    Private Sub cboSeason_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSeason.Validated
        Dim tmpstr As String
        tmpstr = cboSeason.Text

        If cboSeason.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboSeason.Text = ""
        End If
    End Sub
End Class