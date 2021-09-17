using System;
using System.Net;
using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfController : ControllerBase
    {
        private IUfService _service;

        public UfController(IUfService service)
        {
            _service = service;
        }

        // GET: api/uf
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Valida se o modelo do dado de input, caso não retorna um BadRequest(400)
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //400
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: api/uf/{id}
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
