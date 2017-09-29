Public Class SYM00105
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
        'SYM00105
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
        Me.Name = "SYM00105"
        Me.Text = "SYM00105 - Claims Email Group Maintenance"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYEMLGRP As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer
    Public validcheck2 As Integer



    Private Sub SYM00105_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ''add on 11/8/2011
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right


            validcheck = 1
            validcheck2 = 1
           


            gsCompany = "UCP"
            gspStr = "sp_list_SYEMLGRP'" & gsCompany & "'"
            'rtnLong = getConnStr(gsConnStr, rtnStr)
            rtnLong = execute_SQLStatement(gspStr, rs_SYEMLGRP, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00105 #001 sp_list_SYEMLGRP : " & rtnStr)
            Else
                dgCharge.DataSource = rs_SYEMLGRP.Tables("RESULT").DefaultView

                rs_SYEMLGRP.Tables("RESULT").Columns(0).ReadOnly = False


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
        Dim dt As DataTable = rs_SYEMLGRP.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                'If (column
                dc.ReadOnly = False

            Next
            ''rs_SYEMLGRP.Tables("RESULT").Columns("DEL").ColumnName = "yeg_del"
            For Each dr As DataRow In dt.Rows
                dr.Item("yeg_del") = ""
            Next
            rs_SYEMLGRP.AcceptChanges()
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
            .Columns(i).Width = 125
            .Columns(i).HeaderText = "Department"
            i = i + 1
            '2
            .Columns(i).Width = 110
            .Columns(i).HeaderText = "User ID"
            i = i + 1
            '3
            .Columns(i).Width = 170
            .Columns(i).HeaderText = "User Name"
            i = i + 1

            .Columns(i).Width = 260
            .Columns(i).HeaderText = "Email Address"
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
            Me.cmdDelRow.Enabled = Del_right_local
            Me.cmdDelete.Enabled = False
            Me.cmdClear.Enabled = True
            Me.cmdSave.Enabled = Enq_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00105_Load(Nothing, Nothing)
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
            For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yeg_dept").ToString.Trim)
            Next
        ElseIf iCol = 2 Then
            For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yeg_usrid").ToString.Trim)
            Next
        ElseIf iCol = 3 Then
            For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yeg_usrnm").ToString.Trim)
            Next
        ElseIf iCol = 4 Then
            For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yeg_maddr").ToString.Trim)
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
                    Me.dgCharge.Rows(iRow).Cells(iCol + 1).Value = rs_SYEMLGRP.Tables("RESULT").Select("yeg_typ = '" & strSelItem & "'")(0).Item("yeg_grp").ToString
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
            'cmdSave.Enabled = Enq_right_local
            If row.Cells("yeg_del").Value.ToString = "" And row.Cells("yeg_creusr").Value.ToString = "~*ADD*~" Then
                row.Cells(e.ColumnIndex).ReadOnly = False
                dgCharge.BeginEdit(True)
            Else
                row.Cells(e.ColumnIndex).ReadOnly = True
            End If
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

        If dgCharge.CurrentCell.ColumnIndex = 1 Then
            AddHandler e.Control.KeyPress, AddressOf Me.TextboxTextOnly_KeyPress
        End If

    End Sub

    Private Sub TextboxTextOnly_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        Dim NotallowedChars As String = "0123456789"

        If NotallowedChars.IndexOf(e.KeyChar) = -1 Then
            ' No not allow Character
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ''Toggle(Delete)
                If Not row.Cells("yeg_usrid").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If
            End If

            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
                dgCharge.BeginEdit(True)
                'cmdSave.Enabled = Enq_right_local
                If row.Cells("yeg_del").Value.ToString = "" And row.Cells("yeg_creusr").Value.ToString = "~*ADD*~" Then
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

        If cmdExit.Focused Then
            Return
        End If

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim


        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("yeg_dept"), "String", 30) Then

                    row.DataGridView.CurrentCell = row.Cells("yeg_dept")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                ElseIf row.Cells("yeg_dept").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in department!")
                    row.DataGridView.CurrentCell = row.Cells("yeg_dept")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                End If
            End If



            If e.ColumnIndex = 2 Then
                If Not chkGrdCellValue(row.Cells("yeg_usrid"), "String", 10) Then

                    row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    validcheck = 0
                    Exit Sub
                ElseIf row.Cells("yeg_usrid").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in user ID!")
                    row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    validcheck = 0
                    Exit Sub

                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yeg_usrid").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated user ID!")
                                row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                                'e.Cancel = True
                                e.Cancel = True 'Frankie Cheung 20111210
                                validcheck = 0
                                Exit Sub
                            End If
                        End If
                    Next
                End If





                If chkGrdCellValue(row.Cells("yeg_usrid"), "String", 10) Then


                    If row.Cells("yeg_usrid").EditedFormattedValue.ToString.Length <> 0 Then

                        For Each drr As DataGridViewRow In dgCharge.Rows
                            If drr.Index <> e.RowIndex Then
                                If drr.Cells("yeg_usrid").Value.ToString.ToUpper <> strNewVal.ToUpper Then
                                    validcheck = 1
                                Else
                                    MsgBox("Duplicated user ID!")
                                    validcheck = 0
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If
                End If
            End If

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("yeg_usrnm"), "String", 30) Then

                    row.DataGridView.CurrentCell = row.Cells("yeg_usrnm")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                ElseIf row.Cells("yeg_usrnm").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in user name!")
                    row.DataGridView.CurrentCell = row.Cells("yeg_usrnm")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210

                End If
            End If

            Dim stringas As String

            If e.ColumnIndex = 4 Then
                If row.Cells("yeg_maddr").IsInEditMode Then
                    stringas = row.Cells("yeg_maddr").EditedFormattedValue
                Else
                    stringas = row.Cells("yeg_maddr").Value
                End If

                If Not chkGrdCellValue(row.Cells("yeg_maddr"), "String", 30) Then

                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                    'e.Cancel = True
                    e.Cancel = True 'Frankie Cheung 20111210
                    validcheck2 = 0
                    Exit Sub
                ElseIf row.Cells("yeg_maddr").EditedFormattedValue.ToString.Length = 0 Then
                    MsgBox("It cannot be NULL in email address!")
                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                    validcheck2 = 0
                    Exit Sub
                ElseIf Microsoft.VisualBasic.Right(stringas.ToString.Trim, 11) <> "@ucp.com.hk" Then
                    MsgBox("The email address domain should be @ucp.com.hk")
                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                    validcheck2 = 0
                    Exit Sub
                ElseIf CharCount(stringas, "@") > 1 Or CharCount(stringas, ".") > 2 Or CharCount(stringas, ",") > 0 _
                Or CharCount(stringas, "/") > 0 Or CharCount(stringas, "[") > 0 Or CharCount(stringas, "]") > 0 Or CharCount(stringas, "/") > 0 Or CharCount(stringas, "`") > 0 Or CharCount(stringas, "=") > 0 _
                Or CharCount(stringas, "-") > 0 Or CharCount(stringas, "+") > 0 Or CharCount(stringas, "{") > 0 Or CharCount(stringas, "}") > 0 Or CharCount(stringas, "'") > 0 Or CharCount(stringas, """") > 0 _
                Or CharCount(stringas, "|") > 0 Or CharCount(stringas, "!") > 0 Or CharCount(stringas, "#") > 0 Or CharCount(stringas, "$") > 0 Or CharCount(stringas, "%") > 0 Or CharCount(stringas, "^") > 0 _
                Or CharCount(stringas, "&") > 0 Or CharCount(stringas, "*") > 0 Or CharCount(stringas, ":") > 0 Or CharCount(stringas, ";") > 0 Or CharCount(stringas, "<") > 0 Or CharCount(stringas, ">") > 0 _
                Or CharCount(stringas, "?") > 0 Or CharCount(stringas, "~") > 0 Then
                    MsgBox("The email address format is incorrect!")
                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                    validcheck2 = 0
                    Exit Sub
                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yeg_maddr").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated email address!")
                                row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                                'e.Cancel = True
                                e.Cancel = True 'Frankie Cheung 20111210
                                validcheck2 = 0
                                Exit Sub
                            End If
                        End If
                    Next




                End If



                If chkGrdCellValue(row.Cells("yeg_maddr"), "String", 30) Then


                    If row.Cells("yeg_maddr").EditedFormattedValue.ToString.Length <> 0 Then


                        If Microsoft.VisualBasic.Right(stringas.ToString.Trim, 11) = "@ucp.com.hk" Then

                            If CharCount(stringas, "@") = 1 And CharCount(stringas, ".") = 2 And CharCount(stringas, ",") = 0 _
                            And CharCount(stringas, "/") = 0 And CharCount(stringas, "[") = 0 And CharCount(stringas, "]") = 0 And CharCount(stringas, "/") = 0 And CharCount(stringas, "`") = 0 And CharCount(stringas, "=") = 0 _
                            And CharCount(stringas, "-") = 0 And CharCount(stringas, "+") = 0 And CharCount(stringas, "{") = 0 And CharCount(stringas, "}") = 0 And CharCount(stringas, "'") = 0 And CharCount(stringas, """") = 0 _
                            And CharCount(stringas, "|") = 0 And CharCount(stringas, "!") = 0 And CharCount(stringas, "#") = 0 And CharCount(stringas, "$") = 0 And CharCount(stringas, "%") = 0 And CharCount(stringas, "^") = 0 _
                            And CharCount(stringas, "&") = 0 And CharCount(stringas, "*") = 0 And CharCount(stringas, ":") = 0 And CharCount(stringas, ";") = 0 And CharCount(stringas, "<") = 0 And CharCount(stringas, ">") = 0 _
                            And CharCount(stringas, "?") = 0 And CharCount(stringas, "~") = 0 Then
                                validcheck2 = 1

                            End If
                        End If

                        'If e.ColumnIndex = 3 Then
                        'If Not chkGrdCellValue(row.Cells("yeg_typ"), "String", 3) Then
                        'e.Cancel = True
                        'End If
                        'End If
                    End If
                End If
            End If
        End If
    End Sub




    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

        Dim addnewrow As Boolean

        addnewrow = False

        SetStatusBar("InsRow")
        Call SetStatus("InsRow")

        If rs_SYEMLGRP.Tables("RESULT").Rows.Count = 0 Then
            addnewrow = True
        ElseIf rs_SYEMLGRP.Tables("RESULT").Rows(rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1).Item("yeg_dept").ToString = "" Or rs_SYEMLGRP.Tables("RESULT").Rows(rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1).Item("yeg_usrid").ToString = "" Or rs_SYEMLGRP.Tables("RESULT").Rows(rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1).Item("yeg_usrnm").ToString = "" Or rs_SYEMLGRP.Tables("RESULT").Rows(rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1).Item("yeg_maddr").ToString = "" Then
            addnewrow = False
            MsgBox("Please insert all of information  first before add the new row")
            For Each row As DataGridViewRow In dgCharge.Rows
                If row.Cells("yeg_dept").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yeg_dept")
                ElseIf row.Cells("yeg_usrid").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                ElseIf row.Cells("yeg_usrnm").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yeg_usrnm")
                ElseIf row.Cells("yeg_maddr").Value.ToString.Trim = "" Then
                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                End If
            Next

        ElseIf rs_SYEMLGRP.Tables("RESULT").Rows(rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1).Item("yeg_creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 And validcheck2 = 1 Then
                addnewrow = True
            Else
                If validcheck <> 1 Then
                    MsgBox("Please insert the right user ID before adding the new row")
                    For Each row As DataGridViewRow In dgCharge.Rows
                        row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                    Next
                End If

                If validcheck2 <> 1 Then
                    MsgBox("Please insert the right email format before adding the new row")
                    For Each row As DataGridViewRow In dgCharge.Rows
                        row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                    Next
                End If

                addnewrow = False
            End If
        End If

        If addnewrow = True Then
            dsNewRow = rs_SYEMLGRP.Tables("RESULT").NewRow()

            dsNewRow.Item("yeg_creusr") = "~*ADD*~"
            dsNewRow.Item("yeg_del") = ""

            rs_SYEMLGRP.Tables("RESULT").Rows.Add(dsNewRow)
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
            If Not row.Cells("yeg_usrid").Value.ToString = "" Then
                If row.Cells("yeg_del").Value.ToString = "" Then
                    row.Cells("yeg_del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yeg_del").Value = ""
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
        Dim addrcheck() As String
        Dim addrform() As Char
        Dim count As Integer
        Dim check As Integer

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows


                If row.Cells("yeg_del").Value.ToString = "" Then



                    If Not chkGrdCellValue(row.Cells("yeg_dept"), "String", 30) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yeg_dept")




                    ElseIf row.Cells("yeg_dept").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Department should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yeg_dept")




                    ElseIf Not chkGrdCellValue(row.Cells("yeg_usrid"), "String", 10) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yeg_usrid")

                    ElseIf row.Cells("yeg_usrid").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("User ID should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yeg_usrid")

                    ElseIf Not chkGrdCellValue(row.Cells("yeg_usrnm"), "String", 30) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yeg_usrnm")


                    ElseIf row.Cells("yeg_usrnm").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("User Name should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yeg_usrnm")


                    ElseIf Not chkGrdCellValue(row.Cells("yeg_maddr"), "String", 30) Then
                        save_ok = False
                        flgReAct = True
                        row.DataGridView.CurrentCell = row.Cells("yeg_maddr")

                    ElseIf row.Cells("yeg_maddr").Value.ToString.Trim = "" Then
                        save_ok = False
                        flgReAct = True
                        MsgBox("Email address should not be empty!")
                        row.DataGridView.CurrentCell = row.Cells("yeg_maddr")

                    Else
                        If row.Cells("yeg_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yeg_usrid").Value.ToString.ToUpper = row.Cells("yeg_usrid").Value.ToString.ToUpper And _
                                       drr.Cells("yeg_del").Value.ToString = "" Then

                                        MsgBox("Duplicated user ID " & drr.Cells("yeg_usrid").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yeg_usrid")
                                    End If
                                End If
                            Next
                        End If

                        If row.Cells("yeg_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dgCharge.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yeg_maddr").Value.ToString.ToUpper = row.Cells("yeg_maddr").Value.ToString.ToUpper And _
                                       drr.Cells("yeg_del").Value.ToString = "" Then

                                        MsgBox("Duplicated email address " & drr.Cells("yeg_maddr").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                                    End If
                                End If
                            Next
                        End If
                        If Not row.Cells("yeg_maddr").Value.ToString.Contains("@ucp.com.hk") Then
                            MsgBox("The email address format is incorrect!")
                            row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                            save_ok = False
                            flgReAct = True
                        Else
                            addrcheck = Split(row.Cells("yeg_maddr").Value.ToString, "@")
                            addrform = row.Cells("yeg_maddr").Value.ToString
                            check = 0

                            If addrcheck(addrcheck.Length - 1) <> "ucp.com.hk" Then
                                MsgBox("The email domain should be @ucp.com.hk!")
                                row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                                save_ok = False
                                flgReAct = True

                            Else

                                For count = 0 To addrform.Length - 1
                                    If addrform(count) = "@" Then
                                        check = check + 1
                                    End If
                                Next

                                If check > 1 Then
                                    MsgBox("The email format is incorrect!")
                                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                                    save_ok = False
                                    flgReAct = True
                                End If
                                Dim stringas As String
                                stringas = row.Cells("yeg_maddr").Value
                                If CharCount(stringas, "@") > 1 Or CharCount(stringas, ".") > 2 Or CharCount(stringas, ",") > 0 _
                Or CharCount(stringas, "/") > 0 Or CharCount(stringas, "[") > 0 Or CharCount(stringas, "]") > 0 Or CharCount(stringas, "/") > 0 Or CharCount(stringas, "`") > 0 Or CharCount(stringas, "=") > 0 _
                Or CharCount(stringas, "-") > 0 Or CharCount(stringas, "+") > 0 Or CharCount(stringas, "{") > 0 Or CharCount(stringas, "}") > 0 Or CharCount(stringas, "'") > 0 Or CharCount(stringas, """") > 0 _
                Or CharCount(stringas, "|") > 0 Or CharCount(stringas, "!") > 0 Or CharCount(stringas, "#") > 0 Or CharCount(stringas, "$") > 0 Or CharCount(stringas, "%") > 0 Or CharCount(stringas, "^") > 0 _
                Or CharCount(stringas, "&") > 0 Or CharCount(stringas, "*") > 0 Or CharCount(stringas, ":") > 0 Or CharCount(stringas, ";") > 0 Or CharCount(stringas, "<") > 0 Or CharCount(stringas, ">") > 0 _
                Or CharCount(stringas, "?") > 0 Or CharCount(stringas, "~") > 0 Then
                                    MsgBox("The email address format is incorrect!")
                                    row.DataGridView.CurrentCell = row.Cells("yeg_maddr")
                                    save_ok = False
                                    flgReAct = True
                                End If
                            End If
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
                For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        ''MsgBox(dr.RowState & " " & DataRowState.Modified)
                        If dr.Item("yeg_del") = "Y" Then
                            '' "sp_select_SYEMLGRP'" & gsCompany & "','AL'"
                            gspStr = "sp_physical_delete_SYEMLGRP '" & gsCompany & "','" & _
                                        dr.Item("yeg_usrid").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYEMLGRP '" & gsCompany & "','" & _
                                        dr.Item("yeg_dept").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_usrnm").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_maddr").ToString.ToLower.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yeg_del") = "Y" Then

                        If dr.Item("yeg_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYEMLGRP '" & gsCompany & "','" & _
                                        dr.Item("yeg_dept").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_usrnm").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yeg_maddr").ToString.ToLower.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                        'ElseIf dr.Item("yeg_del") = "Y" Then

                        'gspStr = "sp_physical_delete_SYEMLGRP '" & gsCompany & "','" & _
                        'dr.Item("yeg_usrid").ToString.Replace("'", "''").Trim & "'"
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00105 sp_update_SYEMLGRP : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_SYEMLGRP.AcceptChanges()
                    Call SetStatus("Save")
                    SetStatusBar("Save")
                    Call SYM00105_Load(sender, e)
                Else
                    save_ok = False
                    rs_SYEMLGRP.RejectChanges()
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
        If Not rs_SYEMLGRP.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
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
                    'Call SYM00105_Load(sender, e)
                    'Else
                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00105_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00105_Load(sender, e)
        End If
    End Sub



    Public Function CharCount(ByVal OrigString As String, _
  ByVal Chars As String, Optional ByVal CaseSensitive As Boolean = False) _
  As Long

        '**********************************************
        'PURPOSE: Returns Number of occurrences of a character or
        'or a character sequencence within a string

        'PARAMETERS:
        'OrigString: String to Search in
        'Chars: Character(s) to search for
        'CaseSensitive (Optional): Do a case sensitive search
        'Defaults to false

        'RETURNS:
        'Number of Occurrences of Chars in OrigString

        'EXAMPLES:
        'Debug.Print CharCount("FreeVBCode.com", "E") -- returns 3
        'Debug.Print CharCount("FreeVBCode.com", "E", True) -- returns 0
        'Debug.Print CharCount("FreeVBCode.com", "co") -- returns 2
        ''**********************************************

        Dim lLen As Long
        Dim lCharLen As Long
        Dim lAns As Long
        Dim sInput As String
        Dim sChar As String
        Dim lCtr As Long
        Dim lEndOfLoop As Long
        Dim bytCompareType As Byte

        sInput = OrigString
        If sInput = "" Then Exit Function
        lLen = Len(sInput)
        lCharLen = Len(Chars)
        lEndOfLoop = (lLen - lCharLen) + 1
        bytCompareType = IIf(CaseSensitive, vbBinaryCompare, _
           vbTextCompare)

        For lCtr = 1 To lEndOfLoop
            sChar = Mid(sInput, lCtr, lCharLen)
            If StrComp(sChar, Chars, bytCompareType) = 0 Then _
                lAns = lAns + 1
        Next

        CharCount = lAns

    End Function

End Class

