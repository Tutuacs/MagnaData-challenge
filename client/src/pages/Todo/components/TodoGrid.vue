<script setup lang="ts">
import { PlusIcon } from "@heroicons/vue/24/outline";
import TodoItem from "./TodoItem.vue";
import { useTodo } from "@/composables/Todo";

// TodoGrid.vue html imported from: https://www.tailwindgen.com/

const emit = defineEmits(["create-modal", "update-modal"]);

const { fetchTodos: searchTodos, todos, loading } = useTodo();

const fetchTodos = async ({type, value}: {type?: 'id' | 'description', value?: string}) => {
  if (type && value) {
    await searchTodos({ type, value });
    return;
  }
  await searchTodos({});
};

defineExpose({
  fetchTodos,
});

fetchTodos({});

const handleCreateNew = () => {
  emit("create-modal");
};

const handleDelete = () => {
  fetchTodos({});
};
</script>

<template>
  <div
    class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 lg:grid-cols-8 gap-2"
  >
    <button
      @click="handleCreateNew"
      class="group cursor-pointer p-8 hover:scale-101 bg-green-500 hover:bg-green-600 rounded-xl col-span-1 sm:col-span-2 md:col-span-2 lg:col-span-2 row-span-2 transition-colors duration-200 flex flex-col items-center justify-center gap-2 text-white font-medium shadow-md hover:shadow-lg"
    >
      <PlusIcon class="h-8 w-8 group-hover:scale-110 transition-transform" />
      <span>Adicionar novo</span>
    </button>
    <TodoItem
      class="hover:shadow-lg hover:scale-101"
      @delete-todo="handleDelete"
      v-for="item in todos"
      :key="item.id"
      :item="item"
    />
  </div>
</template>

<style></style>
