Public Class SAM00002

    Public rs_SAORDSUM As DataSet
    Public rs_SAORDDTL As DataSet

    Dim sort_itm_sum As Boolean
    Dim sort_orgitm_dtl As Boolean
    Dim sort_fnlitm_dtl As Boolean
    Dim Temp_CusNo As String

    Dim CoCde As String
    Dim vnItem As Boolean


    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        mmdFindClick()
    End Sub

    Private Sub SAM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        'Timer1.Enabled = False
        Dim v
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        For Each v In Me.Controls

            If IsDataGrid(v) Then
                v.TabAction = 1
                v.RowHeight = 190
                v.TabStop = True
                v.WrapCellPointer = False
            End If
        Next
        Me.KeyPreview = True
        Me.TabPageMain.SelectedIndex = 0

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position
        checkraido()
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Public Function IsDataGrid(ByVal v As Object) As Boolean
        If (TypeOf v Is DataGrid) Then
            IsDataGrid = True
        End If
    End Function
    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            Me.TabPageMain.SelectedIndex = 0
            Call SetInputBoxesStatus("DisableAll")
            'freeze_TabControl(-1)

            'Me.TabPageMain.TabPages(0).Enabled = False
            'Me.TabPageMain.TabPages(1).Enabled = False
            'TabPageMain.Enabled = False
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelete.Enabled = False
            mmdFind.Enabled = True
            mmdExit.Enabled = True
            txtCusNo.Enabled = True
            txtItmNo.Enabled = True
            cmd_S_ItmNo.Enabled = True
            cmd_S_ItmNo2.Enabled = True
            txtColCde.Enabled = True
            txtUpdDat.Enabled = True
            txtCusNo.Text = Temp_CusNo
            'txtCusNo.BackColor = vbWhite
            cboCoCde.Enabled = True
            cmdMapping.Enabled = True
        ElseIf Mode = "Updating" Then
            Call SetInputBoxesStatus("EnableAll")

            'release_TabControl()
            'TabPageMain.Enabled = True
            'Me.TabPageMain.TabPages(0).Enabled = True
            'Me.TabPageMain.TabPages(1).Enabled = False
            'Me.TabPageMain.TabPages(1).Enabled = True
            'grdDtl.Focus()
            'grdDtl.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdCopy.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelete.Enabled = False
            mmdDelRow.Enabled = False
            mmdFind.Enabled = False
            cmd_S_ItmNo.Enabled = True
            cmd_S_ItmNo2.Enabled = True
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            txtCusNo.Enabled = False
            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            txtUpdDat.Enabled = False
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False
            cmdMapping.Enabled = True
            grdDtl.Enabled = True
            Call SetStatusBar(Mode)
        ElseIf Mode = "Save" Then
            Call SetStatusBar(Mode)
            Call setStatus("Init")
        ElseIf Mode = "Delete" Then
            Call SetStatusBar(Mode)
        ElseIf Mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(Mode)
            Call setStatus("Init")
            txtCusNo.Focus()
        ElseIf Mode = "Searching" Then
            Call SetInputBoxesStatus("DisableAll")

            'release_TabControl()
            'TabPageMain.Enabled = True
            'Me.TabPageMain.TabPages(0).Enabled = True
            'Me.TabPageMain.TabPages(1).Enabled = False
            'Me.TabPageMain.TabPages(1).Enabled = True
            'grdDtl.Focus()
            'grdDtl.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdCopy.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelete.Enabled = False
            mmdDelRow.Enabled = False
            mmdFind.Enabled = False
            cmd_S_ItmNo.Enabled = False
            cmd_S_ItmNo2.Enabled = False
            mmdSearch.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            txtCusNo.Enabled = False
            txtItmNo.Enabled = False
            txtColCde.Enabled = False
            txtUpdDat.Enabled = False
            cboCoCde.Enabled = False
            txtCoNam.Enabled = False
            cmdMapping.Enabled = False
            grdDtl.Enabled = True

            rdbvenitm.Enabled = False
            rdbitmno.Enabled = False
            Call SetStatusBar("ReadOnly")
        End If
        If mmdSave.Enabled = False And mmdAdd.Enabled = False Then
            Call SetStatusBar("ReadOnly")
        End If

    End Sub
    Private Sub SetStatusBar(ByVal Mode As String)
        If Mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Please Enter a Qu No."
        ElseIf Mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "ADD"
        ElseIf Mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf Mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf Mode = "Delete" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Deleted"
        ElseIf Mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf Mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub
    Private Sub SetInputBoxesStatus(ByVal Mode As String)
        Dim v
        '*** (1) If Mode = "EnableAll", enable all controls
        If Mode = "EnableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = True
                End If

                If TypeOf v Is MenuStrip Then
                    For Each itm As ToolStripMenuItem In v.items
                        itm.Enabled = True
                    Next
                End If
            Next
            '*** (2) If Mode = "DisableAll", disable all controls
        ElseIf Mode = "DisableAll" Then
            For Each v In Me.Controls
                If IsInputBoxes(v) Then
                    v.Enabled = False
                End If
                If TypeOf v Is MenuStrip Then
                    For Each itm As ToolStripMenuItem In v.items
                        itm.Enabled = False
                    Next
                End If
            Next
        End If
    End Sub
    Public Function IsInputBoxes(ByVal v As Object) As Boolean
        If (TypeOf v Is TextBox) Or (TypeOf v Is CheckBox) Or _
           (TypeOf v Is ComboBox) Or (TypeOf v Is Button) Or _
           (TypeOf v Is DataGrid) Then
            IsInputBoxes = True
        Else
            IsInputBoxes = False
        End If
    End Function
    Private Sub ResetDefaultDisp()
        txtCusNo.Text = ""
        txtColCde.Text = ""
        txtUpdDat.Text = ""
        grdSum.DataSource = Nothing
        grdDtl.DataSource = Nothing
    End Sub
    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            If i = tabpageno Then
                Me.TabPageMain.TabPages(i).Enabled = True
            Else
                Me.TabPageMain.TabPages(i).Enabled = False
            End If
        Next i
    End Sub
    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i
    End Sub
    Public Function CheckDate(ByVal theDate As String) As Boolean
        Dim month%, day%, year%
        Dim mm$, dd$, yyyy$
        Dim valid As Boolean

        valid = True
        mm$ = Mid(theDate, 1, 2)
        dd$ = Mid(theDate, 4, 2)
        yyyy$ = Mid(theDate, 7, 4)

        If IsDate(theDate) = False Then
            valid = False
            GoTo result
        End If
        ' Only accept either all date fields filled or all date fields empty
        If Not ((mm$ = "  " And dd$ = "  " And yyyy$ = "    ") Or (mm$ <> "  " And dd$ <> "  " And yyyy$ <> "    ")) Then
            valid = False
            GoTo result
        End If

        month% = Val(mm$)   ' Convert the date into numbers
        day% = Val(dd$)
        year% = Val(yyyy$)

        If month% > 12 Then    ' Check the month
            valid = False
            GoTo result
        End If
        If month% = 1 Or month% = 3 Or _
           month% = 5 Or month% = 7 Or _
           month% = 8 Or month% = 10 Or _
           month% = 12 Then             ' Check the day
            'If Date% > 31 Then
            If day% > 31 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 Or month% = 4 Or _
           month% = 6 Or month% = 9 Or _
           month% = 11 Then             ' Check the day
            'If Date% > 30 Then
            If day% > 30 Then
                valid = False
                GoTo result
            End If
        End If
        If month% = 2 And day% > 28 And _
           year% Mod 4 <> 0 Then ' Check the leap year
            valid = False
            GoTo result
        End If
        '*** Add to check Date is in valid year by Lewis on 15/04/2003 ********************
        If year% < 1950 Or year% > 2049 Then 'So will it bombed at 2049?
            valid = False
            GoTo result
        End If
        '**********************************************************************************
result:
        CheckDate = valid
    End Function
    Private Sub Display()
        txtCusNo.Text = rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_pri")

        grdSum.DataSource = rs_SAORDSUM.Tables("RESULT").DefaultView
        Call Display_Sum()
        grdDtl.DataSource = rs_SAORDDTL.Tables("RESULT").DefaultView
        Call Display_Dtl()
    End Sub
    Private Sub Display_Sum()
        Dim X As Integer
        With grdSum
            For X = 0 To .Columns.Count - 1
                .Columns(X).ReadOnly = True
                '.Columns(X).Width = 0
            Next X

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False

            '.Columns(4).width = 1300
            .Columns(4).Width = 100
            .Columns(4).HeaderCell.Value = "Final Item No."

            '.Columns(5).width = 1000
            .Columns(5).Width = 60
            .Columns(5).HeaderCell.Value = "Color Code"

            '.Columns(6).width = 1300
            .Columns(6).Width = 120
            .Columns(6).HeaderCell.Value = "Item Description"

            '.Columns(7).width = 900
            .Columns(7).Width = 45
            .Columns(7).HeaderCell.Value = "Sample UM"

            '.Columns(8).width = 900
            .Columns(8).Width = 45
            .Columns(8).HeaderCell.Value = "Total Qty"

            '.Columns(9).width = 900
            .Columns(9).Width = 45
            .Columns(9).HeaderCell.Value = "Stock Qty"

            '.Columns(10).width = 900
            .Columns(10).Width = 45
            .Columns(10).HeaderCell.Value = "Cust Qty"

            '.Columns(11).width = 1000
            .Columns(11).Width = 45
            .Columns(11).HeaderCell.Value = "Shipped Qty"

            '.Columns(12).width = 900
            .Columns(12).Width = 40
            .Columns(12).HeaderCell.Value = "O/S Qty"

            '.Columns(13).width = 900
            .Columns(13).Width = 50
            .Columns(13).HeaderCell.Value = "Charged Qty"

            '.Columns(14).width = 900
            .Columns(14).Width = 45
            .Columns(14).HeaderCell.Value = "Shipped Free Qty"

            '.Columns(15).width = 900
            .Columns(15).Width = 40
            .Columns(15).HeaderCell.Value = "Free Qty"

            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            '.Columns(19).width = 2000
            .Columns(19).Width = 100
            .Columns(19).HeaderCell.Value = "Update Date"
            .Columns(19).DefaultCellStyle.Format = "MM/dd/yyyy"

            .Columns(20).Visible = False
            '.Columns(21).Width = 0
            .Columns(21).HeaderCell.Value = "Temp Item No."
            .Columns(21).DisplayIndex = 5
            .Columns(21).Width = 100
            .Columns(22).HeaderCell.Value = "Vendor Item No."
            .Columns(22).DisplayIndex = 6
            .Columns(22).Width = 100
            .Columns(23).HeaderCell.Value = "Vendor"
            .Columns(23).DisplayIndex = 7
            .Columns(23).Width = 80
            '.Columns(20).Width = 0

        End With
    End Sub
    Private Sub Display_Dtl()
        Dim X As Integer
        With grdDtl
            For X = 0 To .Columns.Count - 1
                .Columns(X).ReadOnly = True
            Next X

            '.Columns(0).width = 0
            '.Columns(1).width = 0
            '.Columns(2).width = 0
            '.Columns(3).width = 0
            '.Columns(4).width = 0
            '.Columns(5).width = 0
            '.Columns(6).width = 0
            '.Columns(7).width = 0



            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False

            '.Columns(8).Width = 400
            .Columns(8).Width = 30
            .Columns(8).HeaderCell.Value = "Del"

            '.Columns(9).width = 1300
            .Columns(9).Width = 100
            .Columns(9).HeaderCell.Value = "Original Item No."

            '.Columns(10).width = 1300
            .Columns(10).Width = 100
            .Columns(10).HeaderCell.Value = "Final Item No."

            '.Columns(11).width = 1000
            .Columns(11).Width = 60
            .Columns(11).HeaderCell.Value = "Color Code"

            '.Columns(12).width = 1800
            .Columns(12).Width = 120
            .Columns(12).HeaderCell.Value = "Packing (UM/Inner/Master/CFT)"

            '.Columns(13).width = 1300
            .Columns(13).Width = 120
            .Columns(13).HeaderCell.Value = "Item Desc."

            '.Columns(14).width = 600
            .Columns(14).Width = 45
            .Columns(14).HeaderCell.Value = "Sample UM"

            '.Columns(15).width = 900
            .Columns(15).Width = 45
            .Columns(15).HeaderCell.Value = "Stock Qty"

            '.Columns(16).width = 900
            .Columns(16).Width = 45
            .Columns(16).HeaderCell.Value = "Cust Qty"

            '.Columns(17).width = 900
            .Columns(17).Width = 45
            .Columns(17).HeaderCell.Value = "Total Qty"

            '.Columns(18).width = 500
            .Columns(18).Width = 40
            .Columns(18).HeaderCell.Value = "Selling CCY"

            '.Columns(19).width = 1000
            .Columns(19).Width = 50
            .Columns(19).HeaderCell.Value = "Selling Price"



            ' Disable rights checking, control by stored procedure
            'If gsFlgCst = 1 Then

            '.Columns(20).width = 500
            .Columns(20).Width = 40
            .Columns(20).HeaderCell.Value = "CCY" 'Factory CCY
            .Columns(20).Visible = False

            '.Columns(21).width = 1000
            .Columns(21).Width = 50

            '        If gsCompany = "UCPP" Then
            '            .Columns(21).HeaderCell.Value = "Sample Item Cost"
            '        Else
            .Columns(21).HeaderCell.Value = "Item Cost"
            '        End If

            '    Else
            '        .Columns(21).Width = 0
            '        .Columns(20).Width = 0
            '    End If

            .Columns(22).Visible = False
            .Columns(23).Visible = False

            '.Columns(24).width = 1300
            .Columns(24).Width = 80
            .Columns(24).HeaderCell.Value = "Customer Item No."
            '.Columns(25).width = 1300
            .Columns(25).Width = 80
            .Columns(25).HeaderCell.Value = "Customer Color Code"
            '.Columns(26).width = 2000
            .Columns(26).Width = 80
            .Columns(26).HeaderCell.Value = "Color Description"


            '.Columns(27).width = 800
            .Columns(27).Width = 60
            .Columns(27).HeaderCell.Value = "PV"
            '.Columns(28).width = 800
            .Columns(28).Width = 60
            .Columns(28).HeaderCell.Value = "Sub Code"

            '.Columns(29).width = 800
            .Columns(29).Width = 60
            .Columns(29).HeaderCell.Value = "CV"
            '.Columns(30).width = 800
            .Columns(30).Width = 60
            .Columns(30).HeaderCell.Value = "C. Sub Code"

            '.Columns(31).width = 1300
            .Columns(31).Width = 80
            .Columns(31).HeaderCell.Value = "Quotation No."
            '.Columns(32).width = 1300
            .Columns(32).Width = 80
            .Columns(32).HeaderCell.Value = "Sample Request No."

            .Columns(33).Visible = False
            .Columns(34).Visible = False
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            '.Columns(37).width = 2000
            .Columns(37).Width = 120
            .Columns(37).HeaderCell.Value = "Update Date"
            .Columns(37).DefaultCellStyle.Format = "MM/dd/yyyy"
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).HeaderCell.Value = "Temp Item No."
            .Columns(43).DisplayIndex = 11
            .Columns(43).Width = 100
            .Columns(44).HeaderCell.Value = "Vendor Item No."
            .Columns(44).DisplayIndex = 12
            .Columns(44).Width = 100
            .Columns(45).HeaderCell.Value = "Vendor"
            .Columns(45).DisplayIndex = 13
            .Columns(45).Width = 80
            .Columns(46).HeaderCell.Value = "Terms"
            .Columns(46).DisplayIndex = 16
            .Columns(46).Width = 150
        End With



        'Lester Wu 2005/03/12 Amend the datetime format show to be "MM/DD/YYYY"
        'StatusBar.Panels(2).Text = Format(rs_SAORDDTL("sad_credat"), "DD/MM/YYYY") & " " & Format(rs_SAORDDTL("sad_upddat"), "DD/MM/YYYY") & _
        '                              " " & rs_SAORDDTL("sad_updusr")

    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Temp_CusNo = txtCusNo.Text
        Call setStatus("Clear")
    End Sub
    Private Sub returnSelectedRecordsHandler(ByVal sender As Object)
        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
            Me.txtItmNo.Text = gsSearchKey
            Me.txtItmNo.Refresh()
            Me.txtColCde.Focus()
        End If

    End Sub
    Private Sub cmdMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMapping.Click
        'gsSearchKey = ""
        'If Me.txtItmNo.Text <> "" Then
        '    SYM00022.strITEMNO = Me.txtItmNo.Text
        '    If SYM00022.domapping = 1 Then
        '        SYM00022.Show(vbModal)
        '        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
        '            Me.txtItmNo.Text = gsSearchKey
        '            Me.txtItmNo.Refresh()
        '            Me.txtColCde.SetFocus()
        '        End If
        '    End If
        'End If
        gsSearchKey = ""
        If Me.txtItmNo.Text <> "" Then
            Dim frm_SYM00022 As New SYM00022(Me.txtItmNo.Text)
            frm_SYM00022.MdiParent = Me.MdiParent
            If domapping_value = 1 Then
                frm_SYM00022.Show()
                AddHandler frm_SYM00022.returnSelectedRecords, AddressOf returnSelectedRecordsHandler

            End If
        End If
    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub

    Private Sub cboCoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.Click
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub DefinedKey(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)


        If (e.KeyCode = 114) And (mmdClear.Enabled = True) Then
            Call mmdClear_Click(sender, e)     'Hot Key for Clear (F3)
        End If

    End Sub


    Private Sub SAM00002_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode >= 112 And e.KeyCode <= 123 Then
            Call DefinedKey(sender, e)
        End If
    End Sub

    Private Sub cboCoCde_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.Enter
        HighlightText(txtColCde)
    End Sub

    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtCusNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusNo.Enter
        HighlightText(txtCusNo)
    End Sub

    Private Sub txtCusNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call mmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtItmNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItmNo.Enter
        HighlightText(txtItmNo)
    End Sub

    Private Sub txtUpdDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpdDat.Enter
        HighlightText(txtUpdDat)
    End Sub

    Private Sub txtUpdDat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUpdDat.KeyPress
        If Not e.KeyChar.Equals(Chr(8)) Then
            If Len(txtUpdDat.Text) = 2 Then
                txtUpdDat.Text = txtUpdDat.Text + "/"
                txtUpdDat.SelectionStart = 3
            ElseIf Len(txtUpdDat.Text) = 5 Then
                txtUpdDat.Text = txtUpdDat.Text + "/"
                txtUpdDat.SelectionStart = 6
            End If
        End If

        If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If


        'Dim KeyAscii As Long = Asc(e.KeyChar)
        'If (InStr("0123456789", Chr(KeyAscii)) = 0) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'ElseIf (Len(txtUpdDat.Text) + 1 > 10) And (KeyAscii > 31 Or KeyAscii < 0) Then
        '    KeyAscii = 0
        'End If
    End Sub

    Private Sub txtUpdDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpdDat.Leave
        If txtUpdDat.Text <> "" Then
            If CheckDate(txtUpdDat.Text) = False Then
                MsgBox("Data format invalid!") 'msg("M00044")
                txtUpdDat.Focus()
                Exit Sub
            End If

            If Mid(txtUpdDat.Text, 3, 1) <> "/" And Mid(txtUpdDat.Text, 6, 1) <> "/" Then
                MsgBox("Data format invalid!") 'msg("M00044")
                txtUpdDat.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged


        If Me.TabPageMain.SelectedIndex = 0 Then
            grdSum.Focus()
        ElseIf Me.TabPageMain.SelectedIndex = 1 Then
            grdDtl.Focus()
            grdDtl_ColumnHeaderMouseClick(Nothing, Nothing)
        End If

    End Sub

    Private Sub grdDtl_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDtl.ColumnHeaderMouseClick
        grdDtl.Focus()
    End Sub

    Private Sub SAM00002_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmNo.Name
        frmComSearch.callFmString = txtItmNo.Text

        frmComSearch.show_SAM00002(Me)
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    grdSum.Columns(4).DisplayIndex = 5
    'End Sub

    Private Sub checkraido()
        If rdbitmno.Checked = True Then
            txtItmNo.Enabled = True
            txtVendor.Enabled = False
            txtVenItmNo.Enabled = False
            txtVendor.Text = ""
            txtVenItmNo.Text = ""
        Else
            txtItmNo.Enabled = False
            txtItmNo.Text = ""
            txtVendor.Enabled = True
            txtVenItmNo.Enabled = True
        End If


    End Sub

    Private Sub rdbitmno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbitmno.CheckedChanged

    End Sub

    Private Sub rdbitmno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbitmno.Click
        checkraido()
    End Sub

    Private Sub rdbvenitm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbvenitm.CheckedChanged

    End Sub

    Private Sub rdbvenitm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbvenitm.Click
        checkraido()
    End Sub

    Private Sub cmd_S_ItmNo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo2.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtVenItmNo.Name
        frmComSearch.callFmString = txtVenItmNo.Text

        frmComSearch.show_SAM00002(Me)
    End Sub




    Private Sub mmdFindClick()
        If Trim(txtCusNo.Text) = "" Then
            MsgBox("Please input Primary Customer No.")
            txtCusNo.Focus()
            Exit Sub
        End If

        If txtUpdDat.Text <> "" Then
            If CheckDate(txtUpdDat.Text) = False Then
                MsgBox("Data format invalid!") 'msg("M00044")
                txtUpdDat.Focus()
                Exit Sub
            End If

            If Mid(txtUpdDat.Text, 3, 1) <> "/" And Mid(txtUpdDat.Text, 6, 1) <> "/" Then
                MsgBox("Data format invalid!") 'msg("M00044")
                txtUpdDat.Focus()
                Exit Sub
            End If
        End If

        txtCusNo.Text = UCase(txtCusNo.Text)
        txtItmNo.Text = UCase(txtItmNo.Text)
        txtColCde.Text = UCase(txtColCde.Text)

        If rdbitmno.Checked = True Then


            gspStr = "sp_select_SAORDDTL_2 '" & gsCompany & "','" & txtCusNo.Text & "','" & txtItmNo.Text & "','" & txtColCde.Text & "','" & txtUpdDat.Text & "','" & gsUsrID & "','" & gsFlgCst & "','" & gsFlgCstExt & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00002 cmdFind_Click sp_select_SAORDDTL_2: " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If rs_SAORDDTL.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found!") 'msg("M00071")
                Else
                    If gsSalTem <> rs_SAORDDTL.Tables("RESULT").Rows(0).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("You have no Right access this document.") 'msg ("M00371")
                        Exit Sub
                    End If


                    Me.Cursor = Windows.Forms.Cursors.Default
                End If
            End If

            gspStr = "sp_select_SAORDSUM_2 '" & gsCompany & "','" & txtCusNo.Text & "','" & txtItmNo.Text & "','" & txtColCde.Text & "','" & txtUpdDat.Text & "','" & gsUsrID & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00002 cmdFind_Click sp_select_SAORDSUM_2: " & rtnStr)
            Else
                If rs_SAORDSUM.Tables("RESULT").Rows.Count > 0 Then
                    Call Display()
                    Call setStatus("Updating")
                    Me.StatusBar.Items("lblRight").Text = Format(rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_credat"), "MM/dd/yyyy") & " " & Format(rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_upddat"), "MM/dd/yyyy") & _
                                      " " & rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_updusr")
                End If
            End If


        Else

            gspStr = "sp_select_SAORDDTL_2_VN '" & gsCompany & "','" & txtCusNo.Text & "','" & txtVenItmNo.Text & "','" & txtColCde.Text & "','" & txtUpdDat.Text & "','" & gsUsrID & "','" & gsFlgCst & "','" & gsFlgCstExt & "','" & Trim(txtVendor.Text) & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDDTL, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00002 cmdFind_Click sp_select_SAORDDTL_2_VN: " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If rs_SAORDDTL.Tables("RESULT").Rows.Count = 0 Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("No Record Found!") 'msg("M00071")
                Else
                    If gsSalTem <> rs_SAORDDTL.Tables("RESULT").Rows(0).Item("ysr_saltem") And gsSalTem <> "" And gsSalTem <> "S" Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("You have no Right access this document.") 'msg ("M00371")
                        Exit Sub
                    End If


                    Me.Cursor = Windows.Forms.Cursors.Default
                End If
            End If

            gspStr = "sp_select_SAORDSUM_2_VN '" & gsCompany & "','" & txtCusNo.Text & "','" & txtVenItmNo.Text & "','" & txtColCde.Text & "','" & txtUpdDat.Text & "','" & gsUsrID & "','" & Trim(txtVendor.Text) & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_SAORDSUM, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SAM00002 cmdFind_Click sp_select_SAORDSUM_2_VN: " & rtnStr)
            Else
                If rs_SAORDSUM.Tables("RESULT").Rows.Count > 0 Then
                    Call Display()
                    Call setStatus("Updating")
                    Me.StatusBar.Items("lblRight").Text = Format(rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_credat"), "MM/dd/yyyy") & " " & Format(rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_upddat"), "MM/dd/yyyy") & _
                                      " " & rs_SAORDDTL.Tables("RESULT").Rows(0).Item("sad_updusr")
                End If
            End If




        End If

    End Sub
    Public Sub callBySAM01(ByVal cus1no As String, ByVal itmno As String, _
                           ByVal ComparyCode As String, ByVal vnItm As Boolean, ByVal Vendor As String)

        vnItem = vnItm
        If vnItm = True Then
            txtVenItmNo.Text = itmno
        Else
            txtItmNo.Text = itmno
            txtVendor.Text = Vendor
        End If
        Temp_CusNo = cus1no
        CoCde = ComparyCode
        'Hints: In .net, Shown event is called after Load event
        AddHandler Me.Shown, AddressOf callBySAM01AfterLoading
        Me.ShowDialog()
    End Sub

    Private Sub callBySAM01AfterLoading()
        cboCoCde.SelectedItem = CoCde
        If vnItem = True Then
            rdbvenitm.Checked = True
        End If
        mmdFindClick()
        Call SetInputBoxesStatus("DisableAll")
        mmdExit.Enabled = True
        rdbitmno.Enabled = False
        rdbvenitm.Enabled = False
        RemoveHandler Me.Shown, AddressOf callBySAM01AfterLoading
    End Sub
End Class

