<template>
    <div class="dropdown">
        <div class="input-group input-group-lg">
            <input
                v-model="value"
                @input="debounceSearch"
                @focus="showOptions = true"
                @blur="showOptions = false"
                type="text"
                class="form-control"
                :disabled="disabled"
                :placeholder="placeholder"
                required="required"
            />
            <span class="input-group-text" id="addon-wrapping"
                ><font-awesome-icon icon="fa-solid fa-magnifying-glass"
            /></span>
        </div>
        <div
            class="dropdown-menu dropdown-max-height w-100 mt-0"
            :class="showOptions && 'show'"
            role="button"
        >
            <span
                v-show="searchOptions.length === 0 && !loading"
                class="dropdown-item disabled"
                >{{ noResultsMessage }}</span
            >
            <span
                v-show="searchOptions.length === 0 && loading"
                class="dropdown-item disabled"
            >
                <div class="spinner-border spinner-border-sm" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
                {{ loadingText }}
            </span>
            <div
                class="dropdown-item"
                @mousedown="selectOption(option)"
                v-for="(option, index) in searchOptions"
                :key="`route-option-${index}`"
            >
                {{ option.name }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'SearchDropdown',
    components: {},
    emits: ['setRoute'],
    props: {
        placeholder: {
            type: String,
            default: 'Search',
        },
        noResultsMessage: {
            type: String,
            default: 'No results...',
        },
        loadingText: {
            type: String,
            default: 'Loading...',
        },
        options: {
            type: Array,
        },
        disabled: {
            type: Boolean,
            default: false,
        },
        label: { type: String, default: null },
        loading: {
            type: Boolean,
            default: false,
        },
    },
    data() {
        return {
            value: '',
            showOptions: false,
            debounce: null,
            debounceTimeout: 600,
            icon: true,
        }
    },
    computed: {
        searchOptions() {
            if (Array.isArray(this.options))
                return this.options.filter((option) =>
                    option.name.toLowerCase().includes(this.value.toLowerCase())
                )
            else return []
        },
    },
    methods: {
        debounceSearch(event) {
            clearTimeout(this.debounce)
            this.debounce = setTimeout(() => {
                this.value = event.target.value
            }, this.debounceTimeout)
        },
        selectOption(option) {
            this.value = option.name
            this.$emit('setRoute', option)
        },
    },
    watch: {
        options() {
            return this.options
        },
    },
}
</script>

<style>
.dropdown-max-height {
    overflow-y: scroll;
    overflow: auto;
    max-height: 250px;
}

.dropdown-content {
    position: absolute;
    background-color: #fff;
    width: 100%;
    height: fit-content;
    max-width: 100%;
    box-shadow: 0px -8px 34px 0px rgba(0, 0, 0, 0.05);
    z-index: 1;
}
</style>
