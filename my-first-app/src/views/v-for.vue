<!--v-for demo -->
<script setup>
import { ref } from 'vue';
 // 定义变量 list   
var list = ref(["apple", "banana", "orange", "grape"]);
</script>

<template>
    <ul>
        <li v-for="(item, index) in list" :key="index">
        <strong >{{ index }}</strong>
        <div>{{ item }}</div>
        </li>
    </ul>
</template>
