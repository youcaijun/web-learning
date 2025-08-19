<script setup>
import { ref } from 'vue'

defineProps({
  msg: String,
})

const count = ref(0)
</script>

<template>
  
  <h1>{{ msg }}</h1>
  <p>当前计数: {{ count }}</p>
  <button @click="count++">增加计数</button>
  <button @click="count--">减少计数</button>
  <button @click="count = 0">重置计数</button>
  <p>请在控制台查看计数变化</p>

</template>


