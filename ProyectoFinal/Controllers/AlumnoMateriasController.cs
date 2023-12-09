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
    public class AlumnoMateriasController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public AlumnoMateriasController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: AlumnoMaterias
        public async Task<IActionResult> Index()
        {
              return _context.AlumnoMateria != null ? 
                          View(await _context.AlumnoMateria.ToListAsync()) :
                          Problem("Entity set 'ProyectoFinalContext.AlumnoMateria'  is null.");
        }

        // GET: AlumnoMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }

            return View(alumnoMateria);
        }

        // GET: AlumnoMaterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlumnoMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMateria,IdAlumno")] AlumnoMateria alumnoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alumnoMateria);
        }

        // GET: AlumnoMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria.FindAsync(id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }
            return View(alumnoMateria);
        }

        // POST: AlumnoMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMateria,IdAlumno")] AlumnoMateria alumnoMateria)
        {
            if (id != alumnoMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoMateriaExists(alumnoMateria.Id))
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
            return View(alumnoMateria);
        }

        // GET: AlumnoMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }

            return View(alumnoMateria);
        }

        // POST: AlumnoMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlumnoMateria == null)
            {
                return Problem("Entity set 'ProyectoFinalContext.AlumnoMateria'  is null.");
            }
            var alumnoMateria = await _context.AlumnoMateria.FindAsync(id);
            if (alumnoMateria != null)
            {
                _context.AlumnoMateria.Remove(alumnoMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoMateriaExists(int id)
        {
          return (_context.AlumnoMateria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
