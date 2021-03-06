/****** Object:  StoredProcedure [dbo].[sp_list_FYPRTFYO]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_list_FYPRTFYO]
GO
/****** Object:  StoredProcedure [dbo].[sp_list_FYPRTFYO]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




-- Checked by Allan Yuen at 28/07/2003

CREATE PROCEDURE [dbo].[sp_list_FYPRTFYO] 

@fpf_cocde nvarchar(6),
@fpf_ftycde nvarchar(10)

AS

BEGIN

Declare @count as int

SELECT  
	@count= left(right(max(ltrim(rtrim(fpf_filnam))),6),2) + 1
FROM             FYPRTFYO
where  
	convert(varchar(10),fpf_credat,111) = convert(varchar(10),getdate(),111)  and
	fpf_ftycde = @fpf_ftycde
group by 
	convert(varchar(10),fpf_credat,111) 

set @count = isnull(@count,1)

select 	@fpf_ftycde +
	case len(month(getdate())) when 1 then '0' + ltrim(str(month(getdate())))  else ltrim(str(month(getdate()))) end + 
	case len(day(getdate())) when 1 then '0' + ltrim(str(day(getdate())))  else ltrim(str(day(getdate()))) end +
	case len(@count) when 1 then '0' +  ltrim(str(@count)) else ltrim(str(@count)) end +
	'.doc' as  'SEQ'





END


GO
GRANT EXECUTE ON [dbo].[sp_list_FYPRTFYO] TO [ERPUSER] AS [dbo]
GO
