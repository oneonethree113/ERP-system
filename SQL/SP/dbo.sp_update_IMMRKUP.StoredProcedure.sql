/****** Object:  StoredProcedure [dbo].[sp_update_IMMRKUP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMMRKUP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMMRKUP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- Checked by Allan Yuen at 28/07/2003    
    
/*    
=========================================================    
Program ID :     
Description    :     
Programmer   :     
Create Date    :     
Last Modified   : 17 July 2003    
Table Read(s)  :    
Table Write(s)  :    
=========================================================    
 Modification History                                        
=========================================================    
Date  Author  Description    
=========================================================         
17 July 2003 Allan Yuen  For Merge Porject, disable company code    
20 Jan 2006 Allan Yuen  Add Fty Price Term    
21 Jun 2006 Marco Chan  Add FtyBOMCst Field Storage    
*/    
    
/************************************************************************    
Author:  Kenny Chan    
Date:  13th September, 2001    
Description: Update data From IMMRKUP    
Parameter: 1. Company    
  2. Item No.     
************************************************************************/    
/*    
 Modification History                                        
==========================================================================    
 Date       Initial    Description              
 26 Mar 2003 Lewis To Fix BOM Item not check Production Vendor Field    
                   
==========================================================================         
*/    
CREATE procedure [dbo].[sp_update_IMMRKUP]    
@imu_cocde   nvarchar(6),    
@imu_itmno   nvarchar(20),    
@imu_typ   nvarchar(4),    
@imu_ventyp   nvarchar(4),    
@imu_venno   nvarchar(6),    
@imu_prdven nvarchar(6),    
@imu_pckseq   int,    
/*    
--Modified by Victor Leung 20030120    
--@imu_pckunt   nvarchar(4),    
*/    
@imu_pckunt   nvarchar(6),    
/**/    
@imu_inrqty   int,      
@imu_mtrqty   int,      
@imu_cft   numeric(11,4)   ,    
@imu_curcde   nvarchar(6),    
@imu_prctrm   nvarchar(10),    
@imu_relatn   nvarchar(4),    
@imu_fmlopt   nvarchar(5),           
@imu_ftycst   numeric( 13,   4),    
@imu_ftyprc   numeric( 13,   4),    
@imu_calftyprc   numeric( 13,   4),    
@imu_bcurcde nvarchar(6),    
@imu_basprc   numeric( 13,   4),    
@imu_negprc   numeric( 13,   4),    
@imu_alsbasprc  numeric( 13,   4) = 0,    
@imu_bomcst  numeric( 13,   4),    
@imu_ttlcst  numeric( 13,   4),    
@imu_itmprc numeric( 13,   4),    
@imu_bomprc numeric( 13,   4),    
@imu_ftybomcst numeric( 13,   4),    
@imu_ftyprctrm   nvarchar(10),    
@imu_conftr int,  
@imu_std	char(1),
@imu_cstchgdat datetime,
@imu_updusr   nvarchar(30)    
    
AS    

--Lester Wu 2007-07-27
if @imu_conftr <= 0
begin
	set @imu_conftr = 1
end

IF @imu_typ = 'BOM'     
 begin    
  Update IMMRKUP    
  SET     
  imu_pckunt = @imu_pckunt,    
  imu_inrqty = @imu_inrqty,    
  imu_mtrqty = @imu_mtrqty,    
  imu_cft = @imu_cft,    
  imu_curcde = @imu_curcde,    
  imu_prctrm = @imu_prctrm,    
  imu_relatn = @imu_relatn,    
  imu_fmlopt = @imu_fmlopt,    
  imu_ftycst = @imu_ftycst,    
  imu_ftyprc = @imu_ftyprc,    
  imu_calftyprc = @imu_calftyprc,    
  imu_bcurcde = @imu_bcurcde,    
  imu_basprc = @imu_basprc,    
  imu_negprc = @imu_negprc,    
  imu_alsbasprc = @imu_alsbasprc,    
  imu_bomcst = @imu_bomcst,    
  imu_ttlcst = @imu_ttlcst,    
  imu_cstchgdat = @imu_cstchgdat,
  imu_updusr = @imu_updusr,    
  imu_upddat = Getdate()    
  Where      
   --imu_cocde = @imu_cocde and    
   imu_itmno = @imu_itmno and    
   imu_typ = @imu_typ and    
   imu_ventyp = @imu_ventyp and    
   imu_venno = @imu_venno and    
--   ltrim(rtrim(imu_prdven)) = ltrim(rtrim(@imu_prdven)) and    
   imu_pckseq = @imu_pckseq    
 end    
ELSE    
 begin    
  Update IMMRKUP    
  SET     
  imu_pckunt = @imu_pckunt,    
  imu_inrqty = @imu_inrqty,    
  imu_mtrqty = @imu_mtrqty,    
  imu_cft = @imu_cft,    
  imu_curcde = @imu_curcde,    
  imu_prctrm = @imu_prctrm,    
  imu_relatn = @imu_relatn,    
  imu_fmlopt = @imu_fmlopt,    
  imu_ftycst = @imu_ftycst,    
  imu_ftyprc = @imu_ftyprc,    
  imu_calftyprc = @imu_calftyprc,    
  imu_bcurcde = @imu_bcurcde,    
  imu_basprc = @imu_basprc,    
  imu_negprc = @imu_negprc,    
  imu_alsbasprc = @imu_alsbasprc,    
  imu_bomcst = @imu_bomcst,    
  imu_ttlcst = @imu_ttlcst,      imu_itmprc = @imu_itmprc,    
  imu_bomprc = @imu_bomprc,    
  imu_ftybomcst = @imu_ftybomcst,    
  imu_ftyprctrm = @imu_ftyprctrm,    
  imu_conftr = @imu_conftr,
  imu_std = @imu_std,
  imu_cstchgdat = @imu_cstchgdat,
  imu_updusr = @imu_updusr,    
  imu_upddat = Getdate()
  Where      
   --imu_cocde = @imu_cocde and    
   imu_itmno = @imu_itmno and    
   imu_typ = @imu_typ and    
   imu_ventyp = @imu_ventyp and    
   imu_venno = @imu_venno and    
   ltrim(rtrim(imu_prdven)) = ltrim(rtrim(@imu_prdven)) and    
   imu_pckseq = @imu_pckseq    
 end    
    
    
    
    
    
    
    
  
  









GO
GRANT EXECUTE ON [dbo].[sp_update_IMMRKUP] TO [ERPUSER] AS [dbo]
GO
