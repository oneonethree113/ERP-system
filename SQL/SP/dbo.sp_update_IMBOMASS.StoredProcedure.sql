/****** Object:  StoredProcedure [dbo].[sp_update_IMBOMASS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMBOMASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMBOMASS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  PROCEDURE [dbo].[sp_update_IMBOMASS] 

@iba_cocde  	nvarchar(6),
@iba_itmno  	nvarchar(20),
@iba_assitm	nvarchar(20),
--@iba_pckseq  	int,
@iba_typ  	nvarchar(4),
@iba_colcde  	nvarchar(30),
@iba_pckunt  	nvarchar(6),	-- Modify by Lewis on 20030616
@iba_bomqty  	int,
@iba_inrqty  	int,
@iba_mtrqty  	int,
@iba_altitmno	varchar(20),
@iba_costing	char(1),
@iba_genpo	char(1),
@iba_untcst	numeric(13,4),
@iba_curcde	varchar(4),
@iba_ftyfmlopt	varchar(5),
@iba_fmlopt	varchar(5),
@iba_bombasprc	numeric(13,4),
@iba_fcurcde	varchar(4),
@iba_ftycst	numeric(13,4),
@iba_period	varchar(10),
@iba_orgcolcde  	nvarchar(30),
@iba_updusr  	nvarchar(30)


AS
begin
declare @period datetime
set @period = @iba_period

update IMBOMASS
set 
iba_assitm = @iba_assitm,
--iba_pckseq = @iba_pckseq ,
iba_typ =  @iba_typ ,
iba_colcde = @iba_colcde,
iba_pckunt=@iba_pckunt,
iba_bomqty= @iba_bomqty,
iba_inrqty = @iba_inrqty ,
iba_mtrqty = @iba_mtrqty ,
iba_altitmno = @iba_altitmno,
iba_costing = @iba_costing,		
iba_genpo = @iba_genpo,	
iba_untcst = @iba_untcst,
iba_updusr= @iba_updusr,
iba_curcde = @iba_curcde,
iba_ftyfmlopt = @iba_ftyfmlopt,
iba_fmlopt = @iba_fmlopt,
iba_bombasprc= @iba_bombasprc,
iba_fcurcde = @iba_fcurcde,
iba_ftycst = @iba_ftycst,
iba_period = @period,
iba_upddat = getdate()

Where 
--iba_cocde = @iba_cocde and
iba_itmno = @iba_itmno and
iba_assitm = @iba_assitm and
iba_colcde = @iba_orgcolcde and
--iba_pckseq = @iba_pckseq and
iba_typ = @iba_typ


END



GO
GRANT EXECUTE ON [dbo].[sp_update_IMBOMASS] TO [ERPUSER] AS [dbo]
GO
