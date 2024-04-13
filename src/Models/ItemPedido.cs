using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("ItemsPedidos")]
    public class ItemPedido
    {
        [Key]
        public int IdItemProduto { get; set; }

        [Required]
        public int QtProduto { get; set; }

        [Required]
        public decimal VlUnitario { get; set; }

        [Required]
        public decimal VlTotalItem { get; set; }

        [ForeignKey("PedidoCliente")]
        public int IdPedido { get; set; }
        public virtual PedidoCliente PedidoCliente { get; set;}
    }
}
