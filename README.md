Uma API para gerenciamento de clientes;

## Como Rodar

### Pré-requisitos
- Docker

### Passos

1. Clone este repositório;
2. Rode o comando docker-compose up.
3. Agora, a API estará rodando no http://localhost:9800.

## Funcionalidades

- **Cadastrar Clientes**: Insira facilmente novos clientes com campos essenciais, incluindo ID, Nome Completo, Telefone e Email.
- **Listagem de Clientes**: Recupere uma lista de todos os clientes. Suporta paginação, ordenação e search query.
- **Detalhes do Cliente**: Veja informações detalhadas sobre um cliente específico.

## Tecnologias & Padrões

- **.NET Core 7**: A API foi desenvolvida usando a mais recente versão do .NET Core, garantindo eficiência, performance e segurança.
- **RESTful**: A API segue os princípios e convenções REST.
- **OpenAPI**: Suporte a interface swagger.
- **Clean Architeture**: Descrição
- **DDD** Padrão aplicado para criar um domínio rico, com regras de negócio na camada de domínio da aplicação.
- **Modelagem de Dados**: As tabelas foram modeladas considerando relacionamentos, garantindo integridade e estrutura.
- **Docker Compose**: Configuração Docker-Compose disponível, permitindo que a API e o banco de dados SQLite sejam facilmente inicializados juntos.
- **Bogus**: Integrado à biblioteca Bogus para alimentar o banco de dados com dados fictícios, facilitando o desenvolvimento e testes.
- **Testes unitários**: Cobertura de regras de negócio através de testes unitários, empregando bibliotecas como xUnit, Moq e FluentAssertions.
- **EntityFrameWork Core**: ORM escolhido para facilitar a comunicação com o banco de dados. A estrutura do banco de dados foi estabelecida usando migrations.
- **MediatR**: Implementado para apoiar o padrão UseCases, promovendo um código menos acoplado e melhorando a testabilidade do código.
- **FluentValidation**: Utilizado para validar dados de input na API.

## Cobertura de testes:
![image](https://github.com/pedronvasconcelos/ClienteProject/assets/87155663/64959e0e-d982-4c1d-a372-afab37a31d00)
![image](https://github.com/pedronvasconcelos/ClienteProject/assets/87155663/59670e9c-aac3-491e-b3ef-88b79e86e23d)

## Swagger
Link: http://localhost:9800/swagger/index.html
![image](https://github.com/pedronvasconcelos/ClienteProject/assets/87155663/b326890d-b5c3-4b4c-91d1-d754d9dd8382)




