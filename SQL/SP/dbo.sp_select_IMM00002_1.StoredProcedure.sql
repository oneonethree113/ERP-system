/****** Object:  StoredProcedure [dbo].[sp_select_IMM00002_1]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMM00002_1]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMM00002_1]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE procedure [dbo].[sp_select_IMM00002_1]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_cocde nvarchar(6) ,
@imu_itmno nvarchar(20) 
                                               
---------------------------------------------- 
 
AS


begin
 Select 
' ' as 'imu_status',
imu_cocde,
imu_itmno,
imu_typ,
imu_ventyp,
imu_relatn,
imu_venno,
imu_prdven,
imu_pckseq,
imu_pckunt,
imu_inrqty,
imu_mtrqty,
imu_cft,
cast(imu_pckunt as nvarchar(10) )+ ' / ' +
cast(imu_inrqty  as nvarchar(10) )+ ' / ' +
cast(imu_mtrqty as nvarchar(10) )+ ' / ' +
cast(imu_cft as nvarchar(20) )	    as 'imu_packing',
imu_curcde,
imu_ftycst,
imu_ftyprc,
cast(imu_fmlopt as nvarchar(10))  +  ' - ' + cast(yfi_fml as nvarchar(50) ) as 'imu_fmlopt',
yfi_prcfml,
imu_bcurcde,
imu_basprc,
cast(imu_fmlopt as nvarchar(10))  +  ' - ' + cast(yfi_fml as nvarchar(50) ) as 'imu_fmlopt_Production',
imu_curcde as 'imu_Calcurcde',
imu_calftyprc,
imu_negprc,
imu_prctrm,
imu_creusr,
imu_updusr,
imu_credat,
imu_upddat,
cast(imu_timstp as int ) as imu_timstp,
round(imu_calftyprc / isnull(ycf_value,1),4) as 'Cal. Fty Price in PC'
                                  
--------------------------------- 
 from IMMRKUP
left join SYFMLINF on yfi_fmlopt = imu_fmlopt and yfi_cocde = @imu_cocde
left join SYCONFTR on ycf_cocde = @imu_cocde and ycf_code1 = imu_pckunt and ycf_code2 = 'PC' 
 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
imu_cocde = @imu_cocde and
imu_itmno = @imu_itmno and
imu_ventyp = 
	(
	case @imu_cocde 
		when 'UCPP' then 'P' 
		when 'MS' then 'P' 
		else 'D' end
	)
order by imu_pckseq,  imu_venno
-------------------------- 

                                                           
---------------------------------------------------------- 
end



GO
GRANT EXECUTE ON [dbo].[sp_select_IMM00002_1] TO [ERPUSER] AS [dbo]
GO
