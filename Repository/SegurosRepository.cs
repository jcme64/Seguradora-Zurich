using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SeguradoraApi.Repository
{
    public class SegurosRepository : ISegurosRepository
    {
        DatabaseContext db;
        public SegurosRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<SegurosViewModel>> GetAll()
        {
            if (db != null)
            {
                try
                {

                    List<SegurosViewModel> lstresult;
                    using (var reader = db.GetProcList("SP_GetSeguros"))
                    {
                        lstresult = reader.MapToList<SegurosViewModel>();
                    }
                    return lstresult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return null;
        }

        public async Task<SegurosViewModel> Get(int Id)
        {
            if (db != null)
            {
                List<SqlParameter> listparams = new List<SqlParameter>
                    {
                        new SqlParameter("@IdSeguro",Id)
                    };

                List<SegurosViewModel> lstresult;
                using (var reader = db.GetProcList("SP_GetSeguros", listparams))
                {
                    lstresult = reader.MapToList<SegurosViewModel>();
                    
                }
                if (lstresult != null) 
                    return lstresult.FirstOrDefault();
                else
                    return null;                
            }

            return null;
        }

        public async Task<int> Add(SegurosRequest model)
        {
            if (db != null)
            {
                int IdVeiculo = model.Veiculo.IdVeiculo;
                var veiculosRepository = new VeiculosRepository(db);
                if (IdVeiculo == 0)
                {
                    IdVeiculo = await veiculosRepository.Add(model.Veiculo);
                }
                else
                {
                    var veiculo = await veiculosRepository.Get(IdVeiculo);
                    if (veiculo != null)
                    { 
                        model.Veiculo = new Veiculos {
                        IdVeiculo = veiculo.IdVeiculo,
                        MarcaVeiculo = veiculo.MarcaVeiculo,
                        ModeloVeiculo = veiculo.ModeloVeiculo,
                        CorVeiculo = veiculo.CorVeiculo,
                        Placa = veiculo.Placa,
                        AnoVeiculo = veiculo.AnoVeiculo,
                        Renavam = veiculo.Renavam,
                        ValorVeiculo = veiculo.ValorVeiculo
                        };
                    }
                }
                              
                var paremetrosRepository = new ParemetrosRepository(db);
                ParametrosViewModel Parametros = await paremetrosRepository.GetParemetros();
                Seguros newModel = new Seguros();
                newModel.TaxaRisco = ((model.Veiculo.ValorVeiculo * 5) / (model.Veiculo.ValorVeiculo * 2) / 100);
                newModel.PremioRisco = newModel.TaxaRisco * model.Veiculo.ValorVeiculo;
                newModel.PremioPuro = newModel.PremioRisco * (1 + (Parametros.MargemSeguranca / 100));
                newModel.PremioComercial = newModel.PremioPuro * (1 + (Parametros.Lucro / 100));
                newModel.ValorSeguro = newModel.PremioComercial;

                newModel.IdSegurado = model.IdSegurado;
                newModel.IdVeiculo = IdVeiculo;
                await db.Seguros.AddAsync(newModel);
                await db.SaveChangesAsync();

                return newModel.IdSeguro;
            }

            return 0;
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var model = await db.Seguros.FirstOrDefaultAsync(x => x.IdSeguro == Id);

                if (model != null)
                {
                    //Delete that post
                    db.Seguros.Remove(model);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<MediasViewModel> GetMedias()
        {
            if (db != null)
            {
                try
                {

                    List<MediasViewModel> lstresult;
                    using (var reader = db.GetProcList("SP_GetMediasSeguros"))
                    {
                        lstresult = reader.MapToList<MediasViewModel>();
                    }
                    return lstresult.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return null;
        }
    }
}
