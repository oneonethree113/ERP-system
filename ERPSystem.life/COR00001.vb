Public Class COR00001
    Dim objBSGate As Object
    Dim rs_Select As DataSet
    Dim rs_Result As DataSet
    Dim prefix As String
    Dim rs_Key As DataSet
    Dim colName As String
    Dim rs_Table As DataSet

    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        'On Error GoTo handleError

        Dim cond As String
        Dim fromvalue As String
        Dim tovalue As String
        Dim xlsPath As String
        'Dim myExcel As New Excel.Application
        'Dim xlBook As Excel.Worksheet

        If rs_Select.Tables("RESULT").Rows.Count <> 0 Then
            For i As Integer = 0 To rs_Select.Tables("RESULT").Rows.Count - 1
                If (LTrim(rs_Select.Tables("RESULT").Rows(i).Item("from")) = "" And LTrim(rs_Select.Tables("RESULT").Rows(i).Item("to")) <> "") Or _
                    (LTrim(rs_Select.Tables("RESULT").Rows(i).Item("from")) <> "" And LTrim(rs_Select.Tables("RESULT").Rows(i).Item("to")) = "") Or _
                    (IsDBNull(rs_Select.Tables("RESULT").Rows(i).Item("from")) = True And LTrim(rs_Select.Tables("RESULT").Rows(i).Item("to")) <> "") Or _
                    (LTrim(rs_Select.Tables("RESULT").Rows(i).Item("from")) <> "" And IsDBNull(rs_Select.Tables("RESULT").Rows(i).Item("to")) = True) Then
                    grdValue.Focus()
                    MsgBox("Please fill the condition completely.")
                    Exit Sub
                End If
            Next
            cond = ""
            fromvalue = ""
            tovalue = ""
        End If





        If txtDateFrom.Text = "  /  /    " And txtDateTo.Text = "  /  /    " Then
            MsgBox("Please input Date Range", vbInformation, "Information")
            txtDateFrom.Focus()
            Exit Sub
        ElseIf txtDateFrom.Text = "  /  /    " And txtDateTo.Text <> "  /  /    " Then
            txtDateFrom.Text = "01/01/1900"
        End If
        If txtDateTo.Text = "  /  /    " And txtDateFrom.Text <> "  /  /    " Then
            txtDateTo.Text = txtDateFrom.Text
        End If

        If txtDateFrom.Text <> "  /  /    " Then
            If IsDate(txtDateFrom.Text) = False Then
                MsgBox("Date is Invalid")
                txtDateFrom.Focus()
                Exit Sub
            End If
        End If

        If txtDateTo.Text <> "  /  /    " Then
            If IsDate(txtDateTo.Text) = False Then
                MsgBox("Date is Invalid")
                txtDateTo.Focus()
                Exit Sub
            End If
        End If

        'rs_Select.MoveLast

        'If rs_Select("field") = "" Or rs_Select("from") = "" Or rs_Select("to") = "" Or _
        '   IsNull(rs_Select("field")) = True Or IsNull(rs_Select("from")) = True Or IsNull(rs_Select("to")) = True Then
        '    MsgBox "Please fill the condition completely first", vbInformation, "Information"
        '    Exit Sub
        'End If

        txtSQL.Text = ""
        '+++++++++++++++++++<<<<<<<<<<<<>>>>>>>>>>>>++++++++++++++++++++++<<<<<<<<<<>>>>>>>>>>>>


        Dim initYear As Integer
        Dim currYear As Integer
        Dim dtStart As Date
        Dim dtEnd As Date
        Dim tmpStart As Date
        Dim tmpEnd As Date
        Dim tmpYear As Integer
        Dim strDB As String

        Dim stringBuffer As String


        initYear = 2002 ' set the starting year boundary
        If gsDefaultCompany = "MS" Then
            initYear = 2005
        End If
        currYear = Year(Now) ' set the year use default audit db
        ' error may occur if database for last year is not build up
        ' "Invalid object name 'UCPERPDB_AUD_<xxxx>..SYCOMINF_AUD'."
        ' where <xxxx> is the year suffix
        'currYear = 2004
        dtStart = CDate(Me.txtDateFrom.Text)
        dtEnd = CDate(Me.txtDateTo.Text)

        tmpStart = dtStart
        tmpEnd = dtEnd
        stringBuffer = ""
        For tmpYear = initYear To currYear
            If tmpYear <> initYear And tmpYear > Year(tmpEnd) Then
                Exit For
            End If
            If (Year(tmpStart) <= tmpYear And tmpYear <= Year(tmpEnd)) Or _
                (Year(tmpEnd) <= tmpYear And tmpYear = initYear) Then
                strDB = IIf(tmpYear = currYear, "UCPERPDB_AUD..", "UCPERPDB_AUD_" + CStr(tmpYear) + "..")

                stringBuffer = IIf(stringBuffer <> "", stringBuffer + Chr(13) + Chr(10) + "UNION" + Chr(13) + Chr(10), "") + _
                               "select * from " + strDB + Chr(13) + Chr(10)
                stringBuffer = stringBuffer + Split(cboTable.Text, " - ")(0) + "_AUD (nolock) " + Chr(13) + Chr(10) + "where" + Chr(13) + Chr(10)

                '+++++++++++++++++++<<<<<<<<<<<<>>>>>>>>>>>>++++++++++++++++++++++<<<<<<<<<<>>>>>>>>>>>>

                'txtSQL.Text = "select * from UCPERPDB_AUD.." + Chr(13) + Chr(10)
                'txtSQL.Text = txtSQL.Text + Split(cboTable.Text, " - ")(0) + "_AUD" + Chr(13) + Chr(10) + "where" + Chr(13) + Chr(10)
                'VVVVVVVVVVV
                cond = ""
                '^^^^^^^^^^^
                If rs_Select.Tables("RESULT").Rows.Count <> 0 Then

                    'prefix = Left(rs_Select("field"), 4)

                    For i As Integer = 0 To rs_Select.Tables("RESULT").Rows.Count - 1
                        If LTrim(rs_Select.Tables("RESULT").Rows(i).Item("from")) <> "" And LTrim(rs_Select.Tables("RESULT").Rows(i).Item("to")) <> "" Then
                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                            'Lester Wu 2004/06/11
                            If rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "date" Or rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "datetime" Then
                                If IsDate(rs_Select.Tables("RESULT").Rows(i).Item("from")) = False Then
                                    MsgBox("Invalid Date Format!")
                                    ' grdValue.col = 1
                                    grdValue.Focus()
                                    Exit Sub
                                End If
                                If IsDate(rs_Select.Tables("RESULT").Rows(i).Item("to")) = False Then
                                    MsgBox("Invalid Date Format!")
                                    'grdValue.col = 2
                                    grdValue.Focus()
                                    Exit Sub
                                End If
                                fromvalue = "'" + rs_Select.Tables("RESULT").Rows(i).Item("from") + "'"
                                tovalue = "'" + rs_Select.Tables("RESULT").Rows(i).Item("to") + "'"
                                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                            ElseIf rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "char" Or rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "nchar" Or _
                               rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "nvarchar" Or rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "varchar" Or _
                               rs_Select.Tables("RESULT").Rows(i).Item("fieldtype") = "datetime" Then
                                fromvalue = "''" + rs_Select.Tables("RESULT").Rows(i).Item("from") + "''"
                                tovalue = "''" + rs_Select.Tables("RESULT").Rows(i).Item("to") + "''"
                            Else
                                fromvalue = rs_Select.Tables("RESULT").Rows(i).Item("from")
                                tovalue = rs_Select.Tables("RESULT").Rows(i).Item("to")
                            End If

                            ' Disable to add Company Code for merge project at 19/08/2003
                            'cond = cond + prefix + "cocde = '" + gsCompany + "' and " + Chr(13) + Chr(10)
                            cond = cond + rs_Select.Tables("RESULT").Rows(i).Item("field") + " " + "between " + fromvalue + " and " + tovalue + " and " + Chr(13) + Chr(10)
                        End If

                    Next

                End If  'do here
                cond = cond + prefix + "credat between ''" + txtDateFrom.Text + " 0:00'' and ''" + txtDateTo.Text + " 23:59:59''" + Chr(13) + Chr(10)
                '+++++++++++++++++++<<<<<<<<<<<<>>>>>>>>>>>>++++++++++++++++++++++<<<<<<<<<<>>>>>>>>>>>>
                stringBuffer = stringBuffer + cond
            End If


        Next


        '+++++++++++++++++++<<<<<<<<<<<<>>>>>>>>>>>>++++++++++++++++++++++<<<<<<<<<<>>>>>>>>>>>>

        'cond = cond + "order by " + prefix + "timstp"
        If Trim(stringBuffer) = "" Then
            MsgBox("No Record Found.", vbInformation, "Information")
            Exit Sub
        End If

        'stringBuffer = stringBuffer + "order by " + prefix + "timstp"
        stringBuffer = stringBuffer + "order by " + prefix + "credat, " + prefix + "upddat, " + prefix + "timstp"


        'order by convert(char(10),  ibi_credat, 101), ibi_timstp


        'txtSQL.Text = txtSQL.Text + cond
        txtSQL.Text = stringBuffer


        '''''''''A'''''''''''

        gspStr = "sp_select_Audit '','" & txtSQL.Text & "','" & Split(cboTable.Text, " - ")(0) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_Result, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SAM00001 sp_select_Audit : " & rtnStr)
            Exit Sub
        Else
            If rs_Result.Tables("RESULT").Rows.Count <> 0 Then
                Dim i As Integer
                Dim j As Integer

                i = 0
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")


                'Set xlBook = CreateObject("Excel.sheet")
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet
                'Dim xlButton As Excel.Button

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlBook = xlApp.Workbooks.Add
                xlSheet = xlBook.Worksheets.Add

                ' xlBook.Name = "Audit Trial Report"
                xlSheet.Name = Split(cboTable.Text, " - ")(0)

                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                For i = 0 To rs_Key.Tables("RESULT").Rows.Count - 1
                    xlSheet.Cells(1, i + 1) = rs_Key.Tables("RESULT").Rows(i).Item("key")
                    If rs_Key.Tables("RESULT").Rows(i).Item("fieldtype") = "datetime" _
                    Or rs_Key.Tables("RESULT").Rows(i).Item("fieldtype") = "date" Then
                        Call cal_COL(i)
                        xlSheet.Range(colName).NumberFormatLocal = "dd/mm/yyyy h:mm"
                    End If
                Next

                xlSheet.Cells(1, i + 1) = prefix + "actflg_aud"

                xlSheet.Range("A1:EZ1").Font.Bold = True

                Dim FieldCount As Integer

                FieldCount = rs_Result.Tables("RESULT").Columns.Count
                j = 1






                For i = 0 To rs_Result.Tables("RESULT").Rows.Count - 1



                    For ii As Integer = 0 To FieldCount - 1
                        ' Allan Yuen fix the record is null and timestamp field at 2004/09/20
                        ' Ver 1 Change to not null not datetime
                        ' Ver 2 Timestamp (Aarry)
                        If IsDate(rs_Result.Tables("RESULT").Columns(ii).DataType) = False And _
                            IsDBNull(rs_Result.Tables("RESULT").Rows(i).Item(ii)) = False And _
                            IsArray(rs_Result.Tables("RESULT").Columns(ii).DataType) = False Then

                            If rs_Result.Tables("RESULT").Columns(ii).DataType.ToString <> "System.Byte[]" Then 'And _
                                'rs_Result.Tables("RESULT").Columns(ii).DataType.ToString <> "System.Byte" Then
                                xlSheet.Cells(i + 1 + 1, ii + 1) = Replace(Replace(Replace(rs_Result.Tables("RESULT").Rows(i).Item(ii), Chr(10), "@㊣※"), Chr(13), "@㊣※"), "@㊣※@㊣※", vbCrLf)
                            Else
                                xlSheet.Cells(i + 1 + 1, ii + 1) = ""
                            End If




                        Else
                            xlSheet.Cells(i + 1 + 1, ii + 1) = rs_Result.Tables("RESULT").Rows(i).Item(ii)
                        End If
                    Next





                Next

                xlApp.Selection.CurrentRegion.Columns.AutoFit()
                xlApp.Selection.CurrentRegion.rows.AutoFit()

                xlApp.Visible = True

                xlApp = Nothing
                'xlSheet.SaveAs ("C:\WINDOWS\Desktop\test.xls")
                'xlApp.Workbooks.Close
            Else
                MsgBox("No Record Found.", vbInformation, "Information")



            End If
        End If



        Me.Cursor = Windows.Forms.Cursors.Default

        ''''''''''''A'''''''''''

        'Dim S As String

        'Dim rs() As ADOR.Recordset

        'Me.Cursor = Windows.Forms.Cursors.WaitCursor

        ''Lester Wu 2005-06-08, change stored procedure to handle audit search
        ''S = "㊣SQL※S※" & txtSQL.Text
        'S = "㊣Audit※S※" & txtSQL.Text & "※" & Split(cboTable.Text, " - ")(0)

        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        'Me.Cursor = Windows.Forms.Cursors.Default

        'If rs(0)(0) <> "0" Then  '*** An error has occured
        '    MsgBox(rs(0)(0))
        '    Exit Sub
        'Else

        '    rs_Result = CopyRS(rs(1))


        '    If rs_Result.recordCount > 0 Then

        '        'Frankie Cheung 20110505 Sort result recordset
        '        'rs_Result.sort = prefix + "credat, " + prefix + "timstp"
        '        'rs_Result.sort = prefix + "credat, " + prefix + "upddat, " + prefix + "timstp"





        '        Dim i As Integer
        '        Dim j As Integer

        '        i = 0

        '        'Set xlBook = CreateObject("Excel.sheet")
        '        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        '        Dim xlBook As Microsoft.Office.Interop.Excel.Workbook
        '        Dim xlSheet As Microsoft.Office.Interop.Excel.Worksheet
        '        'Dim xlButton As Excel.Button

        '        xlApp = New Microsoft.Office.Interop.Excel.Application
        '        xlBook = xlApp.Workbooks.Add
        '        xlSheet = xlBook.Worksheets.Add

        '        ' xlBook.Name = "Audit Trial Report"
        '        xlSheet.Name = Split(cboTable.Text, " - ")(0)

        '        Screen.MousePointer = vbHourglass


        '        rs_Key.MoveFirst()
        '        While Not rs_Key.EOF
        '            xlSheet.Cells(1, i + 1) = rs_Key("key")
        '            If rs_Key("fieldtype") = "datetime" Or rs_Key("fieldtype") = "date" Then
        '                Call cal_COL(i)
        '                xlSheet.Range(colName).NumberFormatLocal = "dd/mm/yyyy h:mm"
        '            End If
        '            i = i + 1
        '            rs_Key.MoveNext()
        '        End While ' do

        '        xlSheet.Cells(1, i + 1) = prefix + "actflg_aud"

        '        xlSheet.Range("A1:EZ1").Font.Bold = True

        '        Dim FieldCount As Integer

        '        FieldCount = rs_Result.Fields.count
        '        j = 1

        '        rs_Result.MoveFirst()
        '        While Not rs_Result.EOF

        '            For i = 0 To FieldCount - 1
        '                ' Allan Yuen fix the record is null and timestamp field at 2004/09/20
        '                If (rs_Result.Fields.Item(i).Type = adVarChar Or _
        '                   rs_Result.Fields.Item(i).Type = adChar Or _
        '                   rs_Result.Fields.Item(i).Type = adVarWChar Or _
        '                   rs_Result.Fields.Item(i).Type = adWChar) And _
        '                   rs_Result.Fields.Item(i).Type <> adDBTimeStamp And _
        '                   IsNull(rs_Result(i)) = False Then
        '                    xlSheet.Cells(j + 1, i + 1) = Replace(Replace(Replace(rs_Result(i), Chr(10), "@㊣※"), Chr(13), "@㊣※"), "@㊣※@㊣※", vbCrLf)
        '                Else
        '                    xlSheet.Cells(j + 1, i + 1) = rs_Result(i)
        '                End If
        '            Next

        '            PBar.Value = j
        '            j = j + 1

        '            rs_Result.MoveNext()
        '        End While

        '        xlApp.selection.CurrentRegion.Columns.AutoFit()
        '        xlApp.selection.CurrentRegion.rows.AutoFit()

        '        xlApp.Visible = True

        '        xlApp = Nothing
        '        'xlSheet.SaveAs ("C:\WINDOWS\Desktop\test.xls")
        '        'xlApp.Workbooks.Close
        '    Else
        '        MsgBox("No Record Found.", vbInformation, "Information")

        '    End If
        'End If

        'PBar.Value = 0

        'Screen.MousePointer = vbDefault

        ''handleError:
        ''    If Err.Number <> 0 Then
        ''        MsgBox "Please check your application of Excel or contact System Administrator.", vbCritical, "Error"
        ''    End If
    End Sub

    Private Sub COR00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PBar.Value = 0
        'lstKey.Visible = False

       

        Dim v

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '            objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        Dim S As String
        Dim rs() As ADOR.Recordset

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'S = "㊣table_name※L※Table"
        gspStr = "sp_select_table_list ''"

        rtnLong = execute_SQLStatement(gspStr, rs_Table, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading Form Load sp_select_table_list : " & rtnStr)
        Else
            If rs_Table.Tables("RESULT").Rows.Count <> 0 Then
                For i As Integer = 0 To rs_Table.Tables("RESULT").Rows.Count - 1
                    cboTable.Items.Add(rs_Table.Tables("RESULT").Rows(i).Item("table"))
                Next
            End If

        End If



        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        gspStr = "sp_list_COR00001 ''"

        rtnLong = execute_SQLStatement(gspStr, rs_Select, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default


        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading Form Load sp_list_COR00001 : " & rtnStr)
        Else



            grdValue.DataSource = rs_Select.Tables("RESULT").DefaultView

            Call Display()

        End If

        Call Formstartup(Me.Name)   'Set the form Startup position
    End Sub

    Private Sub Display()

        With grdValue

            .Columns(0).HeaderText = "Key"
            '.Columns(0).Button = True
            .Columns(0).ReadOnly = True
            .Columns(0).Width = 90

            .Columns(1).HeaderText = "From"
            .Columns(1).Width = 120

            .Columns(2).HeaderText = "To"
            .Columns(2).Width = 120

            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With

    End Sub

    Private Sub cal_COL(ByVal i As Integer)
        Dim j As Double
        Dim X As Integer
        Dim Y As Integer
        Dim subCol As String

        If i >= 26 Then
            j = Val(Split(Str(i / 26), ".")(0))
        Else
            j = 0
        End If

        If j = 0 Then
            For X = 0 To 26 - 1
                If i = X Then
                    colName = UCase(Chr(i + 97)) + ":" + UCase(Chr(i + 97))
                End If
            Next
        Else
            For X = 0 To 26 - 1
                If j = X Then
                    subCol = UCase(Chr(j - 1 + 97))
                End If
            Next

            Y = i - (26 * j)
            For X = 0 To 26 - 1
                If Y = X Then
                    colName = subCol + UCase(Chr(Y + 97)) + ":" + subCol + UCase(Chr(Y + 97))
                End If
            Next
        End If

    End Sub

    Private Sub cboTable_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTable.KeyUp
        auto_search_combo(cboTable)
    End Sub


    Private Sub cboTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTable.SelectedIndexChanged
        Dim S As String
        Dim rs() As ADOR.Recordset

        'On Error GoTo errNoField
        If cboTable.Items.IndexOf(cboTable.Text) = -1 Then
            MsgBox("Invalid Table!")

            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor


        gspStr = "sp_list_COR00001 ''"

        rtnLong = execute_SQLStatement(gspStr, rs_Select, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default


        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading Form Load sp_list_COR00001 : " & rtnStr)
        Else
        End If



        If cboTable.Text <> "" Then

            grdValue.DataSource = Nothing

            Me.Cursor = Windows.Forms.Cursors.WaitCursor


            gspStr = "sp_list_COR00001 ''"

            rtnLong = execute_SQLStatement(gspStr, rs_Select, rtnStr)

            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                MsgBox("Error on loading cboTable_SelectedIndexChanged sp_list_COR00001 : " & rtnStr)

            Else

                '  rs_Select = CopyRS(rs(1))

                For i As Integer = 0 To rs_Select.Tables("RESULT").Columns.Count - 1
                    rs_Select.Tables("RESULT").Columns(i).ReadOnly = False
                Next

                grdValue.DataSource = rs_Select.Tables("RESULT").DefaultView

                Call Display()



            End If

            'lstKey.Clear()

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            gspStr = "sp_list_table_information '','" & Split(cboTable.Text, " - ")(0) & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_Key, rtnStr)

            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then  '*** An error has occured
                MsgBox("Error on loading cboTable_SelectedIndexChanged sp_list_table_information : " & rtnStr)

            Else

                If rs_Select.Tables("RESULT").Rows.Count <> 0 Then
                    For i As Integer = 0 To rs_Select.Tables("RESULT").Rows.Count - 1
                        If rs_Select.Tables("RESULT").Rows(i).Item("field") = "" Then
                            rs_Select.Tables("RESULT").Rows(i).Delete()
                            rs_Select.Tables("RESULT").AcceptChanges()
                        End If
                    Next
                End If



                If rs_Key.Tables("RESULT").Rows.Count <> 0 Then

                    prefix = Strings.Left(rs_Key.Tables("RESULT").Rows(0).Item("key"), 4)
                    For i As Integer = 0 To rs_Key.Tables("RESULT").Rows.Count - 1  'And rs_Key("PrimaryKey") = "Y"
                        If rs_Key.Tables("RESULT").Rows(i).Item("PrimaryKey") = "Y" And Strings.Right(rs_Key.Tables("RESULT").Rows(i).Item("key"), 6) <> "_cocde" Then
                            Dim rowcount As Integer
                            rowcount = rs_Select.Tables("RESULT").Rows.Count
                            rs_Select.Tables("RESULT").Rows.Add()
                            rs_Select.Tables("RESULT").Rows(rowcount).Item("field") = rs_Key.Tables("RESULT").Rows(i).Item("key")
                            rs_Select.Tables("RESULT").Rows(rowcount).Item("fieldtype") = rs_Key.Tables("RESULT").Rows(i).Item("fieldtype")
                            rs_Select.Tables("RESULT").Rows(rowcount).Item("fieldlength") = rs_Key.Tables("RESULT").Rows(i).Item("fieldlength")
                            rs_Select.Tables("RESULT").Rows(rowcount).Item("from") = ""
                            rs_Select.Tables("RESULT").Rows(rowcount).Item("to") = ""
                            'lstKey.AddItem rs_Key("key")
                        End If

                        'If rs_Key.AbsolutePosition > 2 Then
                        '    If Not rs_Key.EOF And rs_Key("PrimaryKey") = "Y" Then
                        '        rs_Select.AddNew()

                        '    End If
                        'End If
                    Next
                    '-------------
                    'eliminate records with empty "field"

                    'rs_Select.MoveFirst()
                    'Do While Not rs_Select.EOF
                    '    If rs_Select.Fields("field") = "" Then
                    '        rs_Select.Delete()
                    '    End If
                    '    rs_Select.MoveNext()
                    'Loop

                    ''-------------
                    ''this line may raise an error if no record in rs_select
                    'rs_Select.MoveFirst()
                    '-------------
                End If
            End If

        End If
        Exit Sub
        'errNoField:
        ' set rs_select to nothing in case no primary key available
        '     rs_Select = Nothing
    End Sub

    Private Sub txtDateFrom_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDateFrom.MaskInputRejected

    End Sub

    Private Sub txtDateFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDateFrom.TextChanged
        txtDateTo.Text = txtDateFrom.Text
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub
End Class