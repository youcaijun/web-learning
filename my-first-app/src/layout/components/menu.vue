<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';


import { useRoute } from 'vue-router';

const route = useRoute();

</script>

<template>
    <!-- :default-active="route.path" 用于使当前被选中的处于激活状态-->
    <!-- :router="true 用于再index中直接激活路由即可跳转-->
    <el-menu :default-active="route.path" :router="true">
        <el-menu-item index="/main">主要预览</el-menu-item>
        <el-sub-menu index="1">
            <template #title><span>基础案例</span></template>
            <el-menu-item index="/labelCase">表单案例</el-menu-item>
            <el-menu-item index="/ButtonCase">按钮案例</el-menu-item>
            <el-menu-item index="/PiniaCase">Pinia案例</el-menu-item>
            <el-menu-item index="/tableCase">表格案例</el-menu-item>
            <el-menu-item index="/dialogCase">弹窗案例</el-menu-item>
            <!-- <el-menu-item index="/labelReport">基础表单</el-menu-item> -->
        </el-sub-menu>
        <el-sub-menu index="2">
            <template #title><span>可视化案例</span></template>
            <el-menu-item index="/konvaCase1">Konva案例1</el-menu-item>
            <el-menu-item index="/spcCase1">spc案例1</el-menu-item>
            <el-menu-item index="/spcCase2">spc案例2</el-menu-item>
        </el-sub-menu>
        <el-sub-menu index="3">
            <template #title><span>其他案例</span></template>
            <el-menu-item index="1-2">跳转404</el-menu-item>
        </el-sub-menu>
    </el-menu>
</template>

<style scoped></style>