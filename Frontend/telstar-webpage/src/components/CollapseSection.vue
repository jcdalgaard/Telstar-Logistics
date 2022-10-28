<template>
    <button
        class="btn bg-telstar-primary-light p-2 my-2 rounded shadow-sm w-100 text-start"
    >
        <div
            class="row d-flex align-items-center collapsed"
            data-bs-toggle="collapse"
            :data-bs-target="`#collapse-${header
                .toLowerCase()
                .replace(/\s/g, '-')}-${index}`"
            aria-expanded="false"
            :title="header"
        >
            <div class="col py-2 px-3">
                {{ header }}
            </div>
            <div class="col-auto">
                <font-awesome-icon
                    icon="fa-solid fa-chevron-down"
                    class="chevron-icon"
                />
            </div>
        </div>
        <div
            class="collapse px-2"
            :id="`collapse-${header
                .toLowerCase()
                .replace(/\s/g, '-')}-${index}`"
        >
            <slot></slot>
        </div>
    </button>
</template>

<script>
export default {
    name: 'CollapseSection',
    components: {},
    props: {
        header: { type: String, required: true },
        index: { type: Number, required: true },
    },
}
</script>

<style>
.bg-beige {
    background-color: #f8f0dd;
}
.collapsed .chevron-icon {
    transform: rotate(-90deg);
}

.chevron-icon {
    transition: all 0.5s;
}
</style>
