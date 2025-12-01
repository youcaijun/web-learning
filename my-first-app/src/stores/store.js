import { defineStore } from 'pinia'
import { ref } from 'vue'

export const listStore = defineStore('listStore', {
    // 状态
    state: () => ({
        str: ref('Hello Pinia'),
    }),
    // 方法
    actions: {
        updateStr(newStr) {
            this.str = newStr;
        }
    },
    // 数据持久化,true表示全部持久化，false表示不持久化，清理浏览器数据后失效
    persist: false,
}); 


