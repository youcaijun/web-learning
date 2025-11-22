// src/utils/api.js
import apiClient from '@/utils/axios.js';
// 封装一个获取用户信息的 API 方法


export const apiUtils = {
    get: async (message) => {
        var url = '/api/error'
        if (message && message.length > 0) {
            url = '/api/echo?' + 'message=' + encodeURIComponent(message);
        } else {
            url = '/api/echo';
        }
        let value = await apiClient.get(url);
        console.log("value=" + value.data);
        return value;
    }
}


export const redisUtils = {
    get: async (key) => {
        var url = '';
        if (key && key.length > 0) {
            url = '/redis/get?' + 'key=' + encodeURIComponent(key);
        } else {
            return null;
        }
        let value = await apiClient.get(url);
        console.log("value=" + value.data);
        return value;
    },
    /**
     * 
     *  data: {
     *  key: "yourKey",
     *  value: "yourValue"
     * }
     */
    set: async (data) => {
        var url = '/redis/set';
        let value = await apiClient.post(url, { key: data.key, value: data.value });
        console.log("value=" + value.data);
        return value;
    },
    /**
     * 
     *  data: {
     *  pattern: "yourKey",
     * }
     */
    scan: async (data) => {
        var url = '/redis/scan';
        let value = await apiClient.post(url, { pattern: data.pattern });
        console.log("value=" + value.data);
        return value;
    }
}