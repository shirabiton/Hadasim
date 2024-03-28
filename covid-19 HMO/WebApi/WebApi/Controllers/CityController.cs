using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IService<CityDto> service;

        public CityController(IService<CityDto> service)
        {
            this.service = service;
        }               

        // GET: api/<CityController>
        [HttpGet]
        public List<CityDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public CityDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public CityDto Post([FromBody] CityDto value)
        {
            return service.Add(value);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public CityDto Put(int id, [FromBody] CityDto value)
        {
            return service.Update(id, value);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
