using Clinicas.Data;
using Clinicas.Models.Clinica;
using System;
using System.Linq;

namespace Clinicas.Repositories
{
    public class ClinicaDb
    {
        private readonly DatabaseContext _banco;

        public ClinicaDb(DatabaseContext banco) => _banco = banco;

        public Clinica Buscar(string cnpj)
        {
            try
            {
                return _banco.Clinica.FirstOrDefault(c => c.Cnpj == cnpj);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }

        public bool Registrar(Clinica clinica)
        {
            try
            {
                _banco.Add(clinica);
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
