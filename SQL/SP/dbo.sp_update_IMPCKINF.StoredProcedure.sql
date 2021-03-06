/****** Object:  StoredProcedure [dbo].[sp_update_IMPCKINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMPCKINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMPCKINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO







-- Checked by Allan Yuen at 28/07/2003    
    
    
/*    
=========================================================    
Program ID :     
Description    :     
Programmer   :     
ALTER  Date    :     
Last Modified   : 17 July 2003    
Table Read(s)  :    
Table Write(s)  :    
=========================================================    
 Modification History                                        
=========================================================    
Date  Author  Description    
=========================================================         
17 July 2003 	Allan Yuen  	For Merge Porject, disable company code    
13 Sept 2012	David Yue	Add Packing Inner Size, Master Size, Material
*/    
    
/************************************************************************    
Author:  Kenny Chan    
Date:  15th September, 2001    
************************************************************************/    
-------------------------------------------------     
CREATE procedure [dbo].[sp_update_IMPCKINF]    
  
@ipi_cocde  nvarchar  (6),    
@ipi_itmno   nvarchar  (20),    
/*    
--Modified by Victor Leung 20030120    
--@ipi_pckunt   nvarchar(4),    
*/    
@ipi_pckunt   nvarchar(6),    
/**/    
@ipi_pckseq  int,    
@ipi_mtrqty   int,    
@ipi_inrqty   int,    
@ipi_inrhin   numeric(11,4) ,    
@ipi_inrwin   numeric(11,4),    
@ipi_inrdin   numeric(11,4),    
@ipi_inrhcm   numeric(11,4),    
@ipi_inrwcm   numeric(11,4),    
@ipi_inrdcm   numeric(11,4),    
@ipi_mtrhin   numeric(11,4),    
@ipi_mtrwin   numeric(11,4),    
@ipi_mtrdin   numeric(11,4),    
@ipi_mtrhcm   numeric(11,4),    
@ipi_mtrwcm   numeric(11,4),    
@ipi_mtrdcm   numeric(11,4),    
@ipi_cft    numeric(11,4),    
@ipi_cbm   numeric(11,4),    
@ipi_grswgt   numeric(6,3),    
@ipi_netwgt   numeric(6,3),    
@ipi_pckitr   nvarchar(300),    
@ipi_conftr int,   
@ipi_cusno	nvarchar(6),
-- Added by Mark Lau 20090211
@ipi_qutdat	datetime,
-- David Yue	2012-09-13	Add Packing Inner Size, Master Size, Material
@ipi_inrsze	nvarchar(500),
@ipi_mtrsze	nvarchar(500),
@ipi_mat	nvarchar(500),
--
@ipi_cus1no	nvarchar(6),
@ipi_cus2no	nvarchar(6),
@ipi_updusr   nvarchar(30)                                         
------------------------------------     
AS    
    
if @ipi_conftr <= 0
begin
	set @ipi_conftr = 1
end

update IMPCKINF    
set ipi_pckunt= @ipi_pckunt,    
ipi_mtrqty=@ipi_mtrqty,    
ipi_inrqty=@ipi_inrqty,    
ipi_inrhin=@ipi_inrhin,    
ipi_inrwin=@ipi_inrwin,    
ipi_inrdin=@ipi_inrdin,    
ipi_inrhcm=@ipi_inrhcm,    
ipi_inrwcm=@ipi_inrwcm,    
ipi_inrdcm=@ipi_inrdcm,    
ipi_mtrhin=@ipi_mtrhin,    
ipi_mtrwin=@ipi_mtrwin,    
ipi_mtrdin=@ipi_mtrdin,    
ipi_mtrhcm=@ipi_mtrhcm,    
ipi_mtrwcm=@ipi_mtrwcm,    
ipi_mtrdcm=@ipi_mtrdcm,    
ipi_cft=@ipi_cft,    
ipi_cbm=@ipi_cbm,    
ipi_grswgt=@ipi_grswgt,    
ipi_netwgt=@ipi_netwgt,    
ipi_pckitr=@ipi_pckitr,    
ipi_conftr = @ipi_conftr  ,
ipi_cusno = @ipi_cusno,
ipi_updusr=@ipi_updusr,    
-- Added by Mark Lau 20090211
ipi_qutdat = @ipi_qutdat,
-- David Yue	2012-09-13	Add Packing Inner Size, Master Size, Material
ipi_inrsze = @ipi_inrsze,
ipi_mtrsze = @ipi_mtrsze,
ipi_mat = @ipi_mat,
--
ipi_upddat = getdate() 
where     
--ipi_cocde = @ipi_cocde and    
ipi_itmno = @ipi_itmno and
ipi_pckseq = @ipi_pckseq and
ipi_cus1no = @ipi_cus1no and
ipi_cus2no = @ipi_cus2no





GO
GRANT EXECUTE ON [dbo].[sp_update_IMPCKINF] TO [ERPUSER] AS [dbo]
GO
