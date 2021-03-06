/****** Object:  StoredProcedure [dbo].[sp_insert_SHIPGDTL_cov]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHIPGDTL_cov]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHIPGDTL_cov]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



















/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
Lester Wu 		2005-10-12		fix cust color code size from 10 to 30
***********************************************************************************************************************************/


-- Checked by Allan Yuen at 28/07/2003


------------------------------------------------- 
CREATE           procedure [dbo].[sp_insert_SHIPGDTL_cov]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hid_cocde	nvarchar(6),
@hid_shpno	nvarchar(20),
@hid_shpseq	int,
@hid_ctrcfs	nvarchar(20),
@hid_sealno	nvarchar(20),
@hid_ctrsiz	nvarchar(30),
@hid_pckrmk	nvarchar(40),
@hid_jobno	nvarchar(20),
@hid_ordno	nvarchar(20),
@hid_ordseq	int,
@hid_cuspo	nvarchar(20),
@hid_cusitm	nvarchar(20),
@hid_itmno	nvarchar(20),
@hid_itmtyp	nvarchar(4),
@hid_itmdsc	nvarchar(300),
-- Allan Yuen fix the color code size from 10 to 30 at 14/02/2003
--@hid_colcde	nvarchar(10),
@hid_colcde	nvarchar(30),
@hid_alsitmno	nvarchar(20),
@hid_alscolcde	nvarchar(30),
@hid_custum	nvarchar(6),
-- Lester Wu fix the color code size from 10 to 30 at 2005-10-12
--@hid_cuscol	nvarchar(10),
@hid_cuscol	nvarchar(30),
@hid_coldsc	nvarchar(300),
@hid_shpqty	int,
@hid_untcde	nvarchar(6),
@hid_ctnstr	int,
@hid_ctnend	int,
@hid_inrctn	int,
@hid_mtrctn	int,
@hid_vol		numeric(11,4),
@hid_mtrdcm	numeric(11,4),
@hid_mtrwcm	numeric(11,4),
@hid_mtrhcm	numeric(11,4),
@hid_actvol	numeric(11,4),
@hid_grswgt	numeric(11,4),
@hid_netwgt	numeric(11,4),
@hid_itmshm	nvarchar(300),
@hid_cmprmk	nvarchar(4000),
@hid_mannam	nvarchar(200),
@hid_manadr	nvarchar(200),
@hid_ttlvol	numeric(13,4),
@hid_ttlnet	numeric(13,4),
@hid_ttlgrs	numeric(13,4),
@hid_ttlctn	numeric(11,4),
@hid_untsel	nvarchar(6),
@hid_selprc	numeric(11,4),
@hid_untamt	nvarchar(6),
@hid_ttlamt	numeric(13,4),
@hid_invno	nvarchar(20),
@hid_prctrm	nvarchar(6),
@hid_paytrm	nvarchar(6),
@hid_purord	nvarchar(20),
@hid_purseq	int,
@hid_venno	nvarchar(6),
@hid_cusven	nvarchar(6),
@hid_cusstyno	nvarchar(30),
@hid_consolno nvarchar(30),
@hid_replacement nvarchar(1),
@hid_colpck	nvarchar(200),
@hid_ctnftr	int,
@hid_cus2no	nvarchar(6),
@hid_contopc	char(1),
@hid_conftr	int,
@hid_pcprc	numeric(13,4) , 
@hid_name_f1	nvarchar(150),
@hid_dsc_f1	nvarchar(150),
@hid_name_f2	nvarchar(150),
@hid_dsc_f2	nvarchar(150),
@hid_name_f3	nvarchar(150),
@hid_dsc_f3	nvarchar(150),
@hid_resppo	nvarchar(50),
@hid_cussku	nvarchar(50),
@hid_addinf	nvarchar(200),
@hid_updusr	nvarchar(30)
                                     
------------------------------------ 
AS
 
insert into  SHIPGDTL_cov
(
hid_cocde,
hid_shpno,
hid_shpseq,
hid_ctrcfs	,
hid_sealno,
hid_ctrsiz,
hid_pckrmk,
hid_jobno,
hid_ordno,
hid_ordseq,
hid_cuspo,
hid_cusitm,
hid_itmno,
hid_itmtyp,
hid_itmdsc,
hid_colcde,
hid_alsitmno,
hid_alscolcde,
hid_custum,
hid_cuscol,
hid_coldsc,
hid_shpqty,
hid_untcde,
hid_ctnstr	,
hid_ctnend,
hid_inrctn,
hid_mtrctn,
hid_vol,
hid_mtrdcm,
hid_mtrwcm,
hid_mtrhcm,
hid_actvol,
hid_grswgt,
hid_netwgt,
hid_itmshm,
hid_cmprmk,
hid_mannam,
hid_manadr,
hid_ttlvol,
hid_ttlnet,
hid_ttlgrs,
hid_ttlctn,
hid_untsel,
hid_selprc,
hid_untamt,
hid_ttlamt,
hid_invno,
hid_prctrm,
hid_paytrm,
hid_purord,
hid_purseq,
hid_venno,
hid_cusven,
hid_cusstyno,
hid_consolno ,
hid_replacement,
hid_colpck,
hid_ctnftr,
hid_cus2no,
hid_contopc,
hid_conftr , 
hid_pcprc,
hid_name_f1,
hid_dsc_f1,
hid_name_f2,
hid_dsc_f2,
hid_name_f3,
hid_dsc_f3,
hid_resppo,
hid_cussku,
hid_addinf,
hid_updusr,
hid_creusr,
hid_credat,
hid_upddat
)

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

@hid_cocde,
@hid_shpno,
@hid_shpseq,
rtrim(@hid_ctrcfs),
@hid_sealno,
@hid_ctrsiz,
@hid_pckrmk,
@hid_jobno,
@hid_ordno,
@hid_ordseq,
ltrim(rtrim(@hid_cuspo)),
ltrim(rtrim(@hid_cusitm)),
ltrim(rtrim(@hid_itmno)),
@hid_itmtyp,
ltrim(rtrim(@hid_itmdsc)),
@hid_colcde,
@hid_alsitmno,
@hid_alscolcde,
@hid_custum,
@hid_cuscol,
@hid_coldsc,
@hid_shpqty,
@hid_untcde,
@hid_ctnstr,
@hid_ctnend,
@hid_inrctn,
@hid_mtrctn,
@hid_vol,
@hid_mtrdcm,
@hid_mtrwcm,
@hid_mtrhcm,
@hid_actvol,
@hid_grswgt,
@hid_netwgt,
rtrim(@hid_itmshm),
@hid_cmprmk,
rtrim(@hid_mannam),
@hid_manadr,
@hid_ttlvol,
@hid_ttlnet,
@hid_ttlgrs,
@hid_ttlctn,
@hid_untsel,
@hid_selprc,
@hid_untamt,
@hid_ttlamt,
@hid_invno,
@hid_prctrm,
@hid_paytrm,
@hid_purord,
@hid_purseq,
@hid_venno,
@hid_cusven,
@hid_cusstyno,
@hid_consolno,
@hid_replacement,
@hid_colpck,
@hid_ctnftr,
@hid_cus2no,
@hid_contopc,
@hid_conftr , 
@hid_pcprc,
@hid_name_f1,
@hid_dsc_f1,
@hid_name_f2,
@hid_dsc_f2,
@hid_name_f3,
@hid_dsc_f3,
@hid_resppo,
@hid_cussku,
@hid_addinf,
@hid_updusr,
@hid_updusr,
getdate(),
getdate()
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------










GO
GRANT EXECUTE ON [dbo].[sp_insert_SHIPGDTL_cov] TO [ERPUSER] AS [dbo]
GO
