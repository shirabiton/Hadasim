using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IService<ManufacturerDto> service;

        public ManufacturerController(IService<ManufacturerDto> service)
        {
            this.service = service;
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public List<ManufacturerDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<ManufacturerController>/5
        [HttpGet("{id}")]
        public ManufacturerDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<ManufacturerController>
        [HttpPost]
        public ManufacturerDto Post([FromBody] ManufacturerDto value)
        {
            return service.Add(value);
        }

        // PUT api/<ManufacturerController>/5
        [HttpPut("{id}")]
        public ManufacturerDto Put(int id, [FromBody] ManufacturerDto value)
        {
            return service.Update(id, value);
        }

        // DELETE api/<ManufacturerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
