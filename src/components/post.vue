<template>
    <div>
    <router-link :to="{ name: 'show', params: { id: this.post.id } }">
       
        <p class="postnumb">Пост номер {{ this.post.id }}</p>
        <h2 v-if="$route.path === '/'" >{{  subtract (this.post.title, 25) }}</h2>
        
        <h2 v-else >{{ this.post.title }}</h2>

        <p v-if="$route.path === '/'"  >{{ subtract ( this.post.body, 35) }}</p>
        <p v-else >{{this.post.body }}</p>
         
    </router-link>
</div>
</template>

<script>
export default {
    name: "postComponent",
    props: {
        post: {}
    },
    methods: {
    
    subtract    (text, stop, clamp) {
        
      return text.slice(0, stop) + (stop < text.length ? clamp || '...' : '')
    }
}
}
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