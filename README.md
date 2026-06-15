# Sistema de Chamados

Desafio Técnico Full Stack - Codificar

## Objetivo

Aplicação web desenvolvida em ASP.NET Core MVC para gerenciamento de chamados, permitindo:

- Cadastro de chamados
- Edição de chamados
- Visualização de detalhes
- Exclusão de chamados
- Acompanhamento de status
- Distribuição automática de responsáveis

---

## Tecnologias Utilizadas

### Backend

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- SQLite

### Frontend

- Razor Views
- Bootstrap 5

### Banco de Dados

- SQLite

---

## Justificativa das Escolhas Tecnológicas

### ASP.NET Core MVC

Foi escolhido por oferecer:

- Estrutura organizada
- Separação de responsabilidades (MVC)
- Facilidade de manutenção
- Integração nativa com Entity Framework Core

### Entity Framework Core

Utilizado para:

- Mapeamento objeto-relacional (ORM)
- Controle de migrations
- Facilidade de acesso ao banco de dados

### SQLite

Escolhido por ser:

- Leve
- Não exigir instalação de servidor
- Fácil execução local
- Adequado para testes técnicos

---

## Funcionalidades Implementadas

### Chamados

Cada chamado possui:

- Título
- Descrição
- Prioridade
    - Baixa
    - Média
    - Alta
- Status
    - Aberto
    - Em andamento
    - Resolvido
    - Fechado
- Responsável
- Data de abertura

### Responsáveis

A aplicação possui responsáveis pré-cadastrados:

- João Silva
- Maria Santos
- Carlos Oliveira

### Distribuição Automática

Ao criar um chamado é possível:

- Selecionar um responsável manualmente
- Utilizar distribuição automática

A distribuição automática atribui o chamado ao responsável com a menor quantidade de chamados em aberto.

### Critério de Chamados em Aberto

Foram considerados como chamados em aberto:

- Aberto
- Em andamento

Não são considerados em aberto:

- Resolvido
- Fechado

Essa abordagem foi adotada porque chamados resolvidos ou fechados não demandam mais atendimento ativo.

---

## Estrutura do Projeto

```text
Controllers/
Data/
Models/
Services/
Views/

Program.cs
appsettings.json
```

### Principais Componentes

#### AppDbContext

Responsável pelo acesso ao banco de dados.

#### DistribuicaoAutomaticaService

Implementa a regra de negócio para distribuição automática dos chamados.

#### ChamadosController

Responsável pelas operações:

- Listagem
- Criação
- Edição
- Exclusão
- Detalhamento

---

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK 10 ou superior
- Git

### Clonar o Repositório

```bash
git clone <[URL_DO_REPOSITORIO](https://github.com/Kurt1308/Teste-Codificar.git)>
```

Entrar na pasta do projeto:

```bash
cd Teste_Codificar
```

### Restaurar Dependências

```bash
dotnet restore
```

### Aplicar Migrations

```bash
dotnet ef database update
```

### Executar Aplicação

```bash
dotnet run
```

A aplicação estará disponível em:

```text
[[https://localhost:xxxx](https://localhost:5062)]
```

---

## Banco de Dados

O banco SQLite é criado automaticamente através das migrations.

Arquivo:

```text
app.db
```

---

## Autor

Lucas Dias  14/06/2026
