﻿//Nathan Barton section 002 Home Controller that handles the logic for the instrument rentals

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;
using BlowOut.DAL;
using System.Net;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.Owin.Security;
using System.Web.Configuration;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        private BlowOut1Context db = new BlowOut1Context();

        public ActionResult BlowOut()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            return View(db.Instuments.ToList());
        }

        public ActionResult InstrumentRental(String instrument, String insCondition)
        {
            if (instrument == "Trumpet" && insCondition == "New")
            {
                ViewBag.image = "TrumpetSquare.jpg";
                ViewBag.RentalPrice = "$55 a month";
                ViewBag.Instrument = "Trumpet";
                ViewBag.Type = "New";
            }
            else if (instrument == "Trumpet" && insCondition == "Used")
            {
                ViewBag.image = "TrumpetSquare.jpg";
                ViewBag.RentalPrice = "$25 a month";
                ViewBag.Instrument = "Trumpet";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Trombone" && insCondition == "New")
            {
                ViewBag.image = "TromboneSquare.jpg";
                ViewBag.RentalPrice = "$60 a month";
                ViewBag.Instrument = "Trombone";
                ViewBag.Type = "New";
            }
            else if (instrument == "Trombone" && insCondition == "Used")
            {
                ViewBag.image = "TromboneSquare.jpg";
                ViewBag.RentalPrice = "$35 a month";
                ViewBag.Instrument = "Trombone";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Tuba" && insCondition == "New")
            {
                ViewBag.image = "TubaSquare.jpg";
                ViewBag.RentalPrice = "$70 a month";
                ViewBag.Instrument = "Tuba";
                ViewBag.Type = "New";
            }
            else if (instrument == "Tuba" && insCondition == "Used")
            {
                ViewBag.image = "TubaSquare.jpg";
                ViewBag.RentalPrice = "$50 a month";
                ViewBag.Instrument = "Tuba";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Flute" && insCondition == "New")
            {
                ViewBag.image = "FluteSquare.jpg";
                ViewBag.RentalPrice = "$40 a month";
                ViewBag.Instrument = "Flute";
                ViewBag.Type = "New";
            }
            else if (instrument == "Flute" && insCondition == "Used")
            {
                ViewBag.image = "FluteSquare.jpg";
                ViewBag.RentalPrice = "$25 a month";
                ViewBag.Instrument = "Flute";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Clarinet" && insCondition == "New")
            {
                ViewBag.image = "ClarinetSquare.jpg";
                ViewBag.RentalPrice = "$35 a month";
                ViewBag.Instrument = "Clarinet";
                ViewBag.Type = "New";
            }
            else if (instrument == "Clarinet" && insCondition == "Used")
            {
                ViewBag.image = "ClarinetSquare.jpg";
                ViewBag.RentalPrice = "$27 a month";
                ViewBag.Instrument = "Clarinet";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Saxophone" && insCondition == "New")
            {
                ViewBag.image = "SaxophoneSquare.jpg";
                ViewBag.RentalPrice = "$42 a month";
                ViewBag.Instrument = "Saxophone";
                ViewBag.Type = "New";
            }
            else if (instrument == "Saxophone" && insCondition == "Used")
            {
                ViewBag.image = "SaxophoneSquare.jpg";
                ViewBag.RentalPrice = "$30 a month";
                ViewBag.Instrument = "Saxophone";
                ViewBag.Type = "Used";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Create ActionResult

        [HttpGet]
        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,firstname,lastname,address,city,state,zip,email,phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                //lookup instrument
                Instrument instrument = db.Instuments.Find(ID);
                //update instrument
                instrument.clientID = client.clientID;
                //save changes
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.clientID, InstrumentID = instrument.instrumentID });
            }

            return View(client);
        }

        #endregion

        #region Summary ActionResult

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            Instrument instrument = db.Instuments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;

            ViewBag.Total = instrument.price * 18;
            ViewBag.Image = string.Format("../Content/{0}Square.jpg", instrument.description);

            return View();
        }

        #endregion

        #region UpdateData ActionResult

        [Authorize]
        public ActionResult UpdateData()
        {
            return View(db.Clients.ToList());
        }

        #endregion

        #region Edit ActionResult

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,firstname,lastname,address,city,state,zip,email,phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateData");
            }
            return View(client);
        }

        #endregion

        #region Delete ActionResult

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);

            db.Database.ExecuteSqlCommand("UPDATE Instrument SET Instrument.clientID = null " +
                                        "WHERE Instrument.clientID = " + id + ";");
            db.SaveChanges();
            return RedirectToAction("UpdateData");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Login ActionResult

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String name = form["Name"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(name, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(name, rememberMe);

                return RedirectToAction("UpdateData", "Home");
            }
            else
            {
                return View();
            }
        }

        #endregion

        #region Logoff ActionResult

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("BlowOut", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        #endregion

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        #endregion

    }
}