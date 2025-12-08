<script setup>
import { ref } from 'vue';

// 画布配置
const stageConfig = ref({
  width: 800,
  height: 600,
  fill: '#FF5733'
});

// 圆形配置
const circleConfig = ref({
  x: 100,
  y: 100,
  radius: 50,
  fill: '#00D2FF',
  stroke: 'black',
  strokeWidth: 2
});

// 矩形配置
const rectConfig = ref({
  x: 200,
  y: 150,
  width: 100,
  height: 100,
  fill: '#FF5733',
  cornerRadius: 10
});
</script>

<template>
	<div> 静态案例：</div>
 
  <v-stage :config="stageConfig">
    <v-layer>
      <v-circle :config="circleConfig"/>
      <v-rect :config="rectConfig"/>
    </v-layer>
  </v-stage>
</template>

<style scoped>
</style>

