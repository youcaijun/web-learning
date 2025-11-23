<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';

</script>

<template>
    菜单
    <el-menu :router="true">
        <el-menu-item index="/main">主要预览</el-menu-item>
        <el-sub-menu index="1">
            <template #title><span>基本配置</span></template>
            <el-menu-item index="/label">标的配置</el-menu-item>
            <el-menu-item index="1-2">参数配置</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="2">
            <template #title><span>报表查询</span></template>
            <el-menu-item index="/labelReport">标的报表</el-menu-item>
            <el-menu-item index="1-2">待用</el-menu-item>
        </el-sub-menu>
        <el-menu-item index="/Button">系统维护</el-menu-item>
    </el-menu>
</template>

<style scoped></style>