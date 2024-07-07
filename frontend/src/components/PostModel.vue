<template>
    <div>
        <router-link :to="{ name: 'show', params: { id: this.post.id } }">

       
        <p class="postnumb">Пост номер {{ this.post.id }}</p>
        <h2 v-if="this.$route.path === '/'" >{{  this.post.title }}</h2>
        
        <h2 v-else >{{ this.post.title }}</h2>

        <p v-if="this.$route.path === '/'"  > {{ this.post.body ? hideBody : '' }}</p>
        <p v-else >{{this.post.body }}</p>
         
    </router-link>
</div>
</template>

<script>


export default {
  name: "postComponent",
  
  props: {
    post:Object,
  
  },
  computed: {
        hideBody() {
            return this.post.body.length > 30 && !this.$route.path.startsWith('/post/') ? this.post.body.slice(0, 30) + '...' : this.post.body
        }
    },
    
  
};
</script>

  
<style>
 
    div{  
             
        margin-bottom: 30px;
        padding: 20px;
        box-sizing: border-box;
    }
    h2{
        margin: 0 0 10px;
        font-size: 18px;
        font-weight: bold;
        color: #333; 
    }
    p{
        margin: 0;
        font-size: 16px;
        color: #666;  
    }
    .postnumb{
        color:#4CAF50
    }
</style>