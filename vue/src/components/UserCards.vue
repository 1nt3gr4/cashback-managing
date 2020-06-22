<template>
    <v-app id="user-cards">
        <v-content class="pa-0">
            <v-container class="ma-5">
                <h1>Мои карты</h1>
            </v-container>
            <v-container fluid>
                <v-row dense>
                    <v-col
                            v-for="card in cards"
                            :key="card.id"
                            :cols="4"
                    >
                        <card-small v-bind:card="card" v-if="card.hasCurrentUser"></card-small>
                    </v-col>
                </v-row>
            </v-container>
        </v-content>
    </v-app>
</template>

<script>
    import CardSmall from "@/components/CardSmall";
    import {HTTP} from "@/http-common";

    export default {
        name: "UserCards",
        components: { CardSmall },
        data: () => ({
            cards: []
        }),
        mounted() {
            HTTP.get('card?userOnly=true')
                .then(resp => this.cards = resp.data);
        }
    }
</script>

<style scoped>

</style>