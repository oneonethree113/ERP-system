/****** Object:  StoredProcedure [dbo].[sp_update_QUOTNDTL_qutsts]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_QUOTNDTL_qutsts]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_QUOTNDTL_qutsts]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



/*  
=========================================================  
Description    : sp_update_QUOTNDTL_tbc
ALTER  Date    :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
 Date      Initial   Description                            
=========================================================       
*/  
  
CREATE         PROCEDURE [dbo].[sp_update_QUOTNDTL_qutsts]   
@qud_cocde	nvarchar(6),	
@qud_qutno  nvarchar(20),	
@qud_qutseq  int    ,
@qud_qutitmsts  nvarchar(20),	
@qud_apprve nvarchar(20),	
@user			nvarchar(30)
AS  

update	QUOTNDTL   
set	qud_qutitmsts =@qud_qutitmsts,
	qud_apprve= @qud_apprve,	
	qud_updusr = @user	
where	
	qud_cocde = @qud_cocde	and
	qud_qutno = @qud_qutno	and
	qud_qutseq = @qud_qutseq















  

/*
-- Insert into Customer Item History Summary Information  
if @qud_tbm = 'N' and @qud_qutitmsts = 'A - Active' and (@qud_apprve = '' or @qud_apprve = 'Y')  
begin  
	--*** Update Sample Order Detail  
	if (	select	count(*)
		from	SAREQDTL
		where	srd_cocde = @qud_cocde	and
			srd_qutno = @qud_qutno	and
			srd_qutseq = @qud_qutseq) > 0  
	begin  
		if (	select	count(*)
			from	SAORDDTL
			where	sad_cocde = @qud_cocde	and
				sad_qutno = @qud_qutno	and
				sad_qutseq = @qud_qutseq	and
				sad_delflg = 'N'		and
				sad_itmno = '') > 0   
		begin  
			--***Sample Product Term - Free Unit  
			select	@yst_chgval = yst_chgval 
			from	SYSMPTRM 
			where	yst_trmcde = '' and --@smpprd	and
				yst_charge = 'Q'  
				

			-- Sample Qty in Sample Order Detail  
			select	@sad_smpqty = sad_smpqty, @sad_cusqty = sad_cusqty 
			from	SAORDDTL 
			where	sad_cocde = @qud_cocde	and
				sad_qutno = @qud_qutno	and
				sad_qutseq = @qud_qutseq	and
				sad_delflg = 'N'		and
				sad_itmno = ''  
     
			--Conversion Factor  
			select	@ycf_value = ycf_value
			from	SYCONFTR
			where	ycf_code1 = @qud_untcde	and
				ycf_code2 = @qud_smpunt  

			if @ycf_value is NULL  
			begin  
				set @ycf_value = 1  
			end  
   
			if @yst_chgval is NULL   
			begin  
				set @yst_chgval = 0  
			end  
   
			if (	select	count(*)
				from	SAORDSUM
				where	sas_cocde = @qud_cocde				and
					sas_cus1no in (	select	cbi_cusno
							from	cubasinf (nolock)
							where	cbi_cusali = @cus1no or
								cbi_cusno = @cus1no
							union
							select	cbi_cusali
							from	cubasinf (nolock)
							where	cbi_cusno = @cus1no )	and  
					sas_itmno in (	select	ibi_itmno
							from	imbasinf
							where	ibi_itmno = @qud_itmno or
								ibi_alsitmno = @qud_itmno
							union
							select	bas.ibi_alsitmno
							from	imbasinf bas
							left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
							where	bas.ibi_itmno = @qud_itmno and
								als.ibi_itmsts <> 'OLD' )	and  
					sas_colcde = @qud_colcde) = 1  
			begin  
				set @sumqty = (	select	isnull(sum(isnull(sas_freqty,0)),0)
						from	SAORDSUM
						where	sas_cocde = @qud_cocde				and   
							sas_cus1no in (	select	cbi_cusno
									from	cubasinf (nolock)
									where	cbi_cusali = @cus1no or
										cbi_cusno = @cus1no   
									union
									select	cbi_cusali
									from	cubasinf (nolock)
									where	cbi_cusno = @cus1no)		and  
							sas_itmno in (	select	ibi_itmno
									from	imbasinf
									where	ibi_itmno = @qud_itmno or
										ibi_alsitmno = @qud_itmno  
									union
									select	bas.ibi_alsitmno
									from	imbasinf bas
									left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
									where	bas.ibi_itmno = @qud_itmno and
									als.ibi_itmsts <> 'OLD' )		and  
							sas_colcde = @qud_colcde)  
			end
			else
			begin
				set @sumqty = (	select	isnull(sum(isnull(sad_freqty,0)),0)
						from	SAORDDTL
						where	sad_cocde = @qud_cocde				and   
							sad_cus1no in (	select	cbi_cusno
									from	cubasinf (nolock)
									where	cbi_cusali = @cus1no or
										cbi_cusno = @cus1no   
									union
									select	cbi_cusali
									from	cubasinf (nolock)
									where	cbi_cusno = @cus1no)		and  
							sad_itmno in (	select	ibi_itmno
									from	imbasinf
									where	ibi_itmno = @qud_itmno or
										ibi_alsitmno = @qud_itmno  
									union
									select	bas.ibi_alsitmno
									from	imbasinf bas
									left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
									where	bas.ibi_itmno = @qud_itmno and
										als.ibi_itmsts <> 'OLD')	and  
							sad_colcde = @qud_colcde				and
							sad_delflg in ('N', 'Q'))  
			end  
   
			if @sumqty < @yst_chgval
			begin  
				set @avail = @yst_chgval - @sumqty   
    				if @sad_smpqty < @avail  
				begin  
					set @freqty = @sad_smpqty  
				end  
				else  
				begin  
					set @freqty = @avail  
				end  
			end  
			else  
			begin  
				set @freqty = 0  
			end  
  
			set @chgqty = @sad_cusqty - @freqty  
   
			if @chgqty <= 0   
			begin  
				set @chgqty = 0   
			end   
  
			if @qud_cocde = 'UCP'  
			begin  
				set @qud_ftyprc = @qud_ftycst        
			end  
  
			update	SAORDDTL 
			set	sad_itmno = @qud_itmno,	sad_itmdsc = @qud_itmdsc,	sad_colcde = @qud_colcde,  
				sad_untcde = @qud_untcde,	sad_inrqty = @qud_inrqty,	sad_mtrqty = @qud_mtrqty,  
				sad_cft = @qud_cft,		sad_freqty = @freqty,		sad_chgqty = @chgqty,  
				sad_smpuntcde = @qud_smpunt,	sad_smpselprc = @qud_smpprc,	sad_smpftyprc = @qud_ftyprc/@ycf_value,
				sad_itmtyp = @qud_itmtyp,	sad_upddat = getdate(),		sad_updusr = @qud_creusr,
				sad_coldsc = @qud_coldsc,	sad_cuscol = @qud_cuscol,	sad_cusitm = @qud_cusitm,
				sad_fcurcde = @qud_fcurcde,	sad_itmventyp = @Itmventyp  
			where	sad_cocde = @qud_cocde	and
				sad_qutno = @qud_qutno	and
				sad_qutseq = @qud_qutseq	and
				sad_delflg = 'N'		and
				sad_cus1no = @cus1no	and
				sad_itmno = ''  

			select	@smpqty_sum = sum(sad_smpqty),	@stkqty_sum = sum(sad_stkqty),	@cusqty_sum = sum(sad_cusqty),
				@chgqty_sum = sum(sad_chgqty),	@freqty_sum = sum(sad_freqty)  
			from	SAORDDTL  
			where	sad_cocde = @qud_cocde						and
				sad_cus1no in (	select	cbi_cusno
						from	cubasinf (nolock)
						where	cbi_cusali = @cus1no or
							cbi_cusno = @cus1no
						union   
						select	cbi_cusali 
						from	cubasinf (nolock)
						where	cbi_cusno = @cus1no)				and 
				sad_itmno in (	select	ibi_itmno
						from	imbasinf
						where	ibi_itmno = @qud_itmno or
							ibi_alsitmno = @qud_itmno  
						union  
						select	bas.ibi_alsitmno 
						from	imbasinf bas
						left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno 
						where	bas.ibi_itmno = @qud_itmno and
							als.ibi_itmsts <> 'OLD')			and  
				sad_colcde = @qud_colcde						and
				sad_delflg in ('N', 'Q')  
   
			if (	select	count(1) 
				from	SAORDSUM   
				where	sas_cocde = @qud_cocde					and   
					sas_cus1no in (	select	cbi_cusno
							from	cubasinf
							where	cbi_cusno = @cus1no	or
								cbi_cusali = @cus1no  
							union
							select	cbi_cusali
							from	cubasinf
							where	cbi_cusno = @cus1no)			and  
					sas_itmno in (	select	ibi_itmno
							from	imbasinf
							where	ibi_itmno = @qud_itmno or
								ibi_alsitmno = @qud_itmno    
							union  
							select	bas.ibi_alsitmno
							from	imbasinf bas
							left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
							where	bas.ibi_itmno = @qud_itmno and
								als.ibi_itmsts <>'OLD')		and  
					sas_colcde = @qud_colcde) = 0  
			begin  
				insert into	[SAORDSUM]  
					(sas_cocde,		sas_cus1no,	sas_cus1na,  
					 sas_itmno,		sas_itmdsc,	sas_colcde,
					 sas_smpqty,	sas_shpqty,	sas_chgqty,
					 sas_freqty,		sas_stkqty,		sas_cusqty,
					 sas_creusr,	sas_updusr,	sas_credat,
					 sas_upddat,	sas_itmtyp,		sas_smpunt,
					 sas_itmventyp)  
				values	(@qud_cocde,	@cus1no,		@cus1na,
					 @qud_itmno,	@qud_itmdsc,	@qud_colcde,
					 @smpqty_sum,	0,		@chgqty_sum,
					 @freqty_sum,	@stkqty_sum,	@cusqty_sum,
					 @qud_creusr,	@qud_creusr,	getdate(),
					 getdate(),		@qud_itmtyp,	(case @qud_smpunt when 'PC' then 'PC' else '' end),  
					 @ItmVenTyp)  
			end  
			else  
			begin  
				update	SAORDSUM   
				set	sas_itmdsc = @qud_itmdsc,	sas_itmno = @qud_itmno,	sas_smpqty = @smpqty_sum,
					sas_chgqty = @chgqty_sum,	sas_freqty = @freqty_sum,	sas_stkqty = @stkqty_sum,
					sas_cusqty = @cusqty_sum,	sas_updusr = @qud_creusr,	sas_upddat = getdate(),
					sas_itmtyp = @qud_itmtyp,	sas_smpunt = (case sas_smpunt
										when '' then ''
										else  
										(case @qud_smpunt
											when 'PC' then 'PC'
											else '' end)  
										end)  
				where	sas_cocde = @qud_cocde					and
					sas_cus1no  in (	select	cbi_cusno
							from	cubasinf
							where	cbi_cusno = @cus1no	or
								cbi_cusali = @cus1no  
							union
							select	cbi_cusali
							from	cubasinf
							where	cbi_cusno = @cus1no)			and    
					sas_itmno in (	select	ibi_itmno
							from	imbasinf
							where	ibi_itmno = @qud_itmno or
								ibi_alsitmno = @qud_itmno    
							union
							select	bas.ibi_alsitmno
							from	imbasinf bas
							left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
							where	bas.ibi_itmno = @qud_itmno and
								als.ibi_itmsts <> 'OLD')		and  
					sas_colcde = @qud_colcde  
			end  
		end  
		else  -- i.e. NOT(SAORDDTL>0)
		begin  
			if @qud_cocde = 'UCP'  
			begin  
				set @qud_ftyprc = @qud_ftycst  
			end  

			--Conversion Factor  
			select	@ycf_value = ycf_value
			from	SYCONFTR
			where	ycf_code1 = @qud_untcde	and
				ycf_code2 = @qud_smpunt  

			update	SAORDDTL
			set	sad_smpselprc = @qud_smpprc,	sad_smpftyprc = @qud_ftyprc/@ycf_value,	sad_upddat = getdate(),
				sad_updusr = @qud_creusr,	sad_coldsc = @qud_coldsc,		sad_cuscol = @qud_cuscol,
				sad_cusitm = @qud_cusitm,	sad_fcurcde = @qud_fcurcde,		sad_untcde = @qud_untcde,
				sad_inrqty = @qud_inrqty,	sad_mtrqty = @qud_mtrqty,		sad_itmventyp = @Itmventyp
			where	sad_cocde = @qud_cocde	and
				sad_qutno = @qud_qutno	and
				sad_qutseq = @qud_qutseq	and
				sad_delflg = 'N'		and
				sad_cus1no = @cus1no	and
				sad_itmno = @qud_itmno  
		end  
	end  

	if	@qud_onetim = 'N'	and
		@quh_qutsts = 'A'	and
		@qud_tbm = 'N'  
	begin  
		if @cus2no <> ''   
		begin  
			if (	select	count(1)
				from	CUITMSUM
				where	cis_cusno in (	select	cbi_cusno
							from	cubasinf
							where	cbi_cusno = @cus1no	or
								cbi_cusali = @cus1no  
							union
							select	cbi_cusali
							from	cubasinf
							where	cbi_cusno = @cus1no)				and      
					cis_seccus in (	select	cbi_cusno
							from	cubasinf (nolock)
							where	(cbi_cusali = @cus2no	or
								 cbi_cusno = @cus2no) and
								cbi_cusno <> ''  
							union
							select	cbi_cusali
							from	cubasinf (nolock)
							where	cbi_cusno = @cus2no and
								cbi_cusali  <> '')				and      
					cis_itmno in (	select	ibi_itmno
							from	imbasinf
							where	ibi_itmno = @qud_itmno or
								ibi_alsitmno = @qud_itmno  
							union
							select	bas.ibi_alsitmno
							from	imbasinf bas
							left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
							where	bas.ibi_itmno = @qud_itmno and
								als.ibi_itmsts <>'OLD')			and
					cis_colcde = @qud_colcde						and
					cis_untcde = @qud_untcde						and
					cis_inrqty = @qud_inrqty						and
					cis_conftr = @qud_conftr						and
					cis_mtrqty = @qud_mtrqty) = 0  
			begin  
				insert into	[CUITMSUM]  
					(cis_cocde,		cis_cusno,		cis_itmno,
					 cis_itmdsc,	cis_cusitm,		cis_colcde,
					 cis_coldsc,		cis_cuscol,		cis_untcde,
					 cis_inrqty,		cis_mtrqty,		cis_cft,
					 cis_cbm,		cis_refdoc,		cis_docdat,
					 cis_cussku,	cis_ordqty,		cis_curcde,
					 cis_selprc,		cis_hrmcde,	cis_dtyrat,
					 cis_dept,		cis_typcode,	cis_code1,
					 cis_code2,		cis_code3,		cis_cususd,
					 cis_cuscad,	cis_inrdin,		cis_inrwin,
					 cis_inrhin,		cis_mtrdin,		cis_mtrwin,
					 cis_mtrhin,	cis_inrdcm,	cis_inrwcm,
					 cis_inrhcm,	cis_mtrdcm,	cis_mtrwcm,
					 cis_mtrhcm,	cis_creusr,		cis_updusr,
					 cis_credat,		cis_upddat,		cis_pckitr,
					 cis_seccus,	cis_secsna,		cis_fcurcde,
					 cis_ftyprc,		cis_ftycst,		cis_netselprc,
					 cis_moqchg,	cis_itmventyp,	cis_moq,
					 cis_moa,		cis_moacur,	cis_conftr,
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
						else 0 end,	@qud_curcde,	@qud_conftr,
					 @qud_contopc,	@qud_pcprc,	isnull(@qud_ftytmpitmno,''),
					 isnull(@qud_cusstyno,''),@qud_moqunttyp,	@qud_qutdat,
					 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
					 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
					 @qud_expdat)  
			end  
			else    
			begin   
			update	CUITMSUM    
			set	cis_itmdsc = @qud_itmdsc,	cis_itmno = @qud_itmno,	cis_cusitm = @qud_cusitm,  
				cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
				cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,  
				cis_selprc = @qud_cus1dp,	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,
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
				cis_ftytmpitm = isnull(@qud_ftytmpitmno,''),	cis_cusstyno = isnull(@qud_cusstyno,''),	cis_moqunttyp = @qud_moqunttyp,
				cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
				cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
				cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
			where	cis_cusno in (	select	cbi_cusno
						from	cubasinf
						where	cbi_cusno = @cus1no or
							cbi_cusali = @cus1no  
						union
						select	cbi_cusali
						from	cubasinf
						where	cbi_cusno = @cus1no)			and
				cis_seccus in (	select	cbi_cusno
						from	cubasinf (nolock)
						where	(cbi_cusali = @cus2no or
							 cbi_cusno = @cus2no) and
							cbi_cusno <> ''  
						union
						select	cbi_cusali
						from	cubasinf (nolock)
						where	cbi_cusno = @cus2no and
							cbi_cusali  <> '')			and
				cis_itmno in (	select	ibi_itmno
						from	imbasinf
						where	ibi_itmno = @qud_itmno or
							ibi_alsitmno = @qud_itmno  
						union  
						select	bas.ibi_alsitmno
						from	imbasinf bas
						left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
						where	bas.ibi_itmno = @qud_itmno and
							als.ibi_itmsts <> 'OLD')		and
				cis_colcde = @qud_colcde					and
				cis_untcde = @qud_untcde					and
				cis_inrqty = @qud_inrqty					and
				cis_mtrqty = @qud_mtrqty					and
				cis_conftr = @qud_conftr
			end  
		end     
		else  
		begin  
			if (	select	count(1)
				from	CUITMSUM   
				where	cis_cusno in (	select	cbi_cusno
							from	cubasinf
							where	cbi_cusno = @cus1no or
								cbi_cusali = @cus1no  
							union  
							select	cbi_cusali
							from	cubasinf
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
								als.ibi_itmsts <> 'OLD')	and
					cis_colcde = @qud_colcde				and
					cis_untcde = @qud_untcde				and
					cis_inrqty = @qud_inrqty				and
					cis_conftr = @qud_conftr				and
					cis_mtrqty = @qud_mtrqty) = 0  
			begin  
				insert into	[CUITMSUM]
					(cis_cocde,		cis_cusno,		cis_itmno,
					 cis_itmdsc,	cis_cusitm,		cis_colcde,
					 cis_coldsc,		cis_cuscol,		cis_untcde,
					 cis_inrqty,		cis_mtrqty,		cis_cft,
					 cis_cbm,		cis_refdoc,		cis_docdat,
					 cis_cussku,	cis_ordqty,		cis_curcde,
					 cis_selprc,		cis_hrmcde,	cis_dtyrat,
					 cis_dept,		cis_typcode,	cis_code1,
					 cis_code2,		cis_code3,		cis_cususd,
					 cis_cuscad,	cis_inrdin,		cis_inrwin,
					 cis_inrhin,		cis_mtrdin,		cis_mtrwin,
					 cis_mtrhin,	cis_inrdcm,	cis_inrwcm,
					 cis_inrhcm,	cis_mtrdcm,	cis_mtrwcm,
					 cis_mtrhcm,	cis_creusr,		cis_updusr,
					 cis_credat,		cis_upddat,		cis_pckitr,
					 cis_seccus,	cis_secsna,		cis_fcurcde,
					 cis_ftyprc,		cis_ftycst,		cis_netselprc,
					 cis_moqchg,	cis_itmventyp,	cis_moq,
					 cis_moa,		cis_moacur,	cis_conftr,
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
						else 0 end,	@qud_curcde,	@qud_conftr,
					 @qud_contopc,	@qud_pcprc,	isnull(@qud_ftytmpitmno,''),
					 isnull(@qud_cusstyno,''), @qud_moqunttyp,	@qud_qutdat,
					 @qud_cus1no,	@qud_cus2no,	@qud_prctrm,
					 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
					 @qud_expdat)  
			end  
			else    
			begin   
			update	CUITMSUM    
			set	cis_itmdsc = @qud_itmdsc,	cis_itmno = @qud_itmno,	cis_cusitm = @qud_cusitm,  
				cis_coldsc = @qud_coldsc,	cis_cuscol = @qud_cuscol,	cis_cft = @qud_cft,
				cis_cbm = @qud_cft/35.3356,	cis_refdoc = @qud_qutno,	cis_curcde = @qud_curcde,  
				cis_selprc = @qud_cus1dp,	cis_hrmcde = @qud_hrmcde,	cis_dtyrat = @qud_dtyrat,
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
				cis_ftytmpitm = isnull(@qud_ftytmpitmno ,''), cis_cusstyno = isnull(@qud_cusstyno,''), cis_moqunttyp = @qud_moqunttyp,
				cis_qutdat = @qud_qutdat,	cis_cus1no = @qud_cus1no,	cis_cus2no = @qud_cus2no,
				cis_hkprctrm = @qud_prctrm,	cis_ftyprctrm = @qud_ftyprctrm,	cis_trantrm = @qud_trantrm,
				cis_effdat = @qud_effdat,	cis_expdat = @qud_expdat
			where	cis_cusno in (	select	cbi_cusno
						from	cubasinf
						where	cbi_cusno = @cus1no or
							cbi_cusali = @cus1no  
						union  
						select	cbi_cusali
						from	cubasinf
						where	cbi_cusno = @cus1no)			and     
				cis_seccus = @cus2no						and
				cis_itmno in (	select	ibi_itmno
						from	imbasinf
						where	ibi_itmno = @qud_itmno or
							ibi_alsitmno = @qud_itmno  
						union  
						select	bas.ibi_alsitmno
						from	imbasinf bas
						left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno
						where	bas.ibi_itmno = @qud_itmno and
							als.ibi_itmsts <> 'OLD')		and
				cis_colcde = @qud_colcde					and
				cis_untcde = @qud_untcde					and
				cis_inrqty = @qud_inrqty					and
				cis_mtrqty = @qud_mtrqty					and
				cis_conftr = @qud_conftr
			end  
		end  
	end  
end  

 --Insert into Customer Item History Detail Information  
if @quh_qutsts = 'A' and @qud_tbm = 'N'  
begin   
	set	@cid_seqno = (	select	isnull(max(cid_seqno),0) + 1
				from	CUITMDTL   
				where	cid_cocde = @qud_cocde	and
					cid_cusno = @cus1no		and  
					cid_seccus = @cus2no		and
					cid_itmno = @qud_itmno	and   
					cid_colcde = @qud_colcde	and
					cid_inrqty = @qud_inrqty	and   
					cid_untcde = @qud_untcde	and
					cid_conftr = @qud_conftr)  
    
	insert into	[CUITMDTL]  
		(cid_cocde,		cid_cusno,		cid_seqno,  
		 cid_itmno,		cid_itmdsc,		cid_cusitm,  
		 cid_colcde,	cid_coldsc,		cid_cuscol,  
		 cid_untcde,	cid_inrqty,		cid_mtrqty,  
		 cid_cft,		cid_cbm,		cid_refdoc,
		 cid_docdat,	cid_cussku,	cid_ordqty,
		 cid_curcde,	cid_selprc,		cid_hrmcde,
		 cid_dtyrat,		cid_dept,		cid_typcode,
		 cid_code1,		cid_code2,		cid_code3,  
		 cid_cususd,	cid_cuscad,		cid_inrdin,
		 cid_inrwin,	cid_inrhin,		cid_mtrdin,
		 cid_mtrwin,	cid_mtrhin,		cid_inrdcm,
		 cid_inrwcm,	cid_inrhcm,	cid_mtrdcm,
		 cid_mtrwcm,	cid_mtrhcm,	cid_onetim,
		 cid_creusr,		cid_updusr,	cid_credat,   
		 cid_upddat,	cid_pckitr,		cid_seccus,  
		 cid_secsna,	cid_fcurcde,	cid_ftyprc,  
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
		 @qud_pcprc,	isnull(@qud_ftytmpitmno,''), isnull(@qud_cusstyno,''),
		 @qud_moqunttyp,	@qud_qutdat,	@qud_cus1no,
		 @qud_cus2no,	@qud_prctrm,	@qud_ftyprctrm,
		 @qud_trantrm,	@qud_effdat,	@qud_expdat)  
end


*/















GO
GRANT EXECUTE ON [dbo].[sp_update_QUOTNDTL_qutsts] TO [ERPUSER] AS [dbo]
GO
