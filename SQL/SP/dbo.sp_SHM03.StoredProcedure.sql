/****** Object:  StoredProcedure [dbo].[sp_SHM03]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_SHM03]
GO
/****** Object:  StoredProcedure [dbo].[sp_SHM03]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_SHM03] 

@cocde	nvarchar(6),
@from	nvarchar(20),
@to	nvarchar(20),
@fntyp	nvarchar(1)

AS

BEGIN

	IF @fntyp = 'Y' 
	BEGIN
		
		DECLARE -- SHIPGDTL
		@hid_ordno	nvarchar(20), 
		@hid_ordseq	int, 
		@hid_shpqty int
		
		DECLARE cur_SHIPGDTL CURSOR
		FOR SELECT 
		d.hid_ordno,	
		d.hid_ordseq,
		d.hid_shpqty
		FROM SHIPGDTL d, SHIPGHDR h
		WHERE
		h.hih_shpsts = 'OPE' AND
		d.hid_shpno = h.hih_shpno AND
		d.hid_cocde = h.hih_cocde AND
		d.hid_shpno >= @from AND
		d.hid_shpno <= @to AND
		d.hid_cocde = @cocde

		OPEN cur_SHIPGDTL
		FETCH NEXT FROM cur_SHIPGDTL INTO 
		@hid_ordno, 
		@hid_ordseq,
		@hid_shpqty

		WHILE @@fetch_status = 0
		BEGIN
		
			UPDATE SCORDDTL SET 
			sod_invqty = sod_invqty + @hid_shpqty 
			WHERE 
			sod_cocde = @cocde AND
			sod_ordno = @hid_ordno AND
			sod_ordseq = @hid_ordseq
		
			FETCH NEXT FROM cur_SHIPGDTL INTO 
			@hid_ordno, 
			@hid_ordseq,
			@hid_shpqty
		END
		
		CLOSE cur_SHIPGDTL                                   
		DEALLOCATE cur_SHIPGDTL            	
		
		UPDATE SHIPGHDR SET 
		hih_shpsts = 'REL' 
		WHERE hih_shpsts = 'OPE' AND
		hih_shpno >= @from AND
		hih_shpno <= @to

	END

END





GO
GRANT EXECUTE ON [dbo].[sp_SHM03] TO [ERPUSER] AS [dbo]
GO
