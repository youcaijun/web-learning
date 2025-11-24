<script setup>
import { ElContainer, ElHeader, ElAside, ElMain, ElFooter } from 'element-plus';
import Vmenu from '@/layout/components/menu.vue';
</script>

<template>
  <div class="common-layout">
    <el-container class="wrapper">
      <el-header>Header

      </el-header>
      <el-container>
        <el-aside class="aside">
          <!-- 菜单 -->
          <Vmenu></Vmenu>
        </el-aside>
        <el-main>
          <!--使用router才能访问-->
          <router-view></router-view>
        </el-main>
      </el-container>
    </el-container>
    <el-footer class="footer">Footer</el-footer>
  </div>
  
</template>

<style scoped>
/* 确保footer在底部 */
.common-layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh; /* 确保容器至少占据整个视口的高度 */
}

.aside {
  width: 10%;
  background: #dc6262;
}

.footer {
  background: #333;
  color: white;
  padding: 20px;
  text-align: center;
  margin-top: auto;
}
</style>
