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
    public class LoaiHangHoaController : Controller
    {
        // GET: LoaiHangHoa
        public ActionResult Index(int? page, string search)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = db.loai_hang_hoa.Where(x => x.ten_loai_hang_hoa.Contains(search)).ToList();
            }
            return View(model.ToPagedList(page ?? 1, 5));
        }
        
        // GET: LoaiHangHoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiHangHoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(loai_hang_hoa model)
        {
            try
            {
                var db = new DDBModel();
                db.loai_hang_hoa.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LoaiHangHoa/Delete/5
        public ActionResult Delete(string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.Find(ma_loai_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Delete/5
        public ActionResult DeleteAc(string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.Find(ma_loai_hang_hoa);
            db.loai_hang_hoa.Remove(model);
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
        public ActionResult Edit(string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.Find(ma_loai_hang_hoa);
            return View(model);
        }
        
        // POST: LoaiHangHoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(loai_hang_hoa model)
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
        public ActionResult Details(string ma_loai_hang_hoa)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.Find(ma_loai_hang_hoa);
            return View(model);
        }
        
        // GET: LoaiHangHoa/Search
        public ActionResult Search(string search, int? page)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.Where(x => x.ten_loai_hang_hoa.Contains(search)).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: LoaiHangHoa/Sort
        public ActionResult Sort(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.OrderBy(x => x.ten_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: LoaiHangHoa/SortDesc
        public ActionResult SortDesc(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.OrderByDescending(x => x.ten_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        // GET: LoaiHangHoa/SortMaLoaiHangHoa
        public ActionResult SortMaLoaiHangHoa(string sort, int? page)
        {
            var db = new DDBModel();
            var model = db.loai_hang_hoa.OrderBy(x => x.ma_loai_hang_hoa).ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }
        
        public ActionResult ErrorImage()
        {
            return View();
        }
        
        public ActionResult UploadImage()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                var fileName = System.IO.Path.GetFileName(file.FileName);
                var path = System.IO.Path.Combine(Server.MapPath("~/Images"), fileName);
                file.SaveAs(path);
            }
            else
            {
                return RedirectToAction("ErrorImage");
            }
            return RedirectToAction("Index");
        }
    }
}