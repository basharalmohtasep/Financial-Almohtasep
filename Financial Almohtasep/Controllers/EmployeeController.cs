using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.AspNetCore.Mvc;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Services;
using System;
using System.Threading.Tasks;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        #region Constructor
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Methods

        // Index: Display all employees
        public async Task<IActionResult> Index()
        {
            ViewBag.Data = await _employeeService.GetAllEmployeesAsync();
            return View();
        }

        // Add Employee (GET)
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        // Add Employee (POST)
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
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

            var result = await _employeeService.AddEmployeeAsync(model);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم الإضافة بنجاح");
            return RedirectToAction("Index");
        }

        // Edit Employee (GET)
        [HttpGet("{id}")]
        public async Task<IActionResult> EditEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
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

        // Edit Employee (POST)
        [HttpPost("{id}")]
        public async Task<IActionResult> EditEmployee(EmployeeDtoModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _employeeService.EditEmployeeAsync(model, id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم التعديل بنجاح");
            return RedirectToAction("Index");
        }

        // Delete Employee
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
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
