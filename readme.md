# Teste Prático Saipher

## Sumário
- [Objetivo](#objetivo)
- [Requisitos do Sistema](#requisitos-do-sistema)
    - [Requisitos Funcionais](#requisitos-funcionais)
    - [Requisitos Não Funcionais](#requisitos-não-funcionais)
- [Critério de Avaliação](#critérios-de-avaliação)

## Objetivo

Avaliar as habilidades de desenvolvimento do candidato na construção de um sistema simples de gerenciamento de usuários CRUD utilizando .NET Core para a API e Angular para a aplicação cliente web.

## Requisitos do Sistema

-  Backend API em .NET Core:
    - Autenticação e Autorização:
    - Endpoints:
        - POST /api/auth/login Autenticação de usuário.
        - GET /api/users Listar todos os usuários (protegido por autenticação).
        - POST /api/users Adicionar um novo usuário (protegido por autenticação).
        - PUT /api/users/{id} Atualizar um usuário existente (protegido por
autenticação).
        - GET /api/users/{id} Obter detalhes de um usuário específico (protegido por
autenticação).
        - DELETE /api/users/{id} Deletar um usuário (opcional e protegido por
autenticação).

    - Banco de Dados:
        - Usar Entity Framework Core para interação com o banco de dados.
        - Criar uma tabela de usuários com colunas para ID, Nome, Email, Senha
(hash).

- Frontend (Aplicação Cliente) em Angular:
    - Tela de Login:
        - Formulário com campos para email e senha.
        - Validação de formulário.
        - Chamada ao endpoint de login da API.
        - Redirecionamento para a tela de gerenciamento de usuários em caso de sucesso.
    - Tela de Gerenciamento de Usuários:
        - Grid de listagem de usuários com colunas para Nome e Email.
        - Botão "Adicionar Usuário" para abrir um formulário de criação de usuário.
        - Opção para editar um usuário existente (ao clicar em uma linha do grid ou
um botão de editar).
        - Validação de formulário ao adicionar ou editar usuários.
        - Chamada aos endpoints apropriados da API para listar, adicionar e editar usuários.
        - Proteção de rota para garantir que apenas usuários autenticados possam acessar.

### Requisitos Funcionais:

- Autenticação:
    - Usuários devem poder se autenticar usando email e senha.
    - Após o login bem-sucedido, um token JWT deve ser armazenado no cliente e usado para autenticação em chamadas subsequentes.
- Gerenciamento de Usuários:
    - Listar todos os usuários em um grid na tela de gerenciamento.
    - Permitir adição de novos usuários através de um formulário.
    - Permitir edição de usuários existentes através de um formulário.
    - O sistema deve validar que emails são únicos e senhas são suficientemente seguras.

### Requisitos Não funcionais
- Qualidade de Código:
    - Seguir boas práticas de codificação, incluindo a utilização de princípios SOLID e padrões de design apropriados.
    - Escrever código limpo e comentado.
- Performance e Segurança:
    - Garantir que a aplicação seja responsiva e tenha um bom desempenho.
    - Implementar práticas de segurança para proteger contra ataques comuns (e.g., SQL Injection, XSS).
- Testes:
    - Escrever testes unitários para componentes críticos do frontend e backend.
    - Testar a aplicação manualmente para garantir que todas as funcionalidades estão operando corretamente.

## Critérios de Avaliação

- Compromisso:
    - Independente de ter terminado ou não, entregue.
- Funcionalidade:
    - O sistema atende a todos os requisitos funcionais especificados?
    - A autenticação e autorização estão implementadas corretamente?
- Qualidade do Código:
    - O código segue boas práticas de desenvolvimento?
    - Está bem organizado e fácil de entender?
- Interface de Usuário:
    - A UI é intuitiva e fácil de usar?
    - As telas são responsivas e visualmente agradáveis?
- Performance e Segurança:
    - A aplicação tem um bom desempenho?
    - Foram implementadas medidas de segurança adequadas?
- Testes (Bônus):
    - Existem testes unitários e eles cobrem as partes críticas do código?

    
## Sobre o Desenvolvimento

### Estrutura do Projeto
Utilizei o padrão MVC para criação da API visto que incluiremos também um módulo de View mais na frente com o Angular. Além da estrutura padrão do MVC criei as pastas `Services`, que irão armazenar nossos serviços/métodos de acesso e a pasta `Helpers` para armazenar utilitários (No inicio da aplicação só consigo lembrar da classe de configuração do JWT, mas geralmente, aparecem mais no decorrer do desenvolvimento).

### Banco de Dados
Apesar de o banco de dados padrão da Saipher ser SQL Server, pela simplicidade e similidaridade optei pelo SQLite. Como ORM, seguiremos como pede o teste utilizando o Entity Framework.

### Estrutura de comentários
Comentários que se iniciem com `*` tratam-se de comentários para serem feitos na entrevista de apresentação do projeto e não de comentários técnicos, ou seja, comentários que visam lembrar o que pensei enquanto desenvolvia. Dessa forma, peço que na avaliação sejam ignorados os comentários que se iniciarem com `*`.

### Ferramentas Utilizadas (pacotes)

- Banco de Dados e EF

    O Banco de dados será o SQLite, manipulado pelo EntityFramework.

    Instalação:
    ```
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
- JWT

    Para autenticação e autorização de usuários

    Instalação: 
    ``` bash
    dotnet add package System.IdentityModel.Tokens.Jwt
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.10
    ```
- BCrypt

    O BCrypt será utilizado na criação e tradução de Hash visando manter o tráfego de dados sensíveis seguro.

    Instalação: 
    ``` bash
    dotnet add package BCrypt.Net-Next --version 4.0.3
    ```

    ### Serviços externos
    Criei um pequeno módulo com uma aplicação simples de console que retorna alguns tipos de chave. A criação foi baseada na necessidade de criação de guid e hash fixos para as migrations além de ser utilziada também para criar uma chave segura para o JWT. Esse módulo pode ser acessado [Clicando Aqui](http://github.com/denissondev/KeyGenerator).