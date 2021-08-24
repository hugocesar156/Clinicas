using Microsoft.AspNetCore.Mvc;
using Clinicas.Models.Clinica;
using Clinicas.Repositories;
using Clinicas.Models.Shared;

namespace Clinicas.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly ClinicaDb _clinicaDb;

        public ClinicaController(ClinicaDb clinicaDb)
        {
            _clinicaDb = clinicaDb;
        }

        [HttpGet]
        public PartialViewResult AtualizarLista(int pagina, string pesquisa = "")
        {
            return PartialView("Tabela", 
                _clinicaDb.Listar(pagina, pesquisa != null ? pesquisa?.ToUpper().Trim() : string.Empty));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RegistrarClinica(Clinica clinica)
        {
            if (!ModelState.IsValid)
                return PartialView("Cadastro", clinica);

            if (_clinicaDb.Buscar(clinica.Cnpj) != null)
                ViewBag.Notificacao = 
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.CnpjInvalido);

            else if (_clinicaDb.Registrar(clinica))
            {
                ViewBag.Notificacao = 
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.CadastroRealizado);

                ModelState.Clear();
                return PartialView("Cadastro", new Clinica());
            }
            else
                ViewBag.Notificacao = 
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaCadastro);

            return PartialView("Cadastro", clinica);
        }

        public IActionResult Cadastro()
        {
            return View(new Clinica());
        }

        public IActionResult Lista()
        {
            return View(_clinicaDb.Listar());
        }
    }
}
