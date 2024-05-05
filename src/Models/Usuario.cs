using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharma.Models
{
    public enum Cargos
    {
        Admin,
        Farmaceutico
    }

    /**
        Não coloque acento (ou traços) nas tabelas!!
    **/
    [Table("Usuarios")]
    public class Usuario
    {
        /// <summary>
        /// Id (chave primária) do usuário
        /// </summary>
        /// 
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// "Handler" para acesso do usuário (ex: `user123`, `capivara40`)
        /// </summary>
        [Required(ErrorMessage = "Nome para acesso é obrigatório!")]
        public string AcessoUsuario { get; set; }
        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        /// <summary>
        /// Cargo (tipo) do usuário. Pode ser ou um farmacêutico ou um administrador.
        /// 
        /// 11/04: Por enquanto, qualquer um pode colocar o cargo que desejar, apenas
        /// para não complicar demais o código. Eventualmente colocaremos um tipo de
        /// restrição e um usuário administrador "padrão", para que só ele consiga
        /// registrar outros administradores (e não deixar qualquer um ser adm.)
        /// </summary>
        [Required(ErrorMessage = "O usuário precisa ser um administrador ou um farmacêutico!")]
        public Cargos Cargo { get; set; }

        //Relação virtual entre usuário e Categorias 
        public ICollection<Categoria> Categorias { get; set; }

        public ICollection<Localizacao> Localizacoes { get; set; }
    }
}