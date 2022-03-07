using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SereginLab1.Data;
using SereginLab1.Models;

namespace SereginLab1.Controllers
{
    public class DbEntitiesController : Controller
    {
        private readonly MvcDbEntityContext _context;

        public DbEntitiesController(MvcDbEntityContext context)
        {
            _context = context;
        }

        // GET: DbEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DbEntity.ToListAsync());
        }

        // GET: DbEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEntity = await _context.DbEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbEntity == null)
            {
                return NotFound();
            }

            return View(dbEntity);
        }

        // GET: DbEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDay,Age")] DbEntity dbEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbEntity);
        }

        // GET: DbEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEntity = await _context.DbEntity.FindAsync(id);
            if (dbEntity == null)
            {
                return NotFound();
            }
            return View(dbEntity);
        }

        // POST: DbEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDay,Age")] DbEntity dbEntity)
        {
            if (id != dbEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbEntityExists(dbEntity.Id))
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
            return View(dbEntity);
        }

        // GET: DbEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEntity = await _context.DbEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbEntity == null)
            {
                return NotFound();
            }

            return View(dbEntity);
        }

        // POST: DbEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbEntity = await _context.DbEntity.FindAsync(id);
            _context.DbEntity.Remove(dbEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbEntityExists(int id)
        {
            return _context.DbEntity.Any(e => e.Id == id);
        }
    }
}
