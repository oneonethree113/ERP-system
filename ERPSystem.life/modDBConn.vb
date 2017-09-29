Imports System.Data
Imports System.Data.SqlClient

Imports System.IO


Module modDBConn

    Public Function getConnStr(ByRef brConnStr As String, ByRef rString As String, Optional ByVal type As String = "CON-DB") As Long
        Try
            Dim strPath As String
            strPath = Application.StartupPath

            Dim re As StreamReader
            re = New StreamReader(strPath + "\startup.txt")

            Dim input As String
            input = ""

            Dim strTmp() As String

            input = re.ReadToEnd()

            strTmp = input.Split("##")

            gsDB = strTmp(4).Trim()
            gsDBSvr = strTmp(8).Trim()

            gsDBRpt = strTmp(12).Trim()
            gsDBSvrRpt = strTmp(16).Trim()

            'gsDBUsrID = "sa"
            'gsDBPwd = ""
            gsDBUsrID = "ERP_USER"
            gsDBPwd = "erpsystem"
            'gsDB = "MSDEV"
            'gsSvr = "MCNB"

            Select Case type
                Case "CON-DB"
                    brConnStr = "Data Source=" & gsDBSvr & "; Initial Catalog=" & gsDB & "; User ID=" & gsDBUsrID & "; Password=" & gsDBPwd
                Case "CON-RPT"
                    brConnStr = "Data Source=" & gsDBSvrRpt & "; Initial Catalog=" & gsDBRpt & "; User ID=" & gsDBUsrID & "; Password=" & gsDBPwd
                Case "ADO-DB"
                    brConnStr = "provider=sqloledb;server=" & gsDBSvr & ";database=" & gsDB & ";uid=" & gsDBUsrID & ";password=" & gsDBPwd
                Case "ADO-RPT"
                    brConnStr = "provider=sqloledb;server=" & gsDBSvrRpt & ";database=" & gsDBRpt & ";uid=" & gsDBUsrID & ";password=" & gsDBPwd
                Case ""
            End Select



            If brConnStr <> "" Then
                getConnStr = RC_SUCCESS
            Else
                getConnStr = RC_FAIL
            End If

        Catch ex As Exception
            getConnStr = RC_ERROR
            rString = ex.ToString
            gsDBUsrID = "sa"
            gsDBPwd = ""
            gsDB = "MSDEV"
            gsDBSvr = "MCNB"
            brConnStr = "Data Source=" & gsDBSvr & "; Initial Catalog=" & gsDB & "; User ID=" & gsDBUsrID & "; Password=" & gsDBPwd
        End Try
    End Function

    Public Function execute_StoredProcedure(ByVal spStr As String, ByVal spPara As Object(), ByRef result As DataSet, ByRef rString As String) As Long
        Try
            If gsConnStr = "" Then
                execute_StoredProcedure = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As SqlConnection = New SqlConnection(gsConnStr)
            cn.Open()

            Dim cmdSQL As New SqlCommand(spStr, cn)
            cmdSQL.CommandType = CommandType.StoredProcedure

            Dim i As Integer
            For i = 0 To spPara.Length - 1
                Dim sqlPara As New SqlParameter
                sqlPara.Value = spPara(i)
                cmdSQL.Parameters.Add(sqlPara)
            Next i

            Dim daSQL As SqlDataAdapter = New SqlDataAdapter(cmdSQL)
            Dim r As New DataSet

            daSQL.SelectCommand.CommandTimeout = 6000

            daSQL.Fill(r, "RESULT")

            result = r

            result.Tables("RESULT").DefaultView.AllowNew = False

            For i = 0 To result.Tables("RESULT").Columns.Count - 1
                result.Tables("RESULT").Columns(i).ReadOnly = True
            Next i

            cn.Close()

            execute_StoredProcedure = RC_SUCCESS

        Catch ex As Exception
            execute_StoredProcedure = RC_ERROR
            rString = ex.ToString
        End Try
    End Function

    Public Function execute_SQLStatement(ByVal sqlstr As String, ByRef result As DataSet, ByRef rString As String) As Long
        Try
            If gsConnStr = "" Then
                execute_SQLStatement = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As SqlConnection = New SqlConnection(gsConnStr)
            cn.Open()

            Dim dscmd As New SqlDataAdapter(sqlstr, cn)
            Dim r As New DataSet

            dscmd.SelectCommand.CommandTimeout = 6000

            dscmd.Fill(r, "RESULT")

            result = r

            If result.Tables.Count > 0 Then
                result.Tables("RESULT").DefaultView.AllowNew = False

                Dim i As Integer
                For i = 0 To result.Tables("RESULT").Columns.Count - 1
                    result.Tables("RESULT").Columns(i).ReadOnly = True
                Next i

            End If

            cn.Close()

            execute_SQLStatement = RC_SUCCESS

        Catch ex As Exception
            execute_SQLStatement = RC_ERROR
            rString = ex.ToString
        End Try
    End Function


    Public Function execute_SQLStatement_ADO(ByVal sqlstr As String, ByRef result As ADODB.Recordset, ByRef rString As String) As Long
        Try
            If gsConnStrADO = "" Then
                execute_SQLStatement_ADO = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As New ADODB.Connection
            cn.ConnectionString = gsConnStrADO
            cn.CommandTimeout = 0
            cn.Open()

            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

            rs.Open(sqlstr, cn)
            rs.ActiveConnection = Nothing

            result = rs
            cn.Close()
        Catch ex As Exception
            execute_SQLStatement_ADO = RC_ERROR
            rString = ex.ToString
        End Try

    End Function


    Public Function execute_StoredProcedure_ADO(ByVal spStr As String, ByVal spPara As Object(), ByRef result As ADODB.Recordset, ByRef rString As String) As Long
        Try
            If gsConnStrADO = "" Then
                execute_StoredProcedure_ADO = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As New ADODB.Connection
            cn.ConnectionString = gsConnStrADO
            cn.Open()

            Dim cmd As New ADODB.Command

            cmd.CommandText = spStr
            cmd.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc
            cmd.ActiveConnection = cn

            'rs = cmd.Execute

            Dim para As New ADODB.Parameter

            Dim i As Integer
            For i = 0 To spPara.Length - 1
                Dim sqlPara As New SqlParameter
                sqlPara.Value = spPara(i)

                '                cmd.CreateParameter("", 
            Next i


            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

            rs.Open(spStr, cn)
            rs.ActiveConnection = Nothing

            result = rs
            cn.Close()

        Catch ex As Exception
            execute_StoredProcedure_ADO = RC_ERROR
            rString = ex.ToString
        End Try
    End Function



    Public Function execute_StoredProcedureRPT(ByVal spStr As String, ByVal spPara As Object(), ByRef result As DataSet, ByRef rString As String) As Long
        Try
            If gsConnStrRpt = "" Then
                execute_StoredProcedureRPT = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As SqlConnection = New SqlConnection(gsConnStrRpt)
            cn.Open()

            Dim cmdSQL As New SqlCommand(spStr, cn)
            cmdSQL.CommandType = CommandType.StoredProcedure

            Dim i As Integer
            For i = 0 To spPara.Length - 1
                Dim sqlPara As New SqlParameter
                sqlPara.Value = spPara(i)
                cmdSQL.Parameters.Add(sqlPara)
            Next i

            Dim daSQL As SqlDataAdapter = New SqlDataAdapter(cmdSQL)
            Dim r As New DataSet

            daSQL.SelectCommand.CommandTimeout = 6000

            daSQL.Fill(r, "RESULT")

            result = r

            result.Tables("RESULT").DefaultView.AllowNew = False

            For i = 0 To result.Tables("RESULT").Columns.Count - 1
                result.Tables("RESULT").Columns(i).ReadOnly = True
            Next i

            cn.Close()

            execute_StoredProcedureRPT = RC_SUCCESS

        Catch ex As Exception
            execute_StoredProcedureRPT = RC_ERROR
            rString = ex.ToString
        End Try
    End Function

    Public Function execute_SQLStatementRPT(ByVal sqlstr As String, ByRef result As DataSet, ByRef rString As String) As Long
        Try
            If gsConnStrRpt = "" Then
                execute_SQLStatementRPT = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As SqlConnection = New SqlConnection(gsConnStrRpt)
            cn.Open()

            Dim dscmd As New SqlDataAdapter(sqlstr, cn)
            Dim r As New DataSet

            dscmd.SelectCommand.CommandTimeout = 6000

            dscmd.Fill(r, "RESULT")

            result = r

            If result.Tables.Count > 0 Then
                result.Tables("RESULT").DefaultView.AllowNew = False

                Dim i As Integer
                For i = 0 To result.Tables("RESULT").Columns.Count - 1
                    result.Tables("RESULT").Columns(i).ReadOnly = True
                Next i

            End If

            cn.Close()

            execute_SQLStatementRPT = RC_SUCCESS

        Catch ex As Exception
            execute_SQLStatementRPT = RC_ERROR
            rString = ex.ToString
        End Try
    End Function


    Public Function execute_SQLStatementRPT_ADO(ByVal sqlstr As String, ByRef result As ADODB.Recordset, ByRef rString As String) As Long
        Try
            If gsConnStrRptADO = "" Then
                execute_SQLStatementRPT_ADO = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As New ADODB.Connection
            cn.ConnectionString = gsConnStrRptADO
            cn.CommandTimeout = 0
            cn.Open()

            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

            rs.Open(sqlstr, cn)
            rs.ActiveConnection = Nothing

            result = rs
            cn.Close()
        Catch ex As Exception
            execute_SQLStatementRPT_ADO = RC_ERROR
            rString = ex.ToString
        End Try

    End Function


    Public Function execute_StoredProcedureRPT_ADO(ByVal spStr As String, ByVal spPara As Object(), ByRef result As ADODB.Recordset, ByRef rString As String) As Long
        Try
            If gsConnStrRptADO = "" Then
                execute_StoredProcedureRPT_ADO = RC_CONN_ERR
                Exit Function
            End If

            Dim cn As New ADODB.Connection
            cn.ConnectionString = gsConnStrRptADO
            cn.Open()

            Dim cmd As New ADODB.Command

            cmd.CommandText = spStr
            cmd.CommandType = ADODB.CommandTypeEnum.adCmdStoredProc
            cmd.ActiveConnection = cn

            'rs = cmd.Execute

            Dim para As New ADODB.Parameter

            Dim i As Integer
            For i = 0 To spPara.Length - 1
                Dim sqlPara As New SqlParameter
                sqlPara.Value = spPara(i)

                '                cmd.CreateParameter("", 
            Next i


            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

            rs.Open(spStr, cn)
            rs.ActiveConnection = Nothing

            result = rs
            cn.Close()

        Catch ex As Exception
            execute_StoredProcedureRPT_ADO = RC_ERROR
            rString = ex.ToString
        End Try
    End Function



End Module
