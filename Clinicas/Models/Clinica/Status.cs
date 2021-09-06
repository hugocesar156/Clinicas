using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinicas.Models.Clinica
{
    [Table("clinica_status")]
    public class Status
    {
        [Column("idStatus"), Key]
        public byte IdStatus { get; set; }

        [Column("nome"), Required, MaxLength(45)]
        public string Nome { get; set; }

        [Column("descricao"), Required, MaxLength(45)]
        public string Descricao { get; set; }
    }
}
