Public Class SYM00034
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
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00034))
        Me.ssBar = New System.Windows.Forms.StatusBar
        Me.dgCharge = New System.Windows.Forms.DataGridView
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 609)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(954, 22)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(5, 38)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCharge.RowTemplate.Height = 24
        Me.dgCharge.Size = New System.Drawing.Size(942, 563)
        Me.dgCharge.TabIndex = 7
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 259
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
        Me.mmdFunction.Text = "Function"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'SYM00034
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.dgCharge)
        Me.Controls.Add(Me.ssBar)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SYM00034"
        Me.Text = "SYM00034 - Trading Terms Maintenance (SYM34)"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYTRDTRM As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer



    Private Sub SYM00102_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        validcheck = 1
        ''add on 11/8/2011
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right
            ''end of add



            gsCompany = "UCP"
            gspStr = "sp_select_SYTRDTRM'" & gsCompany & "','AL'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTRDTRM, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00102 #001 sp_select_SYTRDTRM : " & rtnStr)
            Else
                dgCharge.DataSource = rs_SYTRDTRM.Tables("RESULT").DefaultView

                rs_SYTRDTRM.Tables("RESULT").Columns(0).ReadOnly = False


                Call format_dgCharge()
                Call setDataRowAttr()
                Call SetStatusBar("Init")
                mode = "INIT"
                Call setStatus(mode)

            End If
            Call Formstartup(Me.Name)

            '' add on 11/8/2011
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
        '' end add
    End Sub



    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_SYTRDTRM.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                'If (column
                dc.ReadOnly = False

            Next
            ''rs_SYTRDTRM.Tables("RESULT").Columns("DEL").ColumnName = "ytt_del"
            For Each dr As DataRow In dt.Rows
                dr.Item("ytt_del") = ""
            Next
            rs_SYTRDTRM.AcceptChanges()
        End If
    End Sub






    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.ssBar.Text = "Init" Then
            Me.Close()
        Else

            If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call mmdSave_Click(sender, e)

                    If save_ok Then

                        'Me.Close()
                        'Else
                        Exit Sub
                    End If

                ElseIf YNC = Windows.Forms.DialogResult.No Then
                    Me.Close()

                ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub format_dgCharge()
        Dim i As Integer
        i = 0
        With dgCharge
            '0
            .Columns(i).Width = 30
            .Columns(i).HeaderText = "Del"
            i = i + 1
            '1
            .Columns(i).Width = 45
            .Columns(i).HeaderText = "Code"
            i = i + 1
            '2
            .Columns(i).Width = 45
            .Columns(i).HeaderText = "Type"
            i = i + 1
            '3
            .Columns(i).Width = 90
            .Columns(i).HeaderText = "Group"
            i = i + 1

            .Columns(i).Width = 485
            .Columns(i).HeaderText = "Desc"
            i = i + 1


            Dim j As Integer
            For j = i To dgCharge.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub








    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = False

            Me.mmdSearch.Enabled = False

            Me.mmdInsRow.Enabled = True
            Me.mmdDelRow.Enabled = True

            Me.mmdPrint.Enabled = False
            Me.mmdAttach.Enabled = False
            Me.mmdFunction.Enabled = False
            Me.mmdLink.Enabled = False
            Me.mmdExit.Enabled = True

            Call SetStatusBar(mode)
        ElseIf mode = "InsRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00102_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub




    ''/*add by 11/08/2011*/






    Private Sub SetStatusBar(ByVal m As String)

        If m = "Init" Then
            Me.ssBar.Text = "Init"
        ElseIf m = "InsRow" Then
            Me.ssBar.Text = "Insert Row"
        ElseIf m = "Updating" Then
            Me.ssBar.Text = "Updating"
        ElseIf m = "Save" Then
            Me.ssBar.Text = "Record Saved"
        ElseIf m = "DelRow" Then
            Me.ssBar.Text = "Record Row Deleted"
        ElseIf m = "ReadOnly" Then
            Me.ssBar.Text = "Read Only"
        ElseIf m = "Clear" Then
            Me.ssBar.Text = "Clear Screen"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.ssBar.Text = ""
    End Sub
    ''end add


    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        Dim row As DataGridViewRow = dgCharge.CurrentRow

        dgView.Rows(iRow).Cells(iCol).ReadOnly = True
        If iCol = 1 Then
            For Each dr As DataRow In rs_SYTRDTRM.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("ytt_cde").ToString.Trim)
            Next
        ElseIf iCol = 2 Then
            cboCell.Items.Add("Ext")
            cboCell.Items.Add("Int")
        ElseIf iCol = 3 Then
            cboCell.Items.Add("Deposit")
            cboCell.Items.Add("Payment")
            cboCell.Items.Add("Hold")
            cboCell.Items.Add("Claim")
            cboCell.Items.Add("Release")
        ElseIf iCol = 4 Then
            For Each dr As DataRow In rs_SYTRDTRM.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("ytt_dsc").ToString.Trim)
            Next
        End If
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub



    Private Sub cboOpt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = dgCharge.CurrentCell.RowIndex
        Dim iCol As Integer = dgCharge.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.dgCharge.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                ' User has changed the function
                If iCol = 1 Then
                    Me.dgCharge.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.dgCharge.Rows(iRow).Cells(iCol + 1).Value = rs_SYTRDTRM.Tables("RESULT").Select("ytt_typ = '" & strSelItem & "'")(0).Item("ytt_grp").ToString
                ElseIf iCol = 3 Then
                    Me.dgCharge.Rows(iRow).Cells(iCol).Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub dgCharge_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellContentClick

    End Sub




    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgCharge.EditingControlShowing

        If dgCharge.CurrentCell.ColumnIndex = 2 Or dgCharge.CurrentCell.ColumnIndex = 3 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                End If
            End If
        End If
    End Sub


    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ''Toggle(Delete)
                If Not row.Cells("ytt_cde").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                    row.Cells("ytt_del").ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
                If row.Cells("ytt_del").Value.ToString = "" And row.Cells("ytt_creusr").Value.ToString = "~*ADD*~" Then
                    If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(dgCharge.CurrentCell)
                        dgCharge.BeginEdit(True)
                        mmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If
            ElseIf e.ColumnIndex = 1 Or e.ColumnIndex = 4 Then
                dgCharge.BeginEdit(True)
                'cmdSave.Enabled = Enq_right_local
                If row.Cells("ytt_del").Value.ToString = "" And row.Cells("ytt_creusr").Value.ToString = "~*ADD*~" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    dgCharge.BeginEdit(True)
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If
            End If
        End If
        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub




    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCharge.CellValidating
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String

        'If mmdExit.Focused Then
        '    Return
        'End If

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("ytt_cde"), "Z+Numeric", 2) Then

                    'row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    'e.Cancel = True
                ElseIf row.Cells("ytt_cde").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in function code!")
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    'e.Cancel = True
                ElseIf Not (row.Cells("ytt_cde").EditedFormattedValue.ToString.Length = 2) Then
                    MsgBox("Length of function code is not 2 digit!")
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    validcheck = 0
                    e.Cancel = True 'Frankie Cheung 20111210
                    Exit Sub
                    'e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ytt_cde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated function code!")
                                row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                                'e.Cancel = True
                                e.Cancel = True 'Frankie Cheung 20111210
                                validcheck = 0
                                Exit Sub
                            End If
                        End If
                    Next
                End If





                If chkGrdCellValue(row.Cells("ytt_cde"), "Z+Numeric", 2) Then

                    If row.Cells("ytt_cde").EditedFormattedValue.ToString.Length <> 0 Then

                        If row.Cells("ytt_cde").EditedFormattedValue.ToString.Length = 2 Then


                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> e.RowIndex Then
                                    'If drr.Cells("ytt_cde").Value.ToString.ToUpper <> strNewVal.ToUpper Then
                                    validcheck = 1
                                    'Else
                                    'validcheck = 0
                                    'End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If


            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("ytt_cde"), "Z+Numeric", 2) Then
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                    validcheck = 0
                    Exit Sub
                End If
            End If





        End If

    End Sub




    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click

        Dim addnewrow As Boolean

        addnewrow = False

        Call SetStatusBar("InsRow")
        Call setStatus("InsRow")

        If rs_SYTRDTRM.Tables("RESULT").Rows.Count = 0 Then
            addnewrow = True
        ElseIf rs_SYTRDTRM.Tables("RESULT").Rows(rs_SYTRDTRM.Tables("RESULT").Rows.Count - 1).Item("ytt_cde").ToString = "" Or rs_SYTRDTRM.Tables("RESULT").Rows(rs_SYTRDTRM.Tables("RESULT").Rows.Count - 1).Item("ytt_typ").ToString = "" Or rs_SYTRDTRM.Tables("RESULT").Rows(rs_SYTRDTRM.Tables("RESULT").Rows.Count - 1).Item("ytt_grp").ToString = "" Or rs_SYTRDTRM.Tables("RESULT").Rows(rs_SYTRDTRM.Tables("RESULT").Rows.Count - 1).Item("ytt_dsc").ToString = "" Then
            addnewrow = False
            MsgBox("Please insert all of information first before add the new row")
            For Each row As DataGridViewRow In dgCharge.Rows
                If row.Cells("ytt_cde").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                ElseIf row.Cells("ytt_typ").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("ytt_typ")
                ElseIf row.Cells("ytt_grp").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("ytt_grp")
                ElseIf row.Cells("ytt_dsc").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("ytt_dsc")
                End If
            Next
        ElseIf rs_SYTRDTRM.Tables("RESULT").Rows(rs_SYTRDTRM.Tables("RESULT").Rows.Count - 1).Item("ytt_creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 Then
                addnewrow = True
            Else
                MsgBox("Please insert all information, ensure the right code format and no duplicate code before adding the new row")
                addnewrow = False
            End If
        End If

        If addnewrow = True Then
            dsNewRow = rs_SYTRDTRM.Tables("RESULT").NewRow()

            dsNewRow.Item("ytt_creusr") = "~*ADD*~"
            dsNewRow.Item("ytt_del") = ""

            rs_SYTRDTRM.Tables("RESULT").Rows.Add(dsNewRow)
        End If


        For Each drr As DataGridViewRow In dgCharge.Rows
            If IsDBNull(drr.Cells(3).Value) Then
                dgCharge.CurrentCell = drr.Cells(1)
                dgCharge.CurrentCell.ReadOnly = False
                dgCharge.BeginEdit(True)
            End If
        Next
        mmdClear.Enabled = True

    End Sub




    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("ytt_cde").Value.ToString = "" Then
                If row.Cells("ytt_del").Value.ToString = "" Then
                    row.Cells("ytt_del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ytt_del").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
                Call SetStatusBar("DelRow")
            End If
        End If
        mmdClear.Enabled = True
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        ''Dim strUsrGrp, strComGrp As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows


                If row.Cells("ytt_del").Value.ToString = "" Then



                    If Not chkGrdCellValue(row.Cells("ytt_cde"), "Z+Numeric", 2) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("ytt_cde")



                    ElseIf Not (row.Cells("ytt_cde").EditedFormattedValue.ToString.Length = 2) Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("The code should be 2 digit!")
                        row.DataGridView.CurrentCell = row.Cells("ytt_cde")





                    ElseIf Not chkGrdCellValue(row.Cells("ytt_typ"), "String", 3) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("ytt_typ")
                    ElseIf Not chkGrdCellValue(row.Cells("ytt_grp"), "String", 50) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("ytt_grp")
                    ElseIf row.Cells("ytt_dsc").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Description should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("ytt_dsc")
                    Else
                        If row.Cells("ytt_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ytt_cde").Value.ToString.ToUpper = row.Cells("ytt_cde").Value.ToString.ToUpper And _
                                    drr.Cells("ytt_del").Value.ToString = "" Then
                                        'If drr.Cells("ytt_cde").Value.ToString.ToUpper = row.Cells("ytt_cde").Value.ToString.ToUpper Then
                                        MsgBox("Duplicated function code " & drr.Cells("ytt_cde").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ytt_cde")
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

                If Not save_ok Then
                    Exit For
                End If
            Next

            If Not save_ok Then
                dgCharge.BeginEdit(True)
                Exit Sub
            Else

                gspStr = ""
                For Each dr As DataRow In rs_SYTRDTRM.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        ''MsgBox(dr.RowState & " " & DataRowState.Modified)
                        If dr.Item("ytt_del") = "Y" Then

                            '' "sp_select_SYTRDTRM'" & gsCompany & "','AL'"
                            gspStr = "sp_physical_delete_SYTRDTRM '" & gsCompany & "','" & _
                                        dr.Item("ytt_cde").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYTRDTRM '" & gsCompany & "','" & _
                                        dr.Item("ytt_cde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_typ").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_grp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ytt_del") = "Y" Then

                        If dr.Item("ytt_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYTRDTRM '" & gsCompany & "','" & _
                                        dr.Item("ytt_cde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_typ").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_grp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ytt_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If

                        'ElseIf dr.Item("ytt_del") = "Y" Then

                        'gspStr = "sp_physical_delete_SYTRDTRM '" & gsCompany & "','" & _
                        ' dr.Item("ytt_cde").ToString.Replace("'", "''").Trim & "'"
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00102 sp_update_SYTRDTRM : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_SYTRDTRM.AcceptChanges()
                    Call setStatus("Save")
                    SetStatusBar("Save")
                    Call SYM00102_Load(sender, e)
                Else
                    save_ok = False
                    rs_SYTRDTRM.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_SYTRDTRM.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_SYTRDTRM.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If

        'If flgMod Then
        If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call mmdSave_Click(sender, e)

                If save_ok Then
                    'Call SYM00102_Load(sender, e)
                    'Else
                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00102_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00102_Load(sender, e)
        End If
    End Sub

    Private Sub dgCharge_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCharge.ParentChanged

    End Sub

    Private Sub dgCharge_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCharge.Enter

    End Sub

    Private Sub dgCharge_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEnter
        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            'If row.Cells("ytt_del").Value.ToString = "" And row.Cells("ytt_creusr").Value.ToString = "~*ADD*~" Then
            If row.Cells("ytt_creusr").Value.ToString = "~*ADD*~" Then
                'If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                createComboBoxCell(dgCharge.CurrentCell)
                dgCharge.BeginEdit(True)
                mmdSave.Enabled = Enq_right_local
                'End If
            Else
                row.Cells(e.ColumnIndex).ReadOnly = True
            End If
        ElseIf e.ColumnIndex = 1 Or e.ColumnIndex = 4 Then
            dgCharge.BeginEdit(True)
            If row.Cells("ytt_del").Value.ToString = "" And row.Cells("ytt_creusr").Value.ToString = "~*ADD*~" Then
                row.Cells(e.ColumnIndex).ReadOnly = False
                dgCharge.BeginEdit(True)
            Else
                row.Cells(e.ColumnIndex).ReadOnly = True
            End If
        End If
    End Sub
End Class


