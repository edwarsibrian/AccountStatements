using AccountStatements.Interfaces;
using AccountStatements.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccountStatements.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountStatementsClient _accountStatementsClient;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger, 
            IAccountStatementsClient accountStatementsClient,
            IMapper mapper)
        {
            _logger = logger;
            _accountStatementsClient = accountStatementsClient;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var creditCards = _accountStatementsClient.GetAllCreditCards().Result;

            return View(_mapper.Map<List<CreditCardsList>>(creditCards));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
