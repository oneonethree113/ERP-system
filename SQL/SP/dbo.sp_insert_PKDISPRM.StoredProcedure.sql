/****** Object:  StoredProcedure [dbo].[sp_insert_PKDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKDISPRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKDISPRM]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



CREATE  procedure [dbo].[sp_insert_PKDISPRM]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20),
@type nvarchar(15),
@seq int,
@cde nvarchar(20),
@dsc nvarchar(200),
@pctamt nvarchar(10),
@pct numeric(6,3),
@amt numeric(11,4),
@user nvarchar(30)



---------------------------------------------- 

 
AS
 

begin


declare @maxseq as int

select @maxseq = count(*) + 1 from PKDISPRM (nolock)
where pdp_cocde = @code  and pdp_ordno = @ordno

 
insert into PKDISPRM 

Values

(@code,
@ordno ,
@type ,
@maxseq ,
@cde ,
@dsc ,
@pctamt ,
@pct ,
@amt ,
@user ,
@user,
getdate(),
getdate(),
null)

end


 
 


GO
GRANT EXECUTE ON [dbo].[sp_insert_PKDISPRM] TO [ERPUSER] AS [dbo]
GO
