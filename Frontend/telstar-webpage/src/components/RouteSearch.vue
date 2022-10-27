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
                </div>
                <div class="col"></div>
            </div>
            <div class="row p-2">
                <div class="col d-flex justify-content-end">
                    <button type="submit" class="btn btn-lg btn-primary">
                        Search
                    </button>
                </div>
            </div>
        </div>
    </form>
</template>

<script>
import SearchDropdown from '@/components/SearchDropdown.vue'

export default {
    name: 'RouteSearch',
    components: {
        SearchDropdown,
    },
    data() {
        return {
            search: '',
            tmpList: ['test', '1', '2', '3'],
        }
    },
    methods: {
        handleSubmit() {
            console.log('submit')
        },
    },
}
</script>
