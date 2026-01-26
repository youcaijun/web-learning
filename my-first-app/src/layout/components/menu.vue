<script setup>
import { ElMenu, ElMenuItem } from 'element-plus';
import { userinfoStore } from '@/stores/store.js';

import { useRoute } from 'vue-router';
import { reactive } from 'vue';
const userinfo = userinfoStore();


const route = useRoute();
const menu = reactive([]);

//菜单数据,根据后端返回的权限路由数据动态生成菜单,模拟权限控制
console.log('当前用户角色:', userinfo.roles.list.length);
if (userinfo.roles.list.length == undefined || userinfo.roles.list.length == 0) {
    console.log('当前用户无角色');
     menu.push({
        name: "主要预览",
        index: "/myapp/main"
    });
} else {
if (userinfo.roles.list.includes('admin')) {
    console.log('当前用户是admin角色');
    menu.push({
        name: "主要预览",
        index: "/myapp/main"
    }, {
        name: "基础案例",
        index: "1",
        children: [{
            name: "表单案例",
            index: "/myapp/labelCase"
        }, {
            name: "按钮案例",
            index: "/myapp/ButtonCase"
        }, {
            name: "Pinia案例",
            index: "/myapp/PiniaCase"
        }, {
            name: "表格案例",
            index: "/myapp/tableCase"
        }, {
            name: "弹窗案例",
            index: "/myapp/dialogCase"
        }]
    },
        {
            name: "可视化案例",
            index: "2",
            children: [{
                name: "Konva案例1",
                index: "/myapp/konvaCase1"
            },
            {
                name: "Konva案例2",
                index: "/myapp/konvaCase2"
            }, {
                name: "spc案例1",
                index: "/myapp/spcCase1"
            }, {
                name: "spc案例2",
                index: "/myapp/spcCase2"
            }]
        },
        {
            name: "其他案例",
            index: "3",
            children: [{
                name: "跳转404",
                index: "1-2"
            }]
        },
        {
            name: "权限案例",
            index: "4",
            children: [{
                name: "跳转404",
                index: "1-2",
            }, {
                name: "无权限",
                index: "1-3",
            }]
        });
} else {
    console.log('当前用户不是admin角色');
    menu.push({
        name: "主要预览",
        index: "/myapp/main"
    }, {
        name: "基础案例",
        index: "1",
        children: [{
            name: "表单案例",
            index: "/myapp/labelCase"
        }, {
            name: "按钮案例",
            index: "/myapp/ButtonCase"
        }, {
            name: "Pinia案例",
            index: "/myapp/PiniaCase"
        }, {
            name: "表格案例",
            index: "/myapp/tableCase"
        }, {
            name: "弹窗案例",
            index: "/myapp/dialogCase"
        }]
    },
        {
            name: "可视化案例",
            index: "2",
            children: [{
                name: "Konva案例1",
                index: "/myapp/konvaCase1"
            }, {
                name: "spc案例1",
                index: "/myapp/spcCase1"
            }, {
                name: "spc案例2",
                index: "/myapp/spcCase2"
            }]
        });
}
}
</script>

<template>
    <!-- :default-active="route.path" 用于使当前被选中的处于激活状态-->
    <!-- :router="true 用于再index中直接激活路由即可跳转-->
    <el-menu :default-active="route.path" :router="true">
        <template v-for="(item, index) in menu" :key="index">
            <el-sub-menu v-if="item.children && item.children.length > 0" :index="item.index">
                <template #title>{{ item.name }}</template>
                <el-menu-item v-for="(child, cIndex) in item.children" :key="cIndex" :index="child.index">
                    {{ child.name }}
                </el-menu-item>
            </el-sub-menu>
            <el-menu-item v-else :index="item.index">
                {{ item.name }}
            </el-menu-item>
        </template>
    </el-menu>
</template>

<style scoped></style>