using Clinicas.Authorizations.Clinica;
using Clinicas.Models.Clinica;
using Clinicas.Models.Shared;
using Clinicas.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public PartialViewResult Detalhamento(uint idClinica)
        {
            return PartialView("Detalhamento", _clinicaDb.Buscar(idClinica));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditarClinica(Clinica clinica)
        {
            clinica.IdClinica = uint.Parse(TempData["idClinica"].ToString());

            if (!_clinicaDb.ValidarCnpj(clinica.Cnpj, clinica.IdClinica))
                ModelState.AddModelError("Cnpj", ModelError.Clinica.CnpjInvalido);

            if (ModelState.IsValid)
            {
                ViewBag.Notificacao = _clinicaDb.Atualizar(clinica) ?
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.EdicaoRealizada) :
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaEdicao);
            }

            TempData["idClinica"] = clinica.IdClinica;
            return PartialView("Edicao", clinica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RegistrarClinica(Clinica clinica)
        {
            if (!_clinicaDb.ValidarCnpj(clinica.Cnpj))
                ModelState.AddModelError("Cnpj", ModelError.Clinica.CnpjInvalido);

            if (!ModelState.IsValid)
                return PartialView("Cadastro", clinica);

            if (_clinicaDb.Registrar(clinica))
            {
                ViewBag.Notificacao =
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.CadastroRealizado);

                ModelState.Clear();
                return PartialView("Cadastro", new Clinica());
            }

            ViewBag.Notificacao =
                   Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaCadastro);

            return PartialView("Cadastro", clinica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RemoverClinica(uint idClinica)
        {
            ViewBag.Notificacao = _clinicaDb.Deletar(idClinica) ?
                  Notificacao.GerarNotificacao(Notificacao.Mensagem.RegistroRemovido) :
                  Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaRemocao);

            return PartialView("Lista", _clinicaDb.Listar());
        }

        [ClinicaAutorizacao.Cadastro]
        public IActionResult Cadastro()
        {
            return View(new Clinica());
        }

        [HttpGet]
        public IActionResult Edicao(uint idClinica)
        {
            TempData["idClinica"] = idClinica;
            return View(_clinicaDb.Buscar(idClinica));
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(_clinicaDb.Listar());
        }
    }
}
