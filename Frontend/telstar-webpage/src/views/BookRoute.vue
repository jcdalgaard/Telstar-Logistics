<template>
    <div v-if="selectedRoute === null" class="view-container">
        <RouteSearch />
        <ResultsList
            :results-list="resultsList"
            @selectRoute="handleSelectedRoute($event)"
        />
    </div>
    <div v-else-if="!bookingConfirmed" class="view-container">
        <BookingSummary
            :route="selectedRoute"
            @return="selectedRoute = null"
            @confirmed="saveBooking()"
        />
    </div>
    <div v-else class="view-container">
        <BookingConfirmation
            @return=";(selectedRoute = null), (bookingConfirmed = false)"
            @complete=";(selectedRoute = null), (bookingConfirmed = false)"
        />
    </div>
</template>

<script>
import RouteSearch from '@/components/RouteSearch.vue'
import ResultsList from '@/components/ResultsList.vue'
import BookingSummary from '@/components/BookingSummary.vue'
import BookingConfirmation from '@/components/BookingConfirmation.vue'

export default {
    name: 'BookRoute',
    components: {
        RouteSearch,
        ResultsList,
        BookingSummary,
        BookingConfirmation,
    },
    data() {
        return {
            selectedRoute: null,
            bookingConfirmed: false,
            resultsList: [
                {
                    id: 1,
                    departureCity: 'Addis Abeba',
                    destinationCity: 'Tripoli',
                    price: 500,
                    stops: 2,
                    estimatedArrival: 'Thu Oct 28 2022 17:45:42 GMT+0200',
                },
                {
                    id: 2,
                    departureCity: 'Addis Abeba',
                    destinationCity: 'Zanzibar',
                    price: 423,
                    stops: 6,
                    estimatedArrival: 'Thu Oct 30 2022 15:34:42 GMT+0200',
                },
                {
                    id: 3,
                    departureCity: 'Zanzibar',
                    destinationCity: 'Addis Abeba',
                    price: 123,
                    stops: 4,
                    estimatedArrival: 'Thu Oct 29 2022 18:05:42 GMT+0200',
                },
            ],
        }
    },
    methods: {
        handleSelectedRoute(route) {
            this.selectedRoute = route
        },
        async saveBooking() {
            this.bookingConfirmed = true
        },
    },
}
</script>
