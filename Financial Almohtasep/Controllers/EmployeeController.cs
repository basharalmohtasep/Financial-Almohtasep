using Financial_Almohtasep.Data;
using Financial_Almohtasep.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financial_Almohtasep.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
        
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            ViewBag.Data=_context.Employees.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {


                Employee employee = new()
                {
                    FName = model.FName,
                    LName = model.LName,
                    PhoneNumper = model.PhoneNumper,
                    Salary = model.Salary,
                    HireDate = model.HireDate,
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return RedirectToAction( "Index");
            }
            return View(model);
        }
        [HttpGet("{id}")]
        public IActionResult EditEmployee(Guid Id)
        {

            Employee? Employee = _context.Employees.Find(Id);
            if (Employee is not null)
                return View(new EmployeeDtoModel(Employee));
            return RedirectToAction(nameof(Index));
        }
        [HttpPost("{id}")]
        public IActionResult EditEmployee(Guid Id,EmployeeDtoModel model)
        {
            if (ModelState.IsValid)
            {
                if (Id != model.Id)
                {
                    
                    return RedirectToAction(nameof(EditEmployee), new { Id = model.Id });
                }
                var Employee = _context.Employees.Find(Id);
                if (Employee != null)
                {
                    Employee employees = new()
                    {
                        FName = model.FName,
                        LName = model.LName,
                        PhoneNumper = model.PhoneNumper,
                        Salary = model.Salary,
                        HireDate = model.HireDate,

                    };
                    _context.Employees.Update(employees);
                    _context.SaveChanges();
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        [HttpPost("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {

            var Employee = _context.Employees.Find(id);
            if (Employee != null)
            {
                _context.Employees.Remove(Employee);
                _context.SaveChanges();

                
            }
           
            return RedirectToAction(nameof(Index));
        }

    }
}
