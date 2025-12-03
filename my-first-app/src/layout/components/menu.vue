<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';

<<<<<<< HEAD
 import { menuStore } from '@/stores/store.js';
=======
>>>>>>> parent of 0df96d2 (1)

import { useRoute } from 'vue-router';

const route = useRoute();

const menu = menuStore();

//点击后处理
const handleclick = (index, indexPath) => {
    menu.add(index);
    //console.log(index);
    // 可以在这里处理菜单点击事件
    // 例如，导航到不同的路由
}
</script>

<template>
    <!-- :default-active="route.path" 用于使当前被选中的处于激活状态-->
    <!-- :router="true 用于再index中直接激活路由即可跳转-->
    <el-menu :default-active="route.path" :router="true" @select="handleclick">
        <el-menu-item index="/main">主要预览</el-menu-item>
        <el-sub-menu index="1">
            <template #title><span>基础案例</span></template>
            <el-menu-item index="/labelCase" >查询案例</el-menu-item>
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

<style scoped></style>