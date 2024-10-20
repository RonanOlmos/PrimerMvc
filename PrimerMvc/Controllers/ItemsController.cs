using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerMvc.Data;
using PrimerMvc.Models;

namespace PrimerMvc.Controllers
{
    public class ItemsController : Controller
    {
        private readonly PrimerMvcContext _context;
        public ItemsController(PrimerMvcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _context.Items.Include(c => c.Category)
                                           .ToListAsync();
            return View(item);
        }
        public IActionResult Crear()
        {
            ViewData["Categories"]= new SelectList(_context.Categories,"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear([Bind("Id, Name, CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Modificar(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("Id,Name,CategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id==id);
            return View(item);
            
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfimado(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
