import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
//导入 ElementPlus 组件库中的所有图标
import * as ElementPlusIconsVue from '@element-plus/icons-vue';
import 'element-plus/theme-chalk/dark/css-vars.css';
//导入echarts
import * as echarts from 'echarts';
/**大小写不一样也会报错 */
const app = createApp(App);
//注册 ElementPlus 组件库中的所有图标到全局 Vue 应用中
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}
//将 echarts 挂载到全局属性中
app.config.globalProperties.$echarts = echarts;
/**引用elementPlus */
app.use(ElementPlus);
app.mount('#app');
