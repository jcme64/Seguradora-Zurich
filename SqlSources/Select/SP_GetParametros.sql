/*

exec SP_GetParametros

*/

alter PROCEDURE dbo.SP_GetParametros

as

SET NOCOUNT OFF

BEGIN

	begin try

	  select a.id_parametro
	       , a.margem_seguranca
	       , a.lucro
		from tb_parametros a (nolock)
		
	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetParametros: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

