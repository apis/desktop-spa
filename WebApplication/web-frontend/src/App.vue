<template>
  <a>NavbarBrand</a>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/counter">Counter</router-link> |
    <router-link to="/fetch-data">Fetch data</router-link>
  </nav>
  <router-view/>
</template>

<style>

a {
  color: #0366d6;
}

code {
  color: #E01A76;
}

.btn-primary {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

@import "@/assets/custom.css";
@import "@/assets/NavMenu.css";

  /*#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
*/
</style>
