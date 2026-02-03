# 🚀 MagnaData Challenge

Sistema completo de gerenciamento de tarefas com API .NET e interface Vue 3.

## 📦 Stack

**Backend:**
- .NET 10.0 + Entity Framework Core
- MySQL 8.0
- Redis

**Frontend:**
- Vue 3 + TypeScript
- Tailwind CSS
- Vite

## 🐳 Quick Start com Docker

### Executar tudo com Docker Compose

```bash
# Build e iniciar todos os serviços
docker-compose up -d

# Ver logs
docker-compose logs -f

# Parar todos os serviços
docker-compose down
```

**Acessos:**
- Frontend: http://localhost:4173
- API: http://localhost:5000
- Swagger: http://localhost:5000/swagger
- MySQL: localhost:3300
- Redis: localhost:6379

### Serviços inclusos

- MySQL (porta 3300)
- Redis (porta 6379)
- API .NET (porta 5000)
- Frontend Vue (porta 4173)

## 🛠️ Desenvolvimento Local

### Backend (API)

```bash
cd api
dotnet restore
dotnet ef database update
dotnet run
```

📖 [Documentação completa da API](./api/README.md)

### Frontend (Client)

```bash
cd client
pnpm install
pnpm dev
```

📖 [Documentação completa do Frontend](./client/README.md)

## 📁 Estrutura do Projeto

```
MagnaData-challenge/
├── api/                    # Backend .NET
│   ├── Controllers/
│   ├── Services/
│   ├── Data/
│   ├── Dockerfile
│   └── README.md
├── client/                 # Frontend Vue
│   ├── src/
│   ├── Dockerfile
│   └── README.md
├── docker-compose.yml      # Orquestração dos serviços
└── README.md
```

## 🌐 Endpoints da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/todo` | Listar tarefas |
| `GET` | `/todo/{id}` | Buscar por ID |
| `POST` | `/todo` | Criar tarefa |
| `PUT` | `/todo/{id}` | Atualizar tarefa |
| `DELETE` | `/todo/{id}` | Deletar tarefa |

## ⚙️ Configuração

### Variáveis de Ambiente (API)

```env
ConnectionStrings__DefaultConnection=Server=mysql;Database=MagnaData;User=root;Password=pass;
ConnectionStrings__Redis=redis:6379
```

### Configuração do Frontend

API base URL em `client/src/services/main.ts`:
```typescript
baseURL: 'http://localhost:5000' // Docker
baseURL: 'http://localhost:5284' // Localhost
```

## 🔄 Migrations

Migrations são executadas automaticamente no Docker. Para rodar manualmente:

```bash
cd api
dotnet ef database update
```

## 🧪 Tecnologias Detalhadas

**API:**
- ASP.NET Core Web API
- Entity Framework Core + MySQL
- Redis para cache
- Swagger/OpenAPI

**Frontend:**
- Vue 3 Composition API
- TypeScript
- Vue Router + Pinia (Pinia não está sendo usado no momento)
- Axios
- Heroicons

## 📝 Funcionalidades

- CRUD completo de tarefas
- Busca por ID ou descrição (ID Não funciona com os seeds atuais, apenas com novos dados)
- Cache com Redis
- Interface responsiva
- Validações
- Tratamento de erros

---

**Desenvolvido para o MagnaData Challenge**

"Sendo bem direto: a documentação atual, juntamente da do front-end e back-end foram geradas por IA após descrição detalhada do projeto, funcionalidades e tecnologias a serem usadas. Mais por motivos de tempo!"