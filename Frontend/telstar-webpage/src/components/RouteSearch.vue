<template>
    <span>
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
                                            expressDeliery &&
                                            'bg-telstar-primary'
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
                        <div class="row gy-2 d-flex justify-content-end">
                            <div
                                class="col-12 col-md-auto d-flex justify-content-end"
                            >
                                <button
                                    type="button"
                                    class="btn btn-lg btn-secondary"
                                    data-bs-toggle="modal"
                                    data-bs-target="#exampleModal"
                                >
                                    {{ lang.map }}
                                </button>
                            </div>
                            <div
                                class="col-12 col-md-auto d-flex justify-content-end"
                            >
                                <button
                                    type="submit"
                                    class="btn btn-lg btn-telstar-primary"
                                >
                                    {{ lang.search }}
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
        <div
            class="modal fade"
            id="exampleModal"
            tabindex="-1"
            aria-labelledby="exampleModalLabel"
            aria-hidden="true"
        >
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">
                            {{ lang.map }}
                        </h5>
                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close"
                        ></button>
                    </div>
                    <div class="modal-body">
                        <iframe
                            src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d32659096.793650016!2d23.738783875000035!3d-2.2631892668605613!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sda!2sdk!4v1666911554832!5m2!1sda!2sdk"
                            height="450"
                            class="w-100"
                            style="border: 0"
                            allowfullscreen=""
                            loading="lazy"
                            referrerpolicy="no-referrer-when-downgrade"
                        ></iframe>
                    </div>
                    <div class="modal-footer">
                        <button
                            type="button"
                            class="btn btn-secondary"
                            data-bs-dismiss="modal"
                        >
                            {{ lang.close }}
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </span>
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
    emits: ['submit', 'expressDeliery'],
    data() {
        return {
            departingCity: '',
            destinationCity: '',
            recordedDelivery: false,
            refridgeratedGoods: false,
            liveAnimals: false,
            cautiousParcels: false,
            expressDeliery: false,
            optionsList: null,
            loading: false,
            lang: lang.current.BookRoute.RouteSearch,
        }
    },
    methods: {
        async handleSubmit() {
            console.log('submit', {
                departureCity: this.departingCity.name,
                destinationCity: this.destinationCity.name,
                recordedDelivery: this.recordedDelivery,
                refridgeratedGoods: this.refridgeratedGoods,
                liveAnimals: this.liveAnimals,
                cautiousParcels: this.cautiousParcels,
                expressDeliery: this.expressDeliery,
            })
            this.$http({
                method: 'get',
                url: 'https://fa-tl-dk1.azurewebsites.net/api/SearchRoute',
                params: {
                    departureCity: this.departingCity.name,
                    destinationCity: this.destinationCity.name,
                    recordedDelivery: this.recordedDelivery,
                    refridgeratedGoods: this.refridgeratedGoods,
                    liveAnimals: this.liveAnimals,
                    cautiousParcels: this.cautiousParcels,
                    expressDeliery: this.expressDeliery,
                },
            })
                .then((body) => {
                    this.$emit('submit', body.data)
                    console.log('submit success', body)
                })
                .catch((e) => {
                    console.log('submit error', e)
                })
        },
        async getCities() {
            this.$http
                .get('https://fa-tl-dk1.azurewebsites.net/api/GetCities')
                .then((body) => {
                    this.optionsList = body.data
                })
                .catch((e) => {
                    console.log(e)
                })
        },
    },
    async mounted() {
        await this.getCities()
    },
    watch: {
        expressDeliery() {
            this.$emit('expressDeliery', this.expressDeliery)
        },
    },
}
</script>
