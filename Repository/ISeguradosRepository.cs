using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraApi.Repository
{
	public interface ISeguradosRepository
	{
		Task<List<SeguradosViewModel>> GetAll();
		Task<SeguradosViewModel> Get(int Id);
		Task<int> Add(Segurados model);
		Task<int> Delete(int Id);
		Task Update(Segurados model);
	}
}
