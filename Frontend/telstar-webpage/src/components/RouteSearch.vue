<template>
    <form @submit.prevent="handleSubmit()">
        <div class="container-fluid bg-light rounded p-2">
            <div class="row">
                <div class="col-12 col-md-8">
                    <div class="row p-2">
                        <div class="col-12 mb-2">
                            <SearchDropdown
                                placeholder="From"
                                :loading="loading"
                                :options="optionsList"
                                :loadingText="lang.loading"
                                :noResultsMessage="lang.noResults"
                                @setRoute="departingCity = $event"
                            />
                        </div>
                        <div class="col-12">
                            <SearchDropdown
                                placeholder="To"
                                :loading="loading"
                                :options="optionsList"
                                :loadingText="lang.loading"
                                :noResultsMessage="lang.noResults"
                                @setRoute="destinationCity = $event"
                            />
                        </div>
                    </div>
                    <div class="row px-2">
                        <div class="col">
                            <div class="form-check text-start">
                                <input
                                    v-model="expressDeliery"
                                    class="form-check-input border border-secondary"
                                    :class="
                                        expressDeliery && 'bg-telstar-primary'
                                    "
                                    type="checkbox"
                                    id="flexSwitchCheckDefault"
                                />
                                <label
                                    class="form-check-label"
                                    for="flexSwitchCheckDefault"
                                    >{{ lang.expressDeliery }}</label
                                >
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="row">
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-paper-plane"
                                :label="lang.recordedDelivery"
                                type="button"
                                :checked="recordedDelivery"
                                @click="recordedDelivery = $event"
                            />
                        </div>
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-snowflake"
                                :label="lang.refridgeratedGoods"
                                :checked="refridgeratedGoods"
                                @click="refridgeratedGoods = $event"
                            />
                        </div>
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-paw"
                                :label="lang.liveAnimals"
                                :checked="liveAnimals"
                                @click="liveAnimals = $event"
                            />
                        </div>
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-martini-glass"
                                :label="lang.cautiousParcels"
                                :checked="cautiousParcels"
                                @click="cautiousParcels = $event"
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row d-flex align-items-end p-2">
                <div class="col text-start">
                    <ul class="mb-0">
                        <li>{{ lang.additionalCost }}</li>
                        <li>{{ lang.maxWeight }}</li>
                        <li>{{ lang.noWeapons }}</li>
                    </ul>
                </div>
                <div class="col-auto">
                    <button
                        type="submit"
                        class="btn btn-lg btn-telstar-primary"
                    >
                        {{ lang.Search }}
                        <font-awesome-icon
                            icon="fa-solid fa-magnifying-glass"
                            class="ml-2"
                        />
                    </button>
                </div>
            </div>
        </div>
    </form>
</template>

<script>
import SearchDropdown from '@/components/SearchDropdown.vue'
import IconBtn from '@/components/IconBtn.vue'
import lang from '@/utils/lang/langBroker'

export default {
    name: 'RouteSearch',
    components: {
        SearchDropdown,
        IconBtn,
    },
    data() {
        return {
            departingCity: '',
            destinationCity: '',
            recordedDelivery: false,
            refridgeratedGoods: false,
            liveAnimals: false,
            cautiousParcels: false,
            expressDeliery: false,
            optionsList: ['Foo', 'Bar'],
            loading: false,
            lang: lang.BookRoute.RouteSearch,
        }
    },
    methods: {
        async handleSubmit() {
            console.log('submit')
        },
        async getCities() {
            console.log('Getting cities')
        },
    },
    async mounted() {
        await this.getCities()
    },
}
</script>
