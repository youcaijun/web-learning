<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';

</script>

<template>
    <el-menu :router="true">
        <el-menu-item index="/main">主要预览</el-menu-item>
        <el-sub-menu index="1">
            <template #title><span>基础案例</span></template>
            <el-menu-item index="/labelCase">查询案例</el-menu-item>
            <el-menu-item index="/ButtonCase">按钮案例</el-menu-item>
            <el-menu-item index="/PiniaCase">Pinia案例</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="2">
            <template #title><span>表单案例</span></template>
            <el-menu-item index="/labelReport">基础表单</el-menu-item>
            <el-menu-item index="1-2">待用</el-menu-item>
        </el-sub-menu>
    </el-menu>
</template>

<style scoped>
</style>