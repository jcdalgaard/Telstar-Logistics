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
        <div class="row d-flex justify-content-end">
            <div class="col-auto">
                <button
                    class="btn btn-lg btn-telstar-primary"
                    @click="$emit('complete')"
                >
                    {{ lang.return }}
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'

export default {
    name: 'BookingConfirmation',
    emits: ['return', 'complete'],
    computed: {
        lang() {
            return lang.current.BookingConfirmation
        },
    },
}
</script>

<style scoped></style>
