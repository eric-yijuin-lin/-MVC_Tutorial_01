using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Tutorial_01.Models;

namespace MVC_Tutorial_01.Controllers
{
    public class NewsController2 : Controller
    {
        private readonly MvcExamDBContext _context;

        public NewsController2(MvcExamDBContext context)
        {
            _context = context;
        }

        // GET: NewsController2
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblNews.ToListAsync());
        }

        // GET: NewsController2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = await _context.TblNews
                .FirstOrDefaultAsync(m => m.No == id);
            if (tblNews == null)
            {
                return NotFound();
            }

            return View(tblNews);
        }

        // GET: NewsController2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsController2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("No,Type,Title,Creator,Content,CreateDt")] TblNews tblNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblNews);
        }

        // GET: NewsController2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = await _context.TblNews.FindAsync(id);
            if (tblNews == null)
            {
                return NotFound();
            }
            return View(tblNews);
        }

        // POST: NewsController2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("No,Type,Title,Creator,Content,CreateDt")] TblNews tblNews)
        {
            if (id != tblNews.No)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblNews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblNewsExists(tblNews.No))
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
            return View(tblNews);
        }

        // GET: NewsController2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = await _context.TblNews
                .FirstOrDefaultAsync(m => m.No == id);
            if (tblNews == null)
            {
                return NotFound();
            }

            return View(tblNews);
        }

        // POST: NewsController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblNews = await _context.TblNews.FindAsync(id);
            _context.TblNews.Remove(tblNews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblNewsExists(int id)
        {
            return _context.TblNews.Any(e => e.No == id);
        }
    }
}
