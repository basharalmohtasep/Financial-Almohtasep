using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Check;
using Financial_Almohtasep.Services.CheckServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class CheckController(ICheckServices checkServices) : Controller
    {
        readonly private ICheckServices _checkServices=checkServices;
        #region Method
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var checks = await _checkServices.GetAll();
            if (checks == null || checks.Count == 0)
            { 
                NotificationHelper.Alert(TempData, false, "No checks found!");
                return View();
            }
           
            var payees = await _checkServices.GetPayeesName();
            if (payees == null || payees.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "No payees found!");
                return View(); 
            }
            
            CheckDto checkDto = new()
            {
                Checks = checks,
                BaseIdNameModel = payees 
            };

            return View(checkDto);
        }
       
        public async Task<IActionResult> Add(CheckViewModel model)
        {
            var payees = await _checkServices.GetPayeesName();
            if (payees == null || payees.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "ارجو ادخال مستفيد اولا");
                return RedirectToAction("AddPayee");
            }
            var model1 = new CheckViewModel()
            {
                BaseIdNames = payees
            };

            if (ModelState.IsValid) 
            {
                if(model is null)
                {
                    NotificationHelper.Alert(TempData, false, "Erorr");
                    return View(model);
                }
                await _checkServices.Add(model);
                NotificationHelper.Alert(TempData, true, "تم الاضافة بنجاح");
                return RedirectToAction("Index");
            }
            return View(model1);
        }
        
        public async Task<IActionResult> AddPayee(PayeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is null)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                    return View(model);
                }
                await _checkServices.AddPayee(model);
                NotificationHelper.Alert(TempData, true, "تم الاضافة بنجاح");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        #endregion
    }

}
