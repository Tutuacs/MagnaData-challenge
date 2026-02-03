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
- Docker (opcional)

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

## ▶️ Executar

Para rodar o projeto existem duas possibilidades:
### 1. Usando Docker
```bash
docker-compose up --build
```

Existe a imagem do backend `.NET` mas não foi incluída no compose para facilitar o desenvolvimento local.
<br> É possivel usar a imagem isolada com algumas configurações extras, contudo recomenda-se usar o compose
apenas para os serviços de dados (MySQL e Redis).
<br> Após subir os serviços, rode o backend localmente conforme instruções abaixo.

```bash
dotnet restore
dotnet ef database update
dotnet run
```

### 2. Localmente

Tendo os pré-requisitos instalados, rode:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

**Acesso**: `http://localhost:5284` | **Swagger**: `http://localhost:5284/swagger`

## 🌐 Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/todo` | Lista todos (filtros: `?type=id/description&value=texto`) |
| `GET` | `/todo/{id}` | Busca por ID |
| `POST` | `/todo` | Cria novo |
| `PUT` | `/todo/{id}` | Atualiza |
| `DELETE` | `/todo/{id}` | Deleta |

## 📝 Validações
- **Descrição**: obrigatória, 3-10 caracteres
- **Conclusão**: opcional, padrão `false` (data definida pelo sistema por segurança)
- Não foi implementada validação de params para os endpoints de filtro (GET /todo)

**Exemplo**:
```json
POST /todo
{ "description": "Tarefa com +10 lenght" }
```

## 💾 Cache

Neste projeto, o cache Redis é utilizado para otimizar o desempenho das operações de leitura, reduzindo a carga no banco de dados MySQL.
<br>A estratégia de cache adotada inclui:
- **Lista** (`/todo`): key `"todos"`, TTL 1h
- **Item** (`/todo/{id}`): key `"todo/{id}"`, TTL 1h
- **Invalidação**: ao criar/atualizar/deletar

---

**Desenvolvido com .NET**
