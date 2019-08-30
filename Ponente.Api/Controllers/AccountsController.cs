using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ponente.Business.Abstract;
using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Account>> GetAll()
        {
            return _accountService.GetAll();
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Account> Get([FromQuery] int id)
        {
            return _accountService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Account> Add([FromBody] Account account)
        {
            return _accountService.Add(account);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<Account> Update([FromBody] Account account)
        {
            return _accountService.Update(account);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromQuery] int id)
        {
            _accountService.Delete(id);
        }
    }
}