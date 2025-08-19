<script setup>
import HelloWorld from './components/HelloWorld.vue';
import vModel from './views/v-model.vue';
import VShow from './views/v-show.vue';
import VFor from './views/v-for.vue';
</script>


<template>

  <HelloWorld msg="HelloWorld" />
  <!--v-model与插值绑定-->
  <h4>1. v-model与插值绑定</h4>
  <vModel />
  <h4>2. v-show</h4>
  <VShow  />
  <h4>3. v-for</h4>
  <VFor  />

</template>





















<!-- <template>
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <HelloWorld msg="Vite + Vue 445566" />
</template>
-->
<!--
<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style> -->
