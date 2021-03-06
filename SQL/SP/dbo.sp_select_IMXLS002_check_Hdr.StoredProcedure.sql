/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS002_check_Hdr]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMXLS002_check_Hdr]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMXLS002_check_Hdr]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- sp_select_IMXLS002_check_Hdr 'UCPP'

--SELECT * FROM imextitm


CREATE  Procedure [dbo].[sp_select_IMXLS002_check_Hdr]
@cocde varchar(6)
as
BEGIN

create table #tmp_Check(
	_name	varchar(20),
	_pos	char(7),
	_desc	nvarchar(100),
	_type	char(1)		--S : Simplify Chinese		T : Tranditional Chinese
)


insert into #tmp_Check values ('tmp_VenNo','A-2@A-2',N'工廠名稱','T')
--insert into #tmp_Check values ('tmp_DateTime','I-2@I-2','日期','T')
insert into #tmp_Check values ('tmp_VenItm','A-4@A-4',N'貴廠貨號','T')
insert into #tmp_Check values ('tmp_ItmNo','B-4@B-4',N'華源產品編號','T')
insert into #tmp_Check values ('tmp_VenCol','C-4@C-4',N'貴廠貨號顏色編號','T')
insert into #tmp_Check values ('tmp_ItmDesc','D-4@D-4',N'材質/品名','T')
insert into #tmp_Check values ('tmp_UM','I-4@I-4',N'單位','T')
insert into #tmp_Check values ('tmp_InnerL','M-4@M-4',N'內盒尺寸','T')
insert into #tmp_Check values ('tmp_MasterL','P-4@P-4',N'外箱尺寸','T')
insert into #tmp_Check values ('tmp_MasterW','S-4@S-4',N'外箱','T')
insert into #tmp_Check values ('tmp_CurrCst','T-4@T-4',N'FOR HK散貨價或C&F HK散貨價','T')
insert into #tmp_Check values ('tmp_MOQUM','X-4@X-4',N'每款','T')


insert into #tmp_Check values ('tmp_VenNo','A-2@A-2',N'厂名','S')
--insert into #tmp_Check values ('tmp_DateTime','I-2@I-2','日期','S')
insert into #tmp_Check values ('tmp_VenItm','A-4@A-4',N'工厂货号','S')
insert into #tmp_Check values ('tmp_ItmNo','B-4@B-4',N'华源产品编号','S')
insert into #tmp_Check values ('tmp_VenCol','C-4@C-4',N'工厂货号颜色编号','S')
insert into #tmp_Check values ('tmp_ItmDesc','D-4@D-4',N'材质/品名','S')
insert into #tmp_Check values ('tmp_UM','I-4@I-4',N'单位','S')
insert into #tmp_Check values ('tmp_InnerL','M-4@M-4',N'内盒尺寸','S')
insert into #tmp_Check values ('tmp_MasterL','P-4@P-4',N'外箱尺寸','S')
insert into #tmp_Check values ('tmp_MasterW','S-4@S-4',N'外箱','S')
insert into #tmp_Check values ('tmp_CurrCst','T-4@T-4',N'FOR HK散货价或C&F HK散货价','S')
insert into #tmp_Check values ('tmp_MOQUM','X-4@X-4',N'每款','S')


select * from #tmp_Check

drop table #tmp_Check




END





GO
GRANT EXECUTE ON [dbo].[sp_select_IMXLS002_check_Hdr] TO [ERPUSER] AS [dbo]
GO
