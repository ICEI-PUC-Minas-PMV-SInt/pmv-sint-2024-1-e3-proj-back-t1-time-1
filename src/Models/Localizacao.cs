using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models {
    [Table("Localizacao")]
    public class Localizacao {
        /// <summary>
        /// ID (pk) da localização.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do local.
        /// </summary>
        [Required(ErrorMessage ="O nome da localização é obrigatório!")]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do local.
        /// 
        /// OBS: precisa ser obrigatório?
        /// </summary>
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        /// <summary>
        /// OBS: Capacidade do quê?
        /// </summary>
        [Required(ErrorMessage ="A capacidade é obrigatória!")]
        public int Capacidade { get; set; }
    }
}