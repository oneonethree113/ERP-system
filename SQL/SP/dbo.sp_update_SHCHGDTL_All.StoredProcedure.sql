/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGDTL_All]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_update_SHCHGDTL_All]
GO
/****** Object:  StoredProcedure [dbo].[sp_update_SHCHGDTL_All]    Script Date: 09/29/2017 11:53:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO









/************************************************************************
Author:		Marco Chan
Date:		15th February, 2011
Description:	insert data into SHCHGDTL
***********************************************************************
*/

CREATE procedure [dbo].[sp_update_SHCHGDTL_All]

@scd_cocde	nvarchar(6),
@scd_docno	nvarchar(20),
@scd_venno	nvarchar(6),
--@scd_chgcde	nvarchar(20),
@scd_syscbm	numeric(13,4),
@scd_mancbm	numeric(13,4),
@scd_curcde	nvarchar(6),
@d010_flg	char(1),
@scd_fee_d010	numeric(13,4),
@d020_flg	char(1),
@scd_fee_d020	numeric(13,4),
@d030_flg	char(1),
@scd_fee_d030	numeric(13,4),
@d040_flg	char(1),
@scd_fee_d040	numeric(13,4),
@d050_flg	char(1),
@scd_fee_d050	numeric(13,4),
@d060_flg	char(1),
@scd_fee_d060	numeric(13,4),
@d070_flg	char(1),
@scd_fee_d070	numeric(13,4),
@s010_flg	char(1),
@scd_fee_s010	numeric(13,4),
@s020_flg	char(1),
@scd_fee_s020	numeric(13,4),
@s030_flg	char(1),
@scd_fee_s030	numeric(13,4),
@s040_flg	char(1),
@scd_fee_s040	numeric(13,4),
@s050_flg	char(1),
@scd_fee_s050	numeric(13,4),
@s060_flg	char(1),
@scd_fee_s060	numeric(13,4),
@s070_flg	char(1),
@scd_fee_s070	numeric(13,4),
@s080_flg	char(1),
@scd_fee_s080	numeric(13,4),
@scd_updusr	nvarchar(30)
 
AS

BEGIN

--------------------------------------------------------------------------------------------------

declare @scd_chgcde varchar(30)
declare @scd_fee numeric(13,4)
declare @flg char(1)
set @scd_chgcde = ''
set @scd_fee = 0.0
set @flg = ''


--SHDCHG010
set @scd_chgcde = 'SHDCHG010'
set @scd_fee = @scd_fee_d010
set @flg = @d010_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG020
set @scd_chgcde = 'SHDCHG020'
set @scd_fee = @scd_fee_d020
set @flg = @d020_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG030
set @scd_chgcde = 'SHDCHG030'
set @scd_fee = @scd_fee_d030
set @flg = @d030_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG040
set @scd_chgcde = 'SHDCHG040'
set @scd_fee = @scd_fee_d040
set @flg = @d040_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG050
set @scd_chgcde = 'SHDCHG050'
set @scd_fee = @scd_fee_d050
set @flg = @d050_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG060
set @scd_chgcde = 'SHDCHG060'
set @scd_fee = @scd_fee_d060
set @flg = @d060_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHDCHG070
set @scd_chgcde = 'SHDCHG070'
set @scd_fee = @scd_fee_d070
set @flg = @d070_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end


--SHSCHG010
set @scd_chgcde = 'SHSCHG010'
set @scd_fee = @scd_fee_s010
set @flg = @s010_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG020
set @scd_chgcde = 'SHSCHG020'
set @scd_fee = @scd_fee_s020
set @flg = @s020_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG030
set @scd_chgcde = 'SHSCHG030'
set @scd_fee = @scd_fee_s030
set @flg = @s030_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG040
set @scd_chgcde = 'SHSCHG040'
set @scd_fee = @scd_fee_s040
set @flg = @s040_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG050
set @scd_chgcde = 'SHSCHG050'
set @scd_fee = @scd_fee_s050
set @flg = @s050_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG060
set @scd_chgcde = 'SHSCHG060'
set @scd_fee = @scd_fee_s060
set @flg = @s060_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG070
set @scd_chgcde = 'SHSCHG070'
set @scd_fee = @scd_fee_s070
set @flg = @s070_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end

--SHSCHG080
set @scd_chgcde = 'SHSCHG080'
set @scd_fee = @scd_fee_s080
set @flg = @s080_flg

if @flg = 'N'
begin
insert into SHCHGDTL (scd_docno,scd_venno,scd_chgcde,scd_syscbm,scd_mancbm,scd_curcde,scd_fee,scd_creusr,scd_updusr,scd_credat,scd_upddat)
values (@scd_docno,@scd_venno,@scd_chgcde,@scd_syscbm,@scd_mancbm,@scd_curcde,@scd_fee,@scd_updusr,@scd_updusr,getdate(),getdate())
end
else if @flg = 'U'
begin
update SHCHGDTL set scd_syscbm = @scd_syscbm, scd_mancbm = @scd_mancbm, scd_fee = @scd_fee, scd_updusr = @scd_updusr, scd_upddat = getdate()
WHERE scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end
else if @flg = 'D'
begin
delete from SHCHGDTL where scd_docno = @scd_docno and scd_venno = @scd_venno and scd_chgcde = @scd_chgcde and scd_curcde = @scd_curcde
end




END








GO
GRANT EXECUTE ON [dbo].[sp_update_SHCHGDTL_All] TO [ERPUSER] AS [dbo]
GO
