using Financial_Almohtasep.Data;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Dto.Clinets;
using Financial_Almohtasep.Models.Dto.Clinets.ClinetTransactions;
using Financial_Almohtasep.Models.Dto.Employees.Transaction;
using Financial_Almohtasep.Services.ClinetServices;
using Financial_Almohtasep.Services.ClinetServices.ClinetTransactionServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class ClinetTransactionController(IClinetService clinetService, IClinetTransactionService clinetTransaction) : Controller
    {
        private readonly IClinetService _clinetService = clinetService;
        private readonly IClinetTransactionService _clinetTransaction = clinetTransaction;

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index(Guid? ClinetId, DateTime? StartDate, DateTime? EndDate)
        {

            List<ClinetTransactionDto> Data = await _clinetTransaction.GetAllClinets(ClinetId, StartDate, EndDate);
            if (Data.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
            }

            var Clinetresults = await _clinetService.GetNames();
            if (Clinetresults == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add clinet Firstly !");
                return View();
            }
            ViewBag.clinetName = Clinetresults;
            ViewBag.ClinetId = ClinetId;
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;
            //if (ClinetId is not null)
                //return View("View", Data);
            return View("Index", Data);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid ClientId)
        {
            var Clinetresults = await _clinetService.GetNames();
            if (Clinetresults == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return View();
            }
            ViewBag.clinetName = Clinetresults;
            ClinetTransactionDtoAdd model = new()
            {
                ClinetId = ClientId
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClinetTransactionDtoAdd model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }
            var Results = await _clinetTransaction.Add(model);
            if (Results == 0)
            {
                NotificationHelper.Alert(TempData, false, "Error occurred !");
                return View();
            }
            NotificationHelper.Alert(TempData, true, "Added ٍuccessfully !");
            return RedirectToAction("Index");
        }
        #endregion
    }
}
