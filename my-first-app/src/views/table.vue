<script setup>

import { reactive, ref } from 'vue';

// 表格数据,可以从后端获取
const tableData = [
	{
		id: 1,
		name: '张一',
		date: '1990-01-01'
	},
	{
		id: 2,
		name: '张二',
		date: '1990-01-02'
	},
	{
		id: 3,
		name: '张三',
		date: '1990-01-03'
	},
	{
		id: 4,
		name: '张四',
		date: '1990-01-04'
	},
	{
		id: 5,
		name: '张五',
		date: '1990-01-05'
	},
	{
		id: 6,
		name: '李一',
		date: '1990-01-06'
	},
	{
		id: 7,
		name: '李二',
		date: '1990-01-08'
	},
	{
		id: 8,
		name: '李三',
		date: '1990-01-09'
	},
	{
		id: 9,
		name: '李四',
		date: '1990-01-09'
	},
	{
		id: 10,
		name: '李五',
		date: '1990-01-09'
	},
	{
		id: 11,
		name: '钱一',
		date: '1990-01-10'
	},
	{
		id: 12,
		name: '钱二',
		date: '1990-01-11'
	},
	{
		id: 13,
		name: '钱三',
		date: '1990-01-12'
	},
	{
		id: 14,
		name: '钱四',
		date: '1990-01-13'
	},
	{
		id: 15,
		name: '钱五',
		date: '1990-01-14'
	},
]
// 分页相关的参数与函数
const currentPage = ref(1);
const pageSizes = ref(5);
const handleSizeChange = (val) => {
	pageSizes.value = val;
};
const handleCurrentChange = (val) => {
	currentPage.value=val;
	
};

//用于动态分页表格
const currentPageDate = (tableData) => {
	const start = (currentPage.value - 1) * pageSizes.value;
	const end = currentPage.value * pageSizes.value;
	return tableData.slice(start, end);
};
</script>

<template>
	表格示例
	<el-table :data="currentPageDate(tableData)" height="250" style="width: 100%">
		<el-table-column prop="id" label="id" width="180" />
		<el-table-column prop="name" label="Name" width="180" />
		<el-table-column prop="date" label="date" />
		   
	</el-table>
	<el-pagination 
		@size-change="handleSizeChange" 
		@current-change="handleCurrentChange"
		:current-page="currentPage"
		:default-page-size="5"
		:page-sizes="[5, 10, 15, 20]"
		layout="total,sizes,prev, pager, next"
		:total="tableData.length">
	</el-pagination>
</template>

<style scoped></style>