/****** Object:  StoredProcedure [dbo].[sp_select_QUXLSDTL]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_QUXLSDTL]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_QUXLSDTL]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO











-- 20130709

CREATE                                      PROCEDURE [dbo].[sp_select_QUXLSDTL] 

@txtyp 			nvarchar(30),     --upd/new 

@qxd_xlsfil		nvarchar(50),     --for query QUXLSDTL
@qxd_fildat		nvarchar(30),     --for query QUXLSDTL
@qxd_cocde		nvarchar(10),
@qxd_qutno		nvarchar(20),

@qxd_qutseq int,		-- excel row# / grip row # ;  not seq# in  QUOTNDTL
@tmp_itmno nvarchar(30),	-- @tmp_dsc nvarchar(300), for demo

@tmp_colcde nvarchar(30),

@tmp_pckunt nvarchar(10),
@tmp_inrqty int,
@tmp_mtrqty int,

@tmp_hkprctrm nvarchar(30),
@tmp_trantrm nvarchar(30),
@tmp_cus1no nvarchar(30),
@tmp_cus2no nvarchar(30),

@tmp_CusAgt nvarchar(30),
@tmp_SalDiv nvarchar(30),
@tmp_SalRep nvarchar(30),
@tmp_Srname nvarchar(30),
@tmp_SmpPrd nvarchar(30),
@tmp_SmpFgt nvarchar(30),
@tmp_Curcde nvarchar(30),
@tmp_PrcTrm nvarchar(30),
@tmp_PayTrm nvarchar(30),

@tmp_Cus1Ad nvarchar(90), 
@tmp_Cus1St nvarchar(90), 
@tmp_Cus1Cy nvarchar(30), 
@tmp_Cus1Zp nvarchar(30), 

@tmp_Cus1Cp nvarchar(30),

@tmp_Cus1CgInt nvarchar(30),
@tmp_Cus1CgExt nvarchar(30),


@tmp_case nvarchar(30)

AS

Select
*
from QUXLSDTL
where qxd_xlsfil = @qxd_xlsfil 
and  qxd_fildat = @qxd_fildat
--and  (qxd_qutno=@qxd_qutno  or qxd_qutno='' or qxd_qutno is null)
and  qxd_cocde=@qxd_cocde
and  qxd_itmno =@tmp_itmno 
---and  qxd_vencolcde= @tmp_colcde                     -- recheck
--and  ( ( qxd_um=@tmp_pckunt			 
--and qxd_inr =@tmp_inrqty
--and  qxd_mtr =@tmp_mtrqty)
--	 OR 
--	(@tmp_pckunt='ST')
--)
		and ( 
			(qxd_um = @tmp_pckunt and qxd_inr =@tmp_inrqty	and   qxd_mtr =@tmp_mtrqty)
			OR
			(  
			      left(qxd_orgum,2)='ST'
			    and qxd_um='PC'
			    and cast(right(qxd_orgum,(len(qxd_orgum)-2)) as int)*@tmp_inrqty =qxd_inr	
			    and cast(right(qxd_orgum,(len(qxd_orgum)-2)) as int)*@tmp_mtrqty =qxd_mtr	
			)
		          )
and  Left(qxd_prctrm,3)=Left(@tmp_hkprctrm,3)
and  qxd_trantrm=@tmp_trantrm







 
 










































GO
GRANT EXECUTE ON [dbo].[sp_select_QUXLSDTL] TO [ERPUSER] AS [dbo]
GO
