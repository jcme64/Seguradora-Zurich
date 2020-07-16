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
		   , b.nome_segurado
		   , b.cpf
		   , b.dt_nascimento
		   , b.genero
		   , c.id_veiculo
		   , c.marca_veiculo
		   , c.modelo_veiculo
		   , c.cor_veiculo
		   , c.placa
		   , c.ano_veiculo
		   , c.valor_veiculo
		from tb_seguros a (nolock)
		     inner join tb_segurados b (nolock) on a.id_segurado = b.id_segurado
			 inner join tb_veiculos c (nolock) on a.id_veiculo = c.id_veiculo
       where @IdSeguro is null or @IdSeguro = 0 or a.id_seguro =  @IdSeguro

	END TRY
	BEGIN CATCH	
		declare @error int, @message varchar(4000), @xstate int;
        select @error = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
        raiserror ('SP_GetEmpresaUnidadeByNomeFantadiaEmpresa: %d: %s', 16, 1, @error, @message) ;
	END CATCH; 
end

