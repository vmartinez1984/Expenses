import { createRouter, createWebHistory } from 'vue-router'
import PeriodsList from '../components/PeriodsList.vue'
import PeriodsDetails from '../components/PeriodsDetails.vue'

const routes = [
  // {
  //   path: '/',
  //   name: 'periods',
  //   component: PeriodsList
  // },
  {
    path: '/', 
    name: 'periods', 
    component: PeriodsList
  },
  {
    path: '/Periods/Details',
    name: 'periodsDetails',
    component: PeriodsDetails
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
