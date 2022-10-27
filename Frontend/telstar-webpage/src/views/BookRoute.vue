<template>
    <div class="view-container">
        <RouteSearch />
        <ResultsList :results-list="resultsList" />
    </div>
</template>

<script>
import RouteSearch from '@/components/RouteSearch.vue'
import ResultsList from '@/components/ResultsList.vue'

export default {
    name: 'BookRoute',
    components: {
        RouteSearch,
        ResultsList,
    },
    data() {
        return {
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
}
</script>
