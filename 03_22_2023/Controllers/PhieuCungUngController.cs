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
    public class PhieuCungUngController : Controller
    {
        // GET: PhieuCungUng
        public ActionResult Index(int? page, int? search)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.ToList();
            if (search != null)
            {
                model = db.phieu_cung_ung.Where(x => x.so_phieu == search).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }
        
        // GET: PhieuCungUng/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuCungUng/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(phieu_cung_ung model)
        {
            try
            {
                var db = new DDBModel();
                db.phieu_cung_ung.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(int so_phieu)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.Find(so_phieu);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(int so_phieu)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.Find(so_phieu);
            db.phieu_cung_ung.Remove(model);
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

        // GET: PhieuCungUng/Edit/5
        [HttpGet]
        public ActionResult Edit(int so_phieu)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.Find(so_phieu);
            return View(model);
        }
        
        // POST: PhieuCungUng/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(phieu_cung_ung model)
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
        
        // GET: PhieuCungUng/Details/5
        public ActionResult Details(int so_phieu)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.Find(so_phieu);
            return View(model);
        }
        
        // GET: PhieuCungUng/Search
        public ActionResult Search(string search, int? page)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.Where(x => x.ma_nha_cung_cap.Contains(search)).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: PhieuCungUng/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.OrderBy(x => x.ma_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: PhieuCungUng/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.OrderByDescending(x => x.ma_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: PhieuCungUng/SortMaPhieuCungUng
        public ActionResult SortMaPhieuCungUng(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.phieu_cung_ung.OrderBy(x => x.ma_nha_cung_cap).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
    }
}