/****** Object:  StoredProcedure [dbo].[sp_insert_PKMTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_insert_PKMTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_PKMTLSHP]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  procedure [dbo].[sp_insert_PKMTLSHP]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@ordno nvarchar(20),
@ordseq int , 
@shpseq int, 
@shpstrdat datetime,
@shpenddat datetime,
@shpqty int , 
@um nvarchar(20),
@fty nvarchar(50),

@address nvarchar(300),
@state nvarchar(50),
@cntry nvarchar(50),
@zip nvarchar(50),
@cntper nvarchar(30),
@tel nvarchar(20),

@remark nvarchar(300),
@user nvarchar(30)



---------------------------------------------- 

 
AS
 

begin

	 
insert into PKMTLSHP
values
(
@code,
@ordno,
@ordseq,
@shpseq,
@shpstrdat,
@shpenddat,
@shpqty,
@um,
@fty,
@remark,
@user,
@user,
getdate(),
getdate(),
null,
@address,
@state,
@cntry,
@zip,
@tel,
@cntper




)

end





GO
GRANT EXECUTE ON [dbo].[sp_insert_PKMTLSHP] TO [ERPUSER] AS [dbo]
GO
