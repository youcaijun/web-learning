<script setup>
 import { defineStore, storeToRefs } from 'pinia';
 import { listStore } from '@/stores/store.js';

 // 使用 Pinia 存储
const list = listStore();

</script>

<template>
	Pinia案例,在主要预览可以看到变化的值 <br>
{{list.str}}

 <el-button type="primary" @click="list.updateStr('发生变化了');">更新</el-button>
</template>

<style scoped></style>