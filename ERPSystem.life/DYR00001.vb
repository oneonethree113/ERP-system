Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class DYR00001
    Inherits System.Windows.Forms.Form



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents lbl_S_ItmNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_PriCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CoCde As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmd_S_DV As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_S_DV As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CredatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_CredatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DYR00001))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.lbl_S_ItmNo = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lbl_S_PriCust = New System.Windows.Forms.Label
        Me.lbl_S_CoCde = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmd_S_DV = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_S_DV = New System.Windows.Forms.TextBox
        Me.txt_S_CredatFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_CredatTo = New System.Windows.Forms.MaskedTextBox
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 240)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(714, 16)
        Me.StatusBar1.TabIndex = 1
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(0, 0)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(200, 100)
        Me.TabPage6.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(0, 0)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(200, 100)
        Me.TabPage7.TabIndex = 0
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(129, 89)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 4
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(129, 50)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCustAll.TabIndex = 2
        Me.cmd_S_PriCustAll.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Enabled = False
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(129, 12)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 0
        Me.cmd_S_CoCde.Text = "「「"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(17, 92)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(43, 12)
        Me.lbl_S_ItmNo.TabIndex = 110
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(201, 89)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_ItmNo.TabIndex = 5
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(201, 50)
        Me.txt_S_PriCustAll.MaxLength = 5000
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_PriCustAll.TabIndex = 3
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(201, 13)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_CoCde.TabIndex = 1
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(17, 55)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(66, 12)
        Me.lbl_S_PriCust.TabIndex = 105
        Me.lbl_S_PriCust.Text = "Pri Customer"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(17, 17)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(79, 12)
        Me.lbl_S_CoCde.TabIndex = 104
        Me.lbl_S_CoCde.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(163, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "From"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(449, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 12)
        Me.Label10.TabIndex = 160
        Me.Label10.Text = "To"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(577, 170)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "(MM/DD/YYYY)"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(297, 170)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "(MM/DD/YYYY)"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(19, 167)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 157
        Me.Label17.Text = "Create Date"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(337, 198)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(129, 126)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_DV.TabIndex = 6
        Me.cmd_S_DV.Text = "「「"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 130)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 12)
        Me.Label18.TabIndex = 163
        Me.Label18.Text = "Design Vendor"
        '
        'txt_S_DV
        '
        Me.txt_S_DV.Location = New System.Drawing.Point(201, 126)
        Me.txt_S_DV.MaxLength = 5000
        Me.txt_S_DV.Name = "txt_S_DV"
        Me.txt_S_DV.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_DV.TabIndex = 7
        '
        'txt_S_CredatFm
        '
        Me.txt_S_CredatFm.Location = New System.Drawing.Point(201, 165)
        Me.txt_S_CredatFm.Mask = "00/00/0000"
        Me.txt_S_CredatFm.Name = "txt_S_CredatFm"
        Me.txt_S_CredatFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_CredatFm.TabIndex = 8
        '
        'txt_S_CredatTo
        '
        Me.txt_S_CredatTo.Location = New System.Drawing.Point(486, 164)
        Me.txt_S_CredatTo.Mask = "00/00/0000"
        Me.txt_S_CredatTo.Name = "txt_S_CredatTo"
        Me.txt_S_CredatTo.Size = New System.Drawing.Size(85, 22)
        Me.txt_S_CredatTo.TabIndex = 9
        '
        'DYR00001
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(714, 256)
        Me.Controls.Add(Me.txt_S_CredatTo)
        Me.Controls.Add(Me.txt_S_CredatFm)
        Me.Controls.Add(Me.cmd_S_DV)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txt_S_DV)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.cmd_S_CoCde)
        Me.Controls.Add(Me.lbl_S_ItmNo)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.txt_S_CoCde)
        Me.Controls.Add(Me.lbl_S_PriCust)
        Me.Controls.Add(Me.lbl_S_CoCde)
        Me.Controls.Add(Me.StatusBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DYR00001"
        Me.Text = "DYR00001 - Dynamic Report vw_CIH_Report (DYR01)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public rs_SYMUSRCO As New DataSet
    Public rs_DYR00001 As New DataSet


    Dim rowCnt As Integer

    Dim dsNewRow As DataRow

    Dim mode As String


    Private Sub DYR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00001 #001 sp_select_SYMUSRCO : " & rtnStr)
        Else
            Dim i As Integer
            Dim strCocde As String
            strCocde = ""

            If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                    If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                        If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                        Else
                            strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                        End If
                    End If
                Next i
            End If

            Me.txt_S_CoCde.Text = strCocde
        End If
        Call Formstartup(Me.Name)
    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCustAll)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmd_S_DV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_DV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_DV.Name
        frmComSearch.callFmString = txt_S_DV.Text

        frmComSearch.show_frmS(Me.cmd_S_DV)
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Me.Cursor = Cursors.WaitCursor

        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim ITMNOLIST As String
        Dim DVLIST As String
        Dim CREDATFM As String
        Dim CREDATTO As String

        If Trim(Me.txt_S_CoCde.Text) = "" Then
            MsgBox("The Company Code List is empty!")
            Exit Sub
        Else
            If Len(Me.txt_S_CoCde.Text) > 1000 Then
                MsgBox("The Company Code List is too long (1000 char)")
            End If
            COCDELIST = removeduplicateItem(Trim(Me.txt_S_CoCde.Text))
            COCDELIST = COCDELIST.Replace("'", "''")
        End If

        If Trim(Me.txt_S_PriCustAll.Text) = "" Then
            CUS1NOLIST = ""
        Else
            If Len(Me.txt_S_PriCustAll.Text) > 1000 Then
                MsgBox("The Primary Customer List is too long (1000 char)")
                Exit Sub
            End If
            CUS1NOLIST = removeduplicateItem(Trim(Me.txt_S_PriCustAll.Text))
            CUS1NOLIST = CUS1NOLIST.Replace("'", "''")
        End If

        CUS2NOLIST = ""

        If Trim(Me.txt_S_ItmNo.Text) = "" Then
            ITMNOLIST = ""
        Else
            If Len(Me.txt_S_ItmNo.Text) > 1000 Then
                MsgBox("The Item No List is too long (1000 char)")
                Exit Sub
            End If
            ITMNOLIST = removeduplicateItem(Trim(Me.txt_S_ItmNo.Text))
            ITMNOLIST = ITMNOLIST.Replace("'", "''")
        End If


        If Trim(Me.txt_S_DV.Text) = "" Then
            DVLIST = ""
        Else
            If Len(Me.txt_S_DV.Text) > 1000 Then
                MsgBox("The Design Vendor List is too long (1000 char)")
                Exit Sub
            End If
            DVLIST = removeduplicateItem(Trim(Me.txt_S_DV.Text))
            DVLIST = DVLIST.Replace("'", "''")
        End If


        If Me.txt_S_CredatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_CredatFm.Text) Then
                MsgBox("Invalid Date Format: Create Date From")
                Me.txt_S_CredatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_CredatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_CredatTo.Text) Then
                MsgBox("Invalid Date Format: Create Date To")
                Me.txt_S_CredatTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_CredatFm.Text, 7) > Mid(Me.txt_S_CredatTo.Text, 7) Then
            MsgBox("Create Date: End Date < Start Date (YY)")
            Me.txt_S_CredatFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_CredatFm.Text, 7) = Mid(Me.txt_S_CredatTo.Text, 7) Then
            If Me.txt_S_CredatFm.Text.Substring(0, 2) > Me.txt_S_CredatTo.Text.Substring(0, 2) Then
                MsgBox("Create Date: End Date < Start Date (MM)")
                Me.txt_S_CredatFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_CredatFm.Text.Substring(0, 2) = Me.txt_S_CredatTo.Text.Substring(0, 2) Then
                If Me.txt_S_CredatFm.Text.Substring(3, 2) > Me.txt_S_CredatTo.Text.Substring(3, 2) Then
                    MsgBox("Create Date: End Date < Start Date (DD)")
                    Me.txt_S_CredatFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_CredatFm.Text = "  /  /" Then
            CREDATFM = "01/01/1900"
        Else
            CREDATFM = Me.txt_S_CredatFm.Text
        End If

        If Me.txt_S_CredatTo.Text = "  /  /" Then
            CREDATTO = "01/01/1900"
        Else
            CREDATTO = Me.txt_S_CredatTo.Text
        End If


        If CREDATFM = "01/01/1900" And CREDATTO = "01/01/1900" Then
            MsgBox("Create Date must have values!")
            Me.txt_S_CredatFm.Focus()
            Exit Sub
        End If


        gspStr = "sp_list_DYR00001 '','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    DVLIST & "','" & _
                    CREDATFM & "','" & _
                    CREDATTO & "','" & _
                    gsUsrID & "'"


        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00001 #002 sp_list_DYR00001 : " & rtnStr)
        Else
            If rs.RecordCount = 0 Then
                MsgBox("No record found!")
            Else
                Call ExportToExcel(rs)
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExportToExcel(ByVal rs_EXCEL As ADODB.Recordset)
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing
        Dim iRow As Integer
        Dim iCol As Integer
        Dim strCocde As String = String.Empty

        If rs_EXCEL.RecordCount >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If


        Me.Cursor = Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim i As Integer
        For i = 0 To rs_EXCEL.Fields.Count - 1
            xlsApp.Cells(1, i + 1) = rs_EXCEL.Fields(i).Name
        Next
        xlsWS.Rows(1).Font.Bold = True


        xlsApp.Cells(2, 1).copyfromrecordset(rs_EXCEL)

        xlsApp.Selection.CurrentRegion.Columns.AutoFit()
        xlsApp.Selection.CurrentRegion.rows.AutoFit()

        'For i = 0 To rs_EXCEL.Fields.Count - 1
        '    If xlsApp.Columns(i + 1).Width > 100 Then
        '        'xlsWS.Columns(i + 1).Width = 100.0
        '    End If
        'Next
    End Sub


    Private Function removeduplicateItem(ByVal s As String) As String
        Return s
    End Function

    Private Sub txt_S_CredatFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_CredatFm.GotFocus
        Me.txt_S_CredatFm.SelectAll()
    End Sub

    Private Sub txt_S_CredatTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_CredatTo.GotFocus
        Me.txt_S_CredatTo.SelectAll()
    End Sub
End Class
