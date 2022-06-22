<template>
  <div>
    <h1 id="tabelLabel">Weather forecast</h1>
    <p>This component demonstrates fetching data from the server.</p>
    <p v-if="loading"><em>Loading...</em></p>
    <table v-else className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Date</th>
          <th>Temp. (C)</th>
          <th>Temp. (F)</th>
          <th>Summary</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="forecast in forecasts" :key="forecast.date">
          <td>{{forecast.date}}</td>
          <td>{{forecast.temperatureC}}</td>
          <td>{{forecast.temperatureF}}</td>
          <td>{{forecast.summary}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>

import { ref, onMounted } from 'vue'

export default {
  name: 'FetchDataMain',
  setup () {
    onMounted(() => {
      populateWeatherData()
    })

    const forecasts = ref([])
    const loading = ref(true)

    async function populateWeatherData () {
      const response = await fetch('weatherforecast')
      const data = await response.json()
      forecasts.value = data
      loading.value = false
    }

    return { loading, forecasts, populateWeatherData }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
