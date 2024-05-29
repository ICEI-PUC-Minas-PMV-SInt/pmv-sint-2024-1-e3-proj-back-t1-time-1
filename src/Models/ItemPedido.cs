using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("ItemPedido")]
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A quantidade do pedido é obrigatória!")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O valor da unidade é obrigatório!")]
        [Display(Name = "Valor unitário")]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "O valor total não pode ser nulo!")]
        [Display(Name = "Valor total")]
        public decimal ValorTotal { get; set; }

        [ForeignKey("PedidoCliente")]
        public int PedidoClienteId { get; set; }
        public virtual PedidoCliente PedidosCliente { get; set; }
    }
}