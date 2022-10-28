<template>
    <div class="view-container">
        <div class="container bg-white p-3 rounded">
            <div class="row">
                <div class="col">
                    <h1>{{ lang.header }}</h1>
                </div>
            </div>
            <div class="row">
                <div
                    v-for="(route, index) in routeList"
                    :key="`route-history-item-${index}`"
                    class="col-12 col-md-6"
                >
                    <RouteItem :route="route" :index="index" />
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import RouteItem from '@/components/RouteItem.vue'

export default {
    name: 'AdminBookings',
    components: {
        RouteItem,
    },
    data() {
        return {
            lang: lang.adminBookings,
            routeList: [],
        }
    },
    methods: {
        getBookingHistory() {
            this.$http
                .get('https://fa-tl-dk1.azurewebsites.net/api/bookings/all')
                .then((body) => {
                    this.routeList = body.data
                })
        },
    },
    mounted() {
        this.getBookingHistory()
    },
}
</script>
