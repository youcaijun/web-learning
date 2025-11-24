import { defineStore } from 'pinia'
import { ref } from 'vue'

export  const listStore = defineStore ( 'listStore',{
    // 状态
    state: () => ({
        str:ref('Hello Pinia'),
    }),
    // 方法
    actions: {
        updateStr(newStr) {
            this.str = newStr;
        }
    },
});
