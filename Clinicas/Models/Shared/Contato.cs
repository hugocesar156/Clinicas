using Clinicas.Global;
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
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        MinLength(10, ErrorMessage = ViewErro.CampoInvalido), 
        MaxLength(11, ErrorMessage = ViewErro.CampoInvalido)]
        public string Numero
        { 
            get => _numero;
            set => _numero = Regex.Replace(value, @"[^0-9a-zA-Z]+", "");
        }
    }
}
