# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

# Padrões da Aplicação

## Padrão MVC

Padrão de design de software arquitetural que organiza a aplicação da seguinte forma:

### Model

É o objeto da aplicação, onde definimos os campos de cada entidade, tipo e regras.
Ex: A classe de Categorias, Usuário e Produto

```
 [Table("Categorias")]
 public class Categoria
 {
   [Key]
   public int Id { get; set; }

   [Required(ErrorMessage ="Obrigatório informar o nome da categoria")]
   [Display(Name = "Nome da Categoria")]
   public string NomeCategoria { get; set; }

   [Required(ErrorMessage = "Obrigatório informar a descrição da categoria")]
   [Display(Name = "Descrição da Categoria")]
   public string DescricaoCategoria { get; set; }

   ...
  }
```

### View

Responsável pelo visual a qual o usuário interage
Ex: Páginas dinâmicas geradas com o Razor como a de listagem, criação, edição e remoção de itens.

```
 // Páginas de exemplos na pasta Views > Localizacao

 - Create.cshtml
 - Delete.cshtml
 - Details.cshtml
 - Edit.cshtml
 - Index.cshtml

```

### Controller

É o intermediário entre a model e a view gerenciando, garantindo que os dados sejam mostrados corretamente de acordo com a requisição do usuário.

```
 ...
 namespace Pharma.Controllers
 {
     public class CategoriasController : Controller
     {
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Categoria> dados;


            if (User.IsInRole("Admin"))
            {
                 dados = await _context.Categorias.Include(c => c.Usuario).ToListAsync();


            } else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                dados = await _context.Categorias
                    .Include(c => c.Usuario)
                    .Where(c => c.UsuarioId == int.Parse(userId))
                    .ToListAsync();

            }

            return View(dados);
        }
...

```

## Funcionalidades

### Tela Principal

Tela principal com botão de acessar conta.
![Tela - Principal](./img/Telas/Principal/tela_principal.png)

Responsáveis:

- Estruturação da Página e lógica: Gabriel Marco
- Estilização: Alessandra Gabriele

### Login

![Tela - Login](./img/Telas/Login/login.png)

Mensagens de apoio ao usuário caso algum campo não esteja preeenchido

![Tela - Login com campos vazios](./img/Telas/Login/campos_vazios.png)

Caso o mesmo digite dados inválidos, será alertado por ua caixa de texto

![Tela - Login com credenciais inválidas](./img/Telas/Login/credenciais_invalidas.png)

Responsáveis:

- Estruturação da Página, autenticação de usuário e rendeização de menus conforme tipo de usuário (admin ou formacêutico): Gabriel Marco
- Estilização e lógica na view para mostrar mensagem de credenciais inválidas: Alessandra Gabriele  

### Criar Conta

![Tela - Criar conta](./img/Telas/Login/criar_conta.png)

![Tela - Criar conta](./img/Telas/Login/criar_conta_campos_vazios.png)

Responsáveis:

- Estruturação da Página, validações de campos e lógica para criação do primeiro usuário como admin e automaticamente os próximos como farmacêutico: Gabriel Marco
- Estilização: Alessandra Gabriele


### Usuários

### Categorias

Lista de categorias 
![Tela - listagemd e Categorias](./img/Telas/Categoria/listagem.png)

A criação de categoria no momento está com apenas um campo, pois com a integração ficou faltando o campo de descrição que em breve será adicionado

![Tela - Cadastro de Categoria](./img/Telas/Categoria/cadastro.png)

Edição
![Tela - Cadastro de Categoria](./img/Telas/Categoria/editar.png)

Exclusão
![Tela - Cadastro de Categoria](./img/Telas/Categoria/excluir.png)

Listagem de categorias Admin, onde o mesmo tem a possibilidade de visualizar todas as categorias cadastradas e qual usuário cadastrou
![Tela - Cadastro de Categoria](./img/Telas/Categoria/categoria_admin.png)


Responsáveis:

- Lógica para listar todas categorias cadastradas para o admin e listar para o farmacêutico somente as categorias que ele cadastrou: Alessandra Gabriele e Wesley Murat
- Estruturação da Model: Alessandra Murat
- Lógica de Listar, Cadastrar, Excluir e Editar: Alessandra Murat 
- Criação da View e Estilização: Alessandra Gabriele


### Clientes

### Vendas

### Localizações

Responsáveis:

- Lógica para listar todas as localizações cadastradas para o admin e listar para o farmacêutico somente as localizações que ele cadastrou: Wesley Murat e Alessandra (No momento não está aplicado a essa tela por conta das alterações na integração)
- Estruturação da Model: Wesley Murat
- Lógica de Listar, Cadastrar, Excluir e Editar: Wesley Murat
- Criação da View: Wesley Murat
- Estilização: Alessandra Gabriele

### Produto
- Acompanhamento para realização da tarefa: Gean Campos
- Estruturação da Model: Laura Alice
- Lógica de Listar, Cadastrar, Excluir e Editar: Laura Alice
- Criação da View: Laura Alice


### Estoque 