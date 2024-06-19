<template>
  <div>
    <button @click="plusOne">Увеличить значения на 1</button>
    <table>
      <tr>
        <th v-for="num in numbers" :key="num">{{ num }}</th>
      </tr>
      <tr>
        <td v-for="num in numbers" :key="num">{{ num*inputNumber }}</td> 
      </tr>
    </table>
    <button @click="maximum">Найти максимальное значение множителей</button>
    <p>{{ m }}</p>
  </div>
</template>

<script>

export default{
name:"table-component",
data(){
  return{
    numbers : [1,2,3,4,5,6,7,8,9,10],
    m:0,
}
},
props:{
  inputNumber:Number
},
methods:{
  plusOne(){
    for(let i = 0; i<10; i++){
      this.numbers[i]++;
    }
  },
  maximum(){
    for(let i = 0; i<=10; i++){
      if (this.numbers[i]>this.m){
        this.m=this.numbers[i];
      }
    }
  }
}
}
</script>

<style>
  table{
    width: 50%;
    margin: auto;
  }
  th{
    
    border: solid black;
    width: 5%;
    height: 5%;
    border-radius: 10%;
    border-width: 5%;
    align-items: center;
  }
  button{
    margin:2%;
    padding:2%;
    border-radius: 10%;
    border-width: 5%;
    align-self: center;
  }
  div{
    padding:2%;
    border-radius: 10%;
    border-width: 5%;
    align-self: center;
  }
</style>
