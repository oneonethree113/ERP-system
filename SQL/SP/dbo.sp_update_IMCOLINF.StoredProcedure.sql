/****** Object:  StoredProcedure [dbo].[sp_update_IMCOLINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_IMCOLINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_IMCOLINF]    Script Date: 09/29/2017 11:53:54 ******/
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
Last Modified  	: 17 July 2003
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
=========================================================     
17 July 2003	Allan Yuen		For Merge Porject, disable company code
15 Sep 2005	Lester Wu		Trim Vendor ITem #, Color Code and Vendor Color Code
*/

/************************************************************************
Author:		Kenny Chan
Date:		14th September, 2001
************************************************************************/
------------------------------------------------- 
CREATE procedure [dbo].[sp_update_IMCOLINF]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@icf_cocde 	nvarchar(6),
@icf_itmno  	nvarchar(20),
--@icf_colcde	nvarchar(30),
@icf_colcde	varchar(30),
@icf_colseq	int,
--@icf_vencol	nvarchar(30),
@icf_vencol	varchar(30),
@icf_coldsc	nvarchar(200),
@icf_typ	nvarchar(4),
@icf_ucpcde	nvarchar(12),
@icf_eancde	nvarchar(12),
@icf_asscol	char(1),
@icf_swatchpath	varchar(200),
@icf_imgpath	varchar(200),
--@icf_venno	varchar(6),
@icf_lnecde	varchar(10),
@icf_updusr	nvarchar(30)
                                    
------------------------------------ 
AS
 
update IMCOLINF
SET
--icf_colcde=@icf_colcde,
--15 Sep 2005	Lester Wu		Trim Vendor ITem #, Color Code and Vendor Color Code
--icf_colcde=REPLACE(REPLACE(@icf_colcde,CHAR(10),''),CHAR(13),'') ,
--icf_vencol=REPLACE(REPLACE(@icf_vencol,CHAR(10),''),CHAR(13),'') ,
icf_colcde=LTRIM(RTRIM(REPLACE(REPLACE(@icf_colcde,CHAR(10),''),CHAR(13),''))) ,
icf_vencol=LTRIM(RTRIM(REPLACE(REPLACE(@icf_vencol,CHAR(10),''),CHAR(13),''))) ,
--icf_vencol=@icf_vencol,
icf_coldsc=@icf_coldsc,
icf_typ=@icf_typ,
icf_ucpcde=@icf_ucpcde,
icf_eancde=@icf_eancde,
icf_updusr=@icf_updusr,
icf_upddat = getdate(),
icf_asscol = LTRIM(RTRIM(REPLACE(REPLACE(@icf_asscol,CHAR(10),''),CHAR(13),''))),
icf_swatchpath = @icf_swatchpath,
icf_imgpath = @icf_imgpath,
--icf_venno = @icf_venno,
icf_lnecde = @icf_lnecde
where 
--icf_cocde = @icf_cocde and
icf_itmno = @icf_itmno and 
icf_colseq = @icf_colseq
---------------------------------------------------------------------------------------------------------------------------------------------------------------------









GO
GRANT EXECUTE ON [dbo].[sp_update_IMCOLINF] TO [ERPUSER] AS [dbo]
GO
