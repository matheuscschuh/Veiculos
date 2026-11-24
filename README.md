# Gerenciamento de Veículos

Aplicação desktop para cadastro de **marcas** e **veículos**, desenvolvida em **C# com Windows Forms** e **PostgreSQL**, aplicando Orientação a Objetos e separação em camadas.

## Funcionalidades

- **Marcas:** inserir, alterar, excluir e listar.
- **Veículos:** inserir, alterar, excluir e listar, com dois tipos (**Carro** e **Moto**).
- **Log de transações no banco:** toda operação de INSERT, UPDATE e DELETE na tabela de veículos é registrada automaticamente por uma trigger, com o tipo da operação e a data/hora.
- **Tratamento de erros:** mensagens amigáveis para o usuário e registro dos erros inesperados em arquivo.

## Tecnologias

- C# / .NET 10
- Windows Forms
- PostgreSQL 14 ou superior (Npgsql)
- xUnit (testes unitários)

## Arquitetura

A solução é dividida em três projetos:

```
VeiculosApp.slnx
├── VeiculosApp.UI      → interface (Windows Forms)
├── VeiculosApp.Core    → regras de negócio e acesso a dados
│   ├── Entidades       → Marca, Veiculo (abstrata), Carro, Moto
│   ├── Interfaces      → contratos dos repositórios
│   ├── Repositories    → acesso ao PostgreSQL (SQL parametrizado)
│   ├── Services        → validações e regras de negócio
│   ├── Exceptions      → RegraNegocioException
│   └── ConexaoBanco    → criação das conexões
└── VeiculosApp.Tests   → testes unitários
```

Fluxo de uma operação:

```
Tela (Form) → Service → Repository → PostgreSQL
```

- A **UI** referencia apenas o Core e não acessa o banco diretamente.
- Os **Services** dependem das interfaces dos repositórios, o que permite testá-los sem banco de dados.
- As dependências são montadas no `Program.cs` e entregues pelos construtores.

### Orientação a Objetos

- `Veiculo` é uma **classe abstrata** com os dados comuns (código, placa, modelo, ano e marca).
- `Carro` e `Moto` **herdam** de `Veiculo`, cada um com seu atributo próprio (ar-condicionado / baú).
- As propriedades abstratas `Tipo` e `Descricao` são implementadas por cada subclasse (**polimorfismo**). A grade da tela exibe carros e motos juntos sem precisar verificar o tipo de cada um.
- Veículo **tem uma** Marca (composição).
- Propriedades com `private set` e construtores garantem o **encapsulamento**: a placa, por exemplo, é sempre armazenada sem espaços e em letras maiúsculas.

## Regras de negócio

Todas as regras são validadas **no banco de dados** (constraints e chave estrangeira). As principais também são validadas no Service, para dar uma resposta mais rápida e clara ao usuário.

| Regra | Onde |
|---|---|
| Nome da marca obrigatório e único | `NOT NULL`, `UNIQUE`, `CHECK` |
| Não excluir marca vinculada a veículos | `FOREIGN KEY ... ON DELETE RESTRICT` |
| Placa obrigatória e única | `NOT NULL`, `UNIQUE`, `CHECK` |
| Modelo obrigatório | `NOT NULL`, `CHECK` |
| Ano entre 1950 e o ano atual | `CHECK` |
| Veículo deve possuir marca | `NOT NULL` + `FOREIGN KEY` |
| Tipo apenas "Carro" ou "Moto", com o atributo correspondente | `CHECK` |

## Como executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- PostgreSQL 14 ou superior
- Visual Studio 2026 (workload "Desenvolvimento para desktop com .NET") ou apenas o SDK, para executar pela linha de comando

### 1. Criar o banco de dados

1. Crie um banco chamado `veiculos_db`.
2. Conecte-se a ele e execute o script [`database/script.sql`](database/script.sql), que cria as tabelas, as constraints, a função e a trigger de log.

### 2. Configurar a conexão

Edite o arquivo `VeiculosApp/VeiculosApp.UI/appsettings.json` e informe o usuário e a senha do seu PostgreSQL:

```json
{
  "ConnectionStrings": {
    "VeiculosDb": "Host=localhost;Port=5432;Database=veiculos_db;Username=postgres;Password=definido-no-user-secrets"
  }
}
```

Como alternativa, para não deixar a senha no arquivo, use os User Secrets:

```bash
cd VeiculosApp/VeiculosApp.UI
dotnet user-secrets set "ConnectionStrings:VeiculosDb" "Host=localhost;Port=5432;Database=veiculos_db;Username=postgres;Password=SUA_SENHA"
```

### 3. Executar

Pelo Visual Studio: abra `VeiculosApp/VeiculosApp.slnx`, defina `VeiculosApp.UI` como projeto de inicialização e pressione **F5**.

Pela linha de comando:

```bash
cd VeiculosApp
dotnet run --project VeiculosApp.UI
```

### 4. Executar os testes

```bash
cd VeiculosApp
dotnet test
```

## Testes unitários

Os testes validam regras de negócio dos Services usando repositórios falsos, sem acesso ao banco:

| Teste | Regra validada |
|---|---|
| Criar marca com nome vazio | Nome da marca é obrigatório |
| Criar veículo com ano 1945 | Ano deve ser a partir de 1950 |
| Criar veículo com modelo vazio | Modelo é obrigatório |

## Tratamento de erros

- **Erros de regra de negócio** (campo vazio, placa duplicada, marca em uso etc.) são convertidos em `RegraNegocioException` no Service e exibidos ao usuário com uma mensagem clara.
- **Erros inesperados** (banco indisponível, falhas não previstas) exibem uma mensagem genérica e são registrados no arquivo `logs/erros.log`, na pasta do executável, com data/hora, tipo do erro, mensagem e local no código.
- Se a connection string não estiver configurada, a aplicação avisa e não é iniciada.
