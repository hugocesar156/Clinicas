using Clinicas.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Clinicas.Sessions
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _context;

        public Sessao(IHttpContextAccessor context) => _context = context;

        public Usuario Buscar(string chave)
        {
            return _context.HttpContext.Session.GetString(chave) != null ?
                JsonConvert.DeserializeObject<Usuario>(_context.HttpContext.Session.GetString(chave)) : null;
        }

        public void Remover(string chave)
        {
            _context.HttpContext.Session.Remove(chave);
        }

        public void Salvar(object valor, string chave)
        {
            _context.HttpContext.Session.SetString(chave, JsonConvert.SerializeObject(valor));
        }
    }
}
