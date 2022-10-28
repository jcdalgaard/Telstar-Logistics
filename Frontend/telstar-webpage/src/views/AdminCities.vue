<template>
    <div class="view-container">
        <CardContainer v-if="selectedCity === null" :title="lang.header">
            <div class="row">
                <div
                    v-for="(city, index) in cityList"
                    :key="`city-item-${index}`"
                    class="col-12 col-md-6"
                >
                    <CityItem :city="city" @click="selectedCity = $event" />
                </div>
            </div>
        </CardContainer>
        <div v-else class="row row gx-5 gy-4">
            <div class="col-12">
                <CardContainer>
                    <div class="row">
                        <div class="col"></div>
                        <div class="col-auto">
                            <button @click="selectedCity = null" class="btn">
                                <font-awesome-icon icon="fa-solid fa-x" />
                            </button>
                        </div>
                    </div>
                    <h1>{{ selectedCity.name }}</h1>
                    <p>{{ selectedCity.description }}</p>
                </CardContainer>
            </div>
            <div class="col-12">
                <CardContainer :title="lang.routes">
                    <div
                        v-for="(route, index) in selectedCity.routes"
                        :key="`city-route-${index}`"
                        class="row"
                    >
                        <div class="col">
                            <RouteItem :route="route" :index="index" />
                        </div>
                    </div>
                </CardContainer>
            </div>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import CityItem from '@/components/CityItem.vue'
import RouteItem from '@/components/RouteItem.vue'
import CardContainer from '@/components/CardContainer'

export default {
    name: 'AdminCities',
    components: {
        CardContainer,
        CityItem,
        RouteItem,
    },
    lang() {
        return lang.current.adminCities
    },
    data() {
        return {
            selectedCity: null,
            cityList: [
                {
                    id: 1,
                    name: 'Tunis',
                    routes: [
                        {
                            routes: [
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'De Kanariskeoeer',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Tunis',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'Tanger',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Tunis',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'Cairo',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Tunis',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                            ],
                        },
                    ],
                },
                {
                    id: 1,
                    name: 'De Kanariskeoeer',
                    routes: [
                        {
                            routes: [
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'De Kanariskeoeer',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Tunis',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'Tanger',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'De Kanariskeoeer',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'Cairo',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'De Kanariskeoeer',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                            ],
                        },
                    ],
                },
                {
                    id: 1,
                    name: 'Cairo',
                    routes: [
                        {
                            routes: [
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'De Kanariskeoeer',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Cairo',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                            ],
                        },
                        {
                            routes: [
                                {
                                    route: {
                                        firstCityID: 2,
                                        firstCity: {
                                            name: 'Tanger',
                                            isActive: true,
                                            id: 2,
                                        },
                                        secondCityID: 3,
                                        secondCity: {
                                            name: 'Cairo',
                                            isActive: true,
                                            id: 3,
                                        },
                                        segmentPriceID: 1,
                                        segmentPrice: { value: 0.0, id: 0 },
                                        numberOfSegments: 2,
                                        duration: 8.0,
                                        id: 3,
                                    },
                                },
                            ],
                        },
                    ],
                },
            ],
        }
    },
}
</script>
