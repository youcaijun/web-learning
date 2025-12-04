import { defineStore } from 'pinia'
import { ref } from 'vue'

// pinia 测试案例
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

// 记录登录用户信息

export const userinfoStore = defineStore('userinfoStore', {
    state: () => ({
        //用户名
        name: ref(''),
        //用户角色
        roles: ref({}),
        //用户token,校验登录用，后续会存
        token: ref(''),
    }),
    // 方法
    actions: {
        setname(name) {
            this.name = name;
        },
        setroles(roles) {
            this.roles = roles;
        },
        settoken(token) {
            this.token = token;
        }
    },
    // 数据持久化,true表示全部持久化
    persist: true,
});

