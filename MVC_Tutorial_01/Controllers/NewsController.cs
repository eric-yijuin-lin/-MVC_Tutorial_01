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
    public class NewsController : Controller
    {
        private readonly MvcExamDBContext _context;

        public NewsController(MvcExamDBContext context)
        {
            _context = context;
        }

        // GET: News
        public IActionResult Index()
        {
            return View(_context.TblNews.ToList());
        }

        // GET: News/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = _context.TblNews
                .FirstOrDefault(m => m.No == id);
            if (tblNews == null)
            {
                return NotFound();
            }

            return View(tblNews);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            var newsTypes = _context.TblNewsType.ToList();
            var selectList = newsTypes.Select(x => new SelectListItem(x.TypeText, x.TypeValue));
            ViewData["NewsTypeSelectList"] = new SelectList(selectList, "Value", "Text");

            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("No,Type,Title,Creator,Content,CreateDt")] TblNews tblNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblNews);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tblNews);
        }

        // GET: News/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = _context.TblNews.Find(id);
            if (tblNews == null)
            {
                return NotFound();
            }
            return View(tblNews);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("No,Type,Title,Creator,Content,CreateDt")] TblNews tblNews)
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
                    _context.SaveChanges();
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

        // GET: News/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblNews = _context.TblNews
                .FirstOrDefault(m => m.No == id);
            if (tblNews == null)
            {
                return NotFound();
            }

            return View(tblNews);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tblNews = _context.TblNews.Find(id);
            _context.TblNews.Remove(tblNews);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public void MoreLinq()
        {
            // first, first or default
            var allNews = _context.TblNews.ToList();
            try
            {
                var firstNews1 = allNews
                    .First(x => x.Title == "Today");
                var firstNews2 = allNews
                    .First(x => x.Title == "No such title");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                var firstNews3 = allNews
                    .FirstOrDefault(x => x.Title == "No such title");
            }

            // where
            var todayNews = allNews.Where(x => x.Title == "Today");
            var todayNewsToList = allNews.Where(x => x.Title == "Today").ToList();

            // orderby
            var orderedNews1 = allNews.OrderBy(x => x.CreateDt).ToList();
            var orderedNews2 = allNews.OrderByDescending(x => x.CreateDt).ToList();

            // min, max
            var earliestDateTime = allNews.Min(x => x.CreateDt);
            var latestDateTime = allNews.Max(x => x.CreateDt);

            // count, sum
            var newsCount1 = allNews.Count();
            var newsCount2 = allNews.Count(x => x.Title == "Today");
            var sum1 = allNews.Sum(x => x.No);
            var sum2 = allNews.Where(x => x.No > 5).Sum(x => x.No);

            // select
            var select1 = allNews.Select(x => x.Title).ToList();
            var select2 = allNews.Select(x => new { x.Title, x.CreateDt }).ToList();
            var select3 = allNews.Select(x => 
                new TestClass() 
                {
                    TestTitle = x.Title,
                    TestDt = x.CreateDt 
                }
            ).ToList();

            // distinct
            var distinctCreator = allNews
                .Select(x => x.Creator)
                .Distinct()
                .ToList();
        }

        private bool TblNewsExists(int id)
        {
            return _context.TblNews.Any(e => e.No == id);
        }
    }

    public class TestClass
    {
        public string TestTitle { get; set; }
        public DateTime? TestDt { get; set; }
    }
}
