import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import ProductView from '@/views/ProductView.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/products',
    name: 'ProductView',
    component: ProductView
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
