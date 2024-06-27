<template>
    <div v-for="post in this.posts.filter(p => p.id == this.id)" :key="post">
      <postComponent :post="post" :id="this.id"/>
    </div>
  </template>
  
  <script>
  import postComponent from "@/components/post.vue"
  
  export default {
      name: "viewComponent",
      components: {
          postComponent
      },
      props: {
          id: Number,
          posts: []
      },
      
      }
  
  </script>
  
