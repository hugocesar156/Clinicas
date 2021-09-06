using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Clinicas.Models.Shared
{
    public abstract class Contato
    {
        private string _numero;

        [Column("idContato"), Key]
        public uint IdContato { get; set; }

        [Column("numero"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        MinLength(10, ErrorMessage = ModelError.Geral.CampoInvalido), 
        MaxLength(11, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Numero
        { 
            get => _numero;
            set => _numero = Regex.Replace(value, @"[^0-9a-zA-Z]+", "");
        }
    }
}
