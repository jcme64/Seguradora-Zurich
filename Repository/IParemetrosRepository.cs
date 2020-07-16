using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraApi.Repository
{
	public interface IParemetrosRepository
	{
		Task<ParametrosViewModel> GetParemetros();
		Task Update(Parametros model);
	}
}
