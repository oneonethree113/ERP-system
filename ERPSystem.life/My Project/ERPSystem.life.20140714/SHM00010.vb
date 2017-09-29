Public Class SHM00010
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdocno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCredat As System.Windows.Forms.TextBox
    Friend WithEvents txtUpddat As System.Windows.Forms.TextBox
    Friend WithEvents pDocTyp As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbDocTyp_D As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocTyp_C As System.Windows.Forms.RadioButton
    Friend WithEvents btcSHM00010 As ERPSystem.BaseTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgSHCHGDTL_CORE As System.Windows.Forms.DataGridView
    Friend WithEvents dgSHCHGDTL_Distribute As System.Windows.Forms.DataGridView
    Friend WithEvents gbDocTyp_D_Entry As System.Windows.Forms.GroupBox
    Friend WithEvents txtCustList As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtInvNoList As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbDocTyp_C_Entry As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCtn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbHeaderMain As System.Windows.Forms.GroupBox
    Friend WithEvents cboCtnSiz As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtfwdnam As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboBCurr As System.Windows.Forms.ComboBox
    Friend WithEvents cboFCurr As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mskExchRat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtfcrno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFwdInv As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdInvMore As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents rtxtRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents lstVendor As System.Windows.Forms.ListBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCusNoList As System.Windows.Forms.TextBox
    Friend WithEvents dgINVMORE As System.Windows.Forms.DataGridView
    Friend WithEvents mskETDDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents mskPckDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents ssBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.ssBar = New System.Windows.Forms.StatusBar
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdocno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCredat = New System.Windows.Forms.TextBox
        Me.txtUpddat = New System.Windows.Forms.TextBox
        Me.pDocTyp = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.rbDocTyp_D = New System.Windows.Forms.RadioButton
        Me.rbDocTyp_C = New System.Windows.Forms.RadioButton
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btcSHM00010 = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgINVMORE = New System.Windows.Forms.DataGridView
        Me.cmdInvMore = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.gbHeaderMain = New System.Windows.Forms.GroupBox
        Me.mskPckDat = New System.Windows.Forms.DateTimePicker
        Me.Label19 = New System.Windows.Forms.Label
        Me.rtxtRmk = New System.Windows.Forms.RichTextBox
        Me.cboCtnSiz = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtfwdnam = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboBCurr = New System.Windows.Forms.ComboBox
        Me.cboFCurr = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.mskExchRat = New System.Windows.Forms.MaskedTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtfcrno = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFwdInv = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.gbDocTyp_D_Entry = New System.Windows.Forms.GroupBox
        Me.txtCusNoList = New System.Windows.Forms.TextBox
        Me.txtCustList = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtInvNoList = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbDocTyp_C_Entry = New System.Windows.Forms.GroupBox
        Me.mskETDDat = New System.Windows.Forms.DateTimePicker
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCtn = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgSHCHGDTL_Distribute = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lstVendor = New System.Windows.Forms.ListBox
        Me.dgSHCHGDTL_CORE = New System.Windows.Forms.DataGridView
        Me.pDocTyp.SuspendLayout()
        Me.btcSHM00010.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgINVMORE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbHeaderMain.SuspendLayout()
        Me.gbDocTyp_D_Entry.SuspendLayout()
        Me.gbDocTyp_C_Entry.SuspendLayout()
        CType(Me.dgSHCHGDTL_Distribute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgSHCHGDTL_CORE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "Cancel"
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 480)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(752, 16)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(645, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(565, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(605, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(692, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(466, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(525, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(410, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(341, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "Searc&h"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Doc No :"
        '
        'txtdocno
        '
        Me.txtdocno.Location = New System.Drawing.Point(62, 45)
        Me.txtdocno.Name = "txtdocno"
        Me.txtdocno.Size = New System.Drawing.Size(91, 22)
        Me.txtdocno.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(374, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Create :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(504, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Update :"
        '
        'txtCredat
        '
        Me.txtCredat.Enabled = False
        Me.txtCredat.Location = New System.Drawing.Point(426, 44)
        Me.txtCredat.Name = "txtCredat"
        Me.txtCredat.Size = New System.Drawing.Size(76, 22)
        Me.txtCredat.TabIndex = 17
        '
        'txtUpddat
        '
        Me.txtUpddat.Enabled = False
        Me.txtUpddat.Location = New System.Drawing.Point(561, 44)
        Me.txtUpddat.Name = "txtUpddat"
        Me.txtUpddat.Size = New System.Drawing.Size(76, 22)
        Me.txtUpddat.TabIndex = 18
        '
        'pDocTyp
        '
        Me.pDocTyp.Controls.Add(Me.Label4)
        Me.pDocTyp.Controls.Add(Me.rbDocTyp_D)
        Me.pDocTyp.Controls.Add(Me.rbDocTyp_C)
        Me.pDocTyp.Location = New System.Drawing.Point(159, 42)
        Me.pDocTyp.Name = "pDocTyp"
        Me.pDocTyp.Size = New System.Drawing.Size(209, 30)
        Me.pDocTyp.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Doc Type :"
        '
        'rbDocTyp_D
        '
        Me.rbDocTyp_D.AutoSize = True
        Me.rbDocTyp_D.Location = New System.Drawing.Point(139, 3)
        Me.rbDocTyp_D.Name = "rbDocTyp_D"
        Me.rbDocTyp_D.Size = New System.Drawing.Size(58, 20)
        Me.rbDocTyp_D.TabIndex = 16
        Me.rbDocTyp_D.Text = "床砯"
        Me.rbDocTyp_D.UseVisualStyleBackColor = True
        '
        'rbDocTyp_C
        '
        Me.rbDocTyp_C.AutoSize = True
        Me.rbDocTyp_C.Location = New System.Drawing.Point(74, 3)
        Me.rbDocTyp_C.Name = "rbDocTyp_C"
        Me.rbDocTyp_C.Size = New System.Drawing.Size(58, 20)
        Me.rbDocTyp_C.TabIndex = 15
        Me.rbDocTyp_C.Text = "螥砯"
        Me.rbDocTyp_C.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(689, 44)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(50, 22)
        Me.txtStatus.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(643, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 16)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Status :"
        '
        'btcSHM00010
        '
        Me.btcSHM00010.Controls.Add(Me.TabPage1)
        Me.btcSHM00010.Controls.Add(Me.TabPage2)
        Me.btcSHM00010.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcSHM00010.Location = New System.Drawing.Point(2, 67)
        Me.btcSHM00010.Name = "btcSHM00010"
        Me.btcSHM00010.SelectedIndex = 0
        Me.btcSHM00010.Size = New System.Drawing.Size(750, 417)
        Me.btcSHM00010.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgINVMORE)
        Me.TabPage1.Controls.Add(Me.cmdInvMore)
        Me.TabPage1.Controls.Add(Me.cmdRefresh)
        Me.TabPage1.Controls.Add(Me.gbHeaderMain)
        Me.TabPage1.Controls.Add(Me.gbDocTyp_D_Entry)
        Me.TabPage1.Controls.Add(Me.gbDocTyp_C_Entry)
        Me.TabPage1.Controls.Add(Me.dgSHCHGDTL_Distribute)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(742, 388)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Header"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgINVMORE
        '
        Me.dgINVMORE.AllowUserToAddRows = False
        Me.dgINVMORE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgINVMORE.Location = New System.Drawing.Point(329, 47)
        Me.dgINVMORE.Name = "dgINVMORE"
        Me.dgINVMORE.RowHeadersWidth = 30
        Me.dgINVMORE.Size = New System.Drawing.Size(362, 156)
        Me.dgINVMORE.TabIndex = 85
        Me.dgINVMORE.Visible = False
        '
        'cmdInvMore
        '
        Me.cmdInvMore.Location = New System.Drawing.Point(691, 58)
        Me.cmdInvMore.Name = "cmdInvMore"
        Me.cmdInvMore.Size = New System.Drawing.Size(27, 23)
        Me.cmdInvMore.TabIndex = 84
        Me.cmdInvMore.Text = ".."
        Me.cmdInvMore.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(519, 7)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(61, 34)
        Me.cmdRefresh.TabIndex = 83
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'gbHeaderMain
        '
        Me.gbHeaderMain.Controls.Add(Me.mskPckDat)
        Me.gbHeaderMain.Controls.Add(Me.Label19)
        Me.gbHeaderMain.Controls.Add(Me.rtxtRmk)
        Me.gbHeaderMain.Controls.Add(Me.cboCtnSiz)
        Me.gbHeaderMain.Controls.Add(Me.Label14)
        Me.gbHeaderMain.Controls.Add(Me.txtfwdnam)
        Me.gbHeaderMain.Controls.Add(Me.Label17)
        Me.gbHeaderMain.Controls.Add(Me.cboBCurr)
        Me.gbHeaderMain.Controls.Add(Me.cboFCurr)
        Me.gbHeaderMain.Controls.Add(Me.Label16)
        Me.gbHeaderMain.Controls.Add(Me.Label13)
        Me.gbHeaderMain.Controls.Add(Me.mskExchRat)
        Me.gbHeaderMain.Controls.Add(Me.Label12)
        Me.gbHeaderMain.Controls.Add(Me.Label11)
        Me.gbHeaderMain.Controls.Add(Me.txtfcrno)
        Me.gbHeaderMain.Controls.Add(Me.Label9)
        Me.gbHeaderMain.Controls.Add(Me.txtFwdInv)
        Me.gbHeaderMain.Controls.Add(Me.Label8)
        Me.gbHeaderMain.Location = New System.Drawing.Point(8, 122)
        Me.gbHeaderMain.Name = "gbHeaderMain"
        Me.gbHeaderMain.Size = New System.Drawing.Size(728, 161)
        Me.gbHeaderMain.TabIndex = 82
        Me.gbHeaderMain.TabStop = False
        '
        'mskPckDat
        '
        Me.mskPckDat.CustomFormat = ""
        Me.mskPckDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskPckDat.Location = New System.Drawing.Point(349, 99)
        Me.mskPckDat.Name = "mskPckDat"
        Me.mskPckDat.Size = New System.Drawing.Size(91, 22)
        Me.mskPckDat.TabIndex = 97
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(251, 103)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 16)
        Me.Label19.TabIndex = 96
        Me.Label19.Text = "杆螥/óら戳 :"
        '
        'rtxtRmk
        '
        Me.rtxtRmk.Location = New System.Drawing.Point(459, 26)
        Me.rtxtRmk.Name = "rtxtRmk"
        Me.rtxtRmk.Size = New System.Drawing.Size(263, 96)
        Me.rtxtRmk.TabIndex = 27
        Me.rtxtRmk.Text = ""
        '
        'cboCtnSiz
        '
        Me.cboCtnSiz.FormattingEnabled = True
        Me.cboCtnSiz.ItemHeight = 16
        Me.cboCtnSiz.Location = New System.Drawing.Point(123, 100)
        Me.cboCtnSiz.Name = "cboCtnSiz"
        Me.cboCtnSiz.Size = New System.Drawing.Size(122, 24)
        Me.cboCtnSiz.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 16)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Container Size :"
        '
        'txtfwdnam
        '
        Me.txtfwdnam.Location = New System.Drawing.Point(123, 15)
        Me.txtfwdnam.Name = "txtfwdnam"
        Me.txtfwdnam.Size = New System.Drawing.Size(317, 22)
        Me.txtfwdnam.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 16)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Forwarder Name :"
        '
        'cboBCurr
        '
        Me.cboBCurr.FormattingEnabled = True
        Me.cboBCurr.Location = New System.Drawing.Point(303, 130)
        Me.cboBCurr.Name = "cboBCurr"
        Me.cboBCurr.Size = New System.Drawing.Size(65, 24)
        Me.cboBCurr.TabIndex = 29
        '
        'cboFCurr
        '
        Me.cboFCurr.FormattingEnabled = True
        Me.cboFCurr.Location = New System.Drawing.Point(122, 130)
        Me.cboFCurr.Name = "cboFCurr"
        Me.cboFCurr.Size = New System.Drawing.Size(70, 24)
        Me.cboFCurr.TabIndex = 28
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(456, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 88
        Me.Label16.Text = "Remarks :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(374, 132)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 16)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Exch Rate :"
        '
        'mskExchRat
        '
        Me.mskExchRat.Location = New System.Drawing.Point(457, 130)
        Me.mskExchRat.Mask = "#.########"
        Me.mskExchRat.Name = "mskExchRat"
        Me.mskExchRat.Size = New System.Drawing.Size(99, 22)
        Me.mskExchRat.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(212, 133)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 16)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Base Curr. :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 16)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Forwarder Curr. :"
        '
        'txtfcrno
        '
        Me.txtfcrno.Location = New System.Drawing.Point(122, 71)
        Me.txtfcrno.Name = "txtfcrno"
        Me.txtfcrno.Size = New System.Drawing.Size(318, 22)
        Me.txtfcrno.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "FCR No :"
        '
        'txtFwdInv
        '
        Me.txtFwdInv.Location = New System.Drawing.Point(122, 43)
        Me.txtFwdInv.Name = "txtFwdInv"
        Me.txtFwdInv.Size = New System.Drawing.Size(318, 22)
        Me.txtFwdInv.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 16)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Forwarder Invoice :"
        '
        'gbDocTyp_D_Entry
        '
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtCusNoList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtCustList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label10)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtInvNoList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label7)
        Me.gbDocTyp_D_Entry.Location = New System.Drawing.Point(6, 43)
        Me.gbDocTyp_D_Entry.Name = "gbDocTyp_D_Entry"
        Me.gbDocTyp_D_Entry.Size = New System.Drawing.Size(679, 79)
        Me.gbDocTyp_D_Entry.TabIndex = 81
        Me.gbDocTyp_D_Entry.TabStop = False
        '
        'txtCusNoList
        '
        Me.txtCusNoList.Enabled = False
        Me.txtCusNoList.Location = New System.Drawing.Point(87, 55)
        Me.txtCusNoList.Name = "txtCusNoList"
        Me.txtCusNoList.Size = New System.Drawing.Size(580, 22)
        Me.txtCusNoList.TabIndex = 75
        Me.txtCusNoList.Visible = False
        '
        'txtCustList
        '
        Me.txtCustList.Enabled = False
        Me.txtCustList.Location = New System.Drawing.Point(87, 43)
        Me.txtCustList.Name = "txtCustList"
        Me.txtCustList.Size = New System.Drawing.Size(580, 22)
        Me.txtCustList.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 16)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Customer :"
        '
        'txtInvNoList
        '
        Me.txtInvNoList.Location = New System.Drawing.Point(87, 15)
        Me.txtInvNoList.Name = "txtInvNoList"
        Me.txtInvNoList.Size = New System.Drawing.Size(580, 22)
        Me.txtInvNoList.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 16)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Invoice No :"
        '
        'gbDocTyp_C_Entry
        '
        Me.gbDocTyp_C_Entry.Controls.Add(Me.mskETDDat)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label18)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label6)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.txtCtn)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label5)
        Me.gbDocTyp_C_Entry.Location = New System.Drawing.Point(6, -1)
        Me.gbDocTyp_C_Entry.Name = "gbDocTyp_C_Entry"
        Me.gbDocTyp_C_Entry.Size = New System.Drawing.Size(511, 44)
        Me.gbDocTyp_C_Entry.TabIndex = 80
        Me.gbDocTyp_C_Entry.TabStop = False
        '
        'mskETDDat
        '
        Me.mskETDDat.CustomFormat = ""
        Me.mskETDDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskETDDat.Location = New System.Drawing.Point(314, 14)
        Me.mskETDDat.Name = "mskETDDat"
        Me.mskETDDat.Size = New System.Drawing.Size(91, 22)
        Me.mskETDDat.TabIndex = 76
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(411, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 16)
        Me.Label18.TabIndex = 74
        Me.Label18.Text = "MM/DD/YYYY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "ETD Date :"
        '
        'txtCtn
        '
        Me.txtCtn.Location = New System.Drawing.Point(105, 14)
        Me.txtCtn.Name = "txtCtn"
        Me.txtCtn.Size = New System.Drawing.Size(112, 22)
        Me.txtCtn.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Container No :"
        '
        'dgSHCHGDTL_Distribute
        '
        Me.dgSHCHGDTL_Distribute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSHCHGDTL_Distribute.Location = New System.Drawing.Point(6, 289)
        Me.dgSHCHGDTL_Distribute.Name = "dgSHCHGDTL_Distribute"
        Me.dgSHCHGDTL_Distribute.RowHeadersWidth = 30
        Me.dgSHCHGDTL_Distribute.Size = New System.Drawing.Size(730, 93)
        Me.dgSHCHGDTL_Distribute.TabIndex = 31
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstVendor)
        Me.TabPage2.Controls.Add(Me.dgSHCHGDTL_CORE)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(742, 388)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Detail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstVendor
        '
        Me.lstVendor.FormattingEnabled = True
        Me.lstVendor.ItemHeight = 16
        Me.lstVendor.Location = New System.Drawing.Point(6, 207)
        Me.lstVendor.Name = "lstVendor"
        Me.lstVendor.Size = New System.Drawing.Size(161, 132)
        Me.lstVendor.TabIndex = 17
        Me.lstVendor.Visible = False
        '
        'dgSHCHGDTL_CORE
        '
        Me.dgSHCHGDTL_CORE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSHCHGDTL_CORE.Location = New System.Drawing.Point(6, 9)
        Me.dgSHCHGDTL_CORE.Name = "dgSHCHGDTL_CORE"
        Me.dgSHCHGDTL_CORE.RowHeadersWidth = 30
        Me.dgSHCHGDTL_CORE.Size = New System.Drawing.Size(717, 367)
        Me.dgSHCHGDTL_CORE.TabIndex = 16
        '
        'SHM00010
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btcSHM00010)
        Me.Controls.Add(Me.pDocTyp)
        Me.Controls.Add(Me.txtUpddat)
        Me.Controls.Add(Me.txtCredat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdocno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssBar)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(760, 530)
        Me.MinimumSize = New System.Drawing.Size(760, 530)
        Me.Name = "SHM00010"
        Me.Text = "SHM00010 -Shipping Charges Maintenance"
        Me.pDocTyp.ResumeLayout(False)
        Me.pDocTyp.PerformLayout()
        Me.btcSHM00010.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgINVMORE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbHeaderMain.ResumeLayout(False)
        Me.gbHeaderMain.PerformLayout()
        Me.gbDocTyp_D_Entry.ResumeLayout(False)
        Me.gbDocTyp_D_Entry.PerformLayout()
        Me.gbDocTyp_C_Entry.ResumeLayout(False)
        Me.gbDocTyp_C_Entry.PerformLayout()
        CType(Me.dgSHCHGDTL_Distribute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgSHCHGDTL_CORE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYMSHC_ALL As New DataSet
    Public rs_SYMSHC_D As New DataSet
    Public rs_VNBASINF As New DataSet

    Public rs_SHCHGDTL_Distribute As New DataSet
    Public rs_SHCHGDTL_CORE As New DataSet

    Public rs_SHIPGDTL_CTNETD As New DataSet

    Public rs_SHCHGHDR As New DataSet
    Public rs_SHCHGDTL As New DataSet

    Public rs_DOC_GEN As New DataSet

    Public rs_INVMORE As New DataSet

    Public rs_tmp As New DataSet

    Dim Add_flag As Boolean
    Dim Upd_flag As Boolean
    Dim Insert_flag As Boolean

    Dim calculate_dgSHCHGDTL_CORE_flag As Boolean

    Dim changeManualCBM As Boolean



    Private Sub SHM00010_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gspStr = "sp_select_SYMSHC '','ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMSHC_ALL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #001 sp_select_SYMSHC : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYMSHC '','D'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMSHC_D, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #002 sp_select_SYMSHC : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF_vensna ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #003 sp_list_VNBASINF_vensna : " & rtnStr)
            Exit Sub
        End If


        Call format_ComboBox()
        Call format_lstVendor()


        mode = "INIT"
        Call formInit(mode)

        Call format_dgSHCHGDTL_Distribute("NONE")
        Call format_dgSHCHGDTL_CORE()

        Call format_dgINVMORE()


        ' dgSHCHGDTL.DataSource = rs_SYMSHC.Tables("RESULT").DefaultView

        'rs_SYMSHC.Tables("RESULT").Columns(0).ReadOnly = False

        Call Formstartup(Me.Name)


        'for testing
        'Me.txtCtn.Text = "MOFU0718132"
        'Me.mskETDDat.Text = "07/14/2009"

    End Sub



    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub format_ComboBox()
        cboFCurr.Text = ""
        cboFCurr.Items.Add("HKD")
        cboFCurr.Items.Add("CNY")

        cboBCurr.Text = ""
        cboBCurr.Items.Add("HKD")
        cboBCurr.Items.Add("CNY")
        cboBCurr.Text = "HKD"
        cboBCurr.Enabled = False

        cboCtnSiz.Text = ""
        cboCtnSiz.Items.Add("20'")
        cboCtnSiz.Items.Add("40' (8.5')")
        cboCtnSiz.Items.Add("40' (HQ)")
        cboCtnSiz.Items.Add("40' (HR)")
        cboCtnSiz.Items.Add("45'")


    End Sub

    Private Sub format_lstVendor()
        Dim i As Integer
        For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
            If rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensts") = "A" Then
                lstVendor.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
            End If
        Next i
    End Sub

    Private Sub format_dgINVMORE()
        If rs_INVMORE.Tables.Count = 0 Then
            rs_INVMORE.Tables.Add("RESULT")
            'column 0 Invoice No
            rs_INVMORE.Tables("RESULT").Columns.Add("INVNO")
            rs_INVMORE.Tables("RESULT").Columns.Add("CUSNO")
            rs_INVMORE.Tables("RESULT").Columns.Add("CUSNAME")
        End If

        dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT").DefaultView


        dgINVMORE.Columns(0).HeaderText = "Invoice No"
        dgINVMORE.Columns(0).Width = 100
        dgINVMORE.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

        dgINVMORE.Columns(1).HeaderText = "Customer No"
        dgINVMORE.Columns(1).Width = 100
        dgINVMORE.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

        dgINVMORE.Columns(2).HeaderText = "Cust. Name"
        dgINVMORE.Columns(2).Width = 100
        dgINVMORE.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable


    End Sub

    Private Sub display_dgINVMORE()
        Dim sInvNo As String()
        Dim sCusNo As String()
        Dim sCusName As String()

        sInvNo = Split(Me.txtInvNoList.Text, ",")
        sCusNo = Split(Me.txtCusNoList.Text, ",")
        sCusName = Split(Me.txtCustList.Text, ",")

        If sInvNo.Length <> sCusNo.Length Or sCusNo.Length <> sCusName.Length Then
            MsgBox("Error on loading SHM00010 #018 : Invalid Invoice vs Customer List")
            Exit Sub
        End If

        Dim i As Integer

        If rs_INVMORE.Tables("RESULT").Rows.Count > 0 Then
            rs_INVMORE.Tables("RESULT").Rows.Clear()
        End If

        For i = 0 To sInvNo.Length - 1
            dsNewRow = rs_INVMORE.Tables("RESULT").NewRow()
            dsNewRow.Item("INVNO") = sInvNo(i)
            dsNewRow.Item("CUSNO") = sCusNo(i)
            dsNewRow.Item("CUSNAME") = sCusName(i)

            rs_INVMORE.Tables("RESULT").Rows.Add(dsNewRow)
        Next i

    End Sub

    Private Sub format_dgSHCHGDTL_Distribute(ByVal m As String)
        Dim i As Integer

        If rs_SHCHGDTL_Distribute.Tables.Count = 0 Then
            rs_SHCHGDTL_Distribute.Tables.Add("RESULT")

            'column 0 Vendor
            rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add("VENDOR")

            For i = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add(rs_SYMSHC_D.Tables("RESULT").Rows(i).Item("ysc_chgcde"))
            Next i

            ' last column 'Total'
            rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add("TOTAL")
        End If

        dgSHCHGDTL_Distribute.DataSource = rs_SHCHGDTL_Distribute.Tables("RESULT").DefaultView

        For i = 0 To dgSHCHGDTL_Distribute.Columns.Count - 1
            Select Case i
                Case 0
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = ""
                    dgSHCHGDTL_Distribute.Columns(i).Width = 92
                Case dgSHCHGDTL_Distribute.Columns.Count - 1
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = "璸"
                    dgSHCHGDTL_Distribute.Columns(i).Width = 65
                Case Else
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = rs_SYMSHC_D.Tables("RESULT").Rows(i - 1).Item("ysc_chgdsc")
                    If Len(rs_SYMSHC_D.Tables("RESULT").Rows(i - 1).Item("ysc_chgdsc")) > 7 Then
                        dgSHCHGDTL_Distribute.Columns(i).Width = 90
                    Else
                        dgSHCHGDTL_Distribute.Columns(i).Width = 70
                    End If
            End Select

            dgSHCHGDTL_Distribute.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
        End If

        ' row 0 
        If m = "ALL" Or m = "CNY" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        ' row 1
        If m = "ALL" Or m = "HKD" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If


        dgSHCHGDTL_Distribute.AllowUserToAddRows = False
        dgSHCHGDTL_Distribute.Columns(0).ReadOnly = True
    End Sub



    Private Sub format_dgSHCHGDTL_CORE()
        Dim i As Integer

        If rs_SHCHGDTL_CORE.Tables.Count = 0 Then
            rs_SHCHGDTL_CORE.Tables.Add("RESULT")

            'column 0 Vendor Name
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("VENDOR")

            'column 1 PV CBM By system
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("SYSCBM")
            'column 2 PV CBM By manual
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("MANCBM")

            For i = 0 To rs_SYMSHC_ALL.Tables("RESULT").Rows.Count - 1
                rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add(rs_SYMSHC_ALL.Tables("RESULT").Rows(i).Item("ysc_chgcde"))
            Next i

            ' last column 'Total'
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("TOTAL")
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("VENCDE")
        End If

        dgSHCHGDTL_CORE.DataSource = rs_SHCHGDTL_CORE.Tables("RESULT").DefaultView

        For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 1


            Select Case i
                Case 0
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = ""
                    dgSHCHGDTL_CORE.Columns(i).Width = 100
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                Case 1
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "CBM By System"
                    dgSHCHGDTL_CORE.Columns(i).Width = 65
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = Color.Green
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                Case 2
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "CBM By Manual"
                    dgSHCHGDTL_CORE.Columns(i).Width = 65
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = Color.Orange
                Case dgSHCHGDTL_CORE.Columns.Count - 2
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "璸"
                    dgSHCHGDTL_CORE.Columns(i).Width = 80
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                Case dgSHCHGDTL_CORE.Columns.Count - 1
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = ""
                    dgSHCHGDTL_CORE.Columns(i).Width = 0
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                Case Else
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = rs_SYMSHC_ALL.Tables("RESULT").Rows(i - 3).Item("ysc_chgdsc")

                    '                    If Len(rs_SYMSHC_ALL.Tables("RESULT").Rows(i - 3).Item("ysc_chgdsc")) > 5 Then
                    dgSHCHGDTL_CORE.Columns(i).Width = 66
                    'Else
                    'dgSHCHGDTL_CORE.Columns(i).Width = 50
                    'End If
            End Select

            dgSHCHGDTL_CORE.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i



        dgSHCHGDTL_CORE.AllowUserToAddRows = False

    End Sub



    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Me.cmdAdd.Enabled = True
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = True
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = False

            Me.txtdocno.Enabled = True
            Me.pDocTyp.Enabled = False

            '            Me.txtdocno.Text = ""
            Me.txtCtn.Text = ""
            Me.mskETDDat.Text = ""
            Me.txtCredat.Text = ""
            Me.txtUpddat.Text = ""
            Me.rbDocTyp_C.Checked = False
            Me.rbDocTyp_D.Checked = False
            Me.txtInvNoList.Text = ""
            Me.txtCusNoList.Text = ""
            Me.txtCustList.Text = ""

            Me.txtfwdnam.Text = ""
            Me.txtFwdInv.Text = ""
            Me.txtfcrno.Text = ""
            Me.cboCtnSiz.Text = ""
            Me.mskPckDat.Text = ""
            Me.rtxtRmk.Text = ""
            Me.cboFCurr.Text = ""
            Me.cboBCurr.Text = "HKD"
            Me.mskExchRat.Text = ""

            Add_flag = False
            Upd_flag = False
            Insert_flag = False

            changeManualCBM = False

            Me.btcSHM00010.SelectedIndex = 0
            Me.btcSHM00010.Enabled = False

            If rs_SHCHGDTL_CORE.Tables.Count > 0 Then
                If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()
                End If
            End If

            If rs_SHCHGDTL_Distribute.Tables.Count > 0 Then
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
                End If
            End If


            If rs_SHCHGHDR.Tables.Count > 0 Then
                If rs_SHCHGHDR.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGHDR.Tables("RESULT").Rows.Clear()
                End If
            End If

            If rs_SHCHGDTL.Tables.Count > 0 Then
                If rs_SHCHGDTL.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL.Tables("RESULT").Rows.Clear()
                End If
            End If


            If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
                If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Clear()
                End If
            End If


        ElseIf m = "ADD" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = True

            Me.txtdocno.Text = ""
            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = True
        ElseIf m = "UPD" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = True
            Me.cmdDelete.Enabled = True
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True

            Me.cmdRefresh.Enabled = True
            Me.cmdInvMore.Enabled = True

            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = False
            Me.txtCredat.Enabled = False
            Me.txtUpddat.Enabled = False

            Me.btcSHM00010.Enabled = True
            Me.btcSHM00010.TabPages(0).Enabled = True
            Me.gbDocTyp_C_Entry.Enabled = False
            Me.gbDocTyp_D_Entry.Enabled = False
            Me.cboFCurr.Enabled = False

            Me.btcSHM00010.TabPages(1).Enabled = True

        ElseIf m = "READ" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = False

            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = False
            Me.txtCredat.Enabled = False
            Me.txtUpddat.Enabled = False

            Me.btcSHM00010.Enabled = False
            Me.btcSHM00010.TabPages(0).Enabled = False
            Me.gbDocTyp_C_Entry.Enabled = False
            Me.gbDocTyp_D_Entry.Enabled = False
            Me.cboFCurr.Enabled = False

            Me.btcSHM00010.TabPages(1).Enabled = False


        End If


    End Sub



    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Add_flag = True

        Call formInit("ADD")

    End Sub

    Private Sub rbDocTyp_C_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDocTyp_C.CheckedChanged
        If Add_flag = True Then
            Me.pDocTyp.Enabled = False
            Me.btcSHM00010.Enabled = True
            Me.gbDocTyp_C_Entry.Enabled = True
            Me.gbDocTyp_D_Entry.Enabled = False
            Me.gbHeaderMain.Enabled = False
            Me.dgSHCHGDTL_Distribute.Enabled = False
            Me.btcSHM00010.TabPages(1).Enabled = False

            Me.txtCtn.Focus()


        End If
    End Sub

    Private Sub rbDocTyp_D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDocTyp_D.CheckedChanged
        If Add_flag = True Then
            Me.pDocTyp.Enabled = False
            Me.btcSHM00010.Enabled = True
            Me.gbDocTyp_C_Entry.Enabled = False
            Me.gbDocTyp_D_Entry.Enabled = True
            Me.gbHeaderMain.Enabled = False
            Me.btcSHM00010.TabPages(1).Enabled = False
            Me.dgSHCHGDTL_Distribute.Enabled = False
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If Add_flag = True Then
            MsgBox("Record not yet saved!", MsgBoxStyle.YesNoCancel)
            Call formInit("INIT")
        Else
            Call formInit("INIT")
        End If
    End Sub

    Private Sub cboFCurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFCurr.SelectedIndexChanged
        If Add_flag = True Then
            Me.dgSHCHGDTL_Distribute.Enabled = True
            If cboFCurr.Text = "CNY" Then
                Call format_dgSHCHGDTL_Distribute("ALL")
                Me.mskExchRat.Text = ""
                Me.mskExchRat.Enabled = True
            Else
                Call format_dgSHCHGDTL_Distribute("HKD")
                Me.mskExchRat.Text = 1
                Me.mskExchRat.Enabled = False
            End If
        End If
    End Sub

    Private Sub mskETDDat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.mskETDDat.SelectAll()
    End Sub

    Private Sub mskETDDat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskETDDat.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If check_ctnno_etddat() Then
                Me.gbDocTyp_C_Entry.Enabled = False
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")


                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True
            End If
        End If

    End Sub

    Private Function check_ctnno_etddat() As Boolean

        If Me.txtCtn.Text = "" Then
            MsgBox("Container No cannot empty!")
            Me.txtCtn.Focus()
            check_ctnno_etddat = False
            Exit Function
        End If

        If IsDate(Me.mskETDDat.Text) = False Then
            MsgBox("ETD Date is invalid!")
            Me.mskETDDat.Focus()
            check_ctnno_etddat = False
            Exit Function
        End If

        gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
            check_ctnno_etddat = False
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Record not found!")
                check_ctnno_etddat = False
                Me.txtCtn.Focus()
                Exit Function
            Else
                check_ctnno_etddat = True
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False
            End If
        End If

    End Function

    Private Sub txtCtn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtn.GotFocus
        Me.txtCtn.SelectAll()
    End Sub

    Private Sub dgSHCHGDTL_Distribute_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_Distribute.CellValueChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If

        If display_dgSHCHGDTL_Distribute() = True Then
            Call display_dgSHCHGDTL_CORE()
            Me.btcSHM00010.TabPages(1).Enabled = True
        End If
    End Sub

    Private Sub dgSHCHGDTL_Distribute_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSHCHGDTL_Distribute.CurrentCellChanged
        If display_dgSHCHGDTL_Distribute() = True Then
            Call display_dgSHCHGDTL_CORE()
            Me.btcSHM00010.TabPages(1).Enabled = True
        End If
    End Sub

    Private Sub dgSHCHGDTL_Distribute_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSHCHGDTL_Distribute.EditingControlShowing
        Dim txtbox_dgSHCHGDTL_Distribute As TextBox = CType(e.Control, TextBox)
        If Not (txtbox_dgSHCHGDTL_Distribute Is Nothing) Then
            AddHandler txtbox_dgSHCHGDTL_Distribute.KeyPress, AddressOf txtBox_dgSHCHGDTL_Distribute_KeyPress
        End If
    End Sub

    Private Sub txtBox_dgSHCHGDTL_Distribute_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If check_exchrate() = True Then
            If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                e.KeyChar = ""
            Else
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                    If dgSHCHGDTL_Distribute.CurrentCell.RowIndex = 1 Or dgSHCHGDTL_Distribute.CurrentCell.ColumnIndex = 0 Or dgSHCHGDTL_Distribute.CurrentCell.ColumnIndex = dgSHCHGDTL_Distribute.Columns.Count - 1 Then
                        e.KeyChar = ""

                    End If


                End If

            End If
        Else
            e.KeyChar = ""
            MsgBox("Please enter Exchange Rate!")
            Me.mskExchRat.Focus()
            Me.mskExchRat.SelectAll()
        End If
    End Sub


    Private Function display_dgSHCHGDTL_Distribute() As Boolean
        Dim i As Integer
        Dim totalHKD As Decimal
        Dim totalCNY As Decimal

        totalHKD = 0.0
        totalCNY = 0.0

        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
            For i = 1 To dgSHCHGDTL_Distribute.Columns.Count - 2
                If Me.cboFCurr.Text = "CNY" Then
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)) Then
                        totalCNY = totalCNY + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)
                        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i) * Me.mskExchRat.Text, 2)
                        End If
                    Else ' CNY empty and HKD is not empty
                        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i) = ""
                        End If
                    End If
                    If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i)) Then
                            totalHKD = totalHKD + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i)
                        End If
                    End If
                Else
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)) Then
                        totalHKD = totalHKD + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)
                    End If
                End If

            Next i

            '       MsgBox(totalCNY & " : " & totalHKD)
            If Me.cboFCurr.Text = "CNY" Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = totalCNY
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item("TOTAL") = totalHKD
                End If
            Else
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = totalHKD
            End If

            dgSHCHGDTL_Distribute.Refresh()
        End If
        display_dgSHCHGDTL_Distribute = True
    End Function

    Private Function calculate_dgSHCHGDTL_CORE(ByVal cal_colname As String) As Boolean
        calculate_dgSHCHGDTL_CORE = True

        If calculate_dgSHCHGDTL_CORE_flag = False Then
            Exit Function
        End If

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count = 0 Or Me.cboFCurr.Text = "" Then
            Exit Function
        End If
        If (Me.cboFCurr.Text = "CNY" And rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 7) Or (Me.cboFCurr.Text = "HKD" And rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 5) Then
            Exit Function
        End If

        Dim i As Integer
        Dim j As Integer
        Dim colname As String

        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If Me.cboFCurr.Text = "CNY" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If

        If cal_colname = "MANCBM" Then
            'Recalculate Manual Input CBM
            Dim mancbmttl As Decimal
            mancbmttl = 0.0

            For i = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
                    mancbmttl = mancbmttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM"), 2)
                End If
            Next i

            If mancbmttl = 0.0 Then
                MsgBox("Manual CBM Total cannot be zero!")
                Exit Function
            End If

            For i = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                colname = rs_SYMSHC_D.Tables("RESULT").Rows(i).Item("ysc_chgcde")
                For j = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname)) And IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item("MANCBM")) Then
                        rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname) * rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item("MANCBM") / mancbmttl, 2)
                    End If
                Next j
            Next i

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM") = mancbmttl
        End If

        'Recalculate(Total - vert)
        Dim vendorttl As Decimal
        For i = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
            vendorttl = 0.0
            For j = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 3
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(j)) Then
                    vendorttl = vendorttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(j), 2)
                End If
            Next j
            If vendorttl >= 0 Then
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("TOTAL") = System.Decimal.Round(vendorttl, 2)
            End If
        Next i

        'Recalculate(Total - horiz)
        Dim horizttl As Decimal
        For i = 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
            horizttl = 0.0
            For j = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(i)) Then
                    horizttl = horizttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(i), 2)
                End If
            Next j
            If horizttl > 0 Then
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item(i) = System.Math.Round(horizttl, 2)
                If Me.cboFCurr.Text = "CNY" And i > 2 Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD + 1 - 1).Item(i) = System.Math.Round((System.Math.Round(horizttl, 2) / Me.mskExchRat.Text), 2)
                End If
            End If
        Next i

        calculate_dgSHCHGDTL_CORE_flag = False
        dgSHCHGDTL_CORE.Refresh()
    End Function


    Private Function display_dgSHCHGDTL_CORE() As Boolean


        Dim i As Integer
        Dim colname As String

        Dim locHKD As Integer
        locHKD = 0
        If Me.cboFCurr.Text = "CNY" Then
            locHKD = 1
        Else
            locHKD = 0
        End If


        If Not ((Me.cboFCurr.Text = "CNY" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1) Or (Me.cboFCurr.Text = "HKD" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0)) Then
            Exit Function
        End If

        If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
            Exit Function
        End If

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then

            'store manual input CBM
            If changeManualCBM = True Then
                For i = locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (locHKD + 2) - 1
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i - locHKD - 2).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                Next i
            End If

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()
        End If

        ' row 0 
        If Me.cboFCurr.Text = "CNY" Then
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        ' row 1
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)



        If Me.cboFCurr.Text = "CNY" Then
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
                colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
                End If
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)) Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(1).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)
                End If
            Next i
        Else
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
                colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
                End If
            Next
        End If


        ' row 2
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("VENDOR") = ""
        dsNewRow.Item("VENCDE") = ""
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        'calculate rounded mancbmttl
        Dim mancbmttl As Decimal
        mancbmttl = 0.0
        For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1
            If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_mancbm")) Then
                mancbmttl = mancbmttl + System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_mancbm"), 2)
            End If
        Next i

        Dim j As Integer
        Dim vendorttl As Decimal

        vendorttl = 0.0
        'row 3 after (Vendor)
        For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()

            dsNewRow.Item("VENCDE") = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_vbi_venno")
            dsNewRow.Item("VENDOR") = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_vbi_vensna")
            dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_cbm")
            If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_mancbm")) Then
                dsNewRow.Item("MANCBM") = System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(i).Item("tmp_mancbm"), 2)
            Else
                dsNewRow.Item("MANCBM") = 0
            End If
            If IsNumeric(dsNewRow.Item("SYSCBM")) Then
                If dsNewRow.Item("SYSCBM") = 0.0 Then
                    dsNewRow.Item("SYSCBM") = ""
                End If
            Else
                dsNewRow.Item("SYSCBM") = ""
            End If

            'Dim tmpsyscbm As String
            'Dim tmpmancbm As String

            'If IsNumeric(dsNewRow.Item("MANCBM")) Then
            '    If dsNewRow.Item("MANCBM") = 0.0 Then
            '        For j = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
            '            colname = rs_SYMSHC_D.Tables("RESULT").Rows(j).Item("ysc_chgcde")
            '            tmpsyscbm = 0.0
            '            tmpmancbm = 0.0
            '            Call search_SHCHGDTL_CBM(dsNewRow.Item("VENCDE"), colname, "HKD", tmpsyscbm, tmpmancbm)

            '            If tmpmancbm <> "" Then
            '                Dim tmpdecimal As Decimal
            '                tmpdecimal = tmpmancbm
            '                dsNewRow.Item("MANCBM") = System.Decimal.Round(tmpdecimal, 2)
            '                Exit For
            '            End If
            '        Next j
            '    End If
            'End If



            Dim sFee As Decimal
            sFee = 0
            vendorttl = 0.0

            If Insert_flag = True Or Add_flag = True Then
                For j = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
                    colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(j).ColumnName

                    If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname)) And IsNumeric(dsNewRow.Item("MANCBM")) Then
                            dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname) * dsNewRow.Item("MANCBM") / mancbmttl, 2)
                            vendorttl = vendorttl + dsNewRow.Item(colname)
                        End If
                    End If
                Next j
            Else
                For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - (2 + locHKD)
                    colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(j).ColumnName

                    sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(dsNewRow.Item("VENCDE"), colname, "HKD")
                    If sFee <> 0 Then
                        dsNewRow.Item(colname) = System.Decimal.Round(sFee, 2)
                        vendorttl = vendorttl + dsNewRow.Item(colname)
                    End If
                Next j

            End If
            dsNewRow.Item("TOTAL") = System.Decimal.Round(vendorttl, 2)

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        Next i


        If Insert_flag = True Then
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
            Call display_lstVendor(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count)
        End If

        ' row 97
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("VENDOR") = ""
        dsNewRow.Item("VENCDE") = ""
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        ' row 98
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("VENDOR") = "羆璸(HKD)"
        dsNewRow.Item("VENCDE") = ""
        dsNewRow.Item("MANCBM") = mancbmttl
        dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ttlcbm")
        Dim tmpTtl As Decimal
        For i = 1 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
            tmpTtl = 0
            colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
            For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (1 + locHKD)
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)) Then
                    tmpTtl = tmpTtl + rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)
                End If
            Next j
            If tmpTtl <> 0 Then
                dsNewRow.Item(colname) = System.Decimal.Round(tmpTtl, 2)
            End If
        Next i

        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        Dim lastrow As Integer
        lastrow = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1

        If Me.cboFCurr.Text = "CNY" Then
            ' row 99
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "羆璸(CNY)"
            dsNewRow.Item("VENCDE") = ""


            For i = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
                colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname)) Then
                    dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname) / Me.mskExchRat.Text, 2)
                End If
            Next i
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        dgSHCHGDTL_CORE.Refresh()

    End Function


    Private Function check_exchrate() As Boolean
        If IsNumeric(Me.mskExchRat.Text) = True Then
            check_exchrate = True
        Else
            check_exchrate = False
        End If
    End Function

    Private Sub mskExchRat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskExchRat.LostFocus
        If check_exchrate() = True Then
            Call display_dgSHCHGDTL_Distribute()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Me.Cursor = Cursors.WaitCursor
        If Add_flag = False And Upd_flag = False Then
            MsgBox("Record not saved, no data change!")
            Exit Sub
        End If

        'If Add_flag = True Then
        If check_SHCHGHDR_SHCHGDTL() = True Then
            Dim docno As String
            docno = ""
            If save_SHCHGHDR(docno) = True Then
                MsgBox("Record Saved! Document No: " & docno)
                Call formInit("INIT")
                Me.txtdocno.Text = docno
            End If
        End If
        'End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgSHCHGDTL_CORE_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_CORE.CellValueChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
        If e.ColumnIndex = 2 Then
            Call calculate_dgSHCHGDTL_CORE("MANCBM")
            If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
                If Me.cboFCurr.Text = "CNY" Then
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(e.RowIndex - 3).Item("tmp_creusr") = "~*UPD*~"
                Else
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(e.RowIndex - 2).Item("tmp_creusr") = "~*UPD*~"
                End If
            End If
            changeManualCBM = True
        Else
            Call calculate_dgSHCHGDTL_CORE("NONE")
        End If
    End Sub

    Private Sub dgSHCHGDTL_CORE_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSHCHGDTL_CORE.CurrentCellChanged
        Call calculate_dgSHCHGDTL_CORE("NONE")
    End Sub

    Private Sub dgSHCHGDTL_CORE_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSHCHGDTL_CORE.EditingControlShowing
        Dim txtbox_dgSHCHGDTL_CORE As TextBox = CType(e.Control, TextBox)
        If Not (txtbox_dgSHCHGDTL_CORE Is Nothing) Then
            AddHandler txtbox_dgSHCHGDTL_CORE.KeyPress, AddressOf txtBox_dgSHCHGDTL_CORE_KeyPress
        End If
    End Sub

    Private Sub txtBox_dgSHCHGDTL_CORE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 1 Then
                If dgSHCHGDTL_CORE.CurrentCell.RowIndex = 0 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = 1 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = 2 And Me.cboFCurr.Text = "CNY" Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 2 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3 And Me.cboFCurr.Text = "CNY" Then
                    e.KeyChar = ""
                Else
                    calculate_dgSHCHGDTL_CORE_flag = True
                End If
            End If
        End If
    End Sub


    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If btcSHM00010.SelectedIndex = 1 Then
            Insert_flag = True
            Call display_dgSHCHGDTL_CORE()
        End If
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click

        Dim locHKD As Integer
        locHKD = 0
        If Me.cboFCurr.Text = "CNY" Then
            locHKD = 1
        Else
            locHKD = 0
        End If

        Dim delLoc As Integer
        delLoc = 0

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count >= 5 + locHKD Then
            If dgSHCHGDTL_CORE.CurrentCell.RowIndex >= locHKD + 2 And dgSHCHGDTL_CORE.CurrentCell.RowIndex < dgSHCHGDTL_CORE.Rows.Count - 2 - locHKD Then
                delLoc = dgSHCHGDTL_CORE.CurrentCell.RowIndex
            End If
        End If

        If delLoc > 0 Then
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(delLoc).Item("MANCBM") = "0"
            changeManualCBM = True
            calculate_dgSHCHGDTL_CORE_flag = True
            Call calculate_dgSHCHGDTL_CORE("MANCBM")
        End If


        'If btcSHM00010.SelectedIndex = 1 Then
        'Insert_flag = False
        'Call display_dgSHCHGDTL_CORE()
        'End If
    End Sub

    Private Sub lstVendor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendor.DoubleClick
        lstVendor.Visible = False
        Dim venno As String
        Dim vennam As String
        venno = Split(lstVendor.Text, " - ")(0)
        vennam = Split(lstVendor.Text, " - ")(1)
        If Me.cboFCurr.Text = "CNY" Then
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 4).Item("VENDOR") = vennam
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 4).Item("VENCDE") = venno
        Else
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENDOR") = vennam
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENCDE") = venno
        End If

        dsNewRow = rs_SHIPGDTL_CTNETD.Tables("RESULT").NewRow()
        dsNewRow.Item("tmp_vbi_vensna") = vennam
        dsNewRow.Item("tmp_vbi_venno") = venno
        dsNewRow.Item("tmp_creusr") = "~*ADD*~"
        dsNewRow.Item("tmp_mancbm") = 0

        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add(dsNewRow)


    End Sub

    Private Sub display_lstVendor(ByVal rowcount As Integer)
        lstVendor.Visible = True

        lstVendor.Top = dgSHCHGDTL_CORE.Item(0, 0).DataGridView.Top + dgSHCHGDTL_CORE.Item(0, 0).DataGridView.ColumnHeadersHeight + dgSHCHGDTL_CORE.RowTemplate.Height * rowcount
        lstVendor.Left = dgSHCHGDTL_CORE.Item(0, 0).DataGridView.Left + dgSHCHGDTL_CORE.Item(0, 0).DataGridView.RowHeadersWidth
    End Sub

    Private Function check_SHCHGHDR_SHCHGDTL() As Boolean
        If Me.rbDocTyp_C.Checked = False And Me.rbDocTyp_D.Checked = False Then
            MsgBox("Document Type cannot empty!")
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.txtCtn.Text = "" Then
            MsgBox("Container Number cannot empty!")
            Me.txtCtn.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.mskETDDat.Text = "  /  /" Then
            MsgBox("Container Number cannot empty!")
            Me.mskETDDat.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.txtfwdnam.Text = "" Then
            MsgBox("Forwarder Name cannot empty!")
            Me.txtfwdnam.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.txtFwdInv.Text = "" Then
            MsgBox("Forwarder Invoice cannot empty!")
            Me.txtFwdInv.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.txtfcrno.Text = "" Then
            MsgBox("FCR No cannot empty!")
            Me.txtfcrno.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.cboCtnSiz.Text = "" Then
            MsgBox("Container Size cannot empty!")
            Me.cboCtnSiz.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.cboFCurr.Text = "" Then
            MsgBox("Forwarder Currency cannot empty!")
            Me.cboFCurr.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.cboBCurr.Text = "" Then
            MsgBox("Base Currency cannot empty!")
            Me.cboBCurr.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If Me.mskExchRat.Text = " ." Then
            MsgBox("Exchange Rate cannot empty!")
            Me.mskExchRat.Focus()
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("SHCHGDTL Distribute cannot empty!")
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
            If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = 0 Then
                MsgBox("SHCHGDTL Distribute CNY/HKD total is 0!")
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If
        End If

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("SHCHGDTL CORE cannot empty!")
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If

        'Check for no vendor detail
        If Me.cboFCurr.Text = "CNY" Then
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 6 Then
                MsgBox("No Vendor Detail CNY!")
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If
        Else
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 4 Then
                MsgBox("No Vendor Detail HKD!")
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If
        End If



        check_SHCHGHDR_SHCHGDTL = True
    End Function

    Private Function save_SHCHGHDR(ByRef rtnDocNo As String) As Boolean


        Dim sDocNo As String
        sDocNo = ""

        If Add_flag = True Then
            gspStr = "sp_select_DOC_GEN 'SHCHG','SH','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_DOC_GEN, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00010 #005 sp_select_DOC_GEN : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If

            sDocNo = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
            sDocNo = Mid(sDocNo, 1, 2) & Year(Today) & Mid(sDocNo, 5, 5)
        ElseIf Upd_flag = True Then
            sDocNo = Me.txtdocno.Text
        End If


        Dim SCH_DOCNO As String
        Dim SCH_TYP As String
        Dim SCH_STS As String
        Dim SCH_FWDNAM As String
        Dim SCH_FWDINV As String
        Dim SCH_FCRNO As String
        Dim SCH_FCURCDE As String
        Dim SCH_CURCDE As String
        Dim SCH_EXCHRAT As String
        Dim SCH_PCKDAT As String
        Dim SCH_CTRCFS As String
        Dim SCH_CTRSIZ As String
        Dim SCH_INVLST As String
        Dim SCH_CUSLST As String
        Dim SCH_CUSNOLST As String
        Dim SCH_ETDDAT As String
        Dim SCH_RMK As String


        SCH_DOCNO = sDocNo
        If Me.rbDocTyp_C.Checked = True Then
            SCH_TYP = "C"
        Else
            SCH_TYP = "D"
        End If

        If Add_flag = True Then
            SCH_STS = "OPE"
        ElseIf Upd_flag = True Then
            SCH_STS = Me.txtStatus.Text
        Else
            SCH_STS = ""
        End If

        SCH_FWDNAM = Replace(Me.txtfwdnam.Text, "'", "''")
        SCH_FWDINV = Replace(Me.txtFwdInv.Text, "'", "''")
        SCH_FCRNO = Replace(Me.txtfcrno.Text, "'", "''")
        SCH_FCURCDE = Replace(Me.cboFCurr.Text, "'", "''")
        SCH_CURCDE = Replace(Me.cboBCurr.Text, "'", "''")
        SCH_EXCHRAT = Replace(Me.mskExchRat.Text, "'", "''")
        SCH_PCKDAT = Replace(Me.mskPckDat.Text, "'", "''")
        SCH_CTRCFS = Replace(Me.txtCtn.Text, "'", "''")
        SCH_CTRSIZ = Replace(Me.cboCtnSiz.Text, "'", "''")
        SCH_INVLST = Replace(Me.txtInvNoList.Text, "'", "''")
        SCH_CUSLST = Replace(Me.txtCustList.Text, "'", "''")
        SCH_CUSNOLST = Replace(Me.txtCusNoList.Text, "'", "''")
        SCH_ETDDAT = Replace(Me.mskETDDat.Text, "'", "''")
        SCH_RMK = Replace(Me.rtxtRmk.Text, "'", "''")


        If Add_flag = True Then
            gspStr = "sp_insert_SHCHGHDR '','" & SCH_DOCNO & "','" & SCH_TYP & "','" & SCH_STS & "','" & SCH_FWDNAM & "','" & SCH_FWDINV & "','" & SCH_FCRNO & "','" & SCH_FCURCDE & "','" & SCH_CURCDE & "','" & SCH_EXCHRAT & "','" & SCH_PCKDAT & "','" & SCH_CTRCFS & "','" & SCH_CTRSIZ & "','" & SCH_INVLST & "','" & SCH_CUSLST & "','" & SCH_CUSNOLST & "','" & SCH_ETDDAT & "','" & SCH_RMK & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00010 #006 sp_insert_SHCHGHDR : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If

        ElseIf Upd_flag = True Then

            gspStr = "sp_update_SHCHGHDR '','" & SCH_DOCNO & "','" & SCH_TYP & "','" & SCH_STS & "','" & SCH_FWDNAM & "','" & SCH_FWDINV & "','" & SCH_FCRNO & "','" & SCH_FCURCDE & "','" & SCH_CURCDE & "','" & SCH_EXCHRAT & "','" & SCH_PCKDAT & "','" & SCH_CTRCFS & "','" & SCH_CTRSIZ & "','" & SCH_INVLST & "','" & SCH_CUSLST & "','" & SCH_CUSNOLST & "','" & SCH_ETDDAT & "','" & SCH_RMK & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00010 #011 sp_update_SHCHGHDR : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If

        End If


        Dim SCD_DOCNO As String
        Dim SCD_VENNO As String
        Dim SCD_CHGCDE As String
        Dim SCD_SYSCBM As String
        Dim SCD_MANCBM As String
        Dim SCD_CURCDE As String
        Dim SCD_FEE As String
        Dim SCD_FEE_UPD As String

        Dim SCD_MANCBM_UPD As String

        SCD_DOCNO = ""
        SCD_VENNO = ""
        SCD_CHGCDE = ""
        SCD_SYSCBM = ""
        SCD_MANCBM = ""
        SCD_CURCDE = ""
        SCD_FEE = ""
        SCD_FEE_UPD = ""

        SCD_MANCBM_UPD = ""

        Dim i As Integer
        Dim j As Integer



        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If Me.cboFCurr.Text = "CNY" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If

        For i = 0 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
            SCD_DOCNO = SCH_DOCNO

            ' Save Manual Total
            If i < rowspace Then
                SCD_VENNO = "TOTAL"
                For j = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                    SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("SYSCBM")
                    SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM")
                    SCD_CURCDE = ""
                    If Me.cboFCurr.Text = "CNY" And i = 0 Then
                        SCD_CURCDE = "CNY"
                    Else
                        SCD_CURCDE = "HKD"
                    End If
                    SCD_CHGCDE = rs_SYMSHC_D.Tables("RESULT").Rows(j).Item("ysc_chgcde")
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
                        SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
                    Else
                        SCD_FEE = ""
                    End If

                    If SCD_FEE <> "" Then
                        If Add_flag = True Then
                            gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SHM00010 #007a sp_insert_SHCHGDTL : " & rtnStr)
                                save_SHCHGHDR = False
                                Exit Function
                            End If
                        ElseIf Upd_flag = True Then
                            SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                            SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                            If SCD_FEE_UPD = 0 Then
                                gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SHM00010 #012 sp_insert_SHCHGDTL : " & rtnStr)
                                    save_SHCHGHDR = False
                                    Exit Function
                                End If
                            ElseIf SCD_FEE <> SCD_FEE_UPD Then
                                If SCD_FEE = "" And SCD_FEE_UPD <> 0 Then
                                    'del
                                    gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SHM00010 #013 sp_physical_delete_SHCHGDTL : " & rtnStr)
                                        save_SHCHGHDR = False
                                        Exit Function
                                    End If

                                Else
                                    'upd
                                    gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SHM00010 #014 sp_update_SHCHGDTL : " & rtnStr)
                                        save_SHCHGHDR = False
                                        Exit Function
                                    End If
                                End If
                            ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
                                'upd
                                gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SHM00010 #014e sp_update_SHCHGDTL : " & rtnStr)
                                    save_SHCHGHDR = False
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                Next j
            Else
                SCD_VENNO = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE")
                If SCD_VENNO <> "" Then
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")) Then
                        SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")
                    Else
                        SCD_SYSCBM = "0"
                    End If
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
                        SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                    Else
                        SCD_MANCBM = "0"
                    End If

                    SCD_CURCDE = Me.cboBCurr.Text

                    For j = 0 To rs_SYMSHC_ALL.Tables("RESULT").Rows.Count - 1
                        SCD_CHGCDE = rs_SYMSHC_ALL.Tables("RESULT").Rows(j).Item("ysc_chgcde")
                        If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
                            SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
                        Else
                            SCD_FEE = "0"
                        End If
                        If SCD_FEE <> "0" Then
                            If Add_flag = True Then
                                gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SHM00010 #007b sp_insert_SHCHGDTL : " & rtnStr)
                                    save_SHCHGHDR = False
                                    Exit Function
                                End If
                            ElseIf Upd_flag = True Then
                                SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                                SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                                If SCD_FEE_UPD = 0 Then
                                    gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SHM00010 #015 sp_insert_SHCHGDTL : " & rtnStr)
                                        save_SHCHGHDR = False
                                        Exit Function
                                    End If
                                ElseIf SCD_FEE <> SCD_FEE_UPD Then
                                    If SCD_FEE = "0" And SCD_FEE_UPD <> 0 Then
                                        'del
                                        gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on loading SHM00010 #016 sp_physical_delete_SHCHGDTL : " & rtnStr)
                                            save_SHCHGHDR = False
                                            Exit Function
                                        End If

                                    Else
                                        'upd
                                        gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on loading SHM00010 #017 sp_update_SHCHGDTL : " & rtnStr)
                                            save_SHCHGHDR = False
                                            Exit Function
                                        End If
                                    End If
                                ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
                                    'upd
                                    gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading SHM00010 #014e sp_update_SHCHGDTL : " & rtnStr)
                                        save_SHCHGHDR = False
                                        Exit Function
                                    End If
                                End If
                            End If
                        Else
                            gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SHM00010 #016c sp_physical_delete_SHCHGDTL : " & rtnStr)
                                save_SHCHGHDR = False
                                Exit Function
                            End If

                        End If
                    Next j
                End If
            End If
        Next i

        rtnDocNo = sDocNo
        save_SHCHGHDR = True
    End Function


    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        If Me.txtdocno.Text = "" Then
            MsgBox("Please enter Document No")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If
        If Len(Me.txtdocno.Text) <> 11 Then
            MsgBox("Invalid Document No")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If


        gspStr = "sp_select_SHCHGHDR '','" & Me.txtdocno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #008 sp_select_SHCHGHDR : " & rtnStr)
            Exit Sub
        End If

        If rs_SHCHGHDR.Tables.Count = 0 Then
            MsgBox("Record not found!")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If

        If rs_SHCHGHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If

        gspStr = "sp_select_SHCHGDTL '','" & Me.txtdocno.Text & "','ALL',''"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #009 sp_select_SHCHGDTL : " & rtnStr)
            Exit Sub
        End If


        Call display_SHCHGHDR()

        Call display_SHCHGDTL()

        Me.btcSHM00010.TabPages(1).Enabled = False
        Me.btcSHM00010.TabPages(1).Enabled = True

        If Me.txtStatus.Text = "CAN" Then
            formInit("READ")
        End If

    End Sub

    Private Sub clear_SHCHGHDR()

    End Sub

    Private Sub display_SHCHGHDR()

        Dim SCH_DOCNO As String
        Dim SCH_TYP As String
        Dim SCH_STS As String
        Dim SCH_FWDNAM As String
        Dim SCH_FWDINV As String
        Dim SCH_FCRNO As String
        Dim SCH_FCURCDE As String
        Dim SCH_CURCDE As String
        Dim SCH_EXCHRAT As String
        Dim SCH_PCKDAT As String
        Dim SCH_CTRCFS As String
        Dim SCH_CTRSIZ As String
        Dim SCH_INVLST As String
        Dim SCH_CUSLST As String
        Dim SCH_CUSNOLST As String
        Dim SCH_ETDDAT As String
        Dim SCH_RMK As String
        Dim SCH_CREDAT As String
        Dim SCH_UPDDAT As String
        Dim SCH_CREUSR As String
        Dim SCH_UPDUSR As String



        If rs_SHCHGHDR.Tables("RESULT").Rows.Count <> 1 Then
            Exit Sub
        End If
        SCH_DOCNO = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_docno")
        SCH_TYP = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_typ")
        SCH_STS = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_sts")
        SCH_FWDNAM = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fwdnam")
        SCH_FWDINV = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fwdinv")
        SCH_FCRNO = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fcrno")
        SCH_FCURCDE = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fcurcde")
        SCH_CURCDE = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_curcde")
        SCH_EXCHRAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_exchrat")
        SCH_PCKDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_pckdat")
        SCH_CTRCFS = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrcfs")
        SCH_CTRSIZ = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrsiz")
        SCH_INVLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")
        SCH_CUSLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cuslst")
        SCH_CUSNOLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cusnolst")
        SCH_ETDDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_etddat")
        SCH_RMK = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_rmk")
        SCH_CREDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_credat")
        SCH_UPDDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_upddat")
        SCH_CREUSR = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_creusr")
        SCH_UPDUSR = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_updusr")

        If SCH_TYP = "C" Then
            Me.rbDocTyp_C.Checked = True
        Else
            Me.rbDocTyp_D.Checked = True
        End If

        Me.txtStatus.Text = SCH_STS

        Me.txtfwdnam.Text = SCH_FWDNAM
        Me.txtFwdInv.Text = SCH_FWDINV
        Me.txtfcrno.Text = SCH_FCRNO
        Me.cboFCurr.Text = SCH_FCURCDE
        Me.cboBCurr.Text = SCH_CURCDE
        Me.mskExchRat.Text = SCH_EXCHRAT
        Me.mskPckDat.Text = SCH_PCKDAT
        Me.txtCtn.Text = SCH_CTRCFS
        Me.cboCtnSiz.Text = SCH_CTRSIZ
        Me.txtInvNoList.Text = SCH_INVLST
        Me.txtCustList.Text = SCH_CUSLST
        Me.txtCusNoList.Text = SCH_CUSNOLST
        Me.mskETDDat.Text = SCH_ETDDAT
        Me.rtxtRmk.Text = SCH_RMK
        Me.txtCredat.Text = SCH_CREDAT
        Me.txtUpddat.Text = SCH_UPDDAT
        Me.ssBar.Text = "Create User : [" & SCH_CREUSR & "]  Update User : [" & SCH_UPDUSR & "]"
    End Sub

    Private Sub display_SHCHGDTL()


        Dim i As Integer



        If rs_SHCHGDTL_Distribute.Tables.Count > 0 Then
            If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
            End If
        End If

        If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count > 0 Then
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Clear()
            End If
        End If

        gspStr = "sp_select_SHIPGDTL_CTNETD '','',''"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00010 #010 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
            Exit Sub
        Else
            For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns.Count - 1
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns(i).ReadOnly = False
            Next i
        End If

        If Me.cboFCurr.Text = "CNY" Then
            Call format_dgSHCHGDTL_Distribute("ALL")
        Else
            Call format_dgSHCHGDTL_Distribute("HKD")
        End If

        If rs_SHCHGDTL_CORE.Tables.Count > 0 Then
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()
            End If
        End If

        Call format_dgSHCHGDTL_CORE()

        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If Me.cboFCurr.Text = "CNY" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If


        Dim sVendor As String
        Dim sVendorName As String
        Dim sColumn As String
        Dim sCurr As String
        Dim sFee As Decimal

        Dim sTtlSYSCBM As String
        Dim sTtlMANCBM As String
        Dim ttlcbm_flag As Boolean

        sTtlSYSCBM = 0
        sTtlMANCBM = 0
        ttlcbm_flag = False

        sVendor = "TOTAL"

        If Me.cboFCurr.Text = "CNY" Then
            'CNY Row
            sCurr = "CNY"
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
                sColumn = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(sVendor, sColumn, sCurr)
                If sFee <> 0 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(sColumn) = System.Decimal.Round(sFee, 2)
                End If
            Next i
        End If
        'HKD Row

        sCurr = "HKD"
        For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
            sColumn = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
            sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(sVendor, sColumn, sCurr)
            If sFee <> 0 Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(sColumn) = sFee
                If ttlcbm_flag = False Then
                    Call search_SHCHGDTL_CBM(sVendor, sColumn, sCurr, sTtlSYSCBM, sTtlMANCBM)
                    ttlcbm_flag = True
                End If
            End If
        Next i

        Dim sInvList As String
        Dim sCusList As String
        Dim sCusNoList As String
        Dim sCtrsiz As String

        sInvList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")
        sCusList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cuslst")
        sCusNoList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cusnolst")
        sCtrsiz = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrsiz")


        Dim sLastVendor As String
        sLastVendor = ""


        Dim loc As String

        For i = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_venno")
            sVendorName = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_vensna")
            sFee = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_fee")
            If sVendor <> "TOTAL" And sVendor <> sLastVendor Then

                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add()

                loc = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1

                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_invlist") = sInvList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cuslist") = sCusList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cusnolist") = sCusNoList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ttlcbm") = sTtlSYSCBM
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ctrsiz") = sCtrsiz
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_creusr") = ""
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_venno") = sVendor
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_vensna") = sVendorName
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cbm") = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_syscbm")
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_mancbm") = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_mancbm")

                sLastVendor = sVendor
            End If


        Next i

        If display_dgSHCHGDTL_Distribute() = True Then
            Call display_dgSHCHGDTL_CORE()

            Call formInit("UPD")
        End If
    End Sub

    Private Function search_SHCHGDTL_By_Vendor_ChgCde_Curr(ByVal ven As String, ByVal chgcde As String, ByVal curr As String) As String
        Dim i As Integer
        If rs_SHCHGDTL.Tables.Count = 0 Then
            search_SHCHGDTL_By_Vendor_ChgCde_Curr = 0
            Exit Function
        End If
        search_SHCHGDTL_By_Vendor_ChgCde_Curr = 0

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String
        Dim sFee As Decimal


        For i = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_venno")
            sChgCde = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_chgcde")
            sCurr = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_curcde")
            sFee = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_fee")

            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                search_SHCHGDTL_By_Vendor_ChgCde_Curr = System.Decimal.Round(sFee, 2)
                Exit For
            End If
        Next i


    End Function



    Private Function search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(ByVal ven As String, ByVal chgcde As String, ByVal curr As String) As String
        Dim i As Integer
        If rs_SHCHGDTL.Tables.Count = 0 Then
            search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = 0
            Exit Function
        End If
        search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = 0

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String
        Dim sManCBM As Decimal


        For i = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_venno")
            sChgCde = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_chgcde")
            sCurr = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_curcde")
            sManCBM = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_mancbm")

            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = System.Decimal.Round(sManCBM, 2)
                Exit For
            End If
        Next i


    End Function

    Private Sub search_SHCHGDTL_CBM(ByVal ven As String, ByVal chgcde As String, ByVal curr As String, ByRef ttlsyscbm As String, ByRef ttlmancbm As String)
        Dim i As Integer

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String

        ttlsyscbm = 0
        ttlmancbm = 0

        If rs_SHCHGDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_venno")
            sChgCde = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_chgcde")
            sCurr = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_curcde")
            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                ttlsyscbm = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_syscbm")
                ttlmancbm = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_mancbm")
                Exit For
            End If
        Next i


    End Sub

    Private Sub txtfwdnam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfwdnam.TextChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub txtFwdInv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFwdInv.TextChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub txtfcrno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfcrno.TextChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub cboCtnSiz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtnSiz.SelectedIndexChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub mskPckDat_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub rtxtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtxtRmk.TextChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub



    Private Sub mskExchRat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskExchRat.TextChanged
        If Add_flag = False And Upd_flag = False Then
            Upd_flag = True
        End If
    End Sub

    Private Sub cmdInvMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvMore.Click
        Call display_dgINVMORE()
        dgINVMORE.Visible = True
        dgINVMORE.Select()
    End Sub

    Private Sub dgINVMORE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgINVMORE.LostFocus
        dgINVMORE.Visible = False
    End Sub

    Private Sub txtdocno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocno.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub


    Private Sub txtInvNoList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvNoList.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If check_INVMORE() Then
                Me.gbDocTyp_D_Entry.Enabled = False
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")


                Call display_dgINVMORE()

                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True

            End If
        End If
    End Sub

    Private Function check_INVMORE() As Boolean
        gspStr = "sp_select_SHIPGDTL_INVMORE '','" & Me.txtInvNoList.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            check_INVMORE = False
            MsgBox("Error on loading SHM00010 #019 sp_select_SHIPGDTL_INVMORE : " & rtnStr)
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Record not found!")
                check_INVMORE = False
                Me.txtCtn.Focus()
                Exit Function
            Else
                check_INVMORE = True
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
            End If
        End If
    End Function

    Private Sub btcSHM00010_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcSHM00010.GotFocus
        Me.btcSHM00010.TabPages(1).Enabled = False
        Me.btcSHM00010.TabPages(1).Enabled = True
    End Sub

    Private Sub btcSHM00010_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btcSHM00010.MouseClick
        Me.btcSHM00010.TabPages(1).Enabled = False
        Me.btcSHM00010.TabPages(1).Enabled = True
    End Sub

    Private Sub txtCtn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtn.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If check_ctnno_etddat() Then
                Me.gbDocTyp_C_Entry.Enabled = False
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")


                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True
            End If
        End If
    End Sub


    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim docno As String

        docno = Me.txtdocno.Text
        If MsgBox("Are you sure to cancel " & docno & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            gspStr = "sp_update_SHCHGHDR_cancel '','" & docno & "','" & Me.rtxtRmk.Text & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00010 #010 sp_update_SHCHGHDR_cancel : " & rtnStr)
                Exit Sub
            End If

            MsgBox("Record Saved!")
            Call formInit("INIT")
            Me.txtdocno.Text = docno

        End If

    End Sub



    Private Sub dgSHCHGDTL_CORE_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_CORE.CellContentClick

    End Sub
End Class
