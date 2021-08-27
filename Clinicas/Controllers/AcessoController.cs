using Clinicas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clinicas.Controllers
{
    public class AcessoController : Controller
    {
        public IActionResult Entrada()
        {
            return View();
        }

        public IActionResult Opcoes()
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
