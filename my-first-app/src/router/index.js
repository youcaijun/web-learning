import { createRouter, createWebHashHistory, createWebHistory } from "vue-router"


//全局文件中不应该直接引用pinia中的store,否则会引起循环引用的问题
// import { userinfoStore } from '@/stores/store.js';

// const userinfo = userinfoStore();

const routes = [
	{
		path: "/login",
		name: "login",
		component: () => import("@/views/login.vue")
	},
	{
		path: "/", // http://localhost:8080/content
		name: "layout",
		//	component: () => import("@/old/index.vue"),
		component: () => import("@/layout/layout.vue"),
		children: [ // 子路由
			{
				path: '/main',
				component: () => import("@/views/main.vue")
			},
			{
				path: '/PiniaCase',
				component: () => import("@/views/pinia-case.vue")
			},
			{
				path: "/buttonCase",
				component: () => import("@/views/el-button-case.vue")
			},
			{
				path: '/content',
				component: () => import("@/views/content.vue")
			},
			{
				path: "/labelCase",
				component: () => import("@/views/label-case.vue")
			},
			{
				path: "/labelReport",
				component: () => import("@/views/labelReport.vue")
			},
			{
				path: "/tableCase",
				component: () => import("@/views/table-case.vue")
			},
			{
				path: "/dialogCase",
				component: () => import("@/views/dialog-case.vue")
			},
			{
				path: "/konvaCase1",
				component: () => import("@/knova/knova-case1.vue")
			},
			{
				path: "/konvaCase2",
				component: () => import("@/knova/knova-case2.vue")
			},
			{
				path: "/SpcCase1",
				component: () => import("@/knova/spc-case1.vue")
			},
			{
				path: "/SpcCase2",
				component: () => import("@/knova/spc-case2.vue")
			},
		]
	},
	// 404 页面需要放在最后面
	{
		path: '/:pathMatch(.*)*',
		component: () => import('@/layout/components/error/404.vue')
	}

]

const router = createRouter({
	//使用url的#符号之后的部分模拟url路径的变化,因为不会触发页面刷新,所以不需要服务端支持
	//history: createWebHashHistory(), 
	history: createWebHistory(),
	routes
});

//全局路由守卫
router.beforeEach((to, from, next) => {
	//console.log("路由跳转了", to, from);
	//如果访问的不是登录页，则需要验证token
	if (to.path !== '/login') {
		//获取pinia中的userinfoStore
		//console.log("userinfoStore:", userinfo);
		//判断token是否存在
		import('@/stores/store.js').then(({ userinfoStore }) => {
			const userinfo = userinfoStore();
			if (!userinfo.token) {
				//如果token不存在，跳转到登录页
				next({ path: '/login' });
			} else {
				//token存在，放行
				next();
			}
		});
	} else {
		//如果是访问登录页面，则确认是否有登录信息，有则跳主页
		import('@/stores/store.js').then(({ userinfoStore }) => {
			const userinfo = userinfoStore();
			if (userinfo.token) {
				//如果token存在，跳转到主页
				next({ path: '/main' });
			} else {
				//token不存在存在，登录页
				next();
			}
		});
	}
});

export default router
