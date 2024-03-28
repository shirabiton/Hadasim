using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IService<MemberDto> service;

        public MemberController(IService<MemberDto> service)
        {
            this.service = service;            
        }

        // GET: api/<MemberController>
        [HttpGet]
        public List<MemberDto> Get()
        {
            return service.GetAll();
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public MemberDto Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<MemberController>
        [HttpPost]
        public MemberDto Post([FromBody] MemberDto value)
        {
            return service.Add(value);
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public MemberDto Put(int id, [FromBody] MemberDto value)
        {
            return service.Update(id, value);
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
