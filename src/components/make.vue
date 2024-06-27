<template>
    <div>
      <table>
        <th>
        <tr><p>Создай свой пост</p></tr>
        <tr><input type="text" v-model="title" placeholder="Заголовок поста"/></tr>
        <tr><input v-model="body" placeholder="Текст поста" /></tr>
        <tr><button @click="send">Опубликовать пост</button></tr>
    </th>
    </table>
    </div>
  </template>
  
  <script>
  export default {
      name: "makePostComponent",
      data() {
          return {
              title : "",
              body : ""
          }
      },
      methods : {
          send() {
              this.$emit('post-create', {
                  "title": this.title,
                  "body": this.body
              });
              this.$router.push("/");
          }
      }
  }
  </script>
<style>
    div{
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: center;
        align-items: center;

    }
    p{
        margin: 0 auto;
        font-family: Arial, sans-serif;
        font-size: 32px;
        transition: background-color 0.3s; 
        box-sizing: border-box;
        text-align: center;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }
    button{
        width: 70%;
        box-sizing: border-box;
        background-color: #4CAF50;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        font-family: Arial, sans-serif;
        font-size: 16px;
        transition: background-color 0.3s;
    }
    button:hover {
        background-color: #45a049;
    }
    input{
        
        margin:5%;
        align-self: center;
        width: 100%;
        padding: 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        margin-top: 6px;
        margin-bottom: 16px;
        resize: vertical;
        font-family: Arial, sans-serif;
        font-size: 16px;
    }
</style>
