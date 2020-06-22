<template>
    <v-app id="mcccodes">
        <v-data-table
                :headers="headers"
                :items="codes"
                :items-per-page="5"
                :page.sync="page"
                hide-default-footer
                class="elevation-1"
        ></v-data-table>
        <div class="text-center pt-2">
            <v-pagination v-model="page" :length="pageCount"></v-pagination>
        </div>
    </v-app>
</template>

<script>
    import {HTTP} from "@/http-common";

    export default {
        name: "MccCodes",
        data: () => ({
            page: 1,
            headers: [
                { text: 'Код', value: 'code' },
                { text: 'Наименование', value: 'name' }
            ],
            codes: []
        }),
        mounted() {
            HTTP.get('mcccode')
                .then(resp => this.codes = resp.data);
        }
    }
</script>

<style scoped>

</style>