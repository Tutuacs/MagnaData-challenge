import { TodoService } from "@/services/Todo/todoService";
import type { CreateTodoDTO, Todo, UpdateTodoDto } from "@/types/Todo";
import { ref } from "vue";

const todos = ref<Todo[]>([]);
const loading = ref(false);
const actualTodo = ref<Todo>();
const error = ref<string | null>(null);

export function useTodo() {

  const todoService = TodoService();

  const fetchTodos = async ({type, value}: {type?: 'id' | 'description', value?: string}) => {
    loading.value = true;
    const response = await todoService.fetchTodos({type, value});
    todos.value = response.data.data;
    loading.value = false;
  };

  const createTodo = async (data: CreateTodoDTO) => {
    loading.value = true;
    const response = await todoService.createTodo(data);
    loading.value = false;
  };

  const findTodoById = async (id: string): Promise<Todo | null> => {
    loading.value = true;
    const response = await todoService.findTodoById(id);
    loading.value = false;
    return response.data;
  };

  const updateTodo = async (data: UpdateTodoDto, id: string) => {
    loading.value = true;
    const response = await todoService.updateTodo(id, data);
    loading.value = false;
  };

  const deleteTodo = async (id: string) => {
    loading.value = true;
    const response = await todoService.deleteTodo(id);
    loading.value = false;
  };

  return {
    todos,
    actualTodo,
    loading,
    error,
    fetchTodos,
    createTodo,
    findTodoById,
    updateTodo,
    deleteTodo,
  };
}
