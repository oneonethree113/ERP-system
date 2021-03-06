/****** Object:  StoredProcedure [dbo].[SP_SELECT_EXRATE]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[SP_SELECT_EXRATE]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_EXRATE]    Script Date: 09/29/2017 11:53:53 ******/
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

CREATE PROCEDURE [dbo].[SP_SELECT_EXRATE]
@cocde		nvarchar(6) = ' ',
@fm_curcde	nvarchar(6),
@to_curcde	nvarchar(6),
@bs_flag		nvarchar(1),
@return_rate	numeric(13,11)	OUTPUT

AS
Begin
Declare	@fm_rate	 numeric(13,11),
	@to_rate	numeric(13,11)

If @bs_flag = 'B'
   Begin
--       Select @fm_rate =  ysi_buyrat from SYSETINF where ysi_cocde = @cocde and ysi_typ = '06' and ysi_cde = @fm_curcde
       Select @fm_rate =  ysi_buyrat from SYSETINF where ysi_cocde = ' ' and ysi_typ = '06' and ysi_cde = @fm_curcde
       If @fm_rate is NULL
          Begin
               Set @return_rate = 0
              return (99)
          End

--       Select @to_rate =  ysi_buyrat from SYSETINF where ysi_cocde = @cocde and ysi_typ = '06' and ysi_cde = @to_curcde
       Select @to_rate =  ysi_buyrat from SYSETINF where ysi_cocde = ' ' and ysi_typ = '06' and ysi_cde = @to_curcde
       If @to_rate is NULL or @to_rate = 0
          Begin
               Set @return_rate = 0
              return (99)
          End

          Set @return_rate = @fm_rate / @to_rate
   End

If @bs_flag = 'S'
   Begin
--       Select @fm_rate =  ysi_selrat from SYSETINF where ysi_cocde = @cocde and ysi_typ = '06' and ysi_cde = @fm_curcde
       Select @fm_rate =  ysi_selrat from SYSETINF where ysi_cocde = ' ' and ysi_typ = '06' and ysi_cde = @fm_curcde
       If @fm_rate is NULL
          Begin
               Set @return_rate = 0
              return (99)
          End

--       Select @to_rate =  ysi_selrat from SYSETINF where ysi_cocde = @cocde and ysi_typ = '06' and ysi_cde = @to_curcde
       Select @to_rate =  ysi_selrat from SYSETINF where ysi_cocde = ' ' and ysi_typ = '06' and ysi_cde = @to_curcde
       If @to_rate is NULL or @to_rate = 0
          Begin
               Set @return_rate = 0
              return (99)
          End

          Set @return_rate = @fm_rate / @to_rate
   End

End




GO
GRANT EXECUTE ON [dbo].[SP_SELECT_EXRATE] TO [ERPUSER] AS [dbo]
GO
