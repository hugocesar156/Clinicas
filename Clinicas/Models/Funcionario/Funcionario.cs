using Clinicas.Models.Shared;
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

        [Column("idFuncionario"), Key]
        public uint IdFuncionario { get; set; }

        [Column("nome"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        MaxLength(50, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Nome
        {
            get => _nome;
            set => _nome = value.ToUpper().Trim();
        }

        [Column("cpf"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio)]
        public string Cpf
        {
            get => _cpf;
            set => _cpf = value.Replace(".", "").Replace("-", "");
        }

        [Column("rg"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio)]
        public string Rg
        {
            get => _rg;
            set => _rg = value.Replace(".", "");
        }

        [Column("nascimento"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio)]
        public DateTime? Nascimento { get; set; } = null;

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
