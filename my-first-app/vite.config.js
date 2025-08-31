import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    port: 8080, // 自己规定的端口号
  },
  resolve: {
    alias: { //配置路径别名
      '@': path.resolve(__dirname, 'src')
    }
  }
})


