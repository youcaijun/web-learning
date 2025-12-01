<script setup>
import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router';
//存路由信息
const route = useRoute();
const router = useRouter();
//存菜单信息
//打开的tabs
const opentabs = ref([{
    name: '/main',
    path: '/main'
}]);
//当前的标签页
const activetab = ref('/main');

// 监听路由变化
watch(() => route.path, val => {
    //检查是否已经存在该tab
    const exists = opentabs.value.find(tab => tab.path === val);
    if (!exists) {
        opentabs.value.push({
            name: val,
            path: val
        });
    }
    activetab.value = val;
}
);

//绑定在tab-change事件上，绑定在单击事件上会需要点两次
const clickTabchange = () => {
    router.push({ path: activetab.value });
}


//关闭tab
const removeTab = (target) => {
    console.log("removeTab:" + target);
    //主页不让删
    if (target == '/main') {
        return
    }
    const index = opentabs.value.findIndex(tab => tab.name === target);
    if (index !== -1) {
        opentabs.value.splice(index, 1);
    }
    //如果删的是当前页，跳转到最后一个
    if (activetab.value === target) {
        if (opentabs.value.length > 0) {
            const lastTab = opentabs.value[opentabs.value.length - 1];
            activetab.value = lastTab.name;
            router.push({ path: lastTab.path });
        }
    }
}

</script>

<template>
    <!-- router：{{route.path}}<br>
    tab:{{activetab}} -->
    <el-tabs v-model="activetab" type="card"  class="demo-tabs" @tab-change="clickTabchange"
        @tab-remove="removeTab" closable>
        <el-tab-pane v-for="item in opentabs" :key="item.name" :label="item.path" :name="item.name">
            <router-view></router-view>
        </el-tab-pane>
    </el-tabs>
</template>

<style scoped></style>