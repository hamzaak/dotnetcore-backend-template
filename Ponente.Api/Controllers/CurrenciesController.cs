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
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Currency>> GetAll()
        {
            return _currencyService.GetAll();
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Currency> Get([FromQuery] int id)
        {
            return _currencyService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Currency> Add([FromBody] Currency currency)
        {
            return _currencyService.Add(currency);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<Currency> Update([FromBody] Currency currency)
        {
            return _currencyService.Update(currency);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromQuery] int id)
        {
            _currencyService.Delete(id);
        }
    }
}