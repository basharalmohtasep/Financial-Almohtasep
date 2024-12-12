using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Services.TransactionServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeesTransactionController(IEmployeeService employeeService, ITransactionServices transactionServices) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ITransactionServices _transactionServices = transactionServices;

        #region Methods
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var AllEmployeesTransaction = await _transactionServices.GetAllEmployees();
        //    if (AllEmployeesTransaction == null)
        //    {
        //        NotificationHelper.Alert(TempData, false, "لا يوجد اي حركات  ");
        //        return RedirectToAction("Index", "Employee");
        //    }
        //    else
        //    {
        //        var EmployeeName = await _employeeService.ListName();
        //        if (EmployeeName == null)
        //        {
        //            NotificationHelper.Alert(TempData, false, "  لا يوجد موظفين يرجاء اضافة موظف ");
        //            return RedirectToAction("AddTransaction", "Employee");
        //        }
        //        else
        //        {
        //            EmployeeTransactionDtoModel employeeTransactionDtoModel = new()
        //            {
        //                EmployeeTransaction = AllEmployeesTransaction,
        //                BaseIdNameModel = EmployeeName
        //            };
        //            return View(employeeTransactionDtoModel);
        //        }

        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        //{
        //    // Get filtered employee transactions based on startDate and endDate
        //    var filteredTransactions = await _transactionServices.GetFilteredEmployeeTransactions(startDate, endDate);

        //    if (filteredTransactions == null || !filteredTransactions.Any())
        //    {
        //        NotificationHelper.Alert(TempData, false, "لا يوجد أي حركات ضمن الفترة المحددة.");
        //        return RedirectToAction("Index");
        //    }

        //    // Get all employee names
        //    var employeeNames = await _employeeService.ListName();

        //    if (employeeNames == null || !employeeNames.Any())
        //    {
        //        NotificationHelper.Alert(TempData, false, "لا يوجد موظفين، يرجى إضافة موظف.");
        //        return RedirectToAction("AddTransaction", "Employee");
        //    }

        //    // Prepare the DTO model for the view
        //    EmployeeTransactionDtoModel employeeTransactionDtoModel = new()
        //    {
        //        EmployeeTransaction = filteredTransactions,
        //        BaseIdNameModel = employeeNames
        //    };

        //    return View(employeeTransactionDtoModel);
        //}



        //[HttpGet("{id}")]
        //public async Task<IActionResult> EmployeeTransaction(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        NotificationHelper.Alert(TempData, false, "حدث خطاء ");
        //        return View();
        //    }
        //    else
        //    {
        //        var Employee = await _employeeService.ListName();
        //        if (Employee == null)
        //        {
        //            NotificationHelper.Alert(TempData, false, "هذا الموظف غير موجود ");
        //            return View();
        //        }
        //        else
        //        {
        //            var Transaction = await _transactionServices.GetTransactionByEmployeeId(id);
        //            if (Transaction == null)
        //            {
        //                NotificationHelper.Alert(TempData, false, "هذا الموظف ليس لدي حركات ");
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                EmployeeTransactionDtoModel model = new()
        //                {
        //                    EmployeeTransaction = Transaction,
        //                    BaseIdNameModel = Employee
        //                };
        //                return View(model);
        //            }
        //        }
        //    }


        //}
        //[HttpPost("{id}")]
        //public async Task<IActionResult> EmployeeTransaction(Guid? SelectedEmployeeId, DateTime? StartDate, DateTime? EndDate)
        //{

        //    var filteredTransactions = await _transactionServices.GetFilteredEmployeeTransactions(SelectedEmployeeId, StartDate, EndDate);
        //    var Employee = await _employeeService.ListName();
        //    if (Employee == null)
        //    {
        //        NotificationHelper.Alert(TempData, false, "هذا الموظف غير موجود ");
        //        return View();
        //    }
        //        EmployeeTransactionDtoModel model = new()
        //    {
        //        EmployeeTransaction = filteredTransactions,
        //        BaseIdNameModel= Employee
        //    };
        //    if (SelectedEmployeeId == null || SelectedEmployeeId == Guid.Empty)
        //    {
        //        NotificationHelper.Alert(TempData, false, "يرجاء اداخل اسم الوظف الذي تبحث عنه ");
        //        return View(model);
        //    }
        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<IActionResult> AddTransaction()
        //{
        //    var employees = await _employeeService.ListName();
        //    if (employees == null)
        //    {
        //        NotificationHelper.Alert(TempData, false, "يجب اضافة موظف قبل اضافة حركة ");
        //        return RedirectToAction("AddEmployee", "EmployeeController");
        //    }
        //    else
        //    {
        //        ViewBag.EmployeeList = employees;
        //        return View();
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddTransaction(EmployeeTransactionViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model == null)
        //        {
        //            NotificationHelper.Alert(TempData, false, "حدث خطاء يرجاء ادخال معلومات الحركة ");
        //            return View();
        //        }
        //        else
        //        {
        //            var employees = await _employeeService.ListName();
        //            if (employees == null)
        //            {
        //                NotificationHelper.Alert(TempData, false, "يجب اضافة موظف قبل اضافة حركة ");
        //                return RedirectToAction("AddEmployee", "EmployeeController");
        //            }
        //            else
        //            {
        //                ViewBag.EmployeeList = employees;
        //                var Transaction = await _transactionServices.AddEmployeeTransaction(model);
        //                if (Transaction == 0)
        //                {
        //                    NotificationHelper.Alert(TempData, false, " يرجاء التاكد من راتب الموظف  ");
        //                    return RedirectToAction("Index", "EmployeeController");
        //                }
        //                else
        //                {
        //                    NotificationHelper.Alert(TempData, true, "تم الاضافة بنجاح");
        //                    return RedirectToAction("Index");
        //                }
        //            }

        //        }

        //    }
        //    else
        //    {
        //        NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
        //        return View(model);
        //    }
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> EditTransaction(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        NotificationHelper.Alert(TempData, false, "حدث خطاء");
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        var EmployeeName = await _employeeService.ListName();
        //        if (EmployeeName == null)
        //        {
        //            NotificationHelper.Alert(TempData, false, "يجب اضافة موظف قبل اضافة حركة ");
        //            return RedirectToAction("AddEmployee", "EmployeeController");
        //        }
        //        else
        //        {
        //            var Transaction = await _transactionServices.GetTransactionById(id);
        //            if (Transaction == null)
        //            {
        //                NotificationHelper.Alert(TempData, false, "هذا الحركة غير موجودة  ");
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                ViewBag.EmployeeList = EmployeeName;
        //                var model = new EmployeeTransactionViewModel
        //                {
        //                    Amount = Transaction.Amount,
        //                    TransactionDate = Transaction.TransactionDate,
        //                    TransactionType = Transaction.TransactionType,
        //                };
        //                return View(model);
        //            }
        //        }
        //    }

        //}

        //[HttpPost("{id}")]
        //public async Task<IActionResult> Edit(EmployeeTransactionViewModel model, Guid id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == Guid.Empty)
        //        {
        //            NotificationHelper.Alert(TempData, false, "حدث خطاء");
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            var result = await _transactionServices.EditEmployeeTransaction(model, id);
        //            if (result == 0)
        //            {
        //                NotificationHelper.Alert(TempData, false, " خدث خطاء هذا الجركة غير موجودة ");
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                NotificationHelper.Alert(TempData, true, " تم التعديل بناجح  ");
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
        //        return View(model);
        //    }



        //}
        //public async Task<IActionResult> DeleteTransaction(Guid id)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        NotificationHelper.Alert(TempData, false, "هذا الحركه غير موجود ");
        //        return View();
        //    }
        //    else
        //    {
        //        var result = await _transactionServices.DeleteEmployeTransactione(id);
        //        if (result == 0)
        //        {
        //            NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
        //            return RedirectToAction("Index");
        //        }

        //        NotificationHelper.Alert(TempData, true, "تم الحذف بنجاح");
        //        return RedirectToAction("Index");
        //    }
        //}

        #endregion
    }
}
