<template>
    <div class="view-container">
        <div class="row gx-5 gy-4">
            <div class="col-12 col-lg-6">
                <CardContainer :title="lang.reporting.popularCities">
                    <PieChart :data-sets="popularCitiesChartData" />
                </CardContainer>
            </div>
            <div class="col-12 col-lg-6">
                <CardContainer :title="lang.reporting.popularRoutes">
                    <BarChart
                        :data-sets="popularRoutesChartData"
                        :this-month-data-sets="popularRoutesThisMonthChartData"
                    />
                </CardContainer>
            </div>
        </div>
    </div>
</template>
<script>
import CardContainer from '@/components/CardContainer'
import PieChart from '@/components/PieChart'
import lang from '@/utils/lang/langBroker'
import BarChart from '@/components/BarChart'

export default {
    components: { BarChart, PieChart, CardContainer },
    data() {
        return {
            popularCitiesChartData: [],
            popularRoutesChartData: [],
            popularRoutesThisMonthChartData: [],
            lang: lang,
        }
    },
    mounted() {
        // mockup
        this.popularCitiesChartData = [
            { label: 'Darfur', value: 74 },
            { label: 'Congo', value: 37 },
            { label: 'Slavekysten', value: 15 },
            { label: 'Luanda', value: 46 },
            { label: 'Other', value: 27 },
        ]
        this.popularRoutesChartData = [
            { name: 'Sahara - Darfur', thisMonth: 45, total: 127 },
            { name: 'Congo - Luanda', thisMonth: 66, total: 100 },
            { name: 'Wadai - Darfur', thisMonth: 15, total: 87 },
            { name: 'Mocambique - Zanzibar', thisMonth: 2, total: 53 },
        ]
        this.popularRoutesThisMonthChartData = this.popularRoutesChartData.map(
            (entry) => ({ thisMonth: entry.thisMonth })
        )
    },
}
</script>
