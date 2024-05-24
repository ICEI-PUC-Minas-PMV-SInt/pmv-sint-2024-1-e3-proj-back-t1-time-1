using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("PedidoCompra")]
    public class PedidoCompra
    {
        [Key]
        public int IdCompra { get; set; }

        [Required]
        public DateTime DtCompra { get; set; }
        
        [Required]
        public string NtFiscal { get; set; }

        [Required]
        public decimal TotalPedido { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdCFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
