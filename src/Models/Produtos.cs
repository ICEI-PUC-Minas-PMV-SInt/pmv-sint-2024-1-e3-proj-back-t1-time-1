using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        public int IdProduto { get; set; }


        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }


        [ForeignKey("Categorias")]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria   { get; set; }


        [ForeignKey("Localizacoes")]
        public int IdLocalizacao  { get; set; }
        public virtual Localizacao Localizacao { get; set; }


        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
