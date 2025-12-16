<script setup>
import { onMounted, ref, onUnmounted} from 'vue';
import * as echarts from 'echarts';

const chartRef = ref(null);
let chartInstance = null;

const props = defineProps({
  option: Object
});
// 初始化图表,加载dom后挂载图表
onMounted(() => {
  if (chartRef.value) {
    chartInstance = echarts.init(chartRef.value);
    // 没有传入option则使用默认配置
    if(props.option == undefined){
      const option = {
      title: {
        text: 'ECharts 示例'
      },
      tooltip: {},
      xAxis: {
        data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
      },
      yAxis: {},
      series: [{
        name: '销量',
        type: 'bar',
        data: [5, 20, 36, 10, 10, 20]
      }]
    };
    chartInstance.setOption(option);
    } else {
      chartInstance.setOption(props.option);
    }
  }
});

onUnmounted(() => {
  if (chartInstance !== null && chartInstance !== undefined) {
    chartInstance.dispose(); // 销毁实例，释放资源
  }
});
</script>

<template>
  <div ref="chartRef" style="width: 100%; height: 400px;"></div>
</template>
