using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Clinicas.Models.Shared
{
    public abstract class Endereco
    {
        private string _cep;
        private string _logradouro;
        private string _numero;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _complemento;

        [Column("idEndereco"), Key]
        public uint IdEndereco { get; set; }

        [Column("cep"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        StringLength(8, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Cep 
        { 
            get => _cep; 
            set => _cep = Regex.Replace(value, @"[^0-9a-zA-Z]+", ""); 
        }

        [Column("logradouro"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Logradouro
        {
            get => _logradouro;
            set => _logradouro = value.ToUpper().Trim();
        }

        [Column("numero"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(5, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Numero
        {
            get => _numero;
            set => _numero = value.ToUpper().Trim();
        }

        [Column("bairro"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Bairro
        {
            get => _bairro;
            set => _bairro = value.ToUpper().Trim();
        }

        [Column("cidade"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Cidade
        {
            get => _cidade;
            set => _cidade = value.ToUpper().Trim();
        }

        [Column("uf"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        StringLength(2, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Uf
        {
            get => _uf;
            set => _uf = value.ToUpper().Trim();
        }

        [Column("complemento"), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Complemento
        {
            get => _complemento;
            set => _complemento = value?.ToUpper().Trim();
        }

        public static Dictionary<string, string> ListarEstados()
        {
            return new Dictionary<string, string>
            {
                {"AC", "Acre"},
                {"AL", "Alagoas"},
                {"AP", "Amapá"},
                {"AM", "Amazonas"},
                {"BA", "Bahia"},
                {"CE", "Ceará"},
                {"DF", "Distrito Federal"},
                {"ES", "Esperito Santo"},
                {"GO", "Goiás"},
                {"MA", "Maranhão"},
                {"MT", "Manto Grosso"},
                {"MS", "Mato Grosso do Sul"},
                {"MG", "Minas Gerais"},
                {"PA", "Pará"},
                {"PB", "Paraíba"},
                {"PR", "Paraná"},
                {"PE", "Pernambuco"},
                {"PI", "Piauí"},
                {"RJ", "Rio de Janeiro"},
                {"RN", "Rio Grande do Norte"},
                {"RS", "Rio Grande do Sul"},
                {"RO", "Rondônia"},
                {"RR", "Roraima"},
                {"SC", "Santa Catarina"},
                {"SP", "São Paulo"},
                {"SE", "Sergipe"},
                {"TO", "Tocantins"},
            };
        }
    }
}