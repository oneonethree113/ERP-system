/****** Object:  StoredProcedure [dbo].[sp_update_IMIMGCHKLST]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMIMGCHKLST]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMIMGCHKLST]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
21 April 2005	Allan Yuen		Cater MS Company
*/


/*
=========================================================
Program ID	: sp_update_IMIMGCHKLST
Description   	: Update Item Image Check List
Programmer  	: Allan Yuen
Create Date   	: 15 Apr 2003
Last Modified  	: 
Table Read(s) 	:IMIMGCHKLST
Table Write(s) 	:IMIMGCHKLST
=========================================================
 Modification History                                    
=========================================================
 Date      	Initial  	Description          
               
=========================================================     
*/
CREATE PROCEDURE [dbo].[sp_update_IMIMGCHKLST] 
AS


SET NOCOUNT ON

DECLARE  
	@ItemCreDat INT, 	@VENCDE varchar(6),
	@cocde varchar (6),	@imcredat int,
	@imcreno int,	@imimgmisno int,
	@ftycde varchar (6), 	@ftyname nvarchar (20) ,
	@creusr varchar (30) ,	@updusr varchar (30),
	@credat datetime,	@upddat datetime

SET @credat = GETDATE()
SET @upddat = GETDATE()

DECLARE ItemCreate_cursor CURSOR FOR 
	select 
		distinct(convert(varchar(6),ibi_credat,112)) 
	from 
		imbasinf 
	order by 
		convert(varchar(6),ibi_credat,112)
OPEN ItemCreate_cursor 

FETCH NEXT FROM ItemCreate_cursor 
INTO @ItemCreDat

WHILE @@FETCH_STATUS = 0
BEGIN

	DECLARE ItemVendor_cursor CURSOR FOR 
		select 
			DISTINCT(IBI_VENNO) 
		from 
			imbasinf (nolock)
		where 
			(ibi_cocde=' ' or ibi_cocde='UCPP' or ibi_cocde='MS') AND convert(varchar(6),ibi_credat,112) = @ItemCreDat
		
		OPEN ItemVendor_cursor 
		
		FETCH NEXT FROM ItemVendor_cursor 
		INTO @VENCDE 

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @imcreno = 0
			SET @imimgmisno = 0

			---------------------------------
			SELECT
				@ftycde  = isnull(ibi_venno,''),
				@ftyname = vbi_vensna, 
				@imimgmisno = COUNT(1)
			from 
				imbasinf (nolock)
				left outer join vnbasinf (nolock)  on 
					--ibi_cocde=vbi_cocde and 
					ibi_venno=vbi_venno
				where  
					ibi_imgpth=' '  and  
					(ibi_cocde='UCPP' OR ibi_cocde='MS' or ibi_cocde=' ')
					AND convert(varchar(6),ibi_credat,112) = @ItemCreDat
					AND ibi_venno = @VENCDE 
				group by
					ibi_venno, vbi_vensna
			---------------------------------			
			SELECT
				@ftycde  = isnull(ibi_venno,''),
				@ftyname = vbi_vensna, 
				@imcreno = COUNT(1)
			from 
				imbasinf (nolock)
				left outer join vnbasinf (nolock) on 
					ibi_cocde=vbi_cocde and 
					ibi_venno=vbi_venno
				where  
					(ibi_cocde='UCPP' OR ibi_cocde='MS' or ibi_cocde=' ')
					AND convert(varchar(6),ibi_credat,112) = @ItemCreDat
					AND ibi_venno = @VENCDE 
				group by
					ibi_venno, vbi_vensna
			---------------------------------
			INSERT INTO 
				IMIMGCHKLST
					(cocde, imcredat, imcreno, imimgmisno, ftycde, ftyname, 	creusr, updusr, credat, upddat)
				values
					(' ',@ItemCreDat, @imcreno, @imimgmisno, @ftycde, @ftyname, 'MIS', 'MIS', @credat, @upddat)

			FETCH NEXT FROM ItemVendor_cursor 
			INTO @VENCDE 
		END

		CLOSE ItemVendor_cursor 
		DEALLOCATE ItemVendor_cursor 

	FETCH NEXT FROM ItemCreate_cursor 
	INTO @ItemCreDat
END

CLOSE ItemCreate_cursor 
DEALLOCATE ItemCreate_cursor



GO
GRANT EXECUTE ON [dbo].[sp_update_IMIMGCHKLST] TO [ERPUSER] AS [dbo]
GO
