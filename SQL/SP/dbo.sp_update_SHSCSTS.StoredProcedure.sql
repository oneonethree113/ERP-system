/****** Object:  StoredProcedure [dbo].[sp_update_SHSCSTS]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHSCSTS]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHSCSTS]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO






/*
=========================================================
Program ID	: 	sp_update_SHSCSTS
Description   	: 	Check and Update SC Status online
Programmer  	: 	Lewis To
Create Date   	: 	13 May 2003
Last Modified  	: 
Table Read(s) 	:	SCORDHDR, SCORDDTL
Table Write(s) 	:	SCORDHDR
=========================================================
 Modification History                                    
=========================================================
2005-03-05	Allan Yuen	Add Skip updte status if status is active.               
=========================================================     
*/


-- Checked by Allan Yuen at 27/07/2003


CREATE PROCEDURE [dbo].[sp_update_SHSCSTS]


--Declare
@soh_cocde 	varchar(5),
@soh_ordno	varchar(20),
@soh_usr	varchar(30)


--set @soh_cocde = 'UCPP'
--set @soh_ordno = 'US0301366'
--set @soh_usr = 'MIS'
AS

Declare
@sod_outqty 	int,
@sod_ttlord	int
select 
	@sod_outqty = sum(case when (sod_ordqty-sod_shpqty)>0 Then (sod_ordqty-sod_shpqty) ELSE 0 END), 
          	@sod_ttlord = sum(case when (sod_ordqty)>0 Then (sod_ordqty) ELSE 0 END) 
from 	
	scorddtl 
where 
	sod_cocde = @soh_cocde and 
	sod_ordno = @soh_ordno

Update 
	scordhdr 
set 
	soh_ordsts = case when @sod_outqty = 0 Then 'CLO' Else 'REL' End,
	soh_updusr = @soh_usr,
	soh_upddat = getdate()
where 
	soh_cocde = @soh_cocde and 
	soh_ordno = @soh_ordno and 
	@sod_ttlord > 0 and 
	soh_ordsts <> case when @sod_outqty = 0 Then 'CLO' Else 'REL' End and
	soh_ordsts in ('CLO','REL' )



GO
GRANT EXECUTE ON [dbo].[sp_update_SHSCSTS] TO [ERPUSER] AS [dbo]
GO
