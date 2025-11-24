import { createRouter, createWebHashHistory, createWebHistory } from "vue-router"

const routes = [
	// {
	// 	path: "/button", // http://localhost:8080/
	// 	name: "Button",
	// 	component: () => import("@/views/el-button.vue")
	// },
	// {
	// 	path: "/content", // http://localhost:8080/content
	// 	name: "Content",
	// 	component: () => import("@/views/content.vue")
	// },
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


		]
	}
]

const router = createRouter({
	//使用url的#符号之后的部分模拟url路径的变化,因为不会触发页面刷新,所以不需要服务端支持
	//history: createWebHashHistory(), 
	history: createWebHistory(),
	routes
})

export default router
