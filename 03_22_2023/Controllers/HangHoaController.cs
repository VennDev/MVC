using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using _03_22_2023.Models;

namespace _03_22_2023.Controllers
{
    public class HangHoaController : Controller
    {
        // GET: HangHoa
        public ActionResult Index(int? page, string search)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = db.hang_hoa.Where(x => x.ten_hang_hoa.Contains(search)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }
        
        // GET: HangHoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangHoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(hang_hoa model)
        {
            try
            {
                var db = new DDBModel();
                db.hang_hoa.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.Find(ma_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.Find(ma_hang_hoa);
            db.hang_hoa.Remove(model);
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Error()
        {
            return View();
        }

        // GET: HangHoa/Edit/5
        [HttpGet]
        public ActionResult Edit(string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.Find(ma_hang_hoa);
            return View(model);
        }
        
        // POST: HangHoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(hang_hoa model)
        {
            try
            {
                var db = new DDBModel();
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: HangHoa/Details/5
        public ActionResult Details(string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.Find(ma_hang_hoa);
            return View(model);
        }

        // GET: HangHoa/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.OrderBy(x => x.ten_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: HangHoa/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.OrderByDescending(x => x.ten_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: HangHoa/SortMaHangHoa
        public ActionResult SortMaLoaiHangHoa(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.hang_hoa.OrderBy(x => x.ma_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
    }
}