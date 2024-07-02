<template>
  <nav>
   <p><router-link to="/">Главная</router-link> </p>
   <p><router-link to="/post/create">Создать</router-link></p>
  </nav>
  <router-view @post-create="NewPostCreated" :posts="posts" :id="$route.params.id"/>
</template>

<script>


import axios from "axios";

export default {
  name: 'App',

  data() {
    return {
      posts: []
    }
  },
  async created() {
    this.posts = (await axios.get('https://localhost:7243/api/Posts')).data;

  },

  methods: {
  NewPostCreated(data) {
    this.posts.unshift({
      "user_id": this.posts.at(0).user_id,
      "id": this.posts.at(0).id - 1,
      "title": data.title,
      "body": data.body
    });
  }
}
 
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
