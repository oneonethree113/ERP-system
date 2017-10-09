Public Class CUM00003
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim EditModeHdr As String

    Dim CanModify As Boolean ' Check for access right

    Dim Current_TimeStamp As Long 'For current record's time stamp

    Dim sort_cusitm_sum As Boolean
    Dim sort_itmno_sum As Boolean

    Dim sort_cusitm_dtl As Boolean
    Dim sort_itmno_dtl As Boolean

    Dim rs_CUBASINF_CR As New DataSet
    Dim rs_SYTIESTR As New DataSet
    Dim rs_SYUSRRIGHT As New DataSet

    Public rs_CUBASINF As New DataSet
    'Public rs_CUITMSUM As New DataSet

    ' Public rs_CUITMDTL As New DataSet

    Public rs_CUITMHIS As New DataSet
    Public rs_CUITMPRC As New DataSet
    Private Sub Display()
        '*** Folder 1
        'Retrieve MOQ/MOA
        ' Call cal_MOQMOA()

        ' grdCuItmHis.DataSource = rs_CUITMHIS.Tables("RESULT").DefaultView

        Call Display_grdCuItmHis()

        '*** Folder 2
        'grdCuItmPRC.DataSource = rs_CUITMPRC.Tables("RESULT").DefaultView

        Call Display_grdCuItmPRC()
    End Sub
    Private Sub Display_grdCuItmPRC()
        If rs_CUITMPRC.Tables.Count = 0 Then
            Exit Sub
        End If

        grdCuItmPRC.DataSource = rs_CUITMPRC.Tables("RESULT").DefaultView

        grdCuItmPRC.RowHeadersWidth = 18
        grdCuItmPRC.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCuItmPRC.ColumnHeadersHeight = 18
        grdCuItmPRC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCuItmPRC.AllowUserToResizeColumns = True
        grdCuItmPRC.AllowUserToResizeRows = False
        grdCuItmPRC.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUITMPRC.Tables("RESULT").Columns.Count - 1
            rs_CUITMPRC.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Comp"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Pri Cust"
        grdCuItmPRC.Columns(i).Width = 70
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Sec Cust"
        grdCuItmPRC.Columns(i).Width = 70
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Item No."
        grdCuItmPRC.Columns(i).Width = 130
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "DV"
        grdCuItmPRC.Columns(i).Width = 40
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "PV"
        grdCuItmPRC.Columns(i).Width = 40
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Color Code"
        grdCuItmPRC.Columns(i).Width = 110
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "U/M"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Con Ftr"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Inner"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Master"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmPRC.Columns(i).HeaderText = "CFT"
        grdCuItmPRC.Columns(i).Width = 60
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmPRC.Columns(i).HeaderText = "CBM"
        grdCuItmPRC.Columns(i).Width = 60
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "HK Prc Term"
        grdCuItmPRC.Columns(i).Width = 70
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Fty Prc Term"
        grdCuItmPRC.Columns(i).Width = 70
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Tran Term"
        grdCuItmPRC.Columns(i).Width = 70
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "PriceKey(Pri)"
        grdCuItmPRC.Columns(i).Width = 110
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "PriceKey(Sec)"
        grdCuItmPRC.Columns(i).Width = 110
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Eff Date"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Exp Date"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Ref Doc"
        grdCuItmPRC.Columns(i).Width = 90
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Ref Seq"
        grdCuItmPRC.Columns(i).Width = 60
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Doc Date"
        grdCuItmPRC.Columns(i).Width = 100
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Fty Curr"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Fty Cost"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "BOM Cost"
        grdCuItmPRC.Columns(i).Width = 90
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Fty Price"
        grdCuItmPRC.Columns(i).Width = 90
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Curr"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Basic Price"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "MU%"
        grdCuItmPRC.Columns(i).Width = 50
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "MU Price"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        grdCuItmPRC.Columns(i).Visible = False
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Min MU%"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        'grdCuItmPRC.Columns(i).Visible = False
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Min MU Price"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        'grdCuItmPRC.Columns(i).Visible = False
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Packing Cost"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Comm %"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Item Comm $"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Std Price"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Disc %"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        grdCuItmPRC.Columns(i).Visible = False
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Adj Price"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "Period"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_Status = i
        grdCuItmPRC.Columns(i).HeaderText = "IM Period"
        grdCuItmPRC.Columns(i).Width = 80
        grdCuItmPRC.Columns(i).ReadOnly = True
        grdCuItmPRC.Columns(i).Visible = False


    End Sub
    Private Sub Display_grdCuItmHis()
        If rs_CUITMHIS.Tables.Count = 0 Then
            Exit Sub
        End If

        grdCuItmHis.DataSource = rs_CUITMHIS.Tables("RESULT").DefaultView

        grdCuItmHis.RowHeadersWidth = 18
        grdCuItmHis.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCuItmHis.ColumnHeadersHeight = 18
        grdCuItmHis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCuItmHis.AllowUserToResizeColumns = True
        grdCuItmHis.AllowUserToResizeRows = False
        grdCuItmHis.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUITMHIS.Tables("RESULT").Columns.Count - 1
            rs_CUITMHIS.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        'grdCuItmHis_Status = i
        grdCuItmHis.Columns(i).HeaderText = "Comp"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Pri Cust"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Pri Cust Name"
        grdCuItmHis.Columns(i).Width = 110
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Sec Cust"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Sec Cust Name"
        grdCuItmHis.Columns(i).Width = 110
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Item No"
        grdCuItmHis.Columns(i).Width = 130
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Item Desc"
        grdCuItmHis.Columns(i).Width = 120
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Cust Item No"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Cust Style No"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Color Code"
        grdCuItmHis.Columns(i).Width = 110
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Color Desc"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Cust Color"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "U/M"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Con Ftr"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Inner"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Master"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "CFT"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "CBM"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "HK Prc Term"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Fty Prc Term"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Tran Term"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Packing Instruction"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "DV"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "CV"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "PV"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "TV"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "FA"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "PriceKey (Pri)"
        grdCuItmHis.Columns(i).Width = 100
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "PriceKey (Sec)"
        grdCuItmHis.Columns(i).Width = 100
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Ref Doc#"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Doc Date"
        grdCuItmHis.Columns(i).Width = 110
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Qut No"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Qut Seq"
        grdCuItmHis.Columns(i).Width = 70
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Cust SKU #"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Ord Qty"
        grdCuItmHis.Columns(i).Width = 70
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "MOQ Chg"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        grdCuItmHis.Columns(i).Visible = False
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "HSTU / Tariff #"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Duty %"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Dept"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "EAN or UPC"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Code (Merchandise)"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Code (Inner)"
        grdCuItmHis.Columns(i).Width = 100
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Code (Carton)"
        grdCuItmHis.Columns(i).Width = 100
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Retail1 Curr"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Retail1 Price"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Retail2 Curr"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Retail2 Price"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Inner in (DxWxH)"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Master in (DxWxH)"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Inner cm (DxWxH)"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Master cm (DxWxH)"
        grdCuItmHis.Columns(i).Width = 140
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Ven Type"
        grdCuItmHis.Columns(i).Width = 70
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Tier Type"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "MOQ Unit"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "MOQ"
        grdCuItmHis.Columns(i).Width = 40
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "MOA Curr"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "MOA"
        grdCuItmHis.Columns(i).Width = 60
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Convert To PC"
        grdCuItmHis.Columns(i).Width = 90
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "PC Price"
        grdCuItmHis.Columns(i).Width = 70
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Fty Temp Item"
        grdCuItmHis.Columns(i).Width = 110
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Year"
        grdCuItmHis.Columns(i).Width = 50
        grdCuItmHis.Columns(i).ReadOnly = True
        i = i + 1
        'grdCuItmHis_csi_csetyp = i
        grdCuItmHis.Columns(i).HeaderText = "Season"
        grdCuItmHis.Columns(i).Width = 80
        grdCuItmHis.Columns(i).ReadOnly = True
       
    End Sub
    Private Sub CUM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call AccessRight(Me.Name)

        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Cursor = Cursors.WaitCursor

        '*** Folder 1   **********
        txtCusNo.MaxLength = 6
        'txtItmNo.MaxLength = 20
        txtCusNo.MaxLength = 20

        '*** Folder 2   **********

        CanModify = True

        Me.KeyPreview = True

        Call setStatus("Init")

        Call Formstartup(Me.Name)   'Set the form Sartup position

        Cursor = Cursors.Default
    End Sub

    Private Sub setStatus(ByVal Mode As String)
        If Mode = "Init" Then
            'Call SetInputBoxesStatus("DisableAll")
            cmdAdd.Enabled = Enq_right
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = Enq_right
            cmdFind.Enabled = True
            'CmdLookup.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            'cmdspecial.Enabled = False
            'cmdbrowlist.Enabled = True

            cmdAdd.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            txtCusNo.Enabled = True
            txtSecCus.Enabled = True
            txtCusNam.Enabled = False
            txtSecSna.Enabled = False
            txtItmNo.Enabled = True
            txtCusItm.Enabled = True
            txtCusStyNo.Enabled = True
            chbAlias.Enabled = False
            btcCUM00002.SelectedIndex = 0
            Call ResetDefaultDisp()

            '*** Enable key field(s) in header
            txtCusNo.Enabled = True

            cmdBrowse.Enabled = True
            cmdMapping.Enabled = True
        ElseIf Mode = "Updating" Then
            'Call SetInputBoxesStatus("EnableAll")
            cmdBrowse.Enabled = True
            cmdMapping.Enabled = True

            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right
            cmdDelete.Enabled = Del_right
            cmdCopy.Enabled = Enq_right
            cmdFind.Enabled = False
            'CmdLookup.Enabled = True
            cmdInsRow.Enabled = Enq_right
            cmdDelRow.Enabled = Del_right
            cmdExit.Enabled = True
            cmdClear.Enabled = True

            cmdSave.Enabled = False
            cmdDelete.Enabled = False

            txtCusNo.Enabled = False
            txtSecCus.Enabled = False
            txtCusNam.Enabled = False
            txtSecSna.Enabled = False
            txtItmNo.Enabled = False
            txtCusItm.Enabled = False
            txtCusStyNo.Enabled = False
            chbAlias.Enabled = False

            If EditModeHdr = "ADD" Then
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
            ElseIf EditModeHdr = "Updating" Then
                cmdAdd.Enabled = False
            End If

            grdCuItmHis.Focus()
            'grdCuItmSum_Click()
        ElseIf Mode = "Clear" Then
            Call ResetDefaultDisp()
            Call setStatus("Init")
            txtCusNo.SelectAll()
        End If

        'Check for access right
        If Not CanModify Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
        End If
    End Sub
    Private Sub ResetDefaultDisp()
        txtCusNam.Text = ""
        txtSecSna.Text = ""
        chbAlias.Enabled = True
        chbAlias.Checked = True
        grdCuItmHis.DataSource = Nothing
        grdCuItmPRC.DataSource = Nothing

        StatusBar.Panels(0).Text = ""
        StatusBar.Panels(1).Text = ""
    End Sub

    Private Sub cmdMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMapping.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            Dim frm_SYM00022 As New SYM00022(txtItmNo.Text)

            frm_SYM00022.MdiParent = Me.MdiParent

            If domapping_value = 1 Then
                frm_SYM00022.Show()
                AddHandler frm_SYM00022.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            End If
        End If
    End Sub
    Private Sub returnSelectedRecordsHandler(ByVal sender As Object)
        If Len(gsSearchKey) > 0 And txtItmNo.Enabled = True Then
            txtItmNo.Text = gsSearchKey
            txtItmNo.Refresh()
            txtCusItm.Focus()
        End If
    End Sub

    Private Sub cmdBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrowse.Click
        gsSearchKey = ""
        If txtItmNo.Text <> "" Then
            Dim frm_SYM00021 As New SYM00021(txtItmNo.Text)

            frm_SYM00021.MdiParent = Me.MdiParent

            If SYM00021_Value = 1 Then
                frm_SYM00021.Show()
                AddHandler frm_SYM00021.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
            End If
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        cmdFindClick()
    End Sub

    Private Sub cmdFindClick()
        Dim lngDtl As Integer
        Dim lngSum As Integer
        lngDtl = 0
        lngSum = 0

        If (Trim(txtCusNo.Text) = "") Then
            txtCusNo.Focus()
            MsgBox("Please input Customer No.")
            Exit Sub
        End If

        '*** query Primary Customer
        'S = "㊣CUBASINF※S※" & txtCusNo.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUBASINF '" & gsCompany & "','" & txtCusNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFindClick sp_select_CUBASINF 1 :" & rtnStr)
            Exit Sub
        End If

        If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("Customer Not Found!")
            txtCusNo.SelectAll()
            Exit Sub
        Else
            If gsSalTem <> rs_CUBASINF.Tables("RESULT").Rows(0)("ysr_saltem").ToString And _
                gsSalTem <> "" And gsSalTem <> "S" Then

                'S = "㊣SYUSRRIGHT_Check※S※" & gsUsrID & "※" & txtCusNo.Text & "※CU"
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & txtCusNo.Text & "','CU'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFindClick sp_select_SYUSRRIGHT_Check :" & rtnStr)
                    Exit Sub
                End If

                If rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("You have no Right access this document.")
                    Exit Sub
                End If
            End If

            txtCusNo.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusno")
            txtCusNam.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusnam_id")

            If txtSecCus.Text <> "" Then
                '*** query Secondary Customer
                'S = "㊣CUBASINF※S※" & txtSecCus.Text
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gspStr = "sp_select_CUBASINF '" & gsCompany & "','" & txtSecCus.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFindClick sp_select_CUBASINF 2 :" & rtnStr)
                    Exit Sub
                End If

                If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                    MsgBox("Customer Not Found!")
                    txtSecCus.SelectAll()
                    Exit Sub
                Else
                    txtSecSna.Text = rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_cusnam_id")
                End If
            End If

            StatusBar.Panels(1).Text = Format(rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_credat"), "MM/dd/yyyy") & " " & _
                                        Format(rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_upddat"), "MM/dd/yyyy") & " " & _
                                        rs_CUBASINF.Tables("RESULT").Rows(0)("cbi_updusr")

            '***************************************************
            '*** Get Customer Details record  ******************
            '***************************************************
            Dim message As String = ""

            Cursor = Cursors.WaitCursor

            If chbAlias.Checked = False Then
                'S = "㊣CUITMDTL2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMHIS '" & txtCusNo.Text & "','" & _
                                                  txtSecCus.Text & "','" & _
                                                  txtItmNo.Text & "','" & _
                                                  txtCusItm.Text & "','" & _
                                                  txtCusStyNo.Text & "'"

                message = "sp_select_CUITMHIS"
            Else
                'S = "㊣CUITMDTL_alias2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMHIS '" & txtCusNo.Text & "','" & _
                                                 txtSecCus.Text & "','" & _
                                                 txtItmNo.Text & "','" & _
                                                 txtCusItm.Text & "','" & _
                                                 txtCusStyNo.Text & "'"

                message = "sp_select_CUITMHIS"
            End If
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            rtnLong = execute_SQLStatement(gspStr, rs_CUITMHIS, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFindClick " & message & " :" & rtnStr)
                Exit Sub
            End If

            '*** check record count
            lngDtl = rs_CUITMHIS.Tables("RESULT").DefaultView.Count
            '***************************************************
            '*** Get Customer Details record end ***************
            '***************************************************

            '***************************************************
            '*** Get Customer Summary record  ******************
            '***************************************************
            If chbAlias.Checked = False Then
                'S = "㊣CUITMSUM2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMPRC '" & txtCusNo.Text & "','" & _
                                                    txtSecCus.Text & "','" & _
                                                    txtItmNo.Text & "','" & _
                                                    txtCusItm.Text & "','" & _
                                                    txtCusStyNo.Text & "'"
                message = "sp_select_CUITMPRC"
            Else
                'S = "㊣CUITMSUM_alias2※S※" & txtItmNo.Text & "※" & txtCusItm.Text & "※" & txtSecCus.Text & "※" & txtCusNo.Text & "※" & txtCusStyNo.Text & "※" & gsFlgCst & "※" & gsFlgCstExt
                gspStr = "sp_select_CUITMPRC '" & txtCusNo.Text & "','" & _
                                                  txtSecCus.Text & "','" & _
                                                  txtItmNo.Text & "','" & _
                                                  txtCusItm.Text & "','" & _
                                                  txtCusStyNo.Text & "'"
                message = "sp_select_CUITMSUM_alias"
            End If
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            rtnLong = execute_SQLStatement(gspStr, rs_CUITMPRC, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFindClick " & message & " :" & rtnStr)
                Exit Sub
            End If

            '*** check record count
            lngSum = rs_CUITMPRC.Tables("RESULT").DefaultView.Count
            lngDtl = rs_CUITMHIS.Tables("RESULT").DefaultView.Count
            '***************************************************
            '*** Get Customer Summary record end ***************
            '***************************************************
            If lngDtl = 0 And lngSum = 0 Then
                MsgBox("No record found!")
                Exit Sub
            End If

            Call Display()
            Call setStatus("Updating")

            grdCuItmHis.Focus()
        End If

        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txtItmNo.Name
        frmComSearch.callFmString = txtItmNo.Text

        frmComSearch.show_CUM00003(Me)
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Call setStatus("Clear")
        If txtCusItm.Text <> "" And txtCusItm.Enabled = True Then
            txtCusItm.SelectAll()
        ElseIf txtItmNo.Text <> "" And txtItmNo.Enabled = True Then
            txtItmNo.SelectAll()
        ElseIf txtCusNo.Enabled = True Then
            txtCusNo.SelectAll()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class