using System;
using System.Net;
using System.Threading.Tasks;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodeController : ControllerBase
    {
        private IPostalCodeService _service;

        public PostalCodeController(IPostalCodeService service)
        {
            _service = service;
        }

        // GET: api/postalcode/{id}
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetPostalCodeWithId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //Valida se o modelo do dado de input, caso não retorna um BadRequest(400)
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //400
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: api/postalcode/{postalCode}
        [AllowAnonymous]
        [HttpGet]
        [Route("zip/{postalCode}")]
        public async Task<IActionResult> GetByPostalCode(string postalCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetByPostalCode(postalCode);
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

        // POST: api/postalcode
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostalCodeCreateDTO postalCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(postalCode);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetPostalCodeWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // PUT: api/postalcode/{id}
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PostalCodeUpdateDTO postalCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(postalCode);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // DELETE: api/postalcode/{id}
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
