using BRC.Data;
using BRC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BRC.Controllers
{
    [Authorize]
    public class BookReviewController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookReviewController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var UserID = User.FindFirst(ClaimTypes.Name).Value;
            IEnumerable<BookReview> objList = _db.BookReview.Where(u => u.ReviewBy == UserID);
            return View(objList);
        }
        public IActionResult BrowseIndex()
        {
            var UserID = User.FindFirst(ClaimTypes.Name).Value;
            IEnumerable<BookReview> objList = _db.BookReview.Where(u => u.ReviewBy != UserID);
            return View(objList);
        }

        //GET - ADD
        public IActionResult Add()
        {
            return View();
        }
        //POST - ADD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(BookReview br)
        {
            if (ModelState.IsValid)
            {
                _db.BookReview.Add(br);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(br);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if(id==null || id == 0){
                return NotFound();
            }
            var obj = _db.BookReview.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.BookReview.Find(id);
            if (obj == null) { return NotFound(); }
            _db.BookReview.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.BookReview.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookReview br)
        {
            if (ModelState.IsValid)
            {
                _db.BookReview.Update(br);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(br);
        }

        public IActionResult View(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.BookReview.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult BrowseView(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.BookReview.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
