/****** Object:  StoredProcedure [dbo].[sp_insert_VNCNTINF]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_VNCNTINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_VNCNTINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE  procedure [dbo].[sp_insert_VNCNTINF]
                                                                                                                                                                                                                                                               
  
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

@vci_cocde 	nvarchar(6),
@vci_venno  	nvarchar(6),
@vci_cnttyp	nvarchar(6),
@vci_adr	nvarchar(200),
@vci_stt	nvarchar(30),
@vci_city	nvarchar(30),
@vci_town	nvarchar(30),
@vci_cty	nvarchar(6),
@vci_zip	nvarchar(20),
@vci_adrdtl	nvarchar(200),

@vci_cntctp	nvarchar(100),
@vci_cnttil	nvarchar(30),
@vci_cntphn	nvarchar(30),
@vci_cntfax	nvarchar(30),
@vci_cnteml	nvarchar(50),
@vci_cntdef	nvarchar(1),


@vci_updusr	nvarchar(30)
                                   
----------------------------------- 
AS

declare @vci_seq as int

--set  @vci_seq = (select isnull(max(vci_seq),0) + 1 from VNCNTINF  where vci_cocde=@vci_cocde and vci_venno=@vci_venno and vci_cnttyp=@vci_cnttyp)
set  @vci_seq = (select isnull(max(vci_seq),0) + 1 from VNCNTINF  where vci_venno=@vci_venno and vci_cnttyp=@vci_cnttyp)


insert into VNCNTINF 

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
vci_adrdtl,

vci_cntctp,
vci_cnttil,
vci_cntphn,
vci_cntfax,
vci_cnteml,
vci_cntdef,

vci_creusr,
vci_updusr,
vci_credat,
vci_upddat
)
values
(
--@vci_cocde,
' ',
@vci_venno,
@vci_cnttyp,
@vci_seq,
@vci_adr,
@vci_stt,
@vci_city,
@vci_town,
@vci_cty,
@vci_zip,
@vci_adrdtl,

@vci_cntctp,
@vci_cnttil,
@vci_cntphn,
@vci_cntfax,
@vci_cnteml,
@vci_cntdef,

@vci_updusr,
@vci_updusr,
getdate(),
getdate()
)



GO
GRANT EXECUTE ON [dbo].[sp_insert_VNCNTINF] TO [ERPUSER] AS [dbo]
GO
