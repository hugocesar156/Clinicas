using Clinicas.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Clinica
{
    [Table("clinica_contato")]
    public class ContatoClinica : Contato
    {
        [ForeignKey("idClinica")]
        public uint IdClinica { get; set; }
    }
}
