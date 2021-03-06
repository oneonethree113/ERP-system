/****** Object:  StoredProcedure [dbo].[sp_insert_QUOTNDTL2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_QUOTNDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_QUOTNDTL2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




/*
=========================================================
Description   	: sp_insert_QUOTNDTL2
Programmer  	: Carlos Lui
Create Date   	: 
Last Modified  	: 2012-06-17
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description          
=========================================================     
*/

CREATE PROCEDURE [dbo].[sp_insert_QUOTNDTL2] 

@qud_cocde	nvarchar(6) ,	@qud_qutno 	nvarchar(20),	@qud_qutseq 	int,
@qud_itmno 	nvarchar(20),	@qud_itmsts 	nvarchar(4),	@qud_itmdsc 	nvarchar(800),
@qud_alsitmno 	nvarchar(20), 	@qud_alscolcde	nvarchar(30),	@qud_conftr	numeric(9),
@qud_contopc	nvarchar(1),	@qud_pcprc	numeric(13,4),	@qud_hstref 	nvarchar(20),
@qud_colcde 	nvarchar(30),	@qud_cuscol 	nvarchar(30),	@qud_coldsc 	nvarchar(300),
@qud_pckseq 	int,		@qud_untcde 	nvarchar(6),	@qud_inrqty 	int,
@qud_mtrqty 	int,		@qud_cft 		numeric(11,4),	@qud_curcde 	nvarchar(6),
@qud_cus1sp 	numeric(13,4),	@qud_cus2sp 	numeric(13,4),	@qud_cus1dp 	numeric(13,4),
@qud_cus2dp 	numeric(13,4),	@qud_onetim 	nvarchar(1),	@qud_discnt 	numeric(6,3),
@qud_moflag	char(1),		@qud_orgmoq	int,		@qud_orgmoa	numeric(11,4),
@qud_moq 	int,		@qud_moa 	numeric(11,4),	@qud_smpqty 	int,
@qud_hrmcde 	nvarchar(12),	@qud_dtyrat 	numeric(6,3),	@qud_dept 	nvarchar(20),
@qud_cususd 	numeric(13,4),	@qud_cuscad 	numeric(13,4),	@qud_venno 	nvarchar(6),
@qud_subcde	nvarchar(10),	@qud_venitm 	nvarchar(20),	@qud_ftyprc 	numeric(13,4),
@qud_ftycst 	numeric(13,4),	@qud_note 	nvarchar(300),	@qud_image 	nvarchar(1),
@qud_inrdin 	numeric(11,4),	@qud_inrwin 	numeric(11,4),	@qud_inrhin 	numeric(11,4),
@qud_mtrdin 	numeric(11,4),	@qud_mtrwin 	numeric(11,4),	@qud_mtrhin 	numeric(11,4),
@qud_inrdcm 	numeric(11,4),	@qud_inrwcm 	numeric(11,4),	@qud_inrhcm 	numeric(11,4),	
@qud_mtrdcm 	numeric(11,4),	@qud_mtrwcm 	numeric(11,4),	@qud_mtrhcm 	numeric(11,4),	
@qud_grswgt 	numeric(6,3),	@qud_netwgt 	numeric(6,3),	@qud_cosmth 	nvarchar(50),	
@qud_smpprc	numeric(13,4),	@qud_cusitm	nvarchar(20),	@cus1no		nvarchar(6),	
@cus1na		nvarchar(20),	@cus2no		nvarchar(6),	@cus2na		nvarchar(20),	
@qud_prcsec	nvarchar(3),	@qud_grsmgn	numeric(6,3),	@qud_basprc	numeric(13,4),	
@qud_tbm		nvarchar(1),	@qud_tbmsts	nvarchar(3),	@rvsdat		datetime,		
@qud_apprve	nvarchar(1),	@qud_pckitr	nvarchar(300),	@qud_stkqty	int,		
@qud_cusqty	int,		@qud_smpunt	nvarchar(6),	@qud_qutitmsts	nvarchar(10),	
@qud_fcurcde	nvarchar(6),	@qud_itmtyp	nvarchar(4),	@quh_qutsts	nvarchar(10),	
@qud_prctrm	nvarchar(10),	@qud_cusven	varchar(6),		@qud_cussub	varchar(10),
@qud_ftyprctrm	varchar(20),	@qud_cusstyno	nvarchar(50),	@qud_cbm	numeric(11, 4),
@qud_upc		nvarchar(50),	@qud_specpck	nvarchar(255),	@qud_ftytmpitm	nvarchar(1),
@qud_ftytmpitmno	nvarchar(20),	@qud_custitmcat	nvarchar(12),	@qud_custitmcatfml	nvarchar(6),
@qud_custitmcatamt	numeric(13,4),	@qud_pmu	nvarchar(100),	@qud_imrmk	nvarchar(255),
@qud_rndsts	nvarchar(255),	@qud_calpmu	numeric(13,4),	@qud_moqunttyp	nvarchar(6),
@qud_qutdat	datetime,		@qud_cus1no	nvarchar(6),	@qud_cus2no	nvarchar(6),
@qud_trantrm	nvarchar(10),	@qud_effdat	datetime,		@qud_expdat	datetime,
@qud_creusr	nvarchar(30)

AS

declare	@seq	int,		@cid_seqno	int
Declare @Itmventyp char(1)

Set  @seq = (	select	isnull(max(qud_qutseq),0) + 1
		from	QUOTNDTL
		where	qud_cocde = @qud_cocde	and
			qud_qutno = @qud_qutno)

select @seq -- Warning : Cannot delete this selection

--- Get Item Vendor Type ---
set @Itmventyp = isnull(
			(	select	VBI_VENTYP	 
				from	IMBASINF (NOLOCK) 
				left join VNBASINF (NOLOCK) ON VBI_VENNO = IBI_VENNO
				where	IBI_ITMNO = @qud_itmno	and
					VBI_VENTYP IS NOT NULL),
		' ')

insert into	[QUOTNDTL]
	(qud_cocde ,	qud_qutno ,	qud_qutseq ,
	qud_itmno ,	qud_itmsts ,	qud_itmdsc ,
	qud_alsitmno,	qud_alscolcde,	qud_conftr ,
	qud_contopc , 	qud_pcprc,		qud_hstref ,
	qud_colcde ,	qud_cuscol ,	qud_coldsc ,
	qud_pckseq ,	qud_untcde ,	qud_inrqty ,
	qud_mtrqty ,	qud_cft ,		qud_curcde ,
	qud_cus1sp ,	qud_cus2sp ,	qud_cus1dp ,
	qud_cus2dp ,	qud_onetim ,	qud_discnt ,
	qud_moq ,		qud_moa ,		qud_smpqty ,
	qud_hrmcde ,	qud_dtyrat ,	qud_dept ,
	qud_cususd ,	qud_cuscad ,	qud_venno ,
	qud_venitm ,	qud_ftyprc ,	qud_note ,
	qud_image ,	qud_inrdin ,	qud_inrwin ,
	qud_inrhin ,	qud_mtrdin ,	qud_mtrwin ,
	qud_mtrhin ,	qud_inrdcm ,	qud_inrwcm ,
	qud_inrhcm ,	qud_mtrdcm ,	qud_mtrwcm ,
	qud_mtrhcm ,	qud_grswgt ,	qud_netwgt ,
	qud_cosmth ,	qud_creusr ,	qud_updusr ,
	qud_credat ,	qud_upddat ,	qud_smpprc,
	qud_cusitm,	qud_prcsec,	qud_grsmgn,
	qud_basprc,	qud_tbm,		qud_tbmsts,
	qud_apprve,	qud_pckitr,		qud_stkqty,
	qud_cusqty,	qud_smpunt,	qud_qutitmsts,
	qud_fcurcde,	qud_itmtyp,	qud_subcde,
	qud_ftycst,		qud_prctrm,	qud_moflag,
	qud_orgmoq,	qud_orgmoa,	qud_cusven,
	qud_cussub, 	qud_ftyprctrm,	qud_cusstyno ,
	qud_cbm,		qud_upc ,		qud_specpck,
	qud_ftytmpitm,	qud_ftytmpitmno,	qud_custitmcat,
	qud_custitmcatfml,	qud_custitmcatamt,	qud_pmu,
	qud_imrmk,	qud_rndsts,	qud_calpmu,
	qud_moqunttyp,	qud_qutdat,	qud_cus1no,
	qud_cus2no,	qud_trantrm,	qud_effdat,
	qud_expdat)
values	(@qud_cocde ,	@qud_qutno ,	@seq ,
	@qud_itmno ,	@qud_itmsts ,	@qud_itmdsc ,
	@qud_alsitmno,	@qud_alscolcde,	@qud_conftr ,
	@qud_contopc , 	@qud_pcprc,	@qud_hstref ,
	@qud_colcde ,	@qud_cuscol ,	@qud_coldsc ,
	@qud_pckseq ,	@qud_untcde ,	@qud_inrqty ,
	@qud_mtrqty ,	@qud_cft ,		@qud_curcde ,
	@qud_cus1sp ,	@qud_cus2sp ,	@qud_cus1dp ,
	@qud_cus2dp ,	@qud_onetim ,	@qud_discnt ,
	@qud_moq ,	@qud_moa ,	@qud_smpqty ,
	@qud_hrmcde ,	@qud_dtyrat ,	@qud_dept ,
	@qud_cususd ,	@qud_cuscad ,	@qud_venno ,
	@qud_venitm ,	@qud_ftyprc ,	@qud_note ,
	@qud_image ,	@qud_inrdin ,	@qud_inrwin ,
	@qud_inrhin ,	@qud_mtrdin ,	@qud_mtrwin ,
	@qud_mtrhin ,	@qud_inrdcm ,	@qud_inrwcm ,
	@qud_inrhcm ,	@qud_mtrdcm ,	@qud_mtrwcm ,
	@qud_mtrhcm ,	@qud_grswgt ,	@qud_netwgt ,
	@qud_cosmth ,	@qud_creusr ,	@qud_creusr ,
	getdate() ,		getdate() ,		@qud_smpprc ,
	@qud_cusitm ,	@qud_prcsec ,	@qud_grsmgn ,
	@qud_basprc,	@qud_tbm,	@qud_tbmsts,
	@qud_apprve,	@qud_pckitr,	@qud_stkqty,
	@qud_cusqty,	@qud_smpunt,	@qud_qutitmsts,
	@qud_fcurcde,	@qud_itmtyp,	@qud_subcde,
	@qud_ftycst,	@qud_prctrm,	@qud_moflag,
	@qud_orgmoq,	@qud_orgmoa,	@qud_cusven,
	@qud_cussub, 	@qud_ftyprctrm,	@qud_cusstyno ,
	@qud_cbm,	@qud_upc ,	@qud_specpck,
	@qud_ftytmpitm,	@qud_ftytmpitmno,	@qud_custitmcat,
	@qud_custitmcatfml,	@qud_custitmcatamt,	@qud_pmu,
	@qud_imrmk,	@qud_rndsts,	@qud_calpmu,
	@qud_moqunttyp,	@qud_qutdat,	@qud_cus1no,
	@qud_cus2no,	@qud_trantrm,	@qud_effdat,
	@qud_expdat)

UPDATE 	IMBASINF
SET	ibi_latrdat = getdate()
WHERE 	ibi_itmno = @qud_itmno

-- Insert into Customer Item History Summary Information
if @quh_qutsts = 'A' 
begin
	if	@qud_tbm = 'N'		and
		@qud_qutitmsts = 'COMPLETE'	and
		(@qud_apprve = ''	or
		 @qud_apprve = 'Y')
	begin
		if @qud_onetim = 'N' 
		begin
			if @cus2no   <> '' 
			begin 
				if (	select	count(*) 
					from 	CUITMSUM 
					where 	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no) and
									cbi_cusno <> ''
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no and
									cbi_cusali <> '')		and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <> 'OLD')	and
						cis_colcde = @qud_colcde				and
						cis_untcde = @qud_untcde				and 
						cis_inrqty = @qud_inrqty				and 
						cis_conftr = @qud_conftr				and
						cis_mtrqty = @qud_mtrqty) = 0
				begin
					insert into	[CUITMSUM]
						(cis_cocde ,	cis_cusno ,		cis_itmno ,
						 cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
						 cis_coldsc ,	cis_cuscol ,		cis_untcde ,
						 cis_inrqty ,	cis_mtrqty ,	cis_cft ,
						 cis_cbm ,		cis_refdoc ,		cis_docdat ,
						 cis_cussku ,	cis_ordqty ,	cis_curcde ,
						 cis_selprc ,	cis_hrmcde ,	cis_dtyrat ,
						 cis_dept ,		cis_typcode ,	cis_code1 ,	
						 cis_code2 ,	cis_code3 ,		cis_cususd ,
						 cis_cuscad ,	cis_inrdin ,		cis_inrwin ,
						 cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
						 cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
						 cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
						 cis_mtrhcm ,	cis_creusr ,		cis_updusr ,
						 cis_credat ,	cis_upddat ,	cis_pckitr ,
						 cis_seccus ,	cis_secsna ,	cis_fcurcde ,
						 cis_ftyprc ,	cis_ftycst,		cis_netselprc,
						 cis_moqchg,	cis_itmventyp,	cis_moq,
						 cis_moa,		cis_moacur,	cis_conftr ,
						 cis_contopc,	cis_pcprc,		cis_ftytmpitm,
						 cis_cusstyno,	cis_moqunttyp,	cis_qutdat,
						 cis_cus1no,	cis_cus2no,	cis_hkprctrm,
						 cis_ftyprctrm,	cis_trantrm,	cis_effdat,
						 cis_expdat)  
					values	(' ',		@cus1no,		@qud_itmno,
						 @qud_itmdsc,	@qud_cusitm,	@qud_colcde,
						 @qud_coldsc,	@qud_cuscol,	@qud_untcde,
						 @qud_inrqty,	@qud_mtrqty,	@qud_cft,
						 @qud_cft/35.3356,	@qud_qutno,	@rvsdat,
						 '',		0,		@qud_curcde,
						 @qud_cus1dp,	@qud_hrmcde,	@qud_dtyrat,
						 @qud_dept,	'U',		'',		
						 '',		'',		@qud_cususd,
						 @qud_cuscad,	@qud_inrdin,	@qud_inrwin,
						 @qud_inrhin,	@qud_mtrdin,	@qud_mtrwin,
						 @qud_mtrhin,	@qud_inrdcm,	@qud_inrwcm,
						 @qud_inrhcm,	@qud_mtrdcm,	@qud_mtrwcm,
						 @qud_mtrhcm,	@qud_creusr,	@qud_creusr,
						 getdate(),		getdate(),		@qud_pckitr,
						 @cus2no,		@cus2na,		@qud_fcurcde,
						 @qud_ftyprc,	@qud_ftycst,	@qud_cus1dp,
						 0,		@ItmVenTyp,	case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,
						 case @qud_moflag
							when 'A' then @qud_moa
							else 0 end,	@qud_curcde,	@qud_conftr ,
						 @qud_contopc,	@qud_pcprc,	isnull(@qud_ftytmpitmno,''),
						 isnull(@qud_cusstyno,''), @qud_moqunttyp,	@qud_qutdat,
						 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
						 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
						 @qud_expdat)  
				end
				else
				begin	
					update	CUITMSUM 	
					set 	cis_itmno = @qud_itmno,	cis_itmdsc = @qud_itmdsc, 	cis_cusitm = @qud_cusitm,
						cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
						cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,
						cis_selprc = @qud_cus1dp, 	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,
						cis_dept = @qud_dept,		cis_cususd = @qud_cususd,	cis_cuscad = @qud_cuscad,
						cis_inrdin = @qud_inrdin,	cis_inrwin = @qud_inrwin,	cis_inrhin = @qud_inrhin,
					 	cis_mtrdin = @qud_mtrdin,	cis_mtrwin = @qud_mtrwin,	cis_mtrhin = @qud_mtrhin,
						cis_inrdcm = @qud_inrdcm,	cis_inrwcm = @qud_inrwcm,	cis_inrhcm = @qud_inrhcm,	
						cis_mtrdcm = @qud_mtrdcm,	cis_mtrwcm = @qud_mtrwcm,	cis_mtrhcm = @qud_mtrhcm,
						cis_updusr = @qud_creusr,	cis_upddat = getdate(),		cis_docdat = @rvsdat,
						cis_pckitr = @qud_pckitr,	cis_fcurcde = @qud_fcurcde,	cis_ftyprc = @qud_ftyprc,
						cis_ftycst = @qud_ftycst,	cis_netselprc = @qud_cus1dp,	cis_moqchg = 0,
						cis_itmventyp = @ItmVenTyp,	cis_moq = case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,	cis_moa = case @qud_moflag
														when 'A' then @qud_moa
														else 0 end,
						cis_moacur = @qud_curcde,	cis_contopc = @qud_contopc,	cis_pcprc = @qud_pcprc,
						cis_ftytmpitm = isnull(@qud_ftytmpitmno,''),	cis_cusstyno = isnull(@qud_cusstyno,''), cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	(cbi_cusali = @cus2no or
									 cbi_cusno = @cus2no) and
									 cbi_cusno <> ''
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus2no and
									cbi_cusali <> '')		and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde				and 
						cis_untcde = @qud_untcde				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty
				end
			end
			else  -- i.e. @cus2no = '' 	
			begin
				if (	select	count(*) 
					from 	CUITMSUM 
					where 	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus = @cus2no					and
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde				and 
						cis_untcde = @qud_untcde 				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty) = 0
				begin
					insert into	[CUITMSUM]
						(cis_cocde ,	cis_cusno ,		cis_itmno ,
						 cis_itmdsc ,	cis_cusitm ,	cis_colcde ,
						 cis_coldsc ,	cis_cuscol ,		cis_untcde ,
						 cis_inrqty ,	cis_mtrqty ,	cis_cft ,
						 cis_cbm ,		cis_refdoc ,		cis_docdat ,
						 cis_cussku ,	cis_ordqty ,	cis_curcde ,
						 cis_selprc ,	cis_hrmcde ,	cis_dtyrat ,
						 cis_dept ,		cis_typcode ,	cis_code1 ,	
						 cis_code2 ,	cis_code3 ,		cis_cususd ,
						 cis_cuscad ,	cis_inrdin ,		cis_inrwin ,
						 cis_inrhin ,	cis_mtrdin ,	cis_mtrwin ,
						 cis_mtrhin ,	cis_inrdcm ,	cis_inrwcm ,
						 cis_inrhcm ,	cis_mtrdcm ,	cis_mtrwcm ,
						 cis_mtrhcm ,	cis_creusr ,		cis_updusr ,
						 cis_credat ,	cis_upddat ,	cis_pckitr ,
						 cis_seccus ,	cis_secsna ,	cis_fcurcde ,
						 cis_ftyprc ,	cis_ftycst,		cis_netselprc,
					 	 cis_moqchg,	cis_itmventyp,	cis_moq,	
					 	 cis_moa,		cis_moacur	,	cis_conftr ,
						 cis_contopc, 	cis_pcprc,		cis_ftytmpitm,
						 cis_cusstyno,	cis_moqunttyp,	cis_qutdat,
						 cis_cus1no,	cis_cus2no,	cis_hkprctrm,
						 cis_ftyprctrm,	cis_trantrm,	cis_effdat,
						 cis_expdat)  
					values	(' ',		@cus1no,		@qud_itmno,
						 @qud_itmdsc,	@qud_cusitm,	@qud_colcde,
						 @qud_coldsc,	@qud_cuscol,	@qud_untcde,
						 @qud_inrqty,	@qud_mtrqty,	@qud_cft,
						 @qud_cft/35.3356,	@qud_qutno,	@rvsdat,
						 '',		0,		@qud_curcde,
						 @qud_cus1dp,	@qud_hrmcde,	@qud_dtyrat,
						 @qud_dept,	'U',		'',		
						 '',		'',		@qud_cususd,
						 @qud_cuscad,	@qud_inrdin,	@qud_inrwin,
						 @qud_inrhin,	@qud_mtrdin,	@qud_mtrwin,
						 @qud_mtrhin,	@qud_inrdcm,	@qud_inrwcm,
						 @qud_inrhcm,	@qud_mtrdcm,	@qud_mtrwcm,
						 @qud_mtrhcm,	@qud_creusr,	@qud_creusr,
						 getdate(),		getdate(),		@qud_pckitr,
						 @cus2no,		@cus2na,		@qud_fcurcde,
						 @qud_ftyprc,	@qud_ftycst,	@qud_cus1dp,
						 0,		@ItmVenTyp,	case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,
						 case @qud_moflag
							when 'A' then @qud_moa
							else 0 end,	@qud_curcde,	@qud_conftr ,
						 @qud_contopc,	@qud_pcprc,	 isnull(@qud_ftytmpitmno,''),
						 isnull(@qud_cusstyno,''), @qud_moqunttyp,	@qud_qutdat,
						 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
						 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
						 @qud_expdat)  
				end
				else -- i.e. CUITMSUM > 0 
				begin	
					update	CUITMSUM 	
					set 	cis_itmno = @qud_itmno,	cis_itmdsc = @qud_itmdsc, 	cis_cusitm = @qud_cusitm,
						cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
						cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,
						cis_selprc = @qud_cus1dp, 	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,	
						cis_dept = @qud_dept,		cis_cususd = @qud_cususd,	cis_cuscad = @qud_cuscad,
						cis_inrdin = @qud_inrdin,	cis_inrwin = @qud_inrwin,	cis_inrhin = @qud_inrhin, 	
						cis_mtrdin = @qud_mtrdin,	cis_mtrwin = @qud_mtrwin,	cis_mtrhin = @qud_mtrhin,
						cis_inrdcm = @qud_inrdcm,	cis_inrwcm = @qud_inrwcm,	cis_inrhcm = @qud_inrhcm,	
						cis_mtrdcm = @qud_mtrdcm,	cis_mtrwcm = @qud_mtrwcm,	cis_mtrhcm = @qud_mtrhcm,
						cis_updusr = @qud_creusr,	cis_upddat = getdate(),		cis_docdat = @rvsdat,		
						cis_pckitr = @qud_pckitr,	cis_fcurcde = @qud_fcurcde,	cis_ftyprc = @qud_ftyprc,
						cis_ftycst = @qud_ftycst,	cis_netselprc = @qud_cus1dp,	cis_moqchg = 0,
						cis_itmventyp = @ItmVenTyp,	cis_moq = case @qud_moflag
											when 'Q' then @qud_moq
											else 0 end,	cis_moa = case @qud_moflag
														when 'A' then @qud_moa
														else 0 end,
						cis_moacur = @qud_curcde,	cis_contopc = @qud_contopc,	cis_pcprc = @qud_pcprc,
						cis_ftytmpitm = isnull(@qud_ftytmpitmno,''),	cis_cusstyno = isnull(@qud_cusstyno,''), cis_moqunttyp = @qud_moqunttyp,
						cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
						cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
						cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
					where	cis_cusno in (	select	cbi_cusno
								from	cubasinf (nolock)
								where	cbi_cusali = @cus1no or
									cbi_cusno = @cus1no
								union
								select	cbi_cusali
								from	cubasinf (nolock)
								where	cbi_cusno = @cus1no)		and
						cis_seccus =  @cus2no 				and 
						cis_itmno in (	select	ibi_itmno
								from	imbasinf
								where	ibi_itmno = @qud_itmno or
									ibi_alsitmno = @qud_itmno 
								union
								select	bas.ibi_alsitmno
								from	imbasinf bas
								left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
								where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <>'OLD')	and
						cis_colcde = @qud_colcde 				and 
						cis_untcde = @qud_untcde 				and 
						cis_inrqty = @qud_inrqty 				and 
						cis_conftr = @qud_conftr 				and
						cis_mtrqty = @qud_mtrqty
				end
			end
		end	
	end
		
	--Insert into Customer Item History Detail Information
	if @qud_tbm = 'N'  
	begin
		set	@cid_seqno = (	select	isnull(max(cid_seqno),0) + 1
					from	CUITMDTL 
					where 	cid_cocde = @qud_cocde	and
						cid_cusno = @cus1no		and
						cid_seccus = @cus2no 	and
						cid_itmno = @qud_itmno 	and 
						cid_colcde = @qud_colcde 	and
						cid_inrqty = @qud_inrqty 	and 
						cid_untcde = @qud_untcde 	and
						cid_conftr = @qud_conftr)

		insert into	[CUITMDTL]
			(cid_cocde ,	cid_cusno ,		cid_seqno ,
			 cid_itmno ,	cid_itmdsc ,	cid_cusitm ,
			 cid_colcde ,	cid_coldsc ,	cid_cuscol ,
			 cid_untcde ,	cid_inrqty ,		cid_mtrqty ,
			 cid_cft ,		cid_cbm ,		cid_refdoc ,
			 cid_docdat ,	cid_cussku ,	cid_ordqty ,
			 cid_curcde ,	cid_selprc ,		cid_hrmcde ,
			 cid_dtyrat ,	cid_dept ,		cid_typcode ,
		 	 cid_code1 ,	cid_code2 ,		cid_code3 ,
			 cid_cususd ,	cid_cuscad ,	cid_inrdin ,
			 cid_inrwin ,	cid_inrhin ,		cid_mtrdin ,
			 cid_mtrwin ,	cid_mtrhin ,	cid_inrdcm ,
			 cid_inrwcm ,	cid_inrhcm ,	cid_mtrdcm ,
			 cid_mtrwcm ,	cid_mtrhcm ,	cid_onetim,
			 cid_creusr ,	cid_updusr ,	cid_credat ,
			 cid_upddat ,	cid_pckitr ,		cid_seccus ,
			 cid_secsna ,	cid_fcurcde ,	cid_ftyprc ,
			 cid_ftycst,		cid_netselprc,	cid_moqchg,
			 cid_itmventyp,	cid_moq,		cid_moa,
			 cid_moacur,	cid_conftr,		cid_contopc,
			 cid_pcprc,		cid_ftytmpitm,	cid_cusstyno,
			 cid_moqunttyp,	cid_qutdat,		cid_cus1no,
			 cid_cus2no,	cid_hkprctrm,	cid_ftyprctrm,
			 cid_trantrm,	cid_effdat,		cid_expdat)   
		values	(@qud_cocde,	@cus1no,		@cid_seqno,
			 @qud_itmno,	@qud_itmdsc,	@qud_cusitm,
			 @qud_colcde,	@qud_coldsc,	@qud_cuscol,
			 @qud_untcde,	@qud_inrqty,	@qud_mtrqty,
			 @qud_cft,		@qud_cft/35.3356,	@qud_qutno,
			 @rvsdat,		'',		0,
			 @qud_curcde,	@qud_cus1dp,	@qud_hrmcde,
			 @qud_dtyrat,	@qud_dept,	'U',
			 '',		'',		'',
			 @qud_cususd,	@qud_cuscad,	@qud_inrdin,
			 @qud_inrwin,	@qud_inrhin,	@qud_mtrdin,
			 @qud_mtrwin,	@qud_mtrhin,	@qud_inrdcm,
			 @qud_inrwcm,	@qud_inrhcm,	@qud_mtrdcm,
			 @qud_mtrwcm,	@qud_mtrhcm,	@qud_onetim,
			 @qud_creusr,	@qud_creusr,	getdate(),	
			 getdate(),		@qud_pckitr,	@cus2no,
			 @cus2na,		@qud_fcurcde,	@qud_ftyprc,
			 @qud_ftycst,	@qud_cus1dp,	0,
			 @itmventyp,	case @qud_moflag
						when 'Q' then @qud_moq
						else 0 end,	case @qud_moflag
								when 'A' then @qud_moa
								else 0 end,
			 @qud_curcde,	@qud_conftr,	@qud_contopc,
			 @qud_pcprc,	isnull(@qud_ftytmpitmno,''),	isnull(@qud_cusstyno,''),
			 @qud_moqunttyp,	@qud_qutdat,	@qud_cus1no,
			 @qud_cus2no,	@qud_prctrm,	@qud_ftyprctrm,
			 @qud_trantrm,	@qud_effdat,	@qud_expdat)  
	end
end




GO
GRANT EXECUTE ON [dbo].[sp_insert_QUOTNDTL2] TO [ERPUSER] AS [dbo]
GO
