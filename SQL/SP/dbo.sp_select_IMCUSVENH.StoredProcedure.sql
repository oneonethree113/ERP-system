/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSVENH]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMCUSVENH]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMCUSVENH]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*  
=========================================================  
Program ID : sp_select_IMCUSVENH  
Description    : Select IM Custom Vendor  
Programmer   : Allan Yuen  
Create Date    : 27/05/2005  
Last Modified   :   
Table Read(s)  :  
Table Write(s)  :  
=========================================================  
 Modification History                                      
=========================================================  
Date  Author  Description  
=========================================================       
2005-09-10 Allan Yuen  Fix cater alias item problem  
*/  
  
  
-------------------------------------------------   
CREATE procedure [dbo].[sp_select_IMCUSVENH]  
                                                                                                                                                                                                                                                               

@ibi_cocde nvarchar(6) ,  
@ibi_itmno nvarchar(20)   
                                                 
----------------------------------------------   
--sp_select_IMCUSVENH 'ucpp','04a692-058801'  
--select * from imbasinf where ibi_itmno = '04a692-058801'  
  
AS  
begin  
  
DECLARE @ventyp as char(1)  
DECLARE @Tmp_venno  as varchar(6)  
DECLARE @Tmp_vensna  as nvarchar(200)  
  
set @Tmp_venno  = ''  
set @Tmp_vensna  = ''  
set @ventyp  = ''  
  
  
select   
 @ventyp  = isnull(vbi_ventyp,'') ,  
 @tmp_venno = isnull(ibi_venno,'') ,  
 @tmp_vensna = isnull(vbi_vensna,'')  
from   
 IMBASINFH    
 left join vnbasinf  on vbi_venno = ibi_venno  
where  
 ibi_alsitmno = @ibi_itmno  
  
  
if ltrim(rtrim(@tmp_venno)) = ''   
begin  
select   
 @ventyp  = vbi_ventyp ,  
 @tmp_venno = ibi_venno ,  
 @tmp_vensna = vbi_vensna  
from   
 IMBASINFH    
 left join vnbasinf  on vbi_venno = ibi_venno  
where  
 ibi_itmno = @ibi_itmno  
end  
  
--------------------------------------------  
  
if @ventyp  = 'I' OR @ventyp  = 'J'   
BEGIN  
 Select   
  vbi_venno,  
  isnull(vbi_vensna,' ') as 'vbi_cusvensna',  
  @tmp_venno as 'default_venno',  
  @tmp_vensna as 'default_vensna'  
 from   
  VNBASINF   
 where  
--  vbi_ventyp in ('I','J') AND VBI_VENNO NOT IN ('0005','0006','0007','0008','0009')  
(
	  vbi_ventyp in ('I','J') AND VBI_VENNO NOT IN ('0005','0006','0007','0008','0009')  
)
or
(
	vbi_ventyp not in ('I','J') and vbi_venno in (select ibi_venno from imbasinf where ibi_itmno = @ibi_itmno)
)
 order by   
  vbi_venno  
END  
ELSE  
BEGIN  
 Select   
  vbi_venno,  
  isnull(vbi_vensna,' ') as 'vbi_cusvensna',  
  @tmp_venno as 'defailt_venno',  
  @tmp_vensna as 'default_vensna'  
 from   
  VNBASINF   
 where  
  vbi_ventyp = 'E'  
 order by   
  vbi_venno  
END  
  
  
  
end  
  




GO
GRANT EXECUTE ON [dbo].[sp_select_IMCUSVENH] TO [ERPUSER] AS [dbo]
GO
