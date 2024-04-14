using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models

{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public int Id_categoria { get; set; }
        [Required(ErrorMessage ="Obrigatório informar o nome da categoria")]
        public string NomeCategoria { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a descrição da categoria")]
        public string DescricaoCategoria { get; set; }
    }
}
