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

![Tela - Principal](./img/Telas/Principal/tela_principal.png)

Responsáveis:
- Estruturação da Página: Gabriel Marco
- Estilização: Alessandra Gabriele











Implementação do sistema descritas por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos os artefatos criados (código fonte) além das estruturas de dados utilizadas e as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

Para cada requisito funcional, pode ser entregue um artefato desse tipo

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
