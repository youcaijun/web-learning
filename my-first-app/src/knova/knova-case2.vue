<script setup>
import { reactive, ref } from 'vue';
import { equipinfoStore } from '@/stores/store.js'
import { ElMessage } from 'element-plus'

// 保存后的信息
const equipinfo = equipinfoStore();

//控制是否打开
const table = ref(false);

const selectedequipment = ref(-1);

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


// equipList格式
//  name: '添加前的',
//   x: 100,
//   y: 100,
//   width: 50,
//   height: 50,
//   fill: '#FF5733',
//   stroke: 'black',
//   cornerRadius: 10

const equipList = reactive([]);
// 读取保存后的信息
//console.log(equipinfo.equipmentList);
equipinfo.equipmentList.forEach((value, index) => {
  equipList.push(value)
});

let num = equipList.length;
const add = () => {
  equipList.push({
    name: 'new' + num,
    x: 200,
    y: 200,
    width: 50,
    height: 50,
    fill: '#FF4733',
    stroke: 'black',
    cornerRadius: 10
  });
  num++;
}



//单击事件,暂存设备名
const mousedown = (e) => {
  //console.log(e.target.attrs);
  nameTextConfig.value.text = e.target.attrs.name;
  selectedequipment.value = equipList.findIndex(item => item.name === e.target.attrs.name);
}



//处理双击，赋值，弹框
const handleDblClick = (e) => {
  //alert('双击事件开始')
  table.value = true;
};



//删除元素
const del = () => {
  let index = equipList.findIndex(item => item.name === nameTextConfig.value.text);
  if (index !== -1) {
    equipList.splice(index, 1);
  }
  //把当前选中的取消
  nameTextConfig.value.text = '';
  selectedequipment.value = -1;
}

// 处理拖拽后的数据，更新坐标
const handleDragend = (e) => {
  let index = equipList.findIndex(item => item.name === e.target.attrs.name);
  if (index != -1) {
    equipList[index].x = e.target.attrs.x;
    equipList[index].y = e.target.attrs.y;
  }
}

//保存信息
const save = () => {
  //先删再存
  equipinfo.equipmentList.length = 0;
  equipList.forEach((value, index) => {
    equipinfo.equipmentList.push(value)
  });
  ElMessage({
    message: '保存成功',
    type: 'success',
  });
}

const downloadFile = (url, filename) => {
  const a = document.createElement('a');
  a.href = url;
  a.download = filename; // 设置下载的文件名
  document.body.appendChild(a); // 将a标签添加到body中
  a.click(); // 模拟点击行为以触发下载
  document.body.removeChild(a); // 下载完成后从DOM中移除a标签
  URL.revokeObjectURL(url); // 释放URL对象
}

//导出：把当前的json保存出来
const exportlayout = () => {
  //alert('导出');
  const jsonString = JSON.stringify(equipList);
  const blob = new Blob([jsonString], { type: 'application/json' });
  const url = URL.createObjectURL(blob);
  downloadFile(url, 'data.json');
  ElMessage({
    message: '导出成功',
    type: 'success',
  });
}

//导入：把json存入当前
const handleBeforeUpload = (file) => {
  const reader = new FileReader();
  reader.onload = (e) => {
    try {
      const jsonContent = JSON.parse(e.target.result);
      //console.log(jsonContent);
      processJsonContent(jsonContent); // 处理 JSON 内容
    } catch (error) {
      ElMessage({
        message: '文件格式不正确，请上传 JSON 文件',
        type: 'error',
      });
    }
  };
  reader.readAsText(file); // 以文本形式读取文件内容
  return false; // 阻止自动上传，因为我们只读取内容
}
const processJsonContent = (jsonContent) => {
  console.log('JSON 内容:', jsonContent);
  try {
    equipList.length = 0;
    jsonContent.forEach((value, index) => {
      equipList.push(value)
    });
  } catch (e) {
    throw (e.message);
  }
  finally {
    return true;
  }
  // 在这里处理你的 JSON 数据，例如更新数据模型等
}
// const handleSuccess = () => {
//   console.log('文件上传成功');
// }
// const handleError = () => {
//   console.log('文件上传失败');
// }
// const handleRemove = (file, fileList) => {
//   console.log('移除了文件:', file, fileList);
// }





</script>

<template>

  <!-- <p>{{ equipList }}</p> -->
  <!-- 弹窗，双击操作 -->
  <!--<p>我是名称：{{nameTextConfig.text}}</p>
   <p>{{selectedequipment}}</p>
   <p>{{equipList[selectedequipment]}}</p> -->

  <el-drawer v-if="equipList.length > 0" v-model="table" title="设备信息" direction="rtl" size="25%">
    <el-form :model="equipList[selectedequipment]">
      <el-form-item label="名称：">
        <el-input v-model="equipList[selectedequipment].name" autocomplete="off" />
      </el-form-item>
      <!--数字必须是数字，否则会出bug-->
      <el-form-item label="x坐标：">
        <el-input v-model.number="equipList[selectedequipment].x" autocomplete="off" />
      </el-form-item>
      <el-form-item label="y坐标：">
        <el-input v-model.number="equipList[selectedequipment].y" autocomplete="off" />
      </el-form-item>
      <el-form-item label="状态：">
        <el-select v-model="equipList[selectedequipment].fill" placeholder="Select">
          <el-option label="停机" value="#FF4733" />
          <el-option label="待机" value="#FFA500" />
          <el-option label="生产中" value="#7CFC00" />
        </el-select>
      </el-form-item>
    </el-form>
  </el-drawer>
  <div>设备LAYOUT案例(单击拖动，双击配置)：</div>
  <div>操作：
    <el-row :gutter="20">
      <el-button @click="add()">添加</el-button>
      <el-button @click="del()">删除当前</el-button>
      <el-button @click="save()">保存</el-button>
      <el-button @click="exportlayout()">导出</el-button>
      <el-upload style="margin-left: 10px;" :before-upload="handleBeforeUpload" accept=".json">
        <el-button>导入</el-button>
      </el-upload>
    </el-row>
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
          draggable: true,
        }" @mousedown="mousedown" @dblclick="handleDblClick" @dragend="handleDragend" />
      </v-layer>
    </v-stage>
  </div>
</template>

<style scoped></style>
