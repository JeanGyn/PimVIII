using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pim.Data;
using Pim.Models;

namespace Pim.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly PimContext _context;

        public TelefonesController(PimContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var pimContext = _context.Telefone.Include(t => t.TipoTelefone);
            return View(await pimContext.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TipoTelefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Id");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ddd,Numero,TipoTelefoneId")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Id", telefone.TipoTelefoneId);
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Id", telefone.TipoTelefoneId);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ddd,Numero,TipoTelefoneId")] Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.Id))
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
            ViewData["TipoTelefoneId"] = new SelectList(_context.TipoTelefone, "Id", "Id", telefone.TipoTelefoneId);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefone
                .Include(t => t.TipoTelefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefone = await _context.Telefone.FindAsync(id);
            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
            return _context.Telefone.Any(e => e.Id == id);
        }
    }
}
