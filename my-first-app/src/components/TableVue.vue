<script setup>
import { ref } from 'vue'

defineProps({
  msg: Number,
})

const count = ref(0)
</script>

<template>
  <h1>{{ msg }}</h1>
</template>


