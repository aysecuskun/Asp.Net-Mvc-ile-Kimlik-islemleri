using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinesLayerAcces;
using DataAccesLayer;
using Entities;
using RandevuOtomasyonWeb.Models;

namespace OtizmWeb.Controllers
{
    public class RandevuController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        private SehirManager sm = new SehirManager();
        private IlceManager im = new IlceManager();
        private SaatManager saatm = new SaatManager();
        private SebepManager sebepm = new SebepManager();
        private RandevuManager rm = new RandevuManager();

        // GET: Randevu
        public ActionResult Index()
        {
            var randevu = rm.ListQueryable().Include("Neden").Include("Saat").Include("Il").Include("Ilce").Include("Owner").Where(
               x => x.Owner.Id == CurrentSession.User.Id);

            return View(randevu.ToList());
        }

        public JsonResult GetStateList(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Ilce> ılces = db.Ilces.Where(x => x.Il.Id == id).ToList();
            return Json(ılces, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSaatList(int Ilceid,DateTime RandevuGunu,int id)
        {
            Randevu randevu = rm.Find(x => x.Ilceid == Ilceid && x.RandevuGunu==RandevuGunu && x.SaatId==id &&  x.Owner.Id == CurrentSession.User.Id);
            Saat saat = saatm.Find(x => x.Id ==id);
            db.Configuration.ProxyCreationEnabled = false;
            return Json(randevu, JsonRequestBehavior.AllowGet);
        }



        // GET: Randevu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = rm.Find(x => x.Id == id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            return View(randevu);
        }

        // GET: Randevu/Create
        public ActionResult Create()
                                                                                                                          

        {
            ViewBag.Ilid = new SelectList(sm.List(), "Id", "İlAdi");
            ViewBag.Ilceid = new SelectList(im.List(), "Id", "İlceAdi");
            ViewBag.Nedenid = new SelectList(sebepm.List(), "Id", "RandevuAlmaNeden");
            ViewBag.SaatId = new SelectList(saatm.List(), "Id", "Saatler");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                randevu.Owner = CurrentSession.User;
                randevu.RandevuGunu = Convert.ToDateTime(randevu.RandevuGunu);
                rm.Insert(randevu);

            }

            ViewBag.Ilid = new SelectList(sm.List(), "Id", "İlAdi");
            ViewBag.Ilceid = new SelectList(im.List(), "Id", "İlceAdi");
            ViewBag.Nedenid = new SelectList(sebepm.List(), "Id", "RandevuAlmaNeden");
            ViewBag.SaatId = new SelectList(saatm.List(), "Id", "Saatler");
            return RedirectToAction("Index");
            //return View(randevu);
        }

        // GET: Randevu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = rm.Find(x => x.Id == id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ilid = new SelectList(sm.List(), "Id", "İlAdi");
            ViewBag.Ilceid = new SelectList(im.List(), "Id", "İlceAdi");
            ViewBag.Nedenid = new SelectList(sebepm.List(), "Id", "RandevuAlmaNeden");
            ViewBag.SaatId = new SelectList(saatm.List(), "Id", "Saatler");

            return View(randevu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                Randevu db_note = rm.Find(x => x.Id == randevu.Id);
                db_note.Name = randevu.Name;
                db_note.Surname = randevu.Surname;
                db_note.Ilid = randevu.Ilid;
                db_note.Ilceid = randevu.Ilceid;
                db_note.RandevuGunu = randevu.RandevuGunu;
                db_note.SaatId = randevu.SaatId;
                db_note.Nedenid = randevu.Nedenid;
                db_note.Onay = randevu.Onay;


                rm.Update(db_note);

            }
            ViewBag.Ilid = new SelectList(sm.List(), "Id", "İlAdi");
            ViewBag.Ilceid = new SelectList(im.List(), "Id", "İlceAdi");
            ViewBag.Nedenid = new SelectList(sebepm.List(), "Id", "RandevuAlmaNeden");
            ViewBag.SaatId = new SelectList(saatm.List(), "Id", "Saatler");
            return RedirectToAction("Index");
        }

        // GET: Randevu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Randevu randevu = rm.Find(x => x.Id == id);
            if (randevu == null)
            {
                return HttpNotFound();
            }
            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Randevu randevu = rm.Find(x => x.Id == id);
            rm.Delete(randevu);
            return RedirectToAction("Index");
        }

    }
}
