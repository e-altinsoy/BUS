﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus.Controllers
{
    [AllowAnonymous]
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        public ActionResult Index()
        {
            return View();
        }
    }
}