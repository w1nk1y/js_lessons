<template>
  <headerComponent/>
  <router-view/>
</template>

<script>

import headerComponent from '@/components/Header.vue';


export default {
  name: 'App',
  components:{
    headerComponent
  },
}


</script>
<style>
  p{
    display: inline-block;
    padding: 0 20px;
    color: #fff;
    text-decoration: none;
    font-size: 18px;
    line-height: 60px;
    transition: background-color 0.3s;
  }
  nav {
    border-radius: 15%;
    background-color: rgb(202, 249, 197);
    display: flex;
    justify-content: center;
    align-items: center;
    position: relative;
    top: 1%;
    bottom:2%;
    width: 100%;
    height: 100px;
    
}
</style>
