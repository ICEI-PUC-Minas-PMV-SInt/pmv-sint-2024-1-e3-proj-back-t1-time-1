using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("MovimentacaoEstoque")]
    public class MovimentacaoEstoque
    {
        /// <summary>
        /// ID (pk) da movimentação.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Pedido desta movimentação.
        /// 
        /// (Relação ItemPedido-MovimentacaoEstoque)
        /// </summary>
        [ForeignKey("ItemPedido")]
        public int ItemPedidoId { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }

        /// <summary>
        /// Quantidade de produtos desta movimentação.
        /// </summary>
        [Required(ErrorMessage = "A quantidade de produtos é obrigatória!")]
        [Display(Name = "Quantidade de produtos")]
        public int QuantidadeProduto { get; set; }

        /// <summary>
        /// Tipo de movimentação.
        /// </summary>
        [Required(ErrorMessage = "É necessário especificar um tipo de movimentação!")]
        [Display(Name = "Tipo de movimentação")]
        public TipoMovimentacao TipoMovimentacao { get; set; }

        /// <summary>
        /// Data da movimentação.
        /// </summary>
        [Required(ErrorMessage = "É necessário especificar uma data para a movimentação!")]
        [Display(Name = "Data da movimentação")]
        [DataType(DataType.Date)]
        public DateTime DataMovimentacao { get; set; }
    }

    public enum TipoMovimentacao
    {
        Entrada,
        Saída,
    }
}