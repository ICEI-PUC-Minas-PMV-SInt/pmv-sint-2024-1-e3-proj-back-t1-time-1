using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("PedidosClientes")]
    public class PedidoCliente
    {
        [Key]
        public int IdPedido { get; set; }

        [Required]
        public DateTime DtPedido { get; set; }
        
        [Required]
        public string NtFiscal { get; set; }

        [Required]
        public decimal TotalPedido { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
