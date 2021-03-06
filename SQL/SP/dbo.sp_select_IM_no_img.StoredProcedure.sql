/****** Object:  StoredProcedure [dbo].[sp_select_IM_no_img]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IM_no_img]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IM_no_img]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO





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
17 July 2003	Allan Yuen		For Merge Porject
*/


CREATE PROCEDURE [dbo].[sp_select_IM_no_img] 

@cocde	nvarchar(6),
@datefr 	char(10),
@dateto	char(10),
@no_img	char(1)

AS

if upper(@no_img)='Y' 
begin
	/* UCPP: IM w/o picture filtering */
	select 
		ibi_cocde, 	ibi_itmno, 	ibi_lnecde, 
		ibi_curcde, 	ibi_catlvl4, 	ibi_itmsts, 
		ibi_typ, 	ibi_engdsc, 	ibi_chndsc, 
		ibi_venno, 	vbi_vensna, 	convert(char(10),ibi_credat,111) 
	from 
		imbasinf 
	left outer join vnbasinf on 
		--ibi_cocde=vbi_cocde and 
		ibi_venno=vbi_venno
	where  
		ibi_imgpth=' '  
		--and  ibi_cocde=@cocde
		
		and convert(char(10),ibi_credat,111)>=@datefr 
		and convert(char(10),ibi_credat,111)<=@dateto
	order by 
		ibi_credat  desc

	/* ----------	Count # of item missing picture */
	select 
		count(*) 
	from 
		imbasinf 
	where 
		--ibi_cocde=@cocde and
	 	ibi_imgpth=' '  
	 	and convert(char(10),ibi_credat,111)>=@datefr 
		and convert(char(10),ibi_credat,111)<=@dateto
end
else 
begin

	/* ----------	Count # of item missing picture */
	select 
		count(*) 
	from 
		imbasinf 
	where 
		--ibi_cocde=@cocde and
	 	convert(char(10),ibi_credat,111)>=@datefr 
		and convert(char(10),ibi_credat,111)<=@dateto
end





GO
GRANT EXECUTE ON [dbo].[sp_select_IM_no_img] TO [ERPUSER] AS [dbo]
GO
