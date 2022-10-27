<template>
    <div class="container-fluid bg-white my-3 p-3 rounded text-start">
        <div class="row">
            <label class="col-12">{{ lang.fastestLabel }}</label>
            <div class="col-12">
                <ResultsItem :route="resultsList[0]" />
            </div>
        </div>
        <div class="row">
            <label class="col-12">{{ lang.economicLabel }}</label>
            <div class="col-12">
                <ResultsItem :route="resultsList[2]" />
            </div>
        </div>
        <div class="row">
            <label class="col-12">{{ lang.othersLabel }}</label>
            <div
                v-for="(route, index) in resultsList"
                :key="`result-item-${index}`"
            >
                <ResultsItem :route="route" />
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
    data() {
        return {
            lang: lang.ResultsList,
        }
    },
    props: {
        resultsList: { type: Array, required: true },
    },
}
</script>

<style scoped></style>
