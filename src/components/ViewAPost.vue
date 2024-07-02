<template>
    <div v-for="post in this.posts.filter(p => p.id == this.id)" :key="post">
      <postComponent :post="post" :id="this.id"/>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  import postComponent from "@/components/PostModel.vue"
  
  export default {
      name: "viewComponent",
      components: {
          postComponent
      },
      data() {
        return {
            id: this.$route.params.id,
            posts: []
        }
        },
        async created() {
  try {
    const response = await axios.get(`https://localhost:7243/api/Posts/${this.id}`);
    this.posts = [response.data];
  } catch (error) {
    console.error(error);
    this.posts = [];
  }
}
}

</script>