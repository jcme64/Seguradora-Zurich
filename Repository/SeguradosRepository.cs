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
    public class SeguradosRepository : ISeguradosRepository
    {
        DatabaseContext db;
        public SeguradosRepository(DatabaseContext _db)
        {
            db = _db;
        }

        public async Task<List<SeguradosViewModel>> GetAll()
        {
            if (db != null)
            {
                try
                {

                    List<SeguradosViewModel> lstresult;
                    using (var reader = db.GetProcList("SP_GetSegurados"))
                    {
                        lstresult = reader.MapToList<SeguradosViewModel>();
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

        public async Task<SeguradosViewModel> Get(int Id)
        {
            if (db != null)
            {
                List<SqlParameter> listparams = new List<SqlParameter>
                    {
                        new SqlParameter("@IdSegurado",Id)
                    };

                List<SeguradosViewModel> lstresult;
                using (var reader = db.GetProcList("SP_GetSegurados", listparams))
                {
                    lstresult = reader.MapToList<SeguradosViewModel>();
                    
                }
                if (lstresult != null) 
                    return lstresult.FirstOrDefault();
                else
                    return null;                
            }

            return null;
        }

        public async Task<int> Add(Segurados model)
        {
            if (db != null)
            {
                await db.Segurados.AddAsync(model);
                await db.SaveChangesAsync();

                return model.IdSegurado;
            }

            return 0;
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var model = await db.Segurados.FirstOrDefaultAsync(x => x.IdSegurado == Id);

                if (model != null)
                {
                    //Delete that post
                    db.Segurados.Remove(model);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task Update(Segurados model)
        {
            if (db != null)
            {
                //Delete that post
                db.Segurados.Update(model);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
