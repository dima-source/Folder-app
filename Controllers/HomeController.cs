using System.Linq;
using System.Threading.Tasks;
using FolderTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FolderTestApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
 
        public async Task<IActionResult> Index(int? parentId)
        {
            if (!parentId.HasValue)
            {
                parentId = 1;
            }
            
            var catalog = db.Catalogs.FirstOrDefault(c => c.Id == parentId);
            var currentFolderName = catalog.Name;
            ViewData["CurrentFolderName"] = currentFolderName;
            
            return View(await db.Catalogs
                .Where(c => c.ParentId == parentId)
                .ToListAsync());
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Catalog catalog)
        {
            db.Catalogs.Add(catalog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
    }
