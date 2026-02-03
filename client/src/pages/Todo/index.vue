<script setup lang="ts">
import { provide, ref, nextTick } from "vue";
import CreateModal from "./components/CreateModal.vue";
import UpdateModal from "./components/UpdateModal.vue";
import Container from "@/components/Container.vue";
import TodoGrid from "./components/TodoGrid.vue";
import Search from "@/components/Search.vue";
import { useTodo } from "@/composables/Todo";

const createModal = ref(false);
const updateModal = ref(false);
const searchQuery = ref("");
const searchType = ref(false);
const todoGridRef = ref<InstanceType<typeof TodoGrid>>();
const { actualTodo, loading } = useTodo();

// search action
const handleAction = async () => {
  if (searchQuery.value.trim() !== "") {
    const type = searchType.value ? 'id' : 'description';
    await todoGridRef.value?.fetchTodos({ type, value: searchQuery.value });
    return;
  }
  await todoGridRef.value?.fetchTodos({});
};

// open UpdateModal
const toggleUpdateModal = () => {
  updateModal.value = !updateModal.value;
};

// use IdFilter
const copyIdAction = () => {
  searchType.value = true;
};

provide("todoModal", toggleUpdateModal);
provide("copyIdAction", copyIdAction);

const handleSearch = async (payload: { type: boolean; value: string }) => {
  // https://vuejs.org/api/general.html#nexttick
  searchType.value = payload.type;
  searchQuery.value = payload.value;
  await nextTick();
  handleAction();
};

provide("handleSearch", handleSearch);
</script>

<template>
  <div class="p-4">
    <Container>
      <div class="mt-8 mb-16 w-full">
        <Search
          @search="handleSearch"
          :searchType="searchType"
          :searchQuery="searchQuery"
        />
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
