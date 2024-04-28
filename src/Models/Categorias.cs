using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Pharma.Models

{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id_categoria { get; set; }
        [Required(ErrorMessage ="Obrigatório informar o nome da categoria")]
        [Display(Name = "Nome da Categoria")]
        public string NomeCategoria { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a descrição da categoria")]
        [Display(Name = "Descrição da Categoria")]
        public string DescricaoCategoria { get; set; }

        [Display(Name = "Usuário")]

        [Required(ErrorMessage = "Obrigaório informar o usuário")]
        public int UsuarioId { get; set;}
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set;}

    }
}
