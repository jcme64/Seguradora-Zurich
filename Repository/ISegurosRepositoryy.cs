using SeguradoraApi.ViewModel;
using SeguradoraApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeguradoraApi.Repository
{
	public interface ISegurosRepository
	{
		Task<List<SegurosViewModel>> GetAll();
		Task<SegurosViewModel> Get(int Id);
		Task<int> Add(SegurosRequest model);
		Task<int> Delete(int Id);

		Task<MediasViewModel> GetMedias();
	}
}
