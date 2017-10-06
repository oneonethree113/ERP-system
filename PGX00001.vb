Imports Microsoft.Office.Interop
Imports System.IO

Public Class PGX00001
    Inherits System.Windows.Forms.Form
    Dim msg As String = ""
    Dim msg2 As String = ""
    Dim msg3 As String = ""

    Dim txtPkgItem_Text As String
    Dim txtCate_Text As String
    Dim txtPkgChDesc_Text As String
    Dim txtPkgEnDesc_Text As String
    Dim txtPkgRemark_Text As String

    Dim txtEISizeH_Text As String
    Dim txtEISizeW_Text As String
    Dim txtEISizeL_Text As String

    Dim txtECSizeH_Text As String
    Dim txtECSizeW_Text As String
    Dim txtECSizeL_Text As String

    Dim txtFISizeH_Text As String
    Dim txtFISizeL_Text As String
    Dim txtFISizeW_Text As String

    Dim txtFCSizeH_Text As String
    Dim txtFCSizeL_Text As String
    Dim txtFCSizeW_Text As String

    Dim txtMatri_Text As String
    Dim txtTcknes_Text As String
    Dim txtPrtMtd_Text As String
    Dim txtForntCol_Text As String
    Dim txtBackCol_Text As String
    Dim txtFinish_Text As String

    Dim txtMatDsc_Text As String
    Dim txtTckDsc_Text As String
    Dim txtPrtDsc_Text As String

    '    Dim txtPkgItem_Text As String

    Dim txtPkgOrdQty_Text As String
    Dim txtPkgUnitPri_Text As String
    Dim txtPkgTtlQty_Text As String
    Dim txtTtlAmt_Text As String
    Dim txtQuotePrice_Text As String

    Dim txtPkgAddress_Text As String
    Dim txtPkgState_Text As String
    Dim txtPkgCtry_Text As String
    Dim txtZip_Text As String

    Dim txtPkgUnitPriCur_Text As String
    Dim txtTtlAmtCur_Text As String
    Dim txtQuoteCur_Text As String

    Dim cboPkgCtnPer_text As String
    Dim txtTel_Text As String

    Dim rs_VNCTNPER_09 As DataSet

    Dim rs_EXCEL As DataSet
    Dim myExcel As Excel.Application
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""
    Dim numError As Integer

    Dim rs_check As New DataSet
    Dim rs_data As New DataSet
    Dim rs_check_hdr As New DataSet
    Dim rs_approve As New DataSet




    Dim rs_TOSCHEADER As New DataSet
    Dim rs_LIST_RESULT As New DataSet
    Dim rs_LIST_RESULT_group As New DataSet
    Dim rs_LIST_RESULT_check_dup As New DataSet
    Dim rs_LIST_RESULT_check_dup_add As New DataSet

    Dim rs_LIST_RESULT_scto As New DataSet
    Dim rs_LIST_RESULT_copy As New DataSet

    Dim rs_syswasge As New DataSet

    Dim rs_TOSCDETAIL As New DataSet
    Dim rs_VNBASINF As New DataSet
    Dim rs_PKIMBAIF As New DataSet
    Dim rs_VNBASINF_02 As New DataSet
    Dim rs_LIST_RESULT_cusno As New DataSet
    Dim rs_PKESHDR As New DataSet
    Dim rs_PKREQDTL As New DataSet

    Dim rsM As New DataSet
    Dim tmp_cu As New DataSet

    Dim rs_QUXLSDTL As New DataSet '  


    Dim rs_QUOTNDTL_TO As New DataSet '  
    Dim rs_TOORDHDR As New DataSet '  
    Dim rs_TOORDDTL As New DataSet '  
    Dim rs_SAREQDTL As New DataSet '  
    Dim rs_QUASSINF_TO_tmp As New DataSet '  
    Dim rs_QUOTNDTL_TO_tmp As New DataSet '  
    Dim rs_insert_SAREQHDR As New DataSet '  
    Dim rs_insert_SAREQDTL2 As New DataSet '  
    Dim currentDtlVerno As Integer
    Dim current_row As Integer
    Dim flag_to_released As Boolean
    Dim flag_ftyprc_diff(1) As Boolean
    Dim flag_no_TO_item_to_gen As Boolean



    Dim rs_IMBASINF As New DataSet ' for Item Basic
    Dim rs_IMCOLINF As New DataSet  ' for Item Color
    Dim rs_IMPRCINF As New DataSet  ' for Item Pricing
    Dim rs_IMPRCINF_NewAddItem As New DataSet
    Dim rs_IMPCKINF As New DataSet ' for Item Packing
    Dim rs_IMMATBKD As New DataSet  ' for Component Breakdown
    Dim rs_IMBOMASS As New DataSet  ' for Assorted Item
    Dim rs_IMVENINF As New DataSet  ' for Vendor Item (IMVENINF, IMPRCINF, VNBASINF)
    Dim rs_IMVENINF_tbc As New DataSet  ' for Vendor Item (IMVENINF, IMPRCINF, VNBASINF)

    Public rs_QUOTNHDR As New DataSet ' for retrieve Quotation Header information

    Dim rs_CUGRPINF As New DataSet ' for Customer Group Information
    Dim rs_CUBASINF_P As New DataSet ' for Secondary Customer of Primary Customer
    Dim rs_CUBASINF_CP As New DataSet ' for Contact person of the Customer
    Dim rs_CUBASINF_A As New DataSet ' for Agent of Primary Customer

    Dim rs_QUPRCEMT_CU As New DataSet
    Public rs_QUCPTBKD As New DataSet ' for Component Breakdown i


    Dim colApv As Long
    Public uploadBatch As Date

    Dim FileToCopy As String
    Dim tmp_date As String
    Dim Alias_itm As Boolean
    Dim dr() As DataRow
    Public rs_SYHRMCDE As New DataSet ' for HSTU/Tariff #
    Dim rs_IMXCHK As New DataSet ' for multi Company item Check
    Public rs_QUOTNDTL As New DataSet ' for retrieve Quotation Details information
    Public rs_IMBASINF_A As New DataSet
    Public rs_QUASSINF As New DataSet ' for Assortment Item information
    Public rs_SYSALREL As New DataSet

    Dim drNewRow As DataRow

    Private Const cModeAdd As String = "New"
    Private Const cModeUpd As String = "Update"

    Dim txt_itmno As String

    Public rs_CUCNTINF_C As New DataSet
    Public rs_CUBASINF_S As New DataSet

    Public rs_SYTIESTR As New DataSet
    Public rs_SYCONFTR As New DataSet

    Public rs_CUBASINF_CR As New DataSet ' for Currency Rate
    Dim rs_IMTMPREL As New DataSet
    Public rs_SYUSRRIGHT_Check As New DataSet

    Public rs_PKESDTL As New DataSet
    Public rs_PKESHDR_construct As New DataSet

    Private Const sMODULE As String = "QU"

    Dim txt_CusAgt_Text As String
    Dim txt_SalDiv_Text As String
    Dim txt_SalRep_Text As String
    Dim txt_Srname_Text As String
    Dim txt_SmpPrd_Text As String
    Dim txt_SmpFgt_Text As String
    Dim txtCurCde1 As String
    Dim quh_cugrptyp_int As String
    Dim quh_cugrptyp_ext As String

    Dim txt_PrcTrm_Text As String
    Dim txt_PayTrm_Text As String

    Dim txt_Cus1Ad_Text As String
    Dim txt_Cus1St_Text As String
    Dim txt_Cus1Cy_Text As String
    Dim txt_Cus1Zp_Text As String

    Dim txt_Cus1Cp_Text As String

    Dim txt_Cus1CgInt_Text As String
    Dim txt_Cus1CgExt_Text As String

    Dim txtCusItm_Text As String

    Public ORI_MOFLAG As String ' Define Variable to Store Original/Modified MOQ/MOA Flag
    Public ORI_MOA As String ' Define Variable to Store Original MOQ/MOA
    Public ORI_MOQ As String ' Define Variable to Store Original MOQ/MOA

    Dim org_MOFLAG_tmp As String
    Dim org_MOQ_tmp As String
    Dim org_MOA_tmp As String

    Dim org_IM_MOQ_tmp As String
    Dim org_IM_MOA_tmp As String
    Dim pth As String
    Public rs_CUBASINF_rounding As New DataSet
    Public cus1_rounding As Integer
    Public gs_messaeg As String
    Dim pkgtype As String
    Dim txtScNo_Text As String
    Dim cboCoCde_Text As String
    Dim cboPriCust_Text As String
    Dim cboSecCust_Text As String
    Dim txtSalesDiv_Text As String
    Dim cboSalesRep_Text As String
    Dim txtScVer_Text As String
    Dim txtScIssDat_Text As String

    Dim txtScRevDate_Text As String
    Dim txtCustPoDate_Text As String
    Dim txtScCancelDate_Text As String
    Dim txtScShipDateStr_Text As String
    Dim txtScShipDateEnd_Text As String
    Dim txtScRemark_Text As String
    Dim txtHeadScNo_Text As String
    Dim txtToNo_Text As String

    Dim txtToVer_Text As String
    Dim txtToIssDate_Text As String
    Dim txtToRevDate_Text As String
    Dim txtRefQuot_Text As String

    Dim cboToStatus_Text As String
    Dim txtReqno_Text As String


    Private Sub display_grdItem()
        'type
        'A - All
        'F - Functional
        'P - Pricing
        'T - Sample and TO
        'S - Summary

        If rs_LIST_RESULT.Tables.Count = 0 Then
            Exit Sub
        End If

        'grdItem.RowHeadersWidth = 18
        'grdItem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdItem.ColumnHeadersHeight = 18
        'grdItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'grdItem.AllowUserToResizeColumns = True
        'grdItem.AllowUserToResizeRows = False
        'grdItem.RowTemplate.Height = 18
        'grdItem.ReadOnly = False
        'grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView
        Dim i As Integer
        '        grdItem.Columns(grdItem_Del).Frozen = False

        For i = 0 To grdItem.ColumnCount - 1
            grdItem.Columns(i).ReadOnly = False
            grdItem.Columns(i).Visible = True
        Next


        i = 0 '0
        grdItem.Columns(i).HeaderText = "GENE"
        grdItem.Columns(i).Width = 40
        i = i + 1 '1
        grdItem.Columns(i).HeaderText = "Excel Row #"
        grdItem.Columns(i).Width = 40
        i = i + 1 '1
        grdItem.Columns(i).HeaderText = "Act Flag"
        grdItem.Columns(i).Width = 30
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "Hdr Act"
        grdItem.Columns(i).Width = 40
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "Dtl Act"
        grdItem.Columns(i).Width = 40
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "EST Hdr Act"
        grdItem.Columns(i).Width = 40
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "EST Dtl Act"
        grdItem.Columns(i).Width = 40
        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "Req#"
        grdItem.Columns(i).Width = 90
        i = i + 1 '3
        grdItem.Columns(i).HeaderText = "Seq"
        grdItem.Columns(i).Width = 40

        i = i + 1 '2
        grdItem.Columns(i).HeaderText = "Valid"
        grdItem.Columns(i).Width = 40
        i = i + 1 '3
        grdItem.Columns(i).HeaderText = "Case"
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False
        i = i + 1 '3'cocde
        grdItem.Columns(i).HeaderText = "Reason"
        grdItem.Columns(i).Width = 60
        i = i + 1 '3
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False 'cocde
        i = i + 1 '4
        grdItem.Columns(i).HeaderText = "Packing Item"
        grdItem.Columns(i).Width = 100
        i = i + 1 '4
        grdItem.Columns(i).HeaderText = "Category"
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False


        i = i + 1 '5
        grdItem.Columns(i).HeaderText = "Vendor "   ' "Item Desc."
        grdItem.Columns(i).Width = 60


        i = i + 1 '6
        grdItem.Columns(i).HeaderText = "SC No."
        grdItem.Columns(i).Width = 90
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightPink
        i = i + 1 '7
        grdItem.Columns(i).HeaderText = "To No."
        grdItem.Columns(i).Width = 80
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '8
        grdItem.Columns(i).HeaderText = "Primary Customer"
        grdItem.Columns(i).Width = 60
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '9
        grdItem.Columns(i).HeaderText = "Secondary Customer"
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '10
        grdItem.Columns(i).HeaderText = "Item Number"
        grdItem.Columns(i).Width = 140
        i = i + 1 '11
        grdItem.Columns(i).HeaderText = "Ass Item No."
        grdItem.Columns(i).Width = 130
        i = i + 1 '12
        grdItem.Columns(i).HeaderText = "Cus Item No."
        grdItem.Columns(i).Width = 90

        i = i + 1 '13
        grdItem.Columns(i).HeaderText = "Cus SKU"
        grdItem.Columns(i).Width = 90

        i = i + 1 '15
        grdItem.Columns(i).HeaderText = "UM"
        grdItem.Columns(i).Width = 50
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightPink
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '17
        grdItem.Columns(i).HeaderText = "Inner Quantity"
        grdItem.Columns(i).Width = 50
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '18
        grdItem.Columns(i).HeaderText = "Master Quantity"
        grdItem.Columns(i).Width = 50
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGreen
        i = i + 1 '16
        grdItem.Columns(i).HeaderText = "CFT"
        grdItem.Columns(i).Width = 50
        i = i + 1 '20
        grdItem.Columns(i).HeaderText = "FTY Price Term"
        grdItem.Columns(i).Width = 70
        i = i + 1 '19
        grdItem.Columns(i).HeaderText = "HK Price Term"
        grdItem.Columns(i).Width = 70
        i = i + 1 '21
        grdItem.Columns(i).HeaderText = "Trans Term"
        grdItem.Columns(i).Width = 50

        i = i + 1 '22
        grdItem.Columns(i).HeaderText = "Color Code"
        grdItem.Columns(i).Width = 110
        i = i + 1 '23
        grdItem.Columns(i).HeaderText = "Cus PO"
        grdItem.Columns(i).Width = 90
        i = i + 1 '24
        grdItem.Columns(i).HeaderText = "Sc Order Qty"
        grdItem.Columns(i).Width = 70
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Conftr"
        grdItem.Columns(i).Width = 40
        'grdItem.Columns(i).CellTemplate.Style.BackColor = Color.LightGray
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Order Qty"
        grdItem.Columns(i).Width = 70
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Temp Item# "
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = ""
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False
        i = i + 1 '256
        grdItem.Columns(i).HeaderText = ""
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Waste"
        grdItem.Columns(i).Width = 54
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Ttl Order Qty"
        grdItem.Columns(i).Width = 70
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Cur"
        grdItem.Columns(i).Width = 40
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Unit Price"
        grdItem.Columns(i).Width = 65
        i = i + 1 '256
        grdItem.Columns(i).HeaderText = ""
        grdItem.Columns(i).Width = 0
        grdItem.Columns(i).Visible = False

        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Cur of EST"
        grdItem.Columns(i).Width = 45
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Est Per Unit"
        grdItem.Columns(i).Width = 75
        i = i + 1 '25
        grdItem.Columns(i).HeaderText = "Est Per Item"
        grdItem.Columns(i).Width = 75
        i = i + 1 '4
        grdItem.Columns(i).HeaderText = "File Name"
        grdItem.Columns(i).Width = 200
        i = i + 1 '5
        grdItem.Columns(i).HeaderText = "Upload Date"
        grdItem.Columns(i).Width = 160

        i = i + 1 '5
        grdItem.Columns(i).HeaderText = ""
        grdItem.Columns(i).Width = 20

        i = i + 1
        For j As Integer = i To grdItem.Columns.Count - 1
            grdItem.Columns(j).HeaderText = ""
            grdItem.Columns(j).Width = 0
            grdItem.Columns(j).Visible = False
        Next

    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        If (dirSource.SelectedNode Is Nothing) Then
            MsgBox("Directory Not Selected")
            Exit Sub
        End If
        '*** Refresh the source
        filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(filSourcePath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        filSource.Refresh()
    End Sub
    Private Sub PGXLS001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        drvSource.Items.AddRange(System.IO.Directory.GetLogicalDrives)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()

        drvSource.Items.Clear()

        Dim sDrive As String

        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        Dim i As Integer

        For Each sDrive In drvSource.Items
            If sDrive.ToString.ToUpper.Equals("C:\") Then
                drvSource.SelectedIndex = i
            End If
            i += 1
        Next

        If drvSource.SelectedIndex = -1 Then
            Try
                drvSource.SelectedIndex = 1
            Catch
                MessageBox.Show("No fixed disks found!", "Drive Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        dirSource.Nodes(0).Expand()
        dirSource.SelectedNode = dirSource.Nodes(0)

        txtProcess.Text = ""
        txtProcess.Refresh()


        btcPGXLS001.SelectedIndex = 0
        btcPGXLS001.TabPages(0).Enabled = True
        btcPGXLS001.TabPages(1).Enabled = False
        btcPGXLS001.TabPages(2).Enabled = False



        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btcPGXLS001_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcPGXLS001.SelectedIndexChanged
        If btcPGXLS001.SelectedIndex = 1 Then
            optStatusG.Checked = True
        End If
    End Sub

    Private Sub drvSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.SelectedIndexChanged
        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub AddDirectories(ByVal Node As TreeNode)
        Try
            'Construct a DirectoryInfo object of Node.FullPath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)

            'Construct a DirectoryInfo object array of all the folders inside Node.FullPath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
        Catch
            'This error trap prevents a crash when attempting to access restricted folders.
        End Try
    End Sub

    Private Sub dirSource_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles dirSource.BeforeExpand
        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirSource.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirSource.EndUpdate()
        End If

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        On Error GoTo FILE_ACCESS_ERROR

        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        filSourcePath = Dir.FullName

        drvSource.Text = filSourcePath


        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        cmdGen.Enabled = True

        gspStr = "sp_list_pkwasge_02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_syswasge, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Cursors.Default
            MsgBox("Error on loading PGXLS001_Load sp_list_pkwasge :" & rtnStr)
            Exit Sub
        End If


        If read_from_excel() = False Then
            Exit Sub
        End If

        Call map_all_items()

        btcPGXLS001.SelectedIndex = 1
        btcPGXLS001.TabPages(0).Enabled = False
        btcPGXLS001.TabPages(1).Enabled = True
        btcPGXLS001.TabPages(2).Enabled = False


    End Sub

    Private Sub filSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filSource.SelectedIndexChanged
        Dim file_to_upload As String
        'file_to_upload = filSourcePath + filSource.Text
        drvSource.Text = filSourcePath

    End Sub

    Private Sub dirSource_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles dirSource.AfterSelect

    End Sub


    Private Sub cboCoCde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        Call cboCoCdeClick()
    End Sub

    Private Sub cboCoCdeClick()
        txtCoNam.Text = ChangeCompany(cboCoCde_Text, Me.Name)
        'Call getDefault_Path()

    End Sub

    Private Sub cboCoCde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        Call auto_search_combo(cboCoCde, e.KeyCode)
        Dim orgPos As Integer
        orgPos = cboCoCde.SelectedIndex
        If orgPos = -1 Then
            orgPos = 0
        End If
        cboCoCde.SelectedIndex = orgPos
        txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)
    End Sub

    Private Sub cboCoCde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.LostFocus
        Call cboCoCdeClick()
    End Sub


    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged


    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        msg = ""
        msg2 = ""
        msg3 = ""

        gspStr = "sp_list_VNCTNPER_PG09 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCTNPER_09, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGXLS001_Load sp_list_VNCTNPER_PG09 :" & rtnStr)
            Exit Sub
        End If


        If check_gen_set() = True Then
        Else
            Exit Sub
        End If


        If save_PKREQHDR() = True Then
        Else
            MsgBox("Header Record Save Fail!")
            Exit Sub
        End If



        Exit Sub





        Cursor = Cursors.Default


    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim opt As String
        Dim intFm As Long
        Dim intTo As Long


        If rs_LIST_RESULT.Tables.Count = 0 Then Exit Sub
        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If Val(txtFromApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            Cursor = Cursors.Default

            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Not IsNumeric(txtFromApply.Text) Then
            MsgBox("The apply range should be integers!")
            Cursor = Cursors.Default
            txtFromApply.SelectAll()
            Exit Sub
        End If

        If Val(txtToApply.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Not IsNumeric(txtToApply.Text) Then
            MsgBox("The apply range should be integers!")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        txtFromApply.Text = CInt(txtFromApply.Text)
        txtToApply.Text = CInt(txtToApply.Text)


        If Val(txtToApply.Text) > rs_LIST_RESULT.Tables("RESULT").DefaultView.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            txtToApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        If Val(txtFromApply.Text) > Val(txtToApply.Text) Then
            MsgBox("The apply range is invalid.")
            txtFromApply.SelectAll()
            Cursor = Cursors.Default

            Exit Sub
        End If

        intFm = CLng(txtFromApply.Text)
        intTo = CLng(txtToApply.Text)

        If intTo > rs_LIST_RESULT.Tables("RESULT").DefaultView.Count Then
            intTo = rs_LIST_RESULT.Tables("RESULT").DefaultView.Count
        End If


        ''apply
        If optStatusG.Checked = True Then
            For index As Integer = intFm To intTo
                If chkallmatch.Checked = True Then
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_check") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("tmp_action") = "Y"
                    End If

                    'If rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_check") = "Y" _
                    'And (Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_case")) = "1.1" _
                    '     Or Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("res_case")) = "0") Then   'whole key match:  itmno, packing, terms
                    '    rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("tmp_action") = "Y"
                    'End If

                Else
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("VALID") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("gen") = "Y"
                    End If
                End If
            Next
        ElseIf optStatusN.Checked = True Then
            For index As Integer = intFm To intTo
                rs_LIST_RESULT.Tables("RESULT").DefaultView(index - 1)("gen") = "N"
            Next
        End If

        rs_LIST_RESULT.Tables("RESULT").AcceptChanges()
        Exit Sub '2016


        'Check Same Item
        For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            For index_j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                If index_i <> index_j Then
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("tmp_itmno").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("tmp_itmno").ToString() Then
                        grdItem.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                        grdItem.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                        'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                    End If
                End If
            Next
        Next



        'Check "N"
        For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("tmp_action").ToString() = "N" Then
                grdItem.Rows(index_i).Cells(1).Style.BackColor = Color.Red
            End If
        Next
        For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_check").ToString() = "N" Then
                grdItem.Rows(index_i).Cells(25).Style.BackColor = Color.Red
            End If
        Next

        'When UPD Q#, check New case
        If Me.chkQutUpd.Checked = True Then
            For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_acttyp").ToString() = "New" Then
                    grdItem.Rows(index_i).Cells(7).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(8).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(9).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(10).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(16).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(17).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(18).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(19).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(24).Style.BackColor = Color.Cyan
                End If
            Next
        End If


    End Sub


    Private Sub chkQutNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkQutNew.CheckedChanged

        If chkQutNew.Checked = False And chkQutUpd.Checked = False Then
            Cursor = Cursors.Default
            Exit Sub
        Else
            If chkQutNew.Checked = True And chkQutUpd.Checked = True Then
                MsgBox("Please Choose either New or Update Quotation.")
                chkQutNew.Checked = False
                chkQutUpd.Checked = False
                '       Call resetDisplay(cModeAdd)
                Cursor = Cursors.Default

                Exit Sub
            End If

            If chkQutNew.Checked = True And chkQutUpd.Checked = False Then
                '    Call resetDisplay(cModeAdd)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If chkQutNew.Checked = False And chkQutUpd.Checked = True Then
                '    Call resetDisplay(cModeUpd)
                Cursor = Cursors.Default
                Exit Sub
            End If

        End If
    End Sub

    Private Sub grdItem_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItem.CellClick


        'If e.RowIndex >= 0 Then
        '    isSorting = False
        '    dr = rs_LIST_RESULT.Tables("RESULT").Select("", "qud_qutseq")

        '    For index As Integer = 0 To dr.Length - 1
        '        If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("qud_qutseq") = dr(index)("qud_qutseq") Then
        '            li_index_insert = index
        '        End If
        '    Next
        'Else
        '    isSorting = True
        'End If
        If e.ColumnIndex <> 0 Then
            Exit Sub
        End If
        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            If grdItem.Columns(e.ColumnIndex).ReadOnly = False Then
                If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("GEN").ToString = "Y" Then
                    rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("GEN") = "N"
                Else
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("Valid") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(e.RowIndex)("GEN") = "Y"
                    End If
                End If
                '   rs_LIST_RESULT.Tables("RESULT").AcceptChanges()
            End If
        End If
        rs_LIST_RESULT.Tables("RESULT").AcceptChanges()

        Exit Sub

        'Check Same Item
        For index_i As Integer = 0 To grdItem.Rows.Count - 1
            For index_j As Integer = 0 To grdItem.Rows.Count - 1
                If index_i <> index_j Then
                    'If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("tmp_itmno").ToString() = rs_LIST_RESULT.Tables("RESULT").DefaultView(index_j)("tmp_itmno").ToString() Then
                    If grdItem.Rows(index_i).Cells("tmp_itmno").Value.ToString() = grdItem.Rows(index_j).Cells("tmp_itmno").Value.ToString() Then
                        grdItem.Rows(index_i).DefaultCellStyle.BackColor = Color.LightBlue
                        grdItem.Rows(index_j).DefaultCellStyle.BackColor = Color.LightBlue
                        'MsgBox("Item:" & index_i + 1 & " Item:" & index_j + 1 & " are duplcated items, please choose either one only.")
                    End If
                End If
            Next
        Next

        'Check "N"
        For index_i As Integer = 0 To grdItem.Rows.Count - 1
            If grdItem.Rows(index_i).Cells("tmp_action").Value.ToString() = "N" Then
                grdItem.Rows(index_i).Cells(1).Style.BackColor = Color.Red
            End If
        Next
        For index_i As Integer = 0 To grdItem.Rows.Count - 1
            If grdItem.Rows(index_i).Cells("res_check").Value.ToString() = "N" Then
                grdItem.Rows(index_i).Cells(25).Style.BackColor = Color.Red
            End If
        Next


        'When UPD Q#, check New case
        If Me.chkQutUpd.Checked = True Then
            For index_i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").DefaultView(index_i)("res_acttyp").ToString() = "New" Then
                    grdItem.Rows(index_i).Cells(7).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(8).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(9).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(10).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(16).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(17).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(18).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(19).Style.BackColor = Color.Cyan
                    grdItem.Rows(index_i).Cells(24).Style.BackColor = Color.Cyan
                End If
            Next
        End If




    End Sub

    Private Sub grdItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItem.CellContentClick



    End Sub

    Private Function isNewItemFormat(ByVal strItem As String, Optional ByVal bolShow As Boolean = False) As Boolean
        If gsCompanyGroup = "MSG" Then
            isNewItemFormat = False
        Else
            isNewItemFormat = False
            strItem = UCase(strItem)

            If bolShow = True Then
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function

                If UCase(Mid(strItem, 7, 2)) = "AS" And _
                    Microsoft.VisualBasic.Right(strItem, 2) <> "00" And _
                    UCase(Mid(strItem, 3, 1)) <> "C" And _
                    UCase(Mid(strItem, 3, 1)) <> "D" Then Exit Function

                If UCase(Mid(strItem, 7, 2)) <> "AS" Then
                    If UCase(Mid(strItem, 3, 1)) = "U" Then
                        Exit Function
                    End If

                    If UCase(Mid(strItem, 3, 1)) = "A" Then

                    End If

                    '*** Plant CDTXV
                    If UCase(Mid(strItem, 3, 1)) = "C" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "D" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "T" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "V" Then

                    End If
                    If UCase(Mid(strItem, 3, 1)) = "X" Then

                    End If

                    If UCase(Mid(strItem, 3, 1)) = "B" Then
                        If (Mid(strItem, 4, 1) >= "0" And Mid(strItem, 4, 1) <= "9") Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If (Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9") Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If

                        If Mid(strItem, 4, 1) >= "A" And Mid(strItem, 4, 1) <= "Z" Then
                            If Mid(strItem, 5, 1) >= "0" And Mid(strItem, 5, 1) <= "9" Then
                                If Mid(strItem, 6, 1) >= "0" And Mid(strItem, 6, 1) <= "9" Then
                                    isNewItemFormat = True
                                    Exit Function
                                Else
                                    Exit Function
                                End If
                            Else
                                Exit Function
                            End If
                        End If
                    End If
                Else
                    Exit Function
                End If
            Else
                If Len(strItem) < 11 Then Exit Function
                If InStr(strItem, "-") > 0 Then Exit Function
                If InStr(strItem, "/") > 0 Then Exit Function
                '*** Plant CDTXV
                If Not (UCase(Mid(strItem, 3, 1)) = "A" Or _
                        UCase(Mid(strItem, 3, 1)) = "B" Or _
                        UCase(Mid(strItem, 3, 1)) = "U" Or _
                        UCase(Mid(strItem, 3, 1)) = "C" Or _
                        UCase(Mid(strItem, 3, 1)) = "D" Or _
                        UCase(Mid(strItem, 3, 1)) = "T" Or _
                        UCase(Mid(strItem, 3, 1)) = "X" Or _
                        UCase(Mid(strItem, 3, 1)) = "V") Then Exit Function
            End If
            isNewItemFormat = True
        End If
    End Function

    Private Function not_Valid_Item(ByVal itmNo As String, ByVal cus1no As String, ByVal colcde As String) As Boolean
        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde_Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMXChk '" & cboCoCde_Text & "','" & cus1no & "','" & colcde & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMXCHK, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading not_Valid_Item sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            not_Valid_Item = True
            MsgBox("Item cannot Quot by this Company! Customer and Company Relation Missing.")
        Else
            If rs_IMXCHK.Tables("RESULT").Rows(0)("imx_vendef").ToString <> "Y" Then
                If MsgBox("This is not the default company to quot this item, Do you continue the quot?", vbYesNo) = vbYes Then
                    not_Valid_Item = False
                Else
                    not_Valid_Item = True
                End If
            Else
                not_Valid_Item = False
            End If
        End If
    End Function

    Private Sub GetCusSty(ByVal strItm As String)
        '*** Show Customer Alias
        Dim rsCusals As New DataSet

        'cboCusals.Items.Clear()
        'cboCusals.Text = ""

        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde_Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMCUSSTY_QU '" & cboCoCde_Text & "','" & strItm & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ")) & "'"
        rtnLong = execute_SQLStatement(gspStr, rsCusals, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetCusSty sp_select_IMCUSSTY_QU :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            '   cboCusals.Items.Add("")
            For index As Integer = 0 To rsCusals.Tables("RESULT").Rows.Count - 1
                '      cboCusals.Items.Add(rsCusals.Tables("RESULT").Rows(index)("ics_cusstyno").ToString)
            Next

            ' cboCusals.SelectedIndex = 0
            'cboCusals.Enabled = True
        Else
            'cboCusals.Items.Clear()
            'cboCusals.Text = ""
            ''cboCusals.Enabled = False
        End If
    End Sub

    Public Function SearchImgPath(ByVal itmNo As String) As String
        '*** The objective of this function is to search for the sub-directory
        '*** of an item image.  This sub-directory is defined as the first 3
        '*** characters of a "revised" item number
        '*** converting format of the item no:
        itmNo = revisedItmno(itmNo)
        '*** Take the first 3 characters of the item no.
        SearchImgPath = Microsoft.VisualBasic.Left(itmNo, 8)
    End Function
    Public Function revisedItmno(ByVal itmNo As String) As String
        '*** The objective of this function is to replace any "/" or " /" in
        '*** an item number with an "_"
        '*** converting format of item no:
        itmNo = Replace(itmNo, " /", "_")
        itmNo = Replace(itmNo, "/", "_")
        itmNo = Replace(itmNo, "-", "_")
        itmNo = Replace(itmNo, " ", "")
        revisedItmno = itmNo
    End Function

    Private Function isABUAssortment(ByVal itmNo As String) As Boolean
        '*** FOR ALL ASSORTMENT
        Dim rs_ABUASST As New DataSet

        isABUAssortment = False

        '' Cursor = Cursors.WaitCursor

        gsCompany = Trim(cboCoCde_Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CHECK_ASST_FOR_PC '" & cboCoCde_Text & "','" & IIf(itmNo = "", "X", itmNo) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_ABUASST, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading isABUAssortment sp_select_CHECK_ASST_FOR_PC :" & rtnStr)
            Cursor = Cursors.Default
            Exit Function
        End If
        Cursor = Cursors.Default

        If rs_ABUASST.Tables("RESULT").Rows.Count > 0 Then
            isABUAssortment = True
        Else
            isABUAssortment = False
        End If
    End Function


    Private Sub ABUASST(ByVal itmNo As String, ByVal Action As String)
        'Select Case Action
        '    Case "SHOW"
        '        txtUMFtr.Visible = True
        '        lblUMFtr.Visible = True
        '        chkPC.Visible = True
        '        chkPC.Enabled = True
        '        If chkPC_hdr.Checked = True Then
        '            chkPC.Enabled = False
        '        Else
        '            chkPC.Enabled = True
        '        End If
        '    Case "HIDE"
        '        txtUMFtr.Visible = False
        '        chkPC.Visible = True
        '        chkPC.Enabled = True
        '        lblUMFtr.Visible = False
        '        txtUMFtr_Text = ""
        '        chkPC.Visible = False
        '        chkPC.Enabled = False
        '    Case "SHOWPRC"
        '        lblPCPrc.Visible = True
        '        txtPCPrcCur.Visible = True
        '        txtPCPrc.Visible = True

        '        txtPCPrcCur.Enabled = False
        '        txtPCPrc.Enabled = True
        '        txtCus1Dp.Enabled = False
        '    Case "HIDEPRC"
        '        lblPCPrc.Visible = False
        '        txtPCPrcCur.Visible = False
        '        txtPCPrc.Visible = False

        '        txtPCPrcCur.Enabled = False
        '        txtPCPrc.Enabled = False
        '        txtCus1Dp.Enabled = True
        '        txtPCPrc_Text = "0"
        '    Case "CHKPCK_A"
        '        If isABUAssortment(itmNo) = True Then
        '            If rs_IMPCKINF.Tables("RESULT").Rows.Count > 0 Then
        '                dr = rs_IMPCKINF.Tables("RESULT").Select("ipi_pckunt = '" & Split(cboPcking.Text, " / ")(0) & "' and ipi_inrqty = " & Split(cboPcking.Text, " / ")(1) & " and ipi_mtrqty = " & Split(cboPcking.Text, " / ")(2))
        '                If dr(0)("ipi_conftr").ToString <> "" Then
        '                    txtUMFtr_Text = dr(0)("ipi_conftr").ToString()
        '                    Call ABUASST(txtItmNo.Text, "SHOW")
        '                End If
        '            End If
        '        End If
        '    Case "CALPCPRCI"
        '        If txtCus1Sp.Text <> "" And txtUMFtr_Text <> "" Then
        '            Call txtPCPrcGotFocus()
        '            If txtDiscnt.Text <> "" And IsNumeric(txtDiscnt.Text) = True Then
        '                If Val(txtDiscnt.Text) = 0 Then
        '                    txtPCPrc_Text = Format(txtCus1Sp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '                Else
        '                    txtPCPrc_Text = Format(txtCus1Dp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '                End If
        '            Else
        '                txtPCPrc_Text = Format(txtCus1Sp.Text / txtUMFtr_Text, "###,###,##0.0000")
        '            End If
        '            rs_QUOTNDTL.Tables("RESULT").Rows.Item(li_index_insert)("qud_pcprc") = IIf(txtPCPrc_Text = "", 0, txtPCPrc_Text)
        '            Call txtPCPrcLostFocus()
        '        Else
        '            txtPCPrc_Text = Format(0, "###,###,##0.0000")
        '        End If
        'End Select

        'If Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "H" Or Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "C" Or Microsoft.VisualBasic.Left(txtQutSts.Text, 1) = "E" Then
        '    chkPC.Enabled = False
        '    txtPCPrc.Enabled = False

        '    txtPCPrcCur.Enabled = False
        '    chkPC_hdr.Enabled = False
        'End If
    End Sub



    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtFromApply.Text = ""
        txtToApply.Text = ""
    End Sub




    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpload.Click
        chkallmatch.Checked = False
        rs_LIST_RESULT.Clear()
        Me.txtQutNo2.Text = ""


        If rs_LIST_RESULT.Tables("RESULT") Is Nothing Then

            btcPGXLS001.SelectedIndex = 0
            btcPGXLS001.TabPages(0).Enabled = True
            btcPGXLS001.TabPages(1).Enabled = False
            cmdGen.Enabled = True
            Exit Sub
        End If

        If rs_LIST_RESULT.Tables("RESULT").Rows.Count > 1 Then
            grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView

        End If

        btcPGXLS001.SelectedIndex = 0
        btcPGXLS001.TabPages(0).Enabled = True
        btcPGXLS001.TabPages(1).Enabled = False
        cmdGen.Enabled = True




    End Sub

    Sub map_all_items()
        Dim i As Integer
        Dim tmp_est_ttl As Decimal
        Dim tmp_str As String


        gspStr = "sp_select_PGXLS001 '" & FileToCopy & _
                     "','" & tmp_date & "'"
        'gspStr = "sp_select_PGXLS001 '" & cboCoCde_Text.Trim & _
        '           "','" & txtQutNo.Text.Trim & _
        '            "','" & FileToCopy & _
        '             "','" & tmp_date & "'"


        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT, rtnStr)
        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_PGXLS001 :" & rtnStr)
            Exit Sub
        End If


        For i = 0 To rs_LIST_RESULT.Tables("RESULT").Columns.Count - 1
            rs_LIST_RESULT.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        'For i = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
        '    rs_LIST_RESULT.Tables("RESULT").Rows(i)("tmp_count") = i + 1
        'Next



        gspStr = "sp_select_PGXLSDTL_SCTO '" & FileToCopy & _
             "','" & tmp_date & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT_scto, rtnStr)
        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_PGXLSDTL_SCTO :" & rtnStr)
            Exit Sub
        End If

        For i = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Columns.Count - 1
            rs_LIST_RESULT_scto.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        'query req#/ Hdr Act



        'check exist in SC/TO, check  cocde,cusno,    & call ttl est
        '''check exit EST hdr  => EST Iinsert/EST upd
        gspStr = "sp_select_PGXLSDTL '" & FileToCopy & _
                     "','" & tmp_date & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT_group, rtnStr)
        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_PGXLSDTL :" & rtnStr)
            Exit Sub
        Else
            'If rs_LIST_RESULT_group.Tables("RESULT").Rows.Count > 0 Then
            '    For index As Integer = 0 To rs_LIST_RESULT_group.Tables("RESULT").Rows.Count - 1
            '        'rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = " pxd_scno = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_scno") & "'" & _
            '        '                                                                                               " and  pxd_tono = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_tono") & "'" & _
            '        '                                                                                               " and  pxd_itmno = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_itmno") & "'" & _
            '        '                                                                                               " and  pxd_assitmno = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_assitmno") & "'" & _
            '        '                                                                                               " and  pxd_cusitmno = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_cusitmno") & "'" & _
            '        '                                                                                               " and  pxd_um = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_um") & "'" & _
            '        '                                                                                               " and  pxd_inner = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_inner") & "'" & _
            '        '                                                                                               " and  pxd_master = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_master") & "'" & _
            '        '                                                                                               " and  pxd_cft = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_cft") & "'" & _
            '        '                                                                                               " and  pxd_ftytrm = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_ftytrm") & "'" & _
            '        '                                                                                               " and  pxd_hktrm = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_hktrm") & "'" & _
            '        '                                                                                               " and  pxd_trantrm = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_trantrm") & "'" & _
            '        '                                                                                               " and  pxd_colcde = '" & rs_LIST_RESULT_group.Tables("RESULT").Rows(index)("pxd_colcde") & "'"

            '        For index1 As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            '            tmp_est_ttl = rs_LIST_RESULT.Tables("RESULT").DefaultView(0)("pxd_estttl")
            '            If tmp_est_ttl <> rs_LIST_RESULT.Tables("RESULT").DefaultView(index1)("pxd_estttl") Then
            '                MsgBox("Some Estimated total amount not match.")
            '                cmdGen.Enabled = False
            '                '
            '                Exit Sub

            '            End If
            '        Next

            '    Next
            'End If
        End If



        gspStr = "sp_select_PGXLSDTL_cusno '" & FileToCopy & _
     "','" & tmp_date & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT_cusno, rtnStr)
        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_PGXLSDTL_cusno  :" & rtnStr)
            Exit Sub
        End If

        'check insert/update case
        'check dup, check printer, cal/overwrigt wast,  Unit Price non-zero
        'check Cur of UP

        gspStr = "sp_select_PGXLSDTL_check '" & FileToCopy & _
                     "','" & tmp_date & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT_check_dup, rtnStr)
        Cursor = Cursors.Default

        cmdGen.Enabled = True
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading rs_LIST_RESULT_check_dup :" & rtnStr)
            Exit Sub
        Else
            'If rs_LIST_RESULT_check_dup.Tables("RESULT").Rows.Count > 0 Then
            '    For index As Integer = 0 To rs_LIST_RESULT_check_dup.Tables("RESULT").Rows.Count - 1
            '        If rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(index)("check") > 1 Then
            '            For ii As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1

            '            Next
            '            'tmp_str = ""
            '            'For j As Integer = 1 To rs_LIST_RESULT_check_dup.Tables("RESULT").Columns.Count - 1
            '            '    tmp_str = tmp_str & rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(index)(j) & vbCrLf
            '            'Next
            '            '         MsgBox("The Excel has duplicate key rows:" & vbCrLf & tmp_str)

            '            '                        cmdGen.Enabled = False
            '            '
            '            ''''''''''''''''''''''''''''  'Exit Sub
            '        End If
            '    Next
            'End If
        End If
        'call checking same value est per item'
        'insert  by to detail


        gspStr = "sp_select_PGXLSDTL_check_add '" & FileToCopy & _
             "','" & tmp_date & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_LIST_RESULT_check_dup_add, rtnStr)
        Cursor = Cursors.Default

        cmdGen.Enabled = True
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading rs_LIST_RESULT_check_dup :" & rtnStr)
            Exit Sub
        Else
        End If


        Call valid_all()
        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
        rs_LIST_RESULT.Tables("RESULT").AcceptChanges()

        grdItem.DataSource = rs_LIST_RESULT.Tables("RESULT").DefaultView

        grdItem.Refresh()

        Call display_grdItem()

        txtFromApply.Text = "1"
        txtToApply.Text = rs_LIST_RESULT.Tables("RESULT").DefaultView.Count







    End Sub




    Function read_from_excel() As Boolean
        read_from_excel = True

        If filSource.SelectedIndex = -1 Then
            read_from_excel = False

            MsgBox("Please Select a file to Update.")
            btcPGXLS001.SelectedIndex = 0
            btcPGXLS001.TabPages(0).Enabled = True
            btcPGXLS001.TabPages(1).Enabled = False
            btcPGXLS001.TabPages(2).Enabled = False
            Cursor = Cursors.Default
            Exit Function
        End If


        Dim NewCopy As String
        Dim filDePath As String


        FileToCopy = filSourcePath + "\" + filSource.Text

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Dim i As Integer


        '        --------------------------
        Dim temp_cocde As String
        Dim temp_act As String
        Dim temp_pxd_reqno As String
        Dim temp_pxd_reqseq As String = 0
        Dim temp_row As String = 4
        Dim temp_prd_pkgitm As String
        Dim temp_pkgvenno As String
        Dim temp_prh_ScNo As String
        Dim temp_ToNo As String
        Dim temp_Cus1no As String
        Dim temp_Cus2no As String

        Dim temp_ped_itemno As String
        Dim temp_assitemno As String

        Dim temp_ped_price As String
        Dim temp_prd_ttlordqty As String
        Dim temp_prd_cusitm As String
        Dim temp_cussku As String

        Dim temp_prd_pckunt As String
        Dim temp_prd_inrqty As String
        Dim temp_prd_mtrqty As String
        Dim temp_prd_cft As String = 0
        Dim temp_prd_ftyprctrm As String
        Dim temp_prd_hkprctrm As String
        Dim temp_prd_trantrm As String

        Dim temp_prd_colcde As String
        Dim temp_po As String


        Dim temp_prd_scordqty As String
        Dim temp_prd_conftr As String

        Dim temp_prd_ordqty As String
        Dim temp_prd_wasqty As String

        Dim temp_ped_curcde As String
        Dim temp_prd_untprc As String

        Dim temp_prd_multiplier As String

        Dim temp_curest As String
        Dim temp_estunt As String
        Dim temp_estttl As String

        Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        'Set the excel invisible to prevent user interrupt the process of creating the excel
        xlsApp.Visible = False
        xlsApp.UserControl = False

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Open(FileToCopy)

        xlsWS = xlsWB.ActiveSheet
        xlsApp.Sheets(1).Activate()


        ''Check cus1 cus2


        tmp_date = DateTime.Now.ToShortDateString & ".  " & DateTime.Now.ToLongTimeString

        i = 0

        With xlsApp
            If Trim(.Range("B1").Value) <> "1.3.0" Then
                MsgBox("Please Use Correct Version of Excel template.")
                read_from_excel = False

                btcPGXLS001.SelectedIndex = 0
                btcPGXLS001.TabPages(0).Enabled = True
                btcPGXLS001.TabPages(1).Enabled = False
                btcPGXLS001.TabPages(2).Enabled = False
                Cursor = Cursors.Default
                Exit Function
            End If
        End With

        With xlsApp
            If i = 0 And .Range("D" + (i + 5).ToString).Value = Nothing Then
                MsgBox("Please Input Packaging Item Number.")
                read_from_excel = False

                btcPGXLS001.SelectedIndex = 0
                btcPGXLS001.TabPages(0).Enabled = True
                btcPGXLS001.TabPages(1).Enabled = False
                btcPGXLS001.TabPages(2).Enabled = False
                Cursor = Cursors.Default
                Exit Function
            End If


            While (.Range("D" + (i + 5).ToString).Value <> Nothing)
                'check as empty row

                If Not IsNumeric(.Range("V" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for UM Factor.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If Not IsNumeric(.Range("W" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for PKG Order Qty.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If Not IsNumeric(.Range("X" + (i + 5).ToString).Value) And Not Trim(.Range("X" + (i + 5).ToString).Value) = "" Then
                    MsgBox("Please Input Numeric data for PKG Wastage .")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If Not IsNumeric(.Range("Y" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for PKG Total Order Qty  .")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If Not IsNumeric(.Range("AA" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for Unit Price .")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If Not IsNumeric(.Range("AD" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for Estimated (Unit).")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If Not IsNumeric(.Range("AE" + (i + 5).ToString).Value) Then
                    MsgBox("Please Input Numeric data for Estimated (Total).")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If


                If CInt(.Range("V" + (i + 5).ToString).Value) <> .Range("V" + (i + 5).ToString).Value Then
                    MsgBox("Please Input Integer for UM Factor.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If CInt(.Range("W" + (i + 5).ToString).Value) <> .Range("W" + (i + 5).ToString).Value Then
                    MsgBox("Please Input Integer for PKG Order Qty .")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If CInt(.Range("X" + (i + 5).ToString).Value) <> .Range("X" + (i + 5).ToString).Value Then
                    MsgBox("Please Input Integer for PKG Wastage .")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If CInt(.Range("Y" + (i + 5).ToString).Value) <> .Range("Y" + (i + 5).ToString).Value Then
                    MsgBox("Please Input Integer for PKG Total Order Qty.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If .Range("AA" + (i + 5).ToString).Value > 9999 Then
                    MsgBox("Please Input reasonable amount for Unit Price.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If .Range("AD" + (i + 5).ToString).Value > 9999 Then
                    MsgBox("Please Input reasonable amount for Estimated (Unit).")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If .Range("AD" + (i + 5).ToString).Value > 9999 Then
                    MsgBox("Please Input reasonable amount for Estimated (Total).")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                If Len(.Range("K" + (i + 5).ToString).Value) > 20 Then
                    MsgBox("Please Input Shorter length (20) data for Customer Item#.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If Len(.Range("L" + (i + 5).ToString).Value) > 20 Then
                    MsgBox("Please Input Shorter length (20) data for Customer SKU No..")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If
                If Len(.Range("T" + (i + 5).ToString).Value) > 20 Then
                    MsgBox("Please Input Shorter length (20) data for Cust PO#.")
                    read_from_excel = False

                    btcPGXLS001.SelectedIndex = 0
                    btcPGXLS001.TabPages(0).Enabled = True
                    btcPGXLS001.TabPages(1).Enabled = False
                    btcPGXLS001.TabPages(2).Enabled = False
                    Cursor = Cursors.Default
                    Exit Function
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''
                temp_act = Trim((.Range("A" + (i + 5).ToString).Value))
                temp_pxd_reqno = Trim((.Range("B" + (i + 5).ToString).Value))

                temp_pxd_reqseq = Trim((.Range("C" + (i + 5).ToString).Value))
                If temp_pxd_reqseq = "" Then
                    temp_pxd_reqseq = 0
                End If

                temp_row = temp_row + 1

                temp_prd_pkgitm = (.Range("D" + (i + 5).ToString).Value)
                temp_pkgvenno = (.Range("E" + (i + 5).ToString).Value)
                temp_pkgvenno = Trim(temp_pkgvenno)
                temp_pkgvenno = Microsoft.VisualBasic.Left(temp_pkgvenno, 4)

                temp_prh_ScNo = Trim(.Range("F" + (i + 5).ToString).Value)
                temp_ToNo = Trim(.Range("G" + (i + 5).ToString).Value)

                temp_Cus1no = (.Range("H" + (i + 5).ToString).Value)
                temp_Cus1no = Trim(temp_Cus1no)
                temp_Cus1no = Microsoft.VisualBasic.Left(temp_Cus1no, 5)


                temp_ped_itemno = (.Range("I" + (i + 5).ToString).Value)
                temp_assitemno = (.Range("J" + (i + 5).ToString).Value)


                temp_prd_cusitm = (.Range("K" + (i + 5).ToString).Value)
                temp_cussku = (.Range("L" + (i + 5).ToString).Value)

                temp_prd_pckunt = (.Range("M" + (i + 5).ToString).Value)

                temp_prd_inrqty = (.Range("N" + (i + 5).ToString).Value)
                temp_prd_mtrqty = (.Range("O" + (i + 5).ToString).Value)
                temp_prd_ftyprctrm = (.Range("P" + (i + 5).ToString).Value)
                temp_prd_hkprctrm = (.Range("Q" + (i + 5).ToString).Value)
                temp_prd_trantrm = (.Range("R" + (i + 5).ToString).Value)

                temp_prd_colcde = (.Range("S" + (i + 5).ToString).Value)
                temp_po = (.Range("T" + (i + 5).ToString).Value)
                temp_prd_scordqty = (.Range("U" + (i + 5).ToString).Value)
                temp_prd_conftr = (.Range("V" + (i + 5).ToString).Value)

                temp_prd_ordqty = (.Range("W" + (i + 5).ToString).Value)
                temp_prd_wasqty = (.Range("X" + (i + 5).ToString).Value)
                If temp_prd_wasqty = "" Then
                    temp_prd_wasqty = -1
                End If
                temp_prd_ttlordqty = (.Range("Y" + (i + 5).ToString).Value)

                temp_ped_curcde = (.Range("Z" + (i + 5).ToString).Value)
                temp_prd_untprc = (.Range("AA" + (i + 5).ToString).Value)

                temp_prd_multiplier = (.Range("AB" + (i + 5).ToString).Value)

                temp_curest = (.Range("AC" + (i + 5).ToString).Value)

                temp_estunt = (.Range("AD" + (i + 5).ToString).Value)
                If temp_estunt = "" Then
                    temp_estunt = 0
                End If
                temp_estttl = (.Range("AE" + (i + 5).ToString).Value)
                If temp_estttl = "" Then
                    temp_estttl = 0
                End If



                gspStr = "sp_insert_PGXLSDTL '" & temp_cocde & _
  "','" & temp_act & _
  "','" & temp_pxd_reqno & _
  "','" & FileToCopy & _
  "','" & tmp_date & _
  "'," & temp_pxd_reqseq & _
  "," & temp_row & _
   ",'" & temp_prd_pkgitm & _
   "','" & temp_pkgvenno & _
                   "','" & temp_prh_ScNo & _
                   "','" & temp_ToNo & _
                   "','" & temp_Cus1no & _
                   "','" & temp_Cus2no & _
                   "','" & temp_ped_itemno & _
                   "','" & temp_assitemno & _
                   "','" & temp_prd_cusitm & _
                   "','" & temp_cussku & _
                   "','" & temp_prd_pckunt & _
                   "','" & temp_prd_inrqty & _
                   "','" & temp_prd_mtrqty & _
                   "','" & temp_prd_cft & _
                   "','" & temp_prd_ftyprctrm & _
                   "','" & temp_prd_hkprctrm & _
                   "','" & temp_prd_trantrm & _
                   "','" & temp_prd_colcde & _
                   "','" & temp_po & _
                   "','" & temp_prd_scordqty & _
                   "','" & temp_prd_conftr & _
                   "','" & temp_prd_ordqty & _
                   "','" & temp_prd_wasqty & _
                   "','" & temp_prd_ttlordqty & _
                   "','" & temp_ped_curcde & _
                   "','" & temp_prd_untprc & _
                   "'," & temp_prd_multiplier & _
                   ",'" & temp_curest & _
                   "'," & temp_estunt & _
                   "," & temp_estttl & _
   ",'" & gsUsrID & _
    "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading sp_insert_PGXLSDTL" & rtnStr)
                    Exit Function
                End If



                i = i + 1
            End While
        End With

        Cursor = Cursors.Default


        '        MsgBox("Please Approve the Quotation and Select to Generate.")
        'btcPGXLS001.SelectedIndex(1)


        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing


        '    Call cmdsave_click()

        'txtScNo_Text = temp_prh_ScNo
        'txtScNo_KeyPress()

        'dgPKGITEM_CellDoubleClick()

        'txtPkgItem_Text = temp_prd_pkgitm
        'txtPkgItem_KeyPress()


    End Function




    'Private Function save_PKESDTL() As Boolean
    '    'for loop xls records
    '    '


    '    If rs_PKESDTL.Tables("RESULT").Rows.Count = 0 Then
    '        Return True
    '        Exit Function
    '    End If

    '    For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
    '        Dim ped_cocde As String
    '        Dim ped_reqno As String
    '        Dim ped_reqseq As Integer
    '        Dim ped_seq As Integer
    '        Dim ped_itemno As String
    '        Dim ped_assitm As String
    '        Dim ped_tmpitmno As String
    '        Dim ped_venno As String
    '        Dim ped_venitm As String
    '        Dim ped_colcde As String
    '        Dim ped_pkgitem As String
    '        Dim ped_price As Decimal
    '        Dim ped_curcde As String
    '        Dim ped_creusr As String

    '        ped_cocde = cboCoCde_Text
    '        ped_reqno = txtReqno.Text '
    '        ped_reqseq = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq")
    '        ped_seq = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_seq")
    '        ped_itemno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_itemno").ToString
    '        ped_assitm = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_assitm").ToString
    '        ped_tmpitmno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_tmpitmno").ToString
    '        ped_venno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_venno").ToString
    '        ped_venitm = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_venitm").ToString
    '        ped_colcde = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_colcde").ToString
    '        ped_pkgitem = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_pkgitem").ToString
    '        ped_price = round(rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_price"), 5)
    '        ped_curcde = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_curcde")
    '        ped_creusr = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr").ToString


    '        If ped_creusr = "~*ADD*~" Then
    '            gspStr = "sp_insert_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
    '            ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"



    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_PKESDTL sp_insert_PKESHDR :" & rtnStr)
    '                save_PKESDTL = False
    '                Exit Function
    '            End If

    '        ElseIf ped_creusr = "~*UPD*~" Then

    '            gspStr = "sp_update_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
    '            ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"


    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_PKESDTL sp_update_PKESHDR :" & rtnStr)
    '                save_PKESDTL = False
    '                Exit Function
    '            End If

    '        ElseIf ped_creusr = "~*DEL*~" Then

    '            gspStr = "sp_physical_delete_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq


    '            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
    '            If rtnLong <> RC_SUCCESS Then
    '                MsgBox("Error on loading save_PKESDTL sp_physical_delete_PKESDTL :" & rtnStr)
    '                save_PKESDTL = False
    '                Exit Function
    '            End If

    '        End If
    '    Next

    '    save_PKESDTL = True

    'End Function








    Sub valid_all()
        check_and_valid_ActFlag()
        check_and_valid_fields()
        Call check_and_valid_LV3_REQNo()
        check_and_valid_LV1()
        check_and_valid_LV2()
        check_and_valid_UPD()
        check_and_valid_LV3()
    End Sub

    Sub check_and_valid_LV1()
        Dim tmp_cocde As String
        Dim tmp_sc As String
        Dim tmp_to As String
        Dim temp_retuen As Integer

        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO")) = "" Then
                rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO") = index + 1
            End If

            For j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_scno") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno") _
                And rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_tono") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono") And rs_LIST_RESULT.Tables("RESULT").Rows(j)("Valid") <> "N" Then
                    If rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid") <> "N" Then
                        rs_LIST_RESULT.Tables("RESULT").Rows(j)("REQ_NO") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO")
                    End If
                End If
            Next
        Next
        'tmp no

        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            tmp_cocde = Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_cocde"))
            tmp_sc = Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno"))
            tmp_to = Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono"))
            If tmp_sc <> "" Then
                temp_retuen = CheckExistPKG("SC", tmp_sc, tmp_cocde)
                If temp_retuen = 1 Then 'Create
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & tmp_sc & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Hdr_Act") = "New"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "New"
                    Next

                    gspStr = "sp_select_SCORDHDR_PKG02 '" & tmp_cocde & "','" & tmp_sc & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDHDR_PKG02 :" & rtnStr)
                        Exit Sub
                    End If

                    If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts") <> "REL" And rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts") <> "ACT" Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & tmp_sc & "'"
                        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                            rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("valid") = "N"
                            rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") & " SC/TO not in Released/Open Status;"
                            rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid") = "N"
                        Next
                    End If

                ElseIf temp_retuen = 2 Then 'Update
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & tmp_sc & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Hdr_Act") = "Upd"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "Upd"
                    Next

                    '''''''''''''''''find req#

                    'rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO") = FindReqBySCTO(tmp_cocde, tmp_sc, "SC")
                    rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("maxseq") = FindMaxSeqBySCTO(tmp_cocde, rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO"))

                    '                    rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO") = FindReqBySCTO(tmp_cocde, tmp_sc, "SC")
                    For j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_scno") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno") _
                        And rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_tono") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono") Then
                            If rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid") <> "N" Then
                                rs_LIST_RESULT.Tables("RESULT").Rows(j)("REQ_NO") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO")
                            End If
                        End If
                    Next



                ElseIf temp_retuen = 3 Then 'Not found
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & tmp_sc & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("valid") = "N"
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") & " SC# not Exist;"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid") = "N"
                    Next
                End If
            End If

            If tmp_to <> "" Then
                temp_retuen = CheckExistPKG("TO", tmp_to, tmp_cocde)
                If temp_retuen = 1 Then 'Create
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_tono = '" & tmp_to & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Hdr_Act") = "New"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "New"

                    Next
                ElseIf temp_retuen = 2 Then 'Update
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_tono = '" & tmp_to & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Hdr_Act") = "Upd"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "Upd"
                    Next
                    '''''''''''''''''find req#
                    rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO") = FindReqBySCTO(tmp_cocde, tmp_to, "TO")
                    rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("maxseq") = FindMaxSeqBySCTO(tmp_cocde, rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO"))

                    For j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_scno") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno") _
                        And rs_LIST_RESULT.Tables("RESULT").Rows(j)("pxd_tono") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono") Then
                            rs_LIST_RESULT.Tables("RESULT").Rows(j)("REQ_NO") = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO")
                        End If
                    Next


                ElseIf temp_retuen = 3 Then 'Not found
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_tono = '" & tmp_to & "'"
                    For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("valid") = "N"
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Reason") & " TO# not Exist;"
                        rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid") = "N"
                    Next
                End If

            End If


        Next


    End Sub
    Sub check_and_valid_LV2()
        Dim tmp_cocde As String
        Dim tmp_sc As String
        Dim tmp_to As String
        Dim tmp_found As Boolean
        Dim tmp_reqno As String

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            If Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) <> "U" Then
                tmp_cocde = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cocde"))
                tmp_sc = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno"))
                tmp_to = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono"))

                If tmp_sc <> "" Then
                    gspStr = "sp_select_SCORDDTL_PKG02 '" & tmp_cocde & "','" & tmp_sc & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDDTL_PKG02 :" & rtnStr)
                        Exit Sub
                    Else
                        '''Assume Same Item#, Same Tmpitm#,venitm#,Venno
                        For ii As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                            For iii As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
                                If rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_scno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("ordno") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_itmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("realitem") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_assitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("assitem") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_cusitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("custitm") Then

                                    rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_tmpitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                    'rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_venno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                    'rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_tmpitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                End If
                            Next
                        Next
                    End If
                End If

                If tmp_to <> "" Then
                    gspStr = "sp_select_TOORDDTL_PKG02  '" & tmp_cocde & "','" & tmp_to & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDDTL_PKG02 :" & rtnStr)
                        Exit Sub
                    Else
                        '''Assume Same Item#, Same Tmpitm#,venitm#,Venno
                        For ii As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                            For iii As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
                                If rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_tono") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("ordno") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_itmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("realitem") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_assitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("assitem") And _
                                rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_cusitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("custitm") Then

                                    rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_tmpitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                    'rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_venno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                    'rs_LIST_RESULT.Tables("RESULT").Rows(ii)("pxd_tmpitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(iii)("tempitem")
                                End If
                            Next
                        Next
                    End If
                End If


                tmp_found = False
                For j As Integer = 0 To rs_TOSCDETAIL.Tables("RESULT").Rows.Count - 1
                    If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_itmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("realitem") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_assitmno") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("assitem") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_um") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("um") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_inner") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("inr") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_master") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("mst") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_colcde") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("colcde") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ftytrm") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("ftyprctrm") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_hktrm") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("hkprctrm") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_trantrm") = rs_TOSCDETAIL.Tables("RESULT").Rows(j)("trantrm") Then
                        tmp_found = True
                    End If
                Next

                If tmp_found = False Then
                    If rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "Y" Then
                        rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                        rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " (Item +Packing +Terms ) not found in SC/TO;"
                    End If
                End If
            End If

        Next


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'check insert/upd for EST HDR
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            tmp_cocde = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cocde"))
            tmp_sc = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno"))
            tmp_to = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono"))
            tmp_reqno = Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("REQ_NO"))

            If UCase(Trim(rs_LIST_RESULT.Tables("RESULT").Rows(index)("Hdr_Act"))) = UCase("Upd") Then

                gspStr = "sp_select_PKESHDR '" & tmp_cocde & "','" & tmp_reqno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                    Exit Sub
                End If


                tmp_found = False
                For j As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
                    If rs_LIST_RESULT.Tables("RESULT").Rows(index)("REQ_NO") = rs_PKESHDR.Tables("RESULT").Rows(j).Item("peh_reqno") And _
                  rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_itmno") = rs_PKESHDR.Tables("RESULT").Rows(j).Item("peh_itemno") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_assitmno") = rs_PKESHDR.Tables("RESULT").Rows(j).Item("peh_assitm") And _
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_colcde") = rs_PKESHDR.Tables("RESULT").Rows(j).Item("peh_colcde") Then
                        tmp_found = True
                    End If
                Next

                If tmp_found = False Then
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("EST_Hdr_Act") = "New"
                Else
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("EST_Hdr_Act") = "Upd"
                End If
            Else
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("EST_Hdr_Act") = "New"
            End If
        Next


        '' check EST Valuse valid  ''''''''''''''''not_comp_yet		


    End Sub
    Sub check_and_valid_LV3()
        Dim tmp_cocde As String
        Dim tmp_sc As String
        Dim tmp_to As String
        Dim tmp_found As Boolean
        Dim not_count_price As Integer
        Dim count_price As Integer

        gspStr = "sp_list_VNBASINF_PD ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNBASINF_PKG02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_02, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1

            tmp_found = False
            For j As Integer = 0 To rs_LIST_RESULT_check_dup.Tables("RESULT").Rows.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_itmno") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_itmno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_scno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_tono") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_assitmno") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_assitmno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_um") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_um") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_inner") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_inner") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_master") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_master") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_colcde") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_colcde") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ftytrm") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_ftytrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_hktrm") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_hktrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_trantrm") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_trantrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgitm") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_pkgitm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgvenno") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_pkgvenno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_unitprice") = rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("pxd_unitprice") And _
                UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) <> "U" And _
                1 < rs_LIST_RESULT_check_dup.Tables("RESULT").Rows(j)("check") Then
                    tmp_found = True
                End If
            Next
            If tmp_found = True Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Duplicated Key Data ;"
                '                cmdGen.Enabled = False
                btcPGXLS001.TabPages(0).Enabled = True
                btcPGXLS001.TabPages(1).Enabled = True
                btcPGXLS001.TabPages(2).Enabled = False


            End If

            ''''''V
            tmp_found = False
            For k As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgvenno") = rs_VNBASINF.Tables("RESULT").Rows(k)("vbi_venno") Then
                    tmp_found = True
                End If
            Next
            If tmp_found = False Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Vendor not found;"
            End If

            ''''''
            gspStr = "sp_select_PKIMBAIF '" & rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgitm") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading  sp_select_PKIMBAIF :" & rtnStr)
                Exit Sub
            End If
            If rs_PKIMBAIF.Tables("RESULT").Rows.Count = 0 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Packaging Item Number not found;"
            Else

            End If


            dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgvenno") & "'")
            If dr.Length <> 0 Then
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cur") <> Replace(dr(0)("vbi_curcde").ToString, "CNY", "RMB") Then
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Vendor Currency not match;"
                End If
            Else
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Vendor Currency not found;"
            End If

            ''''
            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_unitprice") = 0 And rs_LIST_RESULT.Tables("RESULT").Rows(index)("Hdr_Act") = "New" Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Unit Price Should not be zero;"
            End If

            ''''
            tmp_found = False
            For k As Integer = 0 To rs_LIST_RESULT_cusno.Tables("RESULT").Rows.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("pxd_scno") And _
                 rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("pxd_tono") And _
                  rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cus1no") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("soh_cus1no") Then

                    tmp_found = True
                End If
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("pxd_scno") And _
                 rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("pxd_tono") And _
                  rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cus1no") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("toh_cus1no") Then  ' rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_cus2no") = rs_LIST_RESULT_cusno.Tables("RESULT").Rows(k)("toh_cus2no")
                    tmp_found = True
                End If
            Next
            If tmp_found = False Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Customer Number not match with SC/TO;"
            End If

        Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        'check Key data : ins/upd
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        'SC#/TO# Update Case
        '02 Cat
        'Key data found, update
        For i As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            If rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("ACT") = "Upd" Then
                cmdFind_Click(rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_cocde"), rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("REQ_NO"))

                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_scno") & "'  and pxd_tono ='" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_tono") & "'  and cat ='02'  "
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_scno") & "'  and pxd_tono ='" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_tono") & "'  and cat ='02'  and valid = 'Y' "

                '''''''''''''                               Trim(Split(Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_pkgvenno")), "-")(0)) = Trim(Split(Trim(rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgven")), "-")(0)) And _

                For j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                    For k As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_pkgitm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgitm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_itmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_itemno") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_assitmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_assitm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_um") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pckunt") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_inner") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_inrqty") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_master") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_mtrqty") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_hktrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_hkprctrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_ftytrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_ftyprctrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_trantrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_trantrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_colcde") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_colcde") Then

                            If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_unitprice") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_untprc") Then
                                If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_seq") <> rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_seq") Then
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Valid") = "N"
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Reason") & " Request Sequence number not match;"

                                End If

                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Dtl_Act") = "Upd"
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Upd"

                                '''''''''''''''''''''
                                gspStr = "sp_select_PKESDTL '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_cocde") & "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("REQ_NO") & "'"
                                rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    Cursor = Cursors.Default
                                    MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                                    Exit Sub
                                End If


                                tmp_found = False
                                For o As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("REQ_NO") = rs_PKESDTL.Tables("RESULT").Rows(o).Item("ped_reqno") And _
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_seq") = rs_PKESDTL.Tables("RESULT").Rows(o).Item("ped_reqseq") Then
                                        tmp_found = True
                                    End If
                                Next

                                If tmp_found = False Then
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Insert"
                                Else
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Upd"
                                End If
                                '''''''''''''''''''''
                            Else

                                If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_act") = "R" Then
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Dtl_Act") = "Insert" 'Reprint 
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Insert"
                                Else
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Dtl_Act") = "Upd" 'Reprint 
                                    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Upd"
                                    ''''''''''''''''''''' 
                                    gspStr = "sp_select_PKESDTL '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_cocde") & "','" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("REQ_NO") & "'"

                                    rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                                    If rtnLong <> RC_SUCCESS Then
                                        Cursor = Cursors.Default
                                        MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                                        Exit Sub
                                    End If


                                    tmp_found = False
                                    For o As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                                        If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("REQ_NO") = rs_PKESDTL.Tables("RESULT").Rows(o).Item("ped_reqno") And _
                                        rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_seq") = rs_PKESDTL.Tables("RESULT").Rows(o).Item("ped_reqseq") Then
                                            tmp_found = True
                                        End If
                                    Next

                                    If tmp_found = False Then
                                        rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Insert"
                                    Else
                                        rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Upd"
                                    End If
                                    '''''''''''''''''''''
                                End If

                            End If
                        End If

                        'rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Upd"

                        'gspStr = "sp_select_PKESDTL '" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_cocde") & "','" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("REQ_NO") & "'"
                        'rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                        'If rtnLong <> RC_SUCCESS Then
                        '    Cursor = Cursors.Default
                        '    MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                        '    Exit Sub
                        'End If
                        'rs_PKESDTL.Tables("RESULT").DefaultView.RowFilter = "ped_reqno = '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("REQ_NO") & _
                        '"' and ped_itemno = '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_itmno") & "'" & _
                        '" and ped_assitm = '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_assitmno") & "'" & _
                        '" and ped_colcde = '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_colcde") & "'" & _
                        '" and ped_pkgitem= '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_pkgitm") & "'" & _
                        '" and ped_price= '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_unitprice") & "'"
                        'count_price = rs_PKESDTL.Tables("RESULT").DefaultView.Count

                        'If count_price = 0 Then
                        '    rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Insert"
                        'End If

                    Next
                Next

                '????????????? <> 02
                'rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno = '" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_scno") & "'  and pxd_tono ='" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(i)("pxd_tono") & "'  and cat <>'02'"

                'For j As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                '    For k As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                '        If rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_pkgitm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgitm") And _
                '                Trim(Split(Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_pkgvenno")), "-")(0)) = Trim(Split(Trim(rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgven")), "-")(0)) And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_itmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_itemno") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_assitmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_assitm") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_um") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pckunt") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_inner") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_inrqty") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_master") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_mtrqty") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_hktrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_hkprctrm") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_ftytrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_ftyprctrm") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_trantrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_trantrm") And _
                '                rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("pxd_colcde") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_colcde") Then
                '            rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("Dtl_Act") = "Insert"
                '            rs_LIST_RESULT.Tables("RESULT").DefaultView(j)("EST_Dtl_Act") = "Insert"
                '        End If
                '    Next
                'Next

                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""



            End If

        Next

        'Lbl
        'Dupliacte key datd found, Exception
        'key data found, Insert
        Call check_and_valid_LV3_ordqty()
        Call check_and_valid_LV3_Waste()

        Call get_reqno_and_check_estttl()

        '''Here for checking est dtl and est hdt ttl validation
        ''' 
        '''Here check AUR ,  : _dup
        ''' 
        Call check_and_valid_LV3_AUR()

        Call check_and_valid_LV3_waste_empty()
        Call cal_Waste()

    End Sub



    Private Function CheckExistPKG(ByVal type As String, ByVal ordno As String, ByVal cboCoCde_Text_value As String) As Integer

        If type = "TO" Then

            gspStr = "sp_select_EXISTPKG_excelupload'" & cboCoCde_Text_value & "','" & ordno & "','" & type & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CheckExistPKG sp_select_EXISTPKG_excelupload :" & rtnStr)
                Exit Function
            End If

            If rs.Tables("RESULT").Rows.Count <> 0 Then
                If rs.Tables("RESULT").Rows(0).Item("CountedData") = "0" Then

                    Return 3
                    Exit Function
                ElseIf rs.Tables("RESULT").Rows(0).Item("CountedData") = "1" Then
                    If IsDBNull(rs.Tables("RESULT").Rows(0).Item("prh_ReqNo")) Then
                        'new


                        Return 1
                        Exit Function
                    Else 'UPD


                        Return 2
                        Exit Function
                    End If


                End If


            End If

        ElseIf type = "SC" Then

            gspStr = "sp_select_EXISTPKG_excelupload'" & cboCoCde_Text_value & "','" & ordno & "','" & type & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CheckExistPKG sp_select_EXISTPKG_excelupload :" & rtnStr)
                Exit Function
            End If

            If rs.Tables("RESULT").Rows.Count <> 0 Then
                If rs.Tables("RESULT").Rows(0).Item("CountedData") = "0" Then

                    '                    MsgBox("Sc not found")
                    Return 3
                    Exit Function
                ElseIf rs.Tables("RESULT").Rows(0).Item("CountedData") = "1" Then

                    If IsDBNull(rs.Tables("RESULT").Rows(0).Item("prh_ReqNo")) Then
                        'new


                        Return 1
                        Exit Function
                    Else 'UPD


                        Return 2
                        Exit Function
                    End If

                End If


            End If
            '    Return True
        End If

        Return True


    End Function

    Sub gen_LV1()
        Dim tmp_cocde As String
        Dim tmp_sc As String
        Dim tmp_to As String
        Dim temp_retuen As Integer


        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1

            If rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "New" Then
                'gen doc
                'call level2 (est)/insert

                'call level3 Insert
            ElseIf rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("ACT") = "Upd" Then
                'upd hdr
                'call level2 (est) Insert/Upd

                'call level3 Insert/Upd
            End If

        Next

    End Sub

    Private Function FindReqBySCTO(ByVal tmp_CoCde As String, ByVal SCTO As String, ByVal type As String) As String
        gspStr = "sp_select_PKREQHDR_SCTO '" & tmp_CoCde & "','" & SCTO & "','" & type & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FindReqBySCTO sp_select_PKREQHDR_SCTO :" & rtnStr)
            Exit Function
        End If

        Dim reqno As String = ""
        If rs.Tables("RESULT").Rows.Count <> 0 Then
            reqno = rs.Tables("RESULT").Rows(0).Item(0)
        Else
            'MsgBox("Request No. not found , Please check.")
            'Exit Sub
        End If

        FindReqBySCTO = reqno


    End Function

    Private Function FindMaxESDDTLSeq(ByVal tmp_reqno As String, ByVal tmp_itmno As String, ByVal tmp_assitm As String, ByVal tmp_colcde As String) As Integer
        gspStr = "sp_select_PKESTDTL_maxseq '" & tmp_reqno & "','" & tmp_itmno & "','" & tmp_assitm & "','" & tmp_colcde & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FindReqBySCTO sp_select_PKREQHDR_SCTO :" & rtnStr)
            Exit Function
        End If

        Dim maxseq As Integer
        If rs.Tables("RESULT").Rows.Count <> 0 Then
            maxseq = rs.Tables("RESULT").Rows(0).Item(0)
        Else
            maxseq = 0
            'MsgBox("Request No. not found , Please check.")
            'Exit Sub
        End If

        FindMaxESDDTLSeq = maxseq


    End Function

    Private Function FindMaxSeqBySCTO(ByVal tmp_CoCde As String, ByVal SCTO As String) As Integer
        gspStr = "sp_select_PKREQHDR_SCTO_maxseq '" & tmp_CoCde & "','" & SCTO & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FindReqBySCTO sp_select_PKREQHDR_SCTO :" & rtnStr)
            Exit Function
        End If

        Dim maxseq As Integer
        If rs.Tables("RESULT").Rows.Count <> 0 Then
            maxseq = rs.Tables("RESULT").Rows(0).Item(0)
        Else
            'MsgBox("Request No. not found , Please check.")
            'Exit Sub
        End If

        FindMaxSeqBySCTO = maxseq


    End Function


    Private Function save_PKREQHDR() As Boolean
        Dim cocde As String
        Dim reqno As String
        Dim ver As Integer
        Dim issdat As String
        Dim revdat As String
        Dim status As String
        Dim cus1no As String
        Dim cus2no As String
        Dim saldiv As String
        Dim saltem As String
        Dim salrep As String
        Dim ToNo As String
        Dim ToVer As String
        Dim ToSts As String
        Dim ToIsdat As Object
        Dim ToRevdat As Object
        Dim ToRefqut As String
        Dim potyp As String
        Dim ScNo As String
        Dim ScVer As String
        Dim ScSts As String
        Dim ScIsdat As Object
        Dim ScRevdat As Object
        Dim ScPodat As Object
        Dim ScCandat As Object
        Dim ScShpDatstr As Object
        Dim ScShpdatend As Object
        Dim ScRemark As String

        Dim NewNO As String

        Dim pxd_cocde As String

        rs_LIST_RESULT_copy = rs_LIST_RESULT.Copy

        txtReqNo.Text = ""

        ' ''For index As Integer = 0 To rs_LIST_RESULT_copy.Tables("RESULT").Rows.Count - 1
        ' ''    txtReqNo.Text = txtReqNo.Text & rs_LIST_RESULT_copy.Tables("RESULT").Rows(index)("HDR_ACT") & vbCrLf
        ' ''    txtReqNo.Text = txtReqNo.Text & rs_LIST_RESULT_copy.Tables("RESULT").Rows(index)("REQ_NO") & vbCrLf
        ' ''    txtReqNo.Text = txtReqNo.Text & vbCrLf

        ' ''Next
        ' ''btcPGXLS001.SelectedIndex = 2
        ' ''btcPGXLS001.TabPages(0).Enabled = True
        ' ''btcPGXLS001.TabPages(1).Enabled = False
        ' ''btcPGXLS001.TabPages(2).Enabled = True
        ' ''Exit Function


        ''Req#
        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid")) <> "N" Then
                'check all gene = Y
                If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) <> "" Then
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'  and GEN= 'Y'  "
                    'set var
                    If rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count = 0 Then
                        GoTo Next_step
                        ''''''''''''''''''''
                    End If
                Else
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'  and GEN= 'Y' "
                    'set var
                    If rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count = 0 Then
                        GoTo Next_step
                        ''''''''''''''''''''
                    End If
                End If



                ''sc or to     
                If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) <> "" Then
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'"
                    'set var
                    txtScNo_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_scno")
                    cboCoCde_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cocde")
                    cboPriCust_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus1no")
                    '   cboSecCust_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus2o")
                    txtScNo_KeyPress_h()
                Else
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'"
                    'set var
                    txtToNo_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_tono")
                    cboCoCde_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cocde")
                    cboPriCust_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus1no")
                    'cboSecCust_Text = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus2o")
                    txtToNo_KeyPress_h()
                End If

                If rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("Hdr_Act") = "New" Then

                    'gen doc
                    'Insert hdr

                    pxd_cocde = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_cocde")

                    'gen by #of dataset
                    gspStr = "sp_select_DOC_GEN '" & pxd_cocde & "','KR','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                        Exit Function
                    End If

                    NewNO = rs.Tables("RESULT").Rows(0).Item(0)

                    'For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                    '    rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_reqno") = NewNO
                    'Next

                    cocde = pxd_cocde
                    reqno = NewNO
                    rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("REQ_NO") = reqno

                    For n As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno") = rs_LIST_RESULT.Tables("RESULT").Rows(n)("pxd_scno") And _
                         rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono") = rs_LIST_RESULT.Tables("RESULT").Rows(n)("pxd_tono") Then
                            rs_LIST_RESULT.Tables("RESULT").Rows(n)("REQ_NO") = reqno

                        End If
                    Next

                    ver = 1
                    issdat = DateTime.Now.ToShortDateString  '?
                    revdat = DateTime.Now.ToShortDateString
                    status = "OPE"
                    cus1no = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus1no")
                    cus2no = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("pxd_cus2no")
                    '   saldiv = Split(txtSalesDiv_Text, " ")(1)

                    Try
                        ' saltem = Split(txtSalesDiv_Text, " ")(3).Substring(0, 1)

                    Catch
                    End Try

                    salrep = Split(cboSalesRep_Text, " - ")(0)
                    ToNo = txtToNo_Text
                    ToVer = txtToVer_Text
                    ToSts = "REL"

                    If txtToIssDate_Text <> "" Then
                        ToIsdat = txtToIssDate_Text
                    Else
                        ToIsdat = DBNull.Value
                    End If

                    If txtToRevDate_Text <> "" Then
                        ToRevdat = txtToRevDate_Text
                    Else
                        ToRevdat = DBNull.Value
                    End If


                    ToRefqut = txtRefQuot_Text

                    potyp = ""
                    ScNo = txtScNo_Text
                    ScVer = txtScVer_Text
                    ScSts = "REL"

                    If txtScIssDat_Text <> "" Then
                        ScIsdat = txtScIssDat_Text
                    Else
                        ScIsdat = DBNull.Value
                    End If

                    If txtScRevDate_Text <> "" Then
                        ScRevdat = txtScRevDate_Text
                    Else
                        ScRevdat = DBNull.Value
                    End If

                    If txtCustPoDate_Text <> "" Then
                        ScPodat = txtCustPoDate_Text
                    Else
                        ScPodat = DBNull.Value

                    End If

                    If txtScCancelDate_Text <> "" Then
                        ScCandat = txtScCancelDate_Text
                    Else
                        ScCandat = DBNull.Value
                    End If


                    If txtScShipDateStr_Text <> "" Then
                        ScShpDatstr = txtScShipDateStr_Text
                    Else
                        ScShpDatstr = DBNull.Value
                    End If

                    If txtScShipDateEnd_Text <> "" Then
                        ScShpdatend = txtScShipDateEnd_Text
                    Else
                        ScShpdatend = DBNull.Value
                    End If


                    ScRemark = Replace(txtScRemark_Text, "'", "''")
                    If ScNo <> "" Then '???
                        ToVer = ""
                        ToSts = ""
                        ToIsdat = "01/01/1900"
                        ToRevdat = "01/01/1900"
                        ToRefqut = ""
                        '[prh_ToVer] [nvarchar](20) NULL,
                        '[prh_ToSts] [nvarchar](20) NULL,
                        '[prh_ToIsdat] [datetime] NULL,
                        '[prh_ToRevdat] [datetime] NULL,
                        '[prh_ToRefqut] [nvarchar](20) NULL,

                    End If
                    If ToNo <> "" Then '???
                        ScVer = ""
                        ScSts = ""
                        ScIsdat = ""
                        ScRevdat = ""
                        ScPodat = ""
                        ScCandat = ""
                        ScShpDatstr = ""
                        ScShpdatend = ""
                        ScRemark = ""
                        '[prh_ScVer] [nvarchar](20) NULL,
                        '[prh_ScSts] [nvarchar](20) NULL,
                        '[prh_ScIsdat] [datetime] NULL,
                        '[prh_ScRevdat] [datetime] NULL,
                        '[prh_ScPodat] [datetime] NULL,
                        '[prh_ScCandat] [datetime] NULL,
                        '[prh_ScShpdatstr] [datetime] NULL,
                        '[prh_ScShpdatend] [datetime] NULL,
                        '[prh_ScRemark] [nvarchar](300) NULL,

                    End If



                    gspStr = "sp_insert_PKREQHDR '" & cocde & "','" & reqno & "'," & ver & ",'" & issdat & "','" & revdat & "','" & _
                                                        status & "','" & cus1no & "','" & cus2no & "','" & saldiv & "','" & saltem & "','" & _
                                                        salrep & "','" & ToNo & "','" & ToVer & "','" & ToSts & "','" & ToIsdat & "','" & _
                                                        ToRevdat & "','" & ToRefqut & "','" & potyp & "','" & ScNo & "','" & ScVer & "','" & _
                                                        ScSts & "','" & ScIsdat & "','" & ScRevdat & "','" & ScPodat & "','" & ScCandat & "','" & _
                                                        ScShpDatstr & "','" & ScShpdatend & "','" & ScRemark & "','" & "02" & "','" & gsUsrID & "'"


                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_TOORDHDR sp_insert_TOORDHDR :" & rtnStr)
                        save_PKREQHDR = False
                        Exit Function
                    End If

                    msg = msg & vbCrLf
                    msg = msg & Environment.NewLine
                    msg = msg & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
                    msg = msg & "Company: " & cocde & vbCrLf
                    msg = msg & "Packaging Request# (New): " & reqno & vbCrLf
                    msg = msg & Environment.NewLine

                    msg2 = msg2 & vbCrLf
                    msg2 = msg2 & Environment.NewLine
                    msg2 = msg2 & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
                    msg2 = msg2 & "Company: " & cocde & vbCrLf
                    msg2 = msg2 & "Packaging Request# (New): " & reqno & vbCrLf
                    msg2 = msg2 & Environment.NewLine

                    msg3 = msg3 & "Packaging Request# (New): " & reqno & vbCrLf

                Else 'UPD HDR
                    pxd_cocde = rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_cocde")
                    cocde = pxd_cocde
                    reqno = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView(0)("REQ_NO")

                    msg = msg & vbCrLf
                    msg = msg & Environment.NewLine
                    msg = msg & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
                    msg = msg & "Company: " & cocde & vbCrLf
                    msg = msg & "Packaging Request# (Update): " & reqno & vbCrLf
                    msg = msg & Environment.NewLine


                    msg2 = msg2 & vbCrLf
                    msg2 = msg2 & Environment.NewLine
                    msg2 = msg2 & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
                    msg2 = msg2 & "Company: " & cocde & vbCrLf
                    msg2 = msg2 & "Packaging Request# (Update): " & reqno & vbCrLf
                    msg2 = msg2 & Environment.NewLine

                    msg3 = msg3 & "Packaging Request# (Update): " & reqno & vbCrLf

                    '-call sp_select_dtl
                    '-call sp_select_est_hdr
                    '-call sp_select_est_dtl
                    gspStr = " sp_select_PKREQDTL '" & cboCoCde_Text & "','" & reqno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_PKREQDTL, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading cmdFind_Click sp_select_PKREQDTL :" & rtnStr)
                        Exit Function
                    End If

                    '
                    gspStr = "sp_select_PKESHDR '" & pxd_cocde & "','" & reqno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                        Exit Function
                    End If
                    For j As Integer = 0 To rs_PKESHDR.Tables("result").Columns.Count - 1
                        rs_PKESHDR.Tables("RESULT").Columns(j).ReadOnly = False
                    Next

                    gspStr = "sp_select_PKESDTL '" & pxd_cocde & "','" & reqno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                        Exit Function
                    End If
                    For j As Integer = 0 To rs_PKESDTL.Tables("result").Columns.Count - 1
                        rs_PKESDTL.Tables("RESULT").Columns(j).ReadOnly = False
                    Next

                End If

                '
                'loop for same REQ#
                If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) <> "" Then
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'"
                    ''txtScNo_KeyPress_d(Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")))
                Else
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'"
                    ''txtToNo_KeyPress_d(Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")))
                End If


                '                Call cal_Waste()
                If save_PKREQDTL(reqno) = False Then
                    Exit Function

                End If

                txtReqno_Text = reqno



                'set df 
                ''                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO= '" & reqno & "'"

                If save_PKESHDR() = True Then
                Else
                    MsgBox("Product Item Estimated Cost Record Save Fail!")
                    Exit Function
                End If


            End If

Next_step:

        Next

        btcPGXLS001.SelectedIndex = 2
        btcPGXLS001.TabPages(0).Enabled = True
        btcPGXLS001.TabPages(1).Enabled = False
        btcPGXLS001.TabPages(2).Enabled = True

        msg3 = msg3 & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
        msg3 = msg3 & "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbCrLf
        msg2 = msg3 + msg2

        If msg = "" Then
            ' Call cmdClear_Click(sender, e)
            txtReqNo.Text = "No Packaging Request has been Created/Updated."
        Else
            'Call cmdClear_Click(sender, e)
            txtReqNo.Text = msg2
            'MsgBox(msg)
        End If


        '''''''''''''''''''''''
        'for those header act = "NEw"
        'gen & insert

        ''''''''''call the dtl 

        ''''''''hdr loop



        'If mode <> "ADD" Then

        '    For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
        '        rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_reqno") = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_reqno")
        '    Next

        '    save_PKREQHDR = True
        '    Exit Function
        'End If
        '''''''''''''''''''''''''''use

        save_PKREQHDR = True

    End Function



    Private Function save_PKREQDTL(ByVal reqno As String) As Boolean

        '''''''''''''''''''''''
        'for those dtl act = "Insert"
        'get req# & insert

        '''''''''''''''''''''''
        'for those dtl act = "upd"
        'upd



        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count = 0 Then
            save_PKREQDTL = True
            Exit Function
        End If

        Dim cocde As String
        '       Dim reqno As String
        Dim seq As Integer
        Dim itemno As String
        Dim assitm As String
        Dim tmpitmno As String
        Dim venno As String
        Dim venitm As String
        Dim pckunt As String
        Dim inrqty As Integer
        Dim mtrqty As Integer
        Dim cft As Decimal
        Dim colcde As String
        Dim conftr As Integer
        Dim ftyprctrm As String
        Dim hkprctrm As String
        Dim trantrm As String
        Dim pkgitm As String
        Dim pkgven As String
        Dim cate As String
        Dim chndsc As String
        Dim engdsc As String
        Dim remark As String
        Dim EinchL As Decimal
        Dim EinchW As Decimal
        Dim EinchH As Decimal
        Dim EcmL As Decimal
        Dim EcmW As Decimal
        Dim EcmH As Decimal
        Dim FinchL As Decimal
        Dim FinchW As Decimal
        Dim FinchH As Decimal
        Dim FcmL As Decimal
        Dim FcmW As Decimal
        Dim FcmH As Decimal
        Dim matral As String
        Dim tiknes As String
        Dim prtmtd As String
        Dim clrfot As String
        Dim clrbck As String
        Dim finish As String
        Dim matdsc As String
        Dim tckdsc As String
        Dim prtdsc As String
        'Dim finfot As String
        'Dim finbck As String
        Dim rmtnce As String
        Dim addres As String
        Dim state As String
        Dim cntry As String
        Dim zip As String
        Dim Tel As String
        Dim cntper As String
        Dim sctoqty As Integer
        Dim qtyum As String
        Dim curcde As String
        Dim multip As Integer
        Dim ordqty As Integer
        Dim wasper As Decimal
        Dim wasqty As Integer
        Dim ttlordqty As Integer
        Dim untprc As Decimal
        Dim ttlamtqty As Decimal
        Dim receqty As Integer
        Dim quoteprice As Decimal
        Dim ScToNo As String
        Dim ScToSeq As Integer
        Dim sku As String
        Dim cusitm As String
        Dim bonqty As Integer
        Dim Dtl_Act As String

        Dim est_flag As String
        Dim tmp_counter As Integer
        Dim tmp_counter_u As Integer
        Dim is_r As String

        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("GEN")) = "Y" Then

                Dtl_Act = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("Dtl_Act")

                If UCase(Dtl_Act) = UCase("Insert") Then

                    cocde = cboCoCde_Text
                    '                reqno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_reqno")
                    dr = rs_LIST_RESULT_scto.Tables("RESULT").Select("REQ_NO ='" & reqno & "'")
                    If dr.Length > 0 Then
                        seq = dr(0)("maxseq") + 1
                    Else
                        seq = 1
                    End If

                    'update
                    For l As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT_scto.Tables("RESULT").Rows(l)("REQ_NO") = reqno Then
                            rs_LIST_RESULT_scto.Tables("RESULT").Rows(l)("maxseq") = seq
                        End If
                    Next

                    rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_seq") = seq

                    itemno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_itmno")
                    assitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_assitmno")
                    pckunt = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_um")
                    inrqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_inner")
                    mtrqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_master")
                    colcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_colcde")
                    ftyprctrm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ftytrm")
                    hkprctrm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_hktrm")
                    trantrm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_trantrm")
                    pkgitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_pkgitm")
                    pkgven = Trim(Split(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_pkgvenno"), " - ")(0))

                    '-call txt_ or call sp________
                    ''sc or to     
                    'filter for SC/TO other detail
                    dr = rs_TOSCDETAIL.Tables("RESULT").Select("realitem = '" & _
                                                                itemno & "' and " & _
                                                              " assitem = '" & assitm & "' and " & _
                                                              "colcde = '" & colcde & "' and " & _
                                                              "um = '" & pckunt & "' and " & _
                                                              "inr = '" & inrqty & "' and " & _
                                                              "mst = '" & mtrqty & "'")

                    cusitm = dr(0)("custitm")
                    sku = dr(0)("sku")
                    tmpitmno = dr(0)("tempitem")
                    venitm = dr(0)("venitem")
                    venno = dr(0)("venitemno")
                    conftr = dr(0)("conftr")
                    sctoqty = dr(0)("ScQty")
                    cft = dr(0)("cft")
                    ScToSeq = dr(0)("seq")
                    sku = dr(0)("sku")
                    cusitm = dr(0)("custitm")


                    rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpitmno") = tmpitmno
                    rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpvenno") = venno
                    rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpvenitmno") = venitm

                    'Call txtPkgItem_KeyPress(pkgitm)

                    gspStr = "sp_select_PKIMBAIF '" & rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_pkgitm") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_select_PKIMBAIF :" & rtnStr)
                        Exit Function
                    End If

                    If rs_PKIMBAIF.Tables("RESULT").Rows.Count <> 0 Then


                        cate = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate")
                        'cate = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate") + " - " + rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("ypc_pakna")
                        chndsc = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc")
                        engdsc = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc")
                        remark = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark")

                        EinchH = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
                        EinchW = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW")
                        EinchL = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL")

                        EcmH = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH")
                        EcmW = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW")
                        EcmL = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL")

                        FinchH = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchH")
                        FinchL = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL")
                        FinchW = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchW")

                        FcmH = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH")
                        FcmL = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL")
                        FcmW = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW")

                        matral = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral")
                        tiknes = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes")
                        prtmtd = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd")
                        clrfot = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot")
                        clrbck = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck")
                        finish = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish")
                        'txtForntFin_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finfot")
                        'txtBackFin_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finbck")

                        matdsc = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc")
                        tckdsc = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc")
                        prtdsc = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc")

                        est_flag = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_estflg")
                        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = txtCate_Text

                        ''''''''            txtPkgItem_Text = UCase(txtPkgItem_Text
                        txtPkgOrdQty_Text = 0
                        txtPkgUnitPri_Text = 0
                        txtPkgTtlQty_Text = 0
                        txtTtlAmt_Text = 0
                        txtQuotePrice_Text = 0
                        '''''''''''''''''''''''
                    End If
                    ''''''''''''''''''''''''''Call cboPkgVendor_SelectedIndexChanged()
                    ' Dim dr() As DataRow
                    dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & pkgven & "'")

                    'rmtnce???

                    If dr.Length <> 0 Then
                        addres = dr(0)("vci_address").ToString
                        state = dr(0)("vci_stt").ToString
                        cntry = dr(0)("vci_cty").ToString
                        zip = dr(0)("vci_zip").ToString
                        'Tel = dr(0)("vci_cntphn").ToString '???
                        'cntper = dr(0)("vci_cntctp").ToString '???
                        curcde = dr(0)("vbi_curcde").ToString
                        'txtTtlAmtCur_Text = dr(0)("vbi_curcde").ToString
                        'txtQuoteCur_Text = dr(0)("vbi_curcde").ToString


                    End If


                    Dim dr_Ctnper() As DataRow
                    dr_Ctnper = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & pkgven & "'")

                    cboPkgCtnPer_text = ""
                    If dr_Ctnper.Length <> 0 Then
                        cntper = dr_Ctnper(0)("vci_cntctp")
                    End If

                    Dim dr_tel() As DataRow
                    dr_tel = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & pkgven & "' and vci_cntctp = '" & cboPkgCtnPer_text & "'")
                    If dr_tel.Length <> 0 Then
                        Tel = dr_tel(0)("vci_cntphn")
                    Else
                        txtTel_Text = ""
                    End If
                    '''''''''''''''''
                    'update_PKREQDTL()
                    sctoqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scordqty")
                    ''  qtyum = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_qtyum")
                    ''from sc ???
                    curcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cur")
                    multip = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_multiplier") 'care txtPkgMult.Text
                    ordqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ordqty")
                    ''wasper = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_wasper")
                    ''from  ???
                    wasqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_waste")
                    ''from ??
                    ttlordqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ttlordqty")
                    ''by cal
                    untprc = round(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_unitprice"), 5)
                    ttlamtqty = round(ttlordqty * untprc, 2)
                    ''by cal
                    receqty = 0 'rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_receqty")   '*
                    quoteprice = 0 ' rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_salprc")
                    If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scno")) <> "" Then
                        ScToNo = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scno")
                    Else
                        ScToNo = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tono")
                    End If

                    '                    ScToSeq = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ScToSeq")

                    '                    sku = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_sku")
                    '                   cusitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cusitm")
                    '   bonqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_bonqty")
                    bonqty = wasqty  '???



                    'rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_creusr") = cboCoCde_Text



                    gspStr = "sp_insert_PKREQDTL '" & cocde & "','" & reqno & "'," & seq & ",'" & itemno & "','" & assitm & "','" & tmpitmno & "','" & _
                                               venno & "','" & venitm & "','" & pckunt & "'," & inrqty & "," & mtrqty & "," & cft & ",'" & colcde & "'," & conftr & ",'" & _
                                               ftyprctrm & "','" & hkprctrm & "','" & trantrm & "','" & pkgitm & "','" & pkgven & "','" & _
                                               cate & "','" & chndsc & "','" & engdsc & "','" & remark & "'," & EinchL & "," & _
                                               EinchW & "," & EinchH & "," & EcmL & "," & EcmW & "," & EcmH & "," & _
                                               FinchL & "," & FinchW & "," & FinchH & "," & FcmL & "," & FcmW & "," & _
                                                  FcmH & ",'" & matral & "','" & tiknes & "','" & prtmtd & "','" & clrfot & "','" & _
                                               clrbck & "','" & finish & "','" & matdsc & "','" & tckdsc & "','" & prtdsc & "','" & rmtnce & "','" & addres & "','" & state & "','" & _
                                               cntry & "','" & zip & "','" & Tel & "','" & cntper & "'," & sctoqty & ",'" & _
                                               qtyum & "','" & curcde & "'," & multip & "," & ordqty & "," & wasper & "," & _
                                               wasqty & "," & ttlordqty & "," & untprc & "," & ttlamtqty & "," & receqty & ",'" & "02" & "'," & quoteprice & ",'" & _
                                               ScToNo & "'," & ScToSeq & ",'" & sku & "','" & cusitm & "'," & bonqty & ",'" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_PKREQDTL sp_insert_PKREQDTL :" & rtnStr)
                        save_PKREQDTL = False
                        Exit Function
                    End If

                    msg = msg & "  Detail (Insert):   Seq/item#/Assortment#/UM/inner/master/FtyTrm/HKTrm/Transtrm/Colcde/Pck Item#/Printer#/Cur/Unit Price/OrdQty/Waste/TtlQty" & vbCrLf
                    msg = msg & "                             " & seq & "/" & itemno & "/" & assitm & "/" & pckunt & "/" & inrqty & "/" & mtrqty & "/" & hkprctrm & "/" & hkprctrm & "/" & trantrm & "/" & colcde & "/" & pkgitm & "/" & pkgven & "/" & curcde & "/" & untprc & "/" & ordqty & "/" & wasqty & "/" & ttlordqty & vbCrLf

                    tmp_counter = tmp_counter + 1

                ElseIf UCase(Dtl_Act) = UCase("Upd") Then
                    tmp_counter_u = tmp_counter_u + 1

                    '- get from dase
                    '                               Trim(Split(Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_pkgvenno")), "-")(0)) = Trim(Split(Trim(rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgven")), "-")(0)) And _

                    For k As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                        If rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_pkgitm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pkgitm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_itmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_itemno") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_assitmno") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_assitm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_um") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_pckunt") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_inner") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_inrqty") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_master") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_mtrqty") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_hktrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_hkprctrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_ftytrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_ftyprctrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_trantrm") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_trantrm") And _
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_colcde") = rs_PKREQDTL.Tables("RESULT").Rows(k)("prd_colcde") Then

                            'rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("Dtl_Act") = "Upd"

                            cocde = cboCoCde_Text
                            '                reqno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_reqno")
                            seq = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_seq")
                            itemno = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_itemno")
                            assitm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_assitm")
                            tmpitmno = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_tmpitmno")
                            venno = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_venno")
                            venitm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_venitm")
                            pckunt = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_pckunt")
                            inrqty = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_inrqty")
                            mtrqty = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_mtrqty")
                            cft = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_cft")
                            colcde = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_colcde")
                            conftr = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_conftr")
                            ftyprctrm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_ftyprctrm")
                            hkprctrm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_hkprctrm")
                            trantrm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_trantrm")
                            pkgitm = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_pkgitm")

                            pkgven = Trim(Split(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_pkgvenno"), " - ")(0))
                            '''  pkgven = Split(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_pkgven"), " - ")(0)

                            cate = Split(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_cate"), " - ")(0)
                            chndsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_chndsc"), "'", "''")
                            engdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_engdsc"), "'", "''")
                            remark = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_remark"), "'", "''")
                            EinchL = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EInchL")
                            EinchW = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EInchW")
                            EinchH = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EInchH")
                            EcmL = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EcmL")
                            EcmW = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EcmW")
                            EcmH = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_EcmH")
                            FinchL = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FInchL")
                            FinchW = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FinchW")
                            FinchH = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FinchH")
                            FcmL = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FcmL")
                            FcmW = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FcmW")
                            FcmH = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_FcmH")
                            matral = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_matral"), "'", "''")
                            tiknes = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_tiknes"), "'", "''")
                            prtmtd = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_prtmtd"), "'", "''")
                            clrfot = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_clrfot"), "'", "''")
                            clrbck = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_clrbck"), "'", "''")
                            finish = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_finish"), "'", "''")
                            matdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_matDsc"), "'", "''")
                            tckdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_tikDsc"), "'", "''")
                            prtdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_prtDsc"), "'", "''")
                            'finfot = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_finfot")
                            'finbck = rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_finbck")
                            rmtnce = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_rmtnce"), "'", "''")
                            addres = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_addres"), "'", "''")
                            state = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_state"), "'", "''")
                            cntry = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_cntry"), "'", "''")
                            zip = Replace(rs_PKREQDTL.Tables("RESULT").Rows(k).Item("prd_zip"), "'", "''")

                            'printer
                            Dim dr_Ctnper() As DataRow
                            dr_Ctnper = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & pkgven & "'")

                            cboPkgCtnPer_text = ""
                            If dr_Ctnper.Length <> 0 Then
                                cntper = dr_Ctnper(0)("vci_cntctp")
                            End If

                            Dim dr_tel() As DataRow
                            dr_tel = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & pkgven & "' and vci_cntctp = '" & cboPkgCtnPer_text & "'")
                            If dr_tel.Length <> 0 Then
                                Tel = dr_tel(0)("vci_cntphn")
                            Else
                                txtTel_Text = ""
                            End If
                            '''''''''''''''''
                            'update_PKREQDTL()
                            sctoqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scordqty")
                            ''  qtyum = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_qtyum")
                            ''from sc ???
                            curcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cur")
                            multip = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_multiplier") 'care txtPkgMult.Text
                            ordqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ordqty")
                            ''wasper = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_wasper")
                            ''from  ???
                            wasqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_waste")
                            ''from ??
                            ttlordqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_ttlordqty")
                            ''by cal
                            untprc = round(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_unitprice"), 5)
                            ttlamtqty = round(ttlordqty * untprc, 2)
                            ''by cal
                            receqty = 0 'rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_receqty")   '*
                            quoteprice = 0 ' rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_salprc")
                            If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scno")) <> "" Then
                                ScToNo = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_scno")
                            Else
                                ScToNo = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tono")
                            End If

                            ScToSeq = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_seq")
                            sku = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cussku")
                            cusitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cusitmno")
                            ' bonqty = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_bonqty")
                            bonqty = wasqty  '???


                            '                            cresur = "~*UPD*~"

                        Else
                            '     MsgBox("Detail not found!")
                            '    Exit Function
                        End If
                    Next



                    gspStr = "sp_update_PKREQDTL '" & cocde & "','" & reqno & "'," & seq & "," & multip & "," & ordqty & "," & wasper & "," & _
                                              wasqty & "," & ttlordqty & "," & untprc & "," & ttlamtqty & "," & receqty & ",'" & pkgven & "'," & _
                                              quoteprice & ",'" & cntper & "','" & Tel & "','" & curcde & "'," & bonqty & ",'" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_PKREQDTL sp_update_PKREQDTL :" & rtnStr)
                        save_PKREQDTL = False
                        Exit Function
                    End If
                    msg = msg & "  Detail (Update):   Seq/item#/Assortment#/UM/inner/master/FtyTrm/HKTrm/Transtrm/Colcde/Pck Item#/Printer#/Cur/Unit Price/OrdQty/Waste/TtlQty" & vbCrLf
                    msg = msg & "                             " & seq & "/" & itemno & "/" & assitm & "/" & pckunt & "/" & inrqty & "/" & mtrqty & "/" & hkprctrm & "/" & hkprctrm & "/" & trantrm & "/" & colcde & "/" & pkgitm & "/" & pkgven & "/" & curcde & "/" & untprc & "/" & ordqty & "/" & wasqty & "/" & ttlordqty & vbCrLf

                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_act") = "R" Then
                        is_r = "Re-Print "
                    Else
                        is_r = ""
                    End If


                End If


            End If

        Next

        If tmp_counter <> 0 Then
            msg2 = msg2 & tmp_counter & "  detail  created " & vbCrLf
        End If
        If tmp_counter_u <> 0 Then
            msg2 = msg2 & tmp_counter_u & "  detail updated successfully " & vbCrLf
        End If



        save_PKREQDTL = True




    End Function

    Private Function save_PKESHDR() As Boolean

        Dim rs_LIST_RESULT_cal As DataSet
        Dim rs_LIST_RESULT_compare As DataSet
        Dim rs_LIST_RESULT_check As DataSet

        Dim tmp_est_sum As Decimal
        Dim tmp_found_count As Integer

        rs_LIST_RESULT_cal = rs_LIST_RESULT.Copy
        rs_LIST_RESULT_compare = rs_LIST_RESULT.Copy

        '''''''''''''''''''''''
        'for those hdr act = "Insert"
        '& insert

        '''''''''''''''''''''''
        'for those hdr act = "upd"
        'upd

        ''''''''''''''''''call dtl
        ''''''''''''''''''loop
        Dim realitem As String
        Dim assitem As String
        Dim colcde As String

        Dim tmpitmno As String
        Dim venno As String
        Dim venitm As String

        gspStr = "sp_select_PKESHDR '" & cboCoCde.Text & "','" & "@!#@!#!@#" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR_construct, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
            Exit Function
        End If
        For i2 As Integer = 0 To rs_PKESHDR_construct.Tables("RESULT").Columns.Count - 1
            rs_PKESHDR_construct.Tables("RESULT").Columns(i2).ReadOnly = False
        Next i2

        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If i <= rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1 Then
                If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("GEN")) = "Y" Then


                    realitem = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_itmno")
                    assitem = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_assitmno")
                    colcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_colcde")

                    tmpitmno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpitmno")
                    venno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpvenno")
                    venitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpvenitmno")

                    Dim dr_PKESHDR() As DataRow




                    'If Not rs_PKESHDR_construct Is Nothing Then
                    '    If Not rs_PKESHDR_construct.Tables("RESULT") Is Nothing Then
                    dr = rs_PKESHDR_construct.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
                                                              "peh_assitm = '" & assitem & "' and " & _
                                                        "peh_colcde = '" & colcde & "'")
                    'End If
                    '    End If

                    If dr.Length = 0 Then
                        Dim rowcount_hdr As Integer
                        rowcount_hdr = rs_PKESHDR_construct.Tables("RESULT").Rows.Count
                        rs_PKESHDR_construct.Tables("RESULT").Rows.Add()

                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_reqno") = txtReqno_Text '2016
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_itemno") = realitem
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_assitm") = assitem
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_tmpitmno") = tmpitmno
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venno") = venno
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venitm") = venitm

                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_colcde") = colcde
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_price") = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_estttl")

                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_curcde") = "HKD"

                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("peh_creusr") = "~*ADD*~"
                        rs_PKESHDR_construct.Tables("RESULT").Rows(rowcount_hdr).Item("est_flag") = ""  'no need?

                    End If
                End If
            End If
        Next

        'check if in the system
        gspStr = "sp_select_PKESHDR '" & cboCoCde_Text & "','" & txtReqno_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
            Exit Function
        End If

        For i As Integer = 0 To rs_PKESHDR_construct.Tables("RESULT").Rows.Count - 1
            Dim dr_PKESHDR() As DataRow


            realitem = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_itemno")
            assitem = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_assitm")
            colcde = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_colcde")



            dr = rs_PKESHDR.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
                                                      "peh_assitm = '" & assitem & "' and " & _
                                                "peh_colcde = '" & colcde & "'")

            If dr.Length <> 0 Then
                rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"

                ''If  is partial update ::
                gspStr = "sp_select_PKESDTL '" & cboCoCde_Text & "','" & txtReqno_Text & "'"
                'cboCoCde_Text  ???
                'ped_reqno  
                rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                    Exit Function
                End If
                rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.RowFilter = "  GEN   = 'Y' and pxd_itmno = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                    " pxd_assitmno = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                            " pxd_colcde = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_colcde") & "' and " & _
                                             rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter
                ''

                rs_PKESDTL.Tables("RESULT").DefaultView.RowFilter = "    ped_itemno  = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                    " ped_assitm = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                            " ped_colcde = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"
                tmp_found_count = 0
                If rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count <> rs_PKESDTL.Tables("RESULT").DefaultView.Count Then
                    For k As Integer = 0 To rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count - 1
                        For l As Integer = 0 To rs_PKESDTL.Tables("RESULT").DefaultView.Count - 1
                            If rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(k)("pxd_pkgitm") = rs_PKESDTL.Tables("RESULT").DefaultView(l)("ped_pkgitem") And _
                             rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(k)("pxd_unitprice") = rs_PKESDTL.Tables("RESULT").DefaultView(l)("ped_price") Then
                                ''need check not 'RE-Print' ???
                                tmp_found_count = tmp_found_count + 1
                            End If
                        Next
                    Next
                    If tmp_found_count < rs_PKESDTL.Tables("RESULT").DefaultView.Count Then
                        rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") = dr(0)("peh_price")
                    End If

                End If
                'ccon sider est hdr with some dtl  in system 

            End If

        Next

        '''Cal EST  for 'New' case
        For i As Integer = 0 To rs_PKESHDR_construct.Tables("RESULT").Rows.Count - 1
            If rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~" Then
                tmp_est_sum = 0
                rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.RowFilter = "   GEN   = 'Y' and pxd_itmno  = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                " pxd_assitmno = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                " pxd_colcde = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_colcde") & "' and " & _
                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter
                ''
                For j As Integer = 0 To rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.Count - 1
                    tmp_est_sum = tmp_est_sum + rs_LIST_RESULT_cal.Tables("RESULT").DefaultView(j)("pxd_estunt")
                Next
                If tmp_est_sum = 0 Then
                Else
                    If 0 = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") Then
                        rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") = tmp_est_sum
                    Else
                        'if <> then error
                    End If
                End If
            End If
        Next


        '''Cal EST  for 'UPD' case
        For i As Integer = 0 To rs_PKESHDR_construct.Tables("RESULT").Rows.Count - 1
            If rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~" Then
                tmp_est_sum = 0
                rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.RowFilter = "   GEN   = 'Y' and pxd_itmno  = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                " pxd_assitmno = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                " pxd_colcde = '" & rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_colcde") & "' and " & _
                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter

                For j As Integer = 0 To rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.Count - 1
                    tmp_est_sum = tmp_est_sum + rs_LIST_RESULT_cal.Tables("RESULT").DefaultView(j)("pxd_estunt")
                Next
                If tmp_est_sum = 0 Then
                Else
                    If 0 = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") Then
                        rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") = tmp_est_sum

                    Else
                        'after valid, if not equal, should be est ttl in system case ???
                        'est dtl: if fully updat, not equal, error
                        '2016
                        If rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") <> rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") + tmp_est_sum Then
                            rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") = rs_PKESHDR_construct.Tables("RESULT").Rows(i)("peh_price") + tmp_est_sum
                        End If
                    End If
                End If
            End If
        Next


        If save_PKESDTL(cboCoCde_Text, txtReqno_Text) = True Then
        Else
            MsgBox("Packaging Item Estimated Cost Record Save Fail!")
            Exit Function
        End If


        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count = 0 Then
            Return True
            Exit Function
        End If


        Dim tmp_counter As Integer


        For i As Integer = 0 To rs_PKESHDR_construct.Tables("RESULT").Rows.Count - 1
            tmp_counter = tmp_counter + 1

            Dim peh_cocde As String
            Dim peh_reqno As String
            Dim peh_itemno As String
            Dim peh_assitm As String
            Dim peh_tmpitmno As String
            Dim peh_venno As String
            Dim peh_venitm As String
            Dim peh_colcde As String
            Dim peh_price As Decimal
            Dim peh_curcde As String
            Dim peh_creusr As String


            peh_cocde = cboCoCde_Text
            peh_reqno = txtReqno_Text '
            peh_itemno = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_itemno").ToString
            peh_assitm = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_assitm").ToString
            peh_tmpitmno = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_tmpitmno").ToString
            peh_venno = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_venno").ToString
            peh_venitm = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_venitm").ToString
            peh_colcde = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_colcde").ToString
            peh_price = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_price")
            peh_curcde = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_curcde")
            peh_creusr = rs_PKESHDR_construct.Tables("RESULT").Rows(i).Item("peh_creusr").ToString

            rs_LIST_RESULT_check = rs_LIST_RESULT.Copy
            'check gene = Y
            rs_LIST_RESULT_check.Tables("RESULT").DefaultView.RowFilter = " pxd_itmno = '" & peh_itemno _
            & "'  and pxd_assitmno ='" & peh_assitm & _
             "'  and pxd_colcde ='" & peh_colcde & _
             "'  and REQ_NO ='" & peh_reqno & "' " & _
            " and  GEN  = 'Y'  "
            'set var
            If rs_LIST_RESULT_check.Tables("RESULT").DefaultView.Count = 0 Then
                GoTo NEXT_STEP
                ''''''''''''''''''''
            End If


            If peh_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_PKESHDR '" & peh_cocde & "','" & peh_reqno & "','" & peh_itemno & "','" & peh_assitm & "','" & peh_tmpitmno & "','" & _
                                                peh_venno & "','" & peh_venitm & "','" & peh_colcde & "'," & peh_price & ",'" & peh_curcde & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESHDR sp_insert_PKESHDR :" & rtnStr)
                    save_PKESHDR = False
                    Exit Function
                End If

                msg = msg & "  Est Header (Insert):    /item#/Assortment#/Colcde/Cur/Price" & vbCrLf
                msg = msg & "                             " & peh_itemno & "/" & peh_assitm & "/" & peh_colcde & "/" & peh_curcde & "/" & peh_price & vbCrLf

                If tmp_counter = 1 Then
                    msg2 = msg2 & vbCrLf & "                        " & "                                                              " & "Currency" & "/" & "Estimated Cost " & vbCrLf
                    msg2 = msg2 & "  Estimated  : " & peh_itemno & "  " & peh_assitm & "  " & peh_colcde & "  " & peh_curcde & "  " & peh_price & " inserted" & vbCrLf
                Else
                    msg2 = msg2 & "                          " & peh_itemno & "  " & peh_assitm & "  " & peh_colcde & "  " & peh_curcde & "  " & peh_price & " inserted" & vbCrLf
                End If


            ElseIf peh_creusr = "~*UPD*~" Then

                gspStr = "sp_update_PKESHDR '" & peh_cocde & "','" & peh_reqno & "','" & peh_itemno & "','" & peh_assitm & "','" & peh_tmpitmno & "','" & _
                                                peh_venno & "','" & peh_venitm & "','" & peh_colcde & "'," & peh_price & ",'" & peh_curcde & "','" & gsUsrID & "'"

                msg = msg & "  Est Header (Update):    /item#/Assortment#/Colcde/Cur/Price" & vbCrLf
                msg = msg & "                                           " & peh_itemno & "/" & peh_assitm & "/" & peh_colcde & "/" & peh_curcde & "/" & peh_price & vbCrLf

                If tmp_counter = 1 Then
                    msg2 = msg2 & vbCrLf & "                        " & "                                                              " & "Currency" & "/" & "Estimated Cost " & vbCrLf
                    msg2 = msg2 & "  Estimated  : " & peh_itemno & "  " & peh_assitm & "  " & peh_colcde & "  " & peh_curcde & "  " & peh_price & " updated" & vbCrLf
                Else
                    msg2 = msg2 & "                          " & peh_itemno & "  " & peh_assitm & "  " & peh_colcde & "  " & peh_curcde & "  " & peh_price & " updated" & vbCrLf
                End If


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESHDR sp_update_PKESHDR :" & rtnStr)
                    save_PKESHDR = False
                    Exit Function
                End If

            End If

NEXT_STEP:

        Next


        save_PKESHDR = True

    End Function


    Private Function save_PKESDTL(ByVal tmp_cboCoCde_Text, ByVal tmp_ped_reqno) As Boolean
        gspStr = "sp_select_PKESDTL '" & tmp_cboCoCde_Text & "','" & tmp_ped_reqno & "'"
        'cboCoCde_Text  ???
        'ped_reqno  
        rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
            Exit Function
        End If


        '''''''''''''''''''''''
        'for those dtl act = "Insert"
        '& insert

        'get est dtl seq

        '''''''''''''''''''''''
        'for those dtl act = "upd"
        'upd

        'no need est dtl seq?
        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count = 0 Then
            Return True
            Exit Function
        End If

        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("Valid")) <> "N" Then
                For j As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                    If rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_seq") = rs_PKESDTL.Tables("RESULT").Rows(j)("ped_reqseq") Then
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_estdtl_seq") = rs_PKESDTL.Tables("RESULT").Rows(j)("ped_seq")
                    End If
                Next
            End If
        Next



        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If Trim(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("GEN")) = "Y" Then

                Dim ped_cocde As String
                Dim ped_reqno As String
                Dim ped_reqseq As Integer
                Dim ped_seq As Integer
                Dim ped_itemno As String
                Dim ped_assitm As String
                Dim ped_tmpitmno As String
                Dim ped_venno As String
                Dim ped_venitm As String
                Dim ped_colcde As String
                Dim ped_pkgitem As String
                Dim ped_price As Decimal
                Dim ped_curcde As String
                Dim ped_creusr As String

                ped_cocde = cboCoCde_Text
                ped_reqno = txtReqno_Text '
                ped_reqseq = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_seq")
                ''
                ped_itemno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_itmno").ToString
                ped_assitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_assitmno").ToString

                ped_tmpitmno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpitmno").ToString
                ped_venno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpvenno").ToString
                ped_venitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_tmpvenitmno").ToString

                ped_colcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_colcde").ToString
                ped_pkgitem = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_pkgitm").ToString
                ped_price = round(rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_unitprice"), 5)
                ped_curcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_cur")
                ped_creusr = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("est_Dtl_Act").ToString

                If UCase(ped_creusr) = UCase("Insert") Then
                    '-set ped_seq 
                    Dim seq As Integer = 1
                    Dim SysMaxSeq As Integer
                    Dim dr_dtl() As DataRow
                    SysMaxSeq = FindMaxESDDTLSeq(ped_reqno, ped_itemno, ped_assitm, ped_colcde)

                    dr_dtl = rs_LIST_RESULT.Tables("RESULT").Select("pxd_itmno = '" & ped_itemno & "' and " & _
                                                             "pxd_assitmno = '" & ped_assitm & "' and " & _
                                                             "REQ_NO = '" & ped_reqno & "' and " & _
                                                       "pxd_colcde = '" & ped_colcde & "'")
                    'should count also from system
                    Dim lagerSeq As Integer = 0
                    For ii As Integer = 0 To dr_dtl.Length - 1
                        If lagerSeq <= dr_dtl(ii)("pxd_estdtl_seq") Then
                            lagerSeq = dr_dtl(ii)("pxd_estdtl_seq")
                        End If
                    Next

                    If SysMaxSeq < lagerSeq Then
                    Else
                        lagerSeq = SysMaxSeq
                    End If
                    seq = lagerSeq + 1
                    ped_seq = seq

                    'upd back
                    rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_estdtl_seq") = ped_seq


                    gspStr = "sp_insert_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
                    ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_PKESDTL sp_insert_PKESDTL :" & rtnStr)
                        save_PKESDTL = False
                        Exit Function
                    End If
                    msg = msg & "  Est Detail (Insert):    Req detail seq/Item#/Assortment#/Colcde/Pck Item#/Seq/Cur/Price" & vbCrLf
                    msg = msg & "                                                " & ped_reqseq & "/" & ped_itemno & "/" & ped_assitm & "/" & ped_colcde & "/" & ped_pkgitem & "/" & ped_seq & "/" & ped_curcde & "/" & ped_price & vbCrLf

                ElseIf UCase(ped_creusr) = UCase("Upd") Then
                    '-set ped_seq 

                    ped_seq = rs_LIST_RESULT.Tables("RESULT").DefaultView(i).Item("pxd_estdtl_seq")


                    gspStr = "sp_update_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
                    ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_PKESDTL sp_update_PKESHDR :" & rtnStr)
                        save_PKESDTL = False
                        Exit Function
                    End If
                    msg = msg & "  Est Detail (Update):    Req detail seq/Item#/Assortment#/Colcde/Pck Item#/Seq/Cur/Price" & vbCrLf
                    msg = msg & "                                                " & ped_reqseq & "/" & ped_itemno & "/" & ped_assitm & "/" & ped_colcde & "/" & ped_pkgitem & "/" & ped_seq & "/" & ped_curcde & "/" & ped_price & vbCrLf


                End If
            End If
        Next

        save_PKESDTL = True

    End Function


    Private Sub txtScNo_KeyPress_h()
        '    Private Sub txtScNo_KeyPress(ByVal txtScNo_Text As String, ByVal cboCoCde_Text As String)
        Cursor = Cursors.WaitCursor
        If CheckExistPKG("SC", txtScNo_Text, cboCoCde_Text) = False Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        pkgtype = "SC"


        gspStr = "sp_select_SCORDHDR_PKG02 '" & cboCoCde_Text & "','" & txtScNo_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDHDR_PKG02 :" & rtnStr)
            Exit Sub
        End If


        If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts") = "CLO" Then
            Cursor = Cursors.Default
            ' MsgBox("SC status is close , action cancel.")
            '  Exit Sub
            '???
        End If



        If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 Then
            '            If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 And rs_TOSCDETAIL.Tables("RESULT").Rows.Count <> 0 Then

            cboPriCust_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus1no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus1name")

            If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus2no") <> "" Then
                cboSecCust_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus2no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus2name")
            Else
                cboSecCust_Text = ""
            End If



            txtSalesDiv_Text = "Division " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_saldiv") + _
            " (TEAM " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_saltem") + ")"
            cboSalesRep_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_srname")


            txtScNo_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordno")
            txtScVer_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_verno")

            'cboScStatus.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts")
            '                display_combo(rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts"), cboScStatus)


            txtScIssDat_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_issdat")

            txtScRevDate_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_rvsdat")
            txtCustPoDate_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cpodat")
            txtScCancelDate_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_candat")
            txtScShipDateStr_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_shpstr")
            txtScShipDateEnd_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_shpend")
            txtScRemark_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_rmk")

            txtHeadScNo_Text = txtScNo_Text


            Cursor = Cursors.Default
        End If


        gspStr = "sp_select_SCORDDTL_PKG02 '" & cboCoCde_Text & "','" & txtScNo_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDDTL_PKG02 :" & rtnStr)
            Exit Sub
        End If


        Cursor = Cursors.Default

    End Sub

    'Private Sub txtScNo_KeyPress_d(ByVal tmp_cboCoCde_Text, ByVal tmp_txtScNo_Text)
    '    '    Private Sub txtScNo_KeyPress(ByVal txtScNo_Text As String, ByVal tmp_cboCoCde_Text As String)
    '    Cursor = Cursors.WaitCursor
    '    If CheckExistPKG("SC", txtScNo_Text, tmp_cboCoCde_Text) = False Then
    '        Cursor = Cursors.Default
    '        Exit Sub
    '    End If

    '    pkgtype = "SC"

    '    gspStr = "sp_select_SCORDDTL_PKG02 '" & tmp_cboCoCde_Text & "','" & tmp_txtScNo_Text & "'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDDTL_PKG02 :" & rtnStr)
    '        Exit Sub
    '    End If

    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_cocde") = cboCoCde.Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_reqno") = ""
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_seq") = txtSeq.Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_itemno") = dgPKGITEM.Item(dgPkgITem_realitem, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_assitm") = dgPKGITEM.Item(dgPkgItem_assitem, dgPKGITEM.CurrentCell.RowIndex).Value


    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_tmpitmno") = dgPKGITEM.Item(dgPkgITem_tempitem, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_venno") = dgPKGITEM.Item(dgPkgITem_venitem, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_venitm") = dgPKGITEM.Item(dgPkgITem_venno, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_colcde") = dgPKGITEM.Item(dgPkgItem_colcde, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_conftr") = dgPKGITEM.Item(dgPkgItem_ConFtr, dgPKGITEM.CurrentCell.RowIndex).Value
    '    rs_PKREQDTL.Tables("RESULT").Rows(Loc).Item("prd_sctoqty") = dgPKGITEM.Item(dgPkgITem_stqty, dgPKGITEM.CurrentCell.RowIndex).Value

    '    Cursor = Cursors.Default
    '    End If

    '    Cursor = Cursors.Default

    'End Sub

    Private Sub txtToNo_KeyPress_h()
        Cursor = Cursors.WaitCursor

        If CheckExistPKG("TO", txtToNo_Text, cboCoCde_Text) = False Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        pkgtype = "TO"


        gspStr = "sp_select_TOORDHDR_PKG02 '" & cboCoCde_Text & "','" & txtToNo_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDHDR_PKG02 :" & rtnStr)
            Exit Sub
        End If

        If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts") = "CLO" Then
            Cursor = Cursors.Default
            MsgBox("TO status is close , action cancel.")
            Exit Sub
        End If


        If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 Then
            '            If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 And rs_TOSCDETAIL.Tables("RESULT").Rows.Count <> 0 Then

            cboPriCust_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus1no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus1name")
            'cboSecCust_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no")

            If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no") <> "" Then
                cboSecCust_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus2name")
            Else
                cboSecCust_Text = ""
            End If


            txtSalesDiv_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_saltem")
            cboSalesRep_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_salrep")
            txtToNo_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_toordno")
            txtToVer_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_verno")

            ' cboToStatus_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts")


            '   display_combo(rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts"), cboToStatus)

            txtToIssDate_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_issdat")


            txtToRevDate_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_rvsdat")
            txtRefQuot_Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_refqut")

            ' SetdgSCTO_TO()


            txtScNo_Text = ""
            txtScVer_Text = ""

            txtScIssDat_Text = ""
            txtScRevDate_Text = ""
            txtCustPoDate_Text = ""
            txtScCancelDate_Text = ""
            txtScShipDateEnd_Text = ""
            txtScShipDateStr_Text = ""
            txtScRemark_Text = ""

            Cursor = Cursors.Default

        End If


        gspStr = "sp_select_TOORDDTL_PKG02 '" & cboCoCde_Text & "','" & txtToNo_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDDTL_PKG02 :" & rtnStr)
            Exit Sub
        End If


        Cursor = Cursors.Default


    End Sub

    'Private Sub txtToNo_KeyPress_d(ByVal tmp_txtToNo_Text)
    '    Cursor = Cursors.WaitCursor

    '    If CheckExistPKG("TO", txtToNo_Text, cboCoCde_Text) = False Then
    '        Cursor = Cursors.Default
    '        Exit Sub
    '    End If

    '    pkgtype = "TO"




    '    gspStr = "sp_select_TOORDDTL_PKG02 '" & cboCoCde_Text & "','" & tmp_txtToNo_Text & "'"
    '    rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
    '    If rtnLong <> RC_SUCCESS Then
    '        Cursor = Cursors.Default
    '        MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDDTL_PKG02 :" & rtnStr)
    '        Exit Sub
    '    End If

    '    ' SetdgSCTO_TO()



    '    Cursor = Cursors.Default

    '    End If

    '    Cursor = Cursors.Default


    'End Sub
    Public Sub cmdFind_Click(ByVal tmp_cocde, ByVal tmp_reqno)
        Cursor = Cursors.WaitCursor


        gspStr = " sp_select_PKREQDTL '" & tmp_cocde & "','" & tmp_reqno & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKREQDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKREQDTL :" & rtnStr)
            Exit Sub
        End If



        Cursor = Cursors.Default

    End Sub

    Private Sub txtPkgItem_KeyPress(ByVal txtPkgItem_Text As String)

        gspStr = "sp_select_PKIMBAIF '" & txtPkgItem_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_PKIMBAIF :" & rtnStr)
            Exit Sub
        End If

        If rs_PKIMBAIF.Tables("RESULT").Rows.Count <> 0 Then

            Dim realitem As String
            Dim tmpitem As String
            Dim venitem As String
            Dim venno As String
            Dim assitem As String
            Dim PackUnt As String
            Dim inr As Integer
            Dim master As Integer
            Dim ftyprctrm As String
            Dim hkprctrm As String
            Dim trantrm As String
            Dim cft As Decimal
            Dim colcde As String
            Dim wholeitemno As String

            Dim est_flag As String

            'wholeitemno = Split(tmp_itmno, " : ")(0)
            'colcde = Split(tmp_itmno, " : ")(1)
            'realitem = Split(wholeitemno, " / ")(0)
            'assitem = Split(wholeitemno, " / ")(1)
            'tmpitem = Split(wholeitemno, " / ")(2)
            'venitem = Split(wholeitemno, " / ")(3)
            'venno = Split(wholeitemno, " / ")(4)
            'PackUnt = Split(txtTerms_Text, " / ")(0)
            'inr = Split(txtTerms_Text, " / ")(1)
            'master = Split(txtTerms_Text, " / ")(2)
            'cft = Split(txtTerms_Text, " / ")(3)
            'ftyprctrm = Split(txtTerms_Text, " / ")(4)
            'hkprctrm = Split(txtTerms_Text, " / ")(5)
            'trantrm = Split(txtTerms_Text, " / ")(6)
            'Dim dr() As DataRow

            'dr = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
            '                                          "prd_assitm = '" & assitem & "' and " & _
            '                                  "prd_tmpitmno = '" & tmpitem & "' and " & _
            '                                   "prd_venno = '" & venno & "' and " & _
            '                                   "prd_venitm = '" & venitem & "' and " & _
            '                                   "prd_pkgitm = '" & Trim(txtPkgItem_Text) & "' and " & _
            '                                   "prd_colcde = '" & colcde & "'")

            'If dr.Length <> 0 Then
            '    'MsgBox("Duplicate Packaging Item for the Product Item.")
            '    'Exit Sub
            'End If


            txtPkgItem_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_pgitmno")
            txtCate_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate") + " - " + rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("ypc_pakna")
            txtPkgChDesc_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc")
            txtPkgEnDesc_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc")
            txtPkgRemark_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark")

            txtEISizeH_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
            txtEISizeW_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW")
            txtEISizeL_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL")

            txtECSizeH_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH")
            txtECSizeW_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW")
            txtECSizeL_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL")

            txtFISizeH_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchH")
            txtFISizeL_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL")
            txtFISizeW_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchW")

            txtFCSizeH_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH")
            txtFCSizeL_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL")
            txtFCSizeW_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW")

            txtMatri_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral")
            txtTcknes_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes")
            txtPrtMtd_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd")
            txtForntCol_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot")
            txtBackCol_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck")
            txtFinish_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish")
            'txtForntFin_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finfot")
            'txtBackFin_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finbck")

            txtMatDsc_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc")
            txtTckDsc_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc")
            txtPrtDsc_Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc")

            est_flag = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_estflg")
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = txtCate_Text

            ''''''''            txtPkgItem_Text = UCase(txtPkgItem_Text)




            txtPkgOrdQty_Text = 0
            txtPkgUnitPri_Text = 0
            txtPkgTtlQty_Text = 0
            txtTtlAmt_Text = 0
            txtQuotePrice_Text = 0


        End If

    End Sub

    'Private Sub update_PKREQDTL()

    '    If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
    '        Exit Sub

    '    End If

    '    Dim seq As Integer
    '    seq = txtSeq_Text
    '    Dim loc As Integer = -1


    '    For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
    '        If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
    '            loc = i
    '        End If

    '    Next

    '    If loc = -1 Then
    '        MsgBox("Error Request detail not found!")
    '        Exit Sub
    '    End If

    '    If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*NEW*~" Or _
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~" Then
    '        Exit Sub
    '    End If


    '    Dim realitem As String
    '    Dim tmpitem As String
    '    Dim venitem As String
    '    Dim venno As String

    '    Dim PackUnt As String
    '    Dim inr As Integer
    '    Dim master As Integer
    '    Dim ftyprctrm As String
    '    Dim hkprctrm As String
    '    Dim trantrm As String
    '    Dim cft As Decimal
    '    Dim colcde As String
    '    Dim wholeItemno As String
    '    Dim assitem As String


    '    'wholeItemno = Split(txtItemNo_Text, " : ")(0)

    '    'colcde = Split(txtItemNo_Text, " : ")(1)

    '    'realitem = Split(wholeItemno, " / ")(0)
    '    'assitem = Split(wholeItemno, " / ")(1)
    '    'tmpitem = Split(wholeItemno, " / ")(2)
    '    'venitem = Split(wholeItemno, " / ")(3)
    '    'venno = Split(wholeItemno, " / ")(4)

    '    'PackUnt = Split(txtTerms_Text, " / ")(0)
    '    'inr = Split(txtTerms_Text, " / ")(1)
    '    'master = Split(txtTerms_Text, " / ")(2)
    '    'cft = Split(txtTerms_Text, " / ")(3)
    '    'ftyprctrm = Split(txtTerms_Text, " / ")(4)
    '    'hkprctrm = Split(txtTerms_Text, " / ")(5)
    '    'trantrm = Split(txtTerms_Text, " / ")(6)


    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cocde") = cbococde_Text
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_reqno") = ""
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq") = txtSeq_Text

    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde") = colcde
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno") = realitem
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_assitm") = assitem
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno") = tmpitem
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno") = venno
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm") = venitem
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pckunt") = PackUnt
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_inrqty") = inr
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_mtrqty") = master
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cft") = cft
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ftyprctrm") = ftyprctrm
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_hkprctrm") = hkprctrm
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_trantrm") = trantrm
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgitm") = txtPkgItem_Text

    '    '        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven") = cboPkgVendor_Text

    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = txtCate_Text '*
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_chndsc") = txtPkgChDesc_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_engdsc") = txtPkgEnDesc_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_remark") = txtPkgRemark_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchL") = IIf(txtEISizeL_Text = "", 0, txtEISizeL_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchW") = IIf(txtEISizeW_Text = "", 0, txtEISizeW_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchH") = IIf(txtEISizeH_Text = "", 0, txtEISizeH_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmL") = IIf(txtECSizeL_Text = "", 0, txtECSizeL_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmW") = IIf(txtECSizeW_Text = "", 0, txtECSizeW_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmH") = IIf(txtECSizeH_Text = "", 0, txtECSizeH_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FInchL") = IIf(txtFISizeL_Text = "", 0, txtFISizeL_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchW") = IIf(txtFISizeW_Text = "", 0, txtFISizeW_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchH") = IIf(txtFISizeH_Text = "", 0, txtFISizeH_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmL") = IIf(txtFCSizeL_Text = "", 0, txtFCSizeL_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmW") = IIf(txtFCSizeW_Text = "", 0, txtFCSizeW_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmH") = IIf(txtFCSizeH_Text = "", 0, txtFCSizeH_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matral") = txtMatri_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tiknes") = txtTcknes_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtmtd") = txtPrtMtd_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrfot") = txtForntCol_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrbck") = txtBackCol_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finish") = txtFinish_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_rmtnce") = cboRemi_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_addres") = txtPkgAddress_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_state") = txtPkgState_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntry") = txtPkgCtry_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_zip") = txtZip_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_Tel") = txtTel_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntper") = cboPkgCtnPer_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sctoqty") = IIf(txtPkgSTQty_Text = "", 0, txtPkgSTQty_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum") = cboSTOUM_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_curcde") = txtPkgUnitPriCur_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_multip") = IIf(txtPkgMult_Text = "", 0, txtPkgMult_Text) 'care  0

    '    '        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordqty") = IIf(txtPkgOrdQty_Text = "", 0, txtPkgOrdQty_Text)


    '    'If txtPkgWastPer_Text = "" Then
    '    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") = 0
    '    'Else
    '    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") = txtPkgWastPer_Text
    '    'End If

    '    'If Trim(txtPkgWast_Text) = "" Then
    '    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty") = 0
    '    'Else
    '    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty") = txtPkgWast_Text
    '    'End If



    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlordqty") = IIf(txtPkgTtlQty_Text = "", 0, txtPkgTtlQty_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_untprc") = txtPkgUnitPri_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlamtqty") = IIf(txtTtlAmt_Text = "", 0, txtTtlAmt_Text)
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_receqty") = 0 '*
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = cbococde_Text
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finfot") = txtForntFin_Text
    '    'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finbck") = txtBackFin_Text

    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matDsc") = txtMatDsc_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tikDsc") = txtTckDsc_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtDsc") = txtPrtDsc_Text

    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sku") = txtSKU_Text
    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cusitm") = txtCustomer_Text


    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_salprc") = IIf(Trim(txtQuotePrice_Text) = "", 0, txtQuotePrice_Text)

    '    rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_bonqty") = IIf(Trim(txtBonQty_Text) = "", 0, txtBonQty_Text)


    'End Sub


    'Private Sub cboPkgVendor_SelectedIndexChanged()
    '    'Dim dv As DataView
    '    'dv = rs_VNBASINF.Tables("RESULT").DefaultView

    '    Dim dr() As DataRow
    '    dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(cboPkgVendor_Text, " - ")(0) & "'")

    '    If dr.Length <> 0 Then
    '        txtPkgAddress_Text = dr(0)("vci_address").ToString
    '        txtPkgState_Text = dr(0)("vci_stt").ToString
    '        txtPkgCtry_Text = dr(0)("vci_cty").ToString
    '        txtZip_Text = dr(0)("vci_zip").ToString
    '        'txtTel_Text = dr(0)("vci_cntphn").ToString
    '        ' txtPkgCtnPer_Text = dr(0)("vci_cntctp").ToString
    '        txtPkgUnitPriCur_Text = dr(0)("vbi_curcde").ToString
    '        txtTtlAmtCur_Text = dr(0)("vbi_curcde").ToString
    '        txtQuoteCur_Text = dr(0)("vbi_curcde").ToString


    '    End If


    '    Dim dr_Ctnper() As DataRow
    '    dr_Ctnper = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & Split(cboPkgVendor_Text, " - ")(0) & "'")

    '    cboPkgCtnPer_text = ""
    '    If dr_Ctnper.Length <> 0 Then
    '        cboPkgCtnPer_text = dr_Ctnper(0)("vci_cntctp")
    '    End If

    '    Dim dr_tel() As DataRow
    '    dr_tel = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & Split(cboPkgVendor_Text, " - ")(0) & "' and vci_cntctp = '" & cboPkgCtnPer_Text & "'")
    '    If dr_tel.Length <> 0 Then
    '        txtTel_Text = dr_tel(0)("vci_cntphn")
    '    Else
    '        txtTel_Text = ""
    '    End If




    '    'If MouseClickCbo = True Then
    '    '    MouseClickCbo = False

    '    '    SetAsUpdate(txtSeq_Text)
    '    '    recordstatus = True
    '    'End If




    'End Sub


    Private Function check_and_valid_LV3_estttl() As Boolean

        Dim rs_LIST_RESULT_cal As DataSet
        Dim rs_LIST_RESULT_compare As DataSet
        Dim rs_LIST_RESULT_copy2 As DataSet

        Dim rs_PKESHDR_valid As DataSet

        Dim tmp_est_sum As Decimal
        Dim tmp_found_count As Integer

        rs_LIST_RESULT_cal = rs_LIST_RESULT.Copy
        rs_LIST_RESULT_compare = rs_LIST_RESULT.Copy
        rs_LIST_RESULT_copy2 = rs_LIST_RESULT.Copy

        Dim realitem As String
        Dim assitem As String
        Dim colcde As String

        Dim tmpitmno As String
        Dim venno As String
        Dim venitm As String
        Dim tmp_valid As Boolean
        Dim tmp_estttl As Decimal

        gspStr = "sp_select_PKESHDR '" & cboCoCde.Text & "','" & "@!#@!#!@#" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR_valid, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
            Exit Function
        End If
        For i2 As Integer = 0 To rs_PKESHDR_valid.Tables("RESULT").Columns.Count - 1
            rs_PKESHDR_valid.Tables("RESULT").Columns(i2).ReadOnly = False
        Next i2

        For i As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
            If i <= rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1 Then

                realitem = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_itmno")
                assitem = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_assitmno")
                colcde = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_colcde")

                tmpitmno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpitmno")
                venno = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpvenno")
                venitm = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_tmpvenitmno")

                Dim dr_PKESHDR() As DataRow

                'If Not rs_PKESHDR_valid Is Nothing Then
                '    If Not rs_PKESHDR_valid.Tables("RESULT") Is Nothing Then
                dr = rs_PKESHDR_valid.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
                                                          "peh_assitm = '" & assitem & "' and " & _
                                                    "peh_colcde = '" & colcde & "'")
                'End If
                '    End If

                If dr.Length = 0 Then
                    Dim rowcount_hdr As Integer
                    rowcount_hdr = rs_PKESHDR_valid.Tables("RESULT").Rows.Count
                    rs_PKESHDR_valid.Tables("RESULT").Rows.Add()

                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_reqno") = txtReqno_Text
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_itemno") = realitem
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_assitm") = assitem
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_tmpitmno") = tmpitmno
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venno") = venno
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venitm") = venitm

                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_colcde") = colcde
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_price") = rs_LIST_RESULT.Tables("RESULT").DefaultView(i)("pxd_estttl")

                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_curcde") = "HKD"

                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("peh_creusr") = "~*ADD*~"
                    rs_PKESHDR_valid.Tables("RESULT").Rows(rowcount_hdr).Item("est_flag") = ""  'no need?

                End If
            End If
        Next

        'check if in the system
        gspStr = "sp_select_PKESHDR '" & cboCoCde_Text & "','" & txtReqno_Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
            Exit Function
        End If

        For i As Integer = 0 To rs_PKESHDR_valid.Tables("RESULT").Rows.Count - 1
            Dim dr_PKESHDR() As DataRow

            realitem = rs_PKESHDR_valid.Tables("RESULT").Rows(i)("peh_itemno")
            assitem = rs_PKESHDR_valid.Tables("RESULT").Rows(i)("peh_assitm")
            colcde = rs_PKESHDR_valid.Tables("RESULT").Rows(i)("peh_colcde")

            dr = rs_PKESHDR.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
                                                      "peh_assitm = '" & assitem & "' and " & _
                                                "peh_colcde = '" & colcde & "'")

            If dr.Length <> 0 Then
                '''''''''''''''''''''''''''''''''''''''''
                rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"

                ''If  is partial update ::
                gspStr = "sp_select_PKESDTL '" & cboCoCde_Text & "','" & txtReqno_Text & "'"
                'cboCoCde_Text  ???
                'ped_reqno  
                rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                    Exit Function
                End If

                rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno  = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                    " pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                            " pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "' and " & _
                            " pxd_act = 'U' and " & _
                             rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter
                ''''' 20160321 check 'U' fro count only

                rs_PKESDTL.Tables("RESULT").DefaultView.RowFilter = " ped_itemno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                    " ped_assitm = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                            " ped_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"


                '###########################################################
                tmp_found_count = 0
                If rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count <> rs_PKESDTL.Tables("RESULT").DefaultView.Count Then
                    For k As Integer = 0 To rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count - 1
                        For l As Integer = 0 To rs_PKESDTL.Tables("RESULT").DefaultView.Count - 1
                            If rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(k)("pxd_pkgitm") = rs_PKESDTL.Tables("RESULT").DefaultView(l)("ped_pkgitem") And _
                             rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(k)("pxd_unitprice") = rs_PKESDTL.Tables("RESULT").DefaultView(l)("ped_price") Then
                                ''need check not 'RE-Print' ???
                                tmp_found_count = tmp_found_count + 1
                            End If
                        Next
                    Next

                    If tmp_found_count < rs_PKESDTL.Tables("RESULT").DefaultView.Count Then
                        ''' the case of UCP Item with Estimated Cost Entry in system
                        ''' not fully updated
                        '                        rs_PKESHDR_valid.Tables("RESULT").Rows(i)("peh_price") = dr(0)("peh_price")
                        '''Call check_all_related_estttl()
                        tmp_valid = True
                        '2016
                        rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                                      "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                                "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"
                        tmp_valid = True 'def
                        For m As Integer = 0 To rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.Count - 1
                            If rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(m)("pxd_estttl") <> 0 Then
                                tmp_valid = False
                            End If
                        Next

                        If tmp_valid = False Then
                            rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno= '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                                          "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                                    "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"
                            For m As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Valid") = "N"
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") & " Estimated Cost Entry Invalid;"
                            Next
                        End If
                    End If

                    '>>>>>>>>>>
                    If tmp_found_count = rs_PKESDTL.Tables("RESULT").DefaultView.Count Then
                        ''' the case of UCP Item with Estimated Cost Entry in system
                        ''' not fully updated????????????? fully update?
                        '''Call check_sumup_equalto_estttl()

                        tmp_estttl = 0
                        rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                                      "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                                "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"

                        For m As Integer = 0 To rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.Count - 1
                            If rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(m)("pxd_estttl") <> 0 Then
                                tmp_estttl = tmp_estttl + rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(m)("pxd_estunt")
                            End If
                        Next
                        '''''''''''''''''''''''''''
                        tmp_valid = True '''''''''''''''''''''''''''''''''''''''''default
                        If tmp_estttl <> rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_price") And tmp_estttl <> 0 And rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_price") <> 0 Then
                            tmp_valid = False
                        End If

                        If tmp_valid = False Then
                            rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno= '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                                          "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                                    "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"
                            For m As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Valid") = "N"
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") & " Estimated Cost Entry Invalid;"
                            Next
                        End If

                    End If
                    '>>>>>>>>>>


                End If
                'ccon sider est hdr with some dtl  in system 
                '###########################################################
            End If

        Next




        ''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''
        '''Cal EST  for 'New' case
        For i As Integer = 0 To rs_PKESHDR_valid.Tables("RESULT").Rows.Count - 1
            If rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~" Then
                tmp_est_sum = 0

                rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                    " pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                    " pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "' and " & _
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter

                ''
                For j As Integer = 0 To rs_LIST_RESULT_cal.Tables("RESULT").DefaultView.Count - 1
                    tmp_est_sum = tmp_est_sum + rs_LIST_RESULT_cal.Tables("RESULT").DefaultView(j)("pxd_estunt")
                Next

                '''Call check_sumup_equalto_estttl()

                tmp_estttl = 0
                rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno= '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                              "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                        "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"

                For m As Integer = 0 To rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.Count - 1
                    If rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(m)("pxd_estttl") <> 0 Then
                        tmp_estttl = tmp_estttl + rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(m)("pxd_estunt")
                    End If
                Next
                tmp_valid = True '''''''''''''''''''''''''''''def
                If tmp_estttl <> rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_price") And _
                    Not (tmp_estttl = 0 Or rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_price") = 0) Then
                    tmp_valid = False
                End If

                If tmp_valid = False Then
                    rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_itemno") & "' and " & _
                                                  "pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_assitm") & "' and " & _
                                            "pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(i).Item("peh_colcde") & "'"
                    For m As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Valid") = "N"
                        rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") & " Estimated Cost Entry Invalid;"
                    Next
                End If


            End If
        Next


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For index As Integer = 0 To rs_PKESHDR_valid.Tables("RESULT").Rows.Count - 1

            rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno  = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(index).Item("peh_itemno") & "' and " & _
    " pxd_assitmno = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(index).Item("peh_assitm") & "' and " & _
            " pxd_colcde = '" & rs_PKESHDR_valid.Tables("RESULT").Rows(index).Item("peh_colcde") & "' and " & _
             rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter


            For i As Integer = 0 To rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count - 1
                For j As Integer = 0 To rs_LIST_RESULT_compare.Tables("RESULT").DefaultView.Count - 1

                    If rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(i)("pxd_estttl") <> rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(j)("pxd_estttl") Then

                        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO = '" & txtReqno_Text & "' and pxd_itmno = '" & rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(i).Item("pxd_itmno") & "' and " & _
                                  "pxd_assitmno = '" & rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(i).Item("pxd_assitmno") & "' and " & _
                            "pxd_colcde = '" & rs_LIST_RESULT_compare.Tables("RESULT").DefaultView(i).Item("pxd_colcde") & "'"
                        For m As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").DefaultView.Count - 1
                            rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Valid") = "N"
                            If InStr(rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason"), "(Ttl Cost Different by Rows)") <= 0 Then
                                rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") = rs_LIST_RESULT.Tables("RESULT").DefaultView(m)("Reason") & " Estimated Cost Entry Invalid (Ttl Cost Different by Rows);"

                            End If
                        Next


                    End If

                Next
            Next


        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    End Function

    Sub check_and_valid_ActFlag()
        Dim tmp_found As Boolean

        'check with duplicate

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1


            'AUR
            If Not (UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("A") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("U") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("R")) Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag should be A/U/R;"
            End If

        Next
    End Sub

    Sub check_and_valid_UPD()
        Dim tmp_found As Boolean

        'check with duplicate

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1


            'AUR
            If UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("hdr_act")) = UCase("UPD") And _
                Len(rs_LIST_RESULT.Tables("RESULT").Rows(index)("REQ_NO")) < 7 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Please Input Req#;"
            End If

        Next
    End Sub


    Sub check_and_valid_fields()
        Dim tmp_found As Boolean

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1

            'AUR
            If Not (UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("A") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("U") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("R")) Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag should be A/U/R;"
            End If

        Next
    End Sub

    Sub check_and_valid_LV3_AUR()
        Dim tmp_found As Boolean

        'check with duplicate

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1

            tmp_found = False
            For j As Integer = 0 To rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows.Count - 1
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_itmno") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_itmno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_scno") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_scno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_tono") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_tono") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_assitmno") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_assitmno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_um") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_um") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_inner") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_inner") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_master") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_master") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_colcde") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_colcde") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ftytrm") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_ftytrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_hktrm") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_hktrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_trantrm") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_trantrm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgitm") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_pkgitm") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgvenno") = rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("pxd_pkgvenno") And _
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act") = "A" And _
                1 < rs_LIST_RESULT_check_dup_add.Tables("RESULT").Rows(j)("check") Then
                    tmp_found = True
                End If
            Next
            If tmp_found = True Then
                '20160317
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Duplicated for Act Flag 'A' ;"
            End If

            'AUR
            If Not (UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("A") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("U") Or _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("R")) Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag should be A/U/R;"
            End If

            If UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("Dtl_Act")) = UCase("Insert") And _
            UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("U") Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag Incorrect ;"
            End If

            If UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("Dtl_Act")) = UCase("Upd") And _
            UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) <> UCase("U") Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag Incorrect ;"
            End If

            If UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("Dtl_Act")) = UCase("Upd") And _
            UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("R") Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Act Flag Incorrect ;"
            End If


        Next

        ''



    End Sub

    Sub check_and_valid_LV3_waste_empty()
        Dim tmp_found As Boolean

        'check with duplicate

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = -1 Then

                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_default_waste")

            End If

        Next

        ''



    End Sub

    Sub check_and_valid_LV3_REQNo()
        Dim tmp_found As Boolean

        'check with duplicate

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1


            If (UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("REQ_NO")) = "" And _
                    UCase(rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_act")) = UCase("U")) Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Upd Records should provide Request Number;"
            End If


        Next

        ''



    End Sub

    Sub check_and_valid_LV3_Waste()
        Dim dr() As DataRow
        Dim cate As String
        Dim ordqty As Integer

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            txtPkgItem_Text = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_pkgitm")
            Call txtPkgItem_KeyPress(txtPkgItem_Text)
            cate = txtCate_Text
            ordqty = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty")

            dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & Split(cate, " - ")(0) & "' and pwa_qtyfrm <= " & ordqty & " and pwa_qtyto >= " & ordqty)

            If dr.Length <> 0 Then
                If dr(0)("pwa_um") = "%" Then
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_default_waste") = Math.Round(ordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                Else
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_default_waste") = Fix(dr(0).Item("pwa_wasage"))
                End If
            End If

            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") <> 0 Then
                'sum up should be equal
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") + rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") <> rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") And _
                 rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") <> 0 Then
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Input Req Qty + wastage not equal to Total Req Qty;"
                End If
            Else
                ''Assume zero                 ''Assume default
                If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") + 0 <> rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") And _
                            rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") + rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_default_waste") <> rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") And _
                            rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") <> 0 Then
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                    rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Input Req Qty + wastage not equal to Total Req Qty;"
                End If
            End If
        Next



    End Sub

    Sub cal_Waste()
        Dim dr() As DataRow
        Dim cate As String
        Dim ordqty As Integer

        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1

            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = 0 And rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") = 0 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_default_waste")
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") + rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste")
            End If

            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = 0 And rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") <> 0 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") - rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty")
            End If


            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste") <> 0 And rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") = 0 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ttlordqty") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") + rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_waste")
            End If


        Next



    End Sub


    'Private Sub txtPkgOrdQty_TextChanged()

    '    Dim cate As String = Split(txtCate_Text, " - ")(0)
    '    Dim ordqty As Integer = txtPkgOrdQty_Text

    '    Dim dr() As DataRow
    '    dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & ordqty & " and pwa_qtyto >= " & ordqty)

    '    If dr.Length <> 0 Then
    '        If dr(0)("pwa_um") = "%" Then

    '            txtPkgWastPer_Text = Fix(dr(0).Item("pwa_wasage"))
    '            'txtWasQty_Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
    '            ' txtStandWasage_Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
    '            txtPkgWast_Text = Math.Round(ordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
    '            txtBonQty_Text = txtPkgWast_Text
    '        Else
    '            txtPkgWastPer_Text = ""
    '            'txtWasQty_Text = Fix(dr(0).Item("pwa_wasage"))
    '            txtPkgWast_Text = Fix(dr(0).Item("pwa_wasage"))
    '            txtBonQty_Text = txtPkgWast_Text
    '        End If

    '    End If

    '    If txtBonQty_Text <> txtPkgWast_Text Then
    '        txtBonQty.ForeColor = Color.Red
    '    Else
    '        txtBonQty.ForeColor = Color.Black
    '    End If

    '    'txtPkgWastPer_Text = ""
    '    'txtPkgWast_Text = 0


    '    calTotalOrdQty()
    '    calTotalAMT()


    'End Sub
    Public Sub check_and_valid_LV3_ordqty()
        For index As Integer = 0 To rs_LIST_RESULT.Tables("RESULT").Rows.Count - 1
            If rs_LIST_RESULT.Tables("RESULT").Rows(index)("pxd_ordqty") = 0 Then
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Valid") = "N"
                rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") = rs_LIST_RESULT.Tables("RESULT").Rows(index)("Reason") & " Order Quantity should not be zero;"
            End If
        Next
    End Sub


    Private Function get_reqno_and_check_estttl() As Boolean
        Dim cocde As String
        Dim reqno As String
        Dim ver As Integer
        Dim issdat As String
        Dim revdat As String
        Dim status As String
        Dim cus1no As String
        Dim cus2no As String
        Dim saldiv As String
        Dim saltem As String
        Dim salrep As String
        Dim ToNo As String
        Dim ToVer As String
        Dim ToSts As String
        Dim ToIsdat As Object
        Dim ToRevdat As Object
        Dim ToRefqut As String
        Dim potyp As String
        Dim ScNo As String
        Dim ScVer As String
        Dim ScSts As String
        Dim ScIsdat As Object
        Dim ScRevdat As Object
        Dim ScPodat As Object
        Dim ScCandat As Object
        Dim ScShpDatstr As Object
        Dim ScShpdatend As Object
        Dim ScRemark As String

        Dim NewNO As String

        Dim pxd_cocde As String
        Dim rs_LIST_RESULT_copy2 As DataSet


        rs_LIST_RESULT_copy2 = rs_LIST_RESULT.Copy

        ''Req#
        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid")) <> "N" Then

                ''sc or to     
                If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) <> "" Then
                    rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'"
                    'set var
                    txtScNo_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_scno")
                    cboCoCde_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cocde")
                    cboPriCust_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cus1no")
                    '   cboSecCust_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cus2o")
                    txtScNo_KeyPress_h()
                Else
                    rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'"
                    'set var
                    txtToNo_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_tono")
                    cboCoCde_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cocde")
                    cboPriCust_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cus1no")
                    'cboSecCust_Text = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("pxd_cus2o")
                    txtToNo_KeyPress_h()
                End If

                reqno = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("REQ_NO")
                txtReqno_Text = reqno
                'If UCase(rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("Hdr_Act")) = UCase("New") Then
                '    txtReqno_Text = ""
                'Else 'UPD HDR
                '    reqno = rs_LIST_RESULT_copy2.Tables("RESULT").DefaultView(0)("REQ_NO")
                '    txtReqno_Text = reqno
                'End If

                rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "REQ_NO= '" & txtReqno_Text & "'"
                Call check_and_valid_LV3_estttl()

            End If
        Next


    End Function




    Private Function check_gen_set() As Boolean
        Dim counter_Y As Integer
        Dim counter_N As Integer
        Dim counter_ALL As Integer

        check_gen_set = False
        rs_LIST_RESULT_copy = rs_LIST_RESULT.Copy


        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = "GEN = 'Y' "
        If rs_LIST_RESULT.Tables("RESULT").DefaultView.Count = 0 Then
            rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
            MsgBox("Please Apply rows to Genereate!")
            rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
            Exit Function
        End If






        For index As Integer = 0 To rs_LIST_RESULT_scto.Tables("RESULT").Rows.Count - 1
            If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("Valid")) <> "N" Then
                'check all gene = Y
                If Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) <> "" Then
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'  and GEN= 'Y'  "
                    counter_Y = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'  and GEN<>  'Y'  "
                    counter_N = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_scno= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno")) & "'   "
                    counter_ALL = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    If (counter_Y <> counter_ALL) And (counter_N <> counter_ALL) Then
                        MsgBox("Please generate or do not generate  all rows for SC :" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_scno"))
                        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
                        Exit Function

                    End If

                Else
                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'  and GEN= 'Y' "
                    counter_Y = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'  and GEN <> 'Y' "
                    counter_N = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.RowFilter = "pxd_tono= '" & Trim(rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono")) & "'    "
                    counter_ALL = rs_LIST_RESULT_copy.Tables("RESULT").DefaultView.Count

                    If (counter_Y <> counter_ALL) And (counter_N <> counter_ALL) Then
                        MsgBox("Please generate or do not generate  all rows for  TO :" & rs_LIST_RESULT_scto.Tables("RESULT").Rows(index)("pxd_tono"))
                        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
                        Exit Function
                    End If

                End If
            End If
        Next

        rs_LIST_RESULT.Tables("RESULT").DefaultView.RowFilter = ""
        check_gen_set = True

    End Function



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "&Show Detail" Then
            txtReqNo.Text = msg
            Button1.Text = "&Show Message"
        Else
            txtReqNo.Text = msg2
            Button1.Text = "&Show Detail"
        End If
    End Sub
End Class



















































































































