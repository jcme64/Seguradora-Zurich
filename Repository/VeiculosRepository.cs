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
    public class VeiculosRepository : IVeiculosRepository
    {
        DatabaseContext db;
        public VeiculosRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<VeiculosViewModel>> GetAll()
        {
            if (db != null)
            {
                try
                {

                    List<VeiculosViewModel> lstresult;
                    using (var reader = db.GetProcList("SP_GetVeiculos"))
                    {
                        lstresult = reader.MapToList<VeiculosViewModel>();
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

        public async Task<VeiculosViewModel> Get(int Id)
        {
            if (db != null)
            {
                List<SqlParameter> listparams = new List<SqlParameter>
                    {
                        new SqlParameter("@IdVeiculo",Id)
                    };

                List<VeiculosViewModel> lstresult;
                using (var reader = db.GetProcList("SP_GetVeiculos", listparams))
                {
                    lstresult = reader.MapToList<VeiculosViewModel>();
                    
                }
                if (lstresult != null) 
                    return lstresult.FirstOrDefault();
                else
                    return null;                
            }

            return null;
        }

        public async Task<int> Add(Veiculos model)
        {
            if (db != null)
            {
                await db.Veiculos.AddAsync(model);
                await db.SaveChangesAsync();

                return model.IdVeiculo;
            }

            return 0;
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var model = await db.Veiculos.FirstOrDefaultAsync(x => x.IdVeiculo == Id);

                if (model != null)
                {
                    //Delete that post
                    db.Veiculos.Remove(model);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task Update(Veiculos model)
        {
            if (db != null)
            {
                //Delete that post
                db.Veiculos.Update(model);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
