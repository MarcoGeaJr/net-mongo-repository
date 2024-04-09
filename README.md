# API .NET com MongoDB (Arquitetura Limpa e Repository Pattern)

Este repositório contém uma API .NET Core que oferece funcionalidades para gerenciamento de projetos, utilizando arquitetura limpa juntamente com o padrão Repository para interação com o MongoDB. É importante ressaltar que outras partes do projeto podem não seguir todas as boas práticas de software de forma proposital, visando manter o projeto enxuto e focado no exemplo de implementação do Repository Pattern em Clean Architecture com MongoDB.

## Pré-requisitos:

- Docker instalado na máquina local.

## Instruções de Uso:

1. Clone o repositório para o seu ambiente local:

```bash
git clone https://github.com/MarcoGeaJr/net-mongo-repository.git
```

2. Navegue até o diretório do projeto:
```bash
cd Pizza
```

3. Execute o Docker Compose para criar e iniciar os contêineres:
```bash
docker-compose up
```

Após a execução bem-sucedida, a página do Swagger da API será exibida e o MongoDB estará acessível em mongodb://localhost:27017.

## Endpoints da API:

A API oferece os seguintes endpoints para gerenciamento de pizzas:

### Ingredients
```
GET /api/ingredients: Retorna todos os ingredientes cadastrados.
GET /api/ingredients/{id}: Retorna um ingrediente específico com base no ID.
POST /api/ingredients: Cria um novo ingrediente.
PUT /api/ingredients/{id}: Atualiza um ingrediente existente com base no ID.
DELETE /api/ingredients/{id}: Remove um ingrediente com base no ID.
```

### Pizzas
```
GET /api/pizzas: Retorna todos as pizzas cadastradas.
GET /api/pizzas/{id}: Retorna uma pizza específica com base no ID.
POST /api/pizzas: Cria uma nova pizza.
PUT /api/pizzas/{id}: Atualiza uma pizza existente com base no ID.
DELETE /api/pizzas/{id}: Remove uma pizza com base no ID.
```

Autor:

Marco Gea

Para mais informações, entre em contato pelo LinkedIn [Marco Gea](https://www.linkedin.com/in/marco-gea).