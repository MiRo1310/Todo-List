export interface Todo {
    id: string;
    title: string;
    isCompleted: boolean;
    createdAt: string;
    dueDate?: string;
    description?: string;
}

export interface AddTodo {
    title: string;
    dueDate?: string;
    description?: string;
}