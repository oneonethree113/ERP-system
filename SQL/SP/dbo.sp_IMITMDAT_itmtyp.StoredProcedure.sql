/****** Object:  StoredProcedure [dbo].[sp_IMITMDAT_itmtyp]    Script Date: 09/29/2017 11:53:53 ******/
DROP PROCEDURE [dbo].[sp_IMITMDAT_itmtyp]
GO
/****** Object:  StoredProcedure [dbo].[sp_IMITMDAT_itmtyp]    Script Date: 09/29/2017 11:53:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO



/*
=========================================================
Program ID	: 	sp_IMITMDAT_itmtyp
Description   	: 	
Programmer  	: 	PIC
Create Date   	: 	
Last Modified  	: 
Table Read(s) 	:	
Table Write(s) 	:
=========================================================
 Modification History                                    
=========================================================
2003-09-18	Allan Yuen		Add BOM Item Flag, Original Design Vendor, MOQ Field.
=========================================================     
*/



CREATE PROCEDURE [dbo].[sp_IMITMDAT_itmtyp] 


AS


update imitmdat set iid_itmtyp = 'BOM'
where 	 iid_itmtyp = '' and iid_bomflg = 'Y' 

update imitmdat set iid_itmtyp = 'ASS'
where 	 iid_itmtyp = '' and  iid_venitm in
	(select iad_venitm from IMASSDAT where
	 iad_cocde = iid_cocde and iad_xlsfil = iid_xlsfil and iad_chkdat = iid_chkdat)


update imitmdat set iid_itmtyp = 'REG'
where 	 iid_itmtyp = '' and iid_venitm not in
	(select iad_venitm from IMASSDAT where
	 iad_cocde = iid_cocde and iad_xlsfil = iid_xlsfil and iad_chkdat = iid_chkdat)


DECLARE	-- IMITMDAT
@iid_cocde 	nvarchar(6),	@iid_venno 	nvarchar(6),	@iid_venitm 	nvarchar(20),
@iid_itmseq 	int,		@iid_recseq 	int,		@iid_mode 	nvarchar(3),
@iid_itmsts 	nvarchar(3),	@iid_stage 	nvarchar(3),	@iid_engdsc 	nvarchar(800),
@iid_chndsc 	nvarchar(1600),	@iid_lnecde 	nvarchar(10),	@iid_catlvl4	nvarchar(20),
@iid_untcde 	nvarchar(4),	@iid_inrqty 	int,		@iid_mtrqty 	int,
@iid_inrlcm 	numeric(11,4),	@iid_inrwcm 	numeric(11,4),	@iid_inrhcm 	numeric(11,4),
@iid_mtrlcm 	numeric(11,4),	@iid_mtrwcm 	numeric(11,4),	@iid_mtrhcm 	numeric(11,4),
@iid_cft 		numeric(11,4),	@iid_conftr 	int,		@iid_curcde 	nvarchar(6),
@iid_ftycst 	numeric(13,4),	@iid_ftyprc 	numeric(13,4),	@iid_prctrm 	nvarchar(10),
@iid_grswgt 	numeric(6,3),	@iid_netwgt 	numeric(6,3),	@iid_pckitr 	nvarchar(300),
@iid_itmno	nvarchar(20),	@iid_sysmsg	nvarchar(300),	@iid_xlsfil 	nvarchar(30),		
@iid_veneml	nvarchar(50),	@iid_malsts	nvarchar(1),	@iid_chkdat	datetime,		
@iid_refresh	nvarchar(1),	@iid_prdven           nvarchar(6)

DECLARE	--IMBOMASS
@iba_cocde	nvarchar(6),	@iba_itmno	nvarchar(20),	@iba_assitm	nvarchar(20),
@iba_colcde	nvarchar(30),	@iba_pckunt	nvarchar(6),	@iba_inrqty	int,	
@iba_mtrqty	int

DECLARE 	--TEMP
@match		nvarchar(1)

DECLARE cur_IMITMDAT CURSOR
FOR 	SELECT 		iid_cocde ,	iid_venno ,		iid_venitm ,
			iid_itmseq ,	iid_recseq ,		iid_mode ,
			iid_itmsts ,	iid_stage ,		iid_engdsc ,
			iid_chndsc ,	iid_lnecde ,		iid_catlvl4 ,
			iid_untcde ,	iid_inrqty ,		iid_mtrqty ,
			iid_inrlcm ,	iid_inrwcm ,		iid_inrhcm ,
			iid_mtrlcm ,	iid_mtrwcm ,		iid_mtrhcm ,
			iid_cft ,		iid_conftr ,		iid_curcde ,
			iid_ftycst ,	iid_ftyprc ,		iid_prctrm ,
			iid_grswgt ,	iid_netwgt ,		iid_pckitr ,
			iid_itmno,	iid_sysmsg,		iid_xlsfil,		
			iid_chkdat,	iid_veneml,		iid_malsts,	
			iid_refresh,	iid_prdven
	FROM IMITMDAT	WHERE 	iid_stage =  'W' and iid_mode = 'UPD' and iid_itmtyp = 'ASS'
	ORDER BY  iid_venitm, iid_chkdat
			
OPEN cur_IMITMDAT
FETCH NEXT FROM cur_IMITMDAT INTO 
@iid_cocde ,		@iid_venno ,		@iid_venitm ,
@iid_itmseq ,		@iid_recseq ,		@iid_mode ,
@iid_itmsts ,		@iid_stage ,		@iid_engdsc ,
@iid_chndsc ,		@iid_lnecde ,		@iid_catlvl4 ,
@iid_untcde ,		@iid_inrqty ,		@iid_mtrqty ,
@iid_inrlcm ,		@iid_inrwcm ,		@iid_inrhcm ,
@iid_mtrlcm ,		@iid_mtrwcm ,		@iid_mtrhcm ,
@iid_cft ,			@iid_conftr ,		@iid_curcde ,
@iid_ftycst ,		@iid_ftyprc ,		@iid_prctrm ,
@iid_grswgt ,		@iid_netwgt ,		@iid_pckitr ,
@iid_itmno,		@iid_sysmsg,		@iid_xlsfil,
@iid_chkdat,		@iid_veneml,		@iid_malsts,
@iid_refresh,		@iid_prdven

WHILE @@fetch_status = 0
BEGIN

		set @match = 'Y'

		if 	(select count(*) from IMBOMASS where 
					--iba_cocde = @iid_cocde and 
					iba_itmno = @iid_itmno and 
					iba_typ = 'ASS')  <>
			(select count(*) from IMASSDAT where 
					iad_cocde = @iid_cocde and 
					iad_venno = @iid_venno and 
					iad_prdven = @iid_prdven and
					iad_venitm = @iid_venitm and 
					iad_xlsfil = @iid_xlsfil and 
					iad_chkdat = @iid_chkdat)
		begin
			set @match = 'N'
			set @iid_stage = 'I'
			set @iid_refresh = 'N'
			set @iid_sysmsg = @iid_sysmsg + (case @iid_sysmsg when '' then @iid_venitm + ' - the Assorted Item in Item Master not match with Excel' 
		  				         else ', ' + @iid_venitm + ' - the Assorted Item in Item Master not match with Excel' end)
		end

		if @match = 'Y'
		begin
			DECLARE cur_IMBOMASS CURSOR
			FOR 	SELECT 	iba_cocde,	
					(case @iid_cocde when 'UCPP' then iba_itmno else a.ivi_venitm end),
					(case @iid_cocde when 'UCPP' then iba_assitm else b.ivi_venitm end),
					iba_colcde,	iba_pckunt,	iba_inrqty,	
					iba_mtrqty
				FROM IMBOMASS
				LEFT JOIN  IMVENINF a ON
						--a.ivi_cocde = @iid_cocde and 
						a.ivi_venno = @iid_venno and 
						a.ivi_itmno = iba_itmno
				LEFT JOIN  IMVENINF b ON
						--b.ivi_cocde = @iid_cocde and 
						b.ivi_venno = @iid_venno and 
						b.ivi_itmno = iba_assitm
				WHERE 
					--iba_cocde = @iid_cocde and 
					iba_itmno = @iid_itmno and 
					iba_typ = 'ASS'
				ORDER BY 
					iba_itmno, iba_assitm
			
			OPEN cur_IMBOMASS
			FETCH NEXT FROM cur_IMBOMASS INTO 
			@iba_cocde,	@iba_itmno,	@iba_assitm,
			@iba_colcde,	@iba_pckunt,	@iba_inrqty,	
			@iba_mtrqty
			
			WHILE @@fetch_status = 0
			BEGIN
				if (select count(*) from IMASSDAT where  iad_cocde = @iid_cocde and iad_venitm = @iba_itmno and
								     iad_acsno = @iba_assitm and iad_colcde = @iba_colcde and
								     iad_untcde = @iba_pckunt and iad_inrqty = @iba_inrqty and
								     iad_mtrqty = @iba_mtrqty and iad_venno = @iid_venno and 
								     iad_prdven = @iid_prdven and iad_xlsfil = @iid_xlsfil and
								     iad_chkdat = @iid_chkdat) = 0
				begin
					set @match = 'N'
					set @iid_stage = 'I'
					set @iid_refresh = 'N'
					set @iid_sysmsg = @iid_sysmsg + (case @iid_sysmsg when '' then @iba_assitm + ' - the Assorted Item in Item Master not match with Excel' 
				  				         else ', ' + @iba_assitm + ' - the Assorted Item in Item Master not match with Excel' end)
				end
	
			FETCH NEXT FROM cur_IMBOMASS INTO 
			@iba_cocde,	@iba_itmno,	@iba_assitm,
			@iba_colcde,	@iba_pckunt,	@iba_inrqty,	
			@iba_mtrqty
			
			END
			CLOSE cur_IMBOMASS
			DEALLOCATE cur_IMBOMASS
		end
		
		if @match = 'N' 
		begin
			update IMASSDAT set iad_stage = 'I' , iad_sysmsg = iad_sysmsg +  (case iad_sysmsg when '' then 'The Assorted Item not match with Item Master' 
			  				 else ', the Assorted Item not match with Item Master' end)
			where iad_cocde = @iid_cocde and iad_venitm = @iid_venitm and iad_xlsfil = @iid_xlsfil and iad_chkdat = @iid_chkdat and
			           iad_venno = @iid_venno and iad_prdven = @iid_prdven

			update IMITMDAT set iid_stage = 'I' , iid_sysmsg = @iid_sysmsg
			where iid_cocde = @iid_cocde and iid_venitm = @iid_venitm and iid_xlsfil = @iid_xlsfil and iid_chkdat = @iid_chkdat and
			          iid_venno = @iid_venno and iid_prdven = @iid_prdven
		end

FETCH NEXT FROM cur_IMITMDAT INTO 
@iid_cocde ,		@iid_venno ,		@iid_venitm ,
@iid_itmseq ,		@iid_recseq ,		@iid_mode ,
@iid_itmsts ,		@iid_stage ,		@iid_engdsc ,
@iid_chndsc ,		@iid_lnecde ,		@iid_catlvl4 ,
@iid_untcde ,		@iid_inrqty ,		@iid_mtrqty ,
@iid_inrlcm ,		@iid_inrwcm ,		@iid_inrhcm ,
@iid_mtrlcm ,		@iid_mtrwcm ,		@iid_mtrhcm ,
@iid_cft ,			@iid_conftr ,		@iid_curcde ,
@iid_ftycst ,		@iid_ftyprc ,		@iid_prctrm ,
@iid_grswgt ,		@iid_netwgt ,		@iid_pckitr ,
@iid_itmno,		@iid_sysmsg,		@iid_xlsfil,
@iid_chkdat,		@iid_veneml,		@iid_malsts,
@iid_refresh,		@iid_prdven
END
CLOSE cur_IMITMDAT
DEALLOCATE cur_IMITMDAT

---------------------------------------------------------------------------------------------------

DECLARE cur_IMITMDAT CURSOR
FOR 	SELECT 		iid_cocde ,	iid_venno ,		iid_venitm ,
			iid_itmseq ,	iid_recseq ,		iid_mode ,
			iid_itmsts ,	iid_stage ,		iid_engdsc ,
			iid_chndsc ,	iid_lnecde ,		iid_catlvl4 ,
			iid_untcde ,	iid_inrqty ,		iid_mtrqty ,
			iid_inrlcm ,	iid_inrwcm ,		iid_inrhcm ,
			iid_mtrlcm ,	iid_mtrwcm ,		iid_mtrhcm ,
			iid_cft ,		iid_conftr ,		iid_curcde ,
			iid_ftycst ,	iid_ftyprc ,		iid_prctrm ,
			iid_grswgt ,	iid_netwgt ,		iid_pckitr ,
			iid_itmno,	iid_sysmsg,		iid_xlsfil,		
			iid_chkdat,	iid_veneml,		iid_malsts,	
			iid_refresh,	iid_prdven
	FROM IMITMDAT	WHERE 	iid_stage =  'W' and iid_mode = 'UPD' and iid_itmtyp = 'BOM'
	ORDER BY  iid_venitm, iid_chkdat
			
OPEN cur_IMITMDAT
FETCH NEXT FROM cur_IMITMDAT INTO 
@iid_cocde ,		@iid_venno ,		@iid_venitm ,
@iid_itmseq ,		@iid_recseq ,		@iid_mode ,
@iid_itmsts ,		@iid_stage ,		@iid_engdsc ,
@iid_chndsc ,		@iid_lnecde ,		@iid_catlvl4 ,
@iid_untcde ,		@iid_inrqty ,		@iid_mtrqty ,
@iid_inrlcm ,		@iid_inrwcm ,		@iid_inrhcm ,
@iid_mtrlcm ,		@iid_mtrwcm ,		@iid_mtrhcm ,
@iid_cft ,			@iid_conftr ,		@iid_curcde ,
@iid_ftycst ,		@iid_ftyprc ,		@iid_prctrm ,
@iid_grswgt ,		@iid_netwgt ,		@iid_pckitr ,
@iid_itmno,		@iid_sysmsg,		@iid_xlsfil,
@iid_chkdat,		@iid_veneml,		@iid_malsts,
@iid_refresh,		@iid_prdven

WHILE @@fetch_status = 0
BEGIN

		set @match = 'Y'

		if 	(select count(*) from IMBOMASS where 
					--iba_cocde = @iid_cocde and 
					iba_itmno = @iid_itmno and 
					iba_typ = 'BOM')  <>
			(select count(*) from IMBOMDAT where 
					ibd_cocde = @iid_cocde and 
					ibd_venno = @iid_venno and 
					ibd_prdven = @iid_prdven and
					ibd_venitm = @iid_venitm and 
					ibd_xlsfil = @iid_xlsfil and 
					ibd_chkdat = @iid_chkdat)
		begin
			set @match = 'N'
			set @iid_stage = 'I'
			set @iid_refresh = 'N'
			set @iid_sysmsg = @iid_sysmsg + (case @iid_sysmsg when '' then @iid_venitm + ' - the BOM Item in Item Master not match with Excel' 
		  				         else ', ' + @iid_venitm + ' - the BOM Item in Item Master not match with Excel' end)
		end

		if @match = 'Y'
		begin
			DECLARE cur_IMBOMASS CURSOR
			FOR 	SELECT 	iba_cocde,	
					(case @iid_cocde when 'UCPP' then iba_itmno else a.ivi_venitm end),
					(case @iid_cocde when 'UCPP' then iba_assitm else b.ivi_venitm end),
					iba_colcde,	iba_pckunt,	iba_inrqty,	
					iba_mtrqty
				FROM IMBOMASS
				LEFT JOIN  IMVENINF a ON
						--a.ivi_cocde = @iid_cocde and 
						a.ivi_venno = @iid_venno and 
						a.ivi_itmno = iba_itmno
				LEFT JOIN  IMVENINF b ON
						--b.ivi_cocde = @iid_cocde and 
						b.ivi_venno = @iid_venno and 
						b.ivi_itmno = iba_assitm
				WHERE 
					--iba_cocde = @iid_cocde and 
					iba_itmno = @iid_itmno and 
					iba_typ = 'ASS'
				ORDER BY 
					iba_itmno, iba_assitm
			
			OPEN cur_IMBOMASS
			FETCH NEXT FROM cur_IMBOMASS INTO 
			@iba_cocde,	@iba_itmno,	@iba_assitm,
			@iba_colcde,	@iba_pckunt,	@iba_inrqty,	
			@iba_mtrqty
			
			WHILE @@fetch_status = 0
			BEGIN
				if (select count(*) from IMBOMDAT where  
					ibd_cocde = @iid_cocde and 
					ibd_venitm = @iba_itmno and
					ibd_acsno = @iba_assitm and 
					ibd_colcde = @iba_colcde and
					ibd_untcde = @iba_pckunt and 
					--ibd_inrqty = @iba_inrqty and
					--ibd_mtrqty = @iba_mtrqty and 
					ibd_venno = @iid_venno and 
					ibd_prdven = @iid_prdven and 
					ibd_xlsfil = @iid_xlsfil and
					ibd_chkdat = @iid_chkdat) = 0
				begin
					set @match = 'N'
					set @iid_stage = 'I'
					set @iid_refresh = 'N'
					set @iid_sysmsg = @iid_sysmsg + (case @iid_sysmsg when '' then @iba_assitm + ' - the BOM Item in Item Master not match with Excel' 
				  				         else ', ' + @iba_assitm + ' - the BOM Item in Item Master not match with Excel' end)
				end
	
			FETCH NEXT FROM cur_IMBOMASS INTO 
			@iba_cocde,	@iba_itmno,	@iba_assitm,
			@iba_colcde,	@iba_pckunt,	@iba_inrqty,	
			@iba_mtrqty
			
			END
			CLOSE cur_IMBOMASS
			DEALLOCATE cur_IMBOMASS
		end
		
		if @match = 'N' 
		begin
			update 
				IMBOMDAT 
			set 
				ibd_stage = 'I' , 
				ibd_sysmsg = ibd_sysmsg +  (case ibd_sysmsg when '' then 'The BOM Item not match with Item Master'  else ', the BOM Item not match with Item Master' end)
			where 
				ibd_cocde = @iid_cocde and 
				ibd_venitm = @iid_venitm and 
				ibd_xlsfil = @iid_xlsfil and 
				ibd_chkdat = @iid_chkdat and
			           	ibd_venno = @iid_venno and 
				ibd_prdven = @iid_prdven

			update IMITMDAT set iid_stage = 'I' , iid_sysmsg = @iid_sysmsg
			where iid_cocde = @iid_cocde and iid_venitm = @iid_venitm and iid_xlsfil = @iid_xlsfil and iid_chkdat = @iid_chkdat and
			          iid_venno = @iid_venno and iid_prdven = @iid_prdven		
		end

FETCH NEXT FROM cur_IMITMDAT INTO 
@iid_cocde ,		@iid_venno ,		@iid_venitm ,
@iid_itmseq ,		@iid_recseq ,		@iid_mode ,
@iid_itmsts ,		@iid_stage ,		@iid_engdsc ,
@iid_chndsc ,		@iid_lnecde ,		@iid_catlvl4 ,
@iid_untcde ,		@iid_inrqty ,		@iid_mtrqty ,
@iid_inrlcm ,		@iid_inrwcm ,		@iid_inrhcm ,
@iid_mtrlcm ,		@iid_mtrwcm ,		@iid_mtrhcm ,
@iid_cft ,			@iid_conftr ,		@iid_curcde ,
@iid_ftycst ,		@iid_ftyprc ,		@iid_prctrm ,
@iid_grswgt ,		@iid_netwgt ,		@iid_pckitr ,
@iid_itmno,		@iid_sysmsg,		@iid_xlsfil,
@iid_chkdat,		@iid_veneml,		@iid_malsts,
@iid_refresh,		@iid_prdven
END
CLOSE cur_IMITMDAT
DEALLOCATE cur_IMITMDAT



GO
GRANT EXECUTE ON [dbo].[sp_IMITMDAT_itmtyp] TO [ERPUSER] AS [dbo]
GO
