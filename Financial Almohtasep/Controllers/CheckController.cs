using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Base;
using Financial_Almohtasep.Models.Checks;
using Financial_Almohtasep.Models.Pyees;
using Financial_Almohtasep.Services.CheckServices;
using Financial_Almohtasep.Services.PayeeServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class CheckController(ICheckServices checkServices,IPayeeServices payeeServices) : Controller
    {
        private readonly  ICheckServices _checkServices=checkServices;
        private readonly IPayeeServices _payeeServices=payeeServices;
        
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
           
            var payees = await _payeeServices.GetNames();
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
            var payees = await _payeeServices.GetNames();
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
        
        public async Task<IActionResult> View(Guid Id)
        {
            var checks= await _checkServices.GetById(Id);
            if(checks == null)
            {
                NotificationHelper.Alert(TempData, false, "error");
                return RedirectToAction("index");
            }
            var payee=await _payeeServices.GetById(checks.PayeeID);
            if(payee == null)
            {
                NotificationHelper.Alert(TempData, false, "error");
                return RedirectToAction("index");
            }
            var model = new CheckeView()
            {
                Check = checks,
                Payee = payee
            };
            return View(model);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Edit (Guid Id)
        {
            if(Id== Guid.Empty)
            {
                NotificationHelper.Alert(TempData, false, "خطاء ");
                return RedirectToAction("Index");
            }
            var check =await _checkServices.GetById(Id);
            if (check == null) 
            {
                NotificationHelper.Alert(TempData, false, "خطاء ");
                return RedirectToAction("Index");
            }
            var payee = await _payeeServices.GetNames();
            if(payee == null|| payee.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "ارجو ادخال مستفيد اولا");
                return RedirectToAction("AddPayee");
            }
            var model = new CheckDtoModel()
            {
                CheckNumber = check.CheckNumber,
                Amount = check.Amount,
                DueDate = check.DueDate,
                Bank = check.Bank,
                Currency = check.Currency,
                PayeeId=check.PayeeID,
                BaseIdNames = payee
            };
            return View(model);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(CheckDtoModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                if (model is null)
                {
                    NotificationHelper.Alert(TempData, false, "خطاء ");
                    return RedirectToAction("Index");
                }
                var result = await _checkServices.Edit(model, id);
                if (result == 0)
                {
                    NotificationHelper.Alert(TempData, false, "خطاء ");
                    return RedirectToAction("Index");
                }
                NotificationHelper.Alert(TempData, true, "تم التعديل بنجاح  ");
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _checkServices.Delete(id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                return RedirectToAction("Index");
            }
            NotificationHelper.Alert(TempData, false, "تم الحذف  بنجاح ");
            return RedirectToAction("Index");
        }
        #endregion
    }

}
