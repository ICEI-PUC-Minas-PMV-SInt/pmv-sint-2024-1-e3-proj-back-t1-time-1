using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        // [ForeignKey("Pessoa")]
        // public int IdPessoa { get; set; }
        // public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
