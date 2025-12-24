<script setup>
import ECharts from '@/components/echarts.vue';
import { ref } from 'vue';

// 异常1：点落在中心线3σ以外
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

// 异常2：连续超过9个点在中心线同一侧

const option2 = ref({
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
    // {
    //   gt: 6,
    //   lte: 15,
    //   color: 'orange'
    // }],
  },
  series: [
    {
      //异常在中间
      data: [90, 80, 126, 127, 110, 113, 114, 115, 118, 119, 111, 83, 86, 79, 124],
      //异常在尾部
      //data: [90, 80, 126, 127, 110, 113, 114, 115, 118, 119, 122, 111, 110, 114, 124],
      //异常在头部
      //data: [90, 80, 70, 75, 85, 73, 72, 93, 83, 119, 122, 83, 86, 79, 124],
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
// 动态添加markPoint数据，筛选出符合异常2的点
const data2 = option2.value.series[0].data;
const markPointData2 = [];
for (let i = 0; i < data2.length; i++) {
  let j = i;
  let flag = true;
  while (flag) {
    if (data2[j] >= 100 && data2[i] >= 100) {
      j++;
    } else if (data2[j] < 100 && data2[i] < 100) {
      j++;
    } else {
      i = i + j;
      markPointData2.push(j);
      flag = false;
    }
  }
}
//console.log('markPointData2:', markPointData2);
// 输出区间数据
const finalMarkPointData2 = [];
markPointData2.forEach((value, index) => {
  if (index === 0) {
    finalMarkPointData2.push([0, value-1]);
    //补到下一段的连接数据
    finalMarkPointData2.push([value-1, value ]);
  }
  if (index > 0) {
    finalMarkPointData2.push([markPointData2[index - 1], value - 1]);
     //补到下一段的连接数据
    finalMarkPointData2.push([value-1, value]);
  }
  if (index === markPointData2.length - 1) {
    finalMarkPointData2.push([value - 1, data2.length]);
  }
});
//console.log('finalMarkPointData2:', finalMarkPointData2);

finalMarkPointData2.forEach((value, index) => {
  //console.log('value:', value[0], value[1]);
  if (value[1] - value[0] + 1 > 8) {
    option2.value.visualMap.pieces.push({
      gte: value[0],
      lte: value[1],
      color: 'orange'
    });
  } else {
    option2.value.visualMap.pieces.push({
      gte: value[0],
      lte: value[1],
      color: 'blue'
    });
  }

});
</script>

<template>
  <div>
  spc案例1
  <el-row :gutter="20">
    <el-col :span="11">
      <el-card style="width: 100%">
        <template #header>异常1：存在点落在中心线3σ以外</template>
        <!-- 子组件传值方式: -->
        <ECharts :option=option1></ECharts>
      </el-card>
    </el-col>
    <el-col :span="10">
      <el-card style="width: 100%">
        <template #header>异常2：超过连续9个点在中心线同一侧</template>
        <ECharts :option=option2></ECharts>
      </el-card>
    </el-col>
  </el-row>
</div>
</template>

<style scoped></style>