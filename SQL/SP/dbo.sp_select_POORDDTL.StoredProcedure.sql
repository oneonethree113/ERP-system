/****** Object:  StoredProcedure [dbo].[sp_select_POORDDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_POORDDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_POORDDTL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen 27/07/2003

------------------------------------------------- 
CREATE procedure [dbo].[sp_select_POORDDTL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@pod_cocde nvarchar(6) ,
@pod_purord nvarchar(20)                                                
---------------------------------------------- 
 
AS

begin
Select 
pod_purseq,
pod_itmno,		
isnull(pod_jobord,'') as 'pod_jobord',	
isnull(sod_subcde, '') as 'sod_subcde',
pod_venitm,
pod_cusitm,
pod_cussku,
isnull(pod_vencol,'') as 'pod_vencol',
pod_cuscol,
pod_coldsc,
ltrim(pod_untcde)+' / '+ltrim(str(pod_inrctn))+' / '+ltrim(str(pod_mtrctn))+' / '+ltrim(str(pod_cubcft,11,4)) as 'packinfo',
pod_pckitr,
pod_ordqty,
pod_recqty,
poh_curcde,
pod_ftyprc,
pod_ctnstr,
pod_ctnend,
pod_ttlctn,
pod_shpstr = convert(char(10), pod_shpstr,101),
pod_shpend = convert(char(10), pod_shpend,101),
isnull(convert( nvarchar(10),Case pod_candat when '1900-01-01' 
Then 
	null 
else
	cast(pod_candat as datetime)
end,101),'  /  /    ') as 'pod_candat',
isnull(pod_hrmcde,'') as 'pod_hrmcde',
pod_dtyrat,
pod_code1,
pod_code2,
pod_code3,
pod_cususd,
pod_cuscad


from POORDDTL
left join POORDHDR on poh_cocde = pod_cocde and poh_purord = pod_purord
left join SCORDDTL on sod_cocde = pod_cocde and sod_ordno = pod_scno and sod_ordseq = pod_scline

WHERE                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
pod_cocde = @pod_cocde and
pod_purord = @pod_purord
order by pod_purseq
---------------------------------------------------------- 
end




GO
GRANT EXECUTE ON [dbo].[sp_select_POORDDTL] TO [ERPUSER] AS [dbo]
GO
