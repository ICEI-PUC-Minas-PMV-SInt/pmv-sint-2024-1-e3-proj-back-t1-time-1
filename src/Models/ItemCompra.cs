using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("ItemCompra")]
    public class ItemCompra
    {
        [Key]
        public int Id { get; set; }

        // ...

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Valor da unidade")]
        public int ValorUnitario { get; set; }
    }
}