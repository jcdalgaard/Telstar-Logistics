<template>
    <Pie
        class="p-4"
        :chart-options="chartOptions"
        :chart-data="chartData"
        :chart-id="chartId"
        :dataset-id-key="datasetIdKey"
        :plugins="plugins"
        :css-classes="cssClasses"
        :styles="styles"
        :width="width"
        :height="height"
    />
</template>

<script>
import { Pie } from 'vue-chartjs/legacy'
import { ChartColor } from '@/constants/ChartColor'
import {
    Chart as ChartJS,
    Title,
    Tooltip,
    Legend,
    ArcElement,
    CategoryScale,
} from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, ArcElement, CategoryScale)

export default {
    name: 'PieChart',
    components: { Pie },
    props: {
        chartId: {
            type: String,
            default: 'pie-chart',
        },
        datasetIdKey: {
            type: String,
            default: 'label',
        },
        width: {
            type: Number,
            default: 400,
        },
        height: {
            type: Number,
            default: 400,
        },
        cssClasses: {
            default: '',
            type: String,
        },
        styles: {
            type: Object,
            default: () => {},
        },
        plugins: {
            type: Array,
            default: () => [],
        },
        dataSets: {
            type: Array,
            default: () => [],
        },
    },
    data() {
        return {
            chartData: {
                labels: [], //areas
                datasets: [
                    {
                        backgroundColor: [
                            ChartColor.First,
                            ChartColor.Second,
                            ChartColor.Third,
                            ChartColor.Fourth,
                            ChartColor.Other,
                        ],
                        data: [], // values of areas
                    },
                ],
            },
            chartOptions: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        position: 'bottom',
                        labels: {
                            font: {
                                size: 16,
                            },
                        },
                    },
                },
            },
        }
    },
    watch: {
        dataSets() {
            this.chartData.labels = this.dataSets.map((entry) => entry.label)
            this.chartData.datasets[0].data = this.dataSets.map(
                (entry) => entry.value
            )
        },
    },
}
</script>
