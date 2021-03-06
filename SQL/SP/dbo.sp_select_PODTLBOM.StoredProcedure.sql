/****** Object:  StoredProcedure [dbo].[sp_select_PODTLBOM]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PODTLBOM]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PODTLBOM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- Checked by Allan Yuen at 28/07/2003  
  
/************************************************************************  
Author:  Wong Hong  
Date:  4th Jan, 2002  
Description: Select data From PODTLBOM  
Parameter: 1. Company  
  2. PO No.   
************************************************************************/  

CREATE  procedure [dbo].[sp_select_PODTLBOM]  
@pdb_cocde nvarchar(6) ,  
@pdb_purord nvarchar(20)  
AS  
begin  
Select   
	p.pdb_seq,  		--0
	p.pdb_assitm,  		--1
	p.pdb_bomitm,  	--2
	p.pdb_colcde,  		--3
	i.ibi_engdsc,  		--4
	p.pdb_bomqty,  	--5
	-- Frankie Cheung 20110307 Add Assd Period
	case when year(p.pdb_imperiod) = 1900 then '' else
	ltrim(str(year(p.pdb_imperiod))) + '-' + right('0' +  ltrim(str( month(p.pdb_imperiod))),2) end as 'p.pdb_imperiod',	--6
	p.pdb_pckunt,  	--7
	p.pdb_venno,  		--8
	p.pdb_curcde,  	--9
	p.pdb_ftyprc,  		--10
	s.ysi_buyrat,  		--11
	p.pdb_ordqty,  		--12
	p.pdb_bompno,  	--13
	p.pdb_bompoflg  	--14
from 
	PODTLBOM p
	left join SYSETINF s on s.ysi_cde = p.pdb_curcde AND s.ysi_typ = '06'
	left join IMBASINF i on p.pdb_bomitm = i.ibi_itmno   
where                                                                                                                                                                                                                                                          
	p.pdb_cocde = @pdb_cocde AND  
	p.pdb_purord = @pdb_purord   
end  
  
  








GO
GRANT EXECUTE ON [dbo].[sp_select_PODTLBOM] TO [ERPUSER] AS [dbo]
GO
