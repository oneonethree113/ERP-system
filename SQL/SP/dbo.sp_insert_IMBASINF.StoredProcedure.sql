/****** Object:  StoredProcedure [dbo].[sp_insert_IMBASINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO












/*
=========================================================
Program ID	: sp_insert_IMBASINF
Description   	: Insert IMBASINF
Programmer  	: PIC, Kenny Chan
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen	For Merge Porject
26 July 2004 	Allan Yuen	Add Wastage% Column
21 Mar 2005	Allan Yuen	Add Company Code
23 May 2005	Allan Yuen	Add Custom Vendor Code
*/



------------------------------------------------- 
CREATE procedure [dbo].[sp_insert_IMBASINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ibi_cocde  nvarchar     (6) = '',
@ibi_itmno  nvarchar     (20),
@ibi_orgitm  nvarchar     (20),
@ibi_lnecde  nvarchar     (10),
@ibi_prdtyp varchar (10),
@ibi_curcde  nvarchar     (3),
@ibi_catlvl0  nvarchar     (20),
@ibi_catlvl1  nvarchar     (20),
@ibi_catlvl2  nvarchar     (20),
@ibi_catlvl3  nvarchar     (20),
@ibi_catlvl4  nvarchar     (20),
@ibi_itmsts  nvarchar     (4),
@ibi_typ  nvarchar     (4),
@ibi_engdsc  nvarchar     (800),
@ibi_chndsc  nvarchar     (1600),
@ibi_venno  nvarchar     (6),
@ibi_cusven  nvarchar     (6),
@ibi_tradeven	nvarchar (6),
@ibi_examven	nvarchar (6),
--@ibi_prctrm  nvarchar     (10),
@ibi_imgpth  nvarchar     (200),
@ibi_hamusa  nvarchar     (20),
@ibi_hameur  nvarchar     (20),
@ibi_dtyusa  numeric(6,3),
@ibi_dtyeur  numeric(6,3),
@ibi_cosmth  nvarchar     (50),
@ibi_rmk  nvarchar     (200),
--@ibi_ftyprc  numeric(7,4)  ,
@ibi_tirtyp nvarchar(1),
@ibi_moqctn int,
@ibi_qty int,
@ibi_moa int,
-- 20040726 AY Add wastage column 
@ibi_wastage numeric(5,2),
@ibi_itmnat nvarchar(6),

-- Added by Mark Lau 20090210
@ibi_dsgno	nvarchar(50),
@ibi_finishing	nvarchar(6),
@ibi_material	nvarchar(6),
@ibi_prdsizeTyp	nvarchar(6),
@ibi_prdsizeUnt	nvarchar(6),
@ibi_prdsizeVal	numeric(13,4),
@ibi_moqunttyp	nvarchar(6),
----------------------------------------------------------

-- Added by Mark Lau 20090326
@ibi_prdgrp	nvarchar(6),
@ibi_prdicon	nvarchar(6),

@ibi_season varchar(10),
@ibi_designer varchar(10),
@ibi_devteam varchar(10),
@ibi_type varchar(10),
@ibi_year varchar(10),

@ibi_addreq_forma char(1),
@ibi_addreq_ccbi char(1),
@ibi_addreq_ster char(1),

@ibi_ftytmp char(1),

@ibi_updusr  nvarchar     (30)
                                     
------------------------------------ 
AS
 
insert into  IMBASINF
(ibi_cocde,
ibi_itmno,
ibi_orgitm,
ibi_lnecde,
ibi_prdtyp,
ibi_curcde,
ibi_catlvl0,
ibi_catlvl1,
ibi_catlvl2,
ibi_catlvl3,
ibi_catlvl4,
ibi_itmsts,
ibi_typ,
ibi_engdsc,
ibi_chndsc,
ibi_venno,
ibi_cusven, 
ibi_tradeven ,
ibi_examven ,
--ibi_prctrm,
ibi_imgpth,
ibi_hamusa,
ibi_hameur,
ibi_dtyusa,
ibi_dtyeur,
ibi_cosmth,
ibi_rmk,
--ibi_ftyprc,
ibi_prvsts,
ibi_tirtyp ,
ibi_moqctn ,
ibi_qty ,
ibi_moa ,
-- 20040726 AY Add wastage column 
ibi_wastage ,
----------------------------------------------------------
ibi_itmnat,


-- Added by Mark Lau 20090210
ibi_dsgno	,
ibi_finishing	,
ibi_material	,
ibi_prdsizeTyp	,
ibi_prdsizeUnt	,
ibi_prdsizeVal	,
ibi_moqunttyp	,

-- Added by Mark Lau 20090326
ibi_prdgrp,
ibi_prdicon	,

ibi_season,
ibi_designer,
ibi_devteam,
ibi_type,
ibi_year,

ibi_addreq_forma,
ibi_addreq_ccbi,
ibi_addreq_ster,
ibi_ftytmp,

ibi_creusr,
ibi_updusr,
ibi_credat,
ibi_upddat)

values(
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ibi_cocde,
--' ',
@ibi_itmno,
@ibi_orgitm,
@ibi_lnecde,
@ibi_prdtyp,
@ibi_curcde,
@ibi_catlvl0,
@ibi_catlvl1,
@ibi_catlvl2,
@ibi_catlvl3,
@ibi_catlvl4,
@ibi_itmsts,
@ibi_typ,
@ibi_engdsc,
@ibi_chndsc,
@ibi_venno,
@ibi_cusven,
@ibi_tradeven,
@ibi_examven,
--@ibi_prctrm,
@ibi_imgpth,
@ibi_hamusa,
@ibi_hameur,
@ibi_dtyusa,
@ibi_dtyeur,
@ibi_cosmth,
@ibi_rmk,
@ibi_itmsts,
--@ibi_ftyprc,
@ibi_tirtyp ,
@ibi_moqctn,
@ibi_qty ,
@ibi_moa,
-- 20040726 AY Add wastage column 
@ibi_wastage,
----------------------------------------------------------
@ibi_itmnat,
-- Added by Mark Lau 20090210
@ibi_dsgno	,
@ibi_finishing	,
@ibi_material	,
@ibi_prdsizeTyp,
@ibi_prdsizeUnt,
@ibi_prdsizeVal	,
@ibi_moqunttyp	,
-- Added by Mark Lau 20090326
@ibi_prdgrp,
@ibi_prdicon	,

@ibi_season,
@ibi_designer,
@ibi_devteam,
@ibi_type,
@ibi_year,

@ibi_addreq_forma,
@ibi_addreq_ccbi,
@ibi_addreq_ster,
@ibi_ftytmp,

@ibi_updusr,
@ibi_updusr,
getdate(),
getdate()
)      
---------------------------------------------------------------------------------------------------------------------------------------------------------------------




GO
GRANT EXECUTE ON [dbo].[sp_insert_IMBASINF] TO [ERPUSER] AS [dbo]
GO
