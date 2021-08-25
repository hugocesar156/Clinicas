﻿using Clinicas.Data;
using Clinicas.Models.Clinica;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Clinicas.Repositories
{
    public class ClinicaDb
    {
        private readonly DatabaseContext _banco;

        public ClinicaDb(DatabaseContext banco) => _banco = banco;

        public Clinica Buscar(uint idClincia)
        {
            try
            {
                return _banco.Clinica.Include(c => c.Endereco).Include(c => c.Contato)
                    .FirstOrDefault(c => c.IdClinica == idClincia);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }

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

        public IPagedList<Clinica> Listar(int pagina = 1, string pesquisa = "")
        {
            try
            {
                return _banco.Clinica.Where(c => c.RazaoSocial.Contains(pesquisa) ||
                c.NomeFantasia.Contains(pesquisa) || c.Cnpj.Contains(pesquisa))
                    .OrderBy(c => c.RazaoSocial).ToPagedList(pagina, 10);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                throw new Exception();
            }
        }
    }
}
