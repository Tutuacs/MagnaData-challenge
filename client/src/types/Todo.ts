export interface Todo {
  id: string;
  description: string;
  createdAt: Date;
  completedAt: Date | null;
}

export interface CreateTodoDTO {
  description: string;
}

export interface UpdateTodoDTO {
  description?: string;
  completedAt?: Date | null;
}

