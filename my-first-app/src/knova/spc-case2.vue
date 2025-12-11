<script setup>
import ECharts from '@/components/echarts.vue';
import { ref } from 'vue';

// 异常3：连续6个点连续递增或递减
// 设置区间刻度和标记线
const option = ref({
  xAxis: {
    type: 'category',
    data: ['12-01', '12-02', '12-03', '12-04', '12-05', '12-06', '12-07', '12-08', '12-09', '12-10', '12-11', '12-12', '12-13', '12-14', '12-15']
  },
  yAxis: {
    type: 'value',
    min: 60,
    max: 140,
    interval: 10,
    splitLine: {
      show: true
    }
  },
  visualMap: {
    show: false,
    dimension: 0,
    pieces: [] // 初始时不设置 间断 数据
    // {
    //   lte: 6,
    //   color: 'green'
    // },
  },
  series: [
    {
      //异常在中间
      data: [90, 80, 120, 127, 110, 113, 114, 115, 118, 119, 122, 83, 86, 79, 124],
      //异常在尾部
      //data: [90, 80, 126, 127, 110, 113, 120, 115, 110, 105, 100, 95, 90, 85, 80],
      //异常在头部
      //data: [ 120, 115, 110, 105, 100, 95, 90, 85, 80, 124,90, 85, 80,100,110],
      type: 'line',
      markPoint: { // 初始时不设置 markPoint 数据
        data: []
      },
      markLine: {
        symbol: 'none', // 隐藏箭头
        data: [
          {
            yAxis: 130,
            label: { formatter: 'UCL' },
            lineStyle: {
              type: 'dashed',
              color: 'red'
            }
          },
          {
            yAxis: 70,
            label: { formatter: 'LCL' },
            lineStyle: {
              type: 'dashed',
              color: 'red'
            }
          }
        ]
      }
    },
  ]
});
// 动态添加markPoint数据，筛选出符合异常3的点
const data = option.value.series[0].data;
const markPointData = [];
for (let i = 1; i < data.length-1; i++) {
  if((data[i - 1] - data[i]) * (data[i] - data[i + 1]) > 0){
    continue;
  } else{
    markPointData.push(i);
  }
}
console.log('markPointData:', markPointData);
// 输出区间数据
const finalMarkPointData = [];
markPointData.forEach((value, index) => {
  if (index === 0) {
    finalMarkPointData.push([0, value]);
  }
  if (index > 0) {
    finalMarkPointData.push([markPointData[index - 1], value]);
  }
  //尾部需要补数据，否则会缺失
  if (index === markPointData.length - 1) {
    finalMarkPointData.push([value, data.length]);
  }
});
console.log('finalMarkPointData2:', finalMarkPointData);

finalMarkPointData.forEach((value, index) => {
  //console.log('value:', value[0], value[1]);
  if (value[1] - value[0] + 1 > 5) {
    option.value.visualMap.pieces.push({
      gte: value[0],
      lte: value[1],
      color: 'orange'
    });
  } else {
    option.value.visualMap.pieces.push({
      gte: value[0],
      lte: value[1],
      color: 'blue'
    });
  }
});
</script>

<template>
  spc案例2
  <el-row :gutter="20">
    <el-col :span="14">
      <el-card style="width: 100%">
        <template #header>异常3：连续6个点连续递增递减</template>
        <!-- 子组件传值方式: -->
        <ECharts :option=option></ECharts>
      </el-card>
    </el-col>
    <!-- <el-col :span="11">
      <el-card style="width: 100%">
        <template #header>异常4：连续14个点上下交错</template>
        <ECharts :option=option2></ECharts>
      </el-card>
    </el-col> -->
  </el-row>
</template>

<style scoped></style>