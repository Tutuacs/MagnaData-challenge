<script setup lang="ts">
import { provide, ref } from "vue";
import CreateModal from "./components/CreateModal.vue";
import UpdateModal from "./components/UpdateModal.vue";
import { Todo, UpdateTodoDto } from "@/types/Todo";
import Container from "@/components/Container.vue";
import TodoGrid from "./components/TodoGrid.vue";
import Search from "@/components/Search.vue";
import { useTodo } from "@/composables/Todo";

const createModal = ref(false);
const updateModal = ref(false);
const copyAction = ref(false);
const todoGridRef = ref<InstanceType<typeof TodoGrid>>();

const toggleUpdateModal = () => {
  updateModal.value = !updateModal.value;
};

const toggleCopyAction = () => {
  copyAction.value = !copyAction.value;
};

provide("todoModal", toggleUpdateModal);
provide("copyAction", toggleCopyAction);

const search = ref("");

const { actualTodo, loading } = useTodo();

const handleSearch = (value: string) => {
  search.value = value;
};

const handleAction = async () => {
  await todoGridRef.value?.fetchTodos();
};
</script>

<template>
  <div class="p-4">
    <Container>
      <div class="mt-8 mb-16 w-full">
        <Search @search="handleSearch" />
      </div>
      <TodoGrid
        ref="todoGridRef"
        @create-modal="createModal = true"
        @update-modal="toggleUpdateModal"
      />
      <div>
        <CreateModal
          v-if="createModal"
          :open="true"
          @close="createModal = false"
          @create="handleAction"
        />
        <UpdateModal
          v-if="updateModal"
          :open="true"
          :todo="actualTodo"
          @close="toggleUpdateModal"
          @update="handleAction"
        />
      </div>
    </Container>
  </div>
</template>

<style scoped></style>
