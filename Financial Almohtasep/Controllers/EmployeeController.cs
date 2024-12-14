using Microsoft.AspNetCore.Mvc;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Services.TransactionServices;
using Financial_Almohtasep.Services.EmployeeServices;
using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models.Employees;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController(IEmployeeService employeeService, ITransactionServices transactionServices) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ITransactionServices _transactionServices = transactionServices;

        #region Methods

        public async Task<IActionResult> Index()
        {
            List<EmployeeDto> Data = await _employeeService.GetAllWithFinalAmout();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            if (model.HireDate > DateTime.Now)
            {
                NotificationHelper.Alert(TempData, false, "تاريخ التوظيف أكبر من تاريخ اليوم");
                return View(model);
            }

            var result = await _employeeService.Add(model);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم الإضافة بنجاح");
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            
            var employee = await _employeeService.GetById(id);
            if (employee == null)
            {
                NotificationHelper.Alert(TempData, false, "الموظف غير موجود");
                return RedirectToAction("Index");
            }

            var model = new EmployeeDtoModel
            {
                FName = employee.FName,
                LName = employee.LName,
                PhoneNumper = employee.PhoneNumper,
                Salary = employee.Salary,
                HireDate = employee.HireDate,
            };

            return View(model);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(EmployeeDtoModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _employeeService.Edit(model, id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم التعديل بنجاح");
            return RedirectToAction("Index");
        }
        
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _employeeService.Delete(id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return RedirectToAction("Index");
            }

            NotificationHelper.Alert(TempData, true, "تم الحذف بنجاح");
            return RedirectToAction("Index");
        }
        #endregion
    }
}

