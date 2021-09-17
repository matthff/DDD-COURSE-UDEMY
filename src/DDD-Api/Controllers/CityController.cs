using System;
using System.Net;
using System.Threading.Tasks;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        // GET: api/city
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

        // GET: api/city/{id}
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCityWithId")]
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

        // GET: api/city/byIBGE/{ibgeCode}
        [Authorize("Bearer")]
        [HttpGet]
        [Route("byIBGE/{ibgeCode}")]
        public async Task<IActionResult> GetCompleteByIbgeCode(int ibgeCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetCompleteByIBGE(ibgeCode);
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

        // GET: api/city/complete/{id}
        [Authorize("Bearer")]
        [HttpGet]
        [Route("complete/{id}")]
        public async Task<IActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetCompleteById(id);
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

        // POST: api/city
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityCreateDTO city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Post(city);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetCityWithId", new { id = result.Id })), result);
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

        // PUT: api/city/{id}
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CityUpdateDTO city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Put(city);
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

        // DELETE: api/city/{id}
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
