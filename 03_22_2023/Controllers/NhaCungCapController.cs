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
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        public ActionResult Index(int? page, string search)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = db.nha_cung_cap.Where(x => x.ten_nha_cung_cap.Contains(search)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }
        
        // GET: NhaCungCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(nha_cung_cap model)
        {
            try
            {
                var db = new DDBModel();
                db.nha_cung_cap.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(string ma_nha_cung_cap)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.Find(ma_nha_cung_cap);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(string ma_nha_cung_cap)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.Find(ma_nha_cung_cap);
            db.nha_cung_cap.Remove(model);
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

        // GET: NhaCungCap/Edit/5
        [HttpGet]
        public ActionResult Edit(string ma_nha_cung_cap)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.Find(ma_nha_cung_cap);
            return View(model);
        }
        
        // POST: NhaCungCap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(nha_cung_cap model)
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
        
        // GET: NhaCungCap/Details/5
        public ActionResult Details(string ma_nha_cung_cap)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.Find(ma_nha_cung_cap);
            return View(model);
        }
        
        // GET: NhaCungCap/Search
        public ActionResult Search(string search, int? page)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.Where(x => x.ten_nha_cung_cap.Contains(search)).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: NhaCungCap/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.OrderBy(x => x.ten_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: NhaCungCap/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.OrderByDescending(x => x.ten_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: NhaCungCap/SortMaNhaCungCap
        public ActionResult SortMaNhaCungCap(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.nha_cung_cap.OrderBy(x => x.ma_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
    }
}