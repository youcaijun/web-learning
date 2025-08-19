import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import ElemetPlus from 'element-plus'
import 'element-plus/dist/index.css'
// import router from './router'

/**大小写不一样也会报错 */
const app= createApp(App);
/**引用elementPlus */
app.use(ElemetPlus);
/**引用路由机制 */
// app.use(router);
app.mount('#app');
