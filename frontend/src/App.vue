<script lang="ts" setup>
import {onMounted, ref} from 'vue';

import {useTodos} from "./lib/todos/todos.ts";
import type {Todo} from "./types/types.ts";

const count = ref(0);
const todos = ref<Todo[]>([]);
const {getCount, getTodos, addTodo, removeTodo} = useTodos()
onMounted(async () => {
      await updateValues()
    }
)

const updateValues = async () => {
  count.value = await getCount()
  todos.value = await getTodos()
}


const title = ref('');
const description = ref('');
const dueDate = ref<Date | null>(null);

const add = async () => {
  if (!title.value) return
  await addTodo({
    title: title.value,
    description: description.value,
    dueDate: String(dueDate.value)
  })
  await updateValues()
}

const removeItem = async (id: string) => {
  await removeTodo(id)
  await updateValues()
}
</script>

<template>

  <div class="table-wrapper">
    <p>Es sind {{ count }} todos vorhanden</p>
    <table>
      <thead>
      <tr>
        <th></th>
        <th><input v-model="title"></th>
        <th><input v-model="description"></th>
        <th><input v-model="dueDate" type="datetime-local"></th>
        <th class="flex">
          <button class="button" @click="add">Add</button>
        </th>
        <th/>
      </tr>
      <tr>
        <th>Id</th>
        <th>Title</th>
        <th>Beschreibung</th>
        <th>Fälligkeitsdatum</th>
        <th>Erledigt</th>
        <th> Löschen</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="todo in todos" :key="todo.id">
        <td>
          {{ todo.id }}
        </td>
        <td>
          {{ todo.title }}
        </td>
        <td>
          {{ todo.description }}
        </td>
        <td>
          {{ todo.dueDate ?? "" }}
        </td>
        <td>
          {{ todo.isCompleted }}
        </td>
        <td>
          <button class="button" @click="removeItem(todo.id)">Del</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>
<style scoped>
.table-wrapper {
  @apply p-4
}

.button {
  @apply border-2 border-black p-1
}

input {
  @apply w-full px-2 py-1 bg-gray-100;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}
</style>
