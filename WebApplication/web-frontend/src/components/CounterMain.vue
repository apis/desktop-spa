<template>
  <div>
    <h1>Counter</h1>

    <p>This is a simple example of a Vue JS component.</p>

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
