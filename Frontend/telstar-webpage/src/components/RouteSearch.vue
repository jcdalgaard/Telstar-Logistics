<template>
    <form @submit.prevent="handleSubmit()">
        <div class="container-fluid bg-light rounded p-2">
            <div class="row">
                <div class="col-12 col-md-8">
                    <div class="row p-2">
                        <div class="col-12">
                            <SearchDropdown
                                placeholder="From"
                                @setRoute="search = $event"
                            />
                            <p class="text-white">{{ search }}</p>
                        </div>
                        <div class="col-12">
                            <SearchDropdown
                                placeholder="To"
                                @setRoute="search = $event"
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
                                    >Default switch checkbox input</label
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
                                label="Recorded delivery"
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
                                label="Refridgerated Goods"
                                :checked="refridgeratedGoods"
                                @click="refridgeratedGoods = $event"
                            />
                        </div>
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-paw"
                                label="Live Animals"
                                :checked="liveAnimals"
                                @click="liveAnimals = $event"
                            />
                        </div>
                        <div
                            class="col-6 col-sm-3 col-md-6 d-flex justify-content-center"
                        >
                            <IconBtn
                                icon="fa-solid fa-martini-glass"
                                label="Cautious Parcels"
                                :checked="cautiousParcels"
                                @click="cautiousParcels = $event"
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row d-flex align-items-end p-2">
                <div class="col text-start">
                    <p class="my-0 py-0">
                        * Additional costs may apply <br />
                        Max weight 40kg <br />
                        No weapons allowed
                    </p>
                </div>
                <div class="col-auto">
                    <button
                        type="submit"
                        class="btn btn-lg btn-telstar-primary"
                    >
                        Search
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

export default {
    name: 'RouteSearch',
    components: {
        SearchDropdown,
        IconBtn,
    },
    data() {
        return {
            search: '',
            tmpList: ['test', '1', '2', '3'],
            recordedDelivery: false,
            refridgeratedGoods: false,
            liveAnimals: false,
            cautiousParcels: false,
            expressDeliery: false,
        }
    },
    methods: {
        handleSubmit() {
            console.log('submit')
        },
    },
}
</script>
