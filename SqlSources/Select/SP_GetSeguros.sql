/*
declare @IdSeguro int = 1

exec SP_GetSeguros @IdSeguro

*/

alter PROCEDURE dbo.SP_GetSeguros
(
  @IdSeguro int = NULL
)

as

SET NOCOUNT OFF

BEGIN

	begin try

	  select a.id_seguro
	       , a.id_segurado
		   , a.id_veiculo
	       , a.taxa_risco
		   , a.premio_risco
		   , a.premio_puro
		   , a.premio_comercial
		   , a.valor_seguro		
		   , b.id_segurado
		from tb_seguros a (nolock)
		     inner join tb_segurados b (nolock) on a.id_segurado = b.id_segurado
       where @IdSeguro is null or @IdSeguro = 0 or a.id_seguro =  @IdSeguro

	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetEmpresaUnidadeByNomeFantadiaEmpresa: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

