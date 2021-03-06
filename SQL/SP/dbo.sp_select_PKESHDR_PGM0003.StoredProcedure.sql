/****** Object:  StoredProcedure [dbo].[sp_select_PKESHDR_PGM0003]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_PKESHDR_PGM0003]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_PKESHDR_PGM0003]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO















CREATE  procedure [dbo].[sp_select_PKESHDR_PGM0003]
                                                                                                                                                                                                                                                                 
@code nvarchar(10),
@From nvarchar(20) , 
@To nvarchar(20)


---------------------------------------------- 

 
AS
 

begin

declare @estcount table
(
est_cocde	nvarchar(10),
est_reqno	nvarchar(20),
est_itemno	nvarchar(30),
est_count	int
)


insert into @estcount
select ped_cocde, ped_reqno,ped_itemno, count(*) from PKESDTL (nolock),
PKIMBAIF (nolock)
where ped_cocde = @code and ped_reqno between @From and @To
and ped_pkgitem = pib_pgitmno and pib_estflg = 'Y'
group by ped_cocde, ped_reqno,ped_itemno

select peh_reqno,peh_price,peh_itemno,isnull(est_count,0) 'est_count'
from PKESHDR (nolock)
left join @estcount on est_cocde = peh_cocde and est_reqno = peh_reqno and peh_itemno = est_itemno
where peh_cocde = @code and peh_reqno between @From and @To


end


 
 







GO
GRANT EXECUTE ON [dbo].[sp_select_PKESHDR_PGM0003] TO [ERPUSER] AS [dbo]
GO
