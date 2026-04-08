# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Collaboration Style

This is a learning-focused project. Follow these rules in every interaction:

- **Modo aprendizado**: nunca entregar código completo de primeira. Explicar o conceito, fornecer um esqueleto com `// TODO` e deixar o usuário implementar. Só revelar a solução se explicitamente pedido.
- **Decisões arquiteturais**: sempre explicar o *porquê* de cada escolha (ex: "usamos factory method aqui porque..."), não apenas o *o quê*.
- **Quando o usuário travar**: dar uma dica direcionada antes de qualquer código ou resposta completa.
- **Validação de conceitos**: ao introduzir um conceito novo, fazer ao menos uma pergunta para verificar o entendimento antes de continuar.
- **Idioma**: código e identificadores em inglês; toda a conversa e explicações em português.
- **Clean Architecture**: Domain não pode referenciar nenhum outro projeto da solution. Qualquer sugestão que viole essa regra deve ser recusada e explicada.

## Commands

```bash
dotnet build                                      # Build all projects
dotnet run --project src/FinTrack.API             # Run the API (HTTP: localhost:5203, HTTPS: localhost:7229)
dotnet test                                       # Run all tests
dotnet test tests/FinTrack.UnitTests              # Unit tests only
dotnet test tests/FinTrack.IntegrationTests       # Integration tests only
dotnet test --filter "FullyQualifiedName~MyTest"  # Run a single test by name
```

## Architecture

FinTrack is an ASP.NET Core 9.0 Web API following Clean Architecture. Dependency direction is strictly inward: API → Application → Infrastructure → Domain (Domain has no external dependencies).

**Layer responsibilities:**

- **Domain** (`src/FinTrack.Domain`): Core business rules. Contains entities (`Transaction`, `Category`), the `Money` value object, the `TransactionType` enum (Income/Expense), and `DomainException`. No NuGet dependencies.
- **Application** (`src/FinTrack.Application`): Use cases and application services. Currently empty — add command/query handlers here.
- **Infrastructure** (`src/FinTrack.Infrastructure`): Repositories, EF Core, external services. Currently empty scaffold.
- **API** (`src/FinTrack.API`): ASP.NET Core host, controllers, OpenAPI. Currently has only a placeholder WeatherForecast endpoint.

**Domain design conventions:**

- Entities extend `Entity` (base class with `Guid Id` and value-based equality).
- Objects are created via static `Create(...)` factory methods that validate inputs and throw `DomainException` on failure.
- `Money` is an immutable value object; currency defaults to `"BRL"`. `Add`/`Subtract` require matching currencies.
- Nullable reference types are enabled across all projects.

**Test projects** use xUnit 2.9.2 with FluentAssertions. Coverage via coverlet.

## Test Coverage Status

### Domain (complete)

| Class | Tests | What's covered |
|---|---|---|
| `Money` | 9 | `Create` (valid, zero amount, empty currency, default currency), `Add` (valid, different currencies), `Subtract` (valid, different currencies, negative result) |
| `Category` | 8 | `Create` (valid, empty name, invalid type, empty color), `UpdateName` (valid, empty), `UpdateColor` (valid, empty) |
| `Transaction` | 7 | `Create` (valid, empty description, future date, empty categoryId, invalid type), `UpdateDescription` (valid, empty) |

### Application
No use cases implemented yet — no tests.

### Infrastructure
No repositories implemented yet — no tests.

### API
No endpoints implemented yet — no tests.
