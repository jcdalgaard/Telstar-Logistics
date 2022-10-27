<template>
    <div id="app">
        <nav class="navbar navbar-expand-lg navbar-dark">
            <div class="container-fluid">
                <div class="navbar__logo">
                    <img src="~@/assets/img/telstar-logo.png" />
                </div>
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
                <div class="collapse navbar-collapse mx-4" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item mx-3">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookRoute.link"
                            >
                                {{ lang.nav.bookRoute.name }}
                            </router-link>
                        </li>
                        <li class="nav-item mx-3">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookingHistory.link"
                            >
                                {{ lang.nav.bookingHistory.name }}
                            </router-link>
                        </li>
                        <li class="nav-item mx-3">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookingReport.link"
                            >
                                {{ lang.nav.bookingReport.name }}
                            </router-link>
                        </li>
                        <li class="nav-item dropdown mx-3">
                            <a
                                class="dropdown-toggle nav-item-link light"
                                href="#"
                                id="navbarDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="true"
                            >
                                {{ lang.nav.administrate }}
                            </a>
                            <ul
                                class="dropdown-menu p-3 pop-shadow border-0"
                                aria-labelledby="navbarDropdown"
                            >
                                <li>
                                    <router-link
                                        class="nav-item-link"
                                        :to="lang.nav.adminCities.link"
                                    >
                                        {{ lang.nav.adminCities.name }}
                                    </router-link>
                                </li>
                                <li>
                                    <router-link
                                        class="nav-item-link"
                                        :to="lang.nav.adminBookings.link"
                                    >
                                        {{ lang.nav.adminBookings.name }}
                                    </router-link>
                                </li>
                            </ul>
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
.navbar {
    background-color: var(--primary-color);
}

.navbar__logo {
    height: 4rem;
}

.navbar__logo img {
    height: 100%;
    width: 100%;
}

.nav-item-link {
    font-weight: var(--fw-bold);
}
</style>
