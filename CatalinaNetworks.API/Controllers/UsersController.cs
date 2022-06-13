using CatalinaNetworks.API.Models;
using CatalinaNetworks.Core.Models;
using CatalinaNetworks.Core.Models.Paggination;
using CatalinaNetworks.Core.Services;
using Microsoft.AspNetCore.Mvc;

// Пока слои логики не реализованы, контроллер использует методы контекста
// контекста базы данных напрямую для тестирования frontend части

namespace CatalinaNetworks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QuerryParameters querryParameters)
        {
            var users = await _service.Get(querryParameters);
            var page = new UsersPageContract(users);
            return Ok(page);
        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public async Task<IEnumerable<User>> Get()
        //{
        //    throw new NotImplementedException();
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public async Task<User> Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public async Task<int> Post([FromBody] User newUser)
        //{
        //    throw new NotImplementedException();
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //    throw new NotImplementedException();
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
