<script setup>
import ECharts from '@/components/echarts.vue';

 import { listStore } from '@/stores/store.js';

 // 使用 Pinia 存储
const list = listStore();
</script>

<template>
    
    <h1>主要预览</h1>

    {{list.str}}
    <ECharts></ECharts>
</template>

<style scoped></style>