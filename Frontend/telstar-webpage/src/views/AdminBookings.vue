<template>
    <div class="view-container">
        <CardContainer :title="lang.header">
            <div class="row">
                <div
                    v-for="(route, index) in routeList"
                    :key="`route-history-item-${index}`"
                    class="col-12 col-md-6"
                >
                    <RouteItem :route="route" :index="index" />
                </div>
            </div>
        </CardContainer>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import RouteItem from '@/components/RouteItem.vue'
import CardContainer from '@/components/CardContainer'

export default {
    name: 'AdminBookings',
    components: {
        CardContainer,
        RouteItem,
    },
    data() {
        return {
            lang: lang.adminBookings,
            routeList: [],
        }
    },
    computed: {
        lang() {
            return lang.current.adminBookings
        },
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
