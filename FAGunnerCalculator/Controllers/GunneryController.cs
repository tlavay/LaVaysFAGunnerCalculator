using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAGunnerCalculator.Controllers
{
    public class GunneryController : Controller
    {
        // GET: Gunnery
        public IActionResult Test()
        {
            return Ok("This worked!");
        }
    }
}