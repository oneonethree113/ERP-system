/****** Object:  StoredProcedure [dbo].[SP_SELECT_MEXRATE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_MEXRATE]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_MEXRATE]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: 
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 15 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
20030715	Allan Yuen		Modify For Merge Porject
*/

CREATE PROCEDURE [dbo].[SP_SELECT_MEXRATE]
@cocde		nvarchar(6) = ' ',
@fm_curcde	nvarchar(6),
@to_curcde	nvarchar(6),
@bs_flag	nvarchar(1),
@effdat		datetime,
@return_effdat	datetime 	OUTPUT,
@return_rate	numeric(13,11)	OUTPUT

AS
Begin

declare 
@buyrat	numeric(13,11),
@selrat		numeric(13,11)

If @effdat = '' 
begin
	set @effdat = '1900-01-01' 
end
		
select	@buyrat = yce_buyrat, 
	@selrat = yce_selrat, 
	@return_effdat = yce_effdat 
from 
	SYCUREX (nolock)
where
	yce_frmcur = @fm_curcde
	and yce_tocur = @to_curcde
	and (( @effdat = '1900-01-01' and yce_iseff = 'Y' ) or ( yce_effdat = @effdat + ' 00:00:00' ))

if @bs_flag = 'S'
begin
	if @selrat is NULL
	begin
		Set @return_rate = 0
		return (99)
	end
	else
	begin
	          	Set @return_rate = @selrat
	end
end
else if @bs_flag = 'B'
begin
	if @buyrat is NULL
	begin
		Set @return_rate = 0
		return (99)
	end
	else
	begin
	          	Set @return_rate = @buyrat
	end
end
else
begin
	Set @return_rate = 0
	return (99)
end



End

GO
GRANT EXECUTE ON [dbo].[SP_SELECT_MEXRATE] TO [ERPUSER] AS [dbo]
GO
