using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ponente.Business.Abstract;
using Ponente.Entity.Concrete;

namespace Ponente.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectoryService _directoryService;

        public DirectoriesController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<Directory>> GetAll()
        {
            return _directoryService.GetAll();
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Directory> Get([FromQuery] int id)
        {
            return _directoryService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Directory> Add([FromBody] Directory directory)
        {
            return _directoryService.Add(directory);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<Directory> Update([FromBody] Directory directory)
        {
            return _directoryService.Update(directory);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromQuery] int id)
        {
            _directoryService.Delete(id);
        }
    }
}