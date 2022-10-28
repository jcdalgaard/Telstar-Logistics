import Vue from 'vue'
import VueRouter from 'vue-router'
import lang from '@/utils/lang/langBroker.js'
import { login } from '@/state'

Vue.use(VueRouter)

const routes = [
    {
        path: `${lang.current.nav.login.link}`,
        name: `${lang.current.nav.login.name}`,
        component: () =>
            import(/* webpackChunkName: "login" */ '../views/LoginPage.vue'),
    },
    {
        path: `${lang.current.nav.bookRoute.link}`,
        name: `${lang.current.nav.bookRoute.name}`,

        component: () =>
            import(
                /* webpackChunkName: "book-route" */ '../views/BookRoute.vue'
            ),
    },
    {
        path: `${lang.current.nav.bookingHistory.link}`,
        name: `${lang.current.nav.bookingHistory.name}`,
        component: () =>
            import(
                /* webpackChunkName: "route-history" */ '../views/RouteHistory.vue'
            ),
    },
    {
        path: `${lang.current.nav.bookingReport.link}`,
        name: `${lang.current.nav.bookingReport.name}`,
        component: () =>
            import(
                /* webpackChunkName: "booking-report" */ '../views/BookingReport.vue'
            ),
    },
    {
        path: `${lang.current.nav.adminCities.link}`,
        name: `${lang.current.nav.adminCities.name}`,
        component: () =>
            import(
                /* webpackChunkName: "admin-cities" */ '../views/AdminCities.vue'
            ),
    },
    {
        path: `${lang.current.nav.adminBookings.link}`,
        name: `${lang.current.nav.adminBookings.name}`,
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

router.beforeEach((to, from, next) => {
    const isLoggedIn = localStorage.getItem('isLoggedIn') === '1'
    if (to.name !== lang.current.nav.login.name && !isLoggedIn) {
        login.isLoggedIn = false
        next({ name: lang.current.nav.login.name })
    } else if (to.name === lang.current.nav.login.name && isLoggedIn) {
        next({ name: lang.current.nav.bookRoute.name })
    } else {
        next()
    }
})

export default router
