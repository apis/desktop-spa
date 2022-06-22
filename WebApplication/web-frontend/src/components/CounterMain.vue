<template>
  <div>
    <h1>Counter</h1>

    <p>This is a simple example of a Vue component.</p>

    <p aria-live="polite">Current count: <strong>{{currentCount}}</strong></p>

    <button className="btn btn-primary" @click="incrementCounter()">Increment</button>
  </div>
</template>

<script>

import { ref } from 'vue'

export default {
  name: 'CounterMain',
  setup () {
    const currentCount = ref(0)
    function incrementCounter () {
      currentCount.value++
    }
    return { currentCount, incrementCounter }
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
