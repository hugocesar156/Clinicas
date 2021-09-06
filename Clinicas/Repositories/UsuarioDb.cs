using Clinicas.Data;
using Clinicas.Models.Usuario;
using System;
using System.Linq;

namespace Clinicas.Repositories
{
    public class UsuarioDb
    {
        private readonly DatabaseContext _banco;

        public UsuarioDb(DatabaseContext banco) => _banco = banco;

        public bool Registrar(Usuario usuario)
        {
            try
            {
                _banco.Add(usuario);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }

        public bool ValidarEmail(string email)
        {
            try
            {
                return _banco.Usuario
                    .FirstOrDefault(u => u.Email == email) == null;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }
    }
}
