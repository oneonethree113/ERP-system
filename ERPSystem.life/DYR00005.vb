Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Data.OleDb
'Imports ADODB





Public Class DYR00005
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
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboRptType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbSYSETINF As System.Windows.Forms.RadioButton
    Friend WithEvents rbSYLNEINF As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVendorMaster As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DYR00005))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cboRptType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.rbSYSETINF = New System.Windows.Forms.RadioButton
        Me.rbSYLNEINF = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbVendorMaster = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 166)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(548, 16)
        Me.StatusBar1.TabIndex = 1
        Me.StatusBar1.Text = "StatusBar1"
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
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(190, 124)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 162
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cboRptType
        '
        Me.cboRptType.FormattingEnabled = True
        Me.cboRptType.Location = New System.Drawing.Point(130, 79)
        Me.cboRptType.Name = "cboRptType"
        Me.cboRptType.Size = New System.Drawing.Size(389, 20)
        Me.cboRptType.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Report Type"
        '
        'rbSYSETINF
        '
        Me.rbSYSETINF.AutoSize = True
        Me.rbSYSETINF.Location = New System.Drawing.Point(6, 25)
        Me.rbSYSETINF.Name = "rbSYSETINF"
        Me.rbSYSETINF.Size = New System.Drawing.Size(85, 16)
        Me.rbSYSETINF.TabIndex = 165
        Me.rbSYSETINF.TabStop = True
        Me.rbSYSETINF.Text = "System Setup"
        Me.rbSYSETINF.UseVisualStyleBackColor = True
        '
        'rbSYLNEINF
        '
        Me.rbSYLNEINF.AutoSize = True
        Me.rbSYLNEINF.Location = New System.Drawing.Point(122, 25)
        Me.rbSYLNEINF.Name = "rbSYLNEINF"
        Me.rbSYLNEINF.Size = New System.Drawing.Size(83, 16)
        Me.rbSYLNEINF.TabIndex = 166
        Me.rbSYLNEINF.TabStop = True
        Me.rbSYLNEINF.Text = "Product Line"
        Me.rbSYLNEINF.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbVendorMaster)
        Me.GroupBox1.Controls.Add(Me.rbSYSETINF)
        Me.GroupBox1.Controls.Add(Me.rbSYLNEINF)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 47)
        Me.GroupBox1.TabIndex = 167
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group Code"
        '
        'rbVendorMaster
        '
        Me.rbVendorMaster.AutoSize = True
        Me.rbVendorMaster.Location = New System.Drawing.Point(243, 25)
        Me.rbVendorMaster.Name = "rbVendorMaster"
        Me.rbVendorMaster.Size = New System.Drawing.Size(92, 16)
        Me.rbVendorMaster.TabIndex = 167
        Me.rbVendorMaster.TabStop = True
        Me.rbVendorMaster.Text = "Vendor Master"
        Me.rbVendorMaster.UseVisualStyleBackColor = True
        '
        'DYR00005
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(548, 182)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboRptType)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.StatusBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DYR00005"
        Me.Text = "DYR00005 - Dynamic Report vw_SYSETINF (DYR05)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region






    Private Sub DYR00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        rbSYSETINF.Checked = True

        Call Formstartup(Me.Name)
    End Sub

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Me.Cursor = Cursors.WaitCursor
        Dim YSITYP As String
        Dim GRPCDE As String

        If rbSYLNEINF.Checked = True Then
            GRPCDE = "SYLNEINF"
        ElseIf rbSYSETINF.Checked Then
            GRPCDE = "SYSETINF"
        Else
            GRPCDE = "VendorMaster"
        End If

        If Me.cboRptType.Items.Count > 0 Then
            If Trim(Me.cboRptType.Text) = "" Then
                MsgBox("The Report Type is empty!")
                Exit Sub
            Else
                YSITYP = Split(cboRptType.Text, " - ")(0)
            End If
        Else
            YSITYP = ""
        End If

        gspStr = "sp_list_DYR00005 '','" & _
                    GRPCDE & "','" & _
                    YSITYP & "','" & _
                    gsUsrID & "'"


        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00005 #001 sp_list_DYR00005 : " & rtnStr)
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


















    Private Sub rbSYSETINF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSYSETINF.CheckedChanged
        If rbSYSETINF.Checked = True Then
            cboRptType.Text = ""
            cboRptType.Items.Clear()
            cboRptType.Items.Add("01 - Region")
            cboRptType.Items.Add("02 - Country")
            cboRptType.Items.Add("03 - Price Term")
            cboRptType.Items.Add("04 - Payment Term")
            cboRptType.Items.Add("05 - Unit of Measure")
            'cboRptType.Items.Add("06 - Currency")
            cboRptType.Items.Add("07 - Construction Method")
            cboRptType.Items.Add("08 - Market Type")
            cboRptType.Items.Add("11 - Remarks for Packing List")
            cboRptType.Items.Add("12 - Commission Term")
            cboRptType.Items.Add("13 - Nature (Customer & Vendor)")
            cboRptType.Items.Add("14 - Banks")
            cboRptType.Items.Add("15 - Designer")
            cboRptType.Items.Add("16 - PRC Import Contract")
            cboRptType.Items.Add("17 - Cost Element Setup (CU)")
            cboRptType.Items.Add("18 - Customer Item Category Setup (CU)")
            cboRptType.Items.Add("19 - Quotation Season Code (QU)")
            cboRptType.Items.Add("20 - Item Nature (IM) - Internal")
            cboRptType.Items.Add("24 - Product Group (IM)")
            cboRptType.Items.Add("25 - Material (IM)")
            cboRptType.Items.Add("26 - Product Size Type (IM)")
            cboRptType.Items.Add("27 - Product Size Unit (IM)")
            cboRptType.Items.Add("28 - Product Icons (IM)")
            cboRptType.Items.Add("29 - Item Nature (IM) - External")

            cboRptType.Text = "01 - Region"
        End If
    End Sub

    Private Sub rbSYLNEINF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSYLNEINF.CheckedChanged
        If rbSYLNEINF.Checked = True Then
            cboRptType.Text = ""
            cboRptType.Items.Clear()
            cboRptType.Items.Add("01 - Product Line")
            cboRptType.Text = "01 - Product Line"
        End If
    End Sub

    Private Sub rbVendorMaster_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVendorMaster.CheckedChanged
        If rbVendorMaster.Checked = True Then
            cboRptType.Text = ""
            cboRptType.Items.Clear()
        End If
    End Sub
End Class
