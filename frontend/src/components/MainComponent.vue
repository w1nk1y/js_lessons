<template>
    <div v-for="post in posts" :key="post">
      <postComponent  :post="post"/>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  import postComponent from '@/components/PostModel.vue';
  
  export default {
      name: "mainComponent",
      components: {
          postComponent
      },
      data() {
      return {
        posts: [],
        isLoaded:false
      }
    },
    async created() {
      this.posts = (await axios.get('https://localhost:7243/api/Posts/')).data.reverse();
      this.isLoaded=true;
    }
  }
  
  </script>
