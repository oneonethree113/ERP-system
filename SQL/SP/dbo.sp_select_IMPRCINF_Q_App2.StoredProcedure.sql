/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_Q_App2]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_IMPRCINF_Q_App2]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_IMPRCINF_Q_App2]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


------------------------------------------------- 
Create procedure [dbo].[sp_select_IMPRCINF_Q_App2]
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@imu_itmno nvarchar(20)                          
---------------------------------------------- 
 
AS
begin

SELECT 
imu_itmno,
ibi_itmsts, 
imu_typ, 
imu_ventyp,
imu_venno,
imu_prdven,

imu_pckunt,
imu_conftr, 
imu_inrqty, 
imu_mtrqty, 
imu_cft, 
imu_cus1no, 
imu_cus2no,
case isnull(pri.cbi_cussna,'') when '' then '' else pri.cbi_cussna end as pri_cussna, 
case isnull(sec.cbi_cussna,'') when '' then '' else sec.cbi_cussna end as sec_cussna, 
imu_ftyprctrm, 
imu_hkprctrm,
imu_trantrm, 

case isnull(ipi_qutdat, '') when '' then '' else convert(varchar(7), ipi_qutdat, 21) end as 'imu_period', --the format is yyyy-mm; imu_period is not used
--imu_period,
imu_effdat,
imu_expdat,
imu_status, 
imu_basprc,

---for specific ordering
case imu_cus1no when '1' then 'Z1'
				when '2' then 'Z2'
				when '3' then 'Z3'
				else imu_cus1no
				end as order_cus1no,
case imu_cus2no when '' then 'Z1'
				else imu_cus2no
				end as order_cus2no
				
from imprcinf
left join impckinf on
	imu_itmno = ipi_itmno  and
	imu_cus1no = ipi_cus1no and
	imu_cus2no = ipi_cus2no and
	imu_pckunt = ipi_pckunt and
	imu_conftr = ipi_conftr and 
	imu_inrqty = ipi_inrqty and 
	imu_mtrqty = ipi_mtrqty 
left join imbasinf on
	imu_itmno = ibi_itmno
left join cubasinf pri on
	imu_cus1no = pri.cbi_cusno
left join cubasinf sec on 
	imu_cus2no = sec.cbi_cusno
where 
	(ibi_itmsts like 'CMP' or ibi_itmsts like 'INC' or ibi_itmsts like 'TBC') AND
	imu_itmno = @imu_itmno
order by imu_pckunt, imu_inrqty, imu_mtrqty, imu_ftyprctrm,imu_hkprctrm,imu_trantrm, order_cus1no , order_cus2no
--order by order_cus1no

end

GO
GRANT EXECUTE ON [dbo].[sp_select_IMPRCINF_Q_App2] TO [ERPUSER] AS [dbo]
GO
