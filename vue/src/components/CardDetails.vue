<template>
    <v-card v-bind:cardId="card.id" class="ma-5">
        <v-img
                :src="card.base64Image"
                class="white--text align-end ma-5"
                gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                max-height="300px"
                max-width="300px"
        >
            <v-row>
                <v-card-title v-text="card.shortName"></v-card-title>
                <v-spacer/>
                <v-btn
                        color="primary" align="center"
                        v-bind:cardId="card.id"
                        v-if="!card.hasCurrentUser"
                        class="ma-4"
                        v-on:click="addCard"
                >
                    Добавить
                </v-btn>
                <v-alert color="success" class="ma-4" v-else>Добавлена</v-alert>
            </v-row>
        </v-img>
        <v-card-text>
            <ul>
                <li>Стоимость обслуживания в год, от: {{ card.minCostPerYear }}Р</li>
                <li>Кэшбек до {{ card.maxCashbackPercent }}%</li>
                <li>Кэшбек до {{ card.cashbackLimitInRubles }}Р в мес.</li>
            </ul>
            <v-container v-if="card.cardMccCodeCashbacks.length > 0">
                Кэшбек по категориям:
                <ul>
                    <li v-for="item in card.cardMccCodeCashbacks" :key="item.id">
                        MCC-код: {{ item.mccCode.code }} ({{ item.mccCode.name }}) - {{ item.cashbackPercent }}%
                    </li>
                </ul>
            </v-container>
            <shop-map v-bind:card="card"></shop-map>
        </v-card-text>
    </v-card>
</template>

<script>
    import {HTTP} from "@/http-common";
    import ShopMap from "@/components/ShopMap";

    export default {
        name: "CardDetails",
        components: { ShopMap },
        data: () => ({
            card: null
        }),
        props: {
            id: Number
        },
        mounted() {
            HTTP.get(`card/${this.id}`)
                .then(resp => this.card = resp.data);
        }
    }
</script>

<style scoped>

</style>