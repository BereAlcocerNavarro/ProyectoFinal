using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class ProfesorMateriasController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public ProfesorMateriasController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: ProfesorMaterias
        public async Task<IActionResult> Index()
        {
              return _context.ProfesorMateria != null ? 
                          View(await _context.ProfesorMateria.ToListAsync()) :
                          Problem("Entity set 'ProyectoFinalContext.ProfesorMateria'  is null.");
        }

        // GET: ProfesorMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfesorMateria == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesorMateria == null)
            {
                return NotFound();
            }

            return View(profesorMateria);
        }

        // GET: ProfesorMaterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfesorMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMateria,IdProfesor")] ProfesorMateria profesorMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesorMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesorMateria);
        }

        // GET: ProfesorMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfesorMateria == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria.FindAsync(id);
            if (profesorMateria == null)
            {
                return NotFound();
            }
            return View(profesorMateria);
        }

        // POST: ProfesorMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMateria,IdProfesor")] ProfesorMateria profesorMateria)
        {
            if (id != profesorMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesorMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorMateriaExists(profesorMateria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profesorMateria);
        }

        // GET: ProfesorMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfesorMateria == null)
            {
                return NotFound();
            }

            var profesorMateria = await _context.ProfesorMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesorMateria == null)
            {
                return NotFound();
            }

            return View(profesorMateria);
        }

        // POST: ProfesorMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfesorMateria == null)
            {
                return Problem("Entity set 'ProyectoFinalContext.ProfesorMateria'  is null.");
            }
            var profesorMateria = await _context.ProfesorMateria.FindAsync(id);
            if (profesorMateria != null)
            {
                _context.ProfesorMateria.Remove(profesorMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorMateriaExists(int id)
        {
          return (_context.ProfesorMateria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
