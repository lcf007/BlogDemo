﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Api.Controllers
{
    [Route("api/values")]
    public class ValueController : Controller
    {
        public IActionResult Index()
        {
            return Ok("api/posts started, Enjoy!");
        }
    }
}