// src/utils/axios.js
import axios from 'axios';
// 创建 axios 实例
const apiClient = axios.create({
    baseURL: 'http://localhost:8085/app', // 你的 API 基础 URL
    timeout: 10000, // 请求超时时间
});

// 添加请求拦截器
// apiClient.interceptors.request.use(
//     config => {
//         // 在发送请求之前做些什么，例如设置 token
//         const token = localStorage.getItem('token');
//         if (token) {
//             config.headers.Authorization = `Bearer ${token}`;
//         }
//         return config;
//     },
//     error => {
//         // 对请求错误做些什么
//         return Promise.reject(error);
//     }
// );

// 添加响应拦截器
// apiClient.interceptors.response.use(
//     response => {
//         // 对响应数据做点什么
//         return response.data;
//     },
//     error => {
//         // 对响应错误做点什么
//         return Promise.reject(error);
//     }
// );

export default apiClient;