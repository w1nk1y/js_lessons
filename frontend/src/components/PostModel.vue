<template>
    <div>
        <router-link :to="{ name: 'show', params: { id: post.id } }">

        
        <p class="postnumb">Пост номер {{ post.id }}</p>
        <h2 v-if="$route.path === '/'" >{{  post.title }}</h2>
        
        <h2 v-else >{{ post.title }}</h2>

        <p style="display:inline-block;width:1000px;" v-if="$route.path === '/'"  > {{ post.body}}</p>
        <p v-else >{{post.body }}</p>
         
    </router-link>
</div>
</template>

<script>


export default {
  name: "postComponent",
  props: {
    post:{},
  },
  computed:{
    postID(){
        return this.post.id;
  }
}
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