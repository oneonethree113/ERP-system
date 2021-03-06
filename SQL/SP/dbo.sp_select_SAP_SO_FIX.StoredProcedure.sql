/****** Object:  StoredProcedure [dbo].[sp_select_SAP_SO_FIX]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SAP_SO_FIX]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SAP_SO_FIX]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO







CREATE procedure [dbo].[sp_select_SAP_SO_FIX]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@cocde nvarchar(6) 
             

---------------------------------------------- 
 
AS


begin

select 

soh_cus1no as 'KUNNR',
sod_zorvbeln as 'VBELN',
sod_zorposnr as 'POSNR',
sod_itmno as 'MATNR',
case when sod_dvftyprc > 0 then sod_dvftyprc else sod_ftyprc end as 'COST_UPD',
poh_curcde as 'COSTCURR_UPD',
'' as 'ORDER'
from scorddtl
inner join scordhdr on sod_ordno = soh_ordno
inner join poorddtl on sod_ordno = pod_scno and sod_ordseq = pod_scline
inner join poordhdr on poh_purord = pod_purord
where sod_zorvbeln <> '' and sod_zorposnr <> '' and sod_zorposnr <> '999999'
and
( sod_zorvbeln like 'WT%' or sod_zorvbeln like '101101%' or sod_zorvbeln like '102101%' or sod_zorvbeln like '103101%' or sod_zorvbeln like '104101%' )


order by sod_zorvbeln, sod_zorposnr asc




/*

<KUNNR>50068</KUNNR>
<VBELN>1011000000</VBELN>
<POSNR>000010</POSNR>
<MATNR>06B76SVS18BAC</MATNR>
<COST_UPD>4.25</COST_UPD>
<COSTCURR_UPD>HKD</COSTCURR_UPD>

*/
end



GO
GRANT EXECUTE ON [dbo].[sp_select_SAP_SO_FIX] TO [ERPUSER] AS [dbo]
GO
