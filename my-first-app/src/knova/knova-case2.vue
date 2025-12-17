<script setup>
import { reactive, ref } from 'vue';

// 画布配置
const stageConfig = ref({
  width: 800,
  height: 600
});

// 矩形配置
const rectConfig = ref({
  x: 100,
  y: 100,
  width: 50,
  height: 50,
  fill: '#FF5733',
  stroke: 'black',
  cornerRadius: 10
});
//操作

const simpleTextConfig = {
  x: window.innerWidth / 2,
  y: 15,
  text: '我存在',
  fontSize: 30,
  fontFamily: 'Calibri',
  fill: 'green',
  offsetX: 60 // 近似半宽
};

const equipList = reactive([{
  name:'添加前的',
  x: 100,
  y: 100,
  width: 50,
  height: 50,
  fill: '#FF5733',
  stroke: 'black',
  cornerRadius: 10
}]);

const add =() =>{
  equipList.push({
    name:'添加后的',
  x: 200,
  y: 200,
  width: 50,
  height: 50,
  fill: '#FF4733',
  stroke: 'black',
  cornerRadius: 10
  })
}
</script>

<template>
  <div> 设备LAYOUT案例：</div>
  <div>操作：
    <el-button @click="add()">添加设备</el-button>
  </div>
  <div>画布：</div>
  <div class="broder">
    <v-stage :config="stageConfig">
      <!-- <v-layer>
      <v-rect :config=equipList[0] ></v-rect>
      </v-layer> -->
      <v-layer>
        <v-rect v-for="(item, index) in equipList" :key="index" :config="{
          name:item.name,
          x: item.x, 
          y: item.y,
          width: 50,
          height: 50,
          fill: item.fill,
          stroke: 'black',
          cornerRadius: 10,
        }" @mousedown="console.log(item.name)" />
      </v-layer>
    </v-stage>
  </div>
</template>

<style scoped>
.broder {
  border: 1px solid #170e0e;
}
</style>
