<template>
    <div class="view-container">
        <div class="row">
            <div class="col-12 col-lg-6">
                <CardContainer :title="lang.reporting.popularCities">
                    <PieChart :data-sets="chartData" />
                </CardContainer>
            </div>
        </div>
    </div>
</template>
<script>
import CardContainer from '@/components/CardContainer'
import PieChart from '@/components/PieChart'
import lang from '@/utils/lang/langBroker'

export default {
    components: { PieChart, CardContainer },
    data() {
        return {
            chartData: [],
            lang: lang,
        }
    },
    mounted() {
        // mockup
        this.chartData = [
            { label: 'Darfur', value: 74 },
            { label: 'Congo', value: 37 },
            { label: 'Slavekysten', value: 15 },
            { label: 'Luanda', value: 46 },
            { label: 'Other', value: 27 },
        ]
    },
}
</script>
