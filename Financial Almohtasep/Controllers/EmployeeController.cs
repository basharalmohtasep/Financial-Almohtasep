using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.AspNetCore.Mvc;
using Financial_Almohtasep.Helper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financial_Almohtasep.Services.EmployeeService;
using Financial_Almohtasep.Services.TransactionServices;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        #region Constructor
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;
        private readonly ITransactionServices _transactionServices;
        public EmployeeController(IEmployeeService employeeService, ApplicationDbContext context, ITransactionServices transactionServices)
        {
            _employeeService = employeeService;
            _context = context;
            _transactionServices = transactionServices;
        }
        #endregion

        #region Methods

        public async Task<IActionResult> Index()
        {
            ViewBag.Data = await _employeeService.GetAllEmployees();
            return View();
        }


        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }


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

            var result = await _employeeService.AddEmployee(model);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم الإضافة بنجاح");
            return RedirectToAction("Index");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> EditEmployee(Guid id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
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
        public async Task<IActionResult> EditEmployee(EmployeeDtoModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _employeeService.EditEmployee(model, id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم التعديل بنجاح");
            return RedirectToAction("Index");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return RedirectToAction("Index");
            }

            NotificationHelper.Alert(TempData, true, "تم الحذف بنجاح");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> AddTransaction()
        {
            var employees = await _employeeService.GetAllEmployees();
            ViewBag.EmployeeList = employees;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTransaction(EmployeeTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء ");
                    return View();
                }
                else
                {
                    var employees = await _employeeService.GetAllEmployees();
                    if (employees == null)
                    {
                        NotificationHelper.Alert(TempData, false, "يجب اضافة موظف قبل اضافة حركة ");
                        return View();
                    }
                    else
                    {
                        ViewBag.EmployeeList = employees;
                        var Transaction = await _transactionServices.AddEmployeeTransaction(model);
                        if (Transaction == 0)
                        {
                            NotificationHelper.Alert(TempData, false, "حدث خطاء ");
                            return View();
                        }
                        else
                        {
                            NotificationHelper.Alert(TempData, true, "تم الاضافة بنجاح");
                            return RedirectToAction("Index");
                        }
                    }

                }

            }
            else
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeeTransaction(Guid id)
        {

            // Fetch the employee asynchronously
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View();
            }

            // Fetch employee transactions asynchronously
            var employeeTransactions = await _context.EmployeeTransaction
                                                      .Where(x => x.EmployeeId == id)
                                                      .ToListAsync();

            if (employeeTransactions == null || !employeeTransactions.Any())
            {
                NotificationHelper.Alert(TempData, false, "هذا الموظف ليس لديه حركات سحب");
                return RedirectToAction("Index");
            }

            // Pass the transactions to the view
            ViewBag.TransactionDate = employeeTransactions;
            ViewBag.Salary = await _context.EmployeeNetSalaries.FindAsync(id);
            return View();
        }


    }

    #endregion
}

