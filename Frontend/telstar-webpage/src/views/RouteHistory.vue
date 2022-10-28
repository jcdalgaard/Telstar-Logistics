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
    name: 'RouteHistory',
    components: {
        CardContainer,
        RouteItem,
    },
    computed: {
        lang() {
            return lang.current.bookingHistory
        },
    },
    data() {
        return {
            routeList: [
                {
                    id: 1,
                    departureCity: 'Addis Abeba',
                    destinationCity: 'Tripoli',
                    price: 500,
                    stops: 2,
                    bookedDate: 'Thu Oct 28 2022 17:45:42 GMT+0200',
                },
                {
                    id: 2,
                    departureCity: 'Addis Abeba',
                    destinationCity: 'Zanzibar',
                    price: 423,
                    stops: 6,
                    bookedDate: 'Thu Oct 28 2022 17:45:42 GMT+0200',
                },
                {
                    id: 3,
                    departureCity: 'Zanzibar',
                    destinationCity: 'Addis Abeba',
                    price: 123,
                    stops: 4,
                    bookedDate: 'Thu Oct 28 2022 17:45:42 GMT+0200',
                },
            ],
        }
    },
    methods: {
        getBookingHistory() {
            // TODO
        },
    },
    mounted() {
        this.getBookingHistory()
    },
}
</script>
