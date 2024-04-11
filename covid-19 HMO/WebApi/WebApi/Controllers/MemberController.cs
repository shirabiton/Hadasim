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
            MemberDto member = service.GetById(id);
            if (member.ImageUrl != null) { 

                member.ImageUrl = GetImage(member.ImageUrl);
            }
            return member;
        }


        [HttpPost]

        // task-אסינכרוני
        public async Task<MemberDto> Post([FromForm] MemberDto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (item.Image != null)
            {
                var image = item.Image;
                var path = Path.Combine(Environment.CurrentDirectory, "Images/members/", image.FileName);
                item.ImageUrl = path;

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                    stream.Close();
                }
            }

            return service.Add(item);
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public async Task<MemberDto> Put(int id, [FromForm] MemberDto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (item.Image != null)
            {
                var image = item.Image;
                var path = Path.Combine(Environment.CurrentDirectory, "Images/members/", image.FileName);
                item.ImageUrl = path;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                    stream.Close();
                }
            }
            return service.Update(id, item);
        }


        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }


        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Images/members/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }

    }
}
