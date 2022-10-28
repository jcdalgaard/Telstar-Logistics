<template>
    <div v-if="selectedRoute === null" class="view-container">
        <RouteSearch
            @submit="
                ;(cheapestList = $event.cheapest),
                    (fastestList = $event.fastest)
            "
            @expressDeliery="expressDeliery = $event"
            @loading="loading = $event"
        />
        <ResultsList
            v-if="
                (fastestList.length > 0 || cheapestList.length > 0) && !loading
            "
            :fastest-list="fastestList"
            :cheapest-list="cheapestList"
            :express-deliery="expressDeliery"
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
            expressDeliery: false,
            fastestList: [],
            loading: false,
            cheapestList: [],
        }
    },
    methods: {
        handleSelectedRoute(route) {
            this.selectedRoute = route
        },
        async saveBooking() {
            this.$http({
                method: 'post',
                url: 'https://fa-tl-dk1.azurewebsites.net/api/bookings/add',
                data: {
                    arrivalDate: null,
                    bookedDate: new Date(),
                    price: null,
                    routes: [
                        {
                            bookingID: null,
                            routeID: null,
                            route: {
                                firstCityID: null,
                                firstCity: {
                                    name: this.selectedRoute.departureCity,
                                    isActive: true,
                                    id: null,
                                },
                                secondCityID: null,
                                secondCity: {
                                    name: this.selectedRoute.destinationCity,
                                    isActive: true,
                                    id: null,
                                },
                                segmentPriceID: 1,
                                segmentPrice: {
                                    value: null,
                                    id: null,
                                },
                                numberOfSegments: null,
                                duration: null,
                                id: null,
                            },
                        },
                    ],
                    packages: [],
                    userID: null,
                    user: {
                        name: '',
                        password: '',
                        userRoleID: 0,
                        userRole: {
                            name: '',
                            id: 0,
                        },
                        id: 0,
                    },
                    bookingStatus: 'COM',
                    id: null,
                },
            }).then((this.bookingConfirmed = true))
            this.bookingConfirmed = true
        },
    },
}
</script>
