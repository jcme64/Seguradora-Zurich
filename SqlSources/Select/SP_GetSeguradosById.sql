/*

declare @id int = 1

exec SP_GetSeguradosById @id

*/

Create PROCEDURE dbo.SP_GetSeguradosById
(
  @id int
)
as

SET NOCOUNT OFF

BEGIN

	begin try

	  select id_segurado
	       , nome_segurado
		   , cpf
		   , dt_nascimento
		from tb_segurados (nolock)
	   where id_segurado = @id
		
	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetSeguradosById: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

