# PlataformaCurso-API

![Licença](https://img.shields.io/badge/license-MIT-blue.svg) ![.NET](https://img.shields.io/badge/.NET-5.0-blue.svg) ![EntityFramework](https://img.shields.io/badge/EntityFramework-5.0.0-green.svg) ![CleanArchitecture](https://img.shields.io/badge/CleanArchitecture-Clean-blue.svg)

## 📚 Descrição

PlataformaCurso-API é uma API desenvolvida em .NET usando Entity Framework e Clean Architecture. Esta API oferece autenticação JWT e um sistema robusto para gerenciar uma plataforma de cursos online, incluindo funcionalidades de cadastro, autenticação e gestão de cursos.

## 🗂 Índice

- [Instalação](#instalação)
- [Uso](#uso)
- [Recursos](#recursos)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## 🚀 Instalação

Siga os passos abaixo para instalar e configurar o ambiente para rodar o projeto.

### Pré-requisitos

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Passos para Instalação

1. Clone o repositório:

    ```bash
    git clone https://github.com/FlavioMartinsJr/PlataformaCurso-API.git
    ```

2. Navegue até o diretório do projeto:

    ```bash
    cd PlataformaCurso-API
    ```

3. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
    },
    "Jwt": {
        "Key": "sua_chave_secreta",
        "Issuer": "seu_issuer",
        "Audience": "sua_audience",
        "ExpireMinutes": 30
    }
    ```

5. Atualize o banco de dados:

    ```bash
    dotnet ef database update
    ```

6. Execute o projeto:

    ```bash
    dotnet run
    ```

## 📖 Uso

Para iniciar o servidor, execute o comando `dotnet run` e acesse a API através de `http://localhost:5000/api`.

### Exemplos de Uso

#### Autenticação

1. **Registro de Usuário**

    ```http
    POST /api/auth/register
    Content-Type: application/json

    {
      "username": "usuario",
      "password": "senha"
    }
    ```

2. **Login**

    ```http
    POST /api/auth/login
    Content-Type: application/json

    {
      "username": "usuario",
      "password": "senha"
    }
    ```

#### Operações com Cursos

1. **Adicionar um Curso**

    ```http
    POST /api/courses
    Authorization: Bearer <seu_token_jwt>
    Content-Type: application/json

    {
      "title": "Nome do Curso",
      "description": "Descrição do Curso",
      "duration": 10
    }
    ```

2. **Obter Lista de Cursos**

    ```http
    GET /api/courses
    ```

## 🛠️ Recursos

- **Autenticação JWT:** Segurança na autenticação de usuários.
- **Clean Architecture:** Manutenção e escalabilidade facilitadas.
- **Entity Framework:** ORM para interações eficientes com o banco de dados.
- **CRUD Completo:** Operações de criação, leitura, atualização e exclusão para cursos.

## 🤝 Contribuição

Instruções sobre como contribuir para o projeto:

1. Fork o repositório
2. Crie uma branch com a nova feature (`git checkout -b nova-feature`)
3. Commite suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Faça o push para a branch (`git push origin nova-feature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## 📬 Contato

Flávio Martins Jr - [@seu-usuario](https://twitter.com/seu-usuario) - seu-email@example.com

Link do Projeto: [https://github.com/FlavioMartinsJr/PlataformaCurso-API](https://github.com/FlavioMartinsJr/PlataformaCurso-API)

