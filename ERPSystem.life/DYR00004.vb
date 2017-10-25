Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Data.OleDb
'Imports ADODB



Public Class DYR00004
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CustPODate As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_ShipDate As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_S_SCIssDate As System.Windows.Forms.Label
    Friend WithEvents cmd_S_SalTem As System.Windows.Forms.Button
    Friend WithEvents lbl_S_SalTem As System.Windows.Forms.Label
    Friend WithEvents txt_S_SalTem As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_PV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_CV As System.Windows.Forms.Label
    Friend WithEvents txt_S_CV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PONo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents lbl_S_ItmNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_SCNo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_PONo As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CustPO As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_SecCust As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DYR00004))
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lbl_S_CustPODate = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_S_ShipDate = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_S_SCIssDate = New System.Windows.Forms.Label
        Me.cmd_S_SalTem = New System.Windows.Forms.Button
        Me.lbl_S_SalTem = New System.Windows.Forms.Label
        Me.txt_S_SalTem = New System.Windows.Forms.TextBox
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.lbl_S_PV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_CV = New System.Windows.Forms.Button
        Me.lbl_S_CV = New System.Windows.Forms.Label
        Me.txt_S_CV = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.cmd_S_PONo = New System.Windows.Forms.Button
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.lbl_S_ItmNo = New System.Windows.Forms.Label
        Me.lbl_S_SCNo = New System.Windows.Forms.Label
        Me.lbl_S_PONo = New System.Windows.Forms.Label
        Me.lbl_S_CustPO = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lbl_S_SecCust = New System.Windows.Forms.Label
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
        Me.StatusBar1.Location = New System.Drawing.Point(0, 229)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(714, 16)
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(161, 472)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "From"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(449, 472)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 153
        Me.Label12.Text = "To"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(577, 480)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 16)
        Me.Label13.TabIndex = 152
        Me.Label13.Text = "(MM/DD/YYYY)"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(297, 480)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 16)
        Me.Label14.TabIndex = 151
        Me.Label14.Text = "(MM/DD/YYYY)"
        Me.Label14.Visible = False
        '
        'lbl_S_CustPODate
        '
        Me.lbl_S_CustPODate.Location = New System.Drawing.Point(17, 472)
        Me.lbl_S_CustPODate.Name = "lbl_S_CustPODate"
        Me.lbl_S_CustPODate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_CustPODate.TabIndex = 150
        Me.lbl_S_CustPODate.Text = "Cust PO Date"
        Me.lbl_S_CustPODate.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 448)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "From"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(449, 448)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 12)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "To"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(577, 456)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "(MM/DD/YYYY)"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(297, 456)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 16)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "(MM/DD/YYYY)"
        Me.Label9.Visible = False
        '
        'lbl_S_ShipDate
        '
        Me.lbl_S_ShipDate.Location = New System.Drawing.Point(17, 448)
        Me.lbl_S_ShipDate.Name = "lbl_S_ShipDate"
        Me.lbl_S_ShipDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_ShipDate.TabIndex = 145
        Me.lbl_S_ShipDate.Text = "Ship Date"
        Me.lbl_S_ShipDate.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 424)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "From"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(449, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 140
        Me.Label4.Text = "To"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(577, 432)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "(MM/DD/YYYY)"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(297, 432)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "(MM/DD/YYYY)"
        Me.Label1.Visible = False
        '
        'lbl_S_SCIssDate
        '
        Me.lbl_S_SCIssDate.Location = New System.Drawing.Point(17, 424)
        Me.lbl_S_SCIssDate.Name = "lbl_S_SCIssDate"
        Me.lbl_S_SCIssDate.Size = New System.Drawing.Size(100, 23)
        Me.lbl_S_SCIssDate.TabIndex = 132
        Me.lbl_S_SCIssDate.Text = "SC Issue Date"
        Me.lbl_S_SCIssDate.Visible = False
        '
        'cmd_S_SalTem
        '
        Me.cmd_S_SalTem.Location = New System.Drawing.Point(129, 397)
        Me.cmd_S_SalTem.Name = "cmd_S_SalTem"
        Me.cmd_S_SalTem.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SalTem.TabIndex = 133
        Me.cmd_S_SalTem.Text = "「「"
        Me.cmd_S_SalTem.Visible = False
        '
        'lbl_S_SalTem
        '
        Me.lbl_S_SalTem.AutoSize = True
        Me.lbl_S_SalTem.Location = New System.Drawing.Point(17, 405)
        Me.lbl_S_SalTem.Name = "lbl_S_SalTem"
        Me.lbl_S_SalTem.Size = New System.Drawing.Size(57, 12)
        Me.lbl_S_SalTem.TabIndex = 128
        Me.lbl_S_SalTem.Text = "Sales Team"
        Me.lbl_S_SalTem.Visible = False
        '
        'txt_S_SalTem
        '
        Me.txt_S_SalTem.Location = New System.Drawing.Point(201, 397)
        Me.txt_S_SalTem.MaxLength = 5000
        Me.txt_S_SalTem.Name = "txt_S_SalTem"
        Me.txt_S_SalTem.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_SalTem.TabIndex = 134
        Me.txt_S_SalTem.Visible = False
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(129, 373)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PV.TabIndex = 130
        Me.cmd_S_PV.Text = "「「"
        Me.cmd_S_PV.Visible = False
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(17, 381)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(94, 12)
        Me.lbl_S_PV.TabIndex = 122
        Me.lbl_S_PV.Text = "Production Vendor"
        Me.lbl_S_PV.Visible = False
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(201, 373)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_PV.TabIndex = 131
        Me.txt_S_PV.Visible = False
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(129, 349)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CV.TabIndex = 127
        Me.cmd_S_CV.Text = "「「"
        Me.cmd_S_CV.Visible = False
        '
        'lbl_S_CV
        '
        Me.lbl_S_CV.AutoSize = True
        Me.lbl_S_CV.Location = New System.Drawing.Point(17, 357)
        Me.lbl_S_CV.Name = "lbl_S_CV"
        Me.lbl_S_CV.Size = New System.Drawing.Size(79, 12)
        Me.lbl_S_CV.TabIndex = 118
        Me.lbl_S_CV.Text = "Custom Vendor"
        Me.lbl_S_CV.Visible = False
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(201, 349)
        Me.txt_S_CV.MaxLength = 5000
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_CV.TabIndex = 129
        Me.txt_S_CV.Visible = False
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(129, 89)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 125
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(129, 324)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SCNo.TabIndex = 123
        Me.cmd_S_SCNo.Text = "「「"
        Me.cmd_S_SCNo.Visible = False
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(129, 300)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PONo.TabIndex = 120
        Me.cmd_S_PONo.Text = "「「"
        Me.cmd_S_PONo.Visible = False
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(129, 276)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CustPONo.TabIndex = 117
        Me.cmd_S_CustPONo.Text = "「「"
        Me.cmd_S_CustPONo.Visible = False
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(129, 252)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SecCust.TabIndex = 115
        Me.cmd_S_SecCust.Text = "「「"
        Me.cmd_S_SecCust.Visible = False
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(129, 50)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCustAll.TabIndex = 113
        Me.cmd_S_PriCustAll.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Enabled = False
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(129, 12)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 111
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
        'lbl_S_SCNo
        '
        Me.lbl_S_SCNo.AutoSize = True
        Me.lbl_S_SCNo.Location = New System.Drawing.Point(17, 332)
        Me.lbl_S_SCNo.Name = "lbl_S_SCNo"
        Me.lbl_S_SCNo.Size = New System.Drawing.Size(36, 12)
        Me.lbl_S_SCNo.TabIndex = 109
        Me.lbl_S_SCNo.Text = "SC No"
        Me.lbl_S_SCNo.Visible = False
        '
        'lbl_S_PONo
        '
        Me.lbl_S_PONo.AutoSize = True
        Me.lbl_S_PONo.Location = New System.Drawing.Point(17, 308)
        Me.lbl_S_PONo.Name = "lbl_S_PONo"
        Me.lbl_S_PONo.Size = New System.Drawing.Size(36, 12)
        Me.lbl_S_PONo.TabIndex = 108
        Me.lbl_S_PONo.Text = "PO No"
        Me.lbl_S_PONo.Visible = False
        '
        'lbl_S_CustPO
        '
        Me.lbl_S_CustPO.AutoSize = True
        Me.lbl_S_CustPO.Location = New System.Drawing.Point(17, 284)
        Me.lbl_S_CustPO.Name = "lbl_S_CustPO"
        Me.lbl_S_CustPO.Size = New System.Drawing.Size(60, 12)
        Me.lbl_S_CustPO.TabIndex = 107
        Me.lbl_S_CustPO.Text = "Cust PO No"
        Me.lbl_S_CustPO.Visible = False
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(201, 89)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_ItmNo.TabIndex = 126
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(201, 324)
        Me.txt_S_SCNo.MaxLength = 5000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_SCNo.TabIndex = 124
        Me.txt_S_SCNo.Visible = False
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(201, 300)
        Me.txt_S_PONo.MaxLength = 5000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_PONo.TabIndex = 121
        Me.txt_S_PONo.Visible = False
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(201, 276)
        Me.txt_S_CustPONo.MaxLength = 5000
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_CustPONo.TabIndex = 119
        Me.txt_S_CustPONo.Visible = False
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(201, 252)
        Me.txt_S_SecCust.MaxLength = 5000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(560, 22)
        Me.txt_S_SecCust.TabIndex = 116
        Me.txt_S_SecCust.Visible = False
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(201, 50)
        Me.txt_S_PriCustAll.MaxLength = 5000
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_PriCustAll.TabIndex = 114
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(201, 12)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_CoCde.TabIndex = 112
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(17, 260)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(69, 12)
        Me.lbl_S_SecCust.TabIndex = 106
        Me.lbl_S_SecCust.Text = "Sec Customer"
        Me.lbl_S_SecCust.Visible = False
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
        Me.Label2.Location = New System.Drawing.Point(161, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "From"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(449, 162)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 12)
        Me.Label10.TabIndex = 160
        Me.Label10.Text = "To"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(577, 163)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "(MM/DD/YYYY)"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(297, 162)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 158
        Me.Label16.Text = "(MM/DD/YYYY)"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 163)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 23)
        Me.Label17.TabIndex = 157
        Me.Label17.Text = "Create Date"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(336, 189)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 162
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(129, 126)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_DV.TabIndex = 164
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
        Me.txt_S_DV.TabIndex = 165
        '
        'txt_S_CredatFm
        '
        Me.txt_S_CredatFm.Location = New System.Drawing.Point(203, 159)
        Me.txt_S_CredatFm.Mask = "00/00/0000"
        Me.txt_S_CredatFm.Name = "txt_S_CredatFm"
        Me.txt_S_CredatFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_CredatFm.TabIndex = 166
        '
        'txt_S_CredatTo
        '
        Me.txt_S_CredatTo.Location = New System.Drawing.Point(483, 159)
        Me.txt_S_CredatTo.Mask = "00/00/0000"
        Me.txt_S_CredatTo.Name = "txt_S_CredatTo"
        Me.txt_S_CredatTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_CredatTo.TabIndex = 167
        '
        'DYR00004
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(714, 245)
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
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lbl_S_CustPODate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbl_S_ShipDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_S_SCIssDate)
        Me.Controls.Add(Me.cmd_S_SalTem)
        Me.Controls.Add(Me.lbl_S_SalTem)
        Me.Controls.Add(Me.txt_S_SalTem)
        Me.Controls.Add(Me.cmd_S_PV)
        Me.Controls.Add(Me.lbl_S_PV)
        Me.Controls.Add(Me.txt_S_PV)
        Me.Controls.Add(Me.cmd_S_CV)
        Me.Controls.Add(Me.lbl_S_CV)
        Me.Controls.Add(Me.txt_S_CV)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.cmd_S_SCNo)
        Me.Controls.Add(Me.cmd_S_PONo)
        Me.Controls.Add(Me.cmd_S_CustPONo)
        Me.Controls.Add(Me.cmd_S_SecCust)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.cmd_S_CoCde)
        Me.Controls.Add(Me.lbl_S_ItmNo)
        Me.Controls.Add(Me.lbl_S_SCNo)
        Me.Controls.Add(Me.lbl_S_PONo)
        Me.Controls.Add(Me.lbl_S_CustPO)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.txt_S_SCNo)
        Me.Controls.Add(Me.txt_S_PONo)
        Me.Controls.Add(Me.txt_S_CustPONo)
        Me.Controls.Add(Me.txt_S_SecCust)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.txt_S_CoCde)
        Me.Controls.Add(Me.lbl_S_SecCust)
        Me.Controls.Add(Me.lbl_S_PriCust)
        Me.Controls.Add(Me.lbl_S_CoCde)
        Me.Controls.Add(Me.StatusBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DYR00004"
        Me.Text = "DYR00004 - Dynamic Report vw_ItemMaster_Hist (DYR04)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



    Public rs_SYMUSRCO As New DataSet
    Public rs_DYR00004 As New DataSet


    Dim rowCnt As Integer

    Dim dsNewRow As DataRow

    Dim mode As String


    Private Sub DYR00004_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00004 #001 sp_select_SYMUSRCO : " & rtnStr)
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

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

        '       frmComSearch.show_DYR00004(Me)
    End Sub

    Private Sub cmd_S_CustPONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CustPONo.Name
        frmComSearch.callFmString = txt_S_CustPONo.Text

        '      frmComSearch.show_DYR00004(Me)
    End Sub

    Private Sub cmd_S_PONo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PONo.Name
        frmComSearch.callFmString = txt_S_PONo.Text

        '     frmComSearch.show_DYR00004(Me)
    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        '    frmComSearch.show_DYR00004(Me)
    End Sub


    Private Sub cmd_S_CV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CV.Name
        frmComSearch.callFmString = txt_S_CV.Text

        '    frmComSearch.show_DYR00004(Me)
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        '    frmComSearch.show_DYR00004(Me)
    End Sub

    Private Sub cmd_S_SalTem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SalTem.Name
        frmComSearch.callFmString = txt_S_SalTem.Text

        '    frmComSearch.show_DYR00004(Me)
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
        'Dim CUSPONOLIST As String
        'Dim PONOLIST As String
        'Dim SCNOLIST As String
        'Dim CVLIST As String
        'Dim PVLIST As String
        'Dim SALESTEAMLIST As String
        'Dim SCISSDATFM As String
        'Dim SCISSDATTO As String
        'Dim SHPDATFM As String
        'Dim SHPDATTO As String
        'Dim CUSPODATFM As String
        'Dim CUSPODATTO As String


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


        If Me.txt_S_CredatFm.Text <> "__/__/____" Then
            If Not IsDate(Me.txt_S_CredatFm.Text) Then
                MsgBox("Invalid Date Format: Create Date From")
                Me.txt_S_CredatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_CredatTo.Text <> "__/__/____" Then
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

        If Me.txt_S_CredatFm.Text = "__/__/____" Then
            CREDATFM = "01/01/1900"
        Else
            CREDATFM = Me.txt_S_CredatFm.Text
        End If

        If Me.txt_S_CredatTo.Text = "__/__/____" Then
            CREDATTO = "01/01/1900"
        Else
            CREDATTO = Me.txt_S_CredatTo.Text
        End If
        'CREDATFM = ""
        'CREDATTO = ""

        gspStr = "sp_list_DYR00004 '','" & _
                    COCDELIST & "','" & _
                    ITMNOLIST & "','" & _
                    DVLIST & "','" & _
                    CREDATFM & "','" & _
                    CREDATTO & "','" & _
                    gsUsrID & "'"


        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00004 #002 sp_list_DYR00004 : " & rtnStr)
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


















End Class
