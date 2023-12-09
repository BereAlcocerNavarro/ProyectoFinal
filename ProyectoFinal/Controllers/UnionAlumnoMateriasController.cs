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
    public class UnionAlumnoMateriasController : Controller
    {
        private readonly ProyectoFinalContext _context;

        public UnionAlumnoMateriasController(ProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: UnionAlumnoMaterias
        public async Task<IActionResult> Index()
        {

            return _context.UnionAlumnoMateria != null ?
                        View(await _context.UnionAlumnoMateria.ToListAsync()) :
                        Problem("Entity set 'ProyectoFinalContext.UnionAlumnoMateria'  is null.");
        }

        // GET: UnionAlumnoMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnionAlumnoMateria == null)
            {
                return NotFound();
            }

            var unionAlumnoMateria = await _context.UnionAlumnoMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unionAlumnoMateria == null)
            {
                return NotFound();
            }

            return View(unionAlumnoMateria);
        }

        // GET: UnionAlumnoMaterias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnionAlumnoMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] UnionAlumnoMateria unionAlumnoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unionAlumnoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unionAlumnoMateria);
        }

        // GET: UnionAlumnoMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnionAlumnoMateria == null)
            {
                return NotFound();
            }

            var unionAlumnoMateria = await _context.UnionAlumnoMateria.FindAsync(id);
            if (unionAlumnoMateria == null)
            {
                return NotFound();
            }
            return View(unionAlumnoMateria);
        }

        // POST: UnionAlumnoMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] UnionAlumnoMateria unionAlumnoMateria)
        {
            if (id != unionAlumnoMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unionAlumnoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnionAlumnoMateriaExists(unionAlumnoMateria.Id))
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
            return View(unionAlumnoMateria);
        }

        // GET: UnionAlumnoMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnionAlumnoMateria == null)
            {
                return NotFound();
            }

            var unionAlumnoMateria = await _context.UnionAlumnoMateria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unionAlumnoMateria == null)
            {
                return NotFound();
            }

            return View(unionAlumnoMateria);
        }

        // POST: UnionAlumnoMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnionAlumnoMateria == null)
            {
                return Problem("Entity set 'ProyectoFinalContext.UnionAlumnoMateria'  is null.");
            }
            var unionAlumnoMateria = await _context.UnionAlumnoMateria.FindAsync(id);
            if (unionAlumnoMateria != null)
            {
                _context.UnionAlumnoMateria.Remove(unionAlumnoMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnionAlumnoMateriaExists(int id)
        {
          return (_context.UnionAlumnoMateria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
