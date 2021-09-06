using Clinicas.Models.Shared;
using System.Collections.Generic;
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
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio), 
        MaxLength(45, ErrorMessage = ModelError.Geral.CampoInvalido), EmailAddress]
        public string Email { get; set; }

        [Column("senha"),
        Required(ErrorMessage = ModelError.Geral.CampoObrigatorio),
        MinLength(6, ErrorMessage = ModelError.Geral.CampoInvalido),
        MaxLength(20, ErrorMessage = ModelError.Geral.CampoInvalido)]
        public string Senha { get; set; }

        [NotMapped, Compare("Senha", ErrorMessage = ModelError.Usuario.ConfirmaSenha)]
        public string ConfirmaSenha { get; set; }

        [Column("idPerfil", TypeName = "TINYINT(4)"), 
        ForeignKey("idPerfil"), Required]
        public byte IdPerfil { get; set; }

        public enum Perfil
        {
            Administrador = 1,
            Gerente,
            Financeiro,
            Veterinario,
            Cliente
        }

        public static Dictionary<byte, string> ListarPerfil()
        {
            return new Dictionary<byte, string>
            {
                {1, "Administrador"},
                {2, "Gerente"},
                {3, "Financeiro"},
                {4, "Veterinário"},
                {5, "Cliente"},
            };
        }
    }
}
