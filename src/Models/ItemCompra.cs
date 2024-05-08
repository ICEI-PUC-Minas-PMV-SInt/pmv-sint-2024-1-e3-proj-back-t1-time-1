using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("ItemCompra")]
    public class ItemCompra
    {
        [Key]
        public int IdItemCompra { get; set; }

        [ForeignKey("PedidoCliente")]
        public int IdCompra { get; set; }
        public virtual PedidoCliente PedidoCliente { get; set; }

        //[ForeignKey("Produtos")]
        //public int IdProduto { get; set; }
        //public virtual Produtos Produtos { get; set; }

        public int QtProduto { get; set; }
        public decimal VlTotalItem { get; set; }
        public decimal VlUnitarioItem { get; set; }
    }

}

