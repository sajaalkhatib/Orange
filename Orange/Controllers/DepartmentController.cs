using Microsoft.AspNetCore.Mvc;
using Orange.Models;

namespace Orange.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var department = _context.Department.ToList();
            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Department.Add(department);
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}
