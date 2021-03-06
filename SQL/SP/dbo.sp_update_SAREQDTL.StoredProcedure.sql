/****** Object:  StoredProcedure [dbo].[sp_update_SAREQDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SAREQDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SAREQDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





-- Checked by Allan Yuen at 28/07/2003

/*	Author : Tommy Ho	*/

CREATE PROCEDURE [dbo].[sp_update_SAREQDTL] 

@srd_cocde	nvarchar(6),	@srd_reqno	nvarchar(20),	@srd_reqseq	int,
@srd_engdsc	nvarchar(800),	@srd_chndsc	nvarchar(1600),	@srd_cuscol	nvarchar(30),
@srd_coldsc	nvarchar(300),	@srd_note		nvarchar(300),	@srd_canflg	nvarchar(1),
@srd_cusitm	nvarchar(20),	@srd_smpqty	int,		@srd_stkqty	int,
@srd_cusqty	int,		@srh_cus1no	nvarchar(6),	@srd_itmno 	nvarchar(20),
@srd_colcde	nvarchar(30),	@srd_creusr	nvarchar(30)

AS

declare 	@sad_itmno	nvarchar(20),	@sad_colcde 	nvarchar(30)
declare		@sad_chgqty	int, @sad_freqty int


UPDATE 	SAREQDTL
SET	srd_engdsc = @srd_engdsc,	srd_chndsc = @srd_chndsc,	srd_cuscol = @srd_cuscol,
	srd_coldsc = @srd_coldsc,	srd_note = @srd_note,	srd_canflg = @srd_canflg,
	srd_cusitm = @srd_cusitm,	srd_updusr = @srd_creusr,	srd_upddat = getdate()WHERE	srd_cocde = @srd_cocde 	and 	srd_reqno = @srd_reqno	and
	srd_reqseq = @srd_reqseq

if @srd_canflg = 'Y'
begin
	UPDATE	SAORDDTL
	SET	sad_delflg = 'R', 	sad_upddat = getdate(),	sad_updusr = @srd_creusr
	WHERE	sad_cocde = @srd_cocde and sad_reqno = @srd_reqno and sad_reqseq = @srd_reqseq and sad_delflg = 'N'

	UPDATE	SAORDDTL
	SET	sad_delflg = 'QR', 	sad_upddat = getdate(),	sad_updusr = @srd_creusr
	WHERE	sad_cocde = @srd_cocde and sad_reqno = @srd_reqno and sad_reqseq = @srd_reqseq and sad_delflg = 'Q'

--	if @srd_colcde is not NULL and @srd_colcde <> '' 
--	begin
--		UPDATE SAORDSUM
--		SET	sas_smpqty = sas_smpqty - @srd_smpqty,	sas_stkqty = sas_stkqty - @srd_stkqty,
--			sas_cusqty = sas_cusqty - @srd_cusqty, 	sas_upddat = getdate(),
--			sas_updusr = @srd_creusr
--		WHERE	sas_cocde = @srd_cocde and sas_cus1no = @srh_cus1no and
--			sas_itmno = @srd_itmno and sas_colcde = @srd_colcde
--	end
--	else
--	begin
		select 	@sad_itmno = sad_itmno, @sad_colcde = sad_colcde , @sad_chgqty = isnull(sad_chgqty, 0), @sad_freqty = isnull(sad_freqty, 0)
		from	SAORDDTL
		where	sad_cocde = @srd_cocde and sad_reqno = @srd_reqno and sad_reqseq = @srd_reqseq --and sad_delflg = 'R'

		if @sad_itmno is not NULL and @sad_itmno <> '' and @sad_colcde is not NULL and @sad_colcde <> ''
		begin
			UPDATE SAORDSUM
			SET	sas_smpqty = sas_smpqty - @srd_smpqty,	sas_stkqty = sas_stkqty - @srd_stkqty,
				sas_cusqty = sas_cusqty - @srd_cusqty, 	sas_upddat = getdate(),
				sas_updusr = @srd_creusr,	
				sas_chgqty = sas_chgqty - @sad_chgqty,
				sas_freqty = sas_freqty - @sad_freqty
			WHERE
				sas_cocde = @srd_cocde and 
				sas_cus1no in (select cbi_cusno from cubasinf (nolock) where cbi_cusali = @srh_cus1no or cbi_cusno = @srh_cus1no 
						UNION 
			               		SELECT cbi_cusali from cubasinf (nolock) where cbi_cusno = @srh_cus1no ) and
				sas_itmno in (Select ibi_itmno  from imbasinf where ibi_itmno = @sad_itmno or ibi_alsitmno = @sad_itmno
				      		union
			              		select bas.ibi_alsitmno from imbasinf  bas left join imbasinf als on bas.ibi_alsitmno = als.ibi_itmno where bas.ibi_itmno = @sad_itmno and als.ibi_itmsts <> 'OLD' ) and
				sas_colcde = @sad_colcde
		end
--	end


		
end



GO
GRANT EXECUTE ON [dbo].[sp_update_SAREQDTL] TO [ERPUSER] AS [dbo]
GO
