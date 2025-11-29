<script setup>
import { Utils } from '@/utils/utils';
const str = "  你好";
import { apiUtils,redisUtils } from '@/utils/api';
const data= {
        key:"mess",
        value:"hello api"
}

import { useRouter } from 'vue-router'

const router = useRouter();

const goPath = (path) => {
	router.push(path);
}

</script>

<template>
        内容页
        <h3>按钮</h3>
        <el-button @click="Utils.hello('')">默认按钮</el-button>
        <el-button type="primary" @click="apiUtils.get('mess')">主要按钮</el-button>
        <el-button type="success"@click="apiUtils.get()">成功按钮</el-button>
        <el-button type="info" @click="redisUtils.get('name')">信息按钮</el-button>
        <el-button type="warning"@click="redisUtils.set(data)">警告按钮</el-button>
        <el-button type="danger"@click="redisUtils.get('mess')">危险按钮</el-button>
        <el-button type="primary" @click="goPath('/main')">回到首页</el-button>
        <hr>
        <h3>按钮属性</h3>
        <el-button plain>朴素按钮</el-button>
        <el-button round>圆角按钮</el-button>
        <el-button circle>圆</el-button>
        <el-button disabled>禁用按钮</el-button>
        <el-button loading>加载中</el-button>

        <hr>
        <h3>尺寸</h3>
        <el-button size="large">大型按钮</el-button>
        <el-button>默认按钮</el-button>
        <el-button size="small">小型按钮</el-button>
</template>

<style scoped></style>