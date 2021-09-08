using Clinicas.Data;
using Clinicas.Models.Funcionario;
using Microsoft.EntityFrameworkCore;
using System;
using X.PagedList;

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

        public IPagedList<Funcionario> Listar(int pagina = 1, string pesquisa = "")
        {
            try
            {
                return _banco.Funcionario.Include(f => f.Clinica)
                    .ToPagedList(pagina, 10);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }
    }
}
