using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
    }
}
