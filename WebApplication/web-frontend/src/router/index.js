import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/counter',
    name: 'counter',
    component: () => import('@/views/CounterView.vue')
  },
  {
    path: '/fetch-data',
    name: 'about',
    component: () => import('@/views/FetchDataView.vue')
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
