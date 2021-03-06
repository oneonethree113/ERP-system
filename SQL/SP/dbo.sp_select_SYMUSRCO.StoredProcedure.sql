/****** Object:  StoredProcedure [dbo].[sp_select_SYMUSRCO]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SYMUSRCO]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SYMUSRCO]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/****** Object:  Stored Procedure dbo.sp_select_SYMUSRCO    Script Date: 03/15/2003 9:12:53 ******/
/*
=========================================================
Program ID	: sp_select_SYMUSRCO
Description   	: Select data from table SYMUSRCO
Programmer  	: Lewis To
Create Date   	: 05 June  2003
Last Modified  	: 
Table Read(s) 	: SYMUSRCO, SYCOMINF
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
               
=========================================================     
*/


CREATE procedure [dbo].[sp_select_SYMUSRCO]
                                                                                                                                                                                                                                                               
--declare
@cocde	nvarchar(6),
@usrid	nvarchar(30)
AS

--declare
--@yuc_flgdel varchar(1)

select 	
	' ' as 'yuc_del',
	yuc_usrid,
	yuc_cocde,
	yco_shtnam,
	yuc_usrgrp,
	yuc_supid,
	yuc_usrank,
	yuc_flgcst,
	yuc_flgcstext,
	yuc_flgrel,
	yuc_flgdef,
	yuc_rmk,
	yuc_creusr
--	yuc_updusr
--	yuc_credat
--	yuc_upddat,
--	yuc_updprg

from SYMUSRCO
left join SYCOMINF on yco_cocde = yuc_cocde
where yuc_usrid = @usrid
order by yuc_flgdef desc, yuc_cocde
 





GO
GRANT EXECUTE ON [dbo].[sp_select_SYMUSRCO] TO [ERPUSER] AS [dbo]
GO
