<template>
    <v-app id="cards">
        <v-content class="pa-0">
            <v-container class="ma-5">
                <h1>Карты</h1>
            </v-container>
            <v-container fluid>
                <v-row dense>
                    <v-col
                            v-for="card in cards"
                            :key="card.id"
                            :cols="4"
                    >
                        <card-small v-bind:card="card"></card-small>
                    </v-col>
                </v-row>
            </v-container>
        </v-content>
    </v-app>
</template>

<script>
    import {HTTP} from "@/http-common";
    import CardSmall from "@/components/CardSmall";

    export default {
        name: "Cards",
        components: { CardSmall },
        data: () => ({
            cards: []
        }),
        mounted() {
            HTTP.get('card')
                .then(resp => this.cards = resp.data);
        }
    }
</script>

<style scoped>

</style>