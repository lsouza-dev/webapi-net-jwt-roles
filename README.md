# WebAPI .NET JWT Roles

Este projeto é uma implementação de uma Web API em .NET que utiliza JWT (JSON Web Tokens) para autenticação e controle de acesso baseado em roles. Ele demonstra como proteger endpoints e gerenciar permissões de acesso em uma aplicação ASP.NET Core.

## Visão Geral

A aplicação fornece um exemplo de integração de autenticação JWT em uma API .NET Core, com controle de acesso granular por meio de roles. Ela foi projetada para desenvolver habilidades em segurança e gerenciamento de usuários em APIs RESTful.

## Funcionalidades

- Autenticação de usuários com geração de tokens JWT.
- Controle de acesso baseado em roles (Admin, Visualizadores).
- CRUD de usuários com diferentes níveis de acesso.
- Configuração de string de conexão para banco de dados.
- Migrações de banco de dados usando Entity Framework Core.

## Pré-requisitos

Antes de começar, você precisará ter instalado em seu sistema:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou outro banco de dados suportado configurado
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/) para desenvolvimento

## Configuração

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/lsouza-dev/webapi-net-jwt-roles.git
   ```
   
2. **Navegue para o diretório do projeto:**

   ```bash
   cd webapi-net-jwt-roles
   ```

3. **Restaure as dependências do projeto:**

   ```bash
   dotnet restore
   ```

4. **Configure a string de conexão no arquivo `appsettings.json`:**

   Ajuste o `appsettings.json` conforme o seu ambiente:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=seu_servidor;Database=seu_banco;User Id=seu_usuario;Password=sua_senha;"
   }
   ```

5. **Execute as migrações para criar o banco de dados:**

   ```bash
   dotnet ef database update
   ```

6. **Inicie a aplicação:**

   ```bash
   dotnet run
   ```

## Uso

### Endpoints

#### Autenticação

- **POST /login**: Realiza o login e retorna um token JWT.
  - Corpo da Requisição: 
    ```json
    { "email": "seu_email", "senha": "sua_senha" }
    ```
  - Resposta:
    ```json
    { "token": "seu_token_jwt" }
    ```

#### Usuários

- **GET /Usuarios**: Lista todos os usuários. (Acesso: Admin e Visualizadores)
- **GET /Usuarios/{id}**: Obtém um usuário específico. (Acesso: Admin e Visualizadores)
- **POST /Usuarios**: Cria um novo usuário. (Acesso: Admin)
- **PUT /Usuarios/{id}**: Atualiza um usuário existente. (Acesso: Admin)
- **DELETE /Usuarios/{id}**: Exclui um usuário. (Acesso: Admin)

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir um issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a MIT License. Veja o arquivo LICENSE para mais detalhes.

## Considerações Finais

Esta API é um exemplo básico de como implementar autenticação e controle de acesso em uma aplicação .NET. Sinta-se à vontade para expandir e modificar conforme necessário para atender às suas necessidades.
