using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("PedidoCompra")]
    public class PedidoCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }
        
        [Required]
        public string NotaFiscal { get; set; }

        [Required]
        public decimal TotalPedido { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}