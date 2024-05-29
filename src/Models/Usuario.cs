using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    public enum Cargos
    {
        Admin,
        Farmaceutico
    }

    [Table("Usuario")]
    public class Usuario
    {
        /// <summary>
        /// ID (pk) do usuário
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// "Handler" para o acesso do usuário
        ///  (ex: "melancia123", "avestruz_argentino")
        /// </summary>
        [Required(ErrorMessage = "Nome para acesso é obrigatório")]
        [Display(Name = "Nome de acesso")]
        public string AcessoUsuario { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        /// <summary>
        /// Cargo (tipo) do usuário. Pode ser um farmacêutico ou um administrador.
        /// 
        /// Por enquanto, ao registrar, pode-se auto-definir o cargo, apenas por
        /// conveniência pra testar melhor. Eventualmente terá uma restrição, com
        /// um administrador padrão, e apenas admins podem adicionar outros admins.
        /// </summary>
        [Required(ErrorMessage = "O usuário precisa ser um administrador ou um farmacêutico!")]
        public Cargos Cargo { get; set; }

        // Relação virtual entre Usuário e Categorias
        public ICollection<Categoria> Categorias { get; set; }
    }
}