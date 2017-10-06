Public Class MSR00007

    '*** Program ID     :MSR00007
    '*** Author         :Louis Siu
    '*** Creation Date  :Apr 03 , 2002
    '*** Description    :Outstanding Carton Report

    ' *** Modification History
    ' *** Modified by           :Lester Wu
    ' *** Modified on           :Feb 13 , 2004
    ' *** Description           :ADD "ALL" COMPANY SELECTION

    '***************************************************************************************************************************************
    '*** Modification History
    '***************************************************************************************************************************************
    '*** Modified by        Modified on         Description:
    '***************************************************************************************************************************************
    '*** Lester Wu          Feb 13 , 2004       ADD "ALL" COMPANY SELECTION
    '*** Lester Wu          31st Mar, 2005      Replace ALL with UC-G, not show UC-G for MS Company's users
    '***************************************************************************************************************************************



    Public rs_MSR00007 As New DataSet
    Public rs_CUBASINF As Dataset
    Public rs_CUBASINFSec As Dataset
    Public rs_VNBASINF As Dataset
    Public rs_SYLNEINF As Dataset
    Dim Rpt_MSR00007 As MSR00007Rpt


    Dim objBSGate As Object    '*** an object of "ucpBS_Gate.clsBSGate"



    Private Sub cboCoCde_Click()
        '*** Multi-Company Name Display.
        'txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        'XXXXXXXXXXXXXXXXXXXXX
        ' 2004/02/11 Lester Wu
        'Lester Wu 2005-03-31
        'If Me.cboCoCde.Text <> "ALL" Then
        If Me.cboCoCde.Text <> "UC-G" Then
            txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Else
            Me.txtCoNam.Text = "UNITED CHINESE GROUP"
        End If
        'XXXXXXXXXXXXXXXXXXXXX
    End Sub

    Private Sub cmdShow_Click()
        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '------------------------------------------




        '-- Validation ===================================

        If cboPriCustFm.Text <> "" And cboPriCustTo.Text <> "" Then
            If Split(cboPriCustFm.Text, " - ")(0) > Split(cboPriCustTo.Text, " - ")(0) Then
                MsgBox("Primary Customer No: To < From!")
                cboPriCustFm.Focus()
                Exit Sub
            End If
        End If


        If cboSecCustFm.Text <> "" And cboSecCustTo.Text <> "" Then
            If Split(cboSecCustFm.Text, " - ")(0) > Split(cboSecCustTo.Text, " - ")(0) Then
                MsgBox("Secondary Customer No: To < From!")
                cboSecCustFm.Focus()
                Exit Sub
            End If
        End If

        If cboPLFm.Text > cboPLTo.Text Then
            MsgBox("Product Line: To < From!")
            cboPLFm.Focus()
            Exit Sub
        End If

        If txtItemFm.Text > txtItemTo.Text Then
            MsgBox("Item No: To < From!")
            txtItemFm.Focus()
            Exit Sub
        End If


        If txtCustItemFm.Text > txtCustItemTo.Text Then
            MsgBox("Customer Item No: To < From!")
            txtCustItemFm.Focus()
            Exit Sub
        End If


        If cboVenNoFm.Text <> "" And cboVenNoTo.Text <> "" Then
            If Split(cboVenNoFm.Text, " - ")(0) > Split(cboVenNoTo.Text, " - ")(0) Then
                MsgBox("Vendor No: To < From!")
                cboVenNoFm.Focus()
                Exit Sub
            End If
        End If



        ' Issue Date Validation -------------------------------
        If Mid(txtIssdatFm.Text, 7) > Mid(txtIssdatTo.Text, 7) Then
            MsgBox("Issue Date: End Date < Start date ! (YY)")
            txtIssdatFm.Focus()
            Exit Sub
        ElseIf Mid(txtIssdatFm.Text, 7) = Mid(txtIssdatTo.Text, 7) Then
            If Microsoft.VisualBasic.Left(txtIssdatFm.Text, 2) > Microsoft.VisualBasic.Left(txtIssdatTo.Text, 2) Then
                MsgBox("Issue Date: End Date < Start date ! (MM)")
                txtIssdatFm.Focus()
                Exit Sub
            ElseIf Microsoft.VisualBasic.Left(txtIssdatFm.Text, 2) = Microsoft.VisualBasic.Left(txtIssdatTo.Text, 2) Then
                If Mid(txtIssdatFm.Text, 4, 2) > Mid(txtIssdatTo.Text, 4, 2) Then
                    MsgBox("Issue Date: End Date < Start date ! (DD)")
                    txtIssdatFm.Focus()
                    Exit Sub
                End If
            End If
        End If



        If txtIssdatFm.Text <> "  /  /" Then
            If isDate(txtIssdatFm.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txtIssdatFm.Focus()
                Exit Sub
            End If
        End If

        If txtIssdatTo.Text <> "  /  /" Then
            If isDate(txtIssdatTo.Text) = False Then
                MsgBox("Invalid Enter in Issue Date!")
                txtIssdatTo.Focus()
                Exit Sub
            End If
        End If

        '===============================================================



        ' Primary Customer --------------------------
        Dim PCF As String
        Dim pct As String
        If cboPriCustFm.Text = "" Then
            PCF = ""
        Else
            PCF = Split(cboPriCustFm.Text, " - ")(0)
        End If

        If cboPriCustTo.Text = "" Then
            pct = ""
        Else
            pct = Split(cboPriCustTo.Text, " - ")(0)
        End If

        'Secondary Customer --------------------------------
        Dim SCF As String
        Dim SCT As String
        If cboSecCustFm.Text = "" Then
            SCF = ""
        Else
            SCF = Split(cboSecCustFm.Text, " - ")(0)
        End If

        If cboSecCustTo.Text = "" Then
            SCT = ""
        Else
            SCT = Split(cboSecCustTo.Text, " - ")(0)
        End If

        'Vendor No -----------------------------------------
        Dim VNF As String
        Dim VNT As String
        If cboVenNoFm.Text = "" Then
            VNF = ""
        Else
            VNF = Split(cboVenNoFm.Text, " - ")(0)
        End If

        If cboVenNoTo.Text = "" Then
            VNT = ""
        Else
            VNT = Split(cboVenNoTo.Text, " - ")(0)
        End If


        ' Set Issue Date----------------------------------------
        Dim IDF As String
        Dim IDT As String

        If txtIssdatFm.Text = "  /  /" Then
            IDF = ""
        Else
            IDF = txtIssdatFm.Text + " 00:00:00.000"
        End If

        If txtIssdatTo.Text = "  /  /" Then
            IDT = ""
        Else
            IDT = txtIssdatTo.Text + " 23:59:59.000"
        End If



        ' Print Unit Price or not----------------------------
        Dim FI As String
        If optYes.Checked = True Then
            FI = "Y"
        Else
            FI = "N"
        End If


        ' Getting Selection --------------------------------
        Dim GS As String
        If cboGS.Text = "Quotation" Then
            GS = "Q"
        End If

        If cboGS.Text = "Sales Confirmation" Then
            GS = "S"
        End If

        If cboGS.Text = "Both" Then
            GS = "B"
        End If


        ' Sort by -------------------------------------------
        Dim SB As String
        If cboSortBy.Text = "Item No" Then
            SB = "I"
        Else
            SB = "C"
        End If



        '--------------------------------------------------------------------------------------------------------------

        Dim S As String
        Dim rs As DataSet

        S = "sp_select_MSR00007 '" & cboCocde.Text.Trim() & "' ,'" & PCF & "','" & pct & _
            "','" & SCF & "','" & SCT & _
            "','" & cboPLFm.Text.Trim & "','" & cboPLTo.Text.Trim & _
            "','" & txtItemFm.Text.Trim & "','" & txtItemTo.Text.Trim & _
            "','" & txtCustItemFm.Text.Trim & "','" & txtCustItemTo.Text.Trim & _
            "','" & VNF & "','" & VNT & _
            "','" & IDF & "','" & IDT & _
            "','" & FI & "','" & GS & _
            "','" & SB & "','" & gsUsrID & "'"


        '                S = "sp_select_MSR00007_CUSALI','S','" & PCF & "','" & PCT & _
        '                    "','" & SCF & "','" & SCT & _
        '                    "','" & cboPLFm & "','" & cboPLTo & _
        '                    "','" & txtItemFm & "','" & txtItemTo & _
        '                    "','" & txtCustItemFm & "','" & txtCustItemTo & _
        '                    "','" & VNF & "','" & VNT & _
        '                    "','" & IDF & "','" & IDT & _
        '                    "','" & FI & "','" & GS & _
        '                    "','" & SB & "','" & gsUsrID & "'"

        Cursor = Cursors.WaitCursor

        gspStr = S
        rtnLong = execute_SQLStatementRPT(gspStr, rs_MSR00007, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        End If

        Cursor = Cursors.Default


        If rs_MSR00007.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            MsgBox("No record found !")
            Exit Sub
        Else

            Dim objRpt As New MSR00007Rpt
            objRpt.SetDataSource(rs_MSR00007.Tables("RESULT"))

            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()


            '---------------------------------------------------------

            'Rpt_MSR00007 = New MSR00007Rpt
            'Rpt_MSR00007.Database.SetDataSource(rs_MSR00007)
            'Rpt_MSR00007.OpenSubreport.Tables("RESULT").Rows(index)("aaa.rpt").Database.SetDataSource(rs_MSR00007)
            'frmCR.Report = Rpt_MSR00007
            'frmCR.Show()


        End If


        Cursor = Cursors.Default

    End Sub



    Private Sub fmeInputCriteria_DragDrop(ByVal Source As Control, ByVal X As Single, ByVal Y As Single)

    End Sub

    Private Sub Form_Load()

        'MSR00007.Width = 11160
        'MSR00007.Height = 7965


        cboSortBy.Items.Add("Customer Item No")
        cboSortBy.Items.Add("Item No")
        cboSortBy.SelectedIndex = 0


        cboGS.Items.Add("Quotation")
        cboGS.Items.Add("Sales Confirmation")
        cboGS.Items.Add("Both")
        cboGS.SelectedIndex = 0

        '*** Multi-Company Name Display.
        Call FillCompCombo(gsUsrID, cboCocde)
        '*** ADD PRINT ALL COMPANY ***
        ' 2004/02/11
        'Lester Wu 2005-03-31, replace ALL with UC-G, not show UC-G for MS Company's users
        If gsDefaultCompany <> "MS" Then
            'Me.cboCoCde.Items.add "ALL"
            Me.cboCocde.Items.Add("UC-G")
        End If
        '*****************************
        Call GetDefaultCompany(Me.cboCocde, Me.txtCoNam)



        Call Formstartup(Me.Name)
        '#If useMTS Then
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        'objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If





        '-- Retrieving Customer ,Ventor and SubCode data ----------

        Dim S As String
        Dim rs As DataSet

        Cursor = Cursors.WaitCursor

        S = "sp_list_CUBASINF '','PA' "

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboCust()
        End If


        S = "sp_list_CUBASINF   '','P'"

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINFSec, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboCustSec()
        End If



        S = "sp_list_VNBASINF  '' "

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboVen()
        End If


        S = "sp_list_SYLNEINF  ''  "

        gspStr = S
        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp  :" & rtnStr)
        Else
            Call FillcboLneinf()
        End If



        Cursor = Cursors.Default


    End Sub

    Private Sub FillcboCust()
        If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_CUBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboPriCustFm.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                    cboPriCustTo.Items.Add(rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINF.Tables("RESULT").Rows(index)("cbi_cussna"))
                Next
            End With
        End If
    End Sub

    Private Sub FillcboCustSec()
        If rs_CUBASINFSec.Tables("RESULT").Rows.Count > 0 Then
            With rs_CUBASINFSec
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboSecCustFm.Items.Add(rs_CUBASINFSec.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINFSec.Tables("RESULT").Rows(index)("cbi_cussna"))
                    cboSecCustTo.Items.Add(rs_CUBASINFSec.Tables("RESULT").Rows(index)("cbi_cusno") & " - " & rs_CUBASINFSec.Tables("RESULT").Rows(index)("cbi_cussna"))
                Next
            End With
        End If
    End Sub


    Private Sub FillcboVen()
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then

            With rs_VNBASINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboVenNoFm.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                    cboVenNoTo.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(index)("vbi_vensna"))
                Next
            End With

        End If
    End Sub

    Private Sub FillcboLneinf()
        If rs_SYLNEINF.Tables("RESULT").Rows.Count > 0 Then
            With rs_SYLNEINF
                For index As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    cboPLFm.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(index)("yli_lnecde"))
                    cboPLTo.Items.Add(rs_SYLNEINF.Tables("RESULT").Rows(index)("yli_lnecde"))
                Next
            End With

        End If
    End Sub


    'Change & Click Effect -------------------------------

    Private Sub cboPriCustFm_Click()
        cboPriCustTo.Text = cboPriCustFm.Text
    End Sub


    Private Sub cboSecCustFm_Click()
        cboSecCustTo.Text = cboSecCustFm.Text
    End Sub


    Private Sub cboPLFm_Click()
        cboPLTo.Text = cboPLFm.Text
    End Sub


    Private Sub txtCustItemFm_Change()
        txtCustItemTo.Text = txtCustItemFm.Text
    End Sub

    Private Sub txtItemFm_Change()
        txtItemTo.Text = txtItemFm.Text
    End Sub

    Private Sub cboVenNoFm_Click()
        cboVenNoTo.Text = cboVenNoFm.Text
    End Sub


    Private Sub txtIssdatFm_Change()
        txtIssdatTo.Text = txtIssdatFm.Text
    End Sub


    'GotFocus-------------------------------


    Private Sub txtItemFm_GotFocus()
        Call HighlightText(txtItemFm)
    End Sub

    Private Sub txtItemTo_GotFocus()
        Call HighlightText(txtItemTo)
    End Sub

    Private Sub txtIssdatFm_GotFocus()
        Call HighlightMask(txtIssdatFm)
    End Sub

    Private Sub txtIssdatTo_GotFocus()
        Call HighlightMask(txtIssdatTo)
    End Sub

    'AutoSearching------------------------------

    Private Sub cboPriCustFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboPriCustFm, KeyCode)
    End Sub

    Private Sub cboPriCustTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboPriCustTo, KeyCode)
    End Sub

    Private Sub cboSecCustFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSecCustFm, KeyCode)
    End Sub

    Private Sub cboSecCustTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboSecCustTo, KeyCode)
    End Sub

    Private Sub cboPLFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboPLFm, KeyCode)
    End Sub

    Private Sub cboPLTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboPLTo, KeyCode)
    End Sub

    Private Sub cboVenNoFm_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenNoFm, KeyCode)
    End Sub

    Private Sub cboVenNoTo_KeyUp(ByVal KeyCode As Integer, ByVal Shift As Integer)
        'Call AutoSearch(cboVenNoTo, KeyCode)
    End Sub













    Private Sub MSR00007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Form_Load()

    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShow_Click()

    End Sub

    Private Sub cboPriCustFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCustFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboPriCustFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCustFm.SelectedIndexChanged
        cboPriCustTo.Text = cboPriCustFm.Text

    End Sub

    Private Sub cboSecCustFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSecCustFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSecCustFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCustFm.SelectedIndexChanged
        cboSecCustTo.Text = cboSecCustFm.Text


    End Sub

    Private Sub cboPLFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboPLTo.Text = cboPLFm.Text

    End Sub

    Private Sub txtCustItemFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustItemFm.TextChanged
        txtCustItemTo.Text = txtCustItemFm.Text

    End Sub

    Private Sub txtItemFm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemFm.TextChanged
        txtItemTo.Text = txtItemFm.Text

    End Sub

    Private Sub cboVenNoFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenNoFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenNoFm.SelectedIndexChanged
        cboVenNoTo.Text = cboVenNoFm.Text

    End Sub

    Private Sub txtIssdatFm_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtIssdatFm.MaskInputRejected
        txtIssdatTo.Text = txtIssdatFm.Text

    End Sub

    Private Sub cboPriCustTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCustTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboPriCustTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCustTo.SelectedIndexChanged

    End Sub

    Private Sub cboSecCustTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSecCustTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboSecCustTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecCustTo.SelectedIndexChanged

    End Sub

    Private Sub cboPLFm_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPLFm.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboPLFm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLFm.SelectedIndexChanged

    End Sub

    Private Sub cboPLTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPLTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboPLTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPLTo.SelectedIndexChanged

    End Sub

    Private Sub cboVenNoTo_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenNoTo.KeyUp

        If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Tab Then
            Call auto_search_combo(sender)
        End If

    End Sub

    Private Sub cboVenNoTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenNoTo.SelectedIndexChanged

    End Sub
End Class
