using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraApi.Repository
{
	public interface IVeiculosRepository
	{
		Task<List<VeiculosViewModel>> GetAll();
		Task<VeiculosViewModel> Get(int Id);
		Task<int> Add(Veiculos model);
		Task<int> Delete(int Id);
		Task Update(Veiculos model);
	}
}
