/****** Object:  StoredProcedure [dbo].[sp_insert_VNCUGREL]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_VNCUGREL]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_VNCUGREL]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_insert_VNCUGREL]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@vcr_cocde nvarchar(6),
@vcr_venno nvarchar(6),
@vcr_cugrpcde nvarchar(20),
@vcr_flg_int char(1),
@vcr_flg_ext char(1),
@icf_mrkup decimal(10,5),
@vcr_updusr nvarchar(30)


                                   
----------------------------------- 
AS




insert into VNCUGREL 

(
vcr_cocde, vcr_venno, vcr_cugrpcde, vcr_flg_int, vcr_flg_ext, vcr_creusr, vcr_updusr, vcr_credat, vcr_upddat, vcr_timstp
)
values
(
' ',@vcr_venno,@vcr_cugrpcde,@vcr_flg_int,@vcr_flg_ext,@vcr_updusr,@vcr_updusr,getdate(),getdate(),null
)



insert into IMCGCFML  

(
icf_cocde, icf_venno, icf_cugrpcde, icf_flg_int, icf_flg_ext,icf_mrkup, icf_creusr, icf_updusr, icf_credat, icf_upddat, icf_timstp
)
values
(
' ',@vcr_venno,@vcr_cugrpcde,@vcr_flg_int,@vcr_flg_ext,@icf_mrkup,@vcr_updusr,@vcr_updusr,getdate(),getdate(),null
)


if (select count(*) from IMCALFML 
where icf_vencde =  @vcr_venno) = 0 
begin
insert into IMCALFML
select '',@vcr_venno,'','','','','IM','BASIC','','B01','Y',getdate(),'2099-01-01','mis','mis',getdate(),getdate(),null
end





GO
GRANT EXECUTE ON [dbo].[sp_insert_VNCUGREL] TO [ERPUSER] AS [dbo]
GO
