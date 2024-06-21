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

A opção de usuários somente estará disponível para usuário do tipo admin

Lista de Usuários
![Tela - Listagem de Usuários](./img/Telas/Usuários/listagem.png)

Para o cadastro foi utilizado a mesma tela para criar conta, mas com a adição do campo do tipo de usuário e botão de voltar
![Tela - Listagem de Usuários](./img/Telas/Usuários/cadastrar.png)

Detalhes do usuário
![Tela - Detalhes do Usuário](./img/Telas/Usuários/detalhes.png)

Editar Usuário
![Tela - Editar Usuário](./img/Telas/Usuários/editar.png)

Alerta de mensagem, caso o admin tente excluir o único admin do sistema
![Tela - Excluir Usuário](./img/Telas/Usuários/alterta.png)

Exclusão
![Tela - Excluir Usuário](./img/Telas/Usuários/excluir.png)

Responsáveis:

- Estruturação da Model: Gabriel Marco
- Lógica de Listar, Visualizar detalhes, Cadastrar, Excluir e Editar: Gabriel Marco
- Criação da View: Gabriel Marco
- Criação de lógica para alterar rota e texto do botão na tela de cadastro
- Estiização: Alessandra Gabriele

### Categorias

Lista de categorias
![Tela - Listagem de Categorias](./img/Telas/Categoria/listagem.png)

A criação de categoria no momento está com apenas um campo, pois com a integração ficou faltando o campo de descrição que em breve será adicionado

![Tela - Cadastro de Categoria](./img/Telas/Categoria/cadastro.png)

Detalhes
![Tela - Detalhes da categoria](./img/Telas/Categoria/detalhes.png)

Edição
![Tela - Edição de Categoria](./img/Telas/Categoria/editar.png)

Exclusão
![Tela - Exclusão de Categoria](./img/Telas/Categoria/excluir.png)

Listagem de categorias Admin, onde o mesmo tem a possibilidade de visualizar todas as categorias cadastradas e qual usuário cadastrou
![Tela - Listagem de Categorias - Admin](./img/Telas/Categoria/categoria_admin.png)

Responsáveis:

- Lógica para listar todas categorias cadastradas para o admin e listar para o farmacêutico somente as categorias que ele cadastrou: Alessandra Gabriele e Wesley Murat
- Estruturação da Model: Alessandra Murat
- Lógica de Listar, Visualizar detalhes, Cadastrar, Excluir e Editar: Alessandra Murat
- Criação da View e Estilização: Alessandra Gabriele

### Clientes

Lista de clientes
![Tela - Listagem de Clientes](./img/Telas/Clientes/listagem_clientes.png)

Cadastro
![Tela - Cadastro de Clientes](./img/Telas/Clientes/cadastro_clientes_1.png)
![Tela - Cadastro de Clientes](./img/Telas/Clientes/cadastro_clientes_2.png)

Detalhes
![Tela - Detalhes dos Clientes](./img/Telas/Clientes/detalhes_clientes.png)

Edição
![Tela - Edição de Clientes](./img/Telas/Clientes/edicao_clientes_1.png)
![Tela - Edição de Clientes](./img/Telas/Clientes/edicao_clientes_2.png)

Exclusão
![Tela - Exclusão de Clientes](./img/Telas/Clientes/excluir_clientes.png)

Responsável:

- Estruturação da Model: Gean Campos
- Lógica de Listar, Visualizar Detalhes, Cadastrar, Excluir e Editar: Gean Campos
- Criação da View e Estilização: Gean Campos

### Fornecedores

Lista de fornecedores
![Tela - Listagem de Fornecedores](./img/Telas/Fornecedores/listagem_fornecedores.png)

Cadastro
![Tela - Cadastro de Fornecedores](./img/Telas/Fornecedores/cadastro_fornecedores.png)

Detalhes
![Tela - Detalhes dos Fornecedores](./img/Telas/Fornecedores/detalhes_fornecedores.png)

Edição
![Tela - Edição de Fornecedores](./img/Telas/Fornecedores/editar_fornecedores.png)

Exclusão
![Tela - Exclusão de Fornecedores](./img/Telas/Fornecedores/excluir_fornecedores.png)

Responsável:

- Estruturação da Model: Camila Santos
- Lógica de Listar, Visualizar Detalhes, Cadastrar, Excluir e Editar: Camila
- Criação da View e Estilização: Camila

### Vendas

#### Página funcionando totalmente, mas existe a dependência da criação de um cliente, o que não está totalmente implementado ainda.

Responsável:

- Estruturação da Model: Gean Campos
- Lógica de Listar, Visualizar Detalhes, Cadastrar, Excluir e Editar: Gean Campos
- Criação da View e Estilização: Gean Campos

### Compras

Responsável:

- Estruturação da Model: Camila Santos
- Lógica de Listar, Visualizar Detalhes, Cadastrar, Excluir e Editar: Camila Campos
- Criação da View e Estilização: Camila Campos

### Localizações

![Tela - Listagem de Localizações](./img/Telas/Localizacoes/listagem.png)

Cadastro com validação de campos
![Tela - Cadastro de Localização](./img/Telas/Localizacoes/cadastrar.png)

Detalhes
![Tela - Detalhes da Localização](./img/Telas/Localizacoes/detalhes.png)

Edição
![Tela - Edição de Localiazção](./img/Telas/Localizacoes/editar.png)

Exclusão
![Tela - Excluir Localização](./img/Telas/Localizacoes/excluir.png)

Responsáveis:

- Lógica para listar todas as localizações cadastradas para o admin e listar para o farmacêutico somente as localizações que ele cadastrou: Wesley Murat e Alessandra (No momento não está aplicado a essa tela por conta das alterações na integração)
- Estruturação da Model: Wesley Murat
- Lógica de Listar, Visualizar detalhes, Cadastrar, Excluir e Editar: Wesley Murat
- Criação da View: Wesley Murat
- Estilização: Alessandra Gabriele

### Produto

![Tela - Listagem de Produtos](./img/Telas/Produto/listagem.png)

Cadastro de produto
![Tela - Cadastro de Produto](./img/Telas/Produto/cadastrar.png)

Edição de produto
![Tela - Edição de Produto](./img/Telas/Produto/editar.png)

Detalhe do produto
![Tela - Detalhe do Produto](./img/Telas/Produto/detalhes.png)

Exclusão do Produto
![Tela - Exclusão do Produto](./img/Telas/Produto/excluir.png)

- Acompanhamento para realização da tarefa: Gean Campos
- Estruturação da Model: Laura Alice
- Lógica de Listar, Visualizar detalhes, Cadastrar, Excluir e Editar: Laura Alice
- Criação da View: Laura Alice
- Estilização: Alessandra Murat

### Estoque

![Tela - Estoque](./img/Telas/Estoque/listagem.png)


Responsável:

- Estruturação da Model: Gean Campos
- Lógica de Listar, Visualizar Detalhes, Excluir e Editar: Gean Campos
- Criação da View: Gean Campos

Obs: A lógica segue o modelo de outras telas, entretanto será realizado uma alteração para que o Estoque seja atualizado de acordo com um pedido ou uma compra.

### Tabela intermediária de itens de uma venda (ItemPedidoCliente)

Responsável:

- Estruturação da Model: Gean Campos

Obs: Foi criado a view e os controllers, entretanto será necessário a modificação para essa tabela só receber os itens de cada pedido.

### Tabela intermediária de itens de uma compra (ItemPedidoCompra)

Responsável:

- Estruturação da Model: Celso Nunes

Obs: Foi criado a view e os controllers, entretanto será necessário a modificação para essa tabela só receber os itens de cada pedido.
