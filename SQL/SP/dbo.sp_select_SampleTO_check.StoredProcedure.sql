/****** Object:  StoredProcedure [dbo].[sp_select_SampleTO_check]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_select_SampleTO_check]
GO
/****** Object:  StoredProcedure [dbo].[sp_select_SampleTO_check]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO









/*=========================================================
Program ID	: 	sp_select_SampleTO_check
Description   	: 
Programmer  	: 	Carlos Lui
ALTER  Date   	: 	2013-05-14
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
Date		Author		Description

=========================================================
*/
--sp_select_SampleTO_check 'UCPP','UQ1300614'

CREATE    PROCEDURE [dbo].[sp_select_SampleTO_check] 

@cocde	nvarchar(6),
@qutno	nvarchar(20)

AS

declare @checkflag_sample as char(1)
declare @checkflag_to as char(1)

set @checkflag_sample = 'N'

if (select count(*) from QUOTNHDR (nolock) 
left join SAREQDTL (nolock) on srd_cocde = quh_cocde and srd_qutno = quh_qutno
where quh_cocde = @cocde and quh_qutno = @qutno and srd_credat > quh_credat) >= 1
begin
	set @checkflag_sample = 'Y'
end


set @checkflag_to = 'N'

if (select count(*) from QUOTNHDR (nolock) 
left join TOORDDTL (nolock) on tod_cocde = quh_cocde and tod_qutno = quh_qutno
where quh_cocde = @cocde and quh_qutno = @qutno and tod_credat > quh_credat) >= 1
begin
	set @checkflag_to = 'Y'
end



select @checkflag_sample 'checkflag_sample', @checkflag_to 'checkflag_to'










GO
GRANT EXECUTE ON [dbo].[sp_select_SampleTO_check] TO [ERPUSER] AS [dbo]
GO
