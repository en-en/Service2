﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server2.Models;

namespace Server2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Health()
        {
            return Json(true);
        }


        public IActionResult Hello()
        {
            return Json("我是server2");
        }

        [HttpGet]
        public IActionResult GetCurHostIp()
        {
            return Json(HttpContext.Connection.LocalIpAddress.MapToIPv4()?.ToString());
        }

        public IActionResult Test()
        {
            return Json(HttpContext.Connection.LocalIpAddress.MapToIPv4()?.ToString());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
