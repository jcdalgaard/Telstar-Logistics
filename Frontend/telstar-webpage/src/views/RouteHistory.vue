<template>
    <div class="view-container">
        <div class="container bg-white p-2 rounded">
            <h1>{{ lang.header }}</h1>
        </div>
    </div>
</template>

<script>
import lang from '@/utils/lang/langBroker'

export default {
    name: 'RouteHistory',
    components: {},
    data() {
        return {
            lang: lang.routeHistory,
        }
    },
}
</script>
