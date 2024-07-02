<template>
    <div v-for="post in this.posts" :key="post">
      <postComponent :post="post"/>
    </div>
  </template>
  
  <script>
  
  import postComponent from '@/components/PostModel.vue';
  
  export default {
      name: "mainComponent",
      components: {
          postComponent
      },
      props: {
          posts: []
      }
  }
  
  </script>
