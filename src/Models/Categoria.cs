using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        /// <summary>
        /// ID (pk) da categoria.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria.
        /// </summary>
        [Required(ErrorMessage = "Obrigatório informar o nome da categoria!")]
        [Display(Name = "Nome da categoria")]
        public string Nome { get; set; }

        /// <summary>
        /// OBS: O que o usuário tem a ver com a categoria?
        /// </summary>
        [Required(ErrorMessage = "Obrigatório informar o usuário!")]
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuarios { get; set; }
    }
}