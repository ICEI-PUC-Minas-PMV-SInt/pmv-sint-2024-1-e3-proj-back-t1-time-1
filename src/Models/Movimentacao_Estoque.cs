using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("MovimentacaoEstoque")]
    public class MovimentacaoEstoque
    {
        [Key]
        [Display(Name = "Id da Movimentação")]
        public int IdMovimentacao { get; set; }

        //[ForeignKey("ItemCompra")]
        //public int IdItemCompra { get; set; }
        //public virtual ItemCompra ItemCompra { get; set; }

        [ForeignKey("ItemPedido")]
        public int IdItemPedido { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }

        [Required]
        [Display(Name = "Quantidade de Produtos")]
        public int QtProduto { get; set; }

        [Required]
        [Display(Name = "Tipo de Movimentação")]
        public string TpMovimentacao { get; set; }

        [Required]
        [Display(Name = "Data da Movimentação")]
        public DateTime DtMovimentacao { get; set; }
    }
}
