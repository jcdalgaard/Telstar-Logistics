<template>
    <div class="view-container">
        <div
            v-if="selectedCity === null"
            class="container-fluid bg-white p-3 my-2 rounded"
        >
            <div class="row">
                <div class="col">
                    <h1>{{ lang.header }}</h1>
                </div>
            </div>
            <div class="row">
                <div
                    v-for="(city, index) in cityList"
                    :key="`city-item-${index}`"
                    class="col-12 col-md-6"
                >
                    <CityItem :city="city" @click="selectedCity = $event" />
                </div>
            </div>
        </div>
        <div v-else>
            <div class="container-fluid bg-white p-3 my-2 rounded">
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
            </div>
            <div class="container-fluid bg-white p-3 my-2 rounded">
                <div
                    v-for="(route, index) in selectedCity.routes"
                    :key="`city-route-${index}`"
                    class="row"
                >
                    <div class="col">
                        <RouteItem :route="route" :index="index" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'
import CityItem from '@/components/CityItem.vue'
import RouteItem from '@/components/RouteItem.vue'

export default {
    name: 'AdminCities',
    components: {
        CityItem,
        RouteItem,
    },
    data() {
        return {
            lang: lang.adminCities,
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
