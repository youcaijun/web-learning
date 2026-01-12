<script setup>
import { userinfoStore } from '@/stores/store.js';
import { reactive, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';

// 使用 Pinia 存储
const userinfo = userinfoStore();
//存路由信息
const router = useRouter();
const loginForm = reactive({
	name: '',
	password: '',
});

// 登录
const login = () => {
		//存用户信息
		userinfo.setname(loginForm.name);
		//userinfo.setroles('admin');
		if(loginForm.name=='admin'){
			userinfo.setroles('admin');
		} else{
			userinfo.setroles('user');
		}
		console.log(userinfo);
		userinfo.settoken(loginForm.password + '_token');
		router.push({ path: '/main' });
}
</script>

<template>
	<el-form :model="loginForm">
		<h3 class="title">系统登录</h3>
		<el-form-item>
			<el-input type="text" v-model="loginForm.name" auto-complete="off" placeholder="账号"></el-input>
		</el-form-item>
		<el-form-item>
			<el-input type="password" v-model="loginForm.password" @keyup.enter="login()" auto-complete="off" placeholder="密码"></el-input>
		</el-form-item>
		<!-- <el-checkbox v-model="checked" checked class="remember">记住密码</el-checkbox> -->
		<el-form-item style="width:100%;">
			<!-- <el-button type="primary">重 置</el-button> -->
			<el-button type="primary"  @click="login()">登 录</el-button>
		</el-form-item>
	</el-form>
</template>

<style scoped>
.el-form {
	width: 400px;
	margin: 100px auto;
	padding: 30px 20px;
	border: 1px solid #eee;
	border-radius: 4px;
	box-shadow: 0 2px 12px 0 rgba(0, 0, 0, .1);
}
</style>