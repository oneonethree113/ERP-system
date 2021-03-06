/****** Object:  StoredProcedure [dbo].[sp_list_POQCRpt]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_POQCRpt]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_POQCRpt]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_list_POQCRpt]
@cocde		nvarchar(6),	
@POfrom		nvarchar(20),	
--@POto		nvarchar(20),
@usrid		nvarchar(30)

AS

--create table #TEMP_PONO (tmp_pono nvarchar(20)) on [PRIMARY]
--select * from QCRPTHDR
--select * from QCRPTDTL

select 
distinct
qrh_postr  as PO, 
qrh_tmprptno as 'rpt',
qrh_qcno as 'qc',
qrh_itmno as itm, 
qrh_cusitm as cuitm, 
qrh_itmdsc as itmdsc, 
convert(varchar(20),qrh_inspdat,101) as 'insdat',
case qrh_rpttyp when 'F' then 'Final' else 'In-Line' end as 'type',

qrh_rptstatus qrh_rptstatus, 
qrh_inspresult   qrd_inspresult,

qrh_finalstatus as 'finalstatus', 

qrh_shipapprv qrh_shipapprv,

qrh_tmprptno + '.pdf' as 'pdf'
--isnull(puf_filepath,'')
--'test.pdf'
from QCRPTHDR (nolock) 
left join QCRPTDTL (nolock) on qrd_tmprptno = qrh_tmprptno
--left join POULFILE (nolock) on puf_ordno = qrh_tmprptno
where qrh_postr like '%' + @POfrom + '%'



GO
GRANT EXECUTE ON [dbo].[sp_list_POQCRpt] TO [ERPUSER] AS [dbo]
GO
