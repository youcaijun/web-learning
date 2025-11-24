<script setup>
import { reactive, ref } from 'vue';
import { redisUtils } from '@/utils/api';

// 定义表单数据
const form = reactive({
	name: '',
})

const data = reactive({
	name: '',
	type: '',

})


//重置
const onReset = () => {
	form.name = ''
	data.name = ''
	data.type = ''
}
// 保存
const onSave = () => {
	if (!data.name) {
		return
	}
	redisUtils.set({ key: 'label:' + data.name, value: JSON.stringify(data) }).then(res => {
		if (res) {
			alert('保存成功')
		} else {
			alert('保存失败')
		}
	})
}
// 查询
const onQuery = (name) => {
	redisUtils.get('label:'+name).then(res => {
		if (res) {
			data.name = res.data.name
			data.type = res.data.type
		} else {
			data.name = ''
			data.type = ''
		}
	})
}

</script>

<template>

	<el-text class="mx-1" size="large">基础表单</el-text>

	<el-form :inline="true" :model="form" label-width="auto" >
		<el-form-item label="名称:">
			<el-input v-model="form.name" />
		</el-form-item>
		<el-form-item>
			<el-button type="primary" @click="onQuery(form.name)">查询</el-button>
		</el-form-item>
		<el-form-item>
			<el-button type="primary" @click="onReset()">清空</el-button>
		</el-form-item>

	</el-form>

	<el-form :inline="true" :model="form" label-width="auto">
		<el-form-item label="名称:">
			<el-input v-model="data.name" />
		</el-form-item>
			<el-form-item label="行业:">
			<el-input v-model="data.type" />
		</el-form-item>
		
	//

	</el-form>

</template>

<style scoped>
.el-input {
	--el-input-width: 200px;
}

.el-form {
	max-width: 600px;
	padding: 20px;
	border: 1px solid #1f2942;
	border-radius: var(--el-border-radius-round);
	
	
	margin: 20px;
}

.el-text {
	padding: 20px;
}
</style>
