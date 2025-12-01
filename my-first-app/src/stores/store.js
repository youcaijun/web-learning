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

export const menuStore = defineStore('menuStore', {
    // 状态
    state: () => ({
        tabs: ref([]),
    }),
    // 方法
    actions: {
        add(newtabs) {
            console.log(newtabs);
            if(this.tabs.indexOf(newtabs) !== -1) {
                return; // 如果已存在，则不添加
            }
            this.tabs.push(newtabs);
        }
    },
    // 数据持久化,true表示全部持久化，false表示不持久化，清理浏览器数据后失效
    persist: false,
});

