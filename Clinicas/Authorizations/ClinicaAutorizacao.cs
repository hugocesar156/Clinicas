using Clinicas.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Clinicas.Models.Usuario;
using System;

namespace Clinicas.Authorizations.Clinica
{
    public static class ClinicaAutorizacao
    {
        public class Cadastro : Attribute, IAuthorizationFilter
        {
            private Sessao _sessao;

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                _sessao = (Sessao)context.HttpContext.RequestServices.GetService(typeof(Sessao));
                var usuario = _sessao.Buscar("Acesso");

                if (usuario == null)
                    context.Result = new RedirectToActionResult("Entrada", "Acesso", null);

                if (usuario.IdPerfil != (byte)Usuario.Perfil.Administrador)
                    context.Result = new RedirectToActionResult("Inicio", "Painel", null);
            }
        }
    }
}
