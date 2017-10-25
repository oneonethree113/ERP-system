Imports System.IO.File
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Data.OleDb
'Imports ADODB



Public Class DYR00009
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
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmd_S_DV As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_S_DV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_SecCust As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_PV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboLayout As System.Windows.Forms.ComboBox
    Friend WithEvents txt_S_SCShpStrdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SCShpStrdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SCIssdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SCIssdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SHSlndatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SHSlndatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DYR00009))
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
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmd_S_DV = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_S_DV = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.lbl_S_SecCust = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.lbl_S_PV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboLayout = New System.Windows.Forms.ComboBox
        Me.txt_S_SCShpStrdatFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SCShpStrdatTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SCIssdatFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SCIssdatTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SHSlndatFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SHSlndatTo = New System.Windows.Forms.MaskedTextBox
        Me.SuspendLayout()
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 359)
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
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(129, 92)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_ItmNo.TabIndex = 6
        Me.cmd_S_ItmNo.Text = "「「"
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(129, 38)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PriCustAll.TabIndex = 2
        Me.cmd_S_PriCustAll.Text = "「「"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Enabled = False
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(129, 11)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_CoCde.TabIndex = 0
        Me.cmd_S_CoCde.Text = "「「"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(17, 96)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(43, 12)
        Me.lbl_S_ItmNo.TabIndex = 110
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(201, 92)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_ItmNo.TabIndex = 7
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(201, 38)
        Me.txt_S_PriCustAll.MaxLength = 5000
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_PriCustAll.TabIndex = 3
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(201, 12)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_CoCde.TabIndex = 1
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(17, 44)
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
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(339, 320)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 20
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(129, 119)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_DV.TabIndex = 8
        Me.cmd_S_DV.Text = "「「"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 124)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 12)
        Me.Label18.TabIndex = 163
        Me.Label18.Text = "Design Vendor"
        '
        'txt_S_DV
        '
        Me.txt_S_DV.Location = New System.Drawing.Point(201, 119)
        Me.txt_S_DV.MaxLength = 5000
        Me.txt_S_DV.Name = "txt_S_DV"
        Me.txt_S_DV.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_DV.TabIndex = 9
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(129, 65)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_SecCustAll.TabIndex = 4
        Me.cmd_S_SecCustAll.Text = "「「"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(201, 65)
        Me.txt_S_SecCustAll.MaxLength = 5000
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_SecCustAll.TabIndex = 5
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(17, 72)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(69, 12)
        Me.lbl_S_SecCust.TabIndex = 166
        Me.lbl_S_SecCust.Text = "Sec Customer"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(161, 218)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 12)
        Me.Label19.TabIndex = 175
        Me.Label19.Text = "From"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(437, 218)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(18, 12)
        Me.Label20.TabIndex = 174
        Me.Label20.Text = "To"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(565, 217)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(100, 16)
        Me.Label21.TabIndex = 173
        Me.Label21.Text = "(MM/DD/YYYY)"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(297, 217)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(100, 16)
        Me.Label22.TabIndex = 172
        Me.Label22.Text = "(MM/DD/YYYY)"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(19, 218)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 16)
        Me.Label23.TabIndex = 171
        Me.Label23.Text = "SC Issue Date"
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(129, 146)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 24)
        Me.cmd_S_PV.TabIndex = 10
        Me.cmd_S_PV.Text = "「「"
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(17, 155)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(94, 12)
        Me.lbl_S_PV.TabIndex = 176
        Me.lbl_S_PV.Text = "Production Vendor"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(201, 146)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(501, 22)
        Me.txt_S_PV.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(161, 252)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 12)
        Me.Label24.TabIndex = 185
        Me.Label24.Text = "From"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(437, 252)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(18, 12)
        Me.Label25.TabIndex = 184
        Me.Label25.Text = "To"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(565, 250)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(100, 16)
        Me.Label26.TabIndex = 183
        Me.Label26.Text = "(MM/DD/YYYY)"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(297, 249)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 16)
        Me.Label27.TabIndex = 182
        Me.Label27.Text = "(MM/DD/YYYY)"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(19, 251)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(125, 23)
        Me.Label28.TabIndex = 181
        Me.Label28.Text = "Sailing On Board Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 12)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "To"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(565, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = "(MM/DD/YYYY)"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(297, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 189
        Me.Label4.Text = "(MM/DD/YYYY)"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(19, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 15)
        Me.Label5.TabIndex = 188
        Me.Label5.Text = "SC Ship Start Date"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 23)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "Report Layout"
        '
        'cboLayout
        '
        Me.cboLayout.FormattingEnabled = True
        Me.cboLayout.Location = New System.Drawing.Point(201, 284)
        Me.cboLayout.Name = "cboLayout"
        Me.cboLayout.Size = New System.Drawing.Size(305, 20)
        Me.cboLayout.TabIndex = 18
        '
        'txt_S_SCShpStrdatFm
        '
        Me.txt_S_SCShpStrdatFm.Location = New System.Drawing.Point(201, 182)
        Me.txt_S_SCShpStrdatFm.Mask = "00/00/0000"
        Me.txt_S_SCShpStrdatFm.Name = "txt_S_SCShpStrdatFm"
        Me.txt_S_SCShpStrdatFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCShpStrdatFm.TabIndex = 12
        '
        'txt_S_SCShpStrdatTo
        '
        Me.txt_S_SCShpStrdatTo.Location = New System.Drawing.Point(469, 182)
        Me.txt_S_SCShpStrdatTo.Mask = "00/00/0000"
        Me.txt_S_SCShpStrdatTo.Name = "txt_S_SCShpStrdatTo"
        Me.txt_S_SCShpStrdatTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCShpStrdatTo.TabIndex = 13
        '
        'txt_S_SCIssdatFm
        '
        Me.txt_S_SCIssdatFm.Location = New System.Drawing.Point(201, 214)
        Me.txt_S_SCIssdatFm.Mask = "00/00/0000"
        Me.txt_S_SCIssdatFm.Name = "txt_S_SCIssdatFm"
        Me.txt_S_SCIssdatFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCIssdatFm.TabIndex = 14
        '
        'txt_S_SCIssdatTo
        '
        Me.txt_S_SCIssdatTo.Location = New System.Drawing.Point(469, 213)
        Me.txt_S_SCIssdatTo.Mask = "00/00/0000"
        Me.txt_S_SCIssdatTo.Name = "txt_S_SCIssdatTo"
        Me.txt_S_SCIssdatTo.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SCIssdatTo.TabIndex = 15
        '
        'txt_S_SHSlndatFm
        '
        Me.txt_S_SHSlndatFm.Location = New System.Drawing.Point(201, 246)
        Me.txt_S_SHSlndatFm.Mask = "00/00/0000"
        Me.txt_S_SHSlndatFm.Name = "txt_S_SHSlndatFm"
        Me.txt_S_SHSlndatFm.Size = New System.Drawing.Size(88, 22)
        Me.txt_S_SHSlndatFm.TabIndex = 16
        '
        'txt_S_SHSlndatTo
        '
        Me.txt_S_SHSlndatTo.Location = New System.Drawing.Point(467, 247)
        Me.txt_S_SHSlndatTo.Mask = "00/00/0000"
        Me.txt_S_SHSlndatTo.Name = "txt_S_SHSlndatTo"
        Me.txt_S_SHSlndatTo.Size = New System.Drawing.Size(90, 22)
        Me.txt_S_SHSlndatTo.TabIndex = 17
        '
        'DYR00009
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(714, 375)
        Me.Controls.Add(Me.txt_S_SHSlndatTo)
        Me.Controls.Add(Me.txt_S_SHSlndatFm)
        Me.Controls.Add(Me.txt_S_SCIssdatTo)
        Me.Controls.Add(Me.txt_S_SCIssdatFm)
        Me.Controls.Add(Me.txt_S_SCShpStrdatTo)
        Me.Controls.Add(Me.txt_S_SCShpStrdatFm)
        Me.Controls.Add(Me.cboLayout)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cmd_S_PV)
        Me.Controls.Add(Me.lbl_S_PV)
        Me.Controls.Add(Me.txt_S_PV)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cmd_S_SecCustAll)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.lbl_S_SecCust)
        Me.Controls.Add(Me.cmd_S_DV)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txt_S_DV)
        Me.Controls.Add(Me.cmdShow)
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
        Me.MaximizeBox = False
        Me.Name = "DYR00009"
        Me.Text = "DYR00009 - Dynamic Report vw_SalesConfirmation_EC (DYR09)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



    Public rs_SYMUSRCO As New DataSet
    Public rs_DYR00009 As New DataSet


    Dim rowCnt As Integer

    Dim dsNewRow As DataRow

    Dim mode As String


    Private Sub DYR00009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00009 #001 sp_select_SYMUSRCO : " & rtnStr)
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

        cboLayout.Items.Add("LAYOUT001 - AC Forecast")
        cboLayout.Items.Add("FULL - FULL Report")

        cboLayout.Text = cboLayout.Items(0).ToString

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

    Private Sub cmd_S_SecCustAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCustAll.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCustAll)
    End Sub


    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        frmComSearch.show_frmS(Me.cmd_S_PV)
    End Sub


    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click

        Dim COCDELIST As String
        Dim CUS1NOLIST As String
        Dim CUS2NOLIST As String
        Dim ITMNOLIST As String
        Dim DVLIST As String
        Dim PVLIST As String
        Dim SCSHPSTRDATFM As String
        Dim SCSHPSTRDATTO As String
        Dim SCISSDATFM As String
        Dim SCISSDATTO As String
        Dim SHSLNDATFM As String
        Dim SHSLNDATTO As String
        Dim LAYOUT As String


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

        If Trim(Me.txt_S_PV.Text) = "" Then
            PVLIST = ""
        Else
            If Len(Me.txt_S_PV.Text) > 1000 Then
                MsgBox("The Production Vendor List is too long (1000 char)")
                Exit Sub
            End If
            PVLIST = removeduplicateItem(Trim(Me.txt_S_PV.Text))
            PVLIST = PVLIST.Replace("'", "''")
        End If



        If Me.txt_S_SCShpStrdatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SCShpStrdatFm.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date From")
                Me.txt_S_SCShpStrdatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_SCShpStrdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SCShpStrdatTo.Text) Then
                MsgBox("Invalid Date Format: SC Ship Start Date To")
                Me.txt_S_SCShpStrdatTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SCShpStrdatFm.Text, 7) > Mid(Me.txt_S_SCShpStrdatTo.Text, 7) Then
            MsgBox("SC Ship Start Date: End Date < Start Date (YY)")
            Me.txt_S_SCShpStrdatFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_SCShpStrdatFm.Text, 7) = Mid(Me.txt_S_SCShpStrdatTo.Text, 7) Then
            If Me.txt_S_SCShpStrdatFm.Text.Substring(0, 2) > Me.txt_S_SCShpStrdatTo.Text.Substring(0, 2) Then
                MsgBox("SC Ship Start Date: End Date < Start Date (MM)")
                Me.txt_S_SCShpStrdatFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_SCShpStrdatFm.Text.Substring(0, 2) = Me.txt_S_SCShpStrdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SCShpStrdatFm.Text.Substring(3, 2) > Me.txt_S_SCShpStrdatTo.Text.Substring(3, 2) Then
                    MsgBox("SC Ship Start Date: End Date < Start Date (DD)")
                    Me.txt_S_SCShpStrdatFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SCShpStrdatFm.Text = "  /  /" Then
            SCSHPSTRDATFM = "01/01/1900"
        Else
            SCSHPSTRDATFM = Me.txt_S_SCShpStrdatFm.Text
        End If

        If Me.txt_S_SCShpStrdatTo.Text = "  /  /" Then
            SCSHPSTRDATTO = "01/01/1900"
        Else
            SCSHPSTRDATTO = Me.txt_S_SCShpStrdatTo.Text
        End If





        If Me.txt_S_SCIssdatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SCIssdatFm.Text) Then
                MsgBox("Invalid Date Format: SC Issue Date From")
                Me.txt_S_SCIssdatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_SCIssdatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SCIssdatTo.Text) Then
                MsgBox("Invalid Date Format: SC Issue Date To")
                Me.txt_S_SCIssdatTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SCIssdatFm.Text, 7) > Mid(Me.txt_S_SCIssdatTo.Text, 7) Then
            MsgBox("SC Issue Date: End Date < Start Date (YY)")
            Me.txt_S_SCIssdatFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_SCIssdatFm.Text, 7) = Mid(Me.txt_S_SCIssdatTo.Text, 7) Then
            If Me.txt_S_SCIssdatFm.Text.Substring(0, 2) > Me.txt_S_SCIssdatTo.Text.Substring(0, 2) Then
                MsgBox("SC Issue Date: End Date < Start Date (MM)")
                Me.txt_S_SCIssdatFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_SCIssdatFm.Text.Substring(0, 2) = Me.txt_S_SCIssdatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SCIssdatFm.Text.Substring(3, 2) > Me.txt_S_SCIssdatTo.Text.Substring(3, 2) Then
                    MsgBox("SC Issue Date: End Date < Start Date (DD)")
                    Me.txt_S_SCIssdatFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SCIssdatFm.Text = "  /  /" Then
            SCISSDATFM = "01/01/1900"
        Else
            SCISSDATFM = Me.txt_S_SCIssdatFm.Text
        End If

        If Me.txt_S_SCIssdatTo.Text = "  /  /" Then
            SCISSDATTO = "01/01/1900"
        Else
            SCISSDATTO = Me.txt_S_SCIssdatTo.Text
        End If



        If Me.txt_S_SHSlndatFm.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SHSlndatFm.Text) Then
                MsgBox("Invalid Date Format: Sailing On Board Date From")
                Me.txt_S_SHSlndatFm.Focus()
                Exit Sub
            End If
        End If

        If Me.txt_S_SHSlndatTo.Text <> "  /  /" Then
            If Not IsDate(Me.txt_S_SHSlndatTo.Text) Then
                MsgBox("Invalid Date Format: Sailing On Board Date To")
                Me.txt_S_SHSlndatTo.Focus()
                Exit Sub
            End If
        End If

        If Mid(Me.txt_S_SHSlndatFm.Text, 7) > Mid(Me.txt_S_SHSlndatTo.Text, 7) Then
            MsgBox("Sailing On Board Date: End Date < Start Date (YY)")
            Me.txt_S_SHSlndatFm.Focus()
            Exit Sub
        ElseIf Mid(Me.txt_S_SHSlndatFm.Text, 7) = Mid(Me.txt_S_SHSlndatTo.Text, 7) Then
            If Me.txt_S_SHSlndatFm.Text.Substring(0, 2) > Me.txt_S_SHSlndatTo.Text.Substring(0, 2) Then
                MsgBox("Sailing On Board Date: End Date < Start Date (MM)")
                Me.txt_S_SHSlndatFm.Focus()
                Exit Sub
            ElseIf Me.txt_S_SHSlndatFm.Text.Substring(0, 2) = Me.txt_S_SHSlndatTo.Text.Substring(0, 2) Then
                If Me.txt_S_SHSlndatFm.Text.Substring(3, 2) > Me.txt_S_SHSlndatTo.Text.Substring(3, 2) Then
                    MsgBox("Sailing On Board Date: End Date < Start Date (DD)")
                    Me.txt_S_SHSlndatFm.Focus()
                    Exit Sub
                End If
            End If
        End If

        If Me.txt_S_SHSlndatFm.Text = "  /  /" Then
            SHSLNDATFM = "01/01/1900"
        Else
            SHSLNDATFM = Me.txt_S_SHSlndatFm.Text
        End If

        If Me.txt_S_SHSlndatTo.Text = "  /  /" Then
            SHSLNDATTO = "01/01/1900"
        Else
            SHSLNDATTO = Me.txt_S_SHSlndatTo.Text
        End If

        If SCSHPSTRDATFM = "01/01/1900" And SCSHPSTRDATTO = "01/01/1900" And SCISSDATFM = "01/01/1900" And SCISSDATTO = "01/01/1900" And SHSLNDATFM = "01/01/1900" And SHSLNDATTO = "01/01/1900" Then
            MsgBox("SC Ship Start, Issue or Revised Date must have values!")
            Me.txt_S_SCIssdatFm.Focus()
            Exit Sub
        End If

        If cboLayout.Text = "" Then
            cboLayout.Text = cboLayout.Items(0).ToString
        End If
        LAYOUT = Split(cboLayout.Text, " - ")(0)


        gspStr = "sp_list_DYR00009 '','" & _
                    COCDELIST & "','" & _
                    CUS1NOLIST & "','" & _
                    CUS2NOLIST & "','" & _
                    ITMNOLIST & "','" & _
                    DVLIST & "','" & _
                    PVLIST & "','" & _
                    SCSHPSTRDATFM & "','" & _
                    SCSHPSTRDATTO & "','" & _
                    SCISSDATFM & "','" & _
                    SCISSDATTO & "','" & _
                    SHSLNDATFM & "','" & _
                    SHSLNDATTO & "','" & _
                    LAYOUT & "','" & _
                    gsUsrID & "'"

        Me.Cursor = Cursors.WaitCursor

        Dim rs As New ADODB.Recordset
        rtnLong = execute_SQLStatementRPT_ADO(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading DYR00009 #002 sp_list_DYR00009 : " & rtnStr)
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

    Private Sub txt_S_SCShpStrdatFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SCShpStrdatFm.GotFocus
        Me.txt_S_SCShpStrdatFm.SelectAll()
    End Sub

    Private Sub txt_S_SCShpStrdatTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SCShpStrdatTo.GotFocus
        Me.txt_S_SCShpStrdatTo.SelectAll()
    End Sub

    Private Sub txt_S_SCIssdatFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SCIssdatFm.GotFocus
        Me.txt_S_SCIssdatFm.SelectAll()
    End Sub

    Private Sub txt_S_SCIssdatTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SCIssdatTo.GotFocus
        Me.txt_S_SCIssdatTo.SelectAll()
    End Sub

    Private Sub txt_S_SHSlndatFm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SHSlndatFm.GotFocus
        Me.txt_S_SHSlndatFm.SelectAll()
    End Sub

    Private Sub txt_S_SHSlndatTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_S_SHSlndatTo.GotFocus
        Me.txt_S_SHSlndatTo.SelectAll()
    End Sub

    Private Sub lbl_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_S_CoCde.Click

    End Sub

    Private Sub txt_S_CoCde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_CoCde.TextChanged

    End Sub

    Private Sub txt_S_PriCustAll_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_PriCustAll.TextChanged

    End Sub

    Private Sub lbl_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_S_PriCust.Click

    End Sub

    Private Sub lbl_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_S_SecCust.Click

    End Sub

    Private Sub txt_S_SecCustAll_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_SecCustAll.TextChanged

    End Sub

    Private Sub lbl_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_S_ItmNo.Click

    End Sub

    Private Sub txt_S_ItmNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_ItmNo.TextChanged

    End Sub

    Private Sub lbl_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_S_PV.Click

    End Sub

    Private Sub txt_S_PV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_S_PV.TextChanged

    End Sub
End Class
