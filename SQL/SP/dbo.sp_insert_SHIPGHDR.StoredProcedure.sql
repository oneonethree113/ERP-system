/****** Object:  StoredProcedure [dbo].[sp_insert_SHIPGHDR]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SHIPGHDR]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SHIPGHDR]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO














-- Checked by Allan Yuen at 28/07/2003

------------------------------------------------- 
CREATE   procedure [dbo].[sp_insert_SHIPGHDR]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hih_cocde	nvarchar(6),
@hih_shpno	nvarchar(20),
@hih_issdat	nvarchar(20),
@hih_rvsdat	nvarchar(20),
@hih_cus1no	nvarchar(6),
@hih_cus2no	nvarchar(20),
@hih_smpshp	nvarchar(1),
@hih_shpsts	nvarchar(10),
@hih_ves		nvarchar(30),
@hih_voy		nvarchar(30),
@hih_slnonb	nvarchar(20),
@hih_arrdat	nvarchar(20),
@hih_potloa	nvarchar(20),
@hih_dst		nvarchar(60),
@hih_crr		nvarchar(20),
@hih_crrso	nvarchar(20),
@hih_goddsc	nvarchar(200),

@hih_bilent	nvarchar(100),
@hih_biladr	nvarchar(200),
@hih_bilstt	nvarchar(20),
@hih_bilcty	nvarchar(20),
@hih_bilzip	nvarchar(20),
@hih_bilrmk	nvarchar(4000),

@hih_ttlctn	int,
@hih_ttlcbm		numeric(13,4),
@hih_ttlnwg	numeric(13,4),
@hih_ttlgwg	numeric(13,4),
@hih_untamt	nvarchar(4),
@hih_ttlamt	numeric(13,4),
@hih_lcno	nvarchar(30),
--Frankie Cheung 20100901
@hih_lcbank	nvarchar(300),
@hih_cntyorgn	nvarchar(300),
@hih_invsm	nvarchar(1),

@hih_updusr	nvarchar(30)
                                     
------------------------------------ 
AS
 
insert into  SHIPGHDR
(
hih_cocde,
hih_shpno,
hih_issdat	,
hih_rvsdat,
hih_cus1no,
hih_cus2no,
hih_smpshp,
hih_shpsts,
hih_ves,
hih_voy,
hih_slnonb,
hih_arrdat,
hih_potloa,
hih_dst,
hih_crr,
hih_crrso,
hih_goddsc,

hih_bilent,
hih_biladr,
hih_bilstt,
hih_bilcty,
hih_bilzip,
hih_bilrmk,

hih_ttlctn,
hih_ttlcbm,
hih_ttlnwg,
hih_ttlgwg,
hih_untamt,
hih_ttlamt,

hih_lcno,
--Frankie Cheung 20100901
hih_lcbank,
hih_cntyorgn,
hih_invsm,

hih_updusr,
hih_creusr,
hih_credat,
hih_upddat
)

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@hih_cocde,
@hih_shpno,
@hih_issdat,
@hih_rvsdat,
@hih_cus1no,
@hih_cus2no,
@hih_smpshp,
@hih_shpsts,
@hih_ves,
@hih_voy,
@hih_slnonb,
@hih_arrdat,
@hih_potloa,
@hih_dst,
@hih_crr,
@hih_crrso,
@hih_goddsc,

@hih_bilent,
@hih_biladr,
@hih_bilstt,
@hih_bilcty,
@hih_bilzip,
@hih_bilrmk,

@hih_ttlctn,
@hih_ttlcbm,
@hih_ttlnwg,
@hih_ttlgwg,
@hih_untamt,
@hih_ttlamt,
@hih_lcno,
@hih_lcbank,
@hih_cntyorgn,
@hih_invsm,

@hih_updusr,
@hih_updusr,
getdate(),
getdate()
)     
---------------------------------------------------------------------------------------------------------------------------------------------------------------------












GO
GRANT EXECUTE ON [dbo].[sp_insert_SHIPGHDR] TO [ERPUSER] AS [dbo]
GO
