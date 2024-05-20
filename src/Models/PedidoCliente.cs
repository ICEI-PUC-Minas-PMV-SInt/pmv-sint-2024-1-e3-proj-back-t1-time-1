using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("PedidosClientes")]
    public class PedidoCliente
    {
        [Key]
        [Display(Name = "Id do Pedido")]
        public int IdPedido { get; set; }

        [Required]
        [Display(Name = "Data do Pedido")]
        public DateTime DtPedido { get; set; }
        
        [Required]
        [Display(Name = "Nota Fiscal")]
        public string NtFiscal { get; set; }

        [Required]
        [Display(Name = "Total do Pedido")]
        public decimal TotalPedido { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
