using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public int Idfornecedor { get; set; }

        // [ForeignKey("Pessoa")]
        // public int IdPessoa { get; set; }
        // public virtual Pessoa Pessoa { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario  { get; set; }
    }
}
