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
                            <router-link to="/">Book route</router-link>
                        </li>
                        <li class="nav-item mx-2">
                            <router-link to="/route-history"
                                >Booking History</router-link
                            >
                        </li>
                        <li class="nav-item mx-2">
                            <router-link to="/booking-report"
                                >Reporting</router-link
                            >
                        </li>
                        <li class="nav-item mx-2">
                            <router-link to="/admin-cities"
                                >Administrate</router-link
                            >
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <router-view />
    </div>
</template>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
}

.view-container {
    position: relative;
    height: calc(100vh - 56px);
    left: 0;
    right: 0;
    background-image: url('~@/assets/img/telstar-bg.jpg');
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat;
    padding: 15px;
}
</style>
