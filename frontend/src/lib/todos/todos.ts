import {request} from "../fetch/fetch.ts";
import type {AddTodo, Todo} from "../../types/types.ts";

export const useTodos = () => {
    const getCount = async (): Promise<number> => {
        return await request({"method": "GET", endpoint: "count"})
    }

    const getTodos = async (): Promise<Todo[]> => {
        return await request({"method": "GET"})
    }

    const addTodo = async (body: AddTodo): Promise<void> => {
        await request({"method": "POST", body})
    }

    const removeTodo = async (id: string): Promise<void> => {
        const query = {id: id}
        await request({"method": "DELETE", endpoint: `delete`, query})
    }

    const searchTodos = async (search: string) => {
        return request({"method": "POST", endpoint: "search", body: search})
    }

    const toggleStatus = async (id: string, status: boolean): Promise<void> => {
        await request({"method": "PUT", endpoint: `status`, body: {id, status}})
    }
    return {getCount, getTodos, addTodo, removeTodo, toggleStatus, searchTodos}
}