using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult BlowOut()
        {
            return View();
        }

        public ActionResult Rentals()
        {
            return View();
        }

        public ActionResult InstrumentRental(String instrument, String insCondition)
        {
            if (instrument == "Trumpet" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/TrumpetSquare.jpg'";
                ViewBag.RentalPrice = "$55 a month";
                ViewBag.Instrument = "Trumpet";
                ViewBag.Type = "New";
            }
            else if (instrument == "Trumpet" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/TrumpetSquare.jpg'";
                ViewBag.RentalPrice = "$25 a month";
                ViewBag.Instrument = "Trumpet";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Trombone" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/TromboneSquare.jpg'";
                ViewBag.RentalPrice = "$60 a month";
                ViewBag.Instrument = "Trombone";
                ViewBag.Type = "New";
            }
            else if (instrument == "Trombone" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/TromboneSquare.jpg'";
                ViewBag.RentalPrice = "$35 a month";
                ViewBag.Instrument = "Trombone";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Tuba" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/TubaSquare.jpg'";
                ViewBag.RentalPrice = "$70 a month";
                ViewBag.Instrument = "Tuba";
                ViewBag.Type = "New";
            }
            else if (instrument == "Tuba" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/TubaSquare.jpg'";
                ViewBag.RentalPrice = "$50 a month";
                ViewBag.Instrument = "Tuba";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Flute" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/FluteSquare.jpg'";
                ViewBag.RentalPrice = "$40 a month";
                ViewBag.Instrument = "Flute";
                ViewBag.Type = "New";
            }
            else if (instrument == "Flute" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/FluteSquare.jpg'";
                ViewBag.RentalPrice = "$25 a month";
                ViewBag.Instrument = "Flute";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Clarinet" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/ClarinetSquare.jpg'";
                ViewBag.RentalPrice = "$35 a month";
                ViewBag.Instrument = "Clarinet";
                ViewBag.Type = "New";
            }
            else if (instrument == "Clarinet" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/ClarinetSquare.jpg'";
                ViewBag.RentalPrice = "$27 a month";
                ViewBag.Instrument = "Clarinet";
                ViewBag.Type = "Used";
            }
            else if (instrument == "Saxophone" && insCondition == "New")
            {
                ViewBag.image = "'~/Content/SaxophoneSquare.jpg'";
                ViewBag.RentalPrice = "$42 a month";
                ViewBag.Instrument = "Saxophone";
                ViewBag.Type = "New";
            }
            else if (instrument == "Saxophone" && insCondition == "Used")
            {
                ViewBag.image = "'~/Content/SaxophoneSquare.jpg'";
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
    }
}