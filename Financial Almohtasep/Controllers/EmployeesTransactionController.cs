using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Dto.Employees.Transaction;
using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Services.EmployeeServices.TransactionServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeesTransactionController(IEmployeeService employeeService, IEmployeeTransactionServices transactionServices) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IEmployeeTransactionServices _transactionServices = transactionServices;

        [HttpGet]
        public async Task<IActionResult> Index(Guid? EmployeeId, DateTime? StartDate, DateTime? EndDate)
        {
            var TransactionResults = await _transactionServices.GetAllEmployees(EmployeeId, StartDate, EndDate);
            if (TransactionResults.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
            }
            EmployeeTransactionDtoModel Model = new()
            {
                EmployeeTransaction = TransactionResults,
                BaseIdNameModel = await _employeeService.GetNames()
            };
            ViewBag.EmployeeId = EmployeeId;
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            return View("View", Model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid EmployeeId)
        {
            var Employeeresults = await _employeeService.GetNames();
            if (Employeeresults == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return View();
            }
            EmployeeTransactionViewModel Model = new()
            {
                BaseIdNameModels = Employeeresults,
                EmployeeId = EmployeeId
            };
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeTransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }
            var Results = await _transactionServices.Add(model);
            if (Results == 0)
            {
                NotificationHelper.Alert(TempData, false, "Error occurred !");
                return View();
            }
            NotificationHelper.Alert(TempData, true, "Added ٍuccessfully !");
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employeeName = await _employeeService.GetNames();
            if (employeeName == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return RedirectToAction("View");
            }
            var TransactionResults = await _transactionServices.GetById(id);
            if (TransactionResults == null)
            {
                NotificationHelper.Alert(TempData, false, "Transaction Doesn't exist");
                return RedirectToAction("View");
            }
            EmployeeTransactionViewModel model = new()
            {
                SalaryChange = TransactionResults.SalaryChange,
                TransactionDate = TransactionResults.TransactionDate,
                TransactionType = TransactionResults.TransactionType,
                Note = TransactionResults.Note,
                BaseIdNameModels = employeeName
            };
            return View(model);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(Guid id, EmployeeTransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }
            var result = await _transactionServices.Edit(id, model);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }
            NotificationHelper.Alert(TempData, true, "تم التعديل بنجاح ");
            return RedirectToAction("View");
        }
    }
}
