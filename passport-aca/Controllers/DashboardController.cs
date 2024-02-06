using Microsoft.AspNetCore.Mvc;
using passport_aca.Data;
using passport_aca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passport_aca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        private readonly IAdministratorInterface _user;
        private readonly ITransactionInterface _transactions;

        public DashboardController(IAdministratorInterface user,ITransactionInterface transactions)
        {
            _user = user;
            _transactions = transactions;
        }

        [HttpGet]
        [Route("Numbers_Of_Reports")]
        public async Task<ActionResult<Numbers_Of_Reports>> Numbers_Of_Reports()
        {

            Numbers_Of_Reports count = await _transactions.Numbers_Of_Reports();
            if(count!=null)
            return Ok(count);

            return NoContent();
        }

        [HttpGet]
        [Route("LastFiveTransactions")]
        public async Task<ActionResult<List<TransactionViewModel>>> LastFiveTransactions()
        {
            
        var list =await _transactions.GetLastFive();
            if(list.Count>0)

            return list;
            return NotFound(new MassageInfo(){ Massage="لايوجد بيانات ",statuscode=404});

        }
    }
}
