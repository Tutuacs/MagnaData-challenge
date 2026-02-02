<script setup lang="ts">
import { useTodo } from "@/composables/Todo";
import { Todo } from "@/types/Todo";
import { DocumentDuplicateIcon, TrashIcon } from "@heroicons/vue/24/outline";
import { inject } from "vue";

// TodoItem.vue html based on: https://www.tailwindgen.com/
const props = defineProps({
  item: {
    type: Object as () => Todo,
    required: true,
  },
});

const toggleUpdateModal = inject<() => void>("todoModal")!;
const toggleCopyAction = inject<() => void>("copyAction")!;

const { deleteTodo, actualTodo } = useTodo();

const copyToClipboard = async (text: string) => {
  await navigator.clipboard.writeText(text);
  toggleCopyAction();
};

const emit = defineEmits(["update-modal", "delete-todo", "copy-id"]);

const handleUpdate = () => {
  actualTodo.value = props.item;
  toggleUpdateModal();
};

const handleDelete = async () => {
  await deleteTodo(props.item.id);
  emit("delete-todo");
};
</script>

<template>
  <div class="bg-slate-600 rounded-xl col-span-2 row-span-2 min-h-40 shadow-md">
    <div class="w-full h-full flex flex-col">
      <div class="flex-1 p-5">
        <div class="flex justify-between items-start mb-4">
          <div class="flex items-center gap-2">
            <span class="px-3 py-1 bg-white rounded-full text-sm font-medium">
              {{ item.completed ? "Concluído" : "Pendente" }}
            </span>
          </div>
          <div class="flex flex-col gap-2">
            <div class="relative group" @click="copyToClipboard(item.id)">
              <DocumentDuplicateIcon
                class="h-5 w-5 text-white cursor-pointer hover:text-blue-400 transition-colors"
              />
              <span
                class="absolute left-1/2 -translate-x-1/2 bottom-full mb-2 hidden group-hover:block bg-gray-900 text-white text-xs rounded py-1 px-2 whitespace-nowrap"
              >
                Copiar Id
              </span>
            </div>
            <div class="relative group" @click="handleDelete">
              <TrashIcon
                class="h-5 w-5 text-white cursor-pointer hover:text-red-400 transition-colors"
              />
              <span
                class="absolute left-1/2 -translate-x-1/2 bottom-full mb-2 hidden group-hover:block bg-gray-900 text-white text-xs rounded py-1 px-2 whitespace-nowrap"
              >
                Excluir
              </span>
            </div>
          </div>
        </div>
        <p class="text-white line-clamp-3">{{ item.description }}</p>
      </div>
      <div class="grid grid-cols-2 border-t border-slate-300">
        <div class="p-3 border-r border-slate-300 text-center text-white">
          <div class="font-medium text-sm">
            {{
              item.createdAt
                ? new Date(item.createdAt).toLocaleDateString("pt-BR")
                : "N/A"
            }}
          </div>
        </div>
        <button
          class="group cursor-pointer p-3 text-center bg-amber-400 rounded-br-xl"
          :class="{ 'bg-green-500 hover:animate-pulse': item.completed }"
          @click="handleUpdate"
        >
          <div class="font-medium text-sm">
            <span v-if="!item.completed" class="group-hover:hidden"
              >Pendente</span
            >
            <span v-if="!item.completed" class="hidden group-hover:block"
              >Atualizar</span
            >
            <span v-if="item.completed">{{
              item.completed
                ? new Date(item.completed).toLocaleDateString("pt-BR")
                : "N/A"
            }}</span>
          </div>
        </button>
      </div>
    </div>
  </div>
</template>

<style></style>
