<template>
    <div class="card-container p-4 pop-shadow row">
        <div class="col-12">
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
    },
}
</script>

<style scoped>
@import '~@/assets/style/Common.css';

.card-container {
    background-color: var(--color-white);
    border-radius: var(--border-radius-normal);
}
</style>
