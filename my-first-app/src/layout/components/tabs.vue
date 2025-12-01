<script setup>
import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router';
import { menuStore } from '@/stores/store.js';
//存路由信息
const route = useRoute();
const router = useRouter();
console.log(route);
//存菜单信息
const menu = menuStore();
//打开的tabs
const opentabs = ref({
    name:  '/main',
    path: '/main'
});
//当前的标签页
const activetab = ref(route.path);

const clickTab = () => {
    router.push({ path: this.activetabs })
    console.log(this.$route.path)
}

// watch(opentabs,(router.path) =>()=> {
//     opentabs.push({
//         name: route.path,
//         path: route.path
//     });
//     console.log("watch:"+opentabs);
// }, { deep: true });

const removeTab = (target) => {
    router.push({ path: this.activetabs })
    console.log(this.$route.path)
}
// },
// removeTab(target) {
// 	if (target == '/main') {
// 		return
// 	}
// 	this.delete_tabs(target)
// 	if (this.activeIndex === target) {
// 		if (this.openTab && this.openTab.length >= 1) {
// 			console.log('=============', this.openTab[this.openTab.length - 1].route)
// 			this.set_active_index(this.openTab[this.openTab.length - 1].route)
// 			this.$router.push({ path: this.activeIndex })
// 		}
// 	}
// }

</script>

<template>
    {{ route.path }}
    <el-tabs v-model="activetab" type="card" editable class="demo-tabs" @tab-click="clickTab" closable>
        <el-tab-pane v-for="item in opentabs" :key="item.name" :label="item.path" :name="item.name">
            {{ route.path }}
            <router-view></router-view>
        </el-tab-pane>

    </el-tabs>
</template>

<style scoped></style>