using Microsoft.AspNetCore.Mvc;
using SalesProject.Application.DTO.cellar;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;
using SalesProject.Transversal.Common;

namespace SalesProject.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CellarGeneicController : ControllerBase
    {
        //revisar la clase Cellar, hereda de ClassBase
        private readonly IGenericRepositories<Cellar> repository;

        public CellarGeneicController(IGenericRepositories<Cellar> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CellarDTO>> GetById([FromRoute] int id)
        {

            var response = await repository.GetByIdAsync(id);
            if (response == null)
            {
                NotFound(new ResponseError("The cellar id was not found"));
            }
            return Ok(response);

        }

        [HttpGet("{name}")]
        //public async Task<ActionResult<CellarDTO>> GetByName([FromRoute] string name)
        //{
        //    //var cellar = await _cellarApplication.GetByNameAsync(name);

        //    //if (!cellar.IsSuccess)
        //    //{
        //    //    return BadRequest(new ResponseError(cellar.Message));
        //    //}

        //    //if (cellar.Data == null)
        //    //{
        //    //    return NotFound(new ResponseError("The cellar name was not found"));
        //    //}

        //    //return Ok(cellar.Data);
        //}

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CellarDTO>>> GetAll()
        {

            var responseAll = await repository.GetAllAsync();
            if (!responseAll.Any())
            {
                return BadRequest(new ResponseError("No hay datos"));
            }
            return Ok(responseAll);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Cellar obj)
        {
            var validation = await repository.GetByIdAsync(obj.Id);
            if (validation != null)
            {
                return BadRequest(new ResponseError("registro duplicado"));

            }
            var add = await repository.InsertAsync(obj);
            if (add > 0)
            {
                return Ok();
            }
            return BadRequest(new ResponseError("No se insertaron los datos"));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Cellar obj)
        {
            var update = await repository.UpdateAsync(obj);
            if (update > 0)
            {
                return Ok();
            }
            return BadRequest(new ResponseError("No se actualizaron los datos"));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Cellar obj)
        {
            var delete = await repository.DeleteAsync(obj);
            if (delete > 0)
            {
                return Ok();
            }
            return BadRequest(new ResponseError("No se actualizaron los datos"));
        }
    }
}
