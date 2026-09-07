# Sistema de Gestão de Consultas UVV

Projeto desenvolvido para a disciplina de **Desenvolvimento Web
Back-end** da **Universidade Vila Velha (UVV)**.

O objetivo é desenvolver uma aplicação web para gerenciamento de
usuários e consultas. O sistema permite cadastro, login e gerenciamento
das próprias consultas.

------------------------------------------------------------------------

## Funcionalidades

-   Cadastro de usuários
-   Login e autenticação
-   Logout
-   Controle de acesso às páginas de consultas
-   Cadastro, listagem, edição e exclusão de consultas
-   Relacionamento entre usuários e consultas
-   Validação de dados
-   Persistência utilizando Entity Framework Core
-   Restrição para que cada usuário acesse somente suas próprias
    consultas

------------------------------------------------------------------------

## Tecnologias utilizadas

-   C#
-   .NET 8
-   ASP.NET Core MVC
-   Entity Framework Core
-   SQLite
-   Razor Views
-   HTML
-   CSS
-   Bootstrap
-   Visual Studio Code

------------------------------------------------------------------------

## Arquitetura

O projeto utiliza o padrão **MVC (Model-View-Controller)**.

-   **Models:** entidades e validações, incluindo `Usuario.cs` e
    `Consulta.cs`.
-   **Controllers:** processamento das requisições, incluindo
    `AccountController.cs`, `ConsultasController.cs` e
    `HomeController.cs`.
-   **Views:** interfaces da aplicação desenvolvidas com Razor Views.
-   **Data:** contém o `AppDbContext`, responsável pela comunicação com
    o banco.
-   **Migrations:** contém as migrations utilizadas pelo Entity
    Framework Core.

------------------------------------------------------------------------

## Banco de dados

O projeto utiliza **SQLite** com **Entity Framework Core**.

A string de conexão é configurada em `appsettings.json` e o arquivo de
banco utilizado pela aplicação é `app.db`.

------------------------------------------------------------------------

## Pré-requisitos

-   .NET SDK 8
-   Git
-   Visual Studio Code, Visual Studio ou outro editor compatível

Para verificar o .NET:

``` bash
dotnet --version
```

------------------------------------------------------------------------

## Como executar o projeto

### 1. Clonar o repositório

``` bash
git clone https://github.com/bravinnxd/Sistema-Consultas-UVV.git
```

Acesse a pasta clonada e, se necessário, entre na pasta que contém o
arquivo `.csproj`.

### 2. Restaurar as dependências

``` bash
dotnet restore
```

### 3. Instalar a ferramenta do Entity Framework Core

Caso ainda não esteja instalada:

``` bash
dotnet tool install --global dotnet-ef --version 8.*
```

Verifique com:

``` bash
dotnet ef --version
```

### 4. Preparar/atualizar o banco de dados

Na pasta que contém o `.csproj`, execute:

``` bash
dotnet ef database update
```

Esse comando aplica as migrations existentes e prepara o banco de dados.

> No Package Manager Console do Visual Studio, o comando equivalente é
> `Update-Database`.

### 5. Compilar

``` bash
dotnet build
```

### 6. Executar

``` bash
dotnet run
```

Abra no navegador o endereço informado pelo terminal.

------------------------------------------------------------------------

## Como utilizar o sistema

1.  Acesse a aplicação.
2.  Crie uma conta.
3.  Faça login.
4.  Acesse a área de consultas.
5.  Cadastre uma nova consulta.
6.  Visualize, edite ou exclua suas consultas.
7.  Utilize **Sair** para encerrar a sessão.

------------------------------------------------------------------------

## Autenticação e autorização

As funcionalidades de gerenciamento de consultas são protegidas por
autenticação e autorização. As consultas são associadas ao usuário
autenticado, garantindo que cada usuário tenha acesso somente aos seus
próprios registros.

------------------------------------------------------------------------

## Relacionamento das entidades

O sistema possui relacionamento **um para muitos (1:N)**:

``` text
Usuario 1 -------- N Consulta
```

Um usuário pode possuir várias consultas, enquanto cada consulta
pertence a um único usuário.

------------------------------------------------------------------------

## Demonstração em vídeo

Vídeo demonstrando o fluxo principal da aplicação:

**YouTube:** https://youtu.be/UZa-XVtVLnk

------------------------------------------------------------------------

## Repositório

Código-fonte disponível no GitHub:

**GitHub:** https://github.com/bravinnxd/Sistema-Consultas-UVV

------------------------------------------------------------------------

## Integrantes

-   Gabriel Bravin Correa da Silva
-   Jairo Ribeiro Neto

------------------------------------------------------------------------

## Disciplina

**Desenvolvimento Web Back-end**

**Universidade Vila Velha --- UVV**

------------------------------------------------------------------------

## Observações

Projeto desenvolvido para fins acadêmicos como parte da avaliação da
disciplina de Desenvolvimento Web Back-end.
