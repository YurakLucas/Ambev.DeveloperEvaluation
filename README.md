# Developer Evaluation Project

Este projeto é uma API RESTful desenvolvida com .NET 8 para gerenciamento completo de registros de vendas, aplicando os princípios de **Clean Architecture** e **Domain-Driven Design (DDD)**.

---

## 🚩 Tecnologias e ferramentas

- .NET 8
- ASP.NET Core Web API
- xUnit (Testes unitários)
- FluentAssertions (Asserts avançados)

---

## ⚙️ Como configurar o ambiente

### Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Instalando o projeto

Clone o repositório:

```bash
git clone https://github.com/seu-usuario/Ambev.DeveloperEvaluation.git
cd Ambev.DeveloperEvaluation/backend/src
```

### Restaurando dependências

```bash
dotnet restore
```

---

## 🚀 Executando a aplicação

Execute o comando abaixo para rodar a aplicação localmente:

```bash
dotnet run --project Ambev.DeveloperEvaluation.WebApi
```

A aplicação estará disponível em:  
`https://localhost:7181`

A documentação Swagger poderá ser acessada em:  
`https://localhost:7181/swagger`

---

## ✅ Executando os testes unitários

Os testes estão localizados em:

```bash
Tests/UnitTests
```

Execute os testes com o comando:

```bash
dotnet test
```

---


## 🛠️ Testando a API

### Swagger

Use o Swagger para testes rápidos diretamente no navegador:

- `https://localhost:7181/swagger`

### Exemplos com cURL

#### Criar uma venda (POST)

```bash
curl -X POST "https://localhost:7181/api/sales" \
-H "Content-Type: application/json" \
-d '{
  "customerId": "GUID",
  "branchId": "GUID",
  "saleDate": "2025-03-31T12:00:00Z",
  "items": [
    {
      "productId": "GUID",
      "quantity": 5,
      "unitPrice": 100.00
    }
  ]
}'
```

#### Consultar venda criada (GET)

```bash
curl "https://localhost:7181/api/sales/{id}"
```

---

## 📂 Estrutura do projeto

```
backend/src
├── Adapters (Web API)
├── Core
│   ├── Application (DTOs, Mappings)
│   └── Domain (Entities, Services, Repositories)
├── Infrastructure (Persistence, Repositories)
├── Common (Health Checks, Logging, Security)
├── IoC (Dependency Injection)
└── Tests
    └── UnitTests
```

---

## 📌 Regras de negócio implementadas

- Quantidade 4-9 itens: **10% desconto**
- Quantidade 10-20 itens: **20% desconto**
- Não é permitido vendas com mais de **20 itens** do mesmo produto
- Sem desconto abaixo de **4 itens**

---

## 🧑‍💻 Organização e documentação

Este projeto segue boas práticas de Clean Architecture e Domain-Driven Design (DDD), garantindo uma alta manutenibilidade, fácil compreensão e escalabilidade.

---

## ✅ Critérios atendidos

- [x] CRUD completo
- [x] Regras de negócio validadas
- [x] Testes unitários com cobertura de código
- [x] Documentação clara e organizada