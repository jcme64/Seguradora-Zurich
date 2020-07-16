/*

exec SP_GetSegurados

*/

Create PROCEDURE dbo.SP_GetSegurados

as

SET NOCOUNT OFF

BEGIN

	begin try

	  select id_segurado
	       , nome_segurado
		   , cpf
		   , dt_nascimento
		from tb_segurados (nolock)
		
	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetSegurados: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

