<script lang="ts" setup>
import {onMounted, ref, watch} from 'vue';
import {useTodos} from "./lib/todos/todos.ts";
import type {Todo} from "./types/types.ts";


const count = ref(0);
const todos = ref<Todo[]>([]);
const search = ref('');
const title = ref('');
const description = ref('');
const dueDate = ref<Date | null>(null);

const {getCount, getTodos, addTodo, removeTodo, toggleStatus, searchTodos} = useTodos()
onMounted(async () => {
      await updateValues()
    }
)

const updateValues = async () => {
  count.value = await getCount()
  todos.value = await getTodos()
}

const add = async () => {
  if (!title.value) return
  await addTodo({
    title: title.value,
    description: description.value,
    dueDate: dueDate.value
  })
  title.value = '';
  description.value = '';
  dueDate.value = null;
  await updateValues()
}

const toggle = async (todo: Todo) => {
  await toggleStatus(todo.id, !todo.isCompleted)
  await updateValues()
}

const removeItem = async (id: string) => {
  await removeTodo(id)
  await updateValues()
}

let debouncedTimeout: null | number = null;

watch(search, () => {
  if (debouncedTimeout) clearTimeout(debouncedTimeout)
  debouncedTimeout = setTimeout(async () => {
    todos.value =
        search.value === "" ? await getTodos() : await searchTodos(search.value)
    count.value = await getCount()
    debouncedTimeout = null
  }, 500)

})

</script>

<template>

  <div class="table-wrapper">
    <div class="flex items-center gap-2 mb-6">
      <p>Es sind {{ count }} todos vorhanden</p>
      <input v-model="search" :placeholder="'Suche nach '" class="max-w-48">
      <button class="button" @click="search =''">X</button>
    </div>
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
        <th>Erstellt am</th>
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
          {{ new Date(todo.createdAt).toLocaleString() }}
        </td>
        <td>
          {{ todo.dueDate ? new Date(todo.dueDate).toLocaleString() : "" }}
        </td>
        <td>
          {{ todo.isCompleted }}
          <button class="button" @click="toggle(todo)">Toggle</button>
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
