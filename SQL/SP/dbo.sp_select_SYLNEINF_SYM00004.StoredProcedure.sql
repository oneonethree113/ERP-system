/****** Object:  StoredProcedure [dbo].[sp_select_SYLNEINF_SYM00004]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYLNEINF_SYM00004]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYLNEINF_SYM00004]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO








CREATE   PROCEDURE [dbo].[sp_select_SYLNEINF_SYM00004] 

@yli_cocde	nvarchar(6) = ' ',
@yli_lnecde	nvarchar(12)
AS

declare @yli_timstp int

--Set  @yli_timstp = (Select max(cast(yli_timstp as int)) from sylneinf where yli_cocde = @yli_cocde and yli_lnecde = @yli_lnecde)
Set  @yli_timstp = (Select max(cast(yli_timstp as int)) from sylneinf where yli_cocde = ' ' and yli_lnecde = @yli_lnecde)

begin
Select 
yli_creusr as 'yci_status',
yli_cocde,
yli_lnecde,
yli_lnedsc,
-- 2003/11/28-------
isnull(yli_pcfty + ' - '  + vbi_vensna,'') as 'yli_pcfty',
------------------------
yli_creusr,
yli_updusr,
yli_credat,
yli_upddat,
@yli_timstp as 'yli_timstp',
--2004/06/02--
isnull(yli_dsgcde + ' - ' + ysi_dsc, '') as 'yli_dsgcde'
----------------

from SYLNEINF
left join VNBASINF
on yli_pcfty = vbi_venno
--2004/06/02--
left join SYSETINF
on yli_dsgcde = ysi_cde
--Lester Wu 2004/07/10 cater incorrect retrieve of data
and ysi_typ='15'
-----------------
where 
--yli_cocde = @yli_cocde and 
yli_cocde = ' ' and 
yli_lnecde = @yli_lnecde

order by yli_lnecde

end









GO
GRANT EXECUTE ON [dbo].[sp_select_SYLNEINF_SYM00004] TO [ERPUSER] AS [dbo]
GO
