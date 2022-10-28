<template>
    <button
        class="btn container-fluid bg-telstar-primary-light shadow-sm rounded my-2 p-3 text-start"
        @click="$emit('click', city)"
    >
        <div class="row">
            <div class="col">{{ city.name }}</div>
            <div class="col-auto">{{ city.routes.length }} routes</div>
            <div class="col-auto">
                <font-awesome-icon icon="fa-solid fa-chevron-right" />
            </div>
        </div>
    </button>
</template>

<script>
export default {
    name: 'CityItem',
    props: {
        city: { type: Object, required: true },
    },
    emits: ['click'],
}
</script>
