import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './assets/css/tailwind.css';

import DataService from './services/DataService.js';
import Pagination from 'vue-pagination-2';
Vue.component('pagination', Pagination);
import Print from 'vue-print-nb'
// Global instruction 
Vue.use(Print);


Vue.config.productionTip = false

Vue.prototype.$http = DataService;
import VueHtmlToPaper from "vue-html-to-paper";

Vue.prototype.$authenticatedUser = {
    userId: 0,
    name: null,
    userName: null,
    validity: null,
};


new Vue({
    router,
    render: h => h(App)
}).$mount('#app')