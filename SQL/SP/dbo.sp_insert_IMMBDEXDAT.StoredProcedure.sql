/****** Object:  StoredProcedure [dbo].[sp_insert_IMMBDEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_IMMBDEXDAT]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_IMMBDEXDAT]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/* 
=========================================================  
Program ID : sp_insert_IMMBDEXDAT
Description    :	   
ALTER  Date    :  
=========================================================
 Modification History                                    
=========================================================
2012-07-23	David Yue	Add User ID
========================================================= 
*/  
  
CREATE procedure [dbo].[sp_insert_IMMBDEXDAT]  
                                                                                                                                                                                                                                                                   
@ikd_cocde	nvarchar(6), 	@ikd_ucpno	nvarchar(20), 	@ikd_matdsc	nvarchar(200),  
@ikd_cstper	numeric(13,4), 	@ikd_cstccy	nvarchar(6),	@ikd_cstamt	numeric(13,4),
@ikd_wgtper	numeric(13,4),	@ikd_xlsfil  	nvarchar(50), 	@ikd_chkdat 	datetime,
@creusr		nvarchar(30)		

AS  
--select * from sysetinf where ysi_typ = '25'

declare  	@ikd_recseq int, 		@ikd_stage nvarchar(3), 		@ikd_sysmsg nvarchar(300), 
		@ikd_matcde nvarchar(6), 	@ikd_venno nvarchar(20), 		@ikd_prdven nvarchar(20) 	
 
Set @ikd_recseq = (Select isnull(max(ikd_recseq),0)  + 1 from IMMBDEXDAT)  
Set @ikd_sysmsg = ''  
Set @ikd_stage = 'W'  
set @ikd_cocde = ''
set @ikd_matcde = '' 

Update	IMMBDEXDAT 
Set 	ikd_stage = 'O'
Where	ikd_ucpno = @ikd_ucpno and
	(ikd_xlsfil <> @ikd_xlsfil or ikd_chkdat <> @ikd_chkdat)

UPDATE	IMMBDEXDAT 
set	ikd_stage = 'O'  
where  	ikd_ucpno = @ikd_ucpno and   
	ikd_matdsc = ltrim(rtrim(@ikd_matdsc)) and
	(ikd_stage = 'W' or ikd_stage = 'I')  


if (select count(*) from imitmexdat 
	where ied_ucpno = @ikd_ucpno and ied_xlsfil = @ikd_xlsfil and ied_chkdat = @ikd_chkdat and ied_stage = 'W') = 1 
begin
	select @ikd_venno = ied_venno, @ikd_prdven = ied_prdven 
	from imitmexdat
	where
	ied_ucpno = @ikd_ucpno and
	ied_xlsfil = @ikd_xlsfil and
	ied_chkdat = @ikd_chkdat and
	ied_stage = 'W'
end
else
begin
	select top 1 @ikd_venno = ied_venno, @ikd_prdven = ied_prdven 
	from imitmexdat
	where
	ied_ucpno = @ikd_ucpno and
	ied_xlsfil = @ikd_xlsfil and
	ied_chkdat = @ikd_chkdat
end


insert into  IMMBDEXDAT  
(   
	ikd_cocde,	ikd_venno,	ikd_prdven,
	ikd_ucpno,	ikd_recseq,	ikd_matdsc,
	ikd_curcde,	ikd_cst,		ikd_cstper,
	ikd_wgtper,	ikd_stage,	ikd_sysmsg,
	ikd_xlsfil,	ikd_chkdat,	ikd_creusr,
	ikd_updusr,	ikd_credat,	ikd_upddat
)  
values  
(  
	@ikd_cocde,	@ikd_venno,	@ikd_prdven,
	@ikd_ucpno,	@ikd_recseq,	@ikd_matdsc,
	@ikd_cstccy,	@ikd_cstamt,	@ikd_cstper,	
	@ikd_wgtper,	@ikd_stage,	@ikd_sysmsg,
	@ikd_xlsfil,	@ikd_chkdat, 	@creusr,     
	 @creusr,   	getdate(),   	getdate()
)        


---------------------------------------------------------------------------------------------------------------------------------------------------------------------






GO
GRANT EXECUTE ON [dbo].[sp_insert_IMMBDEXDAT] TO [ERPUSER] AS [dbo]
GO
