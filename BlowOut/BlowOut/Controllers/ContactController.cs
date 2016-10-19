using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public String Index()
        {
            return "Please call support at <b><u>801-555-1212</u></b>. Thank you!";
        }

        // email
        public String Email(String name, String email)
        {
            return "Thank you " + name + " We will send an email to " + email;
        }
    }
}