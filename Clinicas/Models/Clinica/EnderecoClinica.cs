using Clinicas.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Clinica
{
    [Table("clinica_endereco")]
    public class EnderecoClinica : Endereco
    {
        [ForeignKey("idClinica")]
        public uint IdClinica { get; set; }
    }
}
