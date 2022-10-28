<template>
    <div id="app">
        <nav
            v-if="loggedIn"
            class="navbar navbar-expand-lg navbar-dark fixed-top"
        >
            <div class="container-fluid">
                <div class="telstar-logo">
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
                    <ul class="navbar-nav me-auto">
                        <li class="nav-item mx-3 text-end text-lg-start">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookRoute.link"
                            >
                                {{ lang.nav.bookRoute.name }}
                            </router-link>
                        </li>
                        <li class="nav-item mx-3 text-end text-lg-start">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookingHistory.link"
                            >
                                {{ lang.nav.bookingHistory.name }}
                            </router-link>
                        </li>
                        <li class="nav-item mx-3 text-end text-lg-start">
                            <router-link
                                class="nav-item-link light"
                                :to="lang.nav.bookingReport.link"
                            >
                                {{ lang.nav.bookingReport.name }}
                            </router-link>
                        </li>
                        <li
                            class="nav-item dropdown mx-3 text-end text-lg-start"
                        >
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
                                <li class="text-end text-lg-start">
                                    <router-link
                                        class="nav-item-link"
                                        :to="lang.nav.adminCities.link"
                                    >
                                        {{ lang.nav.adminCities.name }}
                                    </router-link>
                                </li>
                                <li class="text-end text-lg-start">
                                    <router-link
                                        class="nav-item-link"
                                        :to="lang.nav.adminBookings.link"
                                    >
                                        {{ lang.nav.adminBookings.name }}
                                    </router-link>
                                </li>
                            </ul>
                        </li>
                        <li
                            class="nav-item dropdown mx-3 mt-5 text-end d-block d-lg-none"
                        >
                            <a
                                class="dropdown-toggle nav-item-link light"
                                href="#"
                                id="navbarDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="true"
                            >
                                {{ language }}
                            </a>
                            <ul
                                class="dropdown-menu p-3 pop-shadow border-0"
                                aria-labelledby="navbarDropdown"
                            >
                                <li
                                    class="text-end cursor-pointer"
                                    v-for="l in languageList"
                                    :key="l"
                                >
                                    <a
                                        class="nav-item-link"
                                        @click="handleChangeLanguage(l)"
                                    >
                                        {{ l }}
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li
                            class="nav-item dropdown mx-3 text-end d-block d-lg-none"
                        >
                            <a
                                class="dropdown-toggle nav-item-link light"
                                href="#"
                                id="navbarDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="true"
                            >
                                {{
                                    lang.navBar.profile.greeting + loggedInUser
                                }}
                            </a>
                            <ul
                                class="dropdown-menu p-3 pop-shadow border-0"
                                aria-labelledby="navbarDropdown"
                            >
                                <li class="text-end cursor-pointer">
                                    <a
                                        class="nav-item-link"
                                        @click="handleLogout()"
                                    >
                                        {{ lang.navBar.profile.logout }}
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <div
                        class="nav-item dropdown mx-3 text-end text-lg-start d-none d-lg-block"
                    >
                        <a
                            class="dropdown-toggle nav-item-link light"
                            href="#"
                            id="navbarDropdown"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="true"
                        >
                            {{ language }}
                        </a>
                        <ul
                            class="dropdown-menu p-3 pop-shadow border-0"
                            aria-labelledby="navbarDropdown"
                        >
                            <li
                                class="cursor-pointer"
                                v-for="l in languageList"
                                :key="l"
                            >
                                <a
                                    class="nav-item-link"
                                    @click="handleChangeLanguage(l)"
                                >
                                    {{ l }}
                                </a>
                            </li>
                        </ul>
                    </div>
                    <div
                        class="nav-item dropdown mx-3 text-end text-lg-start d-none d-lg-block"
                    >
                        <a
                            class="dropdown-toggle nav-item-link light"
                            href="#"
                            id="navbarDropdown"
                            role="button"
                            data-bs-toggle="dropdown"
                            aria-expanded="true"
                        >
                            {{ lang.navBar.profile.greeting + loggedInUser }}
                        </a>
                        <ul
                            class="dropdown-menu p-3 pop-shadow border-0"
                            aria-labelledby="navbarDropdown"
                        >
                            <li class="cursor-pointer">
                                <a
                                    class="nav-item-link"
                                    @click="handleLogout()"
                                >
                                    {{ lang.navBar.profile.logout }}
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
        <router-view />
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker.js'
import { language, login } from '@/state'
import { Language, LanguagesList } from '@/constants/Language'

export default {
    name: 'App',
    data() {
        return {
            lang: lang,
            languageList: LanguagesList,
        }
    },
    created() {
        login.isLoggedIn = localStorage.getItem('isLoggedIn') === '1'
        login.loggedInUser = localStorage.getItem('loggedInUser')
        language.current = localStorage.getItem('language') ?? Language.English
    },
    computed: {
        loggedIn() {
            return login.isLoggedIn
        },
        loggedInUser() {
            return login.loggedInUser
        },
        language() {
            return language.current
        },
    },
    methods: {
        async handleLogout() {
            localStorage.clear()
            login.isLoggedIn = false
            login.loggedInUser = ''
            await this.$router.push({ name: lang.nav.login.name })
        },
        async handleChangeLanguage(selectedLanguage) {
            localStorage.setItem('language', selectedLanguage)
            language.current = selectedLanguage
        },
    },
}
</script>

<style>
@import '~@/assets/style/Common.css';
.navbar {
    background-color: var(--primary-color);
}

.nav-item-link {
    font-weight: var(--fw-bold);
}
</style>
