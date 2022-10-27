import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'BookRoute',
        component: () =>
            import(
                /* webpackChunkName: "book-route" */ '../views/BookRoute.vue'
            ),
    },
    {
        path: '/route-history',
        name: 'RouteHistory',
        component: () =>
            import(
                /* webpackChunkName: "route-history" */ '../views/RouteHistory.vue'
            ),
    },
    {
        path: '/booking-report',
        name: 'BookingReport',
        component: () =>
            import(
                /* webpackChunkName: "booking-report" */ '../views/BookingReport.vue'
            ),
    },
    {
        path: '/admin-cities',
        name: 'AdminCities',
        component: () =>
            import(
                /* webpackChunkName: "admin-cities" */ '../views/AdminCities.vue'
            ),
    },
    {
        path: '/admin-bookings',
        name: 'AdminBookings',
        component: () =>
            import(
                /* webpackChunkName: "admin-bookings" */ '../views/AdminBookings.vue'
            ),
    },
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes,
})

export default router
