<script setup>
import { ref } from 'vue';

const dialogTableVisible = ref(false)
const gridData = [
  {
    devicename: '一号机',
    evnentname: '停止',
    comment: '正常停止',
    time: '2025-12-01 10:00:00',
  },
  {
    devicename: '一号机',
    evnentname: '启动',
    comment: '正常启动',
    time: '2025-12-01 10:30:00',
  },
  {
    devicename: '一号机',
    evnentname: '停止',
    comment: '检修',
    time: '2025-12-03 08:00:00',
  },
  {
    devicename: '一号机',
    evnentname: '启动',
    comment: '正常启动',
    time: '2025-12-04 09:00:00',
  },
  {
    devicename: '一号机',
    evnentname: '停止',
    comment: '设备故障',
    time: '2025-12-08 18:00:00',
  },
]

// 画布配置
const stageConfig = ref({
  width: 800,
  height: 600
});

// 圆形配置
const circleConfig = ref({
  x: 100,
  y: 100,
  radius: 50,
  fill: '#00D2FF',
  stroke: 'black',
  strokeWidth: 2,

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
//操作
const change = () => {
  if (circleConfig.value.fill === '#00D2FF') {
    circleConfig.value.fill = '#FF5733';
  } else {
    circleConfig.value.fill = '#00D2FF';
  }
};

const openDialog = () => {
  dialogTableVisible.value = true;
};
</script>

<template>

  <el-dialog v-model="dialogTableVisible" title="最近5次操作历史" width="800">
    <el-table :data="gridData">
      <el-table-column property="devicename" label="设备名称" width="150" />
      <el-table-column property="evnentname" label="事件名称" width="100" />
      <el-table-column property="time" label="事件时间" width="200" />
      <el-table-column property="comment" label="备注" />
    </el-table>
  </el-dialog>
  <div> 静态案例：</div>

  <div>操作：
    <el-button @click="change()">变色</el-button>
  </div>
  <div>画布：</div>
  <div class="broder">
    <v-stage :config="stageConfig">
      <v-layer>
        <v-circle :config="circleConfig" @mousedown="openDialog()" />
        <v-rect :config="rectConfig" />
      </v-layer>
    </v-stage>
  </div>
</template>

<style scoped>
.broder {
  border: 1px solid #170e0e;
}
</style>
