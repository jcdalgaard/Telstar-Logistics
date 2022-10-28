<template>
    <button
        class="btn container-fluid bg-telstar-primary-light shadow-sm rounded my-2 p-3 text-start"
        @click="$emit('click', route)"
    >
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col-12 col-sm">
                        <label>{{ lang.estimateLabel }}</label>
                        <div class="row">
                            <div class="col text-telstar-primary fw-bold">
                                {{ formatDate(route.estimatedArrival) }}
                            </div>
                        </div>
                    </div>
                    <label class="col-12">{{ route.stops }} stops</label>
                </div>
            </div>
            <div class="col-auto d-flex align-items-center">
                <span class="text-telstar-primary fw-bold"
                    >${{ route.price }}</span
                >
                <font-awesome-icon
                    icon="fa-solid fa-chevron-right"
                    class="ms-2"
                />
            </div>
        </div>
    </button>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import dateTime from 'date-and-time'

export default {
    name: 'ResultsItem',
    props: {
        route: { type: Object, requred: true },
    },
    emits: ['click'],
    computed: {
        lang() {
            return lang.current.ResultsList.ResultsItem
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
