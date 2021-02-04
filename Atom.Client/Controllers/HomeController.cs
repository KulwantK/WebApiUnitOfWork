using Atom.Client.IService;
using Atom.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Atom.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAtomTransactionClientService _service;
        public HomeController(ILogger<HomeController> logger, IAtomTransactionClientService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.Balance(2);
            ViewModel viewModel = new ViewModel { AccountNumber = model.AccountNumber };
            return View(viewModel);
        }
        public async Task<IActionResult> Balance(ViewModel model)
        {
            var viewModel = await _service.Balance(model.AccountNumber);
            viewModel.ShowBalance = true;
            viewModel.Message = string.Empty;
            return View("index",viewModel);
        }
        
        public async Task<IActionResult> Deposit(ViewModel model)
        {
            var viewModel = await _service.Deposit(model);
            viewModel.Amount = 0;
            return View("index", viewModel);
        }
        public async Task<IActionResult> Widthdraw(ViewModel model)
        {
            var viewModel = await _service.Widthdraw(model);
            viewModel.Amount = 0;
            return View("index",viewModel);
        }
    }
}
