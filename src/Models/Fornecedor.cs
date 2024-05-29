using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "DDD do telefone (código de área)")]
        public int TelefoneDDD { get; set; }

        [Required]
        [Display(Name = "Número de telefone")]
        public int TelefoneNumero { get; set; }

        [Required]
        [Display(Name ="CEP")]
        public int Cep { get; set; }

        [Required]
        public string Logadouro { get; set; }

        [Required]
        public int Numero { get; set; }
        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}