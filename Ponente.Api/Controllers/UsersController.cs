using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ponente.Business.Abstract;
using Ponente.Entity.Concrete;

namespace Ponente.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        // GET api/values/hamza/1111
        [HttpGet]
        [Route("get")]
        public ActionResult<User> Get([FromBody] User user)
        {
            return _userService.Get(user.Username, user.Password);
        }
        
        [HttpGet]
        [Route("getall")]
        public ActionResult<List<User>> Get()
        {
            return _userService.GetAll();
        }

        // POST api/values
        [HttpPost]
        [Route("add")]
        public void Add([FromBody] User user)
        {
            _userService.Add(user);
        }
    }
}
