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
        [Display(Name = "Nome da Localização")]
        public string NomeLocalizacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição da localização")]
        [Display(Name = "Descrição da Localização")]
        public string DescricaoLocalizacao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a capacidade")]
        public int Capacidade { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Obrigatório informar o usuário")]
        public int UsuarioId { get; set;}

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }


    }
}
