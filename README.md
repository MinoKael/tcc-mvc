# Catálogo de Mídia em ASP.NET MVC

Este é um projeto de exemplo de uma aplicação web de catálogo de mídias (livros, filmes e séries) desenvolvida com ASP.NET Core MVC, Entity Framework Core e PostgreSQL, utilizando Docker para orquestração dos contêineres.

## Tecnologias Utilizadas

-   **.NET 9**
-   **ASP.NET Core MVC**
-   **Entity Framework Core**
-   **PostgreSQL**
-   **Docker & Docker Compose**
-   **Bootstrap 5**

## Pré-requisitos

Para executar este projeto, você precisará ter as seguintes ferramentas instaladas em sua máquina:

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   [Docker](https://www.docker.com/products/docker-desktop/)
-   [Docker Compose](https://docs.docker.com/compose/install/) (geralmente incluído no Docker Desktop)

## Como Executar o Projeto

1.  **Clone o repositório:**
    ```sh
    git clone [https://github.com/MinoKael/tcc-mvc.git](https://github.com/MinoKael/tcc-mvc.git)
    cd MeuTccMvc
    ```

2.  **Inicie os contêineres com Docker Compose:**
    Execute o seguinte comando na raiz do projeto. Ele irá construir a imagem da aplicação .NET, iniciar o contêiner da aplicação, um contêiner para o banco de dados PostgreSQL e um para o PgAdmin.

    ```sh
    docker-compose up --build
    ```
    O comando `--build` garante que a imagem da sua aplicação seja reconstruída caso haja alterações no código.

3.  **Acesse a aplicação:**
    Após os contêineres estarem em execução, você pode acessar os seguintes serviços:

    -   **Aplicação Web:** [http://localhost:8080](http://localhost:8080)
    -   **PgAdmin (Gerenciador de Banco de Dados):** [http://localhost:5050](http://localhost:5050)
        -   **Email:** `admin@admin.com`
        -   **Senha:** `admin`

Ao iniciar, a aplicação aplicará automaticamente as migrações do Entity Framework e populará o banco de dados com dados iniciais (seeding), conforme configurado em `Data/ModelBuilderExtensions.cs`.

## Estrutura do Projeto

-   `Controllers/CatalogController.cs`: Controlador principal que gerencia as ações de CRUD para os itens de mídia.
-   `Data/AppDbContext.cs`: Contexto do Entity Framework para interação com o banco de dados.
-   `Models`: Contém as classes de modelo como `MediaItem`, `Book`, `Movie` e `Series`.
-   `Views`: Contém os arquivos de visualização (Razor) para a interface do usuário.
-   `Migrations`: Contém as migrações do Entity Framework para a criação do esquema do banco de dados.
-   `docker-compose.yml`: Arquivo de configuração do Docker Compose que orquestra os serviços da aplicação.
-   `Dockerfile`: Define os passos para construir a imagem Docker da aplicação ASP.NET.
-   `appsettings.json`: Contém as configurações da aplicação, incluindo a string de conexão com o banco de dados.