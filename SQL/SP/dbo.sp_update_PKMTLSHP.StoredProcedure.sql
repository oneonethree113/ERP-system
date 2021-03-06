/****** Object:  StoredProcedure [dbo].[sp_update_PKMTLSHP]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_PKMTLSHP]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_PKMTLSHP]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[sp_update_PKMTLSHP]
                                                                                                                                                                                                                                                                 
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

	 
update PKMTLSHP
set 
pms_shpstrdat = @shpstrdat,
pms_shpenddat = @shpenddat,
pms_shpqty = @shpqty,
pms_um = @um,
pms_fty = @fty,

pms_address = @address ,
pms_state = @state ,
pms_cntry = @cntry ,
pms_zip = @zip ,
pms_cntper = @cntper ,
pms_tel = @tel ,

pms_remark = @remark ,
pms_updusr = @user,
pms_upddat = getdate()
where pms_ordno = @ordno
and pms_ordseq = @ordseq 
and pms_shpseq = @shpseq



end








GO
GRANT EXECUTE ON [dbo].[sp_update_PKMTLSHP] TO [ERPUSER] AS [dbo]
GO
