using Clinicas.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Funcionario
{
    [Table("funcionario")]
    public class Funcionario
    {
        private string _nome;
        private string _cpf;
        private string _rg;
        private DateTime _nascimento;

        [Column("idFuncionario"), Key]
        public uint IdFuncionario { get; set; }

        [Column("nome"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        MaxLength(50, ErrorMessage = ViewErro.CampoInvalido)]
        public string Nome
        {
            get => _nome;
            set => _nome = value.ToUpper().Trim();
        }

        [Column("cpf"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio)]
        public string Cpf
        {
            get => _cpf;
            set => _cpf = value.Replace(".", "").Replace("-", "");
        }

        [Column("rg"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio)]
        public string Rg
        {
            get => _rg;
            set => _rg = value.Replace(".", "");
        }

        [Column("nascimento", TypeName = "DATETIME"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio)]
        public DateTime Nascimento 
        {
            get => _nascimento;
            set 
            {
                var data = DateTime.Now;
                
                if (value <= new DateTime(data.Year - 18, data.Month, data.Day))
                    _nascimento = value;
            }
        }

        [ForeignKey("idUsuario")]
        public uint IdUsuario { get; set; }

        public Usuario.Usuario Usuario { get; set; }

        [ForeignKey("idClinica")]
        public uint IdClinica { get; set; }

        public Clinica.Clinica Clinica { get; set; }

        public List<EnderecoFuncionario> Endereco { get; set; }

        public List<ContatoFuncionario> Contato { get; set; }
    }
}
