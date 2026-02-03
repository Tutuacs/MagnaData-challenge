# Build Stage
FROM node:20-alpine
WORKDIR /app

# Copiar package files
COPY package.json pnpm-lock.yaml ./

# Instalar pnpm e dependências
RUN npm install -g pnpm && pnpm install

# Copiar código fonte
COPY . .

# Build da aplicação (sem type-check para evitar erros no Docker)
RUN pnpm build-only

EXPOSE 4173

CMD ["pnpm", "preview", "--host", "0.0.0.0", "--port", "4173"]
