<script setup>
import { ElContainer, ElHeader, ElAside, ElMain, ElFooter } from 'element-plus';
import Vmenu from '@/components/menu.vue';
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
          <el-main>
            <!--使用router才能访问-->
            <router-view></router-view>
          </el-main>
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
