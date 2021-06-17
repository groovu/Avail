using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Availibility2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Availibility2.Controllers
{
    public class AvailsController : Controller
    {
        private readonly AvailContext _context;

        public AvailsController(AvailContext context)
        {
            _context = context;
        }

        // GET: Avails
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avail.ToListAsync());
        }

        // GET: Avails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avail = await _context.Avail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avail == null)
            {
                return NotFound();
            }

            return View(avail);
        }

        // GET: Avails/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        // POST: Avails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Time,Note,Cancelled,Secret")] Avail avail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avail);
                await _context.SaveChangesAsync();
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");
            //return View(avail);
        }

        // GET: Avails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avail = await _context.Avail.FindAsync(id);
            if (avail == null)
            {
                return NotFound();
            }
            return View(avail);
        }
        //public async Task<IActionResult> Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var avail = await _context.Avail.FindAsync(id);
        //    if (avail == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(avail);
        //}
        // POST: Avails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Time,Note,Cancelled,Secret")] Avail avail)
        {
            Console.WriteLine("Hello");
            if (id != avail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailExists(avail.Id))
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
            return View(avail);
        }

        // GET: Avails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avail = await _context.Avail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avail == null)
            {
                return NotFound();
            }

            return View(avail);
        }

        // POST: Avails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avail = await _context.Avail.FindAsync(id);
            _context.Avail.Remove(avail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailExists(int id)
        {
            return _context.Avail.Any(e => e.Id == id);
        }
    }
}
