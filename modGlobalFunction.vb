Imports System.IO
Imports System.Globalization

Module modGlobalFunction

    Public Sub FillCompCombo(ByVal userid As String, ByVal cbobox As ComboBox)
        Dim rs_SYMUSRCO As New DataSet
        Dim gspStr As String
        Dim frm As Form
        frm = CType(cbobox.FindForm, Form)

        If cbobox.Items.Count > 0 Then
            Exit Sub
        End If

        If gsConnStr = "" Then
            gsConnStr = getConnStr(gsConnStr, rtnStr, "CON-DB")
        End If

        gspStr = "sp_select_SYUSRGRP_COMP '','" & gsUsrID & "','" & frm.Name.ToString & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYUSRGRP_COMP : " & rtnStr)
        Else
            For Each dr As DataRow In rs_SYMUSRCO.Tables("RESULT").Rows
                If gsCompanyGroup = "UCG" Then
                    If dr.Item("yuc_cocde").ToString <> "MS" Then
                        cbobox.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                ElseIf gsCompanyGroup = "MSG" Then
                    If dr.Item("yuc_cocde").ToString = "MS" Then
                        cbobox.Items.Add(dr.Item("yuc_cocde").ToString)
                    End If
                End If
            Next
        End If
        rs_SYMUSRCO = Nothing

    End Sub

    Public Sub GetDefaultCompany(ByVal cbobox As ComboBox, ByVal txtCoNam As TextBox)
        Dim frm As Form
        frm = CType(cbobox.FindForm, Form)

        If rs_SYUSRPRF.Tables("RESULT").Rows.Count > 0 Then
            For Each dr As DataRow In rs_SYUSRPRF.Tables("RESULT").Rows
                If dr.Item("yuc_flgdef").ToString = "Y" Then
                    If gsCompanyGroup = "MSG" Then
                        cbobox.Text = "MS"
                    Else
                        cbobox.Text = dr.Item("yuc_cocde").ToString
                    End If
                    txtCoNam.Text = ChangeCompany(cbobox.Text, frm.Name.ToString)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Function ChangeCompany(ByVal CoCde As String, ByVal FormName As String) As String
        Dim dr() As DataRow

        ChangeCompany = ""
        gsCompany = CoCde

        dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
        If Not dr.Length > 0 Then
            MsgBox("Invalid Company Name")
        Else
            ChangeCompany = dr(0)("yco_conam").ToString
        End If
        Call Update_gs_Value(gsCompany)
        Call AccessRight(FormName)
    End Function

    Public Sub GetCompanyName()

        If gsConnStr = "" Then
            gsConnStr = getConnStr(gsConnStr, rtnStr)
        End If

        gspStr = "sp_select_SYCOMINF_M '', 'ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCOMINF_NAME, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYCOMINF_M : " & rtnStr)
        End If
    End Sub

    Public Sub AccessRight(ByVal FormName As String)
        Dim dr() As DataRow
        Dim Right As String = ""

        dr = rs_SYUSRGRP_right.Tables("RESULT").Select("yug_usrfun = " & "'" & FormName & "' and yug_usrgrp = '" & gsUsrGrp & "'")

        If Not dr.Length = 0 Then
            Right = Left(dr(0)("yug_assrig"), 3)
        End If

        '*** Del_right focus on cmdDelete and cmdDelRow button
        '*** Enq_right focus on cmdAdd, cmdSave, cmdCopy, cmd_InsRow button

        If Right = "MWD" Then
            Del_right = True
            Enq_right = True
        ElseIf Right = "MOD" Then
            Del_right = False
            Enq_right = True
        ElseIf Right = "ENQ" Then
            Del_right = False
            Enq_right = False
        Else
            Del_right = False
            Enq_right = False
        End If
    End Sub

    Public Sub Update_gs_Value(ByVal CoCde As String)
        Dim dr() As DataRow

        If CoCde <> "ALL" And CoCde <> "UC-G" Then
            If rs_SYUSRPRF.Tables("RESULT").Rows.Count > 0 Then
                dr = rs_SYUSRPRF.Tables("RESULT").Select("yuc_cocde = '" & CoCde & "'")
                If dr.Length > 0 Then
                    gsUsrGrp = dr(0)("yuc_usrgrp").ToString
                    gsFlgCst = dr(0)("yuc_flgcst").ToString
                    gsFlgCstExt = dr(0)("yuc_flgcstext").ToString
                    gsFlgRel = dr(0)("yuc_flgrel").ToString
                    gsUsrRank = CType(dr(0)("yuc_usrank"), Long)
                    gsSalTem = dr(0)("ysr_saltem").ToString
                End If

                dr = Nothing
                dr = rs_SYCOMINF_NAME.Tables("RESULT").Select("yco_cocde = '" & gsCompany & "'")
                If dr.Length > 0 Then
                    gsTimeOut = CType((dr(0)("yco_systim")) * 60, Long)
                    gsExpDay = CType(dr(0)("yco_expday"), Integer)
                    gsCurcde = dr(0)("yco_curcde").ToString
                    gsMoa = CType(dr(0)("yco_moa"), Double)
                    gsMoq = CType(dr(0)("yco_moq"), Integer)
                    'gsConnStr = Split(gsConnStr, "¡°")(0) & "¡°" & gsCompany
                    'gsConnStrRpt = Split(gsConnStrRpt, "¡°")(0) & "¡°" & gsCompany
                End If
            End If
        Else
            'gsConnStr = Split(gsConnStr, "¡°")(0) & "¡°" & CoCde
            'gsConnStrRpt = Split(gsConnStrRpt, "¡°")(0) & "¡°" & CoCde
        End If
    End Sub

    Public Sub Formstartup(ByVal frmname As String)
        Dim frm As Form

        For Each frm In Application.OpenForms
            If frm.Name = frmname Then
                If frm.IsMdiChild Then
                    frm.Top = 0
                    frm.Left = 0
                End If
                Exit For
            End If
        Next
    End Sub
    Public Function chkGrdCellValue(ByVal cell As DataGridViewCell, ByVal strType As String, Optional ByVal intStrLen As Integer = 0) As Boolean
        Dim colHeader As String
        Dim row As DataGridViewRow
        Dim cellValue As Object

        row = cell.DataGridView.Rows(cell.RowIndex)
        colHeader = cell.DataGridView.Columns(cell.ColumnIndex).HeaderText

        If cell.IsInEditMode Then
            cellValue = cell.EditedFormattedValue
        Else
            cellValue = cell.Value
        End If

        Select Case strType
            Case "Z+Integer"
                If cellValue.ToString = "" Then
                    MsgBox(colHeader & " is empty, please input again!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf Not IsNumeric(cellValue) Then
                    MsgBox(colHeader & " should be numeric!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf cellValue < 0 Then
                    MsgBox(colHeader & " should not be negative!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf CType(cellValue, Decimal) - Math.Truncate(CType(cellValue, Decimal)) <> 0 Then
                    MsgBox(colHeader & " should be an integer!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                Else
                    Return True
                End If

            Case "+Integer"
                If cellValue.ToString = "" Then
                    MsgBox(colHeader & " is empty, please input again!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf Not IsNumeric(cellValue) Then
                    MsgBox(colHeader & " should be numeric!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf cellValue <= 0 Then
                    MsgBox(colHeader & " should be greater than zero!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf CType(cellValue, Decimal) - Math.Truncate(CType(cellValue, Decimal)) <> 0 Then
                    MsgBox(colHeader & " should be an integer!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                Else
                    Return True
                End If

            Case "Z+Numeric"
                If cellValue.ToString = "" Then
                    MsgBox(colHeader & " is empty, please input again!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf Not IsNumeric(cellValue) Then
                    MsgBox(colHeader & " should be numeric!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf cellValue < 0 Then
                    MsgBox(colHeader & " should not be negative!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                Else
                    Return True
                End If

            Case "+Numeric"
                If cellValue.ToString = "" Then
                    MsgBox(colHeader & " is empty, please input again!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf Not IsNumeric(cellValue) Then
                    MsgBox(colHeader & " should be numeric!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf cellValue <= 0 Then
                    MsgBox(colHeader & " should be greater than zero!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                Else
                    Return True
                End If

            Case "String"
                If cellValue.ToString = "" Then
                    MsgBox(colHeader & " is empty, please input again!")
                    row.DataGridView.CurrentCell = cell
                    Return False

                ElseIf intStrLen > 0 And cellValue.ToString.Length > intStrLen Then
                    MsgBox("Exceed field length!")
                    row.DataGridView.CurrentCell = cell
                    Return False
                Else
                    Return True
                End If

        End Select
    End Function


    Public Sub showForm(ByVal mnuItem As MenuItem, ByVal parent As Form)
        Dim flg As Boolean = False
        Dim formName As String

        formName = Split(CType(mnuItem, MenuItem).Text.ToString, " - ")(0).Trim

        For Each f As Form In parent.MdiChildren
            If f.Name = formName Then
                flg = True
                f.BringToFront()
            End If
        Next

        If Not flg Then
            Dim f As Form = GetFormByName(formName)
            If Not f Is Nothing Then
                f.MdiParent = parent
                f.Show()
            End If
        End If
    End Sub

    Public Function GetFormByName(ByVal formName As String) As Object
        Dim myasm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

        Try
            Return myasm.CreateInstance(myasm.GetName.Name.Replace(" ", "_") & "." & formName)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function checkValidCombo(ByVal cbo As ComboBox, ByVal str As String) As Boolean
        checkValidCombo = False

        Dim i As Integer
        Dim s As String

        If cbo.Text <> "" Then
            s = cbo.Text
            For i = 0 To cbo.Items.Count - 1
                If s = cbo.Items(i) Then
                    checkValidCombo = True
                End If
            Next i
        End If

        Return checkValidCombo
    End Function


    Public Sub display_combo(ByVal val As String, ByVal combo As ComboBox)

        If val = "" Then
            combo.Text = val
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To combo.Items.Count - 1
            If val = Split(combo.Items(i), " - ")(0) Then
                combo.Text = combo.Items(i)
                Exit Sub
            End If
        Next i

        combo.Text = val
    End Sub

    Public Sub auto_search_combo(ByVal combo As ComboBox)

        Dim selstart As Integer
        Dim sellength As Integer

        selstart = combo.SelectionStart
        sellength = combo.SelectionLength

        'If selstart = 0 Or sellength = 0 Then
        '    Exit Sub
        'End If

        Dim val As String
        Dim val_len As Integer

        'Changed by Carlos Lui at 11-11-2011
        'val = combo.Text
        val = combo.Text.ToUpper
        val_len = Len(val)

        Dim i As Integer
        Dim hit As Boolean
        hit = False

        For i = 0 To combo.Items.Count - 1
            'If val < combo.Items(i) Then
            'Changed by Carlos Lui at 11-11-2011
            'If val = Mid(combo.Items(i), 1, val_len) Then
            If val = Mid(combo.Items(i).ToString.ToUpper, 1, val_len) Then
                combo.Text = combo.Items(i)
                hit = True
                Exit For
            End If
        Next i

        If hit = True Then
            combo.Select(Len(val), Len(combo.Text) - Len(val))
        End If

    End Sub


    Public Sub auto_search_combo(ByVal combo As ComboBox, ByVal keycode As Keys)

        If Not (keycode >= Asc("0") And keycode <= Asc("z")) Then
            Exit Sub
        End If

        Dim selstart As Integer
        Dim sellength As Integer

        selstart = combo.SelectionStart
        sellength = combo.SelectionLength

        'If selstart = 0 Or sellength = 0 Then
        '    Exit Sub
        'End If

        Dim val As String
        Dim val_len As Integer

        'Changed by Carlos Lui at 11-11-2011
        'val = combo.Text
        val = combo.Text.ToUpper
        val_len = Len(val)

        Dim i As Integer
        Dim hit As Boolean
        hit = False

        For i = 0 To combo.Items.Count - 1
            'If val < combo.Items(i) Then
            'Changed by Carlos Lui at 11-11-2011
            'If val = Mid(combo.Items(i), 1, val_len) Then
            If val = Mid(combo.Items(i).ToString.ToUpper, 1, val_len) Then
                combo.Text = combo.Items(i)
                hit = True
                Exit For
            End If
        Next i

        If hit = True Then
            combo.Select(Len(val), Len(combo.Text) - Len(val))
        End If

    End Sub


    ''' <summary>
    ''' ''''the below codes are added by Danny Yiu
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub GetEMLINF(ByVal docno As String, ByVal modules As String, ByVal modcase As String, Optional ByVal addition As String = "")
        Dim rs_SYEMLGRP As New DataSet
        Dim rs_SYEMLTMP As New DataSet
        Dim rs_EMLQUEUE As New DataSet
        Dim rs_SYEMLSTS As New DataSet
        Dim rs_CAORDHDR As New DataSet
        Dim inteid As Integer
        Dim emlid As String
        Dim i As Integer
        Dim a As Integer
        Dim miladrcomb As String

        Dim tmpid As String
        Dim getccaddr As String
        Dim getsubj As String
        Dim getcont As String
        Dim getsddept As String
        Dim flag As Integer
        Dim countcomm As Integer
        Dim sdemlmag As String
        Dim getusrdept() As String

        i = 0
        a = 0
        flag = 0
        countcomm = 0
        miladrcomb = ""
        sdemlmag = ""
        emlid = ""
        getsddept = ""

        '''''check the forms of need in database having problem or not '''''''
        gsCompany = "UCP"
        gspStr = "sp_list_SYEMLGRP'" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYEMLGRP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_SYEMLGRP : " & rtnStr)
            Exit Sub
        Else
            rs_SYEMLGRP.Tables("RESULT").Columns(0).ReadOnly = False
        End If

        gsCompany = "UCP"
        gspStr = "sp_list_SYEMLTMP'" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYEMLTMP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_SYEMLTMP : " & rtnStr)
            Exit Sub
        Else
            rs_SYEMLTMP.Tables("RESULT").Columns(0).ReadOnly = False
        End If

        gsCompany = "UCP"
        gspStr = "sp_list_EMLQUEUE'" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_EMLQUEUE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_EMLQUEUE : " & rtnStr)
            Exit Sub
        Else
            rs_EMLQUEUE.Tables("RESULT").Columns(0).ReadOnly = False
        End If

        gsCompany = "UCP"
        gspStr = "sp_list_SYEMLSTS'" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYEMLSTS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_SYEMLSTS : " & rtnStr)
            Exit Sub
        Else
            rs_SYEMLSTS.Tables("RESULT").Columns(0).ReadOnly = False
        End If
        '''' end of check ''''''

        If docno <> "" Then
            ''''get and renew email id''''''
            For Each dr As DataRow In rs_EMLQUEUE.Tables("RESULT").Rows
                If dr.Item("emq_emlid") > 0 Then
                    inteid = dr.Item("emq_emlid")
                Else
                    inteid = 0
                End If
            Next

            inteid = inteid + 1
            ''''end of renew email id'''''

            ''''find email address''''''
            '****find usrid
            Dim getemailid As String
            Dim p As Integer
            Dim getusreml As String
            getusreml = ""
            getemailid = ""
            Dim drt As Integer
            Dim dro As Integer

            For drt = 0 To rs_SYEMLSTS.Tables("RESULT").Rows.Count - 1
                If rs_SYEMLSTS.Tables("RESULT").Rows(drt).Item("yes_mod").ToString = modules And rs_SYEMLSTS.Tables("RESULT").Rows(drt).Item("yes_modcase").ToString = modcase Then
                    If rs_SYEMLSTS.Tables("RESULT").Rows(drt).Item("yes_usrid").ToString = "ALL" And InStr(1, rs_SYEMLSTS.Tables("RESULT").Rows(drt).Item("yes_dept"), ",", vbTextCompare) > 0 Then
                        getusrdept = Split(rs_SYEMLSTS.Tables("RESULT").Rows(drt).Item("yes_dept"), ",")

                        For p = 0 To getusrdept.Length - 1
                            For dro = 0 To rs_SYEMLGRP.Tables("RESULT").Rows.Count - 1
                                If getusrdept(p) = rs_SYEMLGRP.Tables("RESULT").Rows(dro).Item("yeg_dept").ToString Then
                                    getusreml = getusreml + rs_SYEMLGRP.Tables("RESULT").Rows(dro).Item("yeg_maddr") + ","
                                End If
                            Next
                        Next
                    Else
                        For Each dvt As DataRow In rs_SYEMLGRP.Tables("RESULT").Rows
                            If getusrdept(p) = dvt.Item("yeg_dept").ToString Then
                                getusreml = getusreml + dvt.Item("yeg_maddr") + ","
                            End If
                        Next
                    End If
                End If
            Next

            sdemlmag = Left(getusreml, getusreml.Length - 1).Trim

            getccaddr = ""

            ''''get tempid''''''
            Dim drr As Integer
            For drr = 0 To rs_SYEMLSTS.Tables("RESULT").Rows.Count - 1
                If rs_SYEMLSTS.Tables("RESULT").Rows(drr).Item("yes_mod").ToString = modules And rs_SYEMLSTS.Tables("RESULT").Rows(drr).Item("yes_modcase").ToString = modcase Then
                    tmpid = rs_SYEMLSTS.Tables("RESULT").Rows(drr).Item("yes_tmpcde")
                End If
            Next
            ''''end of get tempid''''

            ''''add subject''''''
            Dim dre As Integer
            For dre = 0 To rs_SYEMLTMP.Tables("RESULT").Rows.Count - 1
                If rs_SYEMLTMP.Tables("RESULT").Rows(dre).Item("yet_tmpcde") = tmpid Then
                    getsubj = rs_SYEMLTMP.Tables("RESULT").Rows(dre).Item("yet_tmphd")
                End If
            Next
            If tmpid = "01" Then
                getsubj = Replace(getsubj, "@docno", docno)
            End If
            ''''end of add subject''''

            ''''add content''''''
            For Each drh As DataRow In rs_SYEMLTMP.Tables("RESULT").Rows
                If drh.Item("yet_tmpcde") = tmpid Then
                    getcont = drh.Item("yet_tmpcont")
                End If
            Next

            Dim content() As String
            Dim location As Integer
            Dim k As Integer
            k = 0
            If tmpid = "04" Then
                location = getcont.IndexOf("</i>")
                getcont = getcont.Insert(location, "testingtesting")

                content = Split(getcont, "</p>")
                'location = content.IndexOf("</p>")
                getcont = ""
                While (content(k) <> "")
                    getcont = getcont + content(k) + "is it true?" + "</p>"
                    k = k + 1
                End While
            End If

            If tmpid = "01" Then
                getcont = Replace(getcont, "@docno", docno)
                getcont = Replace(getcont, "@int", addition)
                getcont = Replace(getcont, "@now", modcase)
            End If
            ''''end of add content''''

            ''''save(transform) the above information to EMLQUEUE''''''''''
            gspStr = "sp_insert_EMLQUEUE '" & gsCompany & "','" & _
                     inteid.ToString.Replace("'", "''").Trim & "','" & _
                     sdemlmag.ToString.Replace("'", "''").Trim & "','" & _
                     getccaddr.ToString.Replace("'", "''").Trim & "','" & _
                     getsubj.ToString.Replace("'", "''").Trim & "','" & _
                     getcont.ToString.Replace("'", "''").Trim & "','" & _
                     "A".ToString.Replace("'", "''").Trim & "','" & _
                     gsUsrID & "'"

            If gspStr <> "" Then
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading sp_insert_EMLQUEUE : " & rtnStr)
                End If
                gspStr = ""
            End If
        Else
            MsgBox("Please check if there is related Claim No exist in the database")
            Exit Sub
        End If
    End Sub

    Public Function getDefault_Path() As Boolean

        Dim img As String
        Dim col As String
        Dim Shp As String

        If gsCompany = "UCPP" Or gsCompany = "PG" Or gsCompany = "EW" Then
            img = "6FItmImg_pth"
            col = "6FColImg_pth"
            Shp = "6FShpMrk_pth"
        ElseIf gsCompany = "UCP" Then
            img = "3FItmImg_pth"
            col = "3FColImg_pth"
            Shp = "3FShpMrk_pth"
        ElseIf gsCompany = "MS" Then
            img = "MS_ItmImg_pth"
            col = "MS_ColImg_pth"
            Shp = "MS_ShpMrk_pth"
        End If

        Dim S As String

        Try
            Using sr As New StreamReader("path.ini")
                While sr.Peek <> -1
                    S = sr.ReadLine().ToString

                    If S.IndexOf(" = ") > 0 Then
                        Select Case UCase(Split(S, " = ")(0))
                            Case UCase(img)
                                ItmImg_pth = Trim(Split(S, " = ")(1))
                            Case UCase("6FItmImg_pth")
                                ItmImg_pth_6 = Trim(Split(S, " = ")(1))
                            Case UCase(col)
                                ColImg_pth = Trim(Split(S, " = ")(1))
                            Case UCase("6FColImg_pth")
                                ColImg_pth_6 = Trim(Split(S, " = ")(1))
                            Case UCase(Shp)
                                ShpMrk_pth = Trim(Split(S, " = ")(1))
                            Case UCase("REPORTPATH")
                                gsReportPath = Trim(Split(S, " = ")(1))
                            Case UCase("gs_PDO_localpath")
                                gs_PDO_localpath = Trim(Split(S, " = ")(1))
                            Case UCase("gs_PDO_FtpSrvIP")
                                gs_PDO_FtpSrvIP = Trim(Split(S, " = ")(1))
                            Case UCase("gs_PDO_FtpDrive")
                                gs_PDO_FtpDrive = Trim(Split(S, " = ")(1))
                            Case UCase("6Fgs_PDO_SMImg")
                                If gsCompany = "UCPP" Then
                                    gs_PDO_SMImg = Trim(Split(S, " = ")(1))
                                End If
                            Case UCase("3Fgs_PDO_SMImg")
                                If gsCompany = "UCP" Then
                                    gs_PDO_SMImg = Trim(Split(S, " = ")(1))
                                End If
                            Case UCase("MS_gs_PDO_SMImg")
                                If gsCompany = "MS" Then
                                    gs_PDO_SMImg = Trim(Split(S, " = ")(1))
                                End If
                            Case UCase("server_QC_destpth")
                                server_QC_destpth = Trim(Split(S, " = ")(1))
                        End Select
                    End If

                End While
            End Using
        Catch ex As Exception
            MsgBox("Unable to determine file path: path.ini")
            Return False
        End Try

        Return True
    End Function


    Public Sub display_combo_ven(ByVal val As String, ByVal combo As ComboBox)

        'If val = "" Then
        '    combo.Text = val
        '    Exit Sub
        'End If

        'Dim i As Integer

        'For i = 0 To combo.Items.Count - 1
        '    If Split(val, " - ")(0) = Split(combo.Items(i), " - ")(1) Then
        '        combo.Text = Split(combo.Items(i), " - ")(1) & " - " & Split(combo.Items(i), " - ")(0)
        '        Exit Sub
        '    End If
        'Next i
        If InStr(val, "-") > 1 Then

            combo.Text = Split(val, " - ")(1) & " - " & Split(val, " - ")(0)
        End If
    End Sub


    Public Class GenericListItem(Of T)
        Private _Text As String
        Private _Value As T

        Public Sub New(ByVal Text As String, ByVal Value As T)
            _Text = Text
            _Value = Value
        End Sub

        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal Text As String)
                _Text = Text
            End Set
        End Property

        Public Property Value() As T
            Get
                Return _Value
            End Get
            Set(ByVal Value As T)
                _Value = Value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return _Text
        End Function
    End Class

    Public Sub HighlightMask(ByVal t As Object)
        t.SelectionStart = 0

        If (t.Text) = "  /  /" Then
            t.SelectionLength = 10
        Else
            t.SelectionLength = Len(t.Text)
        End If
    End Sub


    Public Sub HighlightText(ByVal t As Object)

        t.SelectionStart = 0

        t.SelectionLength = Len(t.Text)

    End Sub

    Public Function ValidateCombo(ByVal Combo1 As ComboBox) As Boolean

        If Combo1.Text = "" Then

            ValidateCombo = True

            Exit Function

        End If

        ValidateCombo = False

        Dim i As Integer

        Dim S As String

        S = Combo1.Text

        For i = 0 To Combo1.Items.Count - 1

            If UCase(Combo1.Items(i).ToString) = UCase(S) Then

                ValidateCombo = True

                Exit Function

            End If

        Next

        If Not ValidateCombo Then

            MsgBox("Invalid Data! Please try again.")

            On Error Resume Next

            Combo1.Focus()

            On Error GoTo 0

        End If

    End Function

    Public Function checkFocus(ByRef form As Form) As Boolean
        checkFocus = False
        Dim objView As Label = New Label()
        form.Controls.Add(objView)
        objView.Focus()
        If Not (objView.Focused) Then
            checkFocus = True
        End If
        form.Controls.Remove(objView)
    End Function

#Region "Week Function"
    Dim today As Date = Date.Today 'New DateTime(2016, 12, 30)
    Public Function GetCurrentWeek() As Integer
        Return GetWeekByDate(Date.Today, False)
    End Function

    Public Function GetWeekByDate(ByVal _date As Date, Optional ByVal flg_showlastyearweek As Boolean = True) As Integer
        Dim jan1 As DateTime = New DateTime(_date.Year, 1, 1)
        Dim daysOffset As Integer = DayOfWeek.Thursday - jan1.DayOfWeek
        If daysOffset < 0 Then
            daysOffset = daysOffset + 7
        End If
        Dim firstThursday As Date = jan1.AddDays(daysOffset)
        Dim cal As Calendar = New CultureInfo("en-US").Calendar
        'Dim firstWeek As Integer = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        Dim firstWeek As Integer = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        Dim firstWeekYear As Integer = cal.GetYear(firstThursday)

        Dim week As Integer
        '        If firstWeek > 1 And flg_showlastyearweek = False And cal.GetWeekOfYear(Date.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) = firstWeek And firstWeekYear = Date.Today.Year Then
        If firstWeek > 1 And flg_showlastyearweek = False And cal.GetWeekOfYear(_date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) = firstWeek And firstWeekYear = _date.Year Then
            week = -1
        Else
            'week = cal.GetWeekOfYear(_date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
            If _date.Year = _date.AddDays(7).Year Then

                week = cal.GetWeekOfYear(_date.AddDays(7), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) 'avoid the first 7 days are count to be the day in last year
                week = week - 1
            Else

                week = cal.GetWeekOfYear(_date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
            End If
        End If
        Return week
    End Function

    Public Function GetWeekBaseYearByDate(ByVal _date As Date)
        Dim base_year As Integer = _date.Year

        If GetWeekByDate(_date, False) = -1 Then
            Return base_year - 1
        Else
            Return base_year
        End If

    End Function

    Public Function FirstDateOfWeekISO8601(ByVal year As Integer, ByVal weekOfYear As Integer) As Date
        Dim jan8 As DateTime = New DateTime(year, 1, 8) 'in some situation, (year,1,1) will be counted as the day in the week of last year. So jan8 is used
        Dim daysOffset As Integer = DayOfWeek.Thursday - jan8.DayOfWeek
        'Dim daysOffset As Integer = DayOfWeek.Monday - jan1.DayOfWeek
        Dim secondThursday As Date = jan8.AddDays(daysOffset)
        Dim cal As Calendar = New CultureInfo("en-US").Calendar
        '        Dim firstWeek As Integer = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        Dim firstWeek As Integer = cal.GetWeekOfYear(jan8, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 1
        Dim weekNum As Integer = weekOfYear
        If (firstWeek <= 1 Or firstWeek >= 52) And daysOffset > 0 Then
            weekNum -= 1
        End If

        Dim result As Date = secondThursday.AddDays((weekNum - 1) * 7)
        Return result.AddDays(-3) 'return the date of monday of first week under the standard of "CalendarWeekRule.FirstFourDayWeek" of "cal.GetWeekOfYear(jan8, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)"
    End Function

    Public Function LastDateOfWeekIS08601(ByVal year As Integer, ByVal weekOfYear As Integer) As Date
        Dim result As Date = FirstDateOfWeekISO8601(year, weekOfYear)
        Return result.AddDays(6)

    End Function

    Public Function LastWeekOfYear(ByVal year As Integer) As Integer
        Dim cal As Calendar = New CultureInfo("en-US").Calendar
        Dim lastday As Date = New DateTime(year, 12, 31)
        Dim lastWeek As Integer = cal.GetWeekOfYear(lastday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
        If lastday.DayOfWeek = DayOfWeek.Monday Or lastday.DayOfWeek = DayOfWeek.Tuesday Or lastday.DayOfWeek = DayOfWeek.Wednesday Then
            lastWeek = lastWeek - 1
        End If
        Return lastWeek
    End Function


    'Boolean Related Start
    Public Function isOverlappedYear_Date(ByVal _date As Date, ByVal _currentyear As Integer) As Boolean
        Dim lastweek As Integer = LastWeekOfYear(_currentyear - 1)

        Dim newyear_datefm As Date = New Date(_currentyear, 1, 1)
        Dim newyear_dateto As Date = LastDateOfWeekIS08601(_currentyear - 1, lastweek)

        If _date >= newyear_datefm And _date <= newyear_dateto Then
            Return True
        End If

        Return False
    End Function

    'Boolean Related Start

    'Generate String
    Public Function gen_WeekString(ByVal _year As Integer, ByVal _week As Integer) As String
        ' Return string like WEEK 14 - 3/2 to 5/14
        Dim dayfm As Date = FirstDateOfWeekISO8601(_year, _week)
        Dim dayto As Date = LastDateOfWeekIS08601(_year, _week)

        Dim str As String = "WEEK " + _week.ToString + " - " + dayfm.ToString("M/d") + " to " + dayto.ToString("M/d")
        Return str
    End Function

#End Region

#Region "Req Week Class"
    Public Class WeekDay
        Private _Mon As Boolean = False
        Private _Tue As Boolean = False
        Private _Wed As Boolean = False
        Private _Thur As Boolean = False
        Private _Fri As Boolean = False
        Private _Sat As Boolean = False
        Private _Sun As Boolean = False

        Public Sub New()
        End Sub

        Public Sub New(ByVal WeekDay() As Boolean)
            If WeekDay.Length = 7 Then
                _Mon = WeekDay(0)
                _Tue = WeekDay(1)
                _Wed = WeekDay(2)
                _Thur = WeekDay(3)
                _Fri = WeekDay(4)
                _Sat = WeekDay(5)
                _Sun = WeekDay(6)
            End If
        End Sub

        Public Sub New(ByVal WeekDay() As String)
            If WeekDay.Length = 7 Then
                _Mon = If(WeekDay(0) = "Y", True, False)
                _Tue = If(WeekDay(1) = "Y", True, False)
                _Wed = If(WeekDay(2) = "Y", True, False)
                _Thur = If(WeekDay(3) = "Y", True, False)
                _Fri = If(WeekDay(4) = "Y", True, False)
                _Sat = If(WeekDay(5) = "Y", True, False)
                _Sun = If(WeekDay(6) = "Y", True, False)
            End If
        End Sub

        'If true return "Y" else return ""
        Public Function to_YFormat(ByVal day As Integer) As String
            Dim YN As Boolean
            Select Case day
                Case 1
                    YN = Mon
                Case 2
                    YN = Tue
                Case 3
                    YN = Wed
                Case 4
                    YN = Thur
                Case 5
                    YN = Fri
                Case 6
                    YN = Sat
                Case 7
                    YN = Sun
            End Select

            If YN Then
                Return "Y"
            End If

            Return ""
        End Function

        Public Sub setReqDate(ByVal day As Integer, ByVal flag As Boolean)
            Select Case day
                Case 1
                    _Mon = flag
                Case 2
                    _Tue = flag
                Case 3
                    _Wed = flag
                Case 4
                    _Thur = flag
                Case 5
                    _Fri = flag
                Case 6 = flag
                    _Sat = flag
                Case 7
                    _Sun = flag
                Case Else
                    'Do nothing
            End Select

        End Sub

        Public Sub setReqDate(ByVal day As Integer, ByVal YN As String)
            Dim flag As Boolean
            If UCase(YN) = "Y" Then
                flag = True
            ElseIf UCase(YN) = "N" Or YN = "" Then
                flag = False
            End If

            Select Case day
                Case 1
                    _Mon = flag
                Case 2
                    _Tue = flag
                Case 3
                    _Wed = flag
                Case 4
                    _Thur = flag
                Case 5
                    _Fri = flag
                Case 6 = flag
                    _Sat = flag
                Case 7
                    _Sun = flag
                Case Else
                    'Do nothing
            End Select

        End Sub


        Public Property Mon() As Boolean
            Get
                Return _Mon
            End Get
            Set(ByVal value As Boolean)
                _Mon = value
            End Set
        End Property

        Public Property Tue() As Boolean
            Get
                Return _Tue
            End Get
            Set(ByVal value As Boolean)
                _Tue = value
            End Set
        End Property

        Public Property Wed() As Boolean
            Get
                Return _Wed
            End Get
            Set(ByVal value As Boolean)
                _Wed = value
            End Set
        End Property

        Public Property Thur() As Boolean
            Get
                Return _Thur
            End Get
            Set(ByVal value As Boolean)
                _Thur = value
            End Set
        End Property

        Public Property Fri() As Boolean
            Get
                Return _Fri
            End Get
            Set(ByVal value As Boolean)
                _Fri = value
            End Set
        End Property

        Public Property Sat() As Boolean
            Get
                Return _Sat
            End Get
            Set(ByVal value As Boolean)
                _Sat = value
            End Set
        End Property

        Public Property Sun() As Boolean
            Get
                Return _Sun
            End Get
            Set(ByVal value As Boolean)
                _Sun = value
            End Set
        End Property

    End Class

#End Region



End Module
