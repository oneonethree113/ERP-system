/****** Object:  StoredProcedure [dbo].[sp_list_SAORDDTL2]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_SAORDDTL2]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_SAORDDTL2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE   procedure [dbo].[sp_list_SAORDDTL2]
                                                                                                                                                                                                                                                               
@sad_cocde	nvarchar(6) ,
@sad_cus1no	nvarchar(20),
@sad_itmno	nvarchar(20),
@sad_itmnotmp nvarchar(20),
@sad_itmnoven  nvarchar(20),
@sad_itmnovenno nvarchar(20),
@sad_colcde	nvarchar(30)
 
AS

begin
	select	'   '  as 'DEL',	sad_cocde,		sad_qutno,
		sad_qutseq,	sad_seqno,		sad_cus1no,
		sad_cus1na,	sad_cus2no,	sad_cus2na,
		sad_orgitm,	sad_itmno,		sad_itmdsc,
		sad_colcde,		sad_untcde,	sad_inrqty,
		sad_mtrqty,	sad_cft,		sad_curcde,
		sad_smpuntcde,	sad_smpselprc,	sad_smpftyprc,
		sad_smpqty,	sad_shpqty,	sad_chgqty,
		sad_freqty,		sad_stkqty,		sad_cusqty,
		sad_reqno,		sad_reqseq,	sad_delflg,
		sad_creusr,		sad_updusr,	sad_credat,
		sad_upddat,	sad_timstp,		sad_itmtyp,
		sad_smpselprc as 'qud_smpprc',
				sad_cuscol as 'qud_cuscol',
						sad_coldsc  as 'qud_coldsc',
		sad_venno  as 'qud_venno',
				sad_subcde  'qud_subcde',
						sad_cusven  as 'qud_cusven',
		sad_cussub  'qud_cussub',
				sad_fcurcde  as 'qud_fcurcde',
						sad_smpftyprc  as 'qud_ftyprc',
		isnull(	cast(sad_untcde as nvarchar(6)) + ' / ' + 
			cast(sad_inrqty as nvarchar(10)) + ' / ' + 
			cast(sad_mtrqty as nvarchar(10)) + ' / ' + 
			cast(sad_cft as nvarchar(10)) + ' / ' + 
			sad_imu_hkprctrm + ' / ' +
			sad_imu_ftyprctrm + ' / ' +
			sad_imu_trantrm + ' / ' +
			cast(sad_qutno as nvarchar(20)) 
			,'')  as 'sad_pck',
				max(sad_credat) as 'max_sad_credat',
						sad_cusitm,
		--vbi_ventyp,	
		sad_imu_cus1no,	sad_imu_cus2no,
		sad_imu_hkprctrm,	sad_imu_ftyprctrm,	sad_imu_trantrm,
		sad_imu_effdat,	sad_imu_expdat
	from	SAORDDTL (nolock)
	left join	QUOTNDTL (nolock) on	qud_cocde = sad_cocde	and
					qud_qutno = sad_qutno	and
					qud_qutseq = sad_qutseq
	left join	SYCONFTR (nolock) on	qud_untcde = ycf_code1	and
					ycf_code2 = 'PC'
	--left join	IMBASINF (nolock) on	ibi_itmno = sad_itmno		or
		--			ibi_alsitmno = sad_itmno
	--left join	VNBASINF (nolock) on	vbi_venno = ibi_venno
	where	sad_cocde  = @sad_cocde					and 
		sad_cus1no in (	select	cbi_cusno
				from	cubasinf (nolock)
				where	cbi_cusno = @sad_cus1no	or
					cbi_cusali =  @sad_cus1no)		and
		sad_itmno = @sad_itmno					and
 		sad_itmnotmp = @sad_itmnotmp and
		sad_itmnoven = @sad_itmnoven and
--		sad_itmnovenno = @sad_itmnovenno and 
		ltrim(rtrim(sad_colcde)) = ltrim(rtrim(@sad_colcde))			and
		sad_delflg = 'N'
	group by	sad_cocde,		sad_qutno,		sad_qutseq,
		sad_seqno,		sad_cus1no,	sad_cus1na,
		sad_cus2no,	sad_cus2na,	sad_orgitm,
		sad_itmno,		sad_itmdsc,	sad_colcde,
		sad_untcde,	sad_inrqty,		sad_mtrqty,
		sad_cft,		sad_curcde,	sad_smpuntcde,
		sad_smpselprc,	sad_smpftyprc,	sad_smpqty,
		sad_shpqty,	sad_chgqty,	sad_freqty,
		sad_stkqty,		sad_cusqty,	sad_reqno,
		sad_reqseq,	sad_delflg,		sad_creusr,
		sad_updusr,	sad_credat,		sad_upddat,
		sad_timstp,		sad_itmtyp,	sad_smpselprc,
		sad_cuscol,		sad_coldsc,		sad_venno,
		sad_subcde,	sad_cusven,	sad_cussub,
		sad_fcurcde,	sad_smpftyprc,	isnull(	cast(sad_untcde as nvarchar(6)) + ' / ' + 
			cast(sad_inrqty as nvarchar(10)) + ' / ' + 
			cast(sad_mtrqty as nvarchar(10)) + ' / ' + 
			cast(sad_cft as nvarchar(10)) + ' / ' + 
			sad_imu_hkprctrm + ' / ' +
			sad_imu_ftyprctrm + ' / ' +
			sad_imu_trantrm + ' / ' +
			cast(sad_qutno as nvarchar(20)) 
			,'') ,
		sad_cusitm,	
		--vbi_ventyp,
		sad_imu_cus1no,	
		sad_imu_cus2no,	sad_imu_hkprctrm,	sad_imu_ftyprctrm,	
		sad_imu_trantrm,	sad_imu_effdat,	sad_imu_expdat
	order by	sad_untcde, sad_inrqty, sad_mtrqty, sad_cft, sad_credat desc
end

 






GO
GRANT EXECUTE ON [dbo].[sp_list_SAORDDTL2] TO [ERPUSER] AS [dbo]
GO
