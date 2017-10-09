<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POR00007
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.gbCriteria = New System.Windows.Forms.GroupBox
        Me.txtRevDatTo = New System.Windows.Forms.MaskedTextBox
        Me.txtShpDatTo = New System.Windows.Forms.MaskedTextBox
        Me.txtShpDatFm = New System.Windows.Forms.MaskedTextBox
        Me.txtRevDatFm = New System.Windows.Forms.MaskedTextBox
        Me.txtIssDatFm = New System.Windows.Forms.MaskedTextBox
        Me.txtIssDatTo = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optZeroN = New System.Windows.Forms.RadioButton
        Me.optZeroY = New System.Windows.Forms.RadioButton
        Me.Label35 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optAll = New System.Windows.Forms.RadioButton
        Me.optClose = New System.Windows.Forms.RadioButton
        Me.optCancel = New System.Windows.Forms.RadioButton
        Me.optOpen = New System.Windows.Forms.RadioButton
        Me.Label34 = New System.Windows.Forms.Label
        Me.cboVenNoTo = New System.Windows.Forms.ComboBox
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.cboVenNoFm = New System.Windows.Forms.ComboBox
        Me.cboRptType = New System.Windows.Forms.ComboBox
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBomItemNoTo = New System.Windows.Forms.TextBox
        Me.txtJobNoTo = New System.Windows.Forms.TextBox
        Me.txtBomPONoTo = New System.Windows.Forms.TextBox
        Me.txtBomItemNoFm = New System.Windows.Forms.TextBox
        Me.txtJobNoFm = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.txtBomPONoFm = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbCriteria.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(263, 42)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(288, 20)
        Me.txtCoNam.TabIndex = 1
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.SystemColors.Window
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(97, 42)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(66, 21)
        Me.cboCoCde.TabIndex = 0
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(195, 410)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(171, 36)
        Me.cmdShow.TabIndex = 28
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'gbCriteria
        '
        Me.gbCriteria.Controls.Add(Me.txtRevDatTo)
        Me.gbCriteria.Controls.Add(Me.txtShpDatTo)
        Me.gbCriteria.Controls.Add(Me.txtShpDatFm)
        Me.gbCriteria.Controls.Add(Me.txtRevDatFm)
        Me.gbCriteria.Controls.Add(Me.txtIssDatFm)
        Me.gbCriteria.Controls.Add(Me.txtIssDatTo)
        Me.gbCriteria.Controls.Add(Me.GroupBox3)
        Me.gbCriteria.Controls.Add(Me.GroupBox2)
        Me.gbCriteria.Controls.Add(Me.cboVenNoTo)
        Me.gbCriteria.Controls.Add(Me.cboCustNoTo)
        Me.gbCriteria.Controls.Add(Me.cboVenNoFm)
        Me.gbCriteria.Controls.Add(Me.cboRptType)
        Me.gbCriteria.Controls.Add(Me.cboCustNoFm)
        Me.gbCriteria.Controls.Add(Me.Label33)
        Me.gbCriteria.Controls.Add(Me.Label28)
        Me.gbCriteria.Controls.Add(Me.Label21)
        Me.gbCriteria.Controls.Add(Me.Label18)
        Me.gbCriteria.Controls.Add(Me.Label15)
        Me.gbCriteria.Controls.Add(Me.Label12)
        Me.gbCriteria.Controls.Add(Me.Label9)
        Me.gbCriteria.Controls.Add(Me.Label5)
        Me.gbCriteria.Controls.Add(Me.txtBomItemNoTo)
        Me.gbCriteria.Controls.Add(Me.txtJobNoTo)
        Me.gbCriteria.Controls.Add(Me.txtBomPONoTo)
        Me.gbCriteria.Controls.Add(Me.txtBomItemNoFm)
        Me.gbCriteria.Controls.Add(Me.txtJobNoFm)
        Me.gbCriteria.Controls.Add(Me.Label32)
        Me.gbCriteria.Controls.Add(Me.Label27)
        Me.gbCriteria.Controls.Add(Me.txtBomPONoFm)
        Me.gbCriteria.Controls.Add(Me.Label31)
        Me.gbCriteria.Controls.Add(Me.Label26)
        Me.gbCriteria.Controls.Add(Me.Label23)
        Me.gbCriteria.Controls.Add(Me.Label30)
        Me.gbCriteria.Controls.Add(Me.Label25)
        Me.gbCriteria.Controls.Add(Me.Label22)
        Me.gbCriteria.Controls.Add(Me.Label20)
        Me.gbCriteria.Controls.Add(Me.Label17)
        Me.gbCriteria.Controls.Add(Me.Label14)
        Me.gbCriteria.Controls.Add(Me.Label29)
        Me.gbCriteria.Controls.Add(Me.Label24)
        Me.gbCriteria.Controls.Add(Me.Label11)
        Me.gbCriteria.Controls.Add(Me.Label19)
        Me.gbCriteria.Controls.Add(Me.Label16)
        Me.gbCriteria.Controls.Add(Me.Label8)
        Me.gbCriteria.Controls.Add(Me.Label13)
        Me.gbCriteria.Controls.Add(Me.Label6)
        Me.gbCriteria.Controls.Add(Me.Label36)
        Me.gbCriteria.Controls.Add(Me.Label10)
        Me.gbCriteria.Controls.Add(Me.Label7)
        Me.gbCriteria.Controls.Add(Me.Label4)
        Me.gbCriteria.Location = New System.Drawing.Point(12, 69)
        Me.gbCriteria.Name = "gbCriteria"
        Me.gbCriteria.Size = New System.Drawing.Size(539, 335)
        Me.gbCriteria.TabIndex = 2
        Me.gbCriteria.TabStop = False
        '
        'txtRevDatTo
        '
        Me.txtRevDatTo.Location = New System.Drawing.Point(371, 177)
        Me.txtRevDatTo.Mask = "##/##/####"
        Me.txtRevDatTo.Name = "txtRevDatTo"
        Me.txtRevDatTo.Size = New System.Drawing.Size(80, 20)
        Me.txtRevDatTo.TabIndex = 16
        '
        'txtShpDatTo
        '
        Me.txtShpDatTo.Location = New System.Drawing.Point(371, 203)
        Me.txtShpDatTo.Mask = "##/##/####"
        Me.txtShpDatTo.Name = "txtShpDatTo"
        Me.txtShpDatTo.Size = New System.Drawing.Size(80, 20)
        Me.txtShpDatTo.TabIndex = 18
        '
        'txtShpDatFm
        '
        Me.txtShpDatFm.Location = New System.Drawing.Point(169, 203)
        Me.txtShpDatFm.Mask = "##/##/####"
        Me.txtShpDatFm.Name = "txtShpDatFm"
        Me.txtShpDatFm.Size = New System.Drawing.Size(80, 20)
        Me.txtShpDatFm.TabIndex = 17
        '
        'txtRevDatFm
        '
        Me.txtRevDatFm.Location = New System.Drawing.Point(169, 177)
        Me.txtRevDatFm.Mask = "##/##/####"
        Me.txtRevDatFm.Name = "txtRevDatFm"
        Me.txtRevDatFm.Size = New System.Drawing.Size(80, 20)
        Me.txtRevDatFm.TabIndex = 15
        '
        'txtIssDatFm
        '
        Me.txtIssDatFm.Location = New System.Drawing.Point(169, 151)
        Me.txtIssDatFm.Mask = "##/##/####"
        Me.txtIssDatFm.Name = "txtIssDatFm"
        Me.txtIssDatFm.Size = New System.Drawing.Size(80, 20)
        Me.txtIssDatFm.TabIndex = 13
        '
        'txtIssDatTo
        '
        Me.txtIssDatTo.Location = New System.Drawing.Point(371, 151)
        Me.txtIssDatTo.Mask = "##/##/####"
        Me.txtIssDatTo.Name = "txtIssDatTo"
        Me.txtIssDatTo.Size = New System.Drawing.Size(80, 20)
        Me.txtIssDatTo.TabIndex = 14
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optZeroN)
        Me.GroupBox3.Controls.Add(Me.optZeroY)
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 261)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(533, 35)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        '
        'optZeroN
        '
        Me.optZeroN.AutoSize = True
        Me.optZeroN.Checked = True
        Me.optZeroN.Location = New System.Drawing.Point(264, 11)
        Me.optZeroN.Name = "optZeroN"
        Me.optZeroN.Size = New System.Drawing.Size(39, 17)
        Me.optZeroN.TabIndex = 26
        Me.optZeroN.TabStop = True
        Me.optZeroN.Text = "No"
        Me.optZeroN.UseVisualStyleBackColor = True
        '
        'optZeroY
        '
        Me.optZeroY.AutoSize = True
        Me.optZeroY.Location = New System.Drawing.Point(166, 11)
        Me.optZeroY.Name = "optZeroY"
        Me.optZeroY.Size = New System.Drawing.Size(43, 17)
        Me.optZeroY.TabIndex = 25
        Me.optZeroY.Text = "Yes"
        Me.optZeroY.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(3, 13)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(95, 13)
        Me.Label35.TabIndex = 10
        Me.Label35.Text = "Suppress Zero Qty"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAll)
        Me.GroupBox2.Controls.Add(Me.optClose)
        Me.GroupBox2.Controls.Add(Me.optCancel)
        Me.GroupBox2.Controls.Add(Me.optOpen)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 226)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(533, 35)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Checked = True
        Me.optAll.Location = New System.Drawing.Point(457, 11)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(36, 17)
        Me.optAll.TabIndex = 23
        Me.optAll.TabStop = True
        Me.optAll.Text = "All"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optClose
        '
        Me.optClose.AutoSize = True
        Me.optClose.Location = New System.Drawing.Point(368, 11)
        Me.optClose.Name = "optClose"
        Me.optClose.Size = New System.Drawing.Size(51, 17)
        Me.optClose.TabIndex = 22
        Me.optClose.Text = "Close"
        Me.optClose.UseVisualStyleBackColor = True
        '
        'optCancel
        '
        Me.optCancel.AutoSize = True
        Me.optCancel.Location = New System.Drawing.Point(264, 11)
        Me.optCancel.Name = "optCancel"
        Me.optCancel.Size = New System.Drawing.Size(58, 17)
        Me.optCancel.TabIndex = 21
        Me.optCancel.Text = "Cancel"
        Me.optCancel.UseVisualStyleBackColor = True
        '
        'optOpen
        '
        Me.optOpen.AutoSize = True
        Me.optOpen.Location = New System.Drawing.Point(166, 11)
        Me.optOpen.Name = "optOpen"
        Me.optOpen.Size = New System.Drawing.Size(51, 17)
        Me.optOpen.TabIndex = 20
        Me.optOpen.Text = "Open"
        Me.optOpen.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(3, 13)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 13)
        Me.Label34.TabIndex = 10
        Me.Label34.Text = "BOM PO Status"
        '
        'cboVenNoTo
        '
        Me.cboVenNoTo.FormattingEnabled = True
        Me.cboVenNoTo.Location = New System.Drawing.Point(371, 46)
        Me.cboVenNoTo.Name = "cboVenNoTo"
        Me.cboVenNoTo.Size = New System.Drawing.Size(161, 21)
        Me.cboVenNoTo.TabIndex = 6
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(371, 19)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(161, 21)
        Me.cboCustNoTo.TabIndex = 4
        '
        'cboVenNoFm
        '
        Me.cboVenNoFm.FormattingEnabled = True
        Me.cboVenNoFm.Location = New System.Drawing.Point(169, 46)
        Me.cboVenNoFm.Name = "cboVenNoFm"
        Me.cboVenNoFm.Size = New System.Drawing.Size(161, 21)
        Me.cboVenNoFm.TabIndex = 5
        '
        'cboRptType
        '
        Me.cboRptType.FormattingEnabled = True
        Me.cboRptType.Location = New System.Drawing.Point(169, 302)
        Me.cboRptType.Name = "cboRptType"
        Me.cboRptType.Size = New System.Drawing.Size(161, 21)
        Me.cboRptType.TabIndex = 27
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(169, 19)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(161, 21)
        Me.cboCustNoFm.TabIndex = 3
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(336, 206)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(29, 13)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "To : "
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(336, 180)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(29, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "To : "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(336, 154)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "To : "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(336, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "To : "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(336, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "To : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(336, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "To : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(336, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "To : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(336, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "To : "
        '
        'txtBomItemNoTo
        '
        Me.txtBomItemNoTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtBomItemNoTo.Location = New System.Drawing.Point(371, 125)
        Me.txtBomItemNoTo.Name = "txtBomItemNoTo"
        Me.txtBomItemNoTo.Size = New System.Drawing.Size(161, 20)
        Me.txtBomItemNoTo.TabIndex = 12
        '
        'txtJobNoTo
        '
        Me.txtJobNoTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobNoTo.Location = New System.Drawing.Point(371, 99)
        Me.txtJobNoTo.Name = "txtJobNoTo"
        Me.txtJobNoTo.Size = New System.Drawing.Size(161, 20)
        Me.txtJobNoTo.TabIndex = 10
        '
        'txtBomPONoTo
        '
        Me.txtBomPONoTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtBomPONoTo.Location = New System.Drawing.Point(371, 73)
        Me.txtBomPONoTo.Name = "txtBomPONoTo"
        Me.txtBomPONoTo.Size = New System.Drawing.Size(161, 20)
        Me.txtBomPONoTo.TabIndex = 8
        '
        'txtBomItemNoFm
        '
        Me.txtBomItemNoFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtBomItemNoFm.Location = New System.Drawing.Point(169, 125)
        Me.txtBomItemNoFm.Name = "txtBomItemNoFm"
        Me.txtBomItemNoFm.Size = New System.Drawing.Size(161, 20)
        Me.txtBomItemNoFm.TabIndex = 11
        '
        'txtJobNoFm
        '
        Me.txtJobNoFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtJobNoFm.Location = New System.Drawing.Point(169, 99)
        Me.txtJobNoFm.Name = "txtJobNoFm"
        Me.txtJobNoFm.Size = New System.Drawing.Size(161, 20)
        Me.txtJobNoFm.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(457, 206)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "MM/DD/YYYY"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(457, 180)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "MM/DD/YYYY"
        '
        'txtBomPONoFm
        '
        Me.txtBomPONoFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtBomPONoFm.Location = New System.Drawing.Point(169, 73)
        Me.txtBomPONoFm.Name = "txtBomPONoFm"
        Me.txtBomPONoFm.Size = New System.Drawing.Size(161, 20)
        Me.txtBomPONoFm.TabIndex = 7
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(255, 206)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 13)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "MM/DD/YYYY"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(255, 180)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 13)
        Me.Label26.TabIndex = 4
        Me.Label26.Text = "MM/DD/YYYY"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(457, 154)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(79, 13)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "MM/DD/YYYY"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(127, 206)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 13)
        Me.Label30.TabIndex = 4
        Me.Label30.Text = "From :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(127, 180)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(36, 13)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "From :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(255, 154)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(79, 13)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "MM/DD/YYYY"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(127, 154)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "From :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(127, 128)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "From :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(127, 102)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "From :"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 206)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(99, 13)
        Me.Label29.TabIndex = 4
        Me.Label29.Text = "BOM PO Ship Date"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 180)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(111, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "BOM PO Revise Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(127, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "From :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 154)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "BOM PO Issue Date"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "BOM Item No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(127, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "From :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Job No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(127, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "From :"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 305)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(66, 13)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Report Type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "BOM PO No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Customer No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Vendor No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(169, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Company Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Company Code :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(539, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "BOM PO Report (Export to Excel)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'POR00007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 457)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.gbCriteria)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 530)
        Me.Name = "POR00007"
        Me.Text = "POR00007 - BOM PO Report (Export to Excel)"
        Me.gbCriteria.ResumeLayout(False)
        Me.gbCriteria.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents gbCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVenNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBomItemNoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtJobNoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBomPONoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBomItemNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtJobNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtBomPONoFm As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboRptType As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optZeroN As System.Windows.Forms.RadioButton
    Friend WithEvents optZeroY As System.Windows.Forms.RadioButton
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents optClose As System.Windows.Forms.RadioButton
    Friend WithEvents optCancel As System.Windows.Forms.RadioButton
    Friend WithEvents optOpen As System.Windows.Forms.RadioButton
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtRevDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtShpDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtShpDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRevDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIssDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtIssDatTo As System.Windows.Forms.MaskedTextBox
End Class
