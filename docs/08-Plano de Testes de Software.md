# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Os testes funcionais realizados serão realizados para simular o acesso ao site. Será testada a página de login de acesso do usuário, descrito no Caso de Teste CT-01. Nesse cenário, a página será testada por um dos membros da equipe. 

Os testes funcionais realizados no site estão descritos a seguir.


   |Caso de Teste|CT-01|
   |:---:|:---|
   |Requisitos associados|RF-001 Permitir que o usuário faça login de entrada.<br>RF-002 Permitir que o usuário faça logoff do sistema.
   |Objetivo do teste|Verificar se a autenticação do usuário ocorre adecuadamente.|
   |Passos|<ol><li>Acessar o navegador.</li><li>Informar o endereço do site.</li><li>Visualizar a página de login.</li><li>Efetuar o login.</li><li>Acessar a página      autorizada.</li><li>Efetuar o logoff.</li></ol>|    
   |Critérios de Êxito|<ul><li>A página de login precisa ser carregada corretamente.</li><li>Deve ocorrer a autenticação do usuário.</li><li>Após o login a página inicial        precisa ser carregada.</li><li>A página carregada deve ter acesso ao botão de logoff.</li><li>Após o logoff, a página de login deve ser carregada novamente.</li>   </ul>|
    
 |Caso de Teste|CT-02|
 |:---:|:---|
 |Requisitos associados|RF-003 O usuário deve ser direcionado para uma página destinada ao seu uso. <br>RF-004 A página inicial do sistema deve estar relacionada à função que o usuário desempenhará, seja cliente ou fornecedor.|
 |Objetivo do teste|Verificar se o cadastro de usuários é realizado corretamente, garantindo o preenchimento de todos os campos obrigatórios de forma adequada. Garantindo que o usuário seja redirecionado para a página destinada ao seu uso."|
 |Passos|<ol><li>Acessar o navegador.</li><li>Informar o endereço do site.</li><li>Visualizar a página de login.</li><li>Efetuar o login.</li><li>Acessar a página de cadastro realizando conforme o uso destinado.</li><li>Efetuar o login corretamente.</li><li>Acessar a página inicial.</li><li>Garantir acesso a todo o conteúdo destinado, tanto para usuários quanto para fornecedores.</li><li>Efetuar o logoff.</li></ol>
 |Critérios de Êxito|<ul><li>Após o login, a página destinada ao uso específico do usuário será carregada automaticamente.</li><li>A página deve exibir a tabela com o estoque disponível.</li><li>A tabela deve funcionar adequadamente para todos os usuários.</li><li>A página deve possibilitar a pesquisa de um medicamento específico na tabela.</li><li>A página carregada deve ter acesso ao botão de logoff.</li><li>Após o logoff, a página de login deve ser novamente carregada.</li></ul>| 
    
   |Caso de Teste|CT-03|
   |:---:|:---|
   |Requisitos associados|RF-005 Facilitar ao usuário o uso do sistema para alcançar seu objetivo pretendido..<br>RF-006 Permitir que os usuários clientes consultem os medicamentos desejados e que os usuários fornecedores consultem e alterem o estoque.<br>
   |Objetivo do teste|Verificar se o sistema é de fácil acesso e compreensão para usuários leigos.|
   |Passos|<ol><li>Acessar o navegador.</li><li>Informar o endereço do site.</li><li>Visualizar a página de login.</li><li>Efetuar o login.</li><li>Acessar a página inicial do sistema.</li><li> Acesso direcionado ao uso específico pretendido pelo usuário.</li><li>Acessar a tabela do banco de dados que contém o estoque disponível.</li><li>Realizar pesquisas de medicamentos específicos.</li><li>Efetuar o logoff.</li></ol>|
   |Critérios de Êxito|<ul><li>Após o login, a página inicial de uso destinada deve ser carregada automaticamente.</li><li>A página deve exibir uma tabela com o estoque atualizado, além de oferecer uma opção de busca rápida.</li><li>O acesso dos fornecedores deve possibilitar a edição do estoque.</li><li>O banco de dados deve atualizar o estoque automaticamente após qualquer alteração..</li><li>Após o logoff, a página de login deve ser novamente carregada.</li></ul>|
   
   |Caso de Teste|CT-04|
   |:---:|:---|
   |Requisitos associados|RF-007 Permitir que o usuário cliente pesquise e verifique a disponibilidade de medicamentos em estoque. RF-009 Permitir que o usuário fornecedor visualize todo o estoque disponível e faça alterações conforme necessário.|
   |Objetivo do teste|Verificar se o sistema direciona corretamente o usuário para a função apropriada.|
   |Passos|<ol><li>Acessar o navegador.</li><li>Informar o endereço do site.</li><li>Visualizar a página de login.</li><li>Efetuar o login.</li><li>Acessar a página inicial correspondente à sua função de uso.</li><li>Realizar pesquisas e consultar os estoques disponíveis.</li><li>Usuários fornecedores realizarem acesso personalizado para editar e consultar o estoque disponível..</li><li>Efetuar logoff.</li></ol>|
   |Critérios de Êxito|<ul><li>Após o login a página inicial correspondente precisa ser carregada.</li><li>A página deve exibir uma tabela de estoque com opção de pesquisa rápida.</li><li>A área do usuário deve possibilitar a alteração dos dados e localização para verificar o estoque.</li><li>A página carregada deve ter sempre acesso ao botão de logoff.</li><li>Após o logoff, a página de login deve ser novamente carregada.</li></ul>|
   
   |Caso de Teste|CT-05|
   |:---:|:---|
   |Requisitos associados|RF-011	Permitir que os usuários fornecedores tenham acesso aos relatórios de vendas e estoque.<br>RF-012 Verificar e atualizar estoque.<br>RF-013 Registrar nova venda.<br>|
   |Objetivo do teste|Verificar se todas as funcionalidades dos usuários fornecedores estão operando corretamente.|
   |Passos|<ol><li>Acessar o navegador.</li><li>Informar o endereço do site.</li><li>Visualizar a página de login.</li><li>Efetuar o login.</li>    <li>Acessar a página inicial destinada aos fornecedores.</li><li>Efetuar pesquisas e realizar alterações e vendas no banco de dados do estoque.</li><li>Efetuar logoff.</li></ol>|
   |Critérios de Êxito|<ul><li>Após o login, a página inicial destinada aos fornecedores deve ser carregada.</li><li>A página precisa apresentar uma tabela com todo o estoque disponível e relatórios de vendas e estoque.</li><li>A página carregada deve ter acesso ao botão de logoff.</li><li>Após o logoff, a página de login deve ser novamente carregada.</li></ul> 
   
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
