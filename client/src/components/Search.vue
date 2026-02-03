<script setup lang="ts">
import { ref, watch } from "vue";
import { MagnifyingGlassIcon } from "@heroicons/vue/24/outline";

const props = defineProps({
  searchType: {
    required: true,
    type: Boolean,
    default: false,
  },
  searchQuery: {
    required: true,
    type: String,
    default: "",
  },
});

const localSearchType = ref(props.searchType);
const localSearchQuery = ref(props.searchQuery);

watch(() => props.searchType, (newVal) => {
  localSearchType.value = newVal;
});

watch(() => props.searchQuery, (newVal) => {
  localSearchQuery.value = newVal;
});

const emit = defineEmits<{
  search: [{ type: boolean; value: string }];
}>();

const handleSearch = () => {
  emit("search", { type: localSearchType.value, value: localSearchQuery.value });
};

const handleKeyPress = (e: KeyboardEvent) => {
  if (e.key === "Enter") {
    handleSearch();
  }
};
</script>

<template>
  <div class="w-full mx-auto max-w-2xl">
    <div class="flex items-center gap-2 bg-slate-200 rounded-lg shadow-lg p-2">
      <select
        v-model="localSearchType"
        class="px-4 py-2.5 bg-slate-400 text-slate-700 rounded-lg font-medium text-sm focus:outline-none focus:ring-2 focus:ring-yellow-500 cursor-pointer"
      >
        <option :value="false">Descrição</option>
        <option :value="true">ID</option>
      </select>

      <input
        v-model="localSearchQuery"
        type="text"
        :placeholder="
          localSearchType ? 'Buscar por ID...' : 'Buscar por descrição...'
        "
        class="flex-1 px-4 py-2.5 text-gray-700 text-sm focus:outline-none"
        @keypress="handleKeyPress"
      />

      <button
        type="button"
        @click="handleSearch"
        class="inline-flex items-center gap-2 px-6 py-2.5 bg-yellow-600 hover:bg-yellow-700 text-white font-medium text-sm rounded-lg transition-colors focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
      >
        <MagnifyingGlassIcon class="w-5 h-5" />
        Buscar
      </button>
    </div>
  </div>
</template>

<style scoped></style>
