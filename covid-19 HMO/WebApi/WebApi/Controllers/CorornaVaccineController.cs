using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorornaVaccineController : ControllerBase
    {
        private readonly IService<CorornaVaccineDto> service;
        public CorornaVaccineController(IService<CorornaVaccineDto> service)
        {
            this.service = service;
        }

        // GET: api/<CorornaVaccineController>
        [HttpGet]
        public List<CorornaVaccineDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<CorornaVaccineController>/5
        [HttpGet("{id}")]
        public CorornaVaccineDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CorornaVaccineController>
        [HttpPost]
        public CorornaVaccineDto Post([FromBody] CorornaVaccineDto value)
        {
            return service.Add(value);
        }

        // PUT api/<CorornaVaccineController>/5
        [HttpPut("{id}")]
        public CorornaVaccineDto Put(int id, [FromBody] CorornaVaccineDto value)
        {
            return service.Update(id, value);
        }

        // DELETE api/<CorornaVaccineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}

