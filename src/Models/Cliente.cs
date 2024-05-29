using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    public enum Genero
    {
        Masculino,
        Feminino,
        Outro,
    }

    [Table("Cliente")]
    public class Cliente
    {
        /// <summary>
        /// ID (pk) do cliente.
        /// </summary>
        [Key]
        [Display(Name = "ID do cliente")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Genero Genero { get; set; }

        [Display(Name = "DDD do telefone fixo (código de área)")]
        public int TelefoneDDD { get; set; }

        [Display(Name = "Número de telefone fixo")]
        public int TelefoneNumero { get; set; }

        [Required]
        [Display(Name = "DDD do celular (código de área)")]
        public int CelularDDD { get; set; }

        [Required]
        [Display(Name = "Número de celular")]
        public int CelularNumero { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name ="CEP")]
        public int Cep { get; set; }

        [Required]
        public string Logadouro { get; set; }

        public int Numero { get; set; }
        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        /// <summary>
        /// Se o cliente for um usuário do sistema...
        /// 
        /// (Relação Usuario-Cliente)
        /// </summary>
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuarios { get; set; }
    }
}