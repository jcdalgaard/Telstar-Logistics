<template>
    <button
        class="btn d-flex flex-column align-items-center justify-content-center rounded my-1 w-100"
        :class="checked && 'bg-telstar-primary'"
        type="button"
        @click=";(checked = !checked), $emit('click', checked)"
    >
        <font-awesome-icon :icon="icon" class="fa-2x m-2" />
        <label>{{ label }}</label>
    </button>
</template>

<script>
export default {
    name: 'IconBtn',
    data() {
        return {
            checked: false,
        }
    },
    props: {
        label: { type: String, required: true },
        icon: { type: String, required: true },
    },
    emits: ['click'],
}
</script>
