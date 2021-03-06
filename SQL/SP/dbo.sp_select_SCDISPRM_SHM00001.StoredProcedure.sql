/****** Object:  StoredProcedure [dbo].[sp_select_SCDISPRM_SHM00001]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SCDISPRM_SHM00001]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SCDISPRM_SHM00001]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









------------------------------------------------- 
CREATE   procedure [dbo].[sp_select_SCDISPRM_SHM00001]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@sdp_cocde nvarchar(6) ,
@sdp_ordno_list nvarchar(3000),
@sdp_type nvarchar(1)                                     
---------------------------------------------- 
 
AS
begin


declare   @delimiter CHAR(1) 
set  @delimiter =','

create table #tempoutput
(
splitdata nvarchar(30)
)



    DECLARE @start INT, @end INT 

    SELECT @start = 1, @end = CHARINDEX(@delimiter, @sdp_ordno_list) 
    WHILE @start < LEN(@sdp_ordno_list) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@sdp_ordno_list) + 1
       
        INSERT INTO #tempoutput (splitdata)  
        VALUES(SUBSTRING(@sdp_ordno_list, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @sdp_ordno_list, @start)
        
      END



Select 
' ' as 'sdp_status',
sdp_cocde,
sdp_ordno,
sdp_type,
sdp_seqno,
sdp_cde,
sdp_dsc,
sdp_pctamt,
sdp_pct,
sdp_amt,
sdp_creusr,
sdp_updusr,
sdp_credat,
sdp_upddat,
cast(sdp_timstp as int) as sdp_timstp
--------------------------------- 
from SCDISPRM
where                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
sdp_cocde = @sdp_cocde and
sdp_ordno in  (select splitdata from #tempoutput)  and
sdp_type = @sdp_type
---------------------------------------------------------- 
end










GO
GRANT EXECUTE ON [dbo].[sp_select_SCDISPRM_SHM00001] TO [ERPUSER] AS [dbo]
GO
