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
        const body = {id: id}
        await request({"method": "DELETE", endpoint: `delete`, body})

    }
    return {getCount, getTodos, addTodo, removeTodo}
}