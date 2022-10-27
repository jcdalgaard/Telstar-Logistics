<template>
    <div class="view-container">
        <div class="row gx-5 gy-4">
            <div class="col-12 col-lg-6">
                <CardContainer :title="lang.reporting.popularCities">
                    <PieChart :data-sets="popularCitiesChartData" />
                </CardContainer>
            </div>
            <div class="col-12 col-lg-6">
                <CardContainer :title="lang.reporting.averageCost">
                    <AverageCostTable :data="averageBookingCostTableData" />
                </CardContainer>
            </div>
            <div class="col-12">
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
import AverageCostTable from '@/components/AverageCostTable'

export default {
    components: { AverageCostTable, BarChart, PieChart, CardContainer },
    data() {
        return {
            popularCitiesChartData: [],
            popularRoutesChartData: [],
            popularRoutesThisMonthChartData: [],
            averageBookingCostTableData: [],
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
            { name: 'Cairo - Suakin', thisMonth: 25, total: 25 },
            { name: 'Cairo - Omdurman', thisMonth: 0, total: 17 },
            { name: 'Luanda - Kabalo', thisMonth: 2, total: 9 },
        ]
        this.popularRoutesThisMonthChartData = this.popularRoutesChartData.map(
            (entry) => ({ thisMonth: entry.thisMonth })
        )
        this.averageBookingCostTableData = [
            { id: 1, name: 'Sahara', value: 365.24 },
            { id: 2, name: 'Darfur', value: 227.8 },
            { id: 3, name: 'Congo', value: 203.89 },
            { id: 4, name: 'Tripoli', value: 179 },
            { id: 5, name: 'Timbuktu', value: 136.27 },
            { id: 6, name: 'Timbuktu', value: 136.27 },
            { id: 7, name: 'Timbuktu', value: 136.27 },
            { id: 8, name: 'Timbuktu', value: 136.27 },
            { id: 9, name: 'Timbuktu', value: 136.27 },
            { id: 10, name: 'Timbuktu', value: 136.27 },
        ]
    },
}
</script>
