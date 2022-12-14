<template>
    <Bar
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
import { Bar } from 'vue-chartjs/legacy'

import {
    Chart as ChartJS,
    Title,
    Tooltip,
    Legend,
    BarElement,
    CategoryScale,
    LinearScale,
} from 'chart.js'
import { ChartColor } from '@/constants/ChartColor'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
export default {
    name: 'BarChart',
    components: { Bar },
    props: {
        chartId: {
            type: String,
            default: 'bar-chart',
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
        thisMonthDataSets: {
            type: Array,
            default: () => [],
        },
    },
    data() {
        return {
            chartData: {
                labels: [],
                datasets: [
                    {
                        label: 'Total',
                        backgroundColor: ChartColor.First,
                        data: [],
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
            this.chartData.labels = this.dataSets.map((entry) => entry.name)
            this.chartData.datasets[0].data = this.dataSets.map(
                (entry) => entry.total
            )
        },
        thisMonthDataSets() {
            const thisMonthData = this.thisMonthDataSets.map((entry) => {
                if (entry.thisMonth) {
                    return entry.thisMonth
                }
            })
            if (thisMonthData.length) {
                this.chartData.datasets.push({
                    label: 'This month',
                    backgroundColor: ChartColor.Second,
                    data: thisMonthData,
                })
            } else if (this.chartData.datasets.length > 1) {
                this.chartData.datasets = this.chartData.datasets.slice(0, 1)
            }
        },
    },
}
</script>
