using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinicas.Controllers
{
    public class PainelController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
