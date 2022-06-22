<template>
  <div class="home">
    <HomeMain msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HomeMain from '@/components/HomeMain.vue'

export default {
  name: 'HomeView',
  components: {
    HomeMain
  }
}
</script>
