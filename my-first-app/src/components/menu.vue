<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';

const Props = defineProps(
    {
        path:{
            type: String,
            required: true, //true表示必传属性,若未传则会提示警告信息
            default: 'main' //未传默认值
        }
    });
const router = router();
</script>

<template>
    菜单
    {{Props.path}}
    <el-menu>
        <el-menu-item index="1">首页</el-menu-item>
        <el-menu-item index="2">关于</el-menu-item>
        <el-menu-item index="3">联系我们</el-menu-item>
    </el-menu>
</template>

<style scoped></style>