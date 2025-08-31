<script setup>
import { ElContainer, ElHeader, ElAside, ElMain, ElFooter } from 'element-plus';
import Vmenu from '@/components/menu.vue';

const views="main";
</script>

<template>
  <div class="common-layout">
    <el-container>
      <el-header>Header</el-header>
        <el-container>
          <el-aside class="aside">
            <!-- menu组件树 -->
            <Vmenu></Vmenu>
          </el-aside>
          <el-main>{{ views }}</el-main>
        </el-container>
        <el-footer>Footer</el-footer>
    </el-container>
  </div>
</template>

<style scoped>
.aside {
  width: 15%;
}
</style>
