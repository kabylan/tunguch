﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.GlobalDicts.Controllers
{
    [Area("GlobalDicts")]
    public class DictAgeRestrictionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DictAgeRestrictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GlobalDicts/DictAgeRestrictions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictAgeRestrictions.ToListAsync());
        }

        // GET: GlobalDicts/DictAgeRestrictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgeRestrictions = await _context.DictAgeRestrictions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAgeRestrictions == null)
            {
                return NotFound();
            }

            return View(dictAgeRestrictions);
        }

        // GET: GlobalDicts/DictAgeRestrictions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlobalDicts/DictAgeRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DictAgeRestrictions dictAgeRestrictions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictAgeRestrictions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictAgeRestrictions);
        }

        // GET: GlobalDicts/DictAgeRestrictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgeRestrictions = await _context.DictAgeRestrictions.FindAsync(id);
            if (dictAgeRestrictions == null)
            {
                return NotFound();
            }
            return View(dictAgeRestrictions);
        }

        // POST: GlobalDicts/DictAgeRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DictAgeRestrictions dictAgeRestrictions)
        {
            if (id != dictAgeRestrictions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictAgeRestrictions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictAgeRestrictionsExists(dictAgeRestrictions.Id))
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
            return View(dictAgeRestrictions);
        }

        // GET: GlobalDicts/DictAgeRestrictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictAgeRestrictions = await _context.DictAgeRestrictions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictAgeRestrictions == null)
            {
                return NotFound();
            }

            return View(dictAgeRestrictions);
        }

        // POST: GlobalDicts/DictAgeRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictAgeRestrictions = await _context.DictAgeRestrictions.FindAsync(id);
            _context.DictAgeRestrictions.Remove(dictAgeRestrictions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictAgeRestrictionsExists(int id)
        {
            return _context.DictAgeRestrictions.Any(e => e.Id == id);
        }
    }
}