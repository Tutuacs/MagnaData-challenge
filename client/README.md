# 🎨 Client - MagnaData Challenge

Interface moderna para gerenciamento de tarefas, desenvolvida com Vue 3, TypeScript e Tailwind CSS.

## 🛠️ Tecnologias

- **Vue 3** - Framework progressivo
- **TypeScript** - Tipagem estática
- **Vite** - Build tool e dev server
- **Vue Router** - Navegação SPA
- **Pinia** - Gerenciamento de estado
- **Tailwind CSS** - Estilização utilitária
- **Heroicons** - Ícones
- **Axios** - Cliente HTTP

## 🏗️ Arquitetura

```
Components → Composables → Services → API
     ↓
  Pages (Routes)
```

**Estrutura**: Pages (rotas) → Components (UI) → Composables (lógica) → Services (HTTP)

## 📦 Pré-requisitos

- Node.js 18+ 
- pnpm (ou npm/yarn)

## ⚙️ Instalação

```bash
cd client
pnpm install
```

## ▶️ Executar

Para rodar localmente é preciso atualizar a configuração do endpoint da API em `src/services/main.ts`.
<br> Como não foi implementado um arquivo de configuração `.env`, o endpoint está hardcoded para o docker (`http://localhost:5000`).

```bash
# Desenvolvimento
pnpm dev

# Build produção
pnpm build

# Preview build (porta usada no Docker)
pnpm preview
```

**Acesso Dev**: `http://localhost:5173`  
**Acesso Preview/Docker**: `http://localhost:4173`

## 🌐 API

Configure o endpoint da API em `src/services/main.ts`:

```typescript
const api = axios.create({
  baseURL: 'http://localhost:5000' // Para docker ou 'http://localhost:5284' para dev local
});
```

## 📁 Estrutura

```
client/
├── src/
│   ├── components/        # Componentes reutilizáveis
│   │   ├── Container.vue
│   │   ├── Navbar.vue
│   │   └── Search.vue
│   ├── composables/       # Lógica compartilhada
│   │   └── Todo.ts
│   ├── pages/             # Páginas/rotas
│   │   └── Todo/
│   │       ├── index.vue
│   │       └── components/
│   ├── router/            # Configuração rotas
│   │   └── index.ts
│   ├── services/          # Chamadas API
│   │   ├── main.ts
│   │   └── Todo/
│   ├── stores/            # Estado global (Pinia)
│   │   └── counter.ts
│   ├── types/             # TypeScript types
│   │   └── Todo.ts
│   ├── App.vue
│   └── main.ts
├── public/
├── index.html
├── vite.config.ts
├── tailwind.config.js
└── package.json
```

## ✨ Funcionalidades

- Listar tarefas
- Criar nova tarefa
- Atualizar tarefa (marcar como concluída)
- Deletar tarefa
- Buscar por ID ou descrição
- Copiar ID para área de transferência
- Interface responsiva

## 🎨 Componentes Principais

### `Search.vue`
Campo de busca com toggle ID/Descrição

### `TodoGrid.vue`
Grid de cards com todas as tarefas

### `TodoItem.vue`
Card individual de tarefa com ações (copiar, deletar, atualizar)

### `CreateModal.vue` / `UpdateModal.vue`
Modais para criar/editar tarefas

## 🔄 Composables

### `useTodo()`
Gerencia estado e lógica das tarefas:
- `todos` - Lista de tarefas
- `actualTodo` - Tarefa selecionada
- `loading` - Estado de carregamento(não implementado)
- `fetchTodos()` - Buscar tarefas
- `createTodo()` - Criar tarefa
- `deleteTodo()` - Deletar tarefa
- ...e mais

---

**Desenvolvido com Vue 3 + TypeScript**
