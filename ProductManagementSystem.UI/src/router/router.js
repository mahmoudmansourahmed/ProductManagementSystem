import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/views/HomeView.vue';
import ProductView from '@/views/ProductView.vue';
import SupplierListView from '@/views/SupplierListView.vue';
import StatisticsView from '@/views/StatisticsView.vue';

const routes = [
  { path: '/', name: 'Home', component: HomeView },
  { path: '/products', name: 'ProductView', component: ProductView },
  { path: '/suppliers', name: 'SupplierList', component: SupplierListView },
  { path: '/statistics', name: 'Statistics', component: StatisticsView }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
