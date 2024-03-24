import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './assets/css/tailwind.css';

import DataService from './services/DataService.js';
import Pagination from 'vue-pagination-2';
Vue.component('pagination', Pagination);
import axios from 'axios';

// Global instruction 



Vue.config.productionTip = false

Vue.prototype.$http = DataService;

import VueHtmlToPaper1 from "vue-html-to-paper";

//axios.defaults.baseURL='http://localhost:85/';
//axios.defaults.baseURL='http://192.168.112.2:85/';
axios.defaults.baseURL='http://192.168.112.1:92/';
// const options = {
//     name: 'report',
//     specs: [
//         'fullscreen=yes',
//         'titlebar=yes',
//         'scrollbars=yes'
//     ],
//     styles: [
//         'https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css',
//         'https://unpkg.com/kidlat-css/css/kidlat.css',
//         'https://unpkg.com/tailwindcss-jit-cdn',

//     ]
// }

Vue.prototype.$authenticatedUser = {
    userId: 0,
    name: null,
    userName: null,
    validity: null,
};

 Vue.use(VueHtmlToPaper1);
// Vue.use(VueHtmlToPaper, options)





new Vue({
    router,
    render: h => h(App)
}).$mount('#app')