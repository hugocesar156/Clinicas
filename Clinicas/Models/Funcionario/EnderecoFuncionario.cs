using Clinicas.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Funcionario
{
    [Table("funcionario_endereco")]
    public class EnderecoFuncionario : Endereco
    {
        [ForeignKey("idFuncionario")]
        public uint IdFuncionario { get; set; }
    }
}
