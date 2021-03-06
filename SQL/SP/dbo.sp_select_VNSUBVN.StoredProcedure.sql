/****** Object:  StoredProcedure [dbo].[sp_select_VNSUBVN]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_VNSUBVN]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_VNSUBVN]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO









CREATE procedure [dbo].[sp_select_VNSUBVN]
                                                                                                                                                                                                                                                               
@vsv_cocde nvarchar(6) ,
@vsv_venno nvarchar(6) ,
@vsv_typ char(1)
AS


if @vsv_typ = 'F'
begin

Select
'' as 'vsv_del',  
vsv_cocde ,
vsv_ven1cde ,
v1.vbi_vensna as 'vsv_ven1name',
vsv_ven2cde ,
v2.vbi_vensna as 'vsv_ven2name',
vsv_venrel ,
vsv_creusr ,
vsv_updusr ,
vsv_credat ,
vsv_upddat ,
cast(vsv_timstp as int) as vsv_timstp

from VNSUBVN
left join VNBASINF v1 on v1.vbi_venno = vsv_ven1cde
left join VNBASINF v2 on v2.vbi_venno = vsv_ven2cde

where                                                                                                                                                                                                                                                                 
vsv_ven2cde = @vsv_venno
order by vsv_ven1cde

end
else
begin

Select 
'' as 'vsv_del',  
vsv_cocde ,
vsv_ven1cde ,
v1.vbi_vensna as 'vsv_ven1name',
vsv_ven2cde ,
v2.vbi_vensna as 'vsv_ven2name',
vsv_venrel ,
vsv_creusr ,
vsv_updusr ,
vsv_credat ,
vsv_upddat ,
cast(vsv_timstp as int) as vsv_timstp

from VNSUBVN
left join VNBASINF v1 on v1.vbi_venno = vsv_ven1cde
left join VNBASINF v2 on v2.vbi_venno = vsv_ven2cde
where                                                                                                                                                                                                                                                                 
vsv_ven1cde = @vsv_venno
order by vsv_ven2cde

end





GO
GRANT EXECUTE ON [dbo].[sp_select_VNSUBVN] TO [ERPUSER] AS [dbo]
GO
