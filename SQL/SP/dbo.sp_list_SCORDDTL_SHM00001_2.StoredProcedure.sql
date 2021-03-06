/****** Object:  StoredProcedure [dbo].[sp_list_SCORDDTL_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SCORDDTL_SHM00001_2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SCORDDTL_SHM00001_2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Johnson Lai
Date:		10th Jan, 2002
Description:	Select data From SCORDDTL (Cross check with customer)
Parameter:	1. Company
		2. Pri Customer
		3. Sec Customer 
		4.  SC No.	
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
2003-08-19	Allan Yuen	Fix Deadlock error.               
2004-01-28	Marco Chan	Add for getting netuntprc from SC
=========================================================     
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_list_SCORDDTL_SHM00001_2]

@sod_cocde	nvarchar(6),
@sod_ordno	nvarchar(20),
@sod_itmno	nvarchar(20) 
---------------------------------------------- 
 
AS
begin

Select 

sod_ordno, 
sod_ordseq, 
case isnull(sod_cuspo,'') when '' then soh_cuspo else sod_cuspo end  as 'sod_cuspo',
sod_itmno, 
sod_itmtyp,
sod_itmdsc,
sod_cusitm,
sod_colcde,
sod_cuscol,
sod_coldsc,
sod_pckunt,
sod_inrctn,
sod_mtrctn,
sod_mtrdcm,
sod_mtrwcm,
sod_mtrhcm,
sod_cbm,
--sod_ordqty - sod_shpqty as 'sod_shpqty',
0 as 'sod_shpqty',
sod_ordqty - sod_shpqty as 'sod_outqty',
--sod_ordqty  as 'sod_outqty',
sod_venno,
sod_cusven,
cast(sod_colcde as nvarchar(30)) + ' / ' + 
cast(sod_pckunt as nvarchar(6)) + ' / ' + 
cast(sod_inrctn as nvarchar(10)) + ' / ' + 
cast(sod_mtrctn as nvarchar(10)) + ' / ' + 
cast(sod_cbm as nvarchar(10)) as 'sod_colpck',
isnull(soh_cus1no,'') as 'soh_cus1no',
isnull(soh_cus2no,'') as 'soh_cus2no',
isnull(soh_prctrm,'') as 'soh_prctrm',
isnull(soh_paytrm,'') as 'soh_paytrm',
isnull(pod_jobord,'') as 'pod_jobord',
isnull(pod_purord,'') as 'pod_purord',
isnull(pod_purseq,0) as 'pod_purseq',
isnull(vbi_vennam,'') as 'vbi_vennam',
sod_untprc,
sod_netuntprc,
isnull(soh_ordsts,'') as 'soh_ordsts',
isnull(poh_pursts,'') as 'poh_pursts'



from SCORDDTL  (nolock)

inner join SCORDHDR (nolock) on sod_cocde = soh_cocde and sod_ordno = soh_ordno


LEFT join POORDDTL (nolock) on sod_cocde = pod_cocde and sod_ordno=pod_scno and sod_ordseq = pod_scline

left join POORDHDR (nolock) on sod_cocde = poh_cocde and pod_purord = poh_purord 

LEFT join VNBASINF (nolock) on 
	--sod_cocde = vbi_cocde and 
	sod_venno = vbi_venno



where 
sod_cocde = @sod_cocde and
sod_ordno = @sod_ordno  and
sod_itmno = @sod_itmno


order by 
sod_cocde, sod_ordno, sod_itmno, sod_colcde ,sod_pckunt,sod_inrctn,sod_mtrctn,sod_cbm
end




GO
GRANT EXECUTE ON [dbo].[sp_list_SCORDDTL_SHM00001_2] TO [ERPUSER] AS [dbo]
GO
