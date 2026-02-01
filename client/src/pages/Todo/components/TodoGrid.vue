<script setup>
import TodoItem from './TodoItem.vue';

// TodoGrid.vue html imported from: https://www.tailwindgen.com/
</script>

<template>
  <div class="grid grid-cols-8 gap-2">
    <div class="p-16 bg-green-500 rounded-xl col-span-2 row-span-2">+</div>
    <TodoItem v-for="item in 10" :key="item">{{ item }}</TodoItem>
  </div>
</template>

<style></style>
