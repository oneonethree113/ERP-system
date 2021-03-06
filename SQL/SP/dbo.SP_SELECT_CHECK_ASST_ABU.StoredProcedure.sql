/****** Object:  StoredProcedure [dbo].[SP_SELECT_CHECK_ASST_ABU]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[SP_SELECT_CHECK_ASST_ABU]
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_CHECK_ASST_ABU]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


/*
Project : Assortment UM
It aims to check the assortment's Vendor where is A, B or U

*/

CREATE  PROCEDURE [dbo].[SP_SELECT_CHECK_ASST_ABU]
@COCDE NVARCHAR(6),
@ITMNO NVARCHAR(20)
AS


BEGIN
	select 
	isnull(ibi_itmno,'') as 'ibi_itmno',
	isnull(ibi_typ,'') as 'ibi_typ' ,
	isnull(imu_venno,'') as 'imu_venno', 
	isnull(imu_prdven,'') as 'imu_prdven'
	 from imbasinf 
	left join immrkup on imu_itmno = ibi_itmno and imu_ventyp = 'D' and imu_pckseq = 1
	where ibi_typ = 'ASS' and ibi_itmno = @ITMNO and
	imu_venno in ('A','B','U')
	
END


GO
GRANT EXECUTE ON [dbo].[SP_SELECT_CHECK_ASST_ABU] TO [ERPUSER] AS [dbo]
GO
