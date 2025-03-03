using Academy_2025.Data;
using Academy_2025.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _repository;

        public UsersController()
        {
            _repository = new UserRepository();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _repository.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            _repository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            var user = _repository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _repository.Delete(id);

            return result ? NoContent() : NotFound();
        }

        [Route("above18")]
        [HttpGet]
        public IEnumerable<User> GetAbove18()
        {
            return _repository.GetUsersAbove18();
        } 
    }
}
