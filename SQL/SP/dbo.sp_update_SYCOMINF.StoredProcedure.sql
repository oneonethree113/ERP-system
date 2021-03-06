/****** Object:  StoredProcedure [dbo].[sp_update_SYCOMINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SYCOMINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SYCOMINF]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO




/*=========================================================
 Modification History                                    
=========================================================
Date		Author		Description
5 Jun 2003		Lewis		Add company Name and company short name       
4th March 2005		Lester Wu	Add chinese company name, short name, address, fax no, phone no and logo path
=========================================================     
*/

CREATE  procedure [dbo].[sp_update_SYCOMINF]

                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
@run_cocde	nvarchar(6), 	-- add for skip co code gen by sp_general
@yco_cocde	nvarchar(6), 
@yco_addr		nvarchar(200),
@yco_mfystr	int,
@yco_curyer	int,
@yco_systim	int,
@yco_irday	int,
@yco_ir2day	int,
@yco_moq	int,
@yco_curcde	nvarchar(4),
@yco_moa	numeric(11,4),
@yco_bscrat	int,
@yco_datfmt	nvarchar(20),
@yco_ivmth	nvarchar(10),
@yco_commth	nvarchar(1),
@yco_prctle	numeric(6,3),
@yco_expday	int,
@yco_datrme1	nvarchar(5),
@yco_datrme2	nvarchar(5),
@yco_datrme3	nvarchar(5),
@yco_datrme4	nvarchar(5),
@yco_year	int,
@yco_acinv	nvarchar(15),
@yco_acsam	nvarchar(15),
@yco_acinvadj	nvarchar(15),
@yco_acsamtrm	nvarchar(15),
@yco_updusr	nvarchar(30),
@yco_conam	nvarchar(100), 	-- Add by Lewis on 5 Jun 2003
@yco_shtnam	nvarchar(25),	-- Add by Lewis on 5 Jun 2003
--2005/03/03 Lester Wu -- Add Chinese Company Name,Chinese  Short Name,Chinese  Address , phone no , fax no , email address
@yco_conamc	nvarchar(50),
@yco_shtnamc	nvarchar(25),
@yco_addrc	nvarchar(200),
@yco_phoneno	varchar(50),
@yco_faxno	varchar(50),
@yco_logoimgpth	varchar(100),
@dummy		varchar(1)
-----------------------
AS


begin
update sycominf
set 
yco_cocde=@yco_cocde,
yco_addr=@yco_addr,
yco_conam=@yco_conam,	-- Add by Lewis on 5 Jun 2003
yco_shtnam=@yco_shtnam,	-- Add by Lewis on 5 Jun 2003
yco_mfystr=@yco_mfystr,
yco_curyer=@yco_curyer,
yco_systim=@yco_systim,
yco_irday=@yco_irday,
yco_ir2day=@yco_ir2day,
yco_moq=@yco_moq,
yco_curcde=@yco_curcde,
yco_moa=@yco_moa,
yco_bscrat=@yco_bscrat,
yco_datfmt=@yco_datfmt,
yco_ivmth=@yco_ivmth,
yco_commth=@yco_commth,
yco_prctle=@yco_prctle,
yco_expday=@yco_expday,
yco_datrme1=@yco_datrme1,
yco_datrme2=@yco_datrme2,
yco_datrme3=@yco_datrme3,
yco_datrme4=@yco_datrme4,
yco_year=@yco_year,
yco_acinv = @yco_acinv,
yco_acsam = @yco_acsam,
yco_acinvadj = @yco_acinvadj,
yco_acsamtrm = @yco_acsamtrm,
yco_updusr = @yco_updusr,
yco_upddat=getdate(),
--Lester Wu 2005/03/03 -- Update Chinese Company Name, Chinese Short Name, Chinese Address, Phone No, Fax No, Email Address
yco_conamc = @yco_conamc,
yco_shtnamc = @yco_shtnamc,
yco_addrc = @yco_addrc,
yco_phoneno= @yco_phoneno,
yco_faxno = @yco_faxno,
yco_logoimgpth = @yco_logoimgpth
--------------------------------- 

 where
                                                                                                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
 yco_cocde = @yco_cocde



---------------------------------------------------------- 
end






GO
GRANT EXECUTE ON [dbo].[sp_update_SYCOMINF] TO [ERPUSER] AS [dbo]
GO
