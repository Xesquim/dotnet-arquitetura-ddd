using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Services.City;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public ICityService _service { get; set; }
        public CitiesController(ICityService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCityWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("complete/{idCity}")]
        public async Task<ActionResult> GetCompleteById(Guid idCity)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteById(idCity);
                if(result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("ibge/{ibgeCode}")]
        public async Task<ActionResult> GetCompleteByIbge(int ibgeCode)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteByIbge(ibgeCode);
                if(result == null)
                    return NotFound();
                    
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CityDtoCreate cityDtoCreate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(cityDtoCreate);
                if(result == null)
                    return BadRequest();
                
                return Created(new Uri(Url.Link("GetCityWithId", new { id = result.Id })), result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CityDtoUpdate cityDtoUpdate)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _service.Put(cityDtoUpdate);
                if(result == null)
                    return BadRequest();
                
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}