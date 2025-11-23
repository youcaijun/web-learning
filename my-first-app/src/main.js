import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
//导入 ElementPlus 组件库中的所有图标
import * as ElementPlusIconsVue from '@element-plus/icons-vue';
import 'element-plus/theme-chalk/dark/css-vars.css';
import router from './router';
//导入echarts
import * as echarts from 'echarts';
//导入pinia
import { createPinia } from 'pinia';


/**大小写不一样也会报错 */
const app = createApp(App);
//注册 ElementPlus 组件库中的所有图标到全局 Vue 应用中
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}

//将 echarts 挂载到全局属性中
app.config.globalProperties.$echarts = echarts;

const pinia = createPinia();


/**引用elementPlus */
app.use(ElementPlus);
/**引用路由机制 */
app.use(router);
/**引用pinia状态管理 */
app.use(pinia);
app.mount('#app');
