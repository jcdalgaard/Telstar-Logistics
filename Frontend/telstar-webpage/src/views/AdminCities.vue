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
                    description: 'Tunis is a town in northern Africa.',
                    routes: [
                        {
                            id: 1,
                            departureCity: 'Tunis',
                            destinationCity: 'Kapstaden',
                            price: 123,
                            steps: 4,
                        },
                        {
                            id: 1,
                            departureCity: 'Dakar',
                            destinationCity: 'Tunis',
                            price: 123,
                            steps: 4,
                        },
                    ],
                },
                {
                    id: 2,
                    name: 'Kapstaden',
                    description:
                        'Kapstaden is the southern most city of Africa.',
                    routes: [
                        {
                            id: 1,
                            departureCity: 'Tunis',
                            destinationCity: 'Kapstaden',
                            price: 123,
                            steps: 4,
                        },
                        {
                            id: 3,
                            departureCity: 'Kapstaden',
                            destinationCity: 'Wadai',
                            price: 123,
                            steps: 4,
                        },
                        {
                            id: 5,
                            departureCity: 'Kapstaden',
                            destinationCity: 'Dakar',
                            price: 123,
                            steps: 4,
                        },
                    ],
                },
                {
                    id: 3,
                    name: 'Dakar',
                    description: 'Dakas is a city in west-Africa.',
                    routes: [
                        {
                            id: 1,
                            departureCity: 'Kapstaden',
                            destinationCity: 'Dakar',
                            price: 123,
                            steps: 4,
                        },
                    ],
                },
            ],
        }
    },
}
</script>
