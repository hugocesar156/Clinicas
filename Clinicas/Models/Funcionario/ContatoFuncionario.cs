using Clinicas.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Funcionario
{
    [Table("funcionario_contato")]
    public class ContatoFuncionario : Contato
    {
        [Column("email"), 
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        MaxLength(50, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Email { get; set; }

        [ForeignKey("idClinica")]
        public uint IdClinica { get; set; }
    }
}
