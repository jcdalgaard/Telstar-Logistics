<template>
    <div class="average-cost-table table-responsive p-4">
        <table class="table table-striped table-bordered">
            <thead>
                <tr>
                    <th scope="col">City</th>
                    <th scope="col">Average cost</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="row in data" :key="row.id">
                    <td>{{ row.name }}</td>
                    <td>{{ row.value | currency }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: 'AverageCostTable',
    props: {
        data: {
            type: Array,
            default: () => [],
        },
    },
}
</script>

<style scoped></style>
