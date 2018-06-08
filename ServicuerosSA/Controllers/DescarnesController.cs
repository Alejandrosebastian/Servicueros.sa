﻿using System;
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
    public class DescarnesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DescarnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Descarnes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Descarne.Include(d => d.Pelambres);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Descarnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarne = await _context.Descarne
                .Include(d => d.Pelambres)
                .SingleOrDefaultAsync(m => m.DescarneId == id);
            if (descarne == null)
            {
                return NotFound();
            }

            return View(descarne);
        }

        // GET: Descarnes/Create
        public IActionResult Create()
        {
            ViewData["PelambreId"] = new SelectList(_context.Pelambre, "PelambreId", "PelambreId");
            return View();
        }

        // POST: Descarnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescarneId,Cantidad,Fecha,Activo,PelambreId")] Descarne descarne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descarne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PelambreId"] = new SelectList(_context.Pelambre, "PelambreId", "PelambreId", descarne.PelambreId);
            return View(descarne);
        }

        // GET: Descarnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarne = await _context.Descarne.SingleOrDefaultAsync(m => m.DescarneId == id);
            if (descarne == null)
            {
                return NotFound();
            }
            ViewData["PelambreId"] = new SelectList(_context.Pelambre, "PelambreId", "PelambreId", descarne.PelambreId);
            return View(descarne);
        }

        // POST: Descarnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescarneId,Cantidad,Fecha,Activo,PelambreId")] Descarne descarne)
        {
            if (id != descarne.DescarneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descarne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescarneExists(descarne.DescarneId))
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
            ViewData["PelambreId"] = new SelectList(_context.Pelambre, "PelambreId", "PelambreId", descarne.PelambreId);
            return View(descarne);
        }

        // GET: Descarnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarne = await _context.Descarne
                .Include(d => d.Pelambres)
                .SingleOrDefaultAsync(m => m.DescarneId == id);
            if (descarne == null)
            {
                return NotFound();
            }

            return View(descarne);
        }

        // POST: Descarnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descarne = await _context.Descarne.SingleOrDefaultAsync(m => m.DescarneId == id);
            _context.Descarne.Remove(descarne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescarneExists(int id)
        {
            return _context.Descarne.Any(e => e.DescarneId == id);
        }
    }
}
