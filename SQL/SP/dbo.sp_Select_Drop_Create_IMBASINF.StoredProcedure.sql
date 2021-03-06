/****** Object:  StoredProcedure [dbo].[sp_Select_Drop_Create_IMBASINF]    Script Date: 09/29/2017 11:53:52 ******/
DROP PROCEDURE [dbo].[sp_Select_Drop_Create_IMBASINF]
GO
/****** Object:  StoredProcedure [dbo].[sp_Select_Drop_Create_IMBASINF]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





/*
=========================================================
Program ID	: sp_Select_Drop_Create_IMBASINF]
Description   	: Drop / Create IMBASINF Trigger
Programmer  	: PIC
Create Date   	: 
Last Modified  	: 
Table Read(s) 	:
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
 Date      Initial  	Description                          
=========================================================    
10/06/2003 Allan Yuen   Relocate Audit Log Location 
17/07/2003 Allan Yuen	Modify for Merge Project
			Disable this function !!
*/

CREATE PROCEDURE [dbo].[sp_Select_Drop_Create_IMBASINF] 
@cocde nvarchar(6),
@type nvarchar(10)
AS

Declare @S nvarchar(4000)

/*
if @type = 'DROP' 
Begin
	if exists (select * from sysobjects where id = object_id('tr_IMBASINF_update') and OBJECTPROPERTY(id, 'IsTrigger') = 1)
	Begin
	drop trigger [tr_IMBASINF_update]
	End
	
	--remarked by tommy on 16 nov 2002, When this job fail, dont want effect to PDA running. 
	--update IMBASINF SET ibi_imgpth = '' where ibi_cocde = @cocde
END

Else
Begin

SET @S = 'CREATE TRIGGER [tr_IMBASINF_update] ON [IMBASINF]FOR UPDATEAS

                                 
-------------------------------- 
declare @write_log_date datetime

                                   
---------------------------------- 
  set @write_log_date  = getdate()

                                            
------------------------------------------- 
----  insert into [IMBASINF_AUD] 
       insert into [UCPERPDB_AUD].[DBO].[IMBASINF_AUD] (

                                                                                                                                   
---------------------------------------------------------------------------------------------------------------------------------- 
ibi_cocde ,
ibi_itmno ,
ibi_orgitm ,
ibi_lnecde ,
ibi_curcde ,
ibi_catlvl0 ,
ibi_catlvl1 ,
ibi_catlvl2 ,
ibi_catlvl3 ,
ibi_catlvl4 ,
ibi_itmsts ,
ibi_typ ,
ibi_engdsc ,
ibi_chndsc ,
ibi_venno ,
ibi_imgpth ,
ibi_hamusa ,
ibi_hameur ,
ibi_dtyusa ,
ibi_dtyeur ,
ibi_cosmth ,
ibi_rmk ,
ibi_tirtyp ,
ibi_moqctn ,
ibi_qty ,
ibi_moa ,
ibi_prvsts ,
ibi_latrdat ,
ibi_creusr ,
ibi_updusr ,
ibi_credat ,
ibi_upddat ,
ibi_actflg_aud

         
-------- 
)select

                                                                                                                                     
------------------------------------------------------------------------------------------------------------------------------------ 
  ibi_cocde ,
  ibi_itmno ,
  ibi_orgitm ,
  ibi_lnecde ,
  ibi_curcde ,
  ibi_catlvl0 ,
  ibi_catlvl1 ,
  ibi_catlvl2 ,
  ibi_catlvl3 ,
  ibi_catlvl4 ,
  ibi_itmsts ,
  ibi_typ ,
  ibi_engdsc ,
  ibi_chndsc ,
  ibi_venno ,
  ibi_imgpth ,
  ibi_hamusa ,
  ibi_hameur ,
  ibi_dtyusa ,
  ibi_dtyeur ,
  ibi_cosmth ,
  ibi_rmk ,
  ibi_tirtyp ,
  ibi_moqctn ,
  ibi_qty ,
  ibi_moa ,
  ibi_prvsts ,
  ibi_latrdat ,
  ibi_creusr ,
  ibi_updusr ,
  getdate() ,
  ibi_upddat ,
  2

               
-------------- 
  from deleted

                                            
------------------------------------------- 
--  insert into [IMBASINF_AUD] 
     insert into [UCPERPDB_AUD].[DBO].[IMBASINF_AUD] (

                                                                                                                                   
---------------------------------------------------------------------------------------------------------------------------------- 
ibi_cocde ,
ibi_itmno ,
ibi_orgitm ,
ibi_lnecde ,
ibi_curcde ,
ibi_catlvl0 ,
ibi_catlvl1 ,
ibi_catlvl2 ,
ibi_catlvl3 ,
ibi_catlvl4 ,
ibi_itmsts ,
ibi_typ ,
ibi_engdsc ,
ibi_chndsc ,
ibi_venno ,
ibi_imgpth ,
ibi_hamusa ,
ibi_hameur ,
ibi_dtyusa ,
ibi_dtyeur ,
ibi_cosmth ,
ibi_rmk ,
ibi_tirtyp ,
ibi_moqctn ,
ibi_qty ,
ibi_moa ,
ibi_prvsts ,
ibi_latrdat ,
ibi_creusr ,
ibi_updusr ,
ibi_credat ,
ibi_upddat ,
ibi_actflg_aud

         
-------- 
)select

                                                                                                                                     
------------------------------------------------------------------------------------------------------------------------------------ 
  ibi_cocde ,
  ibi_itmno ,
  ibi_orgitm ,
  ibi_lnecde ,
  ibi_curcde ,
  ibi_catlvl0 ,
  ibi_catlvl1 ,
  ibi_catlvl2 ,
  ibi_catlvl3 ,
  ibi_catlvl4 ,
  ibi_itmsts ,
  ibi_typ ,
  ibi_engdsc ,
  ibi_chndsc ,
  ibi_venno ,
  ibi_imgpth ,
  ibi_hamusa ,
  ibi_hameur ,
  ibi_dtyusa ,
  ibi_dtyeur ,
  ibi_cosmth ,
  ibi_rmk ,
  ibi_tirtyp ,
  ibi_moqctn ,
  ibi_qty ,
  ibi_moa ,
  ibi_prvsts ,
  ibi_latrdat ,
  ibi_creusr ,
  ibi_updusr ,
  @write_log_date ,
  ibi_upddat ,
  3

                
--------------- 
  from inserted'
exec(@S)
end
*/





GO
GRANT EXECUTE ON [dbo].[sp_Select_Drop_Create_IMBASINF] TO [ERPUSER] AS [dbo]
GO
