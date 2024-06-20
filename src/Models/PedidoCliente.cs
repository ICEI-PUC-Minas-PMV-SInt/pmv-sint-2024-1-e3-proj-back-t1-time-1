using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("PedidoCliente")]
    public class PedidoCliente
    {
        /// <summary>
        /// ID (pk) do Pedido do Cliente
        /// </summary>
        [Key]
        [Display(Name = "ID do pedido")]
        public int Id { get; set; }

        /// <summary>
        /// Data em que o pedido foi feito.
        /// </summary>
        [Required(ErrorMessage = "Data do pedido é obrigatória!")]
        [Display(Name = "Data do pedido")]
        [DataType(DataType.Date)]
        public DateTime DataPedido { get; set; }

        /// <summary>
        /// Sequência da nota fiscal para o pedido.
        /// 
        /// OBS: de certa forma, por uma nota fiscal ser um identificador
        /// único, se torna um ID redundante?
        /// </summary>
        [Required(ErrorMessage = "A nota fiscal é obrigatória!")]
        [Display(Name = "Nota fiscal")]
        public string NotaFiscal { get; set; }

        /// <summary>
        /// Total monetário do pedido.
        /// </summary>
        [Required(ErrorMessage = "O total do pedido não pode ser nulo!")]
        [Display(Name = "Total do pedido")]
        public decimal TotalPedido { get; set; }

        /// <summary>
        /// Cliente que fez este pedido.
        /// 
        /// (Relação Cliente-PedidoCliente)
        /// </summary>
        [ForeignKey("Cliente")]
        [Display(Name = "CPF do cliente")]
        public int ClienteId { get; set; }
        public virtual Cliente Clientes { get; set; }
    }
}