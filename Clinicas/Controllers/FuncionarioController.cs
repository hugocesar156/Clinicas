using Clinicas.Models.Clinica;
using Clinicas.Models.Funcionario;
using Clinicas.Models.Usuario;
using Clinicas.Models.Shared;
using Clinicas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Clinicas.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ClinicaDb _clinicaDb;
        private readonly FuncionarioDb _funcionarioDb;
        private readonly UsuarioDb _usuarioDb;

        public FuncionarioController(ClinicaDb clinicaDb, FuncionarioDb funcionarioDb, UsuarioDb usuarioDb)
        {
            _clinicaDb = clinicaDb;
            _funcionarioDb = funcionarioDb;
            _usuarioDb = usuarioDb;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RegistrarFuncionario(Funcionario funcionario)
        {
            if (!_usuarioDb.ValidarEmail(funcionario.Usuario.Email))
                ModelState.AddModelError("Usuario.Email", ModelError.Usuario.EmailEmUso);

            if (!_clinicaDb.ValidarCnpj(funcionario.Clinica.Cnpj))
                ModelState.AddModelError("Clinica.Cnpj", ModelError.Clinica.CnpjInvalido);

            if (!ModelState.IsValid)
                return PartialView("Cadastro", funcionario);

            funcionario.Usuario.Senha = Criptografia.TratarCriptografia(funcionario.Usuario.Senha);
            funcionario.Usuario.IdPerfil = (byte)Usuario.Perfil.Gerente;
            funcionario.Clinica.IdStatus = (byte)Clinica.Status.Analise;

            if (_funcionarioDb.Registrar(funcionario))
            {
                ViewBag.Notificacao =
                    Notificacao.GerarNotificacao(Notificacao.Mensagem.CadastroRealizado);

                ModelState.Clear();

                return PartialView("Cadastro", new Funcionario
                {
                    Usuario = new Usuario(),
                    Clinica = new Clinica()
                });
            }

            ViewBag.Notificacao =
                  Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaCadastro);

            return PartialView("Cadastro", funcionario);
        }

        public IActionResult Cadastro()
        {
            var funcionario = new Funcionario
            {
                Usuario = new Usuario(),
                Clinica = new Clinica()
            };

            return View(funcionario);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(_funcionarioDb.Listar());
        }
    }
}
