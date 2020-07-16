/*

declare @IdSegurado int = 1

exec SP_GetSegurados @IdSegurado

*/

alter PROCEDURE dbo.SP_GetSegurados
(
    @IdSegurado int = NULL
)
as

SET NOCOUNT OFF

BEGIN

	begin try

	  select id_segurado
	       , nome_segurado
		   , cpf
		   , dt_nascimento
		   , genero
		from tb_segurados (nolock)
	   where @IdSegurado is null or @IdSegurado = 0 or id_segurado = @IdSegurado
		
	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetSegurados: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

