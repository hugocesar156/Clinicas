using Clinicas.Data;
using Clinicas.Models.Funcionario;
using System;

namespace Clinicas.Repositories
{
    public class FuncionarioDb
    {
        private readonly DatabaseContext _banco;

        public FuncionarioDb(DatabaseContext banco) => _banco = banco;

        public bool Registrar(Funcionario funcionario)
        {
            try
            {
                _banco.Add(funcionario);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }
    }
}
