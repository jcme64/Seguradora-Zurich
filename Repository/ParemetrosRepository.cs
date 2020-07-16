using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeguradoraApi.Repository
{
	public class ParemetrosRepository : IParemetrosRepository
    {
		DatabaseContext db;
		public ParemetrosRepository(DatabaseContext _db)
		{
			db = _db;
		}
        public async Task<ParametrosViewModel> GetParemetros()
        {
            if (db != null)
            {
                try
                {
                    
                    List<ParametrosViewModel> list;
                    using (var reader = db.GetProcList("SP_GetParametros"))
                    {
                        list = reader.MapToList<ParametrosViewModel>();
                    }
                    return list.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        public async Task Update(Parametros model)
        {
            if (db != null)
            {
                //Delete that post
                db.Parametros.Update(model);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

    }
}
