using Clinicas.Models.Funcionario;
using Clinicas.Models.Shared;
using Clinicas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Clinicas.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ClinicaDb _clinicaDb;
        private readonly FuncionarioDb _funcionarioDb;

        public FuncionarioController(ClinicaDb clinicaDb, FuncionarioDb funcionarioDb)
        {
            _clinicaDb = clinicaDb;
            _funcionarioDb = funcionarioDb;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RegistrarFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return PartialView("Cadastro", funcionario);

            if (!_clinicaDb.ValidarCnpj(funcionario.Clinica.Cnpj))
                ViewBag.Notificacao =
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.CnpjInvalido);

            return PartialView("Cadastro", funcionario);
        }

        public IActionResult Cadastro()
        {
            var funcionario = new Funcionario
            {
                Usuario = new Models.Usuario.Usuario(),
                Clinica = new Models.Clinica.Clinica()
            };

            return View(funcionario);
        }
    }
}
