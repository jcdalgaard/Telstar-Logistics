<template>
    <div class="card-container p-4 pop-shadow row" :class="{ blur: blur }">
        <div v-if="title" class="col-12">
            <h3 class="fw-bold">{{ title }}</h3>
        </div>
        <div class="col-12">
            <slot></slot>
        </div>
    </div>
</template>

<script>
export default {
    name: 'CardContainer',
    props: {
        title: String,
        blur: Boolean,
    },
}
</script>

<style scoped>
@import '~@/assets/style/Common.css';

.card-container {
    min-height: 100%;
    background-color: var(--color-white);
    border-radius: var(--border-radius-normal);
}

.card-container.blur {
    backdrop-filter: blur(50px) saturate(150%);
    background-color: rgba(255, 255, 255, 0.75);
}
</style>
