<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00017
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
        Me.grpSearchType = New System.Windows.Forms.GroupBox
        Me.optDAA = New System.Windows.Forms.RadioButton
        Me.optDAC = New System.Windows.Forms.RadioButton
        Me.optLST = New System.Windows.Forms.RadioButton
        Me.optITM = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpITM = New System.Windows.Forms.GroupBox
        Me.txtToItmNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFromItmNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpLST = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtItmLst = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.grpDAT = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtUpddatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtUpddatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpSearchDetail = New System.Windows.Forms.GroupBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboPrdVTo = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboPrdVFm = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboDsgTo = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboDsgFm = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboToCatLvl4 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboFromCatLvl4 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpSearchType.SuspendLayout()
        Me.grpITM.SuspendLayout()
        Me.grpLST.SuspendLayout()
        Me.grpDAT.SuspendLayout()
        Me.grpSearchDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearchType
        '
        Me.grpSearchType.Controls.Add(Me.optDAA)
        Me.grpSearchType.Controls.Add(Me.optDAC)
        Me.grpSearchType.Controls.Add(Me.optLST)
        Me.grpSearchType.Controls.Add(Me.optITM)
        Me.grpSearchType.Controls.Add(Me.Label1)
        Me.grpSearchType.Location = New System.Drawing.Point(12, 12)
        Me.grpSearchType.Name = "grpSearchType"
        Me.grpSearchType.Size = New System.Drawing.Size(662, 49)
        Me.grpSearchType.TabIndex = 0
        Me.grpSearchType.TabStop = False
        '
        'optDAA
        '
        Me.optDAA.AutoSize = True
        Me.optDAA.Location = New System.Drawing.Point(474, 18)
        Me.optDAA.Name = "optDAA"
        Me.optDAA.Size = New System.Drawing.Size(178, 17)
        Me.optDAA.TabIndex = 4
        Me.optDAA.TabStop = True
        Me.optDAA.Text = "Date Range w/ CUR + HIS Item"
        Me.optDAA.UseVisualStyleBackColor = True
        '
        'optDAC
        '
        Me.optDAC.AutoSize = True
        Me.optDAC.Location = New System.Drawing.Point(320, 18)
        Me.optDAC.Name = "optDAC"
        Me.optDAC.Size = New System.Drawing.Size(148, 17)
        Me.optDAC.TabIndex = 3
        Me.optDAC.TabStop = True
        Me.optDAC.Text = "Date Range w/ CUR Item"
        Me.optDAC.UseVisualStyleBackColor = True
        '
        'optLST
        '
        Me.optLST.AutoSize = True
        Me.optLST.Location = New System.Drawing.Point(210, 18)
        Me.optLST.Name = "optLST"
        Me.optLST.Size = New System.Drawing.Size(104, 17)
        Me.optLST.TabIndex = 2
        Me.optLST.TabStop = True
        Me.optLST.Text = "Item Number List"
        Me.optLST.UseVisualStyleBackColor = True
        '
        'optITM
        '
        Me.optITM.AutoSize = True
        Me.optITM.Location = New System.Drawing.Point(84, 18)
        Me.optITM.Name = "optITM"
        Me.optITM.Size = New System.Drawing.Size(120, 17)
        Me.optITM.TabIndex = 1
        Me.optITM.TabStop = True
        Me.optITM.Text = "Item Number Range"
        Me.optITM.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Type:"
        '
        'grpITM
        '
        Me.grpITM.Controls.Add(Me.txtToItmNo)
        Me.grpITM.Controls.Add(Me.Label4)
        Me.grpITM.Controls.Add(Me.txtFromItmNo)
        Me.grpITM.Controls.Add(Me.Label3)
        Me.grpITM.Controls.Add(Me.Label2)
        Me.grpITM.Location = New System.Drawing.Point(12, 67)
        Me.grpITM.Name = "grpITM"
        Me.grpITM.Size = New System.Drawing.Size(662, 62)
        Me.grpITM.TabIndex = 1
        Me.grpITM.TabStop = False
        '
        'txtToItmNo
        '
        Me.txtToItmNo.Location = New System.Drawing.Point(417, 17)
        Me.txtToItmNo.Name = "txtToItmNo"
        Me.txtToItmNo.Size = New System.Drawing.Size(165, 20)
        Me.txtToItmNo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(388, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "To:"
        '
        'txtFromItmNo
        '
        Me.txtFromItmNo.Location = New System.Drawing.Point(149, 17)
        Me.txtFromItmNo.Name = "txtFromItmNo"
        Me.txtFromItmNo.Size = New System.Drawing.Size(165, 20)
        Me.txtFromItmNo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item Number:"
        '
        'grpLST
        '
        Me.grpLST.Controls.Add(Me.Label8)
        Me.grpLST.Controls.Add(Me.Label6)
        Me.grpLST.Controls.Add(Me.Label5)
        Me.grpLST.Controls.Add(Me.txtItmLst)
        Me.grpLST.Controls.Add(Me.Label7)
        Me.grpLST.Location = New System.Drawing.Point(12, 67)
        Me.grpLST.Name = "grpLST"
        Me.grpLST.Size = New System.Drawing.Size(662, 62)
        Me.grpLST.TabIndex = 2
        Me.grpLST.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(370, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Note: Maximum 30 Items Allowed"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 39)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(110, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(233, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Seperate each item number by an asterick (      )"
        '
        'txtItmLst
        '
        Me.txtItmLst.Location = New System.Drawing.Point(113, 17)
        Me.txtItmLst.Name = "txtItmLst"
        Me.txtItmLst.Size = New System.Drawing.Size(527, 20)
        Me.txtItmLst.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Number List:"
        '
        'grpDAT
        '
        Me.grpDAT.Controls.Add(Me.Label14)
        Me.grpDAT.Controls.Add(Me.Label13)
        Me.grpDAT.Controls.Add(Me.Label12)
        Me.grpDAT.Controls.Add(Me.txtUpddatTo)
        Me.grpDAT.Controls.Add(Me.Label11)
        Me.grpDAT.Controls.Add(Me.txtUpddatFm)
        Me.grpDAT.Controls.Add(Me.Label10)
        Me.grpDAT.Controls.Add(Me.Label9)
        Me.grpDAT.Location = New System.Drawing.Point(12, 68)
        Me.grpDAT.Name = "grpDAT"
        Me.grpDAT.Size = New System.Drawing.Size(662, 62)
        Me.grpDAT.TabIndex = 3
        Me.grpDAT.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(110, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(465, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "(Update Date of Item Basic Info./ Design Vendor Cost Markup / Production Vendor C" & _
            "ost Markup)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(504, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "(MM/DD/YYYY)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(233, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "(MM/DD/YYYY)"
        '
        'txtUpddatTo
        '
        Me.txtUpddatTo.Location = New System.Drawing.Point(417, 17)
        Me.txtUpddatTo.Mask = "##/##/####"
        Me.txtUpddatTo.Name = "txtUpddatTo"
        Me.txtUpddatTo.Size = New System.Drawing.Size(81, 20)
        Me.txtUpddatTo.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(381, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "To"
        '
        'txtUpddatFm
        '
        Me.txtUpddatFm.Location = New System.Drawing.Point(146, 17)
        Me.txtUpddatFm.Mask = "##/##/####"
        Me.txtUpddatFm.Name = "txtUpddatFm"
        Me.txtUpddatFm.Size = New System.Drawing.Size(81, 20)
        Me.txtUpddatFm.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(110, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Update Date:"
        '
        'grpSearchDetail
        '
        Me.grpSearchDetail.Controls.Add(Me.cboStatus)
        Me.grpSearchDetail.Controls.Add(Me.Label25)
        Me.grpSearchDetail.Controls.Add(Me.cboPrdVTo)
        Me.grpSearchDetail.Controls.Add(Me.Label21)
        Me.grpSearchDetail.Controls.Add(Me.cboPrdVFm)
        Me.grpSearchDetail.Controls.Add(Me.Label22)
        Me.grpSearchDetail.Controls.Add(Me.Label23)
        Me.grpSearchDetail.Controls.Add(Me.cboDsgTo)
        Me.grpSearchDetail.Controls.Add(Me.Label18)
        Me.grpSearchDetail.Controls.Add(Me.cboDsgFm)
        Me.grpSearchDetail.Controls.Add(Me.Label19)
        Me.grpSearchDetail.Controls.Add(Me.Label20)
        Me.grpSearchDetail.Controls.Add(Me.cboToCatLvl4)
        Me.grpSearchDetail.Controls.Add(Me.Label17)
        Me.grpSearchDetail.Controls.Add(Me.cboFromCatLvl4)
        Me.grpSearchDetail.Controls.Add(Me.Label16)
        Me.grpSearchDetail.Controls.Add(Me.Label15)
        Me.grpSearchDetail.Location = New System.Drawing.Point(13, 136)
        Me.grpSearchDetail.Name = "grpSearchDetail"
        Me.grpSearchDetail.Size = New System.Drawing.Size(661, 142)
        Me.grpSearchDetail.TabIndex = 3
        Me.grpSearchDetail.TabStop = False
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(145, 108)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(225, 21)
        Me.cboStatus.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 111)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 15
        Me.Label25.Text = "Item Status:"
        '
        'cboPrdVTo
        '
        Me.cboPrdVTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdVTo.FormattingEnabled = True
        Me.cboPrdVTo.Location = New System.Drawing.Point(406, 77)
        Me.cboPrdVTo.Name = "cboPrdVTo"
        Me.cboPrdVTo.Size = New System.Drawing.Size(225, 21)
        Me.cboPrdVTo.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(380, 80)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "To"
        '
        'cboPrdVFm
        '
        Me.cboPrdVFm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdVFm.FormattingEnabled = True
        Me.cboPrdVFm.Location = New System.Drawing.Point(145, 77)
        Me.cboPrdVFm.Name = "cboPrdVFm"
        Me.cboPrdVFm.Size = New System.Drawing.Size(225, 21)
        Me.cboPrdVFm.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(109, 80)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "From"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(95, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Production Vendor"
        '
        'cboDsgTo
        '
        Me.cboDsgTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDsgTo.FormattingEnabled = True
        Me.cboDsgTo.Location = New System.Drawing.Point(406, 47)
        Me.cboDsgTo.Name = "cboDsgTo"
        Me.cboDsgTo.Size = New System.Drawing.Size(225, 21)
        Me.cboDsgTo.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(380, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(20, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "To"
        '
        'cboDsgFm
        '
        Me.cboDsgFm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDsgFm.FormattingEnabled = True
        Me.cboDsgFm.Location = New System.Drawing.Point(145, 47)
        Me.cboDsgFm.Name = "cboDsgFm"
        Me.cboDsgFm.Size = New System.Drawing.Size(225, 21)
        Me.cboDsgFm.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(109, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "From"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Design Vendor"
        '
        'cboToCatLvl4
        '
        Me.cboToCatLvl4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToCatLvl4.FormattingEnabled = True
        Me.cboToCatLvl4.Location = New System.Drawing.Point(406, 17)
        Me.cboToCatLvl4.Name = "cboToCatLvl4"
        Me.cboToCatLvl4.Size = New System.Drawing.Size(225, 21)
        Me.cboToCatLvl4.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(380, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 13)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "To"
        '
        'cboFromCatLvl4
        '
        Me.cboFromCatLvl4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromCatLvl4.FormattingEnabled = True
        Me.cboFromCatLvl4.Location = New System.Drawing.Point(145, 17)
        Me.cboFromCatLvl4.Name = "cboFromCatLvl4"
        Me.cboFromCatLvl4.Size = New System.Drawing.Size(225, 21)
        Me.cboFromCatLvl4.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "From"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Category Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(297, 291)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(92, 27)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00017
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 332)
        Me.Controls.Add(Me.grpDAT)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearchDetail)
        Me.Controls.Add(Me.grpLST)
        Me.Controls.Add(Me.grpITM)
        Me.Controls.Add(Me.grpSearchType)
        Me.Name = "IMR00017"
        Me.Text = "IMR00017 - Item Pricing Report (Export to Excel)"
        Me.grpSearchType.ResumeLayout(False)
        Me.grpSearchType.PerformLayout()
        Me.grpITM.ResumeLayout(False)
        Me.grpITM.PerformLayout()
        Me.grpLST.ResumeLayout(False)
        Me.grpLST.PerformLayout()
        Me.grpDAT.ResumeLayout(False)
        Me.grpDAT.PerformLayout()
        Me.grpSearchDetail.ResumeLayout(False)
        Me.grpSearchDetail.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSearchType As System.Windows.Forms.GroupBox
    Friend WithEvents optITM As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optDAC As System.Windows.Forms.RadioButton
    Friend WithEvents optLST As System.Windows.Forms.RadioButton
    Friend WithEvents optDAA As System.Windows.Forms.RadioButton
    Friend WithEvents grpITM As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtToItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFromItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpLST As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItmLst As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents grpDAT As System.Windows.Forms.GroupBox
    Friend WithEvents txtUpddatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUpddatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpSearchDetail As System.Windows.Forms.GroupBox
    Friend WithEvents cboToCatLvl4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboFromCatLvl4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboPrdVTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboPrdVFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboDsgTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboDsgFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
