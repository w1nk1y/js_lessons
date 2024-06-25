<template>
    <button @click="maximum">Найти максимальное значение множителей</button>
    <p>{{ m }}</p>
</template>
  
  <script>
  
  export default{
  name:"FindMax",
  data(){
    return{
      m:0
  }
  },
  props:{
    figures:Number
    
  },
  methods:{
    maximum(){
      for(let i = 0; i<=10; i++){
        if (this.figures[i]>this.m){
          this.m=this.figures[i];
        }
      }
    }
  }
  }
</script>
  
