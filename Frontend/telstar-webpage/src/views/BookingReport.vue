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
        }
    },
    computed: {
        lang() {
            return lang.current
        },
    },
    methods: {
        async getPopularCities() {
            return this.$http
                .get(
                    'https://fa-tl-dk1.azurewebsites.net/api/cities/mostPopular'
                )
                .then(async (body) => {
                    this.popularCitiesChartData = body.data?.map((entry) => ({
                        label: entry.name,
                        value: entry.value,
                    }))
                    // await this.getMostExpensiveCities()
                })
                .catch((e) => {
                    console.log(e)
                })
        },
        async getPopularRoutes() {
            return this.$http
                .get(
                    'https://fa-tl-dk1.azurewebsites.net/api/route/mostPopular'
                )
                .then((body) => {
                    this.popularRoutesChartData = body.data?.map((entry) => ({
                        name: `${entry.city1} - ${entry.city2}`,
                        thisMonth: entry.total,
                        total: entry.thisMonth,
                    }))
                })
                .catch((e) => {
                    console.log(e)
                })
        },
        async getMostExpensiveCities() {
            return this.$http
                .get(
                    'https://fa-tl-dk1.azurewebsites.net/api/cities/mostExpensive'
                )
                .then((body) => {
                    this.averageBookingCostTableData = body.data
                })
                .catch((e) => {
                    console.log(e)
                })
        },
    },
    async mounted() {
        // mockup
        await this.getPopularCities()
        await this.getMostExpensiveCities()
        await this.getPopularRoutes()
        // this.popularRoutesChartData = [
        //     { name: 'Sahara - Darfur', thisMonth: 45, total: 127 },
        //     { name: 'Congo - Luanda', thisMonth: 66, total: 100 },
        //     { name: 'Wadai - Darfur', thisMonth: 15, total: 87 },
        //     { name: 'Mocambique - Zanzibar', thisMonth: 2, total: 53 },
        //     { name: 'Cairo - Suakin', thisMonth: 25, total: 25 },
        //     { name: 'Cairo - Omdurman', thisMonth: 0, total: 17 },
        //     { name: 'Luanda - Kabalo', thisMonth: 2, total: 9 },
        // ]
        this.popularRoutesThisMonthChartData = this.popularRoutesChartData.map(
            (entry) => ({ thisMonth: entry.thisMonth })
        )
    },
}
</script>
