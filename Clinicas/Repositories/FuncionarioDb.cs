using Clinicas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinicas.Repositories
{
    public class FuncionarioDb
    {
        private readonly DatabaseContext _banco;

        public FuncionarioDb(DatabaseContext banco) => _banco = banco;
    }
}
