# eApp - Aplicação Web com Angular e ASP.NET Core

Este repositório contém uma aplicação web fullstack dividida em dois projetos:

- **Frontend:** [eApp](https://github.com/erikscar/eapp) – Repositório `AngularJS`
- **Backend:** [eaAppApi](https://github.com/erikscar/eAppApi) – Repositório `ASP.NET Core`
---

- ## Visão Geral

**Frontend (Marketplace):** Uma plataforma onde os usuários podem visualizar produtos, pesquisar por meio de um mecanismo de busca, adicionar itens ao carrinho e comentar em produtos. A interface foi projetada para ser intuitiva e responsiva, proporcionando uma experiência agradável tanto para navegação quanto para interação com os itens disponíveis.

**Backend (API REST):** Uma API robusta, desenvolvida com **ASP.NET Core**, que oferece funcionalidades completas de **CRUD** para gerenciamento dos recursos do sistema. A autenticação e autorização são gerenciadas por meio de **Tokens JWT**, permitindo controle refinado de roles e permissões com base no nível de acesso do usuário. Além disso, a arquitetura segue o padrão de projeto Repository Pattern, promovendo maior organização, testabilidade e desacoplamento entre as camadas da aplicação.

*O usuário pode clonar este repositório, iniciar os dois serviços localmente e visualizar a aplicação completa rodando em sua máquina.*

## Funcionalidades

### Autenticação e Autorização
- Cadastro e login de usuários
- Sistema de "Lembrar de Mim" para manter uma sessão ativa
- Controle de acesso ao sistema baseado em **Roles (Admin / Usuário) com JWT**
  - Usuário => Página de Produtos
  - Admin   => Painel Administrativo do Admin

---
 
### Página Inicial
- Exibição de **Cards de Categorias** com botão para pesquisar os produtos relacionados
- Cards exibindo:
  - **Todos os Produtos** disponíveis
  - **Produtos Populares** de acordo com a avaliação dos usuários
 
---

### Funcionalidades do Usuário
- Página Individual de Produtos com:
  - Botão "Adicionar ao Carrinho"
  - Campo para "Adicionar Comentário / Avaliação"
- Carrinho de Compras com:
  - Alteração da **quantidade de produtos**
  - Cálculo **dinâmico de ofertas e valor total**
- Página de Perfil com opção de **atualizar dados pessoais e endereço**
- Barra de pesquisa para localizar produtos por **nome, categoria ou palavra-chave**

---

### Painel Administrativo
- **Dashboard** com visão geral do sistema:
  - Gráficos de **registros recentes**, **produtos por categoria (% e quantidade)** e **overview de receita**.
- Página de **configurações de tema e cores do sistema**.
- Área de administração com **CRUD completo** e Tabelas para:
  - Produtos
  - Categorias
  - Usuários
- Botão com funcionalidade de exportação para uma **TABELA EXCEL**
 
---

### Tratamento de Erros
- Página personalizada de erro **404 - Rota não encontrada**
- Feedback visual amigável para o usuário em páginas inválidas

---

- ## Tecnologias Utilizadas

- **AngularJS** - Front-End
- **ASP.NET Core** - Back-End
- **Entity Framework**
- **SQL Server** - Banco de Dados
- **Fluent API**
- **API REST**
- **TypeScript**
- **C#**
- **.NET 6+**
- **HTML5 + SCSS**

---
- ### Pré-Requisitos
- [Node.js](https://nodejs.org/) (v16 ou superior)
- [Angular CLI](https://angular.dev/installation)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (v6.0 ou superior)
- Git instalado
---

### 1. Clone o Repositório (Front-End = eApp)

```bash
git clone https://github.com/erikscar/eapp.git
```

### 2. Inicie o Front-End (Angular)

```bash
cd eApp
npm intall
ng serve
```
*O Angular rodará por padrão em: http://localhost:4200*

### 3. Clone o Repositório (Back-End = eAppApi)

```bash
git clone https://github.com/erikscar/eAppApi.git
```

### 4. Inicie o Back-End (ASP.NET Core)

```bash
cd eAppApi
dotnet restore
dotnet ef database update
```
*O API será executada por padrão em: http://localhost:5104*

*Pull requests são bem-vindos! Sinta-se livre para abrir issues para reportar bugs, sugerir melhorias ou discutir funcionalidades.*


## Aprendizado 

- Integração entre frontend Angular e backend ASP.NET Core com Entity Framework.
- Implementação de autenticação JWT e gerenciamento de roles + guards em Angular.
- Manipulação de dados em tempo real com filtros, pesquisas e gráficos.
- Boas práticas com Repository Pattern e organização em camadas.

## 👤 Autor

Desenvolvido por [Erik Scarcela](https://www.linkedin.com/in/erik-scarcela)  
GitHub: [@erikscar](https://github.com/erikscar)

