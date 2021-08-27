using Clinicas.Global;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Usuario
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("idUsuario"), Key]
        public uint IdUsuario { get; set; }

        [Column("email"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ViewErro.CampoInvalido), EmailAddress]
        public string Email { get; set; }

        [Column("senha"),
        Required(ErrorMessage = ViewErro.CampoObrigatorio),
        MaxLength(60, ErrorMessage = ViewErro.CampoInvalido)]
        public string Senha { get; set; }

        [NotMapped, Compare("Senha")]
        public string ConfirmaSenha { get; set; }
    }
}
