<template>
    <div class="view-container">
        <h1>This is an booking page</h1>
        <RouteSearch />
    </div>
</template>

<script>
import RouteSearch from '@/components/RouteSearch.vue'

export default {
    name: 'BookRoute',
    components: {
        RouteSearch,
    },
}
</script>
