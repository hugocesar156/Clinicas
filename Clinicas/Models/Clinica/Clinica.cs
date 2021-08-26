using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clinicas.Global;
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
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        StringLength(14, ErrorMessage = ViewErro.CampoInvalido),
        CnpjValido(nameof(Cnpj))]
        public string Cnpj
        {
            get => _cnpj;
            set => _cnpj = value.Replace(".", "").Replace("-", "")
                .Replace("/", "").Trim();
        }

        [Column("razaoSocial"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        MaxLength(45, ErrorMessage = ViewErro.CampoInvalido)]
        public string RazaoSocial 
        { 
            get => _razaoSocial; 
            set => _razaoSocial = value.ToUpper().Trim();
        }

        [Column("nomeFantasia"), 
        Required(ErrorMessage = ViewErro.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ViewErro.CampoInvalido)]
        public string NomeFantasia
        {
            get => _nomeFantasia; 
            set => _nomeFantasia = value.ToUpper().Trim();
        }

        [Column("site"), 
        MaxLength(45, ErrorMessage = ViewErro.CampoInvalido)]
        public string Site
        {
            get => _site; 
            set => _site = value.ToUpper().Trim();
        }

        public List<EnderecoClinica> Endereco { get; set; }

        public List<ContatoClinica> Contato { get; set; }
    }
}
