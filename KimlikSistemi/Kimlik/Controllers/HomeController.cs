using Entities.ModelView;
using BusinesLayerAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using RandevuOtomasyonWeb.Models;
using Entities.Messages;
using RandevuOtomasyonWeb.ViewModels;

namespace OtizmWeb.Controllers
{
    public class HomeController : Controller

    {
        private UserManager um = new UserManager();
        private KartManager km = new KartManager();
        private SaatManager saatm = new SaatManager();


        // GET: Home
        public ActionResult Index()
        {
            BusinesLayerAcces.Test test = new BusinesLayerAcces.Test();
            return View();
        }
      
        public ActionResult Login()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {

                BusinesLayerResult<User> res = um.LoginUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                //odemeye basıldığında basarılı bir şekilde ödeme yapıldı ve onaylı olmayan randevu onaylansın
                Session["login"] = res.Result;
                return RedirectToAction("Anasayfam");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Odeme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Odeme(KartModelViews model)
        {
            if (ModelState.IsValid)
            {

                BusinesLayerResult<Kart> kart = km.CartUser(model);
                if (kart.Errors.Count > 0)
                {
                    kart.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                Session["login"] = kart.Result;
                //return RedirectToAction("RegisterOk");
                OkViewModel notifyObj = new OkViewModel()
                {
                    Title = "Odeme Başarılı",
                    RedirectingUrl = "/Randevu/Index",
                };

                notifyObj.Items.Add("Lütfen e-posta adresinize gönderdiğimiz aktivasyon link'ine tıklayarak odemeyi onaylayınız.");

                return View("Ok", notifyObj);
            }
         
            return View(model);
        }

        public ActionResult UserActivate(Guid id)
        {
            BusinesLayerResult<Kart> res = km.ActivateUser(id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                };

                return View("Error", errorNotifyObj);
            }

            OkViewModel okNotifyObj = new OkViewModel()
            {
                Title = "Odeme Onaylandı",
                RedirectingUrl = "/Randevu/Index"
            };

            okNotifyObj.Items.Add("Odemeniz alınmıştır.Randevu günü Gidebilirsiniz.");

            return View("Ok", okNotifyObj);
        }
   
        public ActionResult Anasayfam()
        {
            return View();
        }
        public ActionResult ShowProfil()
        {

            User currentUser = Session["login"] as User;

            BusinesLayerResult<User> res = um.GetUserById(currentUser.Id);
            if (res.Errors.Count > 0)
            {

            }
            return View(res.Result);
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }
        public ActionResult Ok()
        {
            return View();
        }

    }

}