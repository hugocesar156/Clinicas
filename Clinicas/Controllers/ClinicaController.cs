﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public PartialViewResult Detalhamento(uint idClinica)
        {
            return PartialView("Detalhamento", _clinicaDb.Buscar(idClinica));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditarClinica(Clinica clinica)
        {
            if (!ModelState.IsValid)
                return PartialView("Edicao", clinica);

            clinica.IdClinica = uint.Parse(TempData["idClinica"].ToString());
       
            if (!_clinicaDb.ValidarCnpj(clinica.Cnpj, clinica.IdClinica))
                ViewBag.Notificacao =
                     Notificacao.GerarNotificacao(Notificacao.Mensagem.CnpjInvalido);

            else if (_clinicaDb.Atualizar(clinica))
                ViewBag.Notificacao =
                     Notificacao.GerarNotificacao(Notificacao.Mensagem.EdicaoRealizada);

            else
                ViewBag.Notificacao =
                      Notificacao.GerarNotificacao(Notificacao.Mensagem.FalhaEdicao);

            return PartialView("Edicao", clinica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult RegistrarClinica(Clinica clinica)
        {
            if (!ModelState.IsValid)
                return PartialView("Cadastro", clinica);

            if (!_clinicaDb.ValidarCnpj(clinica.Cnpj))
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

        [HttpGet]
        public IActionResult Edicao(uint idClinica)
        {
            TempData["IdClinica"] = idClinica;
            return View(_clinicaDb.Buscar(idClinica));
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(_clinicaDb.Listar());
        }
    }
}
