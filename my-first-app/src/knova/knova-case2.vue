<script setup>
import { reactive, ref } from 'vue';

// 画布配置
const stageConfig = ref({
  width: 1200,
  height: 600
});

// 矩形配置
const rectConfig = ref({
  x: 0,
  y: 0,
  width: 1200,
  height: 600,
  fill: '#808080',
  stroke: 'black'
});
//操作

const simpleTextConfig = ref({
  x: 10,
  y: 10,
  text: '设备名称:',
  fontSize: 20,
  fontFamily: 'Calibri',
  fill: 'black'
});

//存放设备名称
const nameTextConfig = ref({
  x: 10,
  y: 10,
  text: '',
  fontSize: 20,
  fontFamily: 'Calibri',
  fill: 'black',
  offsetX: -90
});

const equipList = reactive([{
  name: '添加前的',
  x: 100,
  y: 100,
  width: 50,
  height: 50,
  fill: '#FF5733',
  stroke: 'black',
  cornerRadius: 10
}]);

const add = () => {
  equipList.push({
    name: '添加后的',
    x: 200,
    y: 200,
    width: 50,
    height: 50,
    fill: '#FF4733',
    stroke: 'black',
    cornerRadius: 10
  })
}

//单击事件
const mousedown = (e) => {
  console.log(e);
  nameTextConfig.value.text = e.target.attrs.name;
}

//处理双击，弹框,todo
const handleDblClick = (e) => {
  alert('双击事件')
};

//删除元素
const del = () => {
  let index = equipList.findIndex(item => item.name === nameTextConfig.value.text);
  if (index !== -1) {
    equipList.splice(index, 1);
  }
}

//保存信息,todo
const save = () => {
  //
  alert('保存信息');
}
//todo
const exportlayout = () =>{
  alert('导出');
}

//todo
const importlayout = () =>{
  alert('导入');
}
</script>

<template>
  <div>设备LAYOUT案例(单击拖动，双击配置)：</div>
  <div>操作：
    <el-button @click="add()">添加</el-button>
    <el-button @click="del()">删除当前</el-button>
    <el-button @click="save()">保存</el-button>
    <el-button @click="exportlayout()">导出</el-button>
    <el-button @click="importlayout()">导入</el-button>
  </div>
  <div>画布：</div>
  <div>
    <v-stage :config="stageConfig">
      <!-- 次序决定位置高低，除了可拖拽会变化高度-->
      <v-layer>
        <v-rect :config="rectConfig" />
        <v-text :config="simpleTextConfig"></v-text>
        <v-text :config="nameTextConfig"></v-text>
        <v-rect v-for="(item, index) in equipList" :key="index" :config="{
          name: item.name,
          x: item.x,
          y: item.y,
          width: 50,
          height: 50,
          fill: item.fill,
          stroke: 'black',
          cornerRadius: 10,
          draggable: true
        }" @mousedown="mousedown" @dblclick="handleDblClick" />
      </v-layer>
    </v-stage>
  </div>
</template>

<style scoped></style>
