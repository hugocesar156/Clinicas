using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clinicas.Models.Shared;
using Clinicas.Validations;

namespace Clinicas.Models.Clinica
{
    [Table("clinica")]
    public class Clinica
    {
        private string _cnpj;
        private string _razaoSocial;
        private string _nomeFantasia;
        private string _site;

        [Column("idClinica"), Key]
        public uint IdClinica { get; set; }

        [Column("cnpj"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        StringLength(14, ErrorMessage = ModelError.Geral.CampoInvalido),
        CnpjValido(nameof(Cnpj))]
        public string Cnpj
        {
            get => _cnpj;
            set => _cnpj = value.Replace(".", "").Replace("-", "")
                .Replace("/", "").Trim();
        }

        [Column("razaoSocial"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string RazaoSocial 
        { 
            get => _razaoSocial; 
            set => _razaoSocial = value.ToUpper().Trim();
        }

        [Column("nomeFantasia"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string NomeFantasia
        {
            get => _nomeFantasia; 
            set => _nomeFantasia = value.ToUpper().Trim();
        }

        [Column("dataFundacao"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio)]
        public DateTime? DataFundacao { get; set; } = null;

        [Column("site"), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Site
        {
            get => _site; 
            set => _site = value.ToUpper().Trim();
        }

        [Column("idStatus", TypeName = "TINYINT(4)"), 
        ForeignKey("idStatus"), Required]
        public byte IdStatus { get; set; }

        public List<EnderecoClinica> Endereco { get; set; }

        public List<ContatoClinica> Contato { get; set; }

        public enum Status
        {
            Analise = 1,
            Ativa,
            Bloqueada
        }

        public static Dictionary<byte, string> ListarStatus()
        {
            return new Dictionary<byte, string>
            {
                {1, "Análise"},
                {2, "Ativa"},
                {3, "Bloqueada"}
            };
        }
    }
}
