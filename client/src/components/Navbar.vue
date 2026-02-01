<script setup></script>

<template>
  <nav class="bg-slate-600 p-4 shadow-2xl border-b-2 border-slate-800">
    <Img v-if="mode === 'ligth'" src="/logo_l.png" class="h-16 ml-12" />
    <Img v-else src="/logo_l.png" class="h-16 ml-12" />
  </nav>
</template>

<style scoped></style>
