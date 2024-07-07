<template>
    <div>
      <p><postComponent :post="post" :id="$route.params.id"/></p>
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
          post: {
          type: Object,
          
        }
        }
        },
        props: {
        id: Number
    },
        async created() {
  try {
    const response = await axios.get(`https://localhost:7243/api/Posts/${this.id}`);
    this.post = [response.data];
  } catch (error) {
    console.error(error);
  }
}
}

</script>


