<script setup>
import ECharts from '@/components/echarts.vue';

import { listStore } from '@/stores/store.js';

// 使用 Pinia 存储
const list = listStore();
</script>

<template>

    <h1>主要预览</h1>

    {{ list.str }}
    <el-row :gutter="20">
        <el-col :span="12">
            <el-card style="width: 100%">
                <template #header>示例</template>
                <ECharts></ECharts>
            </el-card>
        </el-col>
    </el-row>
</template>

<style scoped></style>