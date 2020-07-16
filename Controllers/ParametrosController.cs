using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeguradoraApi.Models;
using SeguradoraApi.Repository;
using System;
using System.Threading.Tasks;

namespace SeguradoraApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    // [Authorize]
    public class ParametrosController : ControllerBase		
	{
		IParemetrosRepository parametrosRepository;

		public ParametrosController(IParemetrosRepository _parametrosRepository)
		{
            parametrosRepository = _parametrosRepository;
		}

        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var data = await parametrosRepository.GetParemetros();

                if (data == null)
                {
                    var resultNotFound = new
                    {
                        code = 20000,
                        data = new {}
                    };
                    return Ok(resultNotFound);
                }
                else
                {
                    var result = new
                    {
                        code = 20000,
                        data 
                    };

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Update([FromBody] Parametros model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await parametrosRepository.Update(model);

                    var result = new
                    {
                        code = 20000,
                        data = "success"
                    };

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}
