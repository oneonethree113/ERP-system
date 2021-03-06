/****** Object:  StoredProcedure [dbo].[sp_insert_SAREQDTL2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_SAREQDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_SAREQDTL2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[sp_insert_SAREQDTL2] 

@srd_cocde	nvarchar(6),	@srd_reqno	nvarchar(20),	@srd_itmno	nvarchar(20),
@srd_itmnotyp varchar(1) ,	@srd_itmnoreal nvarchar(20) ,	@srd_itmnotmp nvarchar(20),
@srd_itmnoven nvarchar(20) ,	@srd_itmnovenno nvarchar(6)	,@srd_pkgtrm	nvarchar(100) ,	@srd_samstage nvarchar(20), 	
@srd_itmsts	nvarchar(4),	@srd_alsitmno	nvarchar(20),	@srd_alscolcde	nvarchar(30),
@srd_venitm	nvarchar(20),	@srd_engdsc	nvarchar(800),	@srd_chndsc	nvarchar(1600),
@srd_colcde	nvarchar(30),	@srd_cuscol	nvarchar(30),	@srd_coldsc	nvarchar(300),	
@srd_pckseq	int,		@srd_untcde	nvarchar(6),	@srd_inrqty	int,		
@srd_mtrqty	int,		@srd_cft 		numeric(11,4),	@srd_smpqty	int,		
@srd_stkqty	int,		@srd_cusqty	int,		@qud_fcurcde	nvarchar(6),	
@srd_ftyprc	numeric(13,4),	@srd_ftycst 	numeric(13,4),	@srd_smpunt	nvarchar(6),
@srd_note		nvarchar(300),	@srd_tbm		nvarchar(1),	@sas_qutno	nvarchar(20),
@sas_qutseq	int,		@srd_vencol	nvarchar(30),	@srd_cus1no	nvarchar(6),	
@srd_cus2no	nvarchar(6),	@sas_cus1na	nvarchar(20),	@sas_cus2na	nvarchar(20),	
@sas_smpselprc	numeric(13,4),	@qud_ftyprc	numeric(13,4),	@ycf_value	int,		
@qutitmsts		nvarchar(10),	@qud_curcde	nvarchar(6),	@yst_charge	nvarchar(1),
@yst_chgval	int,		@srd_itmtyp	nvarchar(4),	@srd_cusitm	nvarchar(20),
@qud_venno	nvarchar(6),	@qud_subcde	nvarchar(10),	@qud_cusven	nvarchar(6),	
@qud_cussub	nvarchar(10),	@qud_cus1no	nvarchar(6),	@qud_cus2no	nvarchar(6),
@qud_hkprctrm	nvarchar(10),	@qud_ftyprctrm	nvarchar(10),	@qud_trantrm	nvarchar(10),
@qud_effdat	datetime,		@qud_expdat	datetime,		@srd_creusr	nvarchar(30)

AS

declare 	@reqseq	int,	@seqno 	int,	@selrat 	numeric(12,4),	@def	nvarchar(6),
	@sumqty	int,	@freqty	int,	@chgqty	int,		@avail	int

declare @itmventyp char(1)

set @freqty = 0 
set @chgqty = 0

if @ycf_value is null or @ycf_value = 0 
begin
	set @ycf_value = 1
end

if @yst_chgval is null
begin
 	set @yst_chgval = 0 
end

set @reqseq = (	select	isnull(max(srd_reqseq),0) + 1
		from	SAREQDTL
		where	srd_cocde = @srd_cocde	and
			srd_reqno = @srd_reqno)

insert into [SAREQDTL]
(srd_cocde ,	srd_reqno ,	srd_reqseq ,
 srd_itmno ,	srd_itmsts ,	srd_alsitmno,	
 srd_alscolcde,	srd_venitm ,	srd_engdsc ,	
 srd_chndsc ,	srd_vencol ,	srd_cuscol ,	
 srd_coldsc ,	srd_pckseq ,	srd_untcde ,	
 srd_inrqty ,	srd_mtrqty ,	srd_cft ,		
 srd_stkqty ,	srd_smpunt ,	srd_cusqty ,	
 srd_smpqty ,	srd_curcde ,	srd_ftyprc ,
 srd_ftycst,		srd_smpftyprc ,	srd_note ,		
 srd_tbm ,		srd_canflg ,	srd_qutno,		
 srd_qutseq,	srd_creusr ,	srd_updusr ,	
 srd_credat ,	srd_upddat ,	srd_itmtyp ,	
 srd_qutitmsts ,	srd_cusitm ,	srd_colcde, 
 srd_prdven ,	srd_prdsub,	srd_cus1no,
 srd_cus2no,	srd_hkprctrm,	srd_ftyprctrm,
 srd_trantrm,	srd_effdat,		srd_expdat,
srd_itmnotyp,	srd_itmnoreal,	srd_itmnotmp,
srd_itmnoven, 	srd_itmnovenno, srd_pkgtrm,
 srd_samstage)
values
(@srd_cocde,	@srd_reqno,	@reqseq,
 @srd_itmno, 	@srd_itmsts,	@srd_alsitmno,	
 @srd_alscolcde,	@srd_venitm,	@srd_engdsc,	
 @srd_chndsc, 	@srd_vencol,	@srd_cuscol,	
 @srd_coldsc,	@srd_pckseq,	@srd_untcde,	
 @srd_inrqty,	@srd_mtrqty,	@srd_cft,		
 @srd_stkqty,	@srd_smpunt,	@srd_cusqty,	
 @srd_smpqty,	@qud_fcurcde,	@srd_ftyprc,	
 @srd_ftycst,	
			 @srd_ftyprc/@ycf_value
			 ,	
				@srd_note,
 @srd_tbm,	'N',		@sas_qutno,	
 @sas_qutseq,	@srd_creusr,	@srd_creusr,	
 getdate(),		getdate(),		@srd_itmtyp ,	
 @qutitmsts,	@srd_cusitm,	@srd_colcde, 
 @qud_venno,	@qud_subcde,	@qud_cus1no,
 @qud_cus2no,	@qud_hkprctrm,	@qud_ftyprctrm,
 @qud_trantrm,	@qud_effdat,	@qud_expdat,
@srd_itmnotyp,	@srd_itmnoreal,@srd_itmnotmp,
@srd_itmnoven, @srd_itmnovenno, @srd_pkgtrm,
@srd_samstage)

select @reqseq -- Cannot delete this coding

--if @srd_cocde = 'UCP'
--begin
--	set @qud_ftyprc = @srd_ftycst
--end

-- Complete and not TBM Item (Insert to Sampler Order Summary and Detail)
--@srd_tbm = 'N' and Comment at 7-31-2013 BN
if  @qutitmsts ='A' or @qutitmsts ='W' or @qutitmsts = 'COMPLETE'
begin
	if ( select count(*) from SAORDSUM where sas_cocde = @srd_cocde and 
			sas_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srd_cus1no or cbi_cusno = @srd_cus1no 
			               UNION 
			               SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srd_cus1no ) AND
			((@srd_itmno = '' and sas_itmno ='') or (@srd_itmno<>'' and sas_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @srd_itmno or ibi_alsitmno = @srd_itmno 
				      union
			              select bas.ibi_alsitmno from imbasinf bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @srd_itmno and als.ibi_itmsts<>'OLD' and bas.ibi_alsitmno <>'' ))) and
			 sas_itmnotmp = @srd_itmnotmp and sas_itmnoven = @srd_itmnoven and  sas_itmnovenno = @srd_itmnovenno
		and 	sas_colcde = @srd_colcde ) = 1
	begin
		set @sumqty = (select isnull(sum(isnull(sas_freqty,0)),0) from SAORDSUM where sas_cocde = @srd_cocde and 
			sas_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srd_cus1no or cbi_cusno = @srd_cus1no 
			               UNION 
			               SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srd_cus1no ) AND
			((@srd_itmno = '' and sas_itmno ='') or (@srd_itmno<>'' and sas_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @srd_itmno or ibi_alsitmno = @srd_itmno 
				      union
			              select bas.ibi_alsitmno from imbasinf bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @srd_itmno and als.ibi_itmsts<>'OLD' and bas.ibi_alsitmno <>'' ))) and
			 sas_itmnotmp = @srd_itmnotmp and sas_itmnoven = @srd_itmnoven and  sas_itmnovenno = @srd_itmnovenno
		and 	sas_colcde = @srd_colcde)
	end
	else
	begin
		set @sumqty = (select isnull(sum(isnull(sad_freqty,0)),0) from SAORDDTL where sad_cocde = @srd_cocde and 
			sad_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srd_cus1no or cbi_cusno = @srd_cus1no 
			               UNION 
			               SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srd_cus1no ) AND
			((@srd_itmno = '' and sad_itmno ='') or (@srd_itmno<>'' and sad_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @srd_itmno or ibi_alsitmno = @srd_itmno 
				      union
			              select bas.ibi_alsitmno from imbasinf bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @srd_itmno and als.ibi_itmsts<>'OLD' and bas.ibi_alsitmno <>'' ))) and
			 sad_itmnotmp = @srd_itmnotmp and sad_itmnoven = @srd_itmnoven and  sad_itmnovenno = @srd_itmnovenno
		and 	sad_colcde = @srd_colcde and sad_delflg in ('N', 'Q') )
	end

	if @sumqty < @yst_chgval
	begin
		set @avail = @yst_chgval - @sumqty	

		if @srd_smpqty < @avail

		begin
			set @freqty = @srd_smpqty
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

	set @chgqty = @srd_cusqty - @freqty

	if @chgqty <= 0 
	begin
		set @chgqty = 0 
	end	

	Set  @seqno = (Select isnull(max(sad_seqno),0)  + 1 from SAORDDTL where sad_cocde = @srd_cocde and sad_cus1no = @srd_cus1no)

	set @itmventyp = (select isnull(vbi_ventyp, '') from VNBASINF (nolock) where vbi_venno = @qud_venno)

	insert into [SAORDDTL]
	(sad_cocde ,	sad_qutno ,	sad_qutseq ,
	 sad_seqno ,	sad_delflg,	sad_cus1no ,	
	 sad_cus1na ,	sad_cus2no ,	sad_cus2na ,	
	 sad_orgitm,	sad_itmno ,	sad_itmnotmp ,
	sad_itmnoven ,  sad_itmnovenno , sad_itmdsc ,	
	 sad_colcde ,	sad_alsitmno,	sad_alscolcde,
	 sad_untcde ,	sad_inrqty ,	sad_mtrqty ,	
	 sad_cft ,		sad_curcde ,	sad_smpuntcde ,	
	 sad_smpselprc ,	sad_smpftyprc ,	sad_smpqty ,	
	 sad_shpqty ,	sad_chgqty ,	sad_freqty ,	
	 sad_stkqty ,	sad_cusqty ,	sad_reqno ,
	 sad_reqseq,	sad_creusr ,	sad_updusr ,	
	 sad_credat ,	sad_upddat ,	sad_itmtyp ,	
	 sad_fcurcde ,	sad_cuscol,		sad_coldsc,	
	 sad_venno,	sad_subcde,	sad_cusven, 	
	 sad_cussub, 	sad_cusitm, 	sad_itmventyp,
	 sad_imu_cus1no,	sad_imu_cus2no,	sad_imu_hkprctrm,
	 sad_imu_ftyprctrm,	sad_imu_trantrm,	sad_imu_effdat,
	 sad_imu_expdat)
	values
	(@srd_cocde,	@sas_qutno,	@sas_qutseq,
	 @seqno,		'N',		@srd_cus1no,	
	 @sas_cus1na,	@srd_cus2no,	@sas_cus2na,	
	 @srd_itmno,	@srd_itmno,	@srd_itmnotmp,
	@srd_itmnoven,	@srd_itmnovenno,@srd_engdsc,	
	 @srd_colcde,	@srd_alsitmno,	@srd_alscolcde,
	 @srd_untcde,	@srd_inrqty,	@srd_mtrqty,	
	 @srd_cft,		@qud_curcde,	@srd_smpunt,	
	 @sas_smpselprc,	@qud_ftyprc/@ycf_value,
					@srd_smpqty,	
	 0,		@chgqty,		@freqty,		
	 @srd_stkqty,	@srd_cusqty,	@srd_reqno,	
	 @reqseq,		@srd_creusr,	@srd_creusr,	
	 getdate(),		getdate(),		@srd_itmtyp,	
	 @qud_fcurcde,	@srd_cuscol,	@srd_coldsc,	
	 @qud_venno,	@qud_subcde,	@qud_cusven,	
	 @qud_cussub,	@srd_cusitm, 	@itmventyp,
	 @qud_cus1no,	@qud_cus2no,	@qud_hkprctrm,
	 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
	 @qud_expdat)
	
	if (	select 
			count(1) 
		from 
			SAORDSUM 
		where 	
			sas_cocde = @srd_cocde and 
			sas_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srd_cus1no or cbi_cusno = @srd_cus1no 
			               UNION 
			               SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srd_cus1no ) AND
			((@srd_itmno = '' and sas_itmno ='') or (@srd_itmno<>'' and sas_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @srd_itmno or ibi_alsitmno = @srd_itmno 
				      union
			              select bas.ibi_alsitmno from imbasinf bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @srd_itmno and als.ibi_itmsts<>'OLD' and bas.ibi_alsitmno <>'' ))) and
			 sas_itmnotmp = @srd_itmnotmp and sas_itmnoven = @srd_itmnoven and  sas_itmnovenno = @srd_itmnovenno
		and 	sas_colcde = @srd_colcde
	) = 0
			
	begin
		insert into [SAORDSUM]
		(sas_cocde ,	sas_cus1no ,	sas_cus1na ,
		 sas_itmno ,	sas_itmnotmp , sas_itmnoven ,
		sas_itmnovenno ,sas_itmdsc ,	sas_colcde ,	
		 sas_alsitmno,	sas_alscolcde,	sas_smpqty ,	
		 sas_shpqty ,	sas_chgqty ,	sas_freqty ,
		 sas_stkqty ,	sas_cusqty ,	sas_creusr ,	
		 sas_updusr ,	sas_credat ,		sas_upddat ,	
		 sas_itmtyp ,	sas_smpunt,	sas_imu_cus1no,
		 sas_imu_cus2no,	sas_imu_hkprctrm,	sas_imu_ftyprctrm,
		 sas_imu_trantrm,	sas_imu_effdat,	sas_imu_expdat)
		values
		(@srd_cocde,	@srd_cus1no,	@sas_cus1na,
		 @srd_itmno,	@srd_itmnotmp ,  @srd_itmnoven  ,
		@srd_itmnovenno , @srd_engdsc, @srd_colcde,
		 @srd_alsitmno,	@srd_alscolcde,	@srd_smpqty,	
		 0,		@chgqty,		@freqty,		
		 @srd_stkqty,	@srd_cusqty,	@srd_creusr,	
		 @srd_creusr,	getdate(),		getdate(),		
		 @srd_itmtyp,	(case @srd_smpunt
					when 'PC' then 'PC'
					else '' end),	@qud_cus1no,
		 @qud_cus2no,	@qud_hkprctrm,	@qud_ftyprctrm,
		 @qud_trantrm,	@qud_effdat,	@qud_expdat)
	end
	else
	begin
		update 	SAORDSUM 	
		set 	
			sas_itmdsc = @srd_engdsc, 
			sas_itmno = @srd_itmno, 
			sas_itmnotmp = @srd_itmnotmp,
			sas_itmnoven = @srd_itmnoven,
			sas_itmnovenno = @srd_itmnovenno,
			sas_alsitmno = @srd_alsitmno,	
			sas_alscolcde=@srd_alscolcde,
			sas_itmtyp = @srd_itmtyp,
			sas_smpqty = sas_smpqty  + @srd_smpqty, 	
			sas_chgqty = sas_chgqty + @chgqty,
			sas_freqty = sas_freqty + @freqty,	
			sas_stkqty = sas_stkqty + @srd_stkqty,					
			sas_cusqty = sas_cusqty + @srd_cusqty, 	
			sas_updusr = @srd_creusr, 
			sas_upddat = getdate(), 	
			sas_smpunt = (case sas_smpunt
					when '' then ''
					else (case @srd_smpunt
						when 'PC' then 'PC'
						else '' end)
					end),
			sas_imu_cus1no = @qud_cus1no,
			sas_imu_cus2no = @qud_cus2no,
			sas_imu_hkprctrm = @qud_hkprctrm,
			sas_imu_ftyprctrm = @qud_ftyprctrm,
			sas_imu_trantrm = @qud_trantrm,
			sas_imu_effdat = @qud_effdat,
			sas_imu_expdat = @qud_expdat
		where	
			sas_cocde = @srd_cocde and 
			sas_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srd_cus1no or cbi_cusno = @srd_cus1no 
			               UNION 
			               SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srd_cus1no ) AND
			((@srd_itmno = '' and sas_itmno ='') or (@srd_itmno<>'' and sas_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @srd_itmno or ibi_alsitmno = @srd_itmno 
				      union
			              select bas.ibi_alsitmno from imbasinf bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @srd_itmno and als.ibi_itmsts<>'OLD' and bas.ibi_alsitmno <>'' ))) and
			 sas_itmnotmp = @srd_itmnotmp and sas_itmnoven = @srd_itmnoven and  sas_itmnovenno = @srd_itmnovenno
		and 	sas_colcde = @srd_colcde
	end
end
--else	-- Incomplete or TBM Item
--begin
	/*Set  @seqno = (Select isnull(max(sad_seqno),0)  + 1 from SAORDDTL where sad_cocde = @srd_cocde and sad_cus1no = @srd_cus1no)

	set @itmventyp = (select isnull(vbi_ventyp, '') from VNBASINF (nolock) where vbi_venno = @qud_venno)

	insert into [SAORDDTL]
	(sad_cocde ,	sad_qutno ,		sad_qutseq ,
	 sad_seqno ,	sad_delflg,		sad_cus1no ,	
	 sad_cus1na ,	sad_cus2no ,	sad_cus2na ,	
	 sad_orgitm,	sad_itmno ,	sad_itmnotmp ,
	sad_itmnoven ,   sad_itmnovenno ,sad_itmdsc ,	
	 sad_colcde ,	sad_alsitmno,	sad_alscolcde,
	 sad_untcde ,	sad_inrqty ,	sad_mtrqty ,	
	 sad_cft ,		sad_curcde ,	sad_smpuntcde ,	
	 sad_smpselprc ,	sad_smpftyprc ,	sad_smpqty ,	
	 sad_shpqty ,	sad_chgqty ,	sad_freqty ,	
	 sad_stkqty ,	sad_cusqty ,	sad_reqno ,
	 sad_reqseq ,	sad_creusr ,	sad_updusr ,	
	 sad_credat ,	sad_upddat ,	sad_itmtyp ,	
	 sad_fcurcde ,	sad_cuscol,		sad_coldsc,
	 sad_venno,	sad_subcde,	sad_cusven,	
	 sad_cussub,	sad_cusitm, 	sad_itmventyp,
	 sad_imu_cus1no,	sad_imu_cus2no,	sad_imu_hkprctrm,
	 sad_imu_ftyprctrm,	sad_imu_trantrm,	sad_imu_effdat,
	 sad_imu_expdat)
	values
	(@srd_cocde,	@sas_qutno,	@sas_qutseq,
	 @seqno,		'N',		@srd_cus1no,	
	 @sas_cus1na,	@srd_cus2no,	@sas_cus2na,	
	 @srd_itmno,   @srd_itmnotmp , @srd_itmnoven,
	@srd_itmnovenno,'',		@srd_engdsc,	
	 @srd_colcde,	@srd_alsitmno,	@srd_alscolcde,
	 @srd_untcde,	@srd_inrqty,	@srd_mtrqty,	
	 @srd_cft,		@qud_curcde,	@srd_smpunt,	
	 @sas_smpselprc,	@qud_ftyprc/@ycf_value,
					@srd_smpqty,	
	 0,		@srd_smpqty,	0,		
	 @srd_stkqty,	@srd_cusqty,	@srd_reqno,	
	 @reqseq,		@srd_creusr,	@srd_creusr,	
	 getdate(),		getdate(),		@srd_itmtyp,	
	 @qud_fcurcde,	@srd_cuscol,	@srd_coldsc,	
	 @qud_venno,	@qud_subcde,	@qud_cusven,	
	 @qud_cussub,	@srd_cusitm, 	@itmventyp,
	 @qud_cus1no,	@qud_cus2no,	@qud_hkprctrm,
	 @qud_ftyprctrm,	@qud_trantrm,	@qud_effdat,
	 @qud_expdat)*/
--end

GO
GRANT EXECUTE ON [dbo].[sp_insert_SAREQDTL2] TO [ERPUSER] AS [dbo]
GO
