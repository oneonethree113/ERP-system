/****** Object:  StoredProcedure [dbo].[sp_list_IMBOMASS]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_IMBOMASS]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_IMBOMASS]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
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
Last Modified  	: 19 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030719	Allan Yuen	Modify For Merge Porject 
				(Disable company code)
20060917	Lester Wu Prohibit activation of item with assorted item in "OLD - Old Item" status
*/


CREATE PROCEDURE [dbo].[sp_list_IMBOMASS] 

@iba_cocde	nvarchar(6),
@iba_itmno 	nvarchar(20),
@iba_usrid	nvarchar(30),
@typ		nvarchar(10),
@act		nvarchar(10)

AS
If @typ = 'ASS'
BEGIN
	IF @act = 'ACT'
	BEGIN
		Select 
		Distinct 	iba_itmno	,	iba_assitm,	
			--CASE When ibi_itmsts = 'DIS' or ibi_itmsts = 'INA' or ibi_itmsts = 'TBC'  then 'Y' Else 'N' End as 'IM_Status'
			CASE When ibi_itmsts = 'DIS' or ibi_itmsts = 'INA' or ibi_itmsts = 'TBC' or ibi_itmsts = 'OLD' then 'Y' Else 'N' End as 'IM_Status'
		From IMBOMASS 
		left join IMBASINF on ibi_itmno = iba_assitm --and ibi_cocde = iba_cocde
		where 	
			--iba_cocde = @iba_cocde and
			iba_itmno = @iba_itmno 

	END
END
ELSE IF @typ = 'REG'
BEGIN
	IF @act = 'ACT'
	BEGIN
		/*Select
		Distinct a.iba_itmno	as 'ASS_Item',	isnull(d.ibi_itmno,'')as 'REG_Item' 
		from IMBOMASS a, IMBASINF b 
		left join IMBOMASS c on 
			--c.iba_cocde = b.ibi_cocde and 
			c.iba_itmno = b.ibi_itmno 
		left join IMBASINF d on 
			--d.ibi_cocde = c.iba_cocde and 
			d.ibi_itmno = c.iba_assitm and
		(d.ibi_itmsts = 'DIS' or d.ibi_itmsts  = 'INA' ) and d.ibi_itmno <>  @iba_itmno
		where 	
			--a.iba_cocde = @iba_cocde and
			a.iba_assitm = @iba_itmno and
			b.ibi_itmno = a.iba_itmno and 
			--b.ibi_cocde = a.iba_cocde and
			(b.ibi_itmsts = 'DIS' or b.ibi_itmsts  = 'INA' )*/
		Select
		Distinct  a.iba_itmno as 'ASS_Item'  , isnull(c.CountR,0) as 'CountR'
		from IMBOMASS a, IMBASINF b 
		left join
		(Select iba_itmno,  count(*) as 'CountR'
				From imbomass	
				left join imbasinf on --iba_cocde = ibi_cocde and
				iba_assitm = ibi_itmno and
				-- Lester Wu 2006-09-17
				--(ibi_itmsts = 'DIS' or ibi_itmsts = 'INA' or ibi_itmsts = 'TBC')	 
				(ibi_itmsts = 'DIS' or ibi_itmsts = 'INA' or ibi_itmsts = 'TBC' or ibi_itmsts = 'OLD')	 
				where 	
				--iba_cocde = @iba_cocde and				
				iba_assitm <> @iba_itmno and				
				ibi_itmno is not null
				group by iba_itmno) c 
				on b.ibi_itmno = c.iba_itmno
		where 	
			--a.iba_cocde = @iba_cocde and
			a.iba_assitm = @iba_itmno and
			b.ibi_itmno = a.iba_itmno and 
			--b.ibi_cocde = a.iba_cocde and			
			-- Lester Wu 2006-09-17
			--(b.ibi_itmsts = 'DIS' or b.ibi_itmsts  = 'INA' OR b.ibi_itmsts  = 'TBC' ) 
			(b.ibi_itmsts = 'DIS' or b.ibi_itmsts  = 'INA' OR b.ibi_itmsts  = 'TBC' OR b.ibi_itmsts  = 'OLD' ) 
	END
	ELSE IF @act = 'DIS'
	BEGIN
		Select 
		Distinct iba_itmno	,	iba_assitm
		from IMBOMASS 
		left join IMBASINF on ibi_itmno = iba_itmno and
			--and ibi_cocde = iba_cocde and 
			--Lester Wu 2006-09-17
			--(ibi_itmsts <> 'DIS' and ibi_itmsts <> 'INA' AND ibi_itmsts <> 'TBC' ) 
			(ibi_itmsts <> 'DIS' and ibi_itmsts <> 'INA' AND ibi_itmsts <> 'TBC' AND ibi_itmsts <> 'OLD') 
		Where 	
			--iba_cocde = @iba_cocde and
			iba_assitm = @iba_itmno and
			ibi_itmno is not null	
	END
END









GO
GRANT EXECUTE ON [dbo].[sp_list_IMBOMASS] TO [ERPUSER] AS [dbo]
GO
