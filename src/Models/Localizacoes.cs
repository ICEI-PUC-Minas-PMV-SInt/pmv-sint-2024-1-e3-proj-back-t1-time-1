using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Localizacoes")]
    public class Localizacao
    {
        [Key]
        public int Id_localizacao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o nome da localização")]
        public string NomeLocalizacao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a descrição da localização")]
        public string DescricaoLocalizacao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a capacidade")]
        public int Capacidade { get; set; }

    }
}
