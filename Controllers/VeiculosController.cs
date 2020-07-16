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
    public class VeiculosController : ControllerBase		
	{
        IVeiculosRepository veiculosRepository;

		public VeiculosController(IVeiculosRepository _veiculosRepository)
		{
            veiculosRepository = _veiculosRepository;
		}

        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var data = await veiculosRepository.GetAll();

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

        [HttpGet]
        [Route("ObterById")]
        public async Task<IActionResult> ObterById(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }

            try
            {
                var response = await veiculosRepository.Get(Id);

                if (response == null)
                {
                    var resultNotFound = new
                    {
                        code = 20000,
                        totalRecord = 0,
                        data = ""
                    };
                    return Ok(resultNotFound);
                }
                else
                {
                    var result = new
                    {
                        code = 20000,
                        data = response
                    };

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Incluir")]
        public async Task<IActionResult> Add([FromBody] Veiculos model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await veiculosRepository.Add(model);
                    if (Id > 0)
                    {
                        var result = new
                        {

                            code = 20000,
                            data = new
                            {
                                id = Id,
                                mesage = "success"
                            }
                        };

                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("Excluir")]
        public async Task<IActionResult> Delete(int Id)
        {

            if (Id == 0)
            {
                return BadRequest();
            }

            try
            {
                var response = await veiculosRepository.Delete(Id);
                if (response == 0)
                {
                    return NotFound();
                }
                var result = new
                {
                    code = 20000,
                    data = "success"
                };
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Update([FromBody] Veiculos model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await veiculosRepository.Update(model);

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
