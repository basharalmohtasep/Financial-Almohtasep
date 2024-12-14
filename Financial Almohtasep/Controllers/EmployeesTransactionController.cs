using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Services.TransactionServices;
using Microsoft.AspNetCore.Mvc;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Employees;
using Financial_Almohtasep.Models.Enum;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeesTransactionController(IEmployeeService employeeService, ITransactionServices transactionServices) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ITransactionServices _transactionServices = transactionServices;

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var TransactionResults = await _transactionServices.GetAllEmployees();
            if (TransactionResults == null || TransactionResults.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
                return RedirectToAction("Index", "Home");
            }
            var Employeeresults = await _employeeService.GetNames();
            if (Employeeresults == null || Employeeresults.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return RedirectToAction("Index", "Home");
            }
            EmployeeTransactionDtoModel Model = new()
            {
                EmployeeTransaction = TransactionResults,
                BaseIdNameModel = Employeeresults

            };
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(DateTime? StartDate, DateTime? EndDate)
        {
            var TransactionResults = await _transactionServices.GetAllEmployees(null, StartDate, EndDate);
            if (TransactionResults == null)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
                return View();
            }
            var Employeeresults = await _employeeService.GetNames();
            if (Employeeresults == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return View();
            }
            EmployeeTransactionDtoModel Model = new()
            {
                EmployeeTransaction = TransactionResults,
                BaseIdNameModel = Employeeresults

            };
            return View(Model);

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var Employeeresults = await _employeeService.GetNames();
            if (Employeeresults == null)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return View();
            }
            EmployeeTransactionViewModel Model = new()
            {
                BaseIdNameModels = Employeeresults
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
        public async Task<IActionResult> View(Guid id)
        {
            var Employeeresults = await _employeeService.GetNames();
            if(Employeeresults == null || Employeeresults.Count==0)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return RedirectToAction("Index", "Home");
            }
            var TransactionResults = await _transactionServices.GetAllEmployees(id);
            if(TransactionResults == null)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
                return RedirectToAction("Index");
            }
            EmployeeTransactionDtoModel dtoModel = new()
            {
                EmployeeTransaction = TransactionResults,
                BaseIdNameModel = Employeeresults,

            };
            return View(dtoModel);

        }
        [HttpPost("{id}")]
        public async Task<IActionResult> View(Guid id, DateTime? StartDate , DateTime? EndDate )
        {
            var Employeeresults = await _employeeService.GetNames();
            if (Employeeresults == null || Employeeresults.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "Plaess add Employee Firstly !");
                return RedirectToAction("Index", "Home");
            }
            var TransactionResults = await _transactionServices.GetAllEmployees(id, StartDate, EndDate);
            if (TransactionResults == null)
            {
                NotificationHelper.Alert(TempData, false, "No Transaction found !");
                return RedirectToAction("Index");
            }
            EmployeeTransactionDtoModel dtoModel = new()
            {
                EmployeeTransaction = TransactionResults,
                BaseIdNameModel = Employeeresults,

            };
            return View(dtoModel);

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
            var TransactionResults= await _transactionServices.GetById(id);
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

        #endregion
    }
}
