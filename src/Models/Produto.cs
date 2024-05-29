using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("Localizacao")]
        public int LocalizacaoId { get; set; }
        public virtual Localizacao Localizacao { get; set; }

        [Required]
        [Display(Name = "Nome do produto")]
        public string NomeProduto { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}