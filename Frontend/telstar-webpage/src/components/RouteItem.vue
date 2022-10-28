<template>
    <CollapseSection
        :header="`${route.routes[0].route.firstCity.name} - ${route.routes[0].route.secondCity.name}`"
        :index="index"
    >
        <form @submit.prevent="handleUpdate()">
            <div class="row">
                <div class="col-12 col-md-6">
                    <div class="row my-1 d-flex align-items-end">
                        <div class="col">
                            <div v-if="edit">
                                <label :for="`route-departure-${index}`">
                                    {{ lang.departureLabel }}
                                </label>
                                <input
                                    :id="`route-departure-${index}`"
                                    type="text"
                                    class="form-control"
                                    :value="
                                        route.routes[0].route.firstCity.name
                                    "
                                />
                            </div>
                            <label :for="`route-price-${index}`">{{
                                lang.priceLabel
                            }}</label>
                            <input
                                :id="`route-price-${index}`"
                                :value="route.price"
                                type="text"
                                class="form-control"
                                :disabled="!edit"
                            />
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6">
                    <div class="row my-1 d-flex align-items-end">
                        <div class="col">
                            <div v-if="edit">
                                <label :for="`route-destination-${index}`">
                                    {{ lang.destinationLabel }}
                                </label>
                                <input
                                    :id="`route-destination-${index}`"
                                    type="text"
                                    class="form-control"
                                    :value="
                                        route.routes[0].route.secondCity.name
                                    "
                                />
                            </div>
                            <label :for="`route-date-${index}`">
                                {{ lang.dateLabel }}
                            </label>
                            <div>
                                <b-form-datepicker
                                    :id="`route-date-${index}`"
                                    v-model="date"
                                    class="mb-2"
                                    :disabled="!edit"
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row d-flex justify-content-end">
                <div class="col-auto">
                    <button class="btn btn-danger" @click="handleDelete()">
                        {{ lang.delete }}
                    </button>
                </div>
                <div class="col-auto">
                    <button
                        :type="edit ? 'button' : 'submit'"
                        @click="edit = !edit"
                        class="btn btn-telstar-primary"
                    >
                        {{ edit ? lang.save : lang.edit }}
                    </button>
                </div>
            </div>
        </form>
    </CollapseSection>
</template>

<script>
import CollapseSection from '@/components/CollapseSection.vue'
import lang from '@/utils/lang/langBroker'

export default {
    name: 'RouteItem',
    components: {
        CollapseSection,
    },
    data() {
        return {
            edit: false,
            date: new Date(this.route.bookedDate),
            lang: lang.bookingHistory.routeItem,
        }
    },
    props: {
        route: { type: Object, required: true },
        index: { type: Number, required: true },
    },
    methods: {
        handleUpdate() {
            console.log('save')
        },
        handleDelete() {},
    },
}
</script>

<style scoped></style>
