/****** Object:  StoredProcedure [dbo].[sp_select_ZSITMDAT_DTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_ZSITMDAT_DTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_ZSITMDAT_DTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
=========================================================
Program ID	: sp_select_ZSITMDAT_DTL
Description   	: 
Programmer  	: 
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      		Initial  	Description                          
=========================================================    
*/


--exec sp_general '㊣ZSITMDAT_DTL※S※UCPP※33Y033W※1※H050900064', '', '', '', ''

--sp_select_zsitmdat_dtl 'UCPP','33Y033W',1,'H050900064'

CREATE PROCEDURE [dbo].[sp_select_ZSITMDAT_DTL] 
@zid_cocde 	nvarchar(6),
@zid_itmno	varchar(20),
@zid_seqno	INT,
@zid_mpono	varchar(20),
@Zid_Credat	datetime

AS


select 
	'UM' as 'Field Name', 
	Zil_UM as 'Before' , Zid_UM as 'After' 
from 
	ZSITMLST 
	left join ZSITMDAT on Zid_Itmno = Zil_Itmno
where
	Zid_itmno = @zid_itmno and
	Zid_Seqno =  @zid_seqno and
	Zid_MPONO = @zid_mpono and
	convert(varchar(19),zid_credat,121) = convert(varchar(19),@zid_credat,121)

union all

select 
	'CUR' as 'Field Name', 
	Zil_Cur as 'Before' , Zid_Curr as 'After' 
from 
	ZSITMLST 
	left join ZSITMDAT on Zid_Itmno = Zil_Itmno
where
	Zid_itmno = @zid_itmno and
	Zid_Seqno =  @zid_seqno and
	Zid_MPONO = @zid_mpono and
	convert(varchar(19),zid_credat,121) = convert(varchar(19),@zid_credat,121)


union all

select 
	'Unit Price' as 'Field Name', 
	CONVERT(VARCHAR(20), Zil_Prc)  as 'Before' , CONVERT(VARCHAR(20), Zid_UnitPrc)  as 'After' 
from 
	ZSITMLST 
	left join ZSITMDAT on Zid_Itmno = Zil_Itmno
where
	Zid_itmno = @zid_itmno and
	Zid_Seqno =  convert(int,@zid_seqno) and
	Zid_MPONO = @zid_mpono and
	convert(varchar(19),zid_credat,121) = convert(varchar(19),@zid_credat,121)






GO
GRANT EXECUTE ON [dbo].[sp_select_ZSITMDAT_DTL] TO [ERPUSER] AS [dbo]
GO
