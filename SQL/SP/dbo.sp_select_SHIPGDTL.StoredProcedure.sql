/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SHIPGDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SHIPGDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







/*
2003-11-29 Allan Yuen Fix Color Length from 10 to 30

*/


/**********************************************************************************************************************************
Modification History
**********************************************************************************************************************************
Modifiy by		Modified on		Description
**********************************************************************************************************************************
Lester Wu 		2005-10-12		fix cust color code size from 10 to 30
***********************************************************************************************************************************/
CREATE procedure [dbo].[sp_select_SHIPGDTL]
@hid_cocde	nvarchar(6),
@hid_shpno	nvarchar(20),
@hid_shpseq	int,
@hid_ctrcfs	nvarchar(20),
@hid_sealno	nvarchar(20),
@hid_ctrsiz	nvarchar(10),
@hid_pckrmk	nvarchar(40),
@hid_jobno	nvarchar(20),
@hid_ordno	nvarchar(20),
@hid_ordseq	int,
@hid_cuspo	nvarchar(20),
@hid_cusitm	nvarchar(20),
@hid_itmno	nvarchar(20),
@hid_itmtyp	nvarchar(4),
@hid_itmdsc	nvarchar(300),
@hid_colcde	nvarchar(30),
-- Lester Wu 2005-10-12, fix cust color code size from 10 to 30
-- @hid_cuscol	nvarchar(10),
@hid_cuscol	nvarchar(30),
@hid_coldsc	nvarchar(300),
--Added by Mark Lau 20060929
@hid_alsitmno	nvarchar(20),
@hid_alscolcde	nvarchar(30),

--Added by Mark Lau 20080611
@hid_custum	nvarchar(6),

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
@hid_contopc	char(1),
@hid_conftr	int,
@hid_pcprc	numeric(13,4) , 
@hid_cusstyno	nvarchar(30),
@hid_updusr	nvarchar(30)
AS
 
--Set @hid_shpseq = (Select isnull(max(hid_shpseq ),0) + 1 from SHIPGDTL Where hid_cocde = @hid_cocde and hid_shpno = @hid_shpno)


insert into  SHIPGDTL
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
hid_cuscol,
hid_coldsc,
--Added by Mark Lau 20060929
hid_alsitmno,
hid_alscolcde,

--Added by Mark Lau 20080611
hid_custum,

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
hid_updusr,
hid_creusr,
hid_credat,
hid_upddat,
hid_contopc,
hid_conftr , 
hid_pcprc
)

values(

@hid_cocde,
@hid_shpno,
@hid_shpseq,
@hid_ctrcfs,
@hid_sealno,
@hid_ctrsiz,
@hid_pckrmk,
@hid_jobno,
@hid_ordno,
@hid_ordseq,
@hid_cuspo,
@hid_cusitm,
@hid_itmno,
@hid_itmtyp,
@hid_itmdsc,
@hid_colcde,
@hid_cuscol,
@hid_coldsc,

--Added by Mark Lau 20060929
@hid_alsitmno,
@hid_alscolcde,

--Added by Mark Lau 20080611
@hid_custum,

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
@hid_itmshm,
@hid_cmprmk,
-- Modified by Mark Lau 20080813
rtrim(ltrim(@hid_mannam)),
--@hid_mannam,
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
@hid_updusr,
@hid_updusr,
getdate(),
getdate(),
@hid_contopc,
@hid_conftr , 
@hid_pcprc
) 

select  @hid_shpseq as 'NewShpSeq'

---------------------------------------------------------------------------------------------------------------------------------------------------------------------


GO
GRANT EXECUTE ON [dbo].[sp_select_SHIPGDTL] TO [ERPUSER] AS [dbo]
GO
