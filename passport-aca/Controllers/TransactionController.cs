using Microsoft.AspNetCore.Mvc;
using passport_aca.Data;
using passport_aca.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace passport_aca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller

    { 
         public TransactionController(ITransactionInterface transaction)
    {
        _transaction = transaction;
    }
        public ITransactionInterface _transaction { get; }

        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<ActionResult<PageingDtocs>> GetAllTransactions(int page,int pagesize)
        {
            PageingDtocs  list =await _transaction.GetAll(page,pagesize);
            if(list.TransactionList.Count>0)
            return Ok(list);

            return BadRequest(new MassageInfo() { Massage="لايوجد بيانات ",statuscode=400});

        }
        [HttpGet]
        [Route("Search")]

        public async Task<ActionResult<SearchModel>> Search(string search)
        {
            SearchModel transaction = await _transaction.search(search);
            return Json(transaction);
        }
        [HttpGet]
        [Route("GetTransaction/{id}")]

        public async Task<ActionResult<TransactionInfo>> GetTransaction(int id)
        {
            var transaction = await _transaction.GetTransaction(id);

            if(transaction!=null)
            return Json(transaction);
            return NotFound(new MassageInfo() { Massage="لايوجد معاملمة",statuscode=404});
        }


        [HttpPost]
        [Route("AddTransaction")]

        public async Task<ActionResult<MassageInfo>> AddTransaction([FromBody] TransactionInfo transactionInfo)
        {
            MassageInfo nn = await _transaction.AddTransaction(transactionInfo);
            if (nn.statuscode == 201) {
                return Created("AddTransaction", nn);
            }
            else if (nn.statuscode == 406) {

                return StatusCode(406,nn);
            } else {
                return NotFound(new MassageInfo() { Massage = "حدث خطأ", statuscode = 404 });
            } }

        [HttpDelete]
        [Route("DeleteTransaction/{id}")]

        public async Task<ActionResult<MassageInfo>> DeleteTransaction(int id)
        {
           
          MassageInfo nn=  await _transaction.DeleteTransaction(id);
            if (nn.statuscode == 200)
            {
                return Ok(nn);

            }
            else {
                if (nn.statuscode == 404)
                {
                    return StatusCode(404,nn);

                }

            }
            return NotFound(new MassageInfo() { Massage = "خطأ", statuscode = 404 });
        }

        [HttpPut]
        [Route("UpdateTransaction")]

        public async Task<ActionResult<MassageInfo>> UpdateTransaction([FromBody] TransactionInfo transaction)
        {
         MassageInfo nn  = await _transaction.UpdateTransaction(transaction);
            if(nn.statuscode==203)
            return  StatusCode(203,nn);


            return NotFound(nn);

        }


        [HttpGet]
        [Route("UsersReport")]
        public async Task<ActionResult<ReportDto>> UsersReport(int page, int pageSize) {

          var list = await _transaction.UsersReport(page,pageSize);
            if(list.List.Count>0)
             return Json(list);
            return NotFound(new MassageInfo() { Massage = "لايوجد بيانات", statuscode = 404 });
        }
    }
}
