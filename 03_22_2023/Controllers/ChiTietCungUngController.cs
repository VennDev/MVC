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
    public class ChiTietCungUngController : Controller
    {
        // GET: ChiTietCungUng
        public ActionResult Index(int? page, string search)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = db.chi_tiet_cung_ung.Where(x => x.ma_hang_hoa.Contains(search)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }

        // GET: ChiTietCungUng/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietCungUng/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(chi_tiet_cung_ung model)
        {
            try
            {
                var db = new DDBModel();
                db.chi_tiet_cung_ung.Add(model);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(int so_phieu, string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.Find(so_phieu, ma_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(int so_phieu, string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.Find(so_phieu, ma_hang_hoa);
            db.chi_tiet_cung_ung.Remove(model);
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

        // GET: LoaiHangHoa/Edit/5
        [HttpGet]
        public ActionResult Edit(int so_phieu, string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.Find(so_phieu, ma_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(chi_tiet_cung_ung model)
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
        
        // GET: LoaiHangHoa/Details/5
        public ActionResult Details(int so_phieu, string ma_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.Find(so_phieu, ma_hang_hoa);
            return View(model);
        }

        // GET: LoaiHangHoa/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.OrderBy(x => x.ma_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: LoaiHangHoa/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.OrderByDescending(x => x.ma_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: LoaiHangHoa/SortMaLoaiHangHoa
        public ActionResult SortMaLoaiHangHoa(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.chi_tiet_cung_ung.OrderBy(x => x.ma_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
    }
}