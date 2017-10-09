Imports System.IO

Public Class frmAttchUpload
    Dim rs_dst As DataSet
    Dim rs_src As DataSet

    Dim dgDst_del As Integer
    Dim dgDst_filnam As Integer
    Dim dgSrc_del As Integer
    Dim dgSrc_filnam As Integer

    Dim strModule As String = ""
    Dim strCoCde As String = ""
    Dim strCurDir As String = ""
    Dim strDocNo As String = ""
    Dim strDstDir As String = ""

    Private Sub frmAttchUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strCurDir = Directory.GetCurrentDirectory()

        Select Case strModule
            Case "PKG"
                txtModule.Text = "PACKAGING"
                Me.Text = "Attachment File Upload - Packaging"
            Case "CLM"
                txtModule.Text = "CLAIMS"
                Me.Text = "Attachment File Upload - Claims"
            Case Else
                txtModule.Text = ""
                Me.Text = "Attachment File Upload"
        End Select
        txtCoCde.Text = strCoCde
        txtDocNo.Text = strDocNo

        If txtModule.Text = "" Then
            MsgBox("Incorrect Module Designation", MsgBoxStyle.Exclamation, Me.Text & " - Error")
            cmdExit.PerformClick()
            Exit Sub
        End If

        If txtCoCde.Text = "" Then
            MsgBox("Missing Company Code", MsgBoxStyle.Exclamation, Me.Text & " - Error")
            cmdExit.PerformClick()
            Exit Sub
        End If

        If txtDocNo.Text = "" Then
            MsgBox("Missing Document No.", MsgBoxStyle.Exclamation, Me.Text & " - Error")
            cmdExit.PerformClick()
            Exit Sub
        End If


        Dim rs As DataSet
        gspStr = "sp_select_FLDOCATT '" & txtCoCde.Text & "','" & txtDocNo.Text & "','" & strModule & "','" & LCase(gsUsrID) & "'"
        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading " & Me.Name & " #001 sp_select_FLDOCATT : " & rtnStr)
            Close()
        Else
            For i As Integer = 0 To rs.Tables("RESULT").Columns.Count - 1
                rs.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        rs_src = rs.Clone
        rs_dst = rs.Clone

        display_dgSrc()
        display_dgDst()

        getDestDir()
        cmdDestRefresh.PerformClick()

        cmdSrcPreview.Enabled = False
        cmdSrcImport.Enabled = False
        cmdSrcRemove.Enabled = False

        cmdDestPreview.Enabled = False
        cmdDestDelete.Enabled = False
    End Sub

    Public Sub setModule(ByVal str As String)
        strModule = Trim(UCase(str))
    End Sub

    Public Sub setDoc(ByVal cocde As String, ByVal docno As String)
        strCoCde = Trim(UCase(cocde))
        strDocNo = Trim(UCase(docno))
    End Sub

    Private Sub display_dgSrc()
        dgSrc.DataSource = rs_src.Tables("RESULT").DefaultView

        For i As Integer = 0 To dgSrc.Columns.Count - 1
            dgSrc.Columns(i).ReadOnly = True
            Select Case dgSrc.Columns(i).Name
                Case "fda_del"
                    dgSrc_del = i
                    dgSrc.Columns(i).HeaderText = "Rem"
                    dgSrc.Columns(i).Width = 40
                    dgSrc.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "fda_filnam"
                    dgSrc_filnam = i
                    dgSrc.Columns(i).HeaderText = "Filename"
                    dgSrc.Columns(i).Width = 150
                    'Case "fda_filpath"
                    '    dgSrc.Columns(i).HeaderText = "File Path"
                    '    dgSrc.Columns(i).Width = 210
                Case "fda_chkdat"
                    dgSrc.Columns(i).HeaderText = "Modified Date"
                    dgSrc.Columns(i).Width = 100
                Case Else
                    dgSrc.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub display_dgDst()
        dgDst.DataSource = rs_dst.Tables("RESULT").DefaultView

        For i As Integer = 0 To dgDst.Columns.Count - 1
            dgDst.Columns(i).ReadOnly = True
            Select Case dgDst.Columns(i).Name
                Case "fda_del"
                    dgDst_del = i
                    dgDst.Columns(i).HeaderText = "Del"
                    dgDst.Columns(i).Width = 40
                    dgDst.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "fda_filnam"
                    dgDst_filnam = i
                    dgDst.Columns(i).HeaderText = "Filename"
                    dgDst.Columns(i).Width = 150
                    'Case "fda_filpath"
                    '    dgDst.Columns(i).HeaderText = "File Path"
                    '    dgDst.Columns(i).Width = 210
                Case "fda_chkdat"
                    dgDst.Columns(i).HeaderText = "Modified Date"
                    dgDst.Columns(i).Width = 100
                Case Else
                    dgDst.Columns(i).Visible = False
            End Select
        Next
    End Sub

    Private Sub getDestDir()
        Dim S As String
        Try
            Using sr As New StreamReader("path.ini")
                While sr.Peek <> -1
                    S = sr.ReadLine().ToString

                    If S.IndexOf(" = ") > 0 Then
                        Select Case UCase(Split(S, " = ")(0))
                            Case UCase("PKG_DocAttach_PATH")
                                If strModule = "PKG" Then
                                    strDstDir = Trim(Split(S, " = ")(1))
                                End If
                            Case UCase("CLM_DocAttach_PATH")
                                If strModule = "CLM" Then
                                    strDstDir = Trim(Split(S, " = ")(1))
                                End If
                        End Select
                    End If

                End While
            End Using
        Catch ex As Exception
            MsgBox("Unable to determine file path: path.ini", MsgBoxStyle.Exclamation, Me.Text & " - Error")
            Close()
        End Try

        If strDstDir.Length > 0 Then
            If strDstDir.Substring(strDstDir.Length - 1, 1) <> "\" Then
                strDstDir = strDstDir & "\"
            End If

            strDstDir = strDstDir & txtDocNo.Text & "\"
        Else
            MsgBox("Unable to determine destination directory", MsgBoxStyle.Exclamation, Me.Text & " - Error")
            Close()
        End If
    End Sub

    Private Sub txtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdSrcLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSrcLoad.Click
        LoadFileDialog.Title = "Select a File to upload"
        LoadFileDialog.Filter = "All Files|*.*"
        LoadFileDialog.InitialDirectory = "C:\"
        LoadFileDialog.ShowDialog()
    End Sub

    Private Sub cmdSrcPrview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSrcPreview.Click
        If dgSrc.SelectedCells.Count = 0 Then
            MsgBox("No file has been selected for preview", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        For i As Integer = 0 To dgSrc.SelectedCells.Count - 1
            If dgSrc.Columns(dgSrc.SelectedCells(i).ColumnIndex).Name = "fda_filnam" Then
                Try
                    Process.Start(dgSrc.Rows(dgSrc.SelectedCells(i).RowIndex).Cells("fda_filpath").Value)
                Catch ex As Exception
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error has occurred with the following file:" & Environment.NewLine & dgSrc.Rows(dgSrc.SelectedCells(i).RowIndex).Cells("fda_filpath").Value & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Text & " - Error")
                    Exit Sub
                End Try
            End If
        Next
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub LoadFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LoadFileDialog.FileOk
        Dim dr() As DataRow

        Dim strm As System.IO.Stream
        Dim filpath As String
        Dim filnam As String
        Dim chkdat As String
        strm = LoadFileDialog.OpenFile()

        If LoadFileDialog.FileNames.Length > 0 Then
            For i As Integer = 0 To LoadFileDialog.FileNames.Length - 1
                filpath = LoadFileDialog.FileNames(i)
                filnam = Split(filpath, "\")(Split(filpath, "\").Length - 1)
                chkdat = Format(FileDateTime(filpath), "yyyy-MM-dd HH:mm:ss")

                dr = Nothing
                dr = rs_src.Tables("RESULT").Select("fda_filpath = '" & filpath & "'")
                If dr.Length = 0 Then
                    rs_src.Tables("RESULT").Rows.Add()
                    rs_src.Tables("RESULT").Rows(rs_src.Tables("RESULT").Rows.Count - 1)("fda_del") = ""
                    rs_src.Tables("RESULT").Rows(rs_src.Tables("RESULT").Rows.Count - 1)("fda_filnam") = filnam
                    rs_src.Tables("RESULT").Rows(rs_src.Tables("RESULT").Rows.Count - 1)("fda_filpath") = filpath
                    rs_src.Tables("RESULT").Rows(rs_src.Tables("RESULT").Rows.Count - 1)("fda_chkdat") = CDate(chkdat)
                ElseIf dr.Length = 1 Then
                    If dr(0)("fda_del") = "Y" Then
                        dr(0)("fda_del") = ""
                    End If
                End If

                dr = rs_src.Tables("RESULT").Select("fda_del = 'Y'")
                If dr.Length = 0 Then
                    cmdSrcRemove.Enabled = False
                Else
                    cmdSrcRemove.Enabled = True
                End If

                dr = Nothing
                dr = rs_src.Tables("RESULT").Select("fda_del = ''")
                If dr.Length = 0 Then
                    cmdSrcImport.Enabled = False
                Else
                    cmdSrcImport.Enabled = True
                End If
            Next

            dgSrc.ClearSelection()
        End If

        Directory.SetCurrentDirectory(strCurDir)
    End Sub

    Private Sub dgSrc_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSrc.CellClick
        Dim dr() As DataRow

        If e.RowIndex >= 0 Then
            If e.ColumnIndex >= 0 Then
                If e.ColumnIndex = dgSrc_del Then
                    If dgSrc.Rows(e.RowIndex).Cells("fda_del").Value = "" Then
                        dgSrc.Rows(e.RowIndex).Cells("fda_del").Value = "Y"
                    Else
                        dgSrc.Rows(e.RowIndex).Cells("fda_del").Value = ""
                    End If
                    rs_src.AcceptChanges()

                    dr = rs_src.Tables("RESULT").Select("fda_del = 'Y'")
                    If dr.Length = 0 Then
                        cmdSrcRemove.Enabled = False
                    Else
                        cmdSrcRemove.Enabled = True
                    End If

                    dr = Nothing
                    dr = rs_src.Tables("RESULT").Select("fda_del = ''")
                    If dr.Length = 0 Then
                        cmdSrcImport.Enabled = False
                    Else
                        cmdSrcImport.Enabled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdSrcImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSrcImport.Click
        Dim isImport As Boolean = False
        Dim isCopy As Boolean = False

        Dim dr_src() As DataRow
        Dim dr_dst() As DataRow

        Dim dstFile As FileInfo
        Dim srcFile As FileInfo
        Dim dstSize As Double
        Dim srcSize As Double
        Dim dstChkDat As String
        Dim fileName As String

        dr_src = rs_src.Tables("RESULT").Select("fda_del = ''")
        If dr_src.Length = 0 Then
            MsgBox("No file has been selected for import", MsgBoxStyle.Information, Me.Text & " - Import")
            Return
        Else
            If dr_src.Length = 1 Then
                If MsgBox("Are you sure you want to import '" & dr_src(0)("fda_filnam") & "'?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Import") = MsgBoxResult.Yes Then
                    isImport = True
                End If
            Else
                If MsgBox("Are you sure you want to import these " & dr_src.Length & " items?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Import") = MsgBoxResult.Yes Then
                    isImport = True
                End If
            End If

            If isImport = True Then
                ' Check Destination Directory for existence
                If Directory.Exists(strDstDir) = False Then
                    Directory.CreateDirectory(strDstDir)
                End If

                Try
                    For i As Integer = 0 To dr_src.Length - 1
                        isCopy = True
                        fileName = dr_src(i)("fda_filnam")
                        srcFile = Nothing
                        srcFile = New FileInfo(dr_src(i)("fda_filpath"))
                        srcSize = Math.Round(srcFile.Length / 4, 2)

                        ' Check File in Destination Directory for existence
                        If File.Exists(strDstDir & fileName) = True Then
                            isCopy = False
                            dstFile = Nothing
                            dstFile = New FileInfo(strDstDir & fileName)
                            dstSize = Math.Round(dstFile.Length / 4, 2)
                            dstChkDat = Format(FileDateTime(strDstDir & fileName), "yyyy-MM-dd HH:mm:ss")
                            If MsgBox("The document already contains a file named" & Environment.NewLine & "'" & fileName & "'." & Environment.NewLine & Environment.NewLine & _
                                   "Would you like to replace the existing file " & Environment.NewLine & srcSize & " KB " & Environment.NewLine & _
                                   "Last Modified: " & Format(dr_src(i)("fda_chkdat"), "yyyy-MM-dd HH:mm:ss") & Environment.NewLine & Environment.NewLine & "with this one?" & _
                                   Environment.NewLine & dstSize & " KB " & Environment.NewLine & "Last Modified: " & dstChkDat, MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Import") = MsgBoxResult.Yes Then
                                isCopy = True
                            End If
                        End If

                        If isCopy = True Then
                            ' Copy to Desintation Directory
                            FileCopy(dr_src(i)("fda_filpath"), strDstDir & fileName)

                            ' Update File Information to Destination Datagrid
                            dr_dst = rs_dst.Tables("RESULT").Select("fda_filnam = '" & dr_src(i)("fda_filnam") & "'")
                            If dr_dst.Length = 0 Then
                                gspStr = "sp_insert_FLDOCATT '" & txtCoCde.Text & "','" & txtDocNo.Text & "','" & _
                                         strModule & "','" & Replace(strDstDir & fileName, "'", "''") & "','" & _
                                         Format(dr_src(i)("fda_chkdat"), "yyyy-MM-dd HH:mm:ss") & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on deleting " & Me.Name & " #002 sp_insert_FLDOCATT : " & rtnStr)
                                    Return
                                End If

                                rs_dst.Tables("RESULT").Rows.Add()
                                rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_del") = ""
                                rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_filnam") = dr_src(i)("fda_filnam")
                                rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_filpath") = strDstDir & fileName
                                rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_chkdat") = dr_src(i)("fda_chkdat")
                            Else
                                gspStr = "sp_update_FLDOCATT '" & txtCoCde.Text & "','" & txtDocNo.Text & "','" & _
                                         strModule & "','" & Replace(strDstDir & fileName, "'", "''") & "','" & _
                                         Format(dr_src(i)("fda_chkdat"), "yyyy-MM-dd HH:mm:ss") & "','" & LCase(gsUsrID) & "'"
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                Me.Cursor = Windows.Forms.Cursors.Default
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on deleting " & Me.Name & " #003 sp_update_FLDOCATT : " & rtnStr)
                                    Return
                                End If

                                dr_dst(0)("fda_del") = ""
                                dr_dst(0)("fda_filnam") = dr_src(i)("fda_filnam")
                                dr_dst(0)("fda_filpath") = strDstDir & fileName
                                dr_dst(0)("fda_chkdat") = dr_src(i)("fda_chkdat")
                            End If
                            rs_dst.AcceptChanges()
                            dgDst.ClearSelection()

                            ' Remove FIle Information from Source Datagrid
                            dr_src(i).Delete()
                            rs_src.AcceptChanges()
                            dgSrc.ClearSelection()

                        End If
                    Next
                Catch ex As Exception
                    MsgBox("Error has occurred with the following file:" & Environment.NewLine & fileName & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Text & " - Error")
                    Exit Sub
                End Try

                dr_src = Nothing
                dr_src = rs_src.Tables("RESULT").Select("fda_del = ''")
                If dr_src.Length = 0 Then
                    cmdSrcImport.Enabled = False
                Else
                    cmdSrcImport.Enabled = True
                End If

                dr_dst = Nothing
                dr_dst = rs_dst.Tables("RESULT").Select("fda_del = 'Y'")
                If dr_src.Length = 0 Then
                    cmdDestDelete.Enabled = False
                Else
                    cmdDestDelete.Enabled = True
                End If

                rs_src.Clear()
                cmdDestRefresh.PerformClick()

                dgDst.ClearSelection()
                dgSrc.ClearSelection()
            End If
        End If
    End Sub

    Private Sub cmdSrcRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSrcRemove.Click
        Dim isRemove As Boolean = False

        Dim dr() As DataRow = rs_src.Tables("RESULT").Select("fda_del = 'Y'")
        If dr.Length = 0 Then
            MsgBox("No file has been selected for removal", MsgBoxStyle.Information, Me.Text & " - Remove")
            Return
        Else
            If dr.Length = 1 Then
                If MsgBox("Are you sure you want to remove '" & dr(0)("fda_filnam") & "'?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Remove") = MsgBoxResult.Yes Then
                    isRemove = True
                End If
            Else
                If MsgBox("Are you sure you want to remove these " & dr.Length & " items?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Remove") = MsgBoxResult.Yes Then
                    isRemove = True
                End If
            End If

            If isRemove = True Then
                For i As Integer = dr.Length - 1 To 0 Step -1
                    dr(i).Delete()
                Next
                rs_src.AcceptChanges()
                cmdSrcRemove.Enabled = False
                dgSrc.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dgDst_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDst.CellClick
        Dim dr() As DataRow

        If e.RowIndex >= 0 Then
            If e.ColumnIndex >= 0 Then
                If e.ColumnIndex = dgSrc_del Then
                    If dgDst.Rows(e.RowIndex).Cells("fda_del").Value = "" Then
                        dgDst.Rows(e.RowIndex).Cells("fda_del").Value = "Y"
                    Else
                        dgDst.Rows(e.RowIndex).Cells("fda_del").Value = ""
                    End If
                    rs_dst.AcceptChanges()

                    dr = rs_dst.Tables("RESULT").Select("fda_del = 'Y'")
                    If dr.Length = 0 Then
                        cmdDestDelete.Enabled = False
                    Else
                        cmdDestDelete.Enabled = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdDestRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDestRefresh.Click
        Dim file As FileInfo
        Dim filenames As String()

        rs_dst.Clear()

        If Directory.Exists(strDstDir) = False Then
            Return
        Else
            filenames = Directory.GetFiles(strDstDir)
            If filenames.Length > 0 Then
                For i As Integer = 0 To filenames.Length - 1
                    file = Nothing
                    file = New FileInfo(filenames(i))

                    rs_dst.Tables("RESULT").Rows.Add()
                    rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_del") = ""
                    rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_filnam") = file.Name
                    rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_filpath") = file.FullName
                    rs_dst.Tables("RESULT").Rows(rs_dst.Tables("RESULT").Rows.Count - 1)("fda_chkdat") = Format(FileDateTime(filenames(i)), "yyyy-MM-dd HH:mm:ss")
                Next
            End If
        End If

        dgDst.ClearSelection()
    End Sub

    Private Sub cmdDestPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDestPreview.Click
        If dgDst.SelectedCells.Count = 0 Then
            MsgBox("No file has been selected for preview", MsgBoxStyle.Information, Me.Name)
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        For i As Integer = 0 To dgDst.SelectedCells.Count - 1
            If dgDst.Columns(dgDst.SelectedCells(i).ColumnIndex).Name = "fda_filnam" Then
                Try
                    Process.Start(dgDst.Rows(dgDst.SelectedCells(i).RowIndex).Cells("fda_filpath").Value)
                Catch ex As Exception
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error has occurred with the following file:" & Environment.NewLine & dgDst.Rows(dgDst.SelectedCells(i).RowIndex).Cells("fda_filpath").Value & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Text & " - Error")
                    Exit Sub
                End Try
            End If
        Next
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdDestDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDestDelete.Click
        Dim isDelete As Boolean = False

        Dim dr() As DataRow = rs_dst.Tables("RESULT").Select("fda_del = 'Y'")
        If dr.Length = 0 Then
            MsgBox("No file has been selected for deletion", MsgBoxStyle.Information, Me.Text & " - Delete")
            Return
        Else
            If dr.Length = 1 Then
                If MsgBox("Are you sure you want to delete '" & dr(0)("fda_filnam") & "'?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Delete") = MsgBoxResult.Yes Then
                    isDelete = True
                End If
            Else
                If MsgBox("Are you sure you want to delete these " & dr.Length & " items?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text & " - Delete") = MsgBoxResult.Yes Then
                    isDelete = True
                End If
            End If

            If isDelete = True Then
                For i As Integer = dr.Length - 1 To 0 Step -1
                    Try
                        File.Delete(dr(i)("fda_filpath"))
                        gspStr = "sp_physical_delete_FLDOCATT '" & txtCoCde.Text & "','" & txtDocNo.Text & "','" & _
                                 strModule & "','" & Replace(dr(i)("fda_filpath"), "'", "''") & "','" & LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on deleting " & Me.Name & " #004 sp_physical_delete_FLDOCATT : " & rtnStr)
                            Return
                        End If
                    Catch ex As Exception
                        MsgBox("Error has occurred with the following file:" & Environment.NewLine & dgSrc.Rows(dgSrc.SelectedCells(i).RowIndex).Cells("fda_filpath").Value & Environment.NewLine & ex.Message, MsgBoxStyle.Critical, Me.Text & " - Delete")
                        Exit Sub
                    End Try
                    dr(i).Delete()
                Next
                rs_src.AcceptChanges()
                cmdDestDelete.Enabled = False
                dgDst.ClearSelection()
            End If
        End If
    End Sub

    Private Sub dgSrc_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSrc.SelectionChanged
        Dim isPreview As Boolean = False

        For i As Integer = 0 To dgSrc.SelectedCells.Count - 1
            If dgSrc.Columns(dgSrc.SelectedCells(i).ColumnIndex).Name = "fda_filnam" Then
                isPreview = True
            End If
        Next
        cmdSrcPreview.Enabled = isPreview
    End Sub

    Private Sub dgDst_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgDst.SelectionChanged
        Dim isPreview As Boolean = False

        For i As Integer = 0 To dgDst.SelectedCells.Count - 1
            If dgDst.Columns(dgDst.SelectedCells(i).ColumnIndex).Name = "fda_filnam" Then
                isPreview = True
            End If
        Next
        cmdDestPreview.Enabled = isPreview
    End Sub

    Private Sub dgSrc_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSrc.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex >= 0 Then
                If e.ColumnIndex = dgSrc_filnam Then
                    cmdSrcPreview.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub dgDst_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDst.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex >= 0 Then
                If e.ColumnIndex = dgDst_filnam Then
                    cmdDestPreview.PerformClick()
                End If
            End If
        End If
    End Sub
End Class