<template>
    <div class="container-fluid bg-white p-3 rounded">
        <div class="row">
            <div class="col">
                <h1>{{ lang.header }}</h1>
                <p>{{ lang.description }}</p>
            </div>
            <div class="col-auto">
                <button class="btn" @click="$emit('return')">
                    <font-awesome-icon icon="fa-solid fa-x" />
                </button>
            </div>
        </div>
        <div class="row">
            <div class="col-12 col-md">
                <label for="departureCity" class="fw-bold">{{
                    lang.departureLabel
                }}</label>
                <p id="departureCity">{{ route.departureCity }}</p>
                <label for="destinationCity" class="fw-bold">{{
                    lang.destinationLabel
                }}</label>
                <p id="destinationCity">{{ route.destinationCity }}</p>
            </div>
            <div class="col-12 col-md">
                <label for="priceLabel" class="fw-bold">{{
                    lang.priceLabel
                }}</label>
                <p id="priceLabel">{{ route.price }}</p>
                <label for="stopsLabel" class="fw-bold">{{
                    lang.stopsLabel
                }}</label>
                <p id="stopsLabel">{{ route.stops }}</p>
            </div>
        </div>
        <div class="row">
            <label for="estimatedArrival" class="fw-bold">{{
                lang.estimatedArrivalLabel
            }}</label>
            <p id="estimatedArrival">
                {{ formatDate(route.estimatedArrival) }}
            </p>
        </div>
        <div class="row d-flex justify-content-end">
            <div class="col-auto">
                <button
                    class="btn btn-lg btn-telstar-primary"
                    @click="$emit('confirmed')"
                >
                    {{ lang.confirm }}
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import dateTime from 'date-and-time'

export default {
    name: 'BookingSummary',
    props: {
        route: { type: Object, required: true },
    },
    emits: ['return', 'confirmed'],
    computed: {
        lang() {
            return lang.current.BookingSummary
        },
    },
    methods: {
        formatDate(date) {
            const thisDate = new Date(date)
            if (dateTime.isValid(thisDate)) {
                return dateTime.format(thisDate, 'HH:mm dddd, DD MMMM')
            } else console.log(`${date} is not a vaild date string`)
        },
    },
}
</script>

<style scoped></style>
