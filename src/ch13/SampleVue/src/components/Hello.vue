<script setup lang="ts">
import { ref } from "vue";

type Address = {
  id: number
  name: string
}
type Person = {
  id: number
  name: string
  address: Address | null
  age: number
}

const items = ref([{}] as Person[])

fetch("https://localhost:5001/api/People")
.then( async res => {
  let json = await res.json()
  items.value = json 
})


</script>

<template>
  <h1>HELLO vue.js & ASP.NET Core</h1>
  <div>
    <table class="table">
      <thead>
        <tr>
          <th>id</th>
          <th>name</th>
          <th>address</th>
          <th>age</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{  item.id  }}</td>
          <td>{{  item.name  }}</td>
          <td>{{  item.address?.name  }}</td>
          <td>{{  item.age  }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
