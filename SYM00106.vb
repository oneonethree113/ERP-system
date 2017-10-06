Public Class SYM00106
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
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
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
        Me.dgCharge = New System.Windows.Forms.DataGridView
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmdDelete.Text = "&Delete"
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 474)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(752, 22)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(646, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(566, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(606, 0)
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
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(464, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(526, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(408, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 15
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(340, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "Searc&h"
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(12, 46)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCharge.Size = New System.Drawing.Size(728, 422)
        Me.dgCharge.TabIndex = 7
        '
        'SYM00106
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.dgCharge)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SYM00106"
        Me.Text = "SYM00106 - Claims Email Template Maintenance"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYEMLTMP As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer



    Private Sub SYM00106_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        validcheck = 1
        ''add on 11/8/2011
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right
            ''end of add

            gsCompany = "UCP"
            gspStr = "sp_list_SYEMLTMP'" & gsCompany & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_SYEMLTMP, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00106 #001 sp_list_SYEMLTMP : " & rtnStr)
            Else
                dgCharge.DataSource = rs_SYEMLTMP.Tables("RESULT").DefaultView

                rs_SYEMLTMP.Tables("RESULT").Columns(0).ReadOnly = False


                Call format_dgCharge()
                Call setDataRowAttr()
                Call SetStatusBar("Init")
                mode = "INIT"
                Call SetStatus(mode)

            End If
            Call Formstartup(Me.Name)

            '' add on 11/8/2011
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
        '' end add
    End Sub



    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_SYEMLTMP.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                'If (column
                dc.ReadOnly = False

            Next
            ''rs_SYEMLTMP.Tables("RESULT").Columns("DEL").ColumnName = "yet_del"
            For Each dr As DataRow In dt.Rows
                dr.Item("yet_del") = ""
            Next
            rs_SYEMLTMP.AcceptChanges()
        End If
    End Sub






    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.ssBar.Text = "Init" Then
            Me.Close()
        Else

            If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call cmdSave_Click(sender, e)

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
            .Columns(i).Width = 40
            .Columns(i).HeaderText = "Code"
            i = i + 1
            '2
            .Columns(i).Width = 220
            .Columns(i).HeaderText = "Head"
            i = i + 1
            '3   

            .Columns(i).Width = 405
            .Columns(i).HeaderText = "Content"
            i = i + 1


            Dim j As Integer
            For j = i To dgCharge.Columns.Count - 1
                .Columns(j).Visible = False
            Next j

        End With

    End Sub








    Private Sub SetStatus(ByVal mode As String)
        If mode = "INIT" Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = True
            Me.cmdDelRow.Enabled = True
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = True
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00106_Load(Nothing, Nothing)
            Call SetStatusBar(mode)
        ElseIf mode = "DelRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Me.cmdClear.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False

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
            For Each dr As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yet_tmpcde").ToString.Trim)
            Next

        ElseIf iCol = 2 Then
            For Each dr As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yet_tmphd").ToString.Trim)
            Next
        ElseIf iCol = 3 Then
            For Each dr As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yet_tmpcont").ToString.Trim)
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
                    Me.dgCharge.Rows(iRow).Cells(iCol + 1).Value = rs_SYEMLTMP.Tables("RESULT").Select("yet_typ = '" & strSelItem & "'")(0).Item("yet_grp").ToString
                ElseIf iCol = 3 Then
                    Me.dgCharge.Rows(iRow).Cells(iCol).Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub dgCharge_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellEnter
        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            dgCharge.BeginEdit(True)
            If row.Cells("yet_del").Value.ToString = "" And row.Cells("yet_creusr").Value.ToString = "~*ADD*~" Then
                row.Cells(e.ColumnIndex).ReadOnly = False
            Else
                row.Cells(e.ColumnIndex).ReadOnly = True
            End If
            dgCharge.BeginEdit(True)
        End If

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
                If Not row.Cells("yet_tmpcde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If
            End If
            'If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Then
            'If row.Cells("yet_del").Value.ToString = "" And row.Cells("yet_creusr").Value.ToString = "~*ADD*~" Then
            'If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
            'createComboBoxCell(dgCharge.CurrentCell)
            'dgCharge.BeginEdit(True)
            'cmdSave.Enabled = Enq_right_local
            'End If
            'Else
            'row.Cells(e.ColumnIndex).ReadOnly = True
            'End If
            'ElseIf e.ColumnIndex = 1 Or e.ColumnIndex = 4 Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                dgCharge.BeginEdit(True)
                'cmdSave.Enabled = Enq_right_local
                If row.Cells("yet_del").Value.ToString = "" And row.Cells("yet_creusr").Value.ToString = "~*ADD*~" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If
                dgCharge.BeginEdit(True)
            End If
        End If


        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub




    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCharge.CellValidating
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String
        Dim sameidcheck As Integer

        If cmdExit.Focused Then
            Return
        End If

        sameidcheck = 0
        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("yet_tmpcde"), "String", 2) Then

                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    validcheck = 0
                    Exit Sub
                ElseIf row.Cells("yet_tmpcde").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in template ID!")
                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                    validcheck = 0
                    Exit Sub
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210

                    'ElseIf row.Cells("yet_dept").Value.ToString.Trim = "" Then
                    'MsgBox("Department should not be empty!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_dept")
                ElseIf Not (row.Cells("yet_tmpcde").EditedFormattedValue.ToString.Length = 2) Then
                    MsgBox("Length of template ID should be 2 digit!")
                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                    validcheck = 0
                    Exit Sub
                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yet_tmpcde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated template code!")
                                row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                                'e.Cancel = True
                                e.Cancel = True 'Frankie Cheung 20111210
                                validcheck = 0
                                Exit Sub
                            End If
                        End If
                    Next
                End If






                If chkGrdCellValue(row.Cells("yet_tmpcde"), "String", 2) Then


                    If row.Cells("yet_tmpcde").EditedFormattedValue.ToString.Length <> 0 Then

                        If row.Cells("yet_tmpcde").EditedFormattedValue.ToString.Length = 2 Then

                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> e.RowIndex Then
                                    If drr.Cells("yet_tmpcde").Value.ToString.ToUpper = strNewVal.ToUpper Then

                                        MsgBox("Duplicated function code!")
                                        validcheck = 0
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            'If e.ColumnIndex = 2 Then
            'If Not chkGrdCellValue(row.Cells("yet_clmstat"), "String", 3) Then

            'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")
            'e.Cancel = True
            'ElseIf row.Cells("yet_clmstat").EditedFormattedValue.ToString.Length = 0 Then
            'MsgBox("It cannot be NULL in user ID!")
            'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")
            'e.Cancel = True
            'ElseIf Not (row.Cells("yet_clmstat").EditedFormattedValue.ToString.Length = 3) Then
            'MsgBox("Length of claim status should be 3 characters!")
            'row.DataGridView.CurrentCell = row.Cells("yet_cde")
            'e.Cancel = True
            'ElseIf row.Cells("yet_clmstat").Value.ToString.Trim = "" Then
            'MsgBox("User ID should not be empty!")
            'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")

            'Else
            'For Each drr As DataGridViewRow In dgCharge.Rows
            'If drr.Index <> e.RowIndex Then
            'If drr.Cells("yet_clmstat").Value.ToString.ToUpper = strNewVal.ToUpper Then
            'MsgBox("Duplicated claim status!")
            'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")
            'e.Cancel = True
            'Exit For
            'End If
            'End If
            'Next
            'End If
            'End If


            If e.ColumnIndex = 2 Then
                If Not chkGrdCellValue(row.Cells("yet_tmphd"), "String", 100) Then

                    'row.DataGridView.CurrentCell = row.Cells("yet_usrnm")
                    row.DataGridView.CurrentCell = row.Cells("yet_tmphd")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                ElseIf row.Cells("yet_tmphd").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in head!")
                    row.DataGridView.CurrentCell = row.Cells("yet_tmphd")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    'ElseIf Not (row.Cells("yet_cde").EditedFormattedValue.ToString.Length = 2) Then
                    'MsgBox("Length of function code is not 2 digit!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_cde")
                    'e.Cancel = True
                    'Else
                    'For Each drr As DataGridViewRow In dgCharge.Rows
                    'If drr.Index <> e.RowIndex Then
                    'If drr.Cells("yet_usrnm").Value.ToString.ToUpper = strNewVal.ToUpper Then
                    'MsgBox("Duplicated user name!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_usrnm")
                    'e.Cancel = True
                    'Exit For
                    'End If
                    'End If
                    'Next
                    'ElseIf row.Cells("yet_usrnm").Value.ToString.Trim = "" Then
                    'MsgBox("User name should not be empty!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_usrnm")

                End If
            End If


            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("yet_tmpcont"), "String", 500) Then

                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcont")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                ElseIf row.Cells("yet_tmpcont").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in content!")
                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcont")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    'ElseIf Not (row.Cells("yet_maddr").EditedFormattedValue.ToString.Length = 2) Then
                    'MsgBox("Length of function code is not 2 digit!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_maddr")
                    'e.Cancel = True
                    'Next

                    'ElseIf row.Cells("yet_maddr").Value.ToString.Trim = "" Then
                    'MsgBox("Email should not be empty!")
                    'row.DataGridView.CurrentCell = row.Cells("yet_maddr")


                End If

            End If

            'If e.ColumnIndex = 3 Then
            'If Not chkGrdCellValue(row.Cells("yet_typ"), "String", 3) Then
            'e.Cancel = True
            'End If
            'End If

        End If

    End Sub




    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

        Dim addnewrow As Boolean

        addnewrow = False

        SetStatusBar("InsRow")


        Call SetStatus("InsRow")

        If rs_SYEMLTMP.Tables("RESULT").Rows.Count = 0 Then
            addnewrow = True
        ElseIf rs_SYEMLTMP.Tables("RESULT").Rows(rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1).Item("yet_tmpcde").ToString = "" Or rs_SYEMLTMP.Tables("RESULT").Rows(rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1).Item("yet_tmphd").ToString = "" Or rs_SYEMLTMP.Tables("RESULT").Rows(rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1).Item("yet_tmpcont").ToString = "" _
        Or rs_SYEMLTMP.Tables("RESULT").Rows(rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1).Item("yet_tmpcde").ToString = "" Then
            addnewrow = False
            MsgBox("Please insert all of information first before add the new row")
            For Each row As DataGridViewRow In dgCharge.Rows
                If row.Cells("yet_tmpcde").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                ElseIf row.Cells("yet_tmphd").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yet_tmphd")
                ElseIf row.Cells("yet_tmpcont").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yet_tmpcont")
                End If
            Next

        ElseIf rs_SYEMLTMP.Tables("RESULT").Rows(rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1).Item("yet_creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 Then
                addnewrow = True
            Else
                MsgBox("Please insert the right information format first before adding the new row")
                addnewrow = False
            End If
        End If

        If addnewrow = True Then
            dsNewRow = rs_SYEMLTMP.Tables("RESULT").NewRow()

            dsNewRow.Item("yet_creusr") = "~*ADD*~"
            dsNewRow.Item("yet_del") = ""

            rs_SYEMLTMP.Tables("RESULT").Rows.Add(dsNewRow)
            For Each drr As DataGridViewRow In dgCharge.Rows
                If IsDBNull(drr.Cells(3).Value) Then
                    dgCharge.CurrentCell = drr.Cells(1)
                    dgCharge.CurrentCell.ReadOnly = False
                    dgCharge.BeginEdit(True)

                End If
            Next
        End If


        Call SetStatusBar("InsRow")
        Call SetStatus("InsRow")

    End Sub




    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("yet_tmpcde").Value.ToString = "" Then
                If row.Cells("yet_del").Value.ToString = "" Then
                    row.Cells("yet_del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yet_del").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call SetStatus("DelRow")
                Call SetStatusBar("DelRow")
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        ''Dim strUsrGrp, strComGrp As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False


        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows


                If row.Cells("yet_del").Value.ToString = "" Then



                    If Not chkGrdCellValue(row.Cells("yet_tmpcde"), "Z+Numeric", 2) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")



                    ElseIf Not (row.Cells("yet_tmpcde").EditedFormattedValue.ToString.Length = 2) Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Template ID should be 2 digit!")
                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                    ElseIf row.Cells("yet_tmpcde").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Template ID should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")




                        'ElseIf Not chkGrdCellValue(row.Cells("yet_clmstat"), "String", 3) Then
                        'save_ok = False
                        'flgReAct = True
                        'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")

                        'ElseIf row.Cells("yet_clmstat").Value.ToString.Trim = "" Then
                        'save_ok = False
                        'flgReAct = True
                        'MsgBox("Claim status should not be empty!")
                        'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")

                        'ElseIf Not (row.Cells("yet_clmstat").EditedFormattedValue.ToString.Length = 3) Then
                        'save_ok = False
                        'flgReAct = True
                        'MsgBox("Claim status should be 3 characters!")
                        'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")


                    ElseIf Not chkGrdCellValue(row.Cells("yet_tmphd"), "String", 100) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yet_tmphd")
                        'ElseIf row.Cells("yet_dsc").Value.ToString.Trim = "" Then
                        'save_ok = False
                        'flgReAct = True
                        'MsgBox("Description should not be empty!")
                        'row.DataGridView.CurrentCell = row.Cells("yet_dsc")

                    ElseIf row.Cells("yet_tmphd").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Head should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yet_tmphd")


                    ElseIf Not chkGrdCellValue(row.Cells("yet_tmpcont"), "String", 500) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcont")

                    ElseIf row.Cells("yet_tmpcont").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Content should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcont")

                    Else
                        If row.Cells("yet_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yet_tmpcde").Value.ToString.ToUpper = row.Cells("yet_tmpcde").Value.ToString.ToUpper And _
                                       drr.Cells("yet_del").Value.ToString = "" Then

                                        MsgBox("Duplicated template ID " & drr.Cells("yet_tmpcde").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yet_tmpcde")
                                    End If
                                End If
                            Next
                        End If


                        'If row.Cells("yet_credat").Value.ToString = "" Then
                        'For Each drr As DataGridViewRow In dgCharge.Rows
                        'If drr.Index <> row.Index Then
                        'If drr.Cells("yet_clmstat").Value.ToString.ToUpper = row.Cells("yet_clmstat").Value.ToString.ToUpper And _
                        'drr.Cells("yet_del").Value.ToString = "" Then

                        'MsgBox("Duplicated claim status " & drr.Cells("yet_clmstat").Value.ToString & "!")
                        'save_ok = False
                        'flgReAct = True
                        'row.DataGridView.CurrentCell = row.Cells("yet_clmstat")
                        'End If
                        'End If
                        'Next
                        'End If



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
                For Each dr As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        ''MsgBox(dr.RowState & " " & DataRowState.Modified)
                        If dr.Item("yet_del") = "Y" Then
                            '' "sp_select_SYEMLTMP'" & gsCompany & "','AL'"
                            gspStr = "sp_physical_delete_SYEMLTMP '" & gsCompany & "','" & _
                                        dr.Item("yet_tmpcde").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYEMLTMP '" & gsCompany & "','" & _
                                        dr.Item("yet_tmpcde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yet_tmphd").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yet_tmpcont").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yet_del") = "Y" Then

                        If dr.Item("yet_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYEMLTMP '" & gsCompany & "','" & _
                                        dr.Item("yet_tmpcde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yet_tmphd").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yet_tmpcont").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                        'ElseIf dr.Item("yet_del") = "Y" Then

                        'gspStr = "sp_physical_delete_SYEMLTMP '" & gsCompany & "','" & _
                        'dr.Item("yet_tmpcde").ToString.Replace("'", "''").Trim & "'"
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00106 sp_update_SYEMLTMP : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_SYEMLTMP.AcceptChanges()
                    Call SetStatus("Save")
                    SetStatusBar("Save")
                    Call SYM00106_Load(sender, e)
                Else
                    save_ok = False
                    rs_SYEMLTMP.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_SYEMLTMP.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If

        'If flgMod Then
        If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call cmdSave_Click(sender, e)

                If save_ok Then
                    'Call SYM00106_Load(sender, e)
                    'Else
                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00106_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00106_Load(sender, e)
        End If
    End Sub
End Class

