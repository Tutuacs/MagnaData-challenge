<script setup lang="ts">
import { ref } from "vue";
import CreateModal from "./components/CreateModal.vue";
import UpdateModal from "./components/UpdateModal.vue";
import { UpdateTodoDto } from "@/types/Todo";
import Container from "@/components/Container.vue";
import TodoGrid from "./components/TodoGrid.vue";
import Search from "@/components/Search.vue";

const createModal = ref(false);
const updateModal = ref(false);
const todo = ref<UpdateTodoDto | null>(null);
todo.value = {
  description: "Initial Todo",
  completed: false,
};

const search = ref("");

const handleSearch = (value: string) => {
  search.value = value;
  // Aqui você pode fazer outras operações com o valor
  console.log('Search value:', value);
};
</script>

<template>
  <div class="p-4">
    <!-- <button class="bg-slate-200" @click="createModal = true">
      Open Create Modal
    </button>
    <hr />
    <button class="bg-slate-200" @click="updateModal = true">
      Open Edit Modal
    </button> -->
    <Container>
      <div class="mt-8 mb-16 w-full">
        <Search @search="handleSearch"></Search>
      </div>
      <TodoGrid> </TodoGrid>
      <div>
        <CreateModal
          v-if="createModal"
          :open="true"
          @close="createModal = false"
          @create="console.log('created')"
        />
        <UpdateModal
          v-if="updateModal"
          :open="true"
          :todo="todo"
          @close="updateModal = false"
          @update="console.log('updated')"
        />
      </div>
    </Container>
  </div>
</template>

<style scoped></style>
