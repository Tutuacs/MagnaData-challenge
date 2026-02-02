export interface Todo {
  id: string;
  description: string;
  createdAt: Date;
  completed: Date | null;
}

export interface CreateTodoDTO {
  description: string;
}

export interface UpdateTodoDto {
  description?: string;
  completed?: boolean;
}

