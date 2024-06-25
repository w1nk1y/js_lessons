<template>
  <input type="number" v-model="number"/>
  <table-component :inputNumber="number"/>
  
</template>

<script>
import tableComponent from '@/components/HelloWorld.vue';

export default {
  name: 'App',
  components: {
    tableComponent
  },
  data(){
    return {
      number:0,
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
