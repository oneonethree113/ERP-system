/****** Object:  StoredProcedure [dbo].[sp_insert_CUCALFML]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_CUCALFML]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_CUCALFML]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





CREATE procedure [dbo].[sp_insert_CUCALFML]
                                                                                                                                                                                                                                                                 
	@ccf_cocde nvarchar(6),
	@ccf_cus1no nvarchar(10),
	@ccf_cus2no nvarchar(10),
	@ccf_cat nvarchar(20),
            @ccf_venno nvarchar(10),
            @ccf_prctrm nvarchar(10),
            @ccf_trantrm  nvarchar(10),
            @ccf_curcde nvarchar(10),
            @ccf_cumu numeric(13,4),
            @ccf_pm numeric(13,4),
            @ccf_cush numeric(13,4),
            @ccf_thccusper numeric(13,4),
            @ccf_upsper numeric(13,4),
            @ccf_labper numeric(13,4),
            @ccf_faper numeric(13,4),
            @ccf_cstbufper numeric(13,4),
            @ccf_othper  numeric(13,4),
            @ccf_pliper numeric(13,4),
            @ccf_dmdper numeric(13,4),
            @ccf_rbtper numeric(13,4),
            @ccf_pkgper numeric(13,4),
            @ccf_comper numeric(13,4),
            @ccf_icmper numeric(13,4),
 	@User nvarchar(30),
	@effdat datetime
AS

begin

insert into CUCALFML
(ccf_cocde, ccf_cus1no, ccf_cus2no, ccf_cat, ccf_venno, ccf_prctrm, ccf_trantrm, ccf_curcde, ccf_cumu, ccf_pm, ccf_cush, ccf_thccusper, ccf_upsper, ccf_labper, ccf_faper, ccf_cstbufper, ccf_othper, ccf_pliper, ccf_dmdper, ccf_rbtper, ccf_pkgper, ccf_comper, ccf_icmper, ccf_creusr, ccf_updusr, ccf_credat, ccf_upddat, ccf_timstp,ccf_effdat,ccf_iseff,ccf_latest)
values ( @ccf_cocde ,
	@ccf_cus1no  ,
	@ccf_cus2no ,
	@ccf_cat  ,
            @ccf_venno ,
            @ccf_prctrm ,
            @ccf_trantrm  ,
            @ccf_curcde ,
            @ccf_cumu ,
            @ccf_pm ,
            @ccf_cush ,
            @ccf_thccusper ,
            @ccf_upsper ,
            @ccf_labper,
            @ccf_faper ,
            @ccf_cstbufper ,
            @ccf_othper  ,
            @ccf_pliper ,
            @ccf_dmdper ,
            @ccf_rbtper ,
            @ccf_pkgper ,
            @ccf_comper ,
            @ccf_icmper ,
 	@User ,
	@User,
	getdate(),
	getdate(),
	null,
	@effdat,
	'Y',
	'Y')

end








GO
GRANT EXECUTE ON [dbo].[sp_insert_CUCALFML] TO [ERPUSER] AS [dbo]
GO
