<!--v-model与插值绑定 demo -->
<script setup>
import { ref } from 'vue';
// 定义变量 name   
var name= ref("");
</script>

 <!--v-model与插值绑定-->
<template>
  <input v-model=name type="text"  />
  <div>
      <p>输入的内容是：{{ name }}</p>
  </div>
</template>
