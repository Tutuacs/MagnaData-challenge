# 🚀 API - MagnaData Challenge

API RESTful em .NET para gerenciamento de tarefas com cache Redis e persistência MySQL.

## 🛠️ Tecnologias

- **.NET 10.0** - Framework 
- **Entity Framework Core** - ORM
- **MySQL** - Banco de dados
- **Redis** - Cache distribuído
- **Swagger** - Documentação

## 🏗️ Arquitetura

```
Controllers → Services → Repositories → Database
     ↓
CacheContext → Redis
```

**Camadas**: Controllers (REST) → Services (lógica) → Repositories (dados) → Persistência

## 📦 Pré-requisitos

- .NET 10.0 SDK
- MySQL 8.0+
- Redis 6.0+

## ⚙️ Configuração

Edite `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3300;Database=MagnaData;User Id=root;Password=MagnadataPass;",
    "Redis": "localhost:6379"
  }
}
```

Redis: `localhost:6379` (padrão em `Data/CacheContext.cs`)

## ▶️ Executar

```bash
dotnet restore
dotnet ef database update
dotnet run
```

**Acesso**: `http://localhost:5000` | **Swagger**: `http://localhost:5000/swagger`

## 🌐 Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/todo` | Lista todos (filtros: `?type=id/description&value=texto`) |
| `GET` | `/todo/{id}` | Busca por ID |
| `POST` | `/todo` | Cria novo |
| `PUT` | `/todo/{id}` | Atualiza |
| `DELETE` | `/todo/{id}` | Deleta |

**Exemplo**:
```json
POST /todo
{ "description": "Tarefa" }
```

## 💾 Cache

- **Lista** (`/todo`): key `"todos"`, TTL 1h
- **Item** (`/todo/{id}`): key `"todo/{id}"`, TTL 1h
- **Invalidação**: ao criar/atualizar/deletar

## 🗄️ Migrations

```bash
dotnet ef migrations add NomeMigration
dotnet ef database update
```

---

**Desenvolvido com .NET**
