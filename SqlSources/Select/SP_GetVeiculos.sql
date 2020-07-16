/*

declare @IdVeiculo int = 2

exec SP_GetVeiculos @IdVeiculo

*/

alter PROCEDURE dbo.SP_GetVeiculos
(
    @IdVeiculo int = NULL
)
as

SET NOCOUNT OFF

BEGIN

	begin try

       select a.id_veiculo
	        , a.marca_veiculo
			, a.modelo_veiculo
			, a.cor_veiculo
			, a.placa
			, a.ano_veiculo
			, a.valor_veiculo
			, a.renavam
	     from tb_veiculos a (nolock)
         where @IdVeiculo is null or @IdVeiculo = 0 or a.id_veiculo = @IdVeiculo
		
	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetVeiculos: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

