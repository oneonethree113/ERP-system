Module modGlobalConst
    'Database use only
    Public gsDB As String
    Public gsDBSvr As String

    Public gsDBRpt As String
    Public gsDBSvrRpt As String


    Public gsDBUsrID As String
    Public gsDBPwd As String

    Public gsConnStr As String
    Public gsConnStrRpt As String

    Public gsConnStrADO As String
    Public gsConnStrRptADO As String

    Public rtnLong As Long
    Public rtnStr As String

    Public gspStr As String

    'Return Code use only
    Public Const RC_SUCCESS As Long = 0
    Public Const RC_FAIL As Long = 1
    Public Const RC_NOTFOUND As Long = 2

    Public Const RC_ERROR As Long = 9000            ' Exception Catch Error
    Public Const RC_CONN_ERR As Long = 9001         ' SQL Get Connection Error
    Public Const RC_RUNSP_ERR As Long = 9002        ' Run Store procedure Error
    Public Const RC_DUPKEY_ERR As Long = 2627       ' Duplicate Primary Key Error


    'ERP General Use
    Public gsERPVer As String
    '    Public gsERPUsr As String
    Public gsCompany As String
    Public gsDefaultCompany As String
    Public gsCompanyGroup As String

    Public gsUsrID As String
    Public gsUsrGrp As String
    Public gsFlgCst As String
    Public gsFlgCstExt As String
    Public gsFlgRel As String
    Public gsUsrRank As Integer
    Public gsSalTem As String

    Public gsExpDay As Integer
    Public gsMoa As Double
    Public gsMoq As Integer
    Public gsCurcde As String
    Public gsTimeOut As Long

    Public rs As New DataSet
    Public rs_SYUSRPRF As New DataSet
    Public rs_SYCOMINF_NAME As New DataSet
    Public rs_SYUSRGRP_right As New DataSet

    Public Del_right As Boolean
    Public Enq_right As Boolean

    Public ItmImg_pth As String
    Public ItmImg_pth_6 As String
    Public ColImg_pth As String
    Public ColImg_pth_6 As String
    Public ShpMrk_pth As String
    Public gsReportPath As String
    Public gs_PDO_localpath As String
    Public gs_PDO_FtpSrvIP As String
    Public gs_PDO_FtpDrive As String
    Public gs_PDO_SMImg As String
    Public server_QC_destpth As String


    Public Const CFT_CBM As Decimal = 0.0283
    Public Const CBM_CFT As Decimal = 35.3356
    Public Const In_CM As Decimal = 2.54
    Public Const CM_In As Decimal = 0.3937

    Public gsSearchKey As String 'SAM00002 & SYM00022
    Public domapping_value As Integer 'SAM00002 & SYM00022

    Public SYM00021_Value As Integer
End Module
