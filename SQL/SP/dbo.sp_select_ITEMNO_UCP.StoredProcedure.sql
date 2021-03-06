/****** Object:  StoredProcedure [dbo].[sp_select_ITEMNO_UCP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ITEMNO_UCP]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ITEMNO_UCP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/************************************************************************
Author:		Kenny Chan
Date:		13th September, 2001
Description:	Select Max Itmno  From IMBASINF,IMBASINF
Parameter:	1. Company
		2. Item No.	
***********************************************************************
2003-07-17	Allan Yuen		For Merge Porject, disable company code
2005-07-20	Allan Yuen		Add new generate item method
2006-01-14	Allan Yuen		User Anita request to rollback the logic at 2006-01-13
*/
------------------------------------------------- 
CREATE procedure [dbo].[sp_select_ITEMNO_UCP]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@ibi_cocde	nvarchar(6),
@itmtyp		char(1),
@prdlne		nvarchar(20),
@ibi_venno	nvarchar(6)
---------------------------------------------- 
AS
declare @Year  nvarchar(2)
declare @season  char(1)
declare @theme char(2)
declare @newno varchar(20)


SET @Year = (Select right(Year(Getdate()),2))

begin
Select @Year + @ibi_venno + '-' +
Case (Len((case when a.itmno>b.itmno then a.itmno else b.itmno end + 1)))  
when 1 then '0000'
when 2 then '000'	
when 3 then '00'	
when 4 then '0'
else ''
end								
+
ltrim(Str((case when a.itmno>b.itmno then a.itmno 
else b.itmno
end + 1)))
 as 'Max_itmno'
from
(
Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
from imbasinf 
where 	
--ibi_cocde = @ibi_cocde and
	ibi_venno = @ibi_venno and
	left(ibi_itmno,2) = @Year and
	ISNUMERIC(right(ibi_itmno,5)) = 1
	and ibi_credat > '2010-01-01'
)a, 

(Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
from imbasinfh 
where 
--	ibi_cocde = @ibi_cocde and
	ibi_venno = @ibi_venno and
	left(ibi_itmno,2) = @Year and
	ISNUMERIC(right(ibi_itmno,5)) = 1
	and ibi_credat > '2010-01-01'
)b
---------------------------------------------------------- 
end


/*
--if ltrim(rtrim(@prdlne)) = ''
if @itmtyp  = 'B'
begin
--	SET @Year = (Select right(Year(Getdate()),2))
--	Select 
--	@Year + @ibi_venno + '-' +
--	Case (Len((case when a.itmno>b.itmno then a.itmno else b.itmno end + 1)))  
--	when 1 then '0000'
--	when 2 then '000'	
--	when 3 then '00'	
--	when 4 then '0'
--	else ''
--	end								
--	+
--	ltrim(Str((case when a.itmno>b.itmno then a.itmno 
--	else b.itmno
--	end + 1)))
--	 as 'Max_itmno'
--	from	
--	(
--	Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
--	from imbasinf 
--	where 	
--	--ibi_cocde = @ibi_cocde and
--		ibi_venno = @ibi_venno and
--		left(ibi_itmno,2) = @Year and
--		--ibi_typ = 'BOM'
--		substring(ibi_itmno,8,1) not in ('F','S')
--
--	)a, 
--	(Select isnull(Max(cast(right(ibi_itmno,5) as int)),0)  as 'itmno' 
--	from imbasinfh 
--	where 
--	--	ibi_cocde = @ibi_cocde and
--		ibi_venno = @ibi_venno and
--		left(ibi_itmno,2) = @Year and
--		--ibi_typ = 'BOM'
--		substring(ibi_itmno,8,1) not in ('F','S')
--	)b

	---------------------------------------------------------- 

	SET @Year = (Select right(Year(Getdate()),2))
	set @theme = ''
	set @season = ''

	--- Get New Number ---
	select 
		@newno =  case when a.itmno>b.itmno then a.itmno else b.itmno end + 1
	from
		(
		Select  
			isnull(Max(cast(right(ibi_itmno,3) as int)),0)  as 'itmno' 
		from 
			imbasinf 
		where 	
			left(ibi_itmno,2) = @year and
			substring(ibi_itmno,3,4) = @ibi_venno and
			substring(ibi_itmno,8,4) = '000B'
		)a, 
		(
		Select  
			isnull(Max(cast(right(ibi_itmno,3) as int)),0)  as 'itmno' 
		from 
			imbasinfh 
		where 	
			left(ibi_itmno,2) = @year and
			substring(ibi_itmno,3,4) = @ibi_venno and
			substring(ibi_itmno,8,4) = '000B'
		)b 
	----------------------


	--- Output New Number ---
	Select 
		ltrim(rtrim(@year)) +
		ltrim(rtrim(@ibi_venno)) + '-' + '000'+
		ltrim(rtrim(@itmtyp)) +
		Case (Len((@newno)))  
		when 1 then '00'
		when 2 then '0'	
		--when 3 then '00'	
		--when 4 then '0'
		else ''
		end + 
		ltrim(rtrim(@newno))
	 as 'Max_itmno'
	--------------------------------

end
else
begin
	set @year = substring(@prdlne,4,2)
	set @theme = substring(@prdlne,1,2)
	set @season = substring(@prdlne,6,1)

	--- Get New Number ---
	select 
		@newno =  case when a.itmno>b.itmno then a.itmno else b.itmno end + 1
	from
		(
		Select  
			isnull(Max(cast(right(ibi_itmno,3) as int)),0)  as 'itmno' 
		from 
			imbasinf 
		where 	
			left(ibi_itmno,2) = @year and
			substring(ibi_itmno,3,4) = @ibi_venno and
			substring(ibi_itmno,8,4) = @season + @theme + @itmtyp
		)a, 
		(
		Select  
			isnull(Max(cast(right(ibi_itmno,3) as int)),0)  as 'itmno' 
		from 
			imbasinfh 
		where 	
			left(ibi_itmno,2) = @year and
			substring(ibi_itmno,3,4) = @ibi_venno and
			substring(ibi_itmno,8,4) = @season + @theme + @itmtyp
		)b 
	----------------------


	--- Output New Number ---
	Select 
		ltrim(rtrim(@year)) +
		ltrim(rtrim(@ibi_venno)) + '-' +
		ltrim(rtrim(@season)) + 
		ltrim(rtrim(@theme)) + 
		ltrim(rtrim(@itmtyp)) +
		Case (Len((@newno)))  
		when 1 then '00'
		when 2 then '0'	
		--when 3 then '00'	
		--when 4 then '0'
		else ''
		end + 
		ltrim(rtrim(@newno))
	 as 'Max_itmno'
	--------------------------------

end
*/

GO
GRANT EXECUTE ON [dbo].[sp_select_ITEMNO_UCP] TO [ERPUSER] AS [dbo]
GO
