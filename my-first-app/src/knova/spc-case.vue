<script setup>
import ECharts from '@/components/echarts.vue';
import { ref } from 'vue';

// 异常1：1个点落在中心线3σ以外
// 设置区间刻度和标记线
const option1 = ref({
  xAxis: {
    type: 'category',
    data: ['12-01', '12-02', '12-03', '12-04', '12-05', '12-06', '12-07']
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
  series: [
    {
      data: [100, 135, 130, 90, 104, 120, 65],
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
// 动态添加markPoint数据，筛选出符合异常1的点
const data1 = option1.value.series[0].data; 
const markPointData = [];
data1.forEach((value, index) => {
  if (value >= 130 || value <= 70) {
    markPointData.push({
      name: '异常点',
      value: value,
      xAxis: index,
      yAxis: value,
      itemStyle: { color: 'orange' } // 设置异常点颜色
    });
  }
});
option1.value.series[0].markPoint.data = markPointData;
// 异常2：连续9个点在中心线同一侧
</script>

<template>
  spc案例
  <el-row :gutter="20">
    <el-col :span="12">
      <el-card style="width: 100%">
        <template #header>异常1：点落在中心线3σ以外</template>
        <!-- 子组件传值方式: -->
        <ECharts :option=option1></ECharts>
      </el-card>
    </el-col>
    <el-col :span="12">
      <el-card style="width: 100%">
        <template #header>异常2：连续9个点在中心线同一侧</template>
        <ECharts></ECharts>
      </el-card>
    </el-col>
  </el-row>
</template>

<style scoped></style>