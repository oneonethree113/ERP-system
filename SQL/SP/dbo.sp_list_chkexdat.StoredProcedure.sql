/****** Object:  StoredProcedure [dbo].[sp_list_chkexdat]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_chkexdat]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_chkexdat]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[sp_list_chkexdat] 


@ied_cocde	nvarchar(6),	
@ied_xlsfil	nvarchar(50),	
@ied_chkdat	nvarchar(30)

AS

declare 
@cur_ucpno	nvarchar(20)

BEGIN

DECLARE cur_REGITM CURSOR
FOR 	SELECT	distinct ied_ucpno		
	FROM		imitmexdat
	WHERE 	ied_xlsfil = @ied_xlsfil and 
		ied_chkdat = @ied_chkdat and 
		ied_itmtyp = 'REG' and
		ied_stage = 'W'
OPEN cur_REGITM
FETCH NEXT FROM cur_REGITM INTO 
@cur_ucpno

WHILE @@fetch_status = 0
BEGIN

	if (select count(*) from imbomass where iba_itmno = @cur_ucpno and iba_typ = 'BOM') > 0 
	begin

		if (select count(*) from imbomexdat where ibd_ucpno = @cur_ucpno and ibd_xlsfil = @ied_xlsfil and ibd_chkdat = @ied_chkdat) = 0
		begin
			update imbomexdat set ibd_stage = 'I', ibd_sysmsg = left(ibd_sysmsg +  (case ibd_sysmsg when '' then @cur_ucpno + ' - Item no with previous BOM item.'   
				else ', ' + @cur_ucpno + ' - Item no with previous BOM item' end),300)  
			where  ibd_ucpno = @cur_ucpno and ibd_xlsfil = @ied_xlsfil and ibd_chkdat = @ied_chkdat		

			update IMITMEXDAT set ied_stage = 'I' , ied_sysmsg = left(ied_sysmsg +  (case ied_sysmsg when '' then @cur_ucpno + ' - Item no with previous BOM item.'   
				else ', ' + @cur_ucpno + ' - Item no with previous BOM item' end),300)  
			where  ied_ucpno = @cur_ucpno and ied_xlsfil = @ied_xlsfil and ied_chkdat = @ied_chkdat  
	
		end			
	end

FETCH NEXT FROM cur_REGITM INTO 
@cur_ucpno
END
CLOSE cur_REGITM
DEALLOCATE cur_REGITM


END




GO
GRANT EXECUTE ON [dbo].[sp_list_chkexdat] TO [ERPUSER] AS [dbo]
GO
