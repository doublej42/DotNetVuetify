import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/chat',
      name: 'chat',
      // route level code-splitting
      // this generates a separate chunk (Chat.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "Chat" */ './examples/Chat.vue')
    },
    {
      path: '/fetchdata',
      name: 'Fetch Data',
      component: () => import(/* webpackChunkName: "FetchData" */ './examples/FetchData.vue')
    },

  ]
})
