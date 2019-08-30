using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ponente.Business.Abstract;
using Ponente.Entity.Concrete;
using Ponente.Entity.DTO;
using System.Collections.Generic;

namespace Ponente.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<TransactionResponseDTO> GetAll([FromQuery] string query)
        {
            var dto = JsonConvert.DeserializeObject<TransactionRequestDTO>(query);
            return _transactionService.GetAll(dto);
        }

        [HttpGet]
        [Route("getsumsbyaccount")]
        public ActionResult<List<TransactionSumByAccountDTO>> GetSumsByAccount()
        {
            return _transactionService.GetSumsByAccount();
        }

        [HttpGet]
        [Route("getsumsbydate")]
        public ActionResult<List<TransactionSumByDateDTO>> GetSumsByDate()
        {
            return _transactionService.GetSumsByDate();
        }

        [HttpGet]
        [Route("gettransactionreport")]
        public ActionResult<List<TransactionSumByDateDTO>> GetTransactionReport([FromQuery] string query)
        {
            var dto = JsonConvert.DeserializeObject<TransactionRequestDTO>(query);
            return _transactionService.GetTransactionReport(dto);
        }

        [HttpGet]
        [Route("getaccountsreport")]
        public ActionResult<List<TransactionAccountsReportDTO>> GetAccountsReport()
        {
            return _transactionService.GetAccountsReport();
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Transaction> Get([FromQuery] string id)
        {
            return _transactionService.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Transaction> Add([FromBody] Transaction transaction)
        {
            return _transactionService.Add(transaction);
        }

        [HttpPost]
        [Route("transfer")]
        public void Transfer([FromBody] TransactionTransferDTO dto)
        {
            _transactionService.Transfer(dto);
        }

        [HttpPost]
        [Route("update")]
        public ActionResult<Transaction> Update([FromBody] Transaction transaction)
        {
            return _transactionService.Update(transaction);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete([FromQuery] string id)
        {
            _transactionService.Delete(id);
        }
    }
}