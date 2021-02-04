using Atom.ApiService.IService;
using Atom.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Atom.Api.Controllers
{
    [Route("api/atomtransaction")]
    [ApiController]
    public class AtomTransactionApiController : ControllerBase
    {
        private IAtomAccountService atomAccountService { get; set; }
        
        public AtomTransactionApiController(IAtomAccountService atomAccountService)
        {
            this.atomAccountService= atomAccountService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Balance(long id)
        {
            var banlance = await this.atomAccountService.Balance(id);
            if (banlance == null)
                return BadRequest();
            return Ok(banlance);
        }
        [HttpPut("deposit")]
        public async Task<IActionResult>Deposit([FromBody] AccountDto accountDto)
        {
            var deposit = await this.atomAccountService.Deposit(accountDto);
            if (deposit == null)
                return BadRequest();
            return Ok(deposit);
        }
        [Route("Withdraw")]
        [HttpGet()]
        public async Task<IActionResult> Widthdraw([FromBody] AccountDto accountDto)
        {
            var widthdraw = await this.atomAccountService.Widthdraw(accountDto);
            if (widthdraw == null)
                return BadRequest();
            return Ok(widthdraw);
        }
    }
}
