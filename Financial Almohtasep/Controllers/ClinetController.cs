using Financial_Almohtasep.Helper;
using Financial_Almohtasep.Models.Dto.Clinets;
using Financial_Almohtasep.Services.ClinetServices;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class ClinetController(IClinetService ClinetService) : Controller
    {
        private readonly IClinetService _ClinetService = ClinetService;

        public async Task<IActionResult> Index()
        {
            List<ClinetDto> Data = await _ClinetService.GetAll();
            return View(Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClinetDtoAdd model)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _ClinetService.Add(model);
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
            var Clinet = await _ClinetService.GetById(id);
            if (Clinet == null)
            {
                NotificationHelper.Alert(TempData, false, "الموظف غير موجود");
                return RedirectToAction("Index");
            }

            return View(new ClinetDtoEdit(Clinet));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(ClinetDtoEdit model, Guid id)
        {
            if (id != model.Id)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء غير متوقع");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطاء في الإدخال");
                return View(model);
            }

            var result = await _ClinetService.Edit(model, id);
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
            var result = await _ClinetService.Delete(id);
            if (result == 0)
            {
                NotificationHelper.Alert(TempData, false, "حدث خطأ غير متوقع");
                return RedirectToAction("Index");
            }

            NotificationHelper.Alert(TempData, true, "تم الحذف بنجاح");
            return RedirectToAction("Index");
        }
    }
}

