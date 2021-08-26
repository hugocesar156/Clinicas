using Clinicas.Global;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Funcionario
{
    [Table("funcionario_contato")]
    public class ContatoFuncionario
    {
        [Column("email"), 
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        MaxLength(50, ErrorMessage = ViewErro.CampoInvalido)]
        public string Email { get; set; }

        [ForeignKey("idClinica")]
        public uint IdClinica { get; set; }
    }
}
