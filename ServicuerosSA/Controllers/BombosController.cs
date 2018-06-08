using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class BombosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private BomboModel claseBombosModel;
        public BombosController(ApplicationDbContext context)
        {
            _context = context;
            claseBombosModel = new BomboModel(context);
        }


        public List<object[]> ControladorSacaBombo(int bomboId)
        {
            return claseBombosModel.ClaseBombo(bomboId);
        }


        public List<Bombo> ControladorListaBombos()
        {
            return claseBombosModel.ClaseListaBombo();
        }
        // GET: Bombos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bombo.ToListAsync());
        }

        // GET: Bombos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bombo = await _context.Bombo
                .SingleOrDefaultAsync(m => m.BomboId == id);
            if (bombo == null)
            {
                return NotFound();
            }

            return View(bombo);
        }

        // GET: Bombos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bombos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BomboId,Num_bombo,Capacidad,FechaIngreso")] Bombo bombo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bombo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bombo);
        }

        // GET: Bombos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bombo = await _context.Bombo.SingleOrDefaultAsync(m => m.BomboId == id);
            if (bombo == null)
            {
                return NotFound();
            }
            return View(bombo);
        }

        // POST: Bombos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BomboId,Num_bombo,Capacidad,FechaIngreso")] Bombo bombo)
        {
            if (id != bombo.BomboId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bombo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BomboExists(bombo.BomboId))
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
            return View(bombo);
        }

        // GET: Bombos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bombo = await _context.Bombo
                .SingleOrDefaultAsync(m => m.BomboId == id);
            if (bombo == null)
            {
                return NotFound();
            }

            return View(bombo);
        }

        // POST: Bombos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bombo = await _context.Bombo.SingleOrDefaultAsync(m => m.BomboId == id);
            _context.Bombo.Remove(bombo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BomboExists(int id)
        {
            return _context.Bombo.Any(e => e.BomboId == id);
        }
    }
}
