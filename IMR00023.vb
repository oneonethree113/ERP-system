Public Class IMR00023
    Dim FilePattern As String = "*.xls"
    Dim filSourcePath As String = ""
    Dim myExcel As New Microsoft.Office.Interop.Excel.Application
    Dim rs_EXCEL As DataSet

    Private Sub IMR00023_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        drvSource.Items.AddRange(System.IO.Directory.GetLogicalDrives)

        Dim sDrives As String() = System.Environment.GetLogicalDrives()

        drvSource.Items.Clear()

        Dim sDrive As String

        For Each sDrive In sDrives
            drvSource.Items.Add(sDrive)
        Next

        Dim i As Integer

        For Each sDrive In drvSource.Items
            If sDrive.ToString.ToUpper.Equals("C:\") Then
                drvSource.SelectedIndex = i
            End If
            i += 1
        Next

        If drvSource.SelectedIndex = -1 Then
            Try
                drvSource.SelectedIndex = 1
            Catch
                MessageBox.Show("No fixed disks found!", "Drive Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        dirSource.Nodes(0).Expand()
        dirSource.SelectedNode = dirSource.Nodes(0)

        txtProcess.Text = ""
        txtProcess.Refresh()


    End Sub

    Private Sub drvSource_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drvSource.SelectedIndexChanged
        Cursor.Current = Cursors.WaitCursor
        dirSource.Nodes.Clear()
        dirSource.Nodes.Add(drvSource.Text)
        AddDirectories(dirSource.Nodes(0))
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub AddDirectories(ByVal Node As TreeNode)
        Try
            'Construct a DirectoryInfo object of Node.FullPath
            Dim Dir As New System.IO.DirectoryInfo(Node.FullPath)

            'Construct a DirectoryInfo object array of all the folders inside Node.FullPath.

            Dim Folders As System.IO.DirectoryInfo

            For Each Folders In Dir.GetDirectories
                ' Add node for the directory.
                Dim NewNode As New TreeNode(Folders.Name)
                Node.Nodes.Add(NewNode)
                NewNode.Nodes.Add("*")
            Next
        Catch
            'This error trap prevents a crash when attempting to access restricted folders.
        End Try
    End Sub

    Private Sub dirSource_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles dirSource.AfterSelect

    End Sub

    Private Sub dirSource_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles dirSource.BeforeExpand
        If e.Node.Nodes(0).Text = "*" Then
            ' Disable redraw.
            dirSource.BeginUpdate()

            e.Node.Nodes.Clear()
            AddDirectories(e.Node)

            ' Enable redraw.
            dirSource.EndUpdate()
        End If

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(e.Node.FullPath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        On Error GoTo FILE_ACCESS_ERROR

        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        filSourcePath = Dir.FullName

        drvSource.Text = filSourcePath


        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        Exit Sub

FILE_ACCESS_ERROR:
        MsgBox("Directory Access Denied", MsgBoxStyle.Critical, "Directory Access Error")
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        If (dirSource.SelectedNode Is Nothing) Then
            MsgBox("Directory Not Selected")
            Exit Sub
        End If
        '*** Refresh the source
        filSourcePath = Replace(dirSource.SelectedNode.FullPath, "\\", "\")

        'Construct a DirectoryInfo object of the selected Node.
        Dim Dir As New System.IO.DirectoryInfo(filSourcePath)

        'Construct a FileInfo object array of all the files inside e.Node.FullPath that match FilePattern.
        Dim Files As System.IO.FileInfo() = Dir.GetFiles(FilePattern)

        'Create a FileInfo object (File) for the For-Each loop and clear the lstFiles listbox before filling it.
        Dim File As System.IO.FileInfo

        filSource.Items.Clear()

        For Each File In Files
            'Add the file name to the lstFiles listbox
            filSource.Items.Add(File.Name)
        Next

        filSource.Refresh()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")



        Dim S As String
        Dim rs As ADOR.Recordset
        Dim rs_tmp As ADOR.Recordset

        Dim intCount As Integer
        Dim intRow As Integer
        Dim xlsPath As String
        Dim strFileDate As String
        Dim strField1 As String
        Dim strField2 As String
        Dim strField3 As String
        Dim strField4 As String

        Dim strFileCopy As String
        Dim intCopy As Integer

        Dim inValidFileName As String

        intRow = 6
        txtProcess.Text = ""

        If filSource.Items.Count = 0 Then
            MsgBox("No Excel file in the directory!")
            Exit Sub
        End If


        Dim FileToCopy As String = filSourcePath + "\" + filSource.Text 'C:\book.xls

        Me.Cursor = Cursors.WaitCursor

        On Error GoTo Error_Hld
        If Dir(filSourcePath + "\Uploaded", vbDirectory) = "" Then
            MkDir(filSourcePath + "\Uploaded")
        End If
        Err.Clear()

        strField1 = "Item"
        Dim id As Integer
        id = 1
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Value = 1
        Do While intCount < filSource.Items.Count
            setErrMsg("Uploading - " & filSourcePath & IIf(Strings.Right(filSourcePath, 1) = "\", "", "\") & filSource.Items(intCount) & ", please wait...")
            xlsPath = filSourcePath & IIf(Strings.Right(filSourcePath, 1) = "\", "", "\") & filSource.Items(intCount)
            strFileDate = Format(FileDateTime(xlsPath), "MM/dd/yyyy HH:MM:SS")
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Dim rs_data As DataSet
            rs_data = createRS()  'A recordset to store the excel data
            With myExcel
                On Error GoTo Error_Hld_Excel



                .Workbooks.Open(xlsPath)       'Open the excel file
                .Sheets(1).Select()               'Select the first sheet


                intRow = 0

                

                Do While Trim(.Range("A" & intRow + 1).Text.ToString) <> ""
                    If intRow > 65535 Then GoTo Error_Hld
                    rs_data.Tables("RESULT").Rows.Add()

                    rs_data.Tables("RESULT").Rows(intRow).Item(strField1) = getDBValues(.Range("A" & intRow + 1).Text.ToString, "Varchar", 40)
                    rs_data.Tables("RESULT").Rows(intRow).Item("ID") = Str(id)
                    'rs_data.Update()
                    intRow = intRow + 1
                    Me.ProgressBar1.Value = (Me.ProgressBar1.Value + 1) / 100
                Loop

            End With
            Err.Clear()

            On Error GoTo Error_Hld_RS

            If saveExcel(rs_data, xlsPath, strFileDate) = True Then
                strFileCopy = filSourcePath & IIf(Strings.Right(filSourcePath, 1) = "\", "Uploaded\", "\Uploaded\") & LTrim(Strings.Left(filSource.Items(intCount), Len(filSource.Items(intCount)) - 4)) & ".old"
                'strFileCopy = filSource.path & IIf(right(filSource.path, 1) = "\", "", "\") & LTrim(left(filSource.List(intCount), Len(filSource.List(intCount)) - 4)) & ".old"
                inValidFileName = ""
            Else
                inValidFileName = "save failure"
            End If

            rs_data = Nothing
            'myExcel.Workbooks.Close

            If inValidFileName <> "" Then
                strFileCopy = filSourcePath & IIf(Strings.Right(filSourcePath, 1) = "\", "", "\") & LTrim(Strings.Left(filSource.Items(intCount), Len(filSource.Items(intCount)) - 4)) & ".err"
                If Dir(strFileCopy) = LTrim(Strings.Left(filSource.Items(intCount), Len(filSource.Items(intCount)) - 4)) & ".err" Then
                    Kill(strFileCopy)
                    '  Name xlsPath As strFileCopy  ''Rename the Excel File to "XXX.old" format
                    Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
                    Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet
                    xlWs = myExcel.Workbooks(1).Sheets(1)
                    xlWs = Nothing
                    myExcel.Workbooks(1).Save()
                    myExcel.Workbooks(1).Close()
                    System.IO.File.Move(xlsPath, strFileCopy)

                Else
                    'Debug.Print vbCrLf & xlsPath & vbCrLf & strFileCopy
                    ' Name xlsPath As strFileCopy  ''Rename the Excel File to "XXX.old" format
                    '  Name xlsPath As strFileCopy  ''Rename the Excel File to "XXX.old" format
                    Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
                    Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet
                    xlWs = myExcel.Workbooks(1).Sheets(1)
                    xlWs = Nothing
                    myExcel.Workbooks(1).Save()
                    myExcel.Workbooks(1).Close()
                    System.IO.File.Move(xlsPath, strFileCopy)
                End If
            End If
            intCount = intCount + 1
        Loop

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        myExcel.Workbooks.Close()
        myExcel.Quit()
        myExcel = Nothing
        myExcel = New Microsoft.Office.Interop.Excel.Application

        Me.Cursor = Cursors.Default
        MsgBox("Excel File process Finished!")
        Exit Sub

        '--------------------------------------------------------------------
Error_Hld_Excel:
        myExcel.Workbooks.Close()
        myExcel.Quit()
        GoTo Error_Hld
Error_Hld_RS:

Error_Hld:
        MsgBox(Err.Description)
        'If strField <> "" Then
        '    MsgBox(Err.Description & vbCrLf & "Row : " & Str(intRow) & " Fields : " & strField)
        'Else
        '    MsgBox(Err.Description)
        'End If
        'myExcel.Workbooks.Close

Exit_func:
        '--------------------------------------------------------------------
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub setErrMsg(ByVal strMsg As String)
        If Trim(txtProcess.Text) = "" Then
            txtProcess.Text = Format(Now(), "MM-dd-yyyy HH:MM:SS") & " " & strMsg
        Else
            txtProcess.Text = txtProcess.Text & vbCrLf & Format(Now(), "MM-dd-yyyy HH:MM:SS") & " " & strMsg
        End If
        txtProcess.Refresh()
    End Sub
    Private Function createRS() As DataSet

        Dim rsDestination As New DataSet
        rsDestination.Tables.Add("RESULT")
        Dim col1 As DataColumn = New DataColumn("ID")
        col1.DataType = System.Type.GetType("System.String")
        col1.MaxLength = 10
        Dim col2 As DataColumn = New DataColumn("Item")
        col2.DataType = System.Type.GetType("System.String")
        col2.MaxLength = 40
        Dim col3 As DataColumn = New DataColumn("pth")
        col3.DataType = System.Type.GetType("System.String")
        col3.MaxLength = 800
        rsDestination.Tables("RESULT").Columns.Add(col1)
        rsDestination.Tables("RESULT").Columns.Add(col2)
        rsDestination.Tables("RESULT").Columns.Add(col3)

        For i As Integer = 0 To rsDestination.Tables("RESULT").Columns.Count - 1
            rsDestination.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        'rsDestination.Tables("RESULT").Columns.Add("ID", , 10, 0)
        'rsDestination.Fields.Append("Item", adVarChar, 40, 0)
        'rsDestination.Fields.Append("pth", adVarChar, 800, 0)

        'rsDestination.Open, , adOpenStatic, adLockOptimistic


        createRS = rsDestination

    End Function '

    Private Function saveExcel(ByRef rs_data As DataSet, ByVal xlsPath As String, ByVal strFileDate As String) As Boolean

      
        ' Dim rs() As ADOR.Recordset
        Dim S As String
        Dim i As Integer
        Dim strPath As String

        On Error GoTo err_handle

        saveExcel = True

        If rs_data Is Nothing Then Exit Function
        If rs_data.Tables("RESULT").Rows.Count <= 0 Then Exit Function



        'Do While Not rs_data.EOF
        For x As Integer = 0 To rs_data.Tables("RESULT").Rows.Count - 1
            gspStr = "sp_select_IMR00023 '"
            For i = 0 To rs_data.Tables("RESULT").Columns.Count - 2 'rs_data.Fields.Count - 2
                gspStr = gspStr & "','" & rs_data.Tables("RESULT").Rows(x).Item(i)
            Next i
            gspStr = gspStr & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)
            If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                MsgBox("Error on loading saveExcel sp_select_IMR00023 :" & rtnStr)
                setErrMsg("Error when process data") '& rs(0)(0))
                saveExcel = False
                Exit Function
            End If

            If rs.Tables("RESULT").Rows.Count > 0 Then
                rs_data.Tables("RESULT").Rows(x).Item("pth") = rs.Tables("RESULT").Rows(0).Item("pth")
                '  rs_data.Update()
            End If
            Me.ProgressBar1.Value = (Me.ProgressBar1.Value + 1) / 100
            'rs_data.MoveNext()
        Next
        'Loop

        '    Set Me.DataGrid1.DataSource = rs_data

        If rs_data.Tables("RESULT").Rows.Count > 0 Then
            rs_EXCEL = rs_data
            Call ExportExcel()
        End If

        Exit Function

err_handle:
        MsgBox(Err.Description)
        Err.Clear()
        Exit Function

    End Function
    Private Function ExportExcel()

        Me.Cursor = Cursors.WaitCursor ' Change mouse pointer to hourglass.

        '    Dim myExcel As Excel.Application
        Dim xlWb As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWs As Microsoft.Office.Interop.Excel.Worksheet

        On Error GoTo err_handle_ee
        '    Set myExcel = CreateObject("Excel.Application")

        '    Set xlWb = myExcel.Workbooks(1)
        '    Set xlWs = xlWb.Worksheets(1)

        '    Set xlWb = myExcel.Workbooks(1)
        xlWs = myExcel.Workbooks(1).Sheets(1)

        myExcel.Visible = True

        myExcel.UserControl = True

        Dim col As Integer
        Dim row As Integer
        col = 2

        With xlWs
            Dim sResultString As String
            'rs_EXCEL.MoveFirst()

            'For row = 1 To rs_EXCEL.recordCount
            For row = 0 To rs_EXCEL.Tables("RESULT").Rows.Count - 1
                '           .Cells(row, 1).RowHeight = 100
                '            .Range(.Cells(row, 1), .Cells(row, col)).HorizontalAlignment = 2
                .Range(.Cells(row + 1, 1), .Cells(row + 1, col)).VerticalAlignment = 2

                .Range(.Cells(row + 1, col), .Cells(row + 1, col)).RowHeight = 100
                .Range(.Cells(row + 1, col), .Cells(row + 1, col)).ColumnWidth = 20
                sResultString = rs_EXCEL.Tables("RESULT").Rows(row).Item("pth").ToString
                If sResultString <> "" Then
                    Call InsertPictureInRange(sResultString, xlWs.Range(Chr(Asc("A") + col - 1) & Trim(Str(row + 1)) & ":" & Chr(Asc("A") + col - 1) & Trim(Str(row + 1))), xlWs)
                End If
                ' rs_EXCEL.MoveNext()
            Next row

            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).VerticalAlignment = xlCenter
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeLeft).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeTop).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeBottom).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeRight).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeBottom).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlEdgeRight).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlInsideHorizontal).LineStyle = xlContinuous
            ''        .Range(.Cells(5, 1), .Cells(row + 4, 29)).Borders(xlInsideVertical).LineStyle = xlContinuous




        End With


        Dim lngPages As Long

        lngPages = rs_EXCEL.Tables("RESULT").Rows.Count / 8 + 1
        If lngPages > 9999 Then
            lngPages = 9999
        End If


        ''    With xlWs.PageSetup
        ''        .PrintTitleRows = "$4:$5"
        ''        .LeftHeader = ""
        ''        .CenterHeader = ""
        ''        .RightHeader = ""
        ''        .LeftFooter = ""
        ''        .CenterFooter = "&P / &N"
        ''        .RightFooter = ""
        ''        .LeftMargin = myExcel.InchesToPoints(0.196850393700787)
        ''        .RightMargin = myExcel.InchesToPoints(0.196850393700787)
        ''        .TopMargin = myExcel.InchesToPoints(0.78740157480315)
        ''        .BottomMargin = myExcel.InchesToPoints(0.393700787401575)
        ''        .HeaderMargin = myExcel.InchesToPoints(0.47244094488189)
        ''        .FooterMargin = myExcel.InchesToPoints(0.196850393700787)
        ''        .PrintHeadings = False
        ''        .PrintGridlines = False
        ''        .PrintComments = xlPrintNoComments
        ''        .PrintQuality = 600
        ''        .CenterHorizontally = True
        ''        .CenterVertically = False
        ''        .FitToPagesWide = 1
        ''        .FitToPagesTall = lngPages
        ''        .orientation = xlLandscape
        ''        .Draft = False
        ''        .PaperSize = xlPaperA4
        ''        .FirstPageNumber = xlAutomatic
        ''        .Order = xlDownThenOver
        ''        .BlackAndWhite = False
        ''        '.Zoom = 55
        ''        .Zoom = False
        '' '       .PrintErrors = xlPrintErrorsDisplayed
        ''    End With

        rs_EXCEL = Nothing

        ' Release Excel references
        xlWs = Nothing
        '   Set xlWb = Nothing
        '   myExcel.SaveWorkspace

        myExcel.Workbooks(1).Save()
        myExcel.Workbooks(1).Close()
        myExcel.Visible = False
        myExcel.UserControl = False

        '   Set myExcel = Nothing
        Exit Function
err_handle_ee:
        MsgBox(Err.Description)
        Err.Clear()
        Exit Function
    End Function
    Sub InsertPictureInRange(ByVal PictureFileName As String, ByVal TargetCells As Microsoft.Office.Interop.Excel.Range, ByRef xls As Microsoft.Office.Interop.Excel.Worksheet)
        Dim p As Object, t As Double, l As Double, W As Double, H As Double

        On Error Resume Next
        If Dir(PictureFileName) = "" Then Exit Sub

        With xls
            If Dir(PictureFileName) <> "" Then
                p = .Pictures.Insert(PictureFileName)
                ' determine positions
                With TargetCells
                    t = .Top
                    l = .Left
                    'w = .Offset(0, .Columns.count).left - .left
                    'h = .Offset(.rows.count, 0).top - .top
                    H = .Offset(0, .Columns.count).Left - .Left
                    W = .Offset(.rows.count, 0).Top - .Top
                End With
                ' position picture


                '            If W > H Then
                '                H = H * (95 / W)
                '                W = 95
                '            Else
                '                W = W * (95 / H)
                '                H = 95
                '            End If

                If p.width > p.Height Then
                    H = p.Height * (95 / p.width)
                    W = 95
                Else
                    W = p.width * (95 / p.Height)
                    H = 95
                End If

                With p
                    .Top = t
                    .Left = l
                    .width = W
                    .Height = H
                End With
                p = Nothing
            End If
        End With

        Err.Clear()
        On Error GoTo 0
    End Sub
    Private Function getDBValues(ByVal varValue As Object, ByVal intType As String, ByVal intLen As Integer) As Object
        On Error GoTo err_handle
        Select Case intType
            'Case adEmpty:
            'Case adSmallInt:
            ' Case adInteger
            ' getDBValues = CInt(varValue)
            'Case adSingle:
            'Case adDouble:
            'Case adCurrency:
            'Case adDate:
            'Case adBSTR:
            'Case adIDispatch:
            'Case adError:
            'Case adBoolean:
            'Case adVariant:
            'Case adIUnknown:
            'Case adDecimal:
            'Case adTinyInt:
            'Case adUnsignedTinyInt:
            'Case adUnsignedSmallInt:
            'Case adUnsignedInt:
            'Case adBigInt:
            'Case adUnsignedBigInt:
            'Case adGUID:
            'Case adBinary:
            ' Case adNumeric
            '    getDBValues = CDbl(Replace(varValue, "`", ""))
            'Case adUserDefined:
            'Case adDBDate:
            'Case adDBTime:

            'Case adDBTimeStamp
            '   getDBValues = Format(varValue, "MM/DD/YYYY HH:MM:SS")
            Case "Varchar" 'adChar, adWChar, adVarChar, adLongVarChar, adVarWChar, adLongVarWChar
                getDBValues = Strings.Left(Replace(CStr(varValue), "'", "''"), intLen)
                'Case adVarBinary:
                '
                'Case adLongVarBinary:

            Case Else
                getDBValues = DBNull.Value
        End Select
        Exit Function
err_handle:
        getDBValues = DBNull.Value
    End Function
End Class