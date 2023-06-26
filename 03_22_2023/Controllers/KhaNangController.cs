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
    public class KhaNangController : Controller
    {
        // GET: KhaNang
        public ActionResult Index(int? page, string search)
        {
            var db = new DDBModel();
            var model = db.kha_nang.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = db.kha_nang.Where(x => x.ma_nha_cung_cap.Contains(search)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }
        
        // GET: KhaNang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhaNang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kha_nang model)
        {
            try
            {
                var db = new DDBModel();
                db.kha_nang.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(string ma_nha_cung_cap, string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.kha_nang.Find(ma_nha_cung_cap, ma_loai_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(string ma_nha_cung_cap, string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.kha_nang.Find(ma_nha_cung_cap, ma_loai_hang_hoa);
            db.kha_nang.Remove(model);
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

        // GET: KhaNang/Edit/5
        [HttpGet]
        public ActionResult Edit(string ma_nha_cung_cap, string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.kha_nang.Find(ma_nha_cung_cap, ma_loai_hang_hoa);
            return View(model);
        }
        
        // POST: KhaNang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kha_nang model)
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
        
        // GET: KhaNang/Details/5
        public ActionResult Details(string ma_nha_cung_cap, string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.kha_nang.Find(ma_nha_cung_cap, ma_loai_hang_hoa);
            return View(model);
        }
        
        // GET: KhaNang/Search
        public ActionResult Search(string search, int? page)
        {
            var db = new DDBModel();
            var model = db.kha_nang.Where(x => x.ma_loai_hang_hoa.Contains(search)).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: KhaNang/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.kha_nang.OrderBy(x => x.ma_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: KhaNang/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.kha_nang.OrderByDescending(x => x.ma_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: KhaNang/SortMaHangHoa
        public ActionResult SortMaHangHoa(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.kha_nang.OrderBy(x => x.ma_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
    }
}