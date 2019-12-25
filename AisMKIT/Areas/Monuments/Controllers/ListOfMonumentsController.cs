﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Monuments.Controllers
{
    [Area("Monuments")]
    public class ListOfMonumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfMonumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monuments/ListOfMonuments
        public async Task<IActionResult> Index(int Id = 0)
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", Id);
            var applicationDbContext = _context.ListOfMonuments.Include(l => l.DictDistrict).Include(l => l.DictFinSource).Include(l => l.DictMonumemtSignOfLoss).Include(l => l.DictMonumentType);
            if (Id != 0)
                applicationDbContext = _context.ListOfMonuments.Where(x => x.DictFinSourceId == Id).Include(l => l.DictDistrict).Include(l => l.DictFinSource).Include(l => l.DictMonumemtSignOfLoss).Include(l => l.DictMonumentType);
            
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Monuments/ListOfMonuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonuments = await _context.ListOfMonuments
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictMonumemtSignOfLoss)
                .Include(l => l.DictMonumentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonuments == null)
            {
                return NotFound();
            }

            return View(listOfMonuments);
        }

        // GET: Monuments/ListOfMonuments/Create
        public IActionResult Create()
        {
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictMonumemtSignOfLossId"] = new SelectList(_context.DictMonumemtSignOfLoss, "Id", "NameRus");
            ViewData["DictMonumentTypeId"] = new SelectList(_context.DictMonumentType, "Id", "NameRus");
            ListOfMonuments model = new ListOfMonuments();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: Monuments/ListOfMonuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DatingOfMonument,DictDistrictId,LegalAddress,DictFinSourceId,DictMonumentTypeId,DictMonumemtSignOfLossId,CreateDate")] ListOfMonuments listOfMonuments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfMonuments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonuments.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonuments.DictFinSourceId);
            ViewData["DictMonumemtSignOfLossId"] = new SelectList(_context.DictMonumemtSignOfLoss, "Id", "NameRus", listOfMonuments.DictMonumemtSignOfLossId);
            ViewData["DictMonumentTypeId"] = new SelectList(_context.DictMonumentType, "Id", "NameRus", listOfMonuments.DictMonumentTypeId);
            return View(listOfMonuments);
        }

        // GET: Monuments/ListOfMonuments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonuments = await _context.ListOfMonuments.FindAsync(id);
            if (listOfMonuments == null)
            {
                return NotFound();
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonuments.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonuments.DictFinSourceId);
            ViewData["DictMonumemtSignOfLossId"] = new SelectList(_context.DictMonumemtSignOfLoss, "Id", "NameRus", listOfMonuments.DictMonumemtSignOfLossId);
            ViewData["DictMonumentTypeId"] = new SelectList(_context.DictMonumentType, "Id", "NameRus", listOfMonuments.DictMonumentTypeId);
            return View(listOfMonuments);
        }

        // POST: Monuments/ListOfMonuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DatingOfMonument,DictDistrictId,LegalAddress,DictFinSourceId,DictMonumentTypeId,DictMonumemtSignOfLossId,CreateDate")] ListOfMonuments listOfMonuments)
        {
            if (id != listOfMonuments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfMonuments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfMonumentsExists(listOfMonuments.Id))
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
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfMonuments.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfMonuments.DictFinSourceId);
            ViewData["DictMonumemtSignOfLossId"] = new SelectList(_context.DictMonumemtSignOfLoss, "Id", "NameRus", listOfMonuments.DictMonumemtSignOfLossId);
            ViewData["DictMonumentTypeId"] = new SelectList(_context.DictMonumentType, "Id", "NameRus", listOfMonuments.DictMonumentTypeId);
            return View(listOfMonuments);
        }

        // GET: Monuments/ListOfMonuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfMonuments = await _context.ListOfMonuments
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictMonumemtSignOfLoss)
                .Include(l => l.DictMonumentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfMonuments == null)
            {
                return NotFound();
            }

            return View(listOfMonuments);
        }

        // POST: Monuments/ListOfMonuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfMonuments = await _context.ListOfMonuments.FindAsync(id);
            _context.ListOfMonuments.Remove(listOfMonuments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfMonumentsExists(int id)
        {
            return _context.ListOfMonuments.Any(e => e.Id == id);
        }
    }
}