Public Class frmComSearch
    Inherits System.Windows.Forms.Form

    'Public pom00010 As POM00010


    Public callFmForm As String
    Public callFmCriteria As String
    Public callFmString As String

    Public rangeMode As String

    Public frmS As Form

    Dim rs_fillinBox As New DataSet

    Dim form_POM00010 As POM00010

    Dim form_INR00014 As INR00014

    Dim form_SAM00002 As SAM00002

    Dim from_CUM00003 As CUM00003


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
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSingleValueList As System.Windows.Forms.TextBox
    Friend WithEvents cmdSVClear As System.Windows.Forms.Button
    Friend WithEvents cmdRLClear As System.Windows.Forms.Button
    Friend WithEvents cmdPVClear As System.Windows.Forms.Button
    Friend WithEvents cmdAllClear As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblSearchingCriteria As System.Windows.Forms.Label
    Friend WithEvents txtRangeList As System.Windows.Forms.TextBox
    Friend WithEvents txtPartialList As System.Windows.Forms.TextBox
    Friend WithEvents lblRangeList As System.Windows.Forms.Label
    Friend WithEvents lblPartialList As System.Windows.Forms.Label

    Friend WithEvents btcSearch As ERPSystem.BaseTabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSVDel As System.Windows.Forms.Button
    Friend WithEvents cmdSVAdd As System.Windows.Forms.Button
    Friend WithEvents lstTo As System.Windows.Forms.ListBox
    Friend WithEvents lstFrom As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboRangeFm2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboRangeTo3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboRangeFm3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboRangeTo2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboRangeTo1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboRangeFm1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRangeTo3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeFm3 As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeTo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeFm2 As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeTo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRangeFm1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPartial3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartial2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartial1 As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtSingleValueList = New System.Windows.Forms.TextBox
        Me.txtRangeList = New System.Windows.Forms.TextBox
        Me.txtPartialList = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSVClear = New System.Windows.Forms.Button
        Me.cmdRLClear = New System.Windows.Forms.Button
        Me.lblRangeList = New System.Windows.Forms.Label
        Me.cmdPVClear = New System.Windows.Forms.Button
        Me.lblPartialList = New System.Windows.Forms.Label
        Me.lblSearchingCriteria = New System.Windows.Forms.Label
        Me.cmdAllClear = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.btcSearch = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cmdSVDel = New System.Windows.Forms.Button
        Me.cmdSVAdd = New System.Windows.Forms.Button
        Me.lstTo = New System.Windows.Forms.ListBox
        Me.lstFrom = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cboRangeFm2 = New System.Windows.Forms.ComboBox
        Me.cboRangeTo3 = New System.Windows.Forms.ComboBox
        Me.cboRangeFm3 = New System.Windows.Forms.ComboBox
        Me.cboRangeTo2 = New System.Windows.Forms.ComboBox
        Me.cboRangeTo1 = New System.Windows.Forms.ComboBox
        Me.cboRangeFm1 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRangeTo3 = New System.Windows.Forms.TextBox
        Me.txtRangeFm3 = New System.Windows.Forms.TextBox
        Me.txtRangeTo2 = New System.Windows.Forms.TextBox
        Me.txtRangeFm2 = New System.Windows.Forms.TextBox
        Me.txtRangeTo1 = New System.Windows.Forms.TextBox
        Me.txtRangeFm1 = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtPartial3 = New System.Windows.Forms.TextBox
        Me.txtPartial2 = New System.Windows.Forms.TextBox
        Me.txtPartial1 = New System.Windows.Forms.TextBox
        Me.btcSearch.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSingleValueList
        '
        Me.txtSingleValueList.Enabled = False
        Me.txtSingleValueList.Location = New System.Drawing.Point(8, 49)
        Me.txtSingleValueList.Name = "txtSingleValueList"
        Me.txtSingleValueList.Size = New System.Drawing.Size(152, 20)
        Me.txtSingleValueList.TabIndex = 2
        '
        'txtRangeList
        '
        Me.txtRangeList.Enabled = False
        Me.txtRangeList.Location = New System.Drawing.Point(168, 49)
        Me.txtRangeList.Name = "txtRangeList"
        Me.txtRangeList.Size = New System.Drawing.Size(152, 20)
        Me.txtRangeList.TabIndex = 3
        '
        'txtPartialList
        '
        Me.txtPartialList.Enabled = False
        Me.txtPartialList.Location = New System.Drawing.Point(328, 49)
        Me.txtPartialList.Name = "txtPartialList"
        Me.txtPartialList.Size = New System.Drawing.Size(152, 20)
        Me.txtPartialList.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Single Value List"
        '
        'cmdSVClear
        '
        Me.cmdSVClear.Location = New System.Drawing.Point(104, 28)
        Me.cmdSVClear.Name = "cmdSVClear"
        Me.cmdSVClear.Size = New System.Drawing.Size(56, 21)
        Me.cmdSVClear.TabIndex = 6
        Me.cmdSVClear.Text = "Clear"
        '
        'cmdRLClear
        '
        Me.cmdRLClear.Location = New System.Drawing.Point(264, 28)
        Me.cmdRLClear.Name = "cmdRLClear"
        Me.cmdRLClear.Size = New System.Drawing.Size(56, 21)
        Me.cmdRLClear.TabIndex = 8
        Me.cmdRLClear.Text = "Clear"
        '
        'lblRangeList
        '
        Me.lblRangeList.Location = New System.Drawing.Point(168, 35)
        Me.lblRangeList.Name = "lblRangeList"
        Me.lblRangeList.Size = New System.Drawing.Size(88, 14)
        Me.lblRangeList.TabIndex = 7
        Me.lblRangeList.Text = "Range List"
        '
        'cmdPVClear
        '
        Me.cmdPVClear.Location = New System.Drawing.Point(424, 28)
        Me.cmdPVClear.Name = "cmdPVClear"
        Me.cmdPVClear.Size = New System.Drawing.Size(56, 21)
        Me.cmdPVClear.TabIndex = 10
        Me.cmdPVClear.Text = "Clear"
        '
        'lblPartialList
        '
        Me.lblPartialList.Location = New System.Drawing.Point(328, 35)
        Me.lblPartialList.Name = "lblPartialList"
        Me.lblPartialList.Size = New System.Drawing.Size(88, 14)
        Me.lblPartialList.TabIndex = 9
        Me.lblPartialList.Text = "Partial Value List"
        '
        'lblSearchingCriteria
        '
        Me.lblSearchingCriteria.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchingCriteria.ForeColor = System.Drawing.Color.Blue
        Me.lblSearchingCriteria.Location = New System.Drawing.Point(8, 7)
        Me.lblSearchingCriteria.Name = "lblSearchingCriteria"
        Me.lblSearchingCriteria.Size = New System.Drawing.Size(472, 21)
        Me.lblSearchingCriteria.TabIndex = 11
        Me.lblSearchingCriteria.Text = "Searching Criteria : XXX"
        '
        'cmdAllClear
        '
        Me.cmdAllClear.Location = New System.Drawing.Point(8, 319)
        Me.cmdAllClear.Name = "cmdAllClear"
        Me.cmdAllClear.Size = New System.Drawing.Size(64, 21)
        Me.cmdAllClear.TabIndex = 12
        Me.cmdAllClear.Text = "All Clear"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(416, 319)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(64, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(344, 319)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(64, 21)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        '
        'btcSearch
        '
        Me.btcSearch.Controls.Add(Me.TabPage1)
        Me.btcSearch.Controls.Add(Me.TabPage2)
        Me.btcSearch.Controls.Add(Me.TabPage3)
        Me.btcSearch.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcSearch.Location = New System.Drawing.Point(0, 75)
        Me.btcSearch.Name = "btcSearch"
        Me.btcSearch.SelectedIndex = 0
        Me.btcSearch.Size = New System.Drawing.Size(488, 231)
        Me.btcSearch.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdSVDel)
        Me.TabPage1.Controls.Add(Me.cmdSVAdd)
        Me.TabPage1.Controls.Add(Me.lstTo)
        Me.TabPage1.Controls.Add(Me.lstFrom)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(480, 205)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = " SINGLE VALUE "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdSVDel
        '
        Me.cmdSVDel.Location = New System.Drawing.Point(209, 158)
        Me.cmdSVDel.Name = "cmdSVDel"
        Me.cmdSVDel.Size = New System.Drawing.Size(64, 20)
        Me.cmdSVDel.TabIndex = 11
        Me.cmdSVDel.Text = "<< Del"
        '
        'cmdSVAdd
        '
        Me.cmdSVAdd.Location = New System.Drawing.Point(209, 67)
        Me.cmdSVAdd.Name = "cmdSVAdd"
        Me.cmdSVAdd.Size = New System.Drawing.Size(64, 21)
        Me.cmdSVAdd.TabIndex = 10
        Me.cmdSVAdd.Text = "Add >>"
        '
        'lstTo
        '
        Me.lstTo.Location = New System.Drawing.Point(281, 26)
        Me.lstTo.Name = "lstTo"
        Me.lstTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstTo.Size = New System.Drawing.Size(192, 173)
        Me.lstTo.TabIndex = 9
        '
        'lstFrom
        '
        Me.lstFrom.Location = New System.Drawing.Point(9, 26)
        Me.lstFrom.Name = "lstFrom"
        Me.lstFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFrom.Size = New System.Drawing.Size(192, 173)
        Me.lstFrom.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(281, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "To List"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(9, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "From List"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboRangeFm2)
        Me.TabPage2.Controls.Add(Me.cboRangeTo3)
        Me.TabPage2.Controls.Add(Me.cboRangeFm3)
        Me.TabPage2.Controls.Add(Me.cboRangeTo2)
        Me.TabPage2.Controls.Add(Me.cboRangeTo1)
        Me.TabPage2.Controls.Add(Me.cboRangeFm1)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtRangeTo3)
        Me.TabPage2.Controls.Add(Me.txtRangeFm3)
        Me.TabPage2.Controls.Add(Me.txtRangeTo2)
        Me.TabPage2.Controls.Add(Me.txtRangeFm2)
        Me.TabPage2.Controls.Add(Me.txtRangeTo1)
        Me.TabPage2.Controls.Add(Me.txtRangeFm1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(480, 205)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "RANGE"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cboRangeFm2
        '
        Me.cboRangeFm2.Location = New System.Drawing.Point(40, 92)
        Me.cboRangeFm2.Name = "cboRangeFm2"
        Me.cboRangeFm2.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeFm2.TabIndex = 32
        '
        'cboRangeTo3
        '
        Me.cboRangeTo3.Location = New System.Drawing.Point(280, 127)
        Me.cboRangeTo3.Name = "cboRangeTo3"
        Me.cboRangeTo3.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeTo3.TabIndex = 35
        '
        'cboRangeFm3
        '
        Me.cboRangeFm3.Location = New System.Drawing.Point(40, 127)
        Me.cboRangeFm3.Name = "cboRangeFm3"
        Me.cboRangeFm3.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeFm3.TabIndex = 34
        '
        'cboRangeTo2
        '
        Me.cboRangeTo2.Location = New System.Drawing.Point(280, 92)
        Me.cboRangeTo2.Name = "cboRangeTo2"
        Me.cboRangeTo2.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeTo2.TabIndex = 33
        '
        'cboRangeTo1
        '
        Me.cboRangeTo1.Location = New System.Drawing.Point(280, 58)
        Me.cboRangeTo1.Name = "cboRangeTo1"
        Me.cboRangeTo1.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeTo1.TabIndex = 31
        '
        'cboRangeFm1
        '
        Me.cboRangeFm1.Location = New System.Drawing.Point(40, 57)
        Me.cboRangeFm1.Name = "cboRangeFm1"
        Me.cboRangeFm1.Size = New System.Drawing.Size(192, 21)
        Me.cboRangeFm1.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(248, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "To"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(248, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(248, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "To"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "From"
        '
        'txtRangeTo3
        '
        Me.txtRangeTo3.Location = New System.Drawing.Point(280, 127)
        Me.txtRangeTo3.Name = "txtRangeTo3"
        Me.txtRangeTo3.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeTo3.TabIndex = 23
        '
        'txtRangeFm3
        '
        Me.txtRangeFm3.Location = New System.Drawing.Point(40, 127)
        Me.txtRangeFm3.Name = "txtRangeFm3"
        Me.txtRangeFm3.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeFm3.TabIndex = 22
        '
        'txtRangeTo2
        '
        Me.txtRangeTo2.Location = New System.Drawing.Point(280, 92)
        Me.txtRangeTo2.Name = "txtRangeTo2"
        Me.txtRangeTo2.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeTo2.TabIndex = 21
        '
        'txtRangeFm2
        '
        Me.txtRangeFm2.Location = New System.Drawing.Point(40, 92)
        Me.txtRangeFm2.Name = "txtRangeFm2"
        Me.txtRangeFm2.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeFm2.TabIndex = 20
        '
        'txtRangeTo1
        '
        Me.txtRangeTo1.Location = New System.Drawing.Point(280, 58)
        Me.txtRangeTo1.Name = "txtRangeTo1"
        Me.txtRangeTo1.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeTo1.TabIndex = 19
        '
        'txtRangeFm1
        '
        Me.txtRangeFm1.Location = New System.Drawing.Point(40, 58)
        Me.txtRangeFm1.Name = "txtRangeFm1"
        Me.txtRangeFm1.Size = New System.Drawing.Size(192, 20)
        Me.txtRangeFm1.TabIndex = 18
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.txtPartial3)
        Me.TabPage3.Controls.Add(Me.txtPartial2)
        Me.TabPage3.Controls.Add(Me.txtPartial1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(480, 205)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "PARTIAL"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Partial 3"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Partial 2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Partial 1"
        '
        'txtPartial3
        '
        Me.txtPartial3.Location = New System.Drawing.Point(76, 127)
        Me.txtPartial3.Name = "txtPartial3"
        Me.txtPartial3.Size = New System.Drawing.Size(392, 20)
        Me.txtPartial3.TabIndex = 8
        '
        'txtPartial2
        '
        Me.txtPartial2.Location = New System.Drawing.Point(76, 92)
        Me.txtPartial2.Name = "txtPartial2"
        Me.txtPartial2.Size = New System.Drawing.Size(392, 20)
        Me.txtPartial2.TabIndex = 7
        '
        'txtPartial1
        '
        Me.txtPartial1.Location = New System.Drawing.Point(76, 58)
        Me.txtPartial1.Name = "txtPartial1"
        Me.txtPartial1.Size = New System.Drawing.Size(392, 20)
        Me.txtPartial1.TabIndex = 6
        '
        'frmComSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 347)
        Me.Controls.Add(Me.btcSearch)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAllClear)
        Me.Controls.Add(Me.lblSearchingCriteria)
        Me.Controls.Add(Me.cmdPVClear)
        Me.Controls.Add(Me.lblPartialList)
        Me.Controls.Add(Me.cmdRLClear)
        Me.Controls.Add(Me.lblRangeList)
        Me.Controls.Add(Me.cmdSVClear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPartialList)
        Me.Controls.Add(Me.txtRangeList)
        Me.Controls.Add(Me.txtSingleValueList)
        Me.Name = "frmComSearch"
        Me.Text = "frmComSearch"
        Me.btcSearch.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public Sub show_POM00010(ByVal frm As Form)
        form_POM00010 = frm
        Me.ShowDialog()
    End Sub

    Public Sub show_INR00014(ByVal frm As Form)
        form_INR00014 = frm
        Me.ShowDialog()
    End Sub
    Public Sub show_SAM00002(ByVal frm As Form)
        form_SAM00002 = frm
        Me.ShowDialog()
    End Sub

    Public Sub show_CUM00003(ByVal frm As Form)
        from_CUM00003 = frm
        Me.ShowDialog()
    End Sub

    Public Sub show_frmS(ByVal btn As Button)
        frmS = CType(btn.FindForm, Form)
        Me.ShowDialog()
    End Sub

    Private Sub frmComSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case callFmCriteria
            Case "txt_S_CoCde"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Company Code"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = False
                'Hides the second tabpage.
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_PriCust"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Primary Customer"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_SecCust"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Secondary Customer"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_PriCustAll"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Primary Customer All"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_SecCustAll"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Secondary Customer All"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CustPONo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Customer PO Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_PONo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : PO Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_SCNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : SC Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_ItmNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Item Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txtItmNo" 'Added at 2013-04-25 for sample summary
                Me.lblSearchingCriteria.Text = "Searching Criteria : Item Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txtVenItmNo" 'Added at 2013-05-30 for sample summary 
                Me.lblSearchingCriteria.Text = "Searching Criteria : Item Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False

            Case "txt_S_ShipNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Shipment Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CV"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Custom Vendor"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_DV"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Design Vendor"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_PV"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Production Vendor"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_SalTem"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Sales Team"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_VdrCde"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Vendor Code"
                Me.btcSearch.TabPages(0).Enabled = True
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "COMBO"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_JobNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Job Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_InvNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Invoice Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CustItmNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Customer Item Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CustStyleNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Customer Style Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CaOrdNo"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Claim Number"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case "txt_S_CaSts"
                Me.lblSearchingCriteria.Text = "Searching Criteria : Claim Status"
                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = True
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
            Case Else
                Me.lblSearchingCriteria.Text = "Searching Criteria : ???"

                Me.btcSearch.TabPages(0).Enabled = False
                Me.btcSearch.TabPages(1).Enabled = False
                rangeMode = "TEXT"
                Me.btcSearch.TabPages(2).Enabled = False
        End Select

        '       If Me.tcSearch.TabPages(0).Enabled = False Then
        '       tcSearch.Controls.Remove(tcSearch.TabPages(0))
        '       End If

        '      If Me.tcSearch.TabPages(1).Enabled = False Then
        '     tcSearch.Controls.Remove(tcSearch.TabPages(1))
        '    End If

        '   If Me.tcSearch.TabPages(2).Enabled = False Then
        '  tcSearch.Controls.Remove(tcSearch.TabPages(2))
        ' End If

        If Me.btcSearch.TabPages(0).Enabled = True Then
            Me.btcSearch.SelectedTab = TabPage1
        ElseIf Me.btcSearch.TabPages(1).Enabled = True Then
            Me.btcSearch.SelectedTab = TabPage2
        End If

        rangeTabEnable()
        fillinBox()

        fillcallFmString()
    End Sub

    Private Sub fillcallFmString()
        Dim splitSel() As String
        Dim max As Long
        Dim i As Long
        Dim j As Long
        Dim strTemp As String

        If callFmString <> "" Then

            splitSel = Split(callFmString, ",")

            max = UBound(splitSel)

            For i = 0 To max
                If InStr(splitSel(i), "~") > 0 Then
                    'Range Value Handling
                    Me.txtRangeList.Text = Me.txtRangeList.Text & "," & splitSel(i).ToString
                    If Trim(cboRangeFm1.Text) = "" Then
                        For j = cboRangeFm1.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeFm1.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(0) Then
                                cboRangeFm1.Text = strTemp
                            End If
                        Next j

                        For j = cboRangeTo1.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeTo1.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(1) Then
                                cboRangeTo1.Text = strTemp
                            End If
                        Next j
                    ElseIf Trim(cboRangeFm2.Text) = "" Then
                        For j = cboRangeFm2.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeFm2.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(0) Then
                                cboRangeFm2.Text = strTemp
                            End If
                        Next j

                        For j = cboRangeTo2.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeTo2.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(1) Then
                                cboRangeTo2.Text = strTemp
                            End If
                        Next j
                    ElseIf Trim(cboRangeFm3.Text) = "" Then
                        For j = cboRangeFm3.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeFm3.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(0) Then
                                cboRangeFm3.Text = strTemp
                            End If
                        Next j

                        For j = cboRangeTo3.Items.Count - 1 To 0 Step -1
                            strTemp = cboRangeTo3.Items(j)
                            If Split(strTemp, " - ")(0) = Split(splitSel(i).ToString, "~")(1) Then
                                cboRangeTo3.Text = strTemp
                            End If
                        Next j
                    End If

                ElseIf splitSel(i).ToString.Substring(0, 1) = "%" And splitSel(i).ToString.Substring(Len(splitSel(i).ToString) - 1, 1) = "%" Then
                    'Partial Value Handling
                    Me.txtPartialList.Text = Me.txtPartialList.Text & "," & splitSel(i).ToString

                    If Trim(Me.txtPartial1.Text) = "" Then
                        Me.txtPartial1.Text = splitSel(i).ToString.Substring(2, Len(splitSel(i)) - 2)
                    ElseIf Trim(Me.txtPartial2.Text) = "" Then
                        Me.txtPartial2.Text = splitSel(i).ToString.Substring(2, Len(splitSel(i)) - 2)
                    ElseIf Trim(Me.txtPartial3.Text) = "" Then
                        Me.txtPartial3.Text = splitSel(i).ToString.Substring(2, Len(splitSel(i)) - 2)
                    End If
                Else
                    'Single Value Handling
                    Me.txtSingleValueList.Text = Me.txtSingleValueList.Text & "," & splitSel(i).ToString

                    For j = 0 To Me.lstFrom.Items.Count - 1
                        strTemp = lstFrom.Items(j)
                        If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                            lstTo.Items.Add(lstFrom.Items(j))
                        End If
                    Next j

                    For j = Me.lstFrom.Items.Count - 1 To 0 Step -1
                        strTemp = lstFrom.Items(j)
                        If Split(strTemp, " - ")(0) = Split(splitSel(i), "~")(0) Then
                            lstFrom.Items.Remove(lstFrom.Items(j))
                        End If
                    Next j
                End If
            Next i
        End If
    End Sub

    Private Sub fillinBox()
        Select Case callFmCriteria
            Case "txt_S_CoCde"
                gspStr = "sp_select_SYMUSRCO '" & gsDefaultCompany & "','" & gsUsrID & "'"
            Case "txt_S_PriCust"
                gspStr = "sp_select_CUBASINF_PC '" & gsDefaultCompany & "','" & gsUsrID & "','SC','Primary'"
            Case "txt_S_SecCust"
                gspStr = "sp_select_CUBASINF_PC '" & gsDefaultCompany & "','" & gsUsrID & "','SC','Secondary'"
            Case "txt_S_PriCustAll"
                gspStr = "sp_list_CUBASINF '','PA'"
            Case "txt_S_SecCustAll"
                gspStr = "sp_list_CUBASINF '','P'"
            Case "txt_S_CustPONo"
                gspStr = ""
            Case "txt_S_PONo"
                gspStr = ""
            Case "txt_S_SCNo"
                gspStr = ""
            Case "txt_S_ItmNo"
                gspStr = ""
            Case "txt_S_ShipNo"
                gspStr = ""
            Case "txt_S_CustItmNo"
                gspStr = ""
            Case "txt_S_CustStyleNo"
                gspStr = ""
            Case "txt_S_InvNo"
                gspStr = ""
            Case "txt_S_JobNo"
                gspStr = ""
            Case "txt_S_CaOrdNo"
                gspStr = ""
            Case "txt_S_CaSts"
                gspStr = ""
            Case "txt_S_CV"
                gspStr = "sp_list_VNBASINF ''"
            Case "txt_S_DV"
                gspStr = "sp_list_VNBASINF ''"
            Case "txt_S_PV"
                gspStr = "sp_list_VNBASINF ''"
            Case "txt_S_SalTem"
                gspStr = "sp_list_SYSALREP_CUR00002 '','" & gsUsrID & "'"
            Case "txt_S_VdrCde"
                gspStr = "sp_list_VNBASINF ''"
            Case Else
                gspStr = ""
        End Select

        If gspStr <> "" Then
            rtnLong = execute_SQLStatement(gspStr, rs_fillinBox, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading frmComSearch #001 : " & rtnStr)
                Exit Sub
            Else
                fillselection("ALL")
            End If
        End If
    End Sub

    Private Sub fillselection(ByVal mode As String)
        Dim i As Integer
        Dim strList As String

        If rs_fillinBox.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_fillinBox.Tables("RESULT").Rows.Count - 1
                strList = ""
                Select Case callFmCriteria
                    Case "txt_S_CoCde"
                        If gsDefaultCompany = "MS" Then
                            If rs_fillinBox.Tables("RESULT").Rows(i).Item("yuc_cocde") = "MS" Then
                                strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("yuc_cocde") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("yco_shtnam")
                            End If
                        Else
                            If rs_fillinBox.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                                strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("yuc_cocde") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("yco_shtnam")
                            End If
                        End If
                    Case "txt_S_PriCust"
                        If rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                            strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cussna")
                        End If
                    Case "txt_S_SecCust"
                        If rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") > "60000" Then
                            strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cussna")
                        End If
                    Case "txt_S_PriCustAll"
                        If rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                            strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cussna")
                        End If
                    Case "txt_S_SecCustAll"
                        If rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                            strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("cbi_cussna")
                        End If
                    Case "txt_S_CustPONo"
                        strList = ""
                    Case "txt_S_PONo"
                        strList = ""
                    Case "txt_S_SCNo"
                        strList = ""
                    Case "txt_S_ItmNo"
                        strList = ""
                    Case "txt_S_ShipNo"
                        strList = ""
                    Case "txt_S_CustItmNo"
                        gspStr = ""
                    Case "txt_S_CustStyleNo"
                        gspStr = ""
                    Case "txt_S_InvNo"
                        gspStr = ""
                    Case "txt_S_JobNo"
                        gspStr = ""
                    Case "txt_S_CaOrdNo"
                        gspStr = ""
                    Case "txt_S_CaSts"
                        gspStr = ""
                    Case "txt_S_CV"
                        strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_vensna")
                    Case "txt_S_DV"
                        strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_vensna")
                    Case "txt_S_PV"
                        strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_vensna")
                    Case "txt_S_SalTem"
                        strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("ysr_saltem") & " - Sales Team " & rs_fillinBox.Tables("RESULT").Rows(i).Item("ysr_saltem")
                    Case "txt_S_VdrCde"
                        strList = rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_fillinBox.Tables("RESULT").Rows(i).Item("vbi_vensna")
                    Case Else
                        strList = ""
                End Select

                If strList <> "" Then
                    If mode = "LIST" Then
                        Me.lstFrom.Items.Add(strList)
                    ElseIf mode = "COMBO" Then
                        Me.cboRangeFm1.Items.Add(strList)
                        Me.cboRangeTo1.Items.Add(strList)
                        Me.cboRangeFm2.Items.Add(strList)
                        Me.cboRangeTo2.Items.Add(strList)
                        Me.cboRangeFm3.Items.Add(strList)
                        Me.cboRangeTo3.Items.Add(strList)
                    ElseIf mode = "ALL" Then
                        Me.lstFrom.Items.Add(strList)
                        Me.cboRangeFm1.Items.Add(strList)
                        Me.cboRangeTo1.Items.Add(strList)
                        Me.cboRangeFm2.Items.Add(strList)
                        Me.cboRangeTo2.Items.Add(strList)
                        Me.cboRangeFm3.Items.Add(strList)
                        Me.cboRangeTo3.Items.Add(strList)
                    End If
                End If
            Next i
        End If
    End Sub

    Private Sub rangeTabEnable()
        If rangeMode = "TEXT" Then
            txtRangeFm1.Enabled = True
            txtRangeTo1.Enabled = True
            txtRangeFm1.Visible = True
            txtRangeTo1.Visible = True

            txtRangeFm2.Enabled = True
            txtRangeTo2.Enabled = True
            txtRangeFm2.Visible = True
            txtRangeTo2.Visible = True

            txtRangeFm3.Enabled = True
            txtRangeTo3.Enabled = True
            txtRangeFm3.Visible = True
            txtRangeTo3.Visible = True

            cboRangeFm1.Enabled = False
            cboRangeTo1.Enabled = False
            cboRangeFm1.Visible = False
            cboRangeTo1.Visible = False

            cboRangeFm2.Enabled = False
            cboRangeTo2.Enabled = False
            cboRangeFm2.Visible = False
            cboRangeTo2.Visible = False

            cboRangeFm3.Enabled = False
            cboRangeTo3.Enabled = False
            cboRangeFm3.Visible = False
            cboRangeTo3.Visible = False
        Else
            txtRangeFm1.Enabled = False
            txtRangeTo1.Enabled = False
            txtRangeFm1.Visible = False
            txtRangeTo1.Visible = False

            txtRangeFm2.Enabled = False
            txtRangeTo2.Enabled = False
            txtRangeFm2.Visible = False
            txtRangeTo2.Visible = False

            txtRangeFm3.Enabled = False
            txtRangeTo3.Enabled = False
            txtRangeFm3.Visible = False
            txtRangeTo3.Visible = False

            cboRangeFm1.Enabled = True
            cboRangeTo1.Enabled = True
            cboRangeFm1.Visible = True
            cboRangeTo1.Visible = True

            cboRangeFm2.Enabled = True
            cboRangeTo2.Enabled = True
            cboRangeFm2.Visible = True
            cboRangeTo2.Visible = True

            cboRangeFm3.Enabled = True
            cboRangeTo3.Enabled = True
            cboRangeFm3.Visible = True
            cboRangeTo3.Visible = True
        End If
    End Sub

    Private Sub setSingleValueList()
        Dim i As Integer
        Me.txtSingleValueList.Text = ""
        For i = 0 To lstTo.Items.Count - 1
            If Me.txtSingleValueList.Text = "" Then
                Me.txtSingleValueList.Text = Split(lstTo.Items(i), " - ")(0).ToString
            Else
                Me.txtSingleValueList.Text = Me.txtSingleValueList.Text & "," & Split(lstTo.Items(i), " - ")(0).ToString
            End If
        Next i
    End Sub

    Private Sub setRangeList()
        Me.txtRangeList.Text = ""

        If rangeMode = "TEXT" Then
            If Me.txtRangeFm1.Text <> "" And Me.txtRangeTo1.Text <> "" Then
                Me.txtRangeList.Text = Me.txtRangeFm1.Text & "~" & Me.txtRangeTo1.Text
            Else
                Me.txtRangeFm1.Text = ""
                Me.txtRangeTo1.Text = ""
            End If

            If Me.txtRangeFm2.Text <> "" And Me.txtRangeTo2.Text <> "" Then
                Me.txtRangeList.Text = Me.txtRangeList.Text & "," & Me.txtRangeFm2.Text & "~" & Me.txtRangeTo2.Text
            Else
                Me.txtRangeFm2.Text = ""
                Me.txtRangeTo2.Text = ""
            End If

            If Me.txtRangeFm3.Text <> "" And Me.txtRangeTo3.Text <> "" Then
                Me.txtRangeList.Text = Me.txtRangeList.Text & "," & Me.txtRangeFm3.Text & "~" & Me.txtRangeTo3.Text
            Else
                Me.txtRangeFm3.Text = ""
                Me.txtRangeTo3.Text = ""
            End If
        Else
            If Me.cboRangeFm1.Text <> "" And Me.cboRangeTo1.Text <> "" Then
                Me.txtRangeList.Text = Split(Me.cboRangeFm1.Text, " - ")(0).ToString & "~" & Split(Me.cboRangeTo1.Text, " - ")(0).ToString
            Else
                Me.cboRangeFm1.Text = ""
                Me.cboRangeTo1.Text = ""
            End If

            If Me.cboRangeFm2.Text <> "" And Me.cboRangeTo2.Text <> "" Then
                Me.txtRangeList.Text = Me.txtRangeList.Text & "," & Split(Me.cboRangeFm2.Text, " - ")(0).ToString & "~" & Split(Me.cboRangeTo2.Text, " - ")(0).ToString
            Else
                Me.cboRangeFm2.Text = ""
                Me.cboRangeTo2.Text = ""
            End If

            If Me.cboRangeFm3.Text <> "" And Me.cboRangeTo3.Text <> "" Then
                Me.txtRangeList.Text = Me.txtRangeList.Text & "," & Split(Me.cboRangeFm3.Text, " - ")(0).ToString & "~" & Split(Me.cboRangeTo3.Text, " - ")(0).ToString
            Else
                Me.cboRangeFm3.Text = ""
                Me.cboRangeTo3.Text = ""
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If btcSearch.SelectedIndex = 1 Then
            Call setRangeList()
        End If

        Dim tmpStr As String

        tmpStr = Trim(Me.txtSingleValueList.Text) & "," & Trim(Me.txtRangeList.Text) & "," & Trim(Me.txtPartialList.Text)

        If tmpStr <> ",," Then
            While tmpStr.Substring(0, 1) = ","
                tmpStr = tmpStr.Substring(1, Len(tmpStr) - 1)
            End While

            While tmpStr.Substring(Len(tmpStr) - 1, 1) = ","
                tmpStr = tmpStr.Substring(0, Len(tmpStr) - 1)
            End While
        Else
            tmpStr = ""
        End If

        Select Case callFmCriteria
            Case "txt_S_CoCde"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_CoCde.Text = tmpStr
                    Case "INR00014"
                        form_INR00014.txt_S_CoCde.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CoCde", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_PriCust"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_PriCust.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_PriCust", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_SecCust"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_SecCust.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_SecCust", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_PriCustAll"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_PriCustAll", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_SecCustAll"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_SecCustAll", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CustPONo"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_CustPONo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CustPONo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_PONo"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_PONo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_PONo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_SCNo"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_SCNo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_SCNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_ItmNo"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_ItmNo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_ItmNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txtItmNo"
                Select Case callFmForm
                    Case "SAM00002"
                        form_SAM00002.txtItmNo.Text = tmpStr
                    Case "CUM00003"
                        from_CUM00003.txtItmNo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txtItmNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txtVenItmNo" '--1
                Select Case callFmForm
                    Case "SAM00002"
                        form_SAM00002.txtVenItmNo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txtVenItmNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_ShipNo"
                Select Case callFmForm
                    'Case "POM00010"
                    '    form_POM00010.txt_S_ShipNo.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_ShipNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CV"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_CV.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CV", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_DV"
                Dim ctn() As Control = frmS.Controls.Find("txt_S_DV", True)
                ctn(0).Text = tmpStr
            Case "txt_S_PV"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_PV.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_PV", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_SalTem"
                Select Case callFmForm
                    Case "POM00010"
                        form_POM00010.txt_S_SalTem.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_SalTem", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_VdrCde"
                Select Case callFmForm
                    Case "INR00014"
                        form_INR00014.txt_S_VdrCde.Text = tmpStr
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_VdrCde", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_JobNo"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_JobNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_InvNo"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_InvNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CustItmNo"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CustItmNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CustStyleNo"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CustStyleNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CaOrdNo"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CaOrdNo", True)
                        ctn(0).Text = tmpStr
                End Select
            Case "txt_S_CaSts"
                Select Case callFmForm
                    Case Else
                        Dim ctn() As Control = frmS.Controls.Find("txt_S_CaSts", True)
                        ctn(0).Text = tmpStr
                End Select
        End Select

        'txtSingleValueList.Text = "HELLO WORLD"
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdSVAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSVAdd.Click
        Dim i As Integer
        If lstFrom.SelectedItems.Count > 0 Then
            For i = 0 To lstFrom.SelectedItems.Count - 1
                lstTo.Items.Add(lstFrom.SelectedItems(i))
            Next i
            For i = 0 To lstFrom.SelectedItems.Count - 1
                lstFrom.Items.Remove(lstFrom.SelectedItems(0))
            Next i
        End If

        lstFrom.Sorted = True
        lstTo.Sorted = True

        setSingleValueList()
    End Sub

    Private Sub cmdSVDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSVDel.Click
        Dim i As Integer
        If lstTo.SelectedItems.Count > 0 Then
            For i = 0 To lstTo.SelectedItems.Count - 1
                lstFrom.Items.Add(lstTo.SelectedItems(i))
            Next i
            For i = 0 To lstTo.SelectedItems.Count - 1
                lstTo.Items.Remove(lstTo.SelectedItems(0))
            Next i
        End If

        lstFrom.Sorted = True
        lstTo.Sorted = True

        setSingleValueList()
    End Sub

    Private Sub cmdSVClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSVClear.Click
        Me.txtSingleValueList.Text = ""
        lstFrom.Items.Clear()
        lstTo.Items.Clear()

        fillselection("LIST")
    End Sub

    Private Sub cmdRLClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRLClear.Click
        Me.txtRangeList.Text = ""
        cboRangeFm1.Text = ""
        cboRangeTo1.Text = ""
        cboRangeFm2.Text = ""
        cboRangeTo2.Text = ""
        cboRangeFm3.Text = ""
        cboRangeTo3.Text = ""

        txtRangeFm1.Text = ""
        txtRangeTo1.Text = ""
        txtRangeFm2.Text = ""
        txtRangeTo2.Text = ""
        txtRangeFm3.Text = ""
        txtRangeTo3.Text = ""
    End Sub

    Private Sub cmdPVClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPVClear.Click
        Me.txtPartialList.Text = ""
        txtPartial1.Text = ""
        txtPartial2.Text = ""
        txtPartial3.Text = ""
    End Sub

    Private Sub cmdAllClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllClear.Click
        cmdSVClear_Click(sender, e)
        cmdRLClear_Click(sender, e)
        cmdPVClear_Click(sender, e)
    End Sub
End Class