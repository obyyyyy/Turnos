using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {

        private readonly TurnosContext _context;

        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Especialidad == null){
                return NotFound();
            }
            else{
                return View(await _context.Especialidad.ToListAsync());
            }
            
        }

        public IActionResult Edit(int? id )
        {
            if(id == null || _context.Especialidad == null){
                return NotFound();
            }

            var especialidad = _context.Especialidad.Find(id);

            if (especialidad == null){
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if(id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
    }
}