<template>
    <div>
      <p><postComponent :post="post"/></p>
      <br>
      <span @click="Delete" class="delete-button">Удалить</span>
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
      post: {}
    }
  },
        
  async created() {
      try {
          const response = await axios.get(`https://localhost:7243/api/Posts/${this.$route.params.id}`);
          this.post = response.data;
  } catch (error) {
    console.error(error);
  }
},
methods: {
        async Delete() {
            try {
                await axios.delete("http://localhost:7243/api/Posts/" + this.post.id);
                window.location.reload();
            } catch (error) {
                console.error(error);
            }
        }
    }
}

</script>


