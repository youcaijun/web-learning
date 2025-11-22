import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
//导入 ElementPlus 组件库中的所有图标
import * as ElementPlusIconsVue from '@element-plus/icons-vue'
import 'element-plus/theme-chalk/dark/css-vars.css'
import router from './router'
//导入echarts
import * as echarts from 'echarts';


/**大小写不一样也会报错 */
const app = createApp(App);
//注册 ElementPlus 组件库中的所有图标到全局 Vue 应用中
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}

app.config.globalProperties.$echarts = echarts;

/**引用elementPlus,并使用暗黑模式 */
app.use(ElementPlus, {
  el: {
    elMessage: {
      color: '#fff' // 设置消息框文字颜色为白色，适应暗黑模式
    }
  }
});
/**引用路由机制 */
app.use(router);
app.mount('#app');
