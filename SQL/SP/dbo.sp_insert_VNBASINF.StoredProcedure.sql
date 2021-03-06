/****** Object:  StoredProcedure [dbo].[sp_insert_VNBASINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_VNBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_VNBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- Checked by Allan Yuen at 28/08/2003



------------------------------------------------- 
CREATE  procedure [dbo].[sp_insert_VNBASINF]
                                                                                                                                                                                                                                                               
  
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

@vbi_cocde 	nvarchar(6),
@vbi_venno	nvarchar(6),
@vbi_vensts	nvarchar(1),
@vbi_vensna	nvarchar(40),
@vbi_vennam	nvarchar(100),
@vbi_venrat	nvarchar(1),
@vbi_prctrm	nvarchar(6),
@vbi_paytrm	nvarchar(6),
@vbi_curcde	nvarchar(6),
@vbi_discnt	numeric(6,3),
@vbi_orgven	nvarchar(6),
@vbi_rmk	nvarchar(800),
@vbi_ledtim	int,
@vbi_tsttim	int,
@vbi_bufday	int,
@vbi_venweb	nvarchar(100),
@vbi_ventyp	char(1),
@vbi_moqchg	char(1),
@vbi_frurcde   nvarchar(10),
@vbi_framt	int,
@vci_adr		nvarchar(200),
@vci_stt		nvarchar(30),
@vci_city		nvarchar(30),
@vci_town		nvarchar(30),

@vci_cty		nvarchar(6),
@vci_zip		nvarchar(20),

-- Added by Mark Lau 20081027
@vbi_venchnnam	nvarchar(255),
@vci_chnadr	nvarchar(255),
@vbi_venfty	char(1),
@vbi_ventranflg char(1),
@vbi_venflag	nvarchar(10),
@vbi_updusr	nvarchar(30)
                                     
------------------------------------ 
AS
 
insert into  VNBASINF
(
vbi_cocde,
vbi_venno,
vbi_vensts,
vbi_vensna,
vbi_vennam,
vbi_venrat,
vbi_prctrm,
vbi_paytrm,
vbi_curcde,
vbi_discnt,
vbi_orgven,
vbi_rmk,
vbi_ledtim,
vbi_tsttim,
vbi_bufday,
vbi_venweb,
vbi_ventyp,
vbi_moqchg,
vbi_frurcde  ,
vbi_framt,
-- Added by Mark Lau 20081027
vbi_venchnnam,
vbi_venfty,
vbi_ventranflg,
vbi_venflag,
vbi_creusr,
vbi_updusr,
vbi_credat,
vbi_upddat
)

values(
                                                                                                                                                                                                                                                               
  
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--@vbi_cocde,
' ',
@vbi_venno,
@vbi_vensts,
@vbi_vensna,
@vbi_vennam,
@vbi_venrat,
@vbi_prctrm,
@vbi_paytrm,
@vbi_curcde,
@vbi_discnt,
@vbi_orgven,
@vbi_rmk,
@vbi_ledtim,
@vbi_tsttim,
@vbi_bufday,
@vbi_venweb,
@vbi_ventyp,
@vbi_moqchg,
@vbi_frurcde  ,
@vbi_framt,
-- Added by Mark Lau 20081027
@vbi_venchnnam,
@vbi_venfty,
@vbi_ventranflg,
@vbi_venflag,
@vbi_updusr,
@vbi_updusr,
getdate(),
getdate()
)     


insert into  VNCNTINF
(
vci_cocde,
vci_venno,
vci_cnttyp,
vci_seq,
vci_adr,
vci_stt,
vci_city,
vci_town,
vci_cty,
vci_zip,
-- Added by Mark Lau 20081027
vci_chnadr,
vci_creusr,
vci_updusr,
vci_credat,
vci_upddat
)

values(
                                                                                                                                                                                                                                                               
 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--@vbi_cocde,
' ',
@vbi_venno,
'M',	-- stand for company address
1,	-- company address only have one seq no.
@vci_adr,
@vci_stt,
@vci_city,
@vci_town,
@vci_cty,
@vci_zip,
-- Added by Mark Lau 20081027
@vci_chnadr,
@vbi_updusr,
@vbi_updusr,
getdate(),
getdate()
)       
---------------------------------------------------------------------------------------------------------------------------------------------------------------------



GO
GRANT EXECUTE ON [dbo].[sp_insert_VNBASINF] TO [ERPUSER] AS [dbo]
GO
