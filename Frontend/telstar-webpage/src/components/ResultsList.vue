<template>
    <div class="container-fluid bg-white my-3 p-3 rounded text-start">
        <div class="row">
            <label class="col-12">{{ lang.fastestLabel }}</label>
            <div class="col-12">
                <ResultsItem
                    :route="fastestList[0]"
                    @click="handleSelectRoute($event)"
                />
            </div>
        </div>
        <div v-if="!expressDeliery" class="row">
            <label class="col-12">{{ lang.economicLabel }}</label>
            <div class="col-12">
                <ResultsItem
                    :route="cheapestList[0]"
                    @click="handleSelectRoute($event)"
                />
            </div>
        </div>
    </div>
</template>

<script>
import ResultsItem from '@/components/ResultsItem.vue'
import lang from '@/utils/lang/langBroker'

export default {
    name: 'ResultsList',
    components: {
        ResultsItem,
    },
    computed: {
        lang() {
            return lang.current.ResultsList
        },
    },
    props: {
        cheapestList: { type: Array, required: true },
        fastestList: { type: Array, required: true },
        expressDeliery: { type: Boolean, required: true },
    },
    emits: ['selectRoute'],
    methods: {
        handleSelectRoute(route) {
            this.$emit('selectRoute', route)
        },
    },
}
</script>

<style scoped></style>
