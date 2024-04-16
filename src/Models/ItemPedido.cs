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
        [Display(Name = "Quantidade de produtos")]
        public int QtProduto { get; set; }

        [Required]
        [Display(Name = "Valor Unitário")]
        public decimal VlUnitario { get; set; }

        [Required]
        [Display(Name = "Valor Total")]
        public decimal VlTotalItem { get; set; }

        [ForeignKey("PedidoCliente")]
        public int IdPedido { get; set; }
        public virtual PedidoCliente PedidoCliente { get; set;}

        // [ForeignKey("Produto")]
        // public int IdProduto { get; set; }
        // public virtual Produto Produto { get; set; }
    }
}
