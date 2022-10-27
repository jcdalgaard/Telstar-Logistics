<template>
    <div id="app">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Telstar</a>
                <button
                    class="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item mx-2">
                            <router-link :to="lang.nav.bookRoute.link">{{
                                lang.nav.bookRoute.name
                            }}</router-link>
                        </li>
                        <li class="nav-item mx-2">
                            <router-link :to="lang.nav.bookingHistory.link">{{
                                lang.nav.bookingHistory.name
                            }}</router-link>
                        </li>
                        <li class="nav-item mx-2">
                            <router-link :to="lang.nav.bookingReport.link">{{
                                lang.nav.bookingReport.name
                            }}</router-link>
                        </li>
                        <li class="nav-item mx-2">
                            <router-link :to="lang.nav.adminCities.link">{{
                                lang.nav.adminCities.name
                            }}</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <router-view />
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker.js'

export default {
    name: 'App',
    data() {
        return {
            lang: lang,
        }
    },
}
</script>

<style>
@import '~@/assets/style/Common.css';
</style>
