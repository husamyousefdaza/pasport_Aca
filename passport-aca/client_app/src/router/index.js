import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/auth/Login.vue'
import incoming_report from "../views/Reports/incoming_report.vue";

Vue.use(VueRouter)

const routes = [{
        path: '/',
        name: 'Login',
        component: Login
    },

    {
        path: "/incoming_report",
        name: "incoming_report",
        component: incoming_report
    },

    
    {
        path: '/dashboard',
        name: 'Dashboard',
        // route level code-splitting
        // this generates a separate chunk (dashboard.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "dashboard" */ '../views/Dashboard/Dashboard.vue')
    },

    {
        path: '/transactions',
        name: 'Transactions',
        // route level code-splitting
        // this generates a separate chunk (transactions.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "transactions" */ '../views/Transactions/Transactions.vue')
    },
    {
        path: '/transactions/create',
        name: 'TransactionsForm',
        // route level code-splitting
        // this generates a separate chunk (transactionscreate.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "transactionscreate" */ '../views/Transactions/TransactionsForm.vue')
    },
    {
        path: '/transactions/:transaction/edit',
        name: 'TransactionsFormEdit',
        component: () =>
            import ( /* webpackChunkName: "network-usersedit" */ '../views/Transactions/TransactionsForm.vue')
    },

    {
        path: '/report',
        name: 'Report',
        // route level code-splitting
        // this generates a separate chunk (report.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "report" */ '../views/Reports/Report.vue')
    },

    {
        path: '/administrators',
        name: 'Administrators',
        // route level code-splitting
        // this generates a separate chunk (administrators.[hash].js) for this route
        // which is lazy-loadAdministratorsed when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "administrators" */ '../views/Administrators/Administrators.vue')
    },
    {
        path: '/administrators/create',
        name: 'AdministratorsForm',
        // route level code-splitting
        // this generates a separate chunk (administratorscreate.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () =>
            import ( /* webpackChunkName: "administratorscreate" */ '../views/Administrators/AdministratorsForm.vue')
    },

    {
        path: '/administrators/:administrato/edit',
        name: 'AdministratorsFormEdit',
        component: () =>
            import ( /* webpackChunkName: "administrator-edit" */ '../views/Administrators/AdministratorsForm.vue')
    },





]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router