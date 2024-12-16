using Microsoft.AspNetCore.Mvc;
using Financial_Almohtasep.Services.ChequeDetailServices;
using Financial_Almohtasep.Models.Cheque;
using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Employees;
using Microsoft.EntityFrameworkCore;
namespace Financial_Almohtasep.Controllers
{
    public class ChequeController(IChequeDetailsService chequeDetails) : Controller
    {
        private readonly IChequeDetailsService _chequeDetailsService = chequeDetails;
        #region Methods
        public async Task<IActionResult> Index()
        {

            var Data = await _chequeDetailsService.GetAll();
            ViewBag.Data = Data;
            return View();
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.data = await _chequeDetailsService.GetAllPayees();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ChequeDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _chequeDetailsService.Add(model);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return View(model);
            }

            NotificationHelper.Alert(TempData, true, "تم الإضافة بنجاح");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddPayee()
        {
            return View();
        }
        public async Task<IActionResult> AddPayee(PayeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _chequeDetailsService.Addpayee(model);
                if (result == 0)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                    return View(model);
                }
                return RedirectToAction("Add", "Cheque");

            }
            return View(model);
        }
    }
}
