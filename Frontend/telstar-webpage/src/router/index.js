import Vue from 'vue'
import VueRouter from 'vue-router'
import lang from '@/utils/lang/english.json'

Vue.use(VueRouter)

const routes = [
    {
        path: `${lang.nav.bookRoute.link}`,
        name: `${lang.nav.bookRoute.name}`,
        component: () =>
            import(
                /* webpackChunkName: "book-route" */ '../views/BookRoute.vue'
            ),
    },
    {
        path: `${lang.nav.bookingHistory.link}`,
        name: `${lang.nav.bookingHistory.name}`,
        component: () =>
            import(
                /* webpackChunkName: "route-history" */ '../views/RouteHistory.vue'
            ),
    },
    {
        path: `${lang.nav.bookingReport.link}`,
        name: `${lang.nav.bookingReport.name}`,
        component: () =>
            import(
                /* webpackChunkName: "booking-report" */ '../views/BookingReport.vue'
            ),
    },
    {
        path: `${lang.nav.adminCities.link}`,
        name: `${lang.nav.adminCities.name}`,
        component: () =>
            import(
                /* webpackChunkName: "admin-cities" */ '../views/AdminCities.vue'
            ),
    },
    {
        path: `${lang.nav.adminBookings.link}`,
        name: `${lang.nav.adminBookings.name}`,
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
