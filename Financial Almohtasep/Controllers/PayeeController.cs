using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Pyees;
using Financial_Almohtasep.Services.PayeeServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class PayeeController(IPayeeServices payeeServices) : Controller
    {
        private readonly IPayeeServices _payeeServices = payeeServices;

        #region Method
        [HttpGet]
        public async Task<IActionResult> Index(Guid? id)
        {
            ViewBag.Payees = await _payeeServices.GetAll();
            var payee = await _payeeServices.GetAll(id);
            if (payee == null || payee.Count == 0)
            {
                NotificationHelper.Alert(TempData, false, "No Payee found!");
                return RedirectToAction("Add");
            }
            var model = new PayeeDtoModel()
            {
                Payee = payee
            };
            ViewBag.PaeeyId = id;
            return View(model);
        }
        public async Task<IActionResult> Add(PayeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model is null)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                    return View(model);
                }
                var result =await _payeeServices.Add(model);
                if (result == 0)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                    return View(model);
                }
                NotificationHelper.Alert(TempData, true, "تم الاضافة بنجاح");
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                return View();
            }
            var payee = await _payeeServices.GetById(id);
            if (payee == null)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                return RedirectToAction("Index");
            }
            var model = new PayeeViewModel()
            {
                Name = payee.Name,
                Note = payee.Note,
                Type = payee.Type,
            };
            return View(model) ;

        }
        

        
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(PayeeViewModel model,Guid Id)
        {
            if (ModelState.IsValid)
            {
                if(model is null)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                    return View(model);
                }
                var result=await _payeeServices.Edit(model,Id);
                if (result == 0)
                {
                    NotificationHelper.Alert(TempData, false, "حدث خطاء غير متواقع ");
                    return View(model);
                }
                NotificationHelper.Alert(TempData, false, "تم التعديل بنجاح ");
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
          var result= await _payeeServices.Delete(id);
            if(result == 0)
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
