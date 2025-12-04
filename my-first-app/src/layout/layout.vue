<script setup>
import { ElContainer, ElHeader, ElAside, ElMain, ElFooter } from 'element-plus';
import { useRoute, useRouter } from 'vue-router';
import Vmenu from '@/layout/components/menu.vue';

import Vtabs from '@/layout/components/tabs.vue';

import { userinfoStore } from '@/stores/store.js';


 // 使用 Pinia 存储
const userinfo = userinfoStore();
const router = useRouter();


const handleCommand = (command) => {
  console.log(command);
  //通过不同的command执行不同的操作
  if (command === 'logout') {
    //清除用户信息
    userinfo.setname('');
    userinfo.settoken('');
    router.push({ path: '/login' });
  }
  if  (command === 'info') {
    alert('用户信息');
  }
}
</script>

<template>
  <div class="common-layout">
    <el-container class="wrapper">
      <el-header>
        <div>图片</div>
        <div>用户名:{{userinfo.name}} token:{{userinfo.token}}</div>
        <!-- 通过指令去执行对应的事件-->
        <el-dropdown  @command="handleCommand">
          <!-- 改一下字体颜色 -->
          <div style="color: #fff;">头像</div>
          
          <template #dropdown>
            <el-dropdown-menu >
              <el-dropdown-item command="info">用户信息</el-dropdown-item>
              <el-dropdown-item disabled>不可选中</el-dropdown-item>
              <el-dropdown-item divided command="logout">退出登录</el-dropdown-item>
            </el-dropdown-menu>
          </template>
        </el-dropdown>
      </el-header>
      <el-container>
        <el-aside>
          <!-- 菜单 -->
          <Vmenu></Vmenu>
        </el-aside>
        <el-main>
          <Vtabs></Vtabs>
          <!--使用router才能访问-->
        </el-main>
      </el-container>
    </el-container>
    <el-footer>Footer</el-footer>
  </div>
</template>

<style scoped>
/* 样式部分 */
/* 确保header内容左右分布 */
.el-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: #373d41;
  color: #fff;
}

/* 确保footer在底部 */
.common-layout {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  /* 确保容器至少占据整个视口的高度 */
}

.el-aside {
  width: 10%;
  text-align: center;
  border: 1px solid #1f2942;
}

.el-footer {
  height: 50px;
  background: #333;
  color: white;
  padding: 20px;
  text-align: center;
  margin-top: auto;
}
</style>
