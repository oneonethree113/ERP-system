/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS002_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMXLS002_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS002_check]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE  Procedure [dbo].[sp_select_IMXLS002_check]
@cocde varchar(6)
as
BEGIN

create table #tmp_Check(
	_name	varchar(20),
	_pos	char(7),
	_desc	varchar(100)
)


insert into #tmp_Check values ('tmp_VenNo','C-2@D-2','Vendor No')
insert into #tmp_Check values ('tmp_VenNam','C-2@D-2','Vendor Name')
insert into #tmp_Check values ('tmp_DateTime','K-2@N-2','File Date')
insert into #tmp_Check values ('tmp_VenItm','A-#@A-#','Vendor Item No')
insert into #tmp_Check values ('tmp_ItmNo','B-#@B-#','Our Item No')
insert into #tmp_Check values ('tmp_VenCol','C-#@C-#','Vendor Color')
insert into #tmp_Check values ('tmp_OurCol','B-#@B-#','Our Color')
insert into #tmp_Check values ('tmp_ItmDesc','D-#@D-#','Item Description')
insert into #tmp_Check values ('tmp_UM','I-#@I-#','Unit of Measure')
insert into #tmp_Check values ('tmp_Inner','J-#@J-#','Inner')
insert into #tmp_Check values ('tmp_Middle','K-#@K-#','Middle')
insert into #tmp_Check values ('tmp_Master','L-#@L-#','Master')
insert into #tmp_Check values ('tmp_InnerL','M-#@M-#','Inner (Length)')
insert into #tmp_Check values ('tmp_InnerW','N-#@N-#','Inner (Width)')
insert into #tmp_Check values ('tmp_InnerH','O-#@O-#','Inner (Height)')
insert into #tmp_Check values ('tmp_MasterL','P-#@P-#','Master (Length)')
insert into #tmp_Check values ('tmp_MasterW','Q-#@Q-#','Master (Width)')
insert into #tmp_Check values ('tmp_MasterH','R-#@R-#','Master (Height)')
insert into #tmp_Check values ('tmp_CFT','S-#@S-#','CFT')
--insert into #tmp_Check values ('tmp_CBM','T#,T#','CBM')
insert into #tmp_Check values ('tmp_CurrCst','T-#@T-#','Currency (Item Cost)')
insert into #tmp_Check values ('tmp_ItmCst','U-#@U-#','Item Cost')
insert into #tmp_Check values ('tmp_MOQUM','X-#@X-#','Unit of Measure (MOQ)')
insert into #tmp_Check values ('tmp_MOQ','Y-#@Y-#','MOQ')

select * from #tmp_Check

drop table #tmp_Check




END




GO
GRANT EXECUTE ON [dbo].[sp_select_IMXLS002_check] TO [ERPUSER] AS [dbo]
GO
