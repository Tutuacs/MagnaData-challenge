import { CreateTodoDTO, UpdateTodoDto } from "@/types/Todo";
import { apiClient } from "../main";

export function TodoService() {

    const METHOD_URL = '/todo';

    const createTodo = async (data: CreateTodoDTO) => {
        return apiClient.post(METHOD_URL, data);
    }

    const fetchTodos = async () => {
        return apiClient.get(METHOD_URL);
    };

    const findTodoById = async (id: string) => {
        return apiClient.get(`${METHOD_URL}/${id}`);
    };

    const updateTodo = async (id: string, data: UpdateTodoDto) => {
        return apiClient.put(`${METHOD_URL}/${id}`, data);
    };

    const deleteTodo = async (id: string) => {
        return apiClient.delete(`${METHOD_URL}/${id}`);
    };

    return {
        createTodo,
        fetchTodos,
        findTodoById,
        updateTodo,
        deleteTodo,
    }

}