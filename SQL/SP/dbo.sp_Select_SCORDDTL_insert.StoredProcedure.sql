/****** Object:  StoredProcedure [dbo].[sp_Select_SCORDDTL_insert]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Select_SCORDDTL_insert]
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_SCORDDTL_insert]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO








-- Checked by Allan Yuen at 27/07/2003


/************************************************************************
Author:		Kenny Chan
Date:		7th Jan, 2002
Description:	Insert data From SCORDHDR
		Using sp_Select to Return the Real OrdSeq
Parameter:	1. Company
		2. SC No.	
************************************************************************
2003-09-03 	Allan Yuen		Add feature to cater second customer with alias
2003-10-01	Allan Yuen		Add Formula Code, Formula & Markup Price.
2004-02-26	Marco Chan		Hidden SC not to update price to CUITMSUM
2004-09-15	Allan Yuen		Add Store BOM Cost column.
2004-05-27	Allan Yuen		Add Custom Vendor, Previous Job No, Sec Customer Item #
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_Select_SCORDDTL_insert]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sod_cocde  nvarchar ( 6),	@sod_ordno  nvarchar ( 20),	@sod_venno nvarchar(6),	@sod_fcurcde nvarchar(6),	
@sod_ftycst numeric(13,4),	@sod_ftyprc numeric(13,4),	@sod_updpo  nvarchar (1),	@sod_chgfty  nvarchar (1),
@sod_itmno  nvarchar (20),	@sod_itmtyp  nvarchar (4),	@sod_itmdsc  nvarchar (800),	@sod_colcde  nvarchar (    30),
@sod_cuscol  nvarchar (30),	@sod_coldsc  nvarchar ( 300),	@sod_pckseq  int,		@sod_pckunt  nvarchar (    6),
@sod_inrctn  int,		@sod_mtrctn  int,		@sod_cft  numeric ( 11,4),	@sod_cbm  numeric( 11,4),
@sod_qutno  nvarchar (20),	@sod_refdat  datetime,		@sod_cusitm  nvarchar ( 20),	@sod_cussku  nvarchar (20),
@sod_resppo  nvarchar (20),	@sod_cuspo  nvarchar (20),	@sod_ordqty  int,		@sod_discnt  numeric( 6,3),
@sod_oneprc  nvarchar (1),	@sod_curcde  nvarchar (6),	@sod_untprc  numeric( 13,4), 	@sod_selprc  numeric( 13,4),	
@sod_hrmcde  nvarchar (12),	@sod_dtyrat  numeric ( 6,3),	@sod_dept  nvarchar (20),	@sod_typcode  nvarchar (1),	
-- Modified by Frankie Cheung 20100518
-- @sod_code1  nvarchar (15),	@sod_code2  nvarchar (15),	@sod_code3  nvarchar (15),	
@sod_code1  nvarchar (25),	@sod_code2  nvarchar (25),	@sod_code3  nvarchar (25),	
@sod_cususd  numeric( 13,4),
@sod_cuscad  numeric( 13,4),	@sod_inrdin  numeric( 11,4),	@sod_inrwin  numeric( 11,4),	@sod_inrhin  numeric( 11,4),	
@sod_mtrdin  numeric( 11,4),	@sod_mtrwin  numeric( 11,4),	@sod_mtrhin  numeric( 11,4),	@sod_inrdcm  numeric( 11,4),
@sod_inrwcm  numeric( 11,4),	@sod_inrhcm  numeric( 11,4),	@sod_mtrdcm  numeric( 11,4),	@sod_mtrwcm  numeric( 11,4),
@sod_mtrhcm  numeric( 11,4),	@sod_shpstr  datetime,	@sod_shpend  datetime ,	@sod_candat  datetime,	
@sod_ctnstr  int ,		@sod_ctnend  int ,		@sod_ttlctn  int,		@sod_rmk  nvarchar ( 300),	
@cusno nvarchar(6),		@sod_subcde nvarchar(10),	@sod_ftyunt nvarchar(6),	@sod_venitm nvarchar(20),	
@sod_itmprc numeric(13,4),	@sod_pckitr nvarchar(300),	@sod_clmno nvarchar(30),	@sod_moq int,		
@sod_moa numeric(11,4),	@sod_itmsts nvarchar(4),		@sod_apprve nvarchar(1),	@seccus nvarchar(6) , 		
@status nvarchar(6) , 		@closeout nvarchar(1), 		@replace nvarchar(1), 		@sod_updusr  nvarchar (30) ,
@sod_orgmoqchg  numeric( 6,3), 	@sod_moqchg  numeric( 6,3),  	@sod_netuntprc  numeric( 13,4),	@sod_cusmoqchg char(1), 	
@sod_cusven varchar(6),		@sod_cussub varchar(10),	@sod_pjobno varchar(20),	@sod_seccusitm varchar(20),
@sod_venmoqchg char(1), 	@sod_assitmcount int, 		@sod_orgvenno nvarchar(6), 	
@sod_alsitmno varchar(20) , 	@sod_alscolcde varchar(30),	@sod_bomcst  numeric( 13,4)
---------------------------------------------- 
--Added by Mark Lau 20070206 SAP Implementation
 ,@sod_ztnvbeln nvarchar(10)  ,@sod_ztnposnr nvarchar(6) 
,@sod_zorvbeln nvarchar(10)  ,@sod_zorposnr  nvarchar(6) 
--Added by Mark Lau 20070622
, @sod_conftr numeric(9), @sod_contopc nvarchar(1)
, @sod_pcprc numeric(13,4)
--Added by Mark Lau 20080611
, @sod_custum nvarchar(6),

-- added by Mark Lau 20080825
@sod_dv nvarchar(50),
@sod_dvftycst numeric(13,4),	
@sod_dvftyprc numeric(13,4),	
@sod_dvbomcst numeric(13,4),	
@sod_dvfcurcde nvarchar(6),	
@sod_dvftyunt nvarchar(6),
-- Added by Mark Lau 20081107
@sod_cusstyno 	nvarchar(30)
-- Added by Mark Lau 20090205
,@sod_moqunttyp 	nvarchar(30)
-- Frankie Cheung 20100413 Add CIH Period
, @qutdat datetime
--Frankie Cheung 20100712 Add Factory cost
,@sod_dvitmcst numeric(13,4)
,@sod_itmcstcur nvarchar(6)
-------------------------------------------
-- Frankie Cheung 20100809 Add IM Period
,@imqutdat datetime
, @endsignal nvarchar(1)
AS

Declare @sod_ordseq  int, @cid_seqno int
Declare @Itmventyp char(1)		--- Vendor Item Type	
Declare @sod_fmlopt varchar(5)		--- Markup Formula Code
declare @sod_fml varchar(300)		--- Markup Formula
declare @fml varchar(300)
declare @sod_mubasprc numeric(13,4)	--- Markup Price
declare @ibi_catlvl3 varchar(20)		--- IM Category Level 3.

declare @OP char(1), @end int, @temp numeric(13,4)

-- Frankie Cheung 20110314 Add Original SC costs info.
declare @sod_ftycst_org numeric(13,4)
declare @sod_bomcst_org numeric(13,4)
declare @sod_ftyprc_org numeric(13,4)
declare @sod_dvftycst_org numeric(13,4)
declare @sod_dvftyprc_org numeric(13,4)
declare @sod_dvbomcst_org numeric(13,4)
declare @sod_imqutdat_org datetime
declare @sod_venno_org nvarchar(6)
declare @sod_fcurcde_org nvarchar(6)
declare @sod_dvfcurcde_org nvarchar(6)

set @sod_ftycst_org = @sod_ftycst
set @sod_bomcst_org = @sod_bomcst
set @sod_ftyprc_org = @sod_ftyprc
set @sod_dvftycst_org = @sod_dvftycst
set @sod_dvftyprc_org = @sod_dvftyprc
set @sod_dvbomcst_org = @sod_dvbomcst
set @sod_imqutdat_org = @imqutdat

set @sod_venno_org = @sod_venno
set @sod_fcurcde_org = @sod_fcurcde
set @sod_dvfcurcde_org = @sod_dvfcurcde

-------------------------------------------------



--- Get Item Vendor Type ---
set @Itmventyp = isnull(        (select 
			VBI_VENTYP	 
		FROM 
			IMBASINF (NOLOCK) 
			LEFT JOIN VNBASINF (NOLOCK) ON VBI_VENNO = IBI_VENNO
		WHERE
			IBI_ITMNO = @sod_itmno and
			VBI_VENTYP IS NOT NULL),' ')
------------------------------------


-- Retrive Category Level 3 --
set @IBI_CATLVL3 = ''
SELECT 
	@IBI_CATLVL3  = IBI_CATLVL3   
FROM 
	IMBASINF (nolock) 
WHERE 
	(IBI_ITMNO = @sod_itmno  OR IBI_ALSITMNO = @sod_itmno )  
	and ibi_itmsts <> 'CLO'
-----------------------------------

-- Retrive Customer Markup formula ---
set @sod_fml  = ''
set @sod_fmlopt  = ''
SELECT 
	@sod_fmlopt  = CCM_MARKUP  
FROM 
	CUMCAMRK (nolock) 
WHERE 
	CCM_CUSNO = @cusno AND 
	CCM_VENTYP = @Itmventyp and 
	ccm_cat = @ibi_catlvl3 

if ltrim(rtrim(@sod_fmlopt )) = ''
   begin 
	SELECT 
		@sod_fmlopt  = CCM_MARKUP  
	FROM 
		CUMCAMRK (nolock) 
	WHERE 
		CCM_CUSNO = @cusno AND 
		CCM_VENTYP = @Itmventyp and 
		ccm_cat = 'STANDARD'
   end
-------------------------------------------------

---- Retrive Formula ----
select 
	@sod_fml = yfi_fml
from 
	SYFMLINF
where
	yfi_fmlopt = @sod_fmlopt
-----------------------------
set @fml = @sod_fml
set @sod_mubasprc  =@sod_itmprc

while len(@fml) <> 0
	begin
		set @fml = ltrim(@fml)
		set @OP = substring(@fml,1,1)
		set @fml = substring(@fml, 2, len(@fml))
				
		if (charindex('*', @fml) = 0 and charindex('/', @fml) = 0)
		    begin
			set @end = len(@fml) + 1
		    end
		else if (charindex('*', @fml) = 0) 
  		    begin
			set @end = charindex('/', @fml)
		    end
		else if (charindex('/', @fml) = 0) 
		    begin
			set @end = charindex('*', @fml)
		    end
		else
		    begin
			if (charindex('*', @fml) < charindex('/', @fml)) 
			    begin
				set @end = charindex('*', @fml)
			    end
			else
			    begin
				set @end = charindex('/', @fml)
			    end
		   end
	
		set @temp = substring(@fml, 1, @end -1)

		if @OP = '*'
		    begin
			set @sod_mubasprc   = @sod_mubasprc  * @temp
		    end
		else if @OP = '/' 
		    begin
			set @sod_mubasprc   = @sod_mubasprc  / @temp
		    end
				
		set @fml = substring(@fml, @end, len(@fml))
	end


Set @sod_ordseq  = (Select isnull(max(sod_ordseq),0) + 1 from SCORDDTL Where sod_cocde = @sod_cocde and sod_ordno = @sod_ordno ) 




begin
Insert into SCORDDTL
(
sod_cocde,		sod_ordno,		sod_ordseq,	sod_updpo,	sod_chgfty,
sod_itmno,		sod_itmtyp,	sod_itmdsc,	sod_colcde,	sod_cuscol,
sod_coldsc,	sod_pckseq,	sod_pckunt,	sod_inrctn,		sod_mtrctn,
sod_cft,		sod_cbm,		sod_qutno,		sod_refdat,		sod_cusitm,
sod_cussku,	sod_resppo,	sod_cuspo,		sod_ordqty,	sod_discnt,
sod_oneprc,	sod_curcde,	sod_untprc,	sod_selprc,		sod_hrmcde,
sod_dtyrat,		sod_dept,		sod_typcode,	sod_code1,		sod_code2,
sod_code3,		sod_cususd,	sod_cuscad,	sod_inrdin,		sod_inrwin,
sod_inrhin,		sod_mtrdin,	sod_mtrwin,	sod_mtrhin,	sod_inrdcm,
sod_inrwcm,	sod_inrhcm,	sod_mtrdcm,	sod_mtrwcm,	sod_mtrhcm,
sod_shpstr,		sod_shpend,	sod_candat,	sod_ctnstr,		sod_ctnend,
sod_ttlctn,		sod_rmk,		sod_invqty,	sod_shpqty,	sod_venno,
sod_ftycst,		sod_ftyprc,		sod_fcurcde,	sod_purord,	sod_purseq,
sod_subcde,	sod_ftyunt,		sod_venitm,	sod_itmprc,	sod_pckitr,
sod_clmno,	sod_moa,		sod_moq,		sod_itmsts,		sod_apprve,
sod_creusr,		sod_updusr,	sod_credat,		sod_upddat,	sod_orgmoqchg,
sod_moqchg,	sod_netuntprc, 	sod_cusmoqchg, 	sod_venmoqchg, 	sod_assitmcount, 
sod_orgvenno, 	sod_fmlopt,	sod_fml,	sod_mubasprc, 	sod_bomcst,
sod_cusven, 	sod_cussub,	sod_pjobno,	sod_seccusitm,
sod_alsitmno,	sod_alscolcde
--Added by Mark Lau 20070206 SAP Implementation
 ,sod_ztnvbeln  ,sod_ztnposnr
,sod_zorvbeln  ,sod_zorposnr 
--Added by Mark Lau 20070622
, sod_conftr , sod_contopc
, sod_pcprc
--Added by Mark Lau 20080611
,sod_custum

-- added by Mark Lau 20080825
,sod_dv ,
sod_dvftycst ,	
sod_dvftyprc ,	
sod_dvbomcst ,	
sod_dvfcurcde ,	
sod_dvftyunt ,
-- Added by Mark Lau 20081107
sod_cusstyno 	,
-- Added by Mark Lau 20090205
sod_moqunttyp 	,
-- Frankie Cheung 20100413 Add CIH Period
sod_qutdat ,
-- Frankie Cheung 20100413 Add IM Period
sod_imqutdat ,
-- Frankie Cheung 20100712 Add Factory Cost
sod_itmcstcur,
sod_dvitmcst ,
-- Frankie Cheung 20110314 Add Original SC costs
sod_ftycst_org,
sod_bomcst_org,
sod_ftyprc_org,
sod_dvftycst_org,
sod_dvftyprc_org,
sod_dvbomcst_org,
sod_imqutdat_org,
sod_venno_org,
sod_fcurcde_org,
sod_dvfcurcde_org,
sod_imqutdatchg
)
values
(
@sod_cocde,		@sod_ordno,	@sod_ordseq,		@sod_updpo,		@sod_chgfty,
@sod_itmno,		@sod_itmtyp,	rtrim(ltrim(@sod_itmdsc)),	@sod_colcde,		rtrim(ltrim(@sod_cuscol)),
rtrim(ltrim(@sod_coldsc)),	@sod_pckseq,	@sod_pckunt,		@sod_inrctn,		@sod_mtrctn,
@sod_cft,			@sod_cbm,	@sod_qutno,		@sod_refdat,		rtrim(ltrim(@sod_cusitm)),
@sod_cussku,		@sod_resppo,	@sod_cuspo,		@sod_ordqty,		@sod_discnt,
@sod_oneprc,		@sod_curcde,	@sod_untprc,		@sod_selprc,		@sod_hrmcde,
@sod_dtyrat,		@sod_dept,	@sod_typcode,		@sod_code1,		@sod_code2,
@sod_code3,		@sod_cususd,	@sod_cuscad,		@sod_inrdin,		@sod_inrwin,
@sod_inrhin,		@sod_mtrdin,	@sod_mtrwin,		@sod_mtrhin,		@sod_inrdcm,
@sod_inrwcm,		@sod_inrhcm,	@sod_mtrdcm,		@sod_mtrwcm,		@sod_mtrhcm,
@sod_shpstr,		@sod_shpend,	@sod_candat,		@sod_ctnstr,		@sod_ctnend,
@sod_ttlctn,		@sod_rmk,	0,			0,			@sod_venno,	
@sod_ftycst,		@sod_ftyprc,	@sod_fcurcde,		'',			'',
@sod_subcde,		@sod_ftyunt,	@sod_venitm,		@sod_itmprc,		@sod_pckitr,
@sod_clmno,		@sod_moa,	@sod_moq,		@sod_itmsts,		@sod_apprve,
@sod_updusr,		@sod_updusr,	GETDATE(),		GETDATE(),		@sod_orgmoqchg,
@sod_moqchg,		@sod_netuntprc, 	@sod_cusmoqchg, 		@sod_venmoqchg, 		@sod_assitmcount, 
@sod_orgvenno, 		@sod_fmlopt,	@sod_fml,			@sod_mubasprc,	@sod_bomcst,
@sod_cusven, 		@sod_cussub,	@sod_pjobno,	@sod_seccusitm,
@sod_alsitmno,		@sod_alscolcde
--Added by Mark Lau 20070206 SAP Implementation
 ,@sod_ztnvbeln  ,@sod_ztnposnr
,@sod_zorvbeln  ,@sod_zorposnr 
--Added by Mark Lau 20070622
, @sod_conftr , @sod_contopc
, @sod_pcprc
--Added by Mark Lau 20080611
,@sod_custum,
-- added by Mark Lau 20080825
@sod_dv ,
@sod_dvftycst,
@sod_dvftyprc ,
@sod_dvbomcst ,
@sod_dvfcurcde ,
@sod_dvftyunt ,
-- Added by Mark Lau 20081107
@sod_cusstyno 	,
-- Added by Mark Lau 20090205
@sod_moqunttyp,
-- Frankie Cheung 20100413 Add CIH Period
@qutdat, 	
-- Frankie Cheung 20100413 Add IM Period
@imqutdat,
-- Frankie Cheung 20100712 Add Factory Cost
@sod_itmcstcur,
@sod_dvitmcst	,
-- Frankie Cheung 20110314 Add Original SC costs
@sod_ftycst_org,
@sod_bomcst_org,
@sod_ftyprc_org,
@sod_dvftycst_org,
@sod_dvftyprc_org,
@sod_dvbomcst_org,
@sod_imqutdat_org,
@sod_venno_org,
@sod_fcurcde_org,
@sod_dvfcurcde_org,
'N'
)



Select @Sod_ordseq                                                                                   
---------------------------------------------------------- 
-- Insert into Customer Item History Summary Information
if @sod_oneprc = 'N' and  @status  = 'ACT' and @closeout ='N' and @replace ='N'
begin
	if @sod_oneprc = 'N' and @status ='ACT'
	begin
		if @seccus  <> '' 
		begin
	
		if (	select 
				count(1) 
			from 
				CUITMSUM 
			where 
				--cis_cocde = @sod_cocde and 
				--cis_cusno = @cusno and 
				cis_cusno in 
				(select cbi_cusno from cubasinf where cbi_cusno = @cusno or cbi_cusali = @cusno
				 union
				select cbi_cusali from cubasinf where cbi_cusno = @cusno) and
				--cis_seccus = @seccus and

				cis_seccus in
				--= @seccus and
				(select cbi_cusno from cubasinf (nolock)   where (cbi_cusali = @seccus   or cbi_cusno = @seccus  ) and cbi_cusno <> ''
				   UNION
				   SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @seccus and cbi_cusali  <> '')  and

				--cis_itmno = @sod_itmno and 
				--cis_itmno  in (Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno  or ibi_alsitmno = @sod_itmno) and
				cis_itmno in
				(
				Select ibi.ibi_itmno  from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno or (ibi.ibi_alsitmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				union
				select ibi.ibi_alsitmno from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
				cis_colcde = @sod_colcde and 
				cis_untcde = @sod_pckunt and 
				cis_inrqty = @sod_inrctn and 
				--Added by Mark Lau 20070622
				cis_conftr = @sod_conftr and
				cis_mtrqty = @sod_mtrctn) = 0
		begin
			insert into [CUITMSUM]
			(
				cis_cocde ,	cis_cusno ,	cis_seccus,		cis_itmno ,
				cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
				cis_coldsc ,	cis_cuscol ,	cis_untcde ,
				cis_inrqty ,	cis_mtrqty ,	cis_cft ,
				cis_cbm ,		cis_refdoc ,	cis_docdat ,
				cis_cussku ,	cis_ordqty ,	cis_curcde ,
				cis_selprc ,		cis_hrmcde ,	cis_dtyrat ,
				cis_dept ,		cis_typcode ,	cis_code1 ,	
				cis_code2 ,		cis_code3 ,		cis_cususd ,
				cis_cuscad ,	cis_inrdin ,	cis_inrwin ,
				cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
				cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
				cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
				cis_mtrhcm ,	cis_creusr ,	cis_updusr ,	cis_pckitr,
				cis_credat ,	cis_upddat ,	cis_fcurcde,	cis_ftyprc,	cis_ftycst,
				cis_netselprc,	cis_moqchg, cis_itmventyp
				
				--Added by Mark Lau 20070622
				,cis_conftr -- , cis_contopc , cis_pcprc
				-- Added by Mark Lau 20081107
				,cis_cusstyno , cis_ftytmpitm	
				-- Added by Mark Lau 20090205
				--,cis_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period
				--SC no further update qu period in CIH 20110603
				--,cis_qutdat
			)
			values
			(
				--@sod_cocde,	@cusno,		@seccus,		@sod_itmno,
				' ',		@cusno,		@seccus,		@sod_itmno,
				@sod_itmdsc,	@sod_cusitm,	@sod_colcde,
				@sod_coldsc,	@sod_cuscol,	@sod_pckunt,
				@sod_inrctn,	@sod_mtrctn,	@sod_cft,
				@sod_cbm,	@sod_ordno,	Getdate(),
				@sod_cussku,	@sod_ordqty,	@sod_curcde,
				@sod_untprc,	@sod_hrmcde,	@sod_dtyrat,
				@sod_dept,	@sod_typcode,	@sod_code1,		
				@sod_code2,	@sod_code3,	@sod_cususd,
				@sod_cuscad,	@sod_inrdin,	@sod_inrwin,
				@sod_inrhin,	@sod_mtrdin,	@sod_mtrwin,

				@sod_mtrhin,	@sod_inrdcm,	@sod_inrwcm,
				@sod_inrhcm,	@sod_mtrdcm,	@sod_mtrwcm,
				@sod_mtrhcm,	@sod_updusr,	@sod_updusr,	@sod_pckitr,
				getdate(),		getdate(),		@sod_fcurcde,	@sod_ftyprc,	@sod_ftycst, 
				@sod_netuntprc,	@sod_moqchg, 	@itmventyp
				
				--Added by Mark Lau 20070622
				,@sod_conftr -- , @sod_contopc, @sod_pcprc
				-- Added by Mark Lau 20081107
				,@sod_cusstyno,''
				-- Added by Mark Lau 20090205
				--,@sod_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period
				--SC no further update qu period in CIH 20110603
				--,@qutdat 
			)
		end
		else
		begin	
			update 	
				CUITMSUM 	
			set 	
				cis_itmno = @sod_itmno,
				cis_itmdsc = @sod_itmdsc, 	cis_cusitm = @sod_cusitm,
				cis_coldsc = @sod_coldsc,	cis_cuscol = @sod_cuscol,
				cis_cft = @sod_cft,		cis_cbm = @sod_cbm,
				cis_fcurcde = @sod_fcurcde,
				cis_ftycst = @sod_ftycst,
				cis_ftyprc = @sod_ftyprc,
				cis_typcode = @sod_typcode,
				cis_code1  = @sod_code1,
				cis_code2  = @sod_code2,
				cis_code3  = @sod_code3,
				cis_refdoc = @sod_ordno,	cis_curcde = @sod_curcde,
				cis_ordqty = @sod_ordqty,	cis_docdat  = GETDATE(),
--				cis_selprc = @sod_untprc, 	
				cis_hrmcde = @sod_hrmcde,
				cis_dtyrat = @sod_dtyrat,	cis_dept = @sod_dept,
				cis_cususd = @sod_cususd,	cis_cuscad = @sod_cuscad,
				cis_inrdin = @sod_inrdin,	cis_inrwin = @sod_inrwin,
				cis_inrhin = @sod_inrhin, 	cis_mtrdin = @sod_mtrdin,
				cis_mtrwin = @sod_mtrwin,	cis_mtrhin = @sod_mtrhin,
				cis_inrdcm = @sod_inrdcm,	cis_inrwcm = @sod_inrwcm,
				cis_inrhcm = @sod_inrhcm,	cis_mtrdcm = @sod_mtrdcm,
				cis_mtrwcm = @sod_mtrwcm,	cis_mtrhcm = @sod_mtrhcm,
				cis_pckitr = @sod_pckitr,
				cis_updusr = @sod_updusr,	cis_upddat = getdate(),
--				cis_netselprc = @sod_netuntprc,
				cis_moqchg = @sod_moqchg,	cis_itmventyp=@itmventyp
				
				--Added by Mark Lau 20070622
				
				--,cis_contopc = @sod_contopc , 
				--cis_pcprc = @sod_pcprc
				-- Added by Mark Lau 20081107
				,cis_cusstyno = @sod_cusstyno 
				 , cis_ftytmpitm	= ''
				-- Added by Mark Lau 20090205
				--,cis_moqunttyp = @sod_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period				
				-- SC no further update qu period in CIH 20110603
				--,cis_qutdat = @qutdat

			where	 
				--cis_cocde = @sod_cocde and 
				--cis_cusno = @cusno and 
				cis_cusno in 
				(select cbi_cusno from cubasinf where cbi_cusno = @cusno or cbi_cusali = @cusno
				 union
				select cbi_cusali from cubasinf where cbi_cusno = @cusno) and

				cis_seccus = @seccus and

				--cis_itmno = @sod_itmno and 
				--cis_itmno  in (Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno  or ibi_alsitmno = @sod_itmno) and
				cis_itmno in
				(
				Select ibi.ibi_itmno  from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno or (ibi.ibi_alsitmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				union
				select ibi.ibi_alsitmno from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
				cis_colcde = @sod_colcde and 
				cis_untcde = @sod_pckunt and 
				cis_inrqty = @sod_inrctn and 
				cis_mtrqty = @sod_mtrctn and
				--Added by Mark Lau 20070622
				cis_conftr = @sod_conftr
		end
		end
	else
-------------------------------------------------------------------------------
	begin
		if (	select 
				count(1) 
			from 
				CUITMSUM 
			where 
				--cis_cocde = @sod_cocde and 
				--cis_cusno = @cusno and 
				cis_cusno in 
				(select cbi_cusno from cubasinf where cbi_cusno = @cusno or cbi_cusali = @cusno
				 union
				select cbi_cusali from cubasinf where cbi_cusno = @cusno) and
				--cis_seccus = @seccus and

				cis_seccus = @seccus and

				--cis_itmno = @sod_itmno and 
				--cis_itmno  in (Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno  or ibi_alsitmno = @sod_itmno) and
				cis_itmno in

				--(Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno or ibi_alsitmno = @sod_itmno 
				--union
				--select ibi_alsitmno from imbasinf where ibi_itmno = @sod_itmno ) and
				(
				Select ibi.ibi_itmno  from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno or (ibi.ibi_alsitmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				union
				select ibi.ibi_alsitmno from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
				cis_colcde = @sod_colcde and 
				cis_untcde = @sod_pckunt and 
				cis_inrqty = @sod_inrctn and 
				--Added by Mark Lau 20070622
				cis_conftr = @sod_conftr and
				cis_mtrqty = @sod_mtrctn) = 0
		begin
			insert into [CUITMSUM]
			(
				cis_cocde ,	cis_cusno ,	cis_seccus,		cis_itmno ,
				cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
				cis_coldsc ,	cis_cuscol ,	cis_untcde ,
				cis_inrqty ,	cis_mtrqty ,	cis_cft ,
				cis_cbm ,		cis_refdoc ,	cis_docdat ,
				cis_cussku ,	cis_ordqty ,	cis_curcde ,
				cis_selprc ,		cis_hrmcde ,	cis_dtyrat ,
				cis_dept ,		cis_typcode ,	cis_code1 ,	
				cis_code2 ,		cis_code3 ,		cis_cususd ,
				cis_cuscad ,	cis_inrdin ,	cis_inrwin ,
				cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
				cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
				cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
				cis_mtrhcm ,	cis_creusr ,	cis_updusr ,	cis_pckitr,
				cis_credat ,	cis_upddat ,	cis_fcurcde,	cis_ftyprc,	cis_ftycst,
				cis_netselprc,	cis_moqchg, cis_itmventyp
				
				--Added by Mark Lau 20070622
				,cis_conftr-- , cis_contopc, cis_pcprc
				-- Added by Mark Lau 20081107
				,cis_cusstyno 	 , cis_ftytmpitm	
				-- Added by Mark Lau 20090205
				--,cis_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period
				-- SC no further update qu period in CIH 20110603
				--,cis_qutdat
			)
			values
			(
				--@sod_cocde,	@cusno,		@seccus,		@sod_itmno,
				' ',		@cusno,		@seccus,		@sod_itmno,
				@sod_itmdsc,	@sod_cusitm,	@sod_colcde,
				@sod_coldsc,	@sod_cuscol,	@sod_pckunt,
				@sod_inrctn,	@sod_mtrctn,	@sod_cft,
				@sod_cbm,	@sod_ordno,	Getdate(),
				@sod_cussku,	@sod_ordqty,	@sod_curcde,
				@sod_untprc,	@sod_hrmcde,	@sod_dtyrat,
				@sod_dept,	@sod_typcode,	@sod_code1,		
				@sod_code2,	@sod_code3,	@sod_cususd,
				@sod_cuscad,	@sod_inrdin,	@sod_inrwin,
				@sod_inrhin,	@sod_mtrdin,	@sod_mtrwin,

				@sod_mtrhin,	@sod_inrdcm,	@sod_inrwcm,
				@sod_inrhcm,	@sod_mtrdcm,	@sod_mtrwcm,
				@sod_mtrhcm,	@sod_updusr,	@sod_updusr,	@sod_pckitr,
				getdate(),		getdate(),		@sod_fcurcde,	@sod_ftyprc,	@sod_ftycst, 
				@sod_netuntprc,	@sod_moqchg, 	@itmventyp
				--Added by Mark Lau 20070622
				,@sod_conftr-- , @sod_contopc, @sod_pcprc
				-- Added by Mark Lau 20081107
				,@sod_cusstyno 	,''
				-- Added by Mark Lau 20090205
				--,@sod_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period
				-- SC no further update qu period in CIH 20110603
				--,@qutdat
			)
		end
		else
		begin	
			update 	
				CUITMSUM 	
			set 	
				cis_itmno = @sod_itmno,
				cis_itmdsc = @sod_itmdsc, 	cis_cusitm = @sod_cusitm,
				cis_coldsc = @sod_coldsc,	cis_cuscol = @sod_cuscol,
				cis_cft = @sod_cft,		cis_cbm = @sod_cbm,
				cis_fcurcde = @sod_fcurcde,
				cis_ftycst = @sod_ftycst,
				cis_ftyprc = @sod_ftyprc,
				cis_typcode = @sod_typcode,
				cis_code1  = @sod_code1,
				cis_code2  = @sod_code2,
				cis_code3  = @sod_code3,
				cis_refdoc = @sod_ordno,	cis_curcde = @sod_curcde,
				cis_ordqty = @sod_ordqty,	cis_docdat  = GETDATE(),
--				cis_selprc = @sod_untprc, 	
				cis_hrmcde = @sod_hrmcde,
				cis_dtyrat = @sod_dtyrat,	cis_dept = @sod_dept,

				cis_cususd = @sod_cususd,	cis_cuscad = @sod_cuscad,
				cis_inrdin = @sod_inrdin,	cis_inrwin = @sod_inrwin,
				cis_inrhin = @sod_inrhin, 	cis_mtrdin = @sod_mtrdin,
				cis_mtrwin = @sod_mtrwin,	cis_mtrhin = @sod_mtrhin,
				cis_inrdcm = @sod_inrdcm,	cis_inrwcm = @sod_inrwcm,
				cis_inrhcm = @sod_inrhcm,	cis_mtrdcm = @sod_mtrdcm,
				cis_mtrwcm = @sod_mtrwcm,	cis_mtrhcm = @sod_mtrhcm,
				cis_pckitr = @sod_pckitr,
				cis_updusr = @sod_updusr,	cis_upddat = getdate(),
--				cis_netselprc = @sod_netuntprc,
				cis_moqchg = @sod_moqchg,	cis_itmventyp=@itmventyp
				
				--Added by Mark Lau 20070622
				--,cis_contopc = @sod_contopc, 
				--cis_pcprc = @sod_pcprc
				-- Added by Mark Lau 20081107
				,cis_cusstyno = @sod_cusstyno
				 , cis_ftytmpitm	 = ''
				-- Added by Mark Lau 20090205
				--,cis_moqunttyp = @sod_moqunttyp 	
				-- Frankie Cheung 20100413 Add Period
				-- SC no further update qu period in CIH 20110603
				--,cis_qutdat = @qutdat
			where	 
				--cis_cocde = @sod_cocde and 
				--cis_cusno = @cusno and 
				cis_cusno in 
				(select cbi_cusno from cubasinf where cbi_cusno = @cusno or cbi_cusali = @cusno
				 union
				select cbi_cusali from cubasinf where cbi_cusno = @cusno) and

				--cis_seccus = @seccus and
				cis_seccus = @seccus and

				--cis_itmno = @sod_itmno and 
				--cis_itmno  in (Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno  or ibi_alsitmno = @sod_itmno) and
				cis_itmno in
				--(Select ibi_itmno  from imbasinf where ibi_itmno = @sod_itmno or ibi_alsitmno = @sod_itmno 
				--union
				--select ibi_alsitmno from imbasinf where ibi_itmno = @sod_itmno ) and
				(
				Select ibi.ibi_itmno  from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno or (ibi.ibi_alsitmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD')
				union
				select ibi.ibi_alsitmno from imbasinf ibi
				left join imbasinf als on ibi.ibi_alsitmno = als.ibi_itmno 
				where ibi.ibi_itmno = @sod_itmno and isnull(als.ibi_itmsts,'') <> 'OLD'
				) and
				cis_colcde = @sod_colcde and 
				cis_untcde = @sod_pckunt and 
				cis_inrqty = @sod_inrctn and 
				--Added by Mark Lau 20070622
				cis_conftr = @sod_conftr and
				cis_mtrqty = @sod_mtrctn
		end
	end
end	
end
		--Insert into Customer Item History Detail Information

	if @status ='ACT' and @closeout ='N' and @replace ='N'
	Begin
	
		Set  @cid_seqno = 	(Select isnull(max(cid_seqno),0)  + 1 from CUITMDTL 
				 where 	cid_cocde = @sod_cocde and cid_cusno = @cusno and
					cid_seccus  =@seccus and
				 	cid_itmno = @sod_itmno and cid_colcde = @sod_colcde and 
					cid_inrqty = @sod_inrctn and cid_untcde = @sod_pckunt and 
					--Added by Mark Lau 20070622
					cid_conftr = @sod_conftr)
		
		insert into [CUITMDTL]
		(
			cid_cocde ,	cid_cusno ,	cid_seccus,	cid_seqno ,
			cid_itmno ,	cid_itmdsc ,	cid_cusitm ,
			cid_colcde ,	cid_coldsc ,	cid_cuscol ,
			cid_untcde ,	cid_inrqty ,	cid_mtrqty ,
			cid_cft ,		cid_cbm ,		cid_refdoc ,
			cid_docdat ,	cid_cussku ,	cid_ordqty ,
			cid_curcde ,	cid_selprc ,	cid_hrmcde ,
			cid_dtyrat ,	cid_dept ,		cid_typcode ,
			cid_code1 ,	cid_code2 ,	cid_code3 ,
			cid_cususd ,	cid_cuscad ,	cid_inrdin ,
			cid_inrwin ,	cid_inrhin ,	cid_mtrdin ,
			cid_mtrwin ,	cid_mtrhin ,	cid_inrdcm ,
			cid_inrwcm ,	cid_inrhcm ,	cid_mtrdcm ,
			cid_mtrwcm ,	cid_mtrhcm ,	cid_onetim,
			cid_creusr ,	cid_updusr ,	cid_credat ,	cid_pckitr,
			cid_upddat,	cid_fcurcde,	cid_ftyprc,	cid_ftycst,
			cid_netselprc,		cid_moqchg,	cid_itmventyp,
				--Added by Mark Lau 20070622
			cid_conftr, cid_contopc, cid_pcprc
			-- Added by Mark Lau 20081107
			,cid_cusstyno 	 , cid_ftytmpitm	
				-- Added by Mark Lau 20090205
				--,cid_moqunttyp 	
			-- Frankie Cheung 20100413 Add Period
			-- SC no further update qu period in CIH
			--,cid_qutdat
		) 
		values
		(
			@sod_cocde,	@cusno,		@seccus,		@cid_seqno,
			@sod_itmno,	@sod_itmdsc,	@sod_cusitm,
			@sod_colcde,	@sod_coldsc,	@sod_cuscol,
			@sod_pckunt,	@sod_inrctn,	@sod_mtrctn,
			@sod_cft,	@sod_cbm,	@sod_ordno,
			GETDATE(),	@sod_cussku,	@sod_ordqty,
			@sod_curcde,	@sod_untprc, 	@sod_hrmcde,
			@sod_dtyrat,	@sod_dept,	@sod_typcode,
			@sod_code1,	@sod_code2,	@sod_code3,
			@sod_cususd,	@sod_cuscad,	@sod_inrdin,
			@sod_inrwin,	@sod_inrhin,	@sod_mtrdin,
			@sod_mtrwin,	@sod_mtrhin,	@sod_inrdcm,
			@sod_inrwcm,	@sod_inrhcm,	@sod_mtrdcm,
			@sod_mtrwcm,	@sod_mtrhcm,	@sod_oneprc,
			@sod_updusr,	@sod_updusr,	getdate(),	@sod_pckitr,	
			getdate(),		@sod_fcurcde,	@sod_ftyprc,	@sod_ftycst,
			@sod_netuntprc,	@sod_moqchg,	@itmventyp,
				--Added by Mark Lau 20070622
			@sod_conftr, @sod_contopc, @sod_pcprc
			-- Added by Mark Lau 20081107
			,@sod_cusstyno 	,''
				-- Added by Mark Lau 20090205
				--,@sod_moqunttyp 	
			-- Frankie Cheung 20100413 Add Period
			-- SC no further update qu period in CIH
			--,@qutdat
		)
end
end















GO
GRANT EXECUTE ON [dbo].[sp_Select_SCORDDTL_insert] TO [ERPUSER] AS [dbo]
GO
