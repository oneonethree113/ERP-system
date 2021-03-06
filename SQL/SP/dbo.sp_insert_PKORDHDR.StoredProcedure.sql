/****** Object:  StoredProcedure [dbo].[sp_insert_PKORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKORDHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKORDHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------------------- 
CREATE PROCEDURE [dbo].[sp_insert_PKORDHDR] 

@poh_cocde nvarchar(6), 
@poh_ordno nvarchar(20), 
@poh_ver int,
@poh_issdat datetime, 
@poh_revdat datetime, 
@poh_status nvarchar(20), 
@poh_cus1no nvarchar(20), 
@poh_cus2no nvarchar(20), 
@poh_saldiv nvarchar(20), 
@poh_saltem nvarchar(20), 
@poh_salrep nvarchar(30), 
@poh_ToNo nvarchar(20), 
@poh_ToVer nvarchar(20), 
@poh_ToSts nvarchar(20), 
@poh_ToIsdat datetime, 
@poh_ToRevdat datetime, 
@poh_ToRefqut nvarchar(20), 
@poh_potyp nvarchar(20), 
@poh_ScNo nvarchar(20), 
@poh_ScVer nvarchar(20), 
@poh_ScSts nvarchar(20), 
@poh_ScIsdat datetime, 
@poh_ScRevdat datetime, 
@poh_ScPodat datetime, 
@poh_ScCandat datetime, 
@poh_ScShpdatstr datetime, 
@poh_ScShpdatend datetime, 
@poh_ScRemark nvarchar(300), 
@poh_Reqno nvarchar(20), 
@poh_Pkgven nvarchar(10),
@poh_address nvarchar(500),
@poh_ttlamt numeric(13,4),
@poh_ctnper  nvarchar(20),
@poh_tel	nvarchar(20),
@poh_Delamt numeric(13,4),
@poh_TtlDelamt numeric(13,4),
@poh_GenFlag nvarchar(10),
@poh_GenType nvarchar(10),
@poh_apvcnt int , 
@user nvarchar(30)


AS


insert into PKORDHDR
values
(@poh_cocde , 
@poh_ordno , 
@poh_ver ,
@poh_issdat , 
@poh_revdat , 
@poh_status , 
@poh_cus1no , 
@poh_cus2no , 
@poh_saldiv , 
@poh_saltem , 
@poh_salrep , 
@poh_ToNo , 
@poh_ToVer , 
@poh_ToSts , 
@poh_ToIsdat , 
@poh_ToRevdat , 
@poh_ToRefqut , 
@poh_potyp , 
@poh_ScNo , 
@poh_ScVer , 
@poh_ScSts , 
@poh_ScIsdat , 
@poh_ScRevdat , 
@poh_ScPodat , 
@poh_ScCandat , 
@poh_ScShpdatstr , 
@poh_ScShpdatend , 
@poh_ScRemark , 
@poh_Reqno , 
@poh_Pkgven ,
'01-01-1900' ,--as 'dvydat',
'' ,--as 'dremark',
'01-01-1900' , --as 'shpstr'
'01-01-1900' , --as 'shpend
'', --as 'fty'
@poh_address,
@poh_ttlamt,
@poh_ctnper,
@poh_tel,
@poh_Delamt ,
@poh_TtlDelamt,
@poh_GenFlag ,
@poh_GenType,
@poh_apvcnt , 
'N', --Default Re-print flag
@user,
@user ,
getdate(),
getdate(),
null,
'',
'',
'',
'',
'',
'',
'',
'',
'',
''
)














GO
GRANT EXECUTE ON [dbo].[sp_insert_PKORDHDR] TO [ERPUSER] AS [dbo]
GO
