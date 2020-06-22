<template>
    <v-card v-bind:cardId="card.id" @click="openCardDetails">
        <v-img
                :src="card.base64Image"
                class="white--text align-end"
                gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
        >
            <v-row>
                <v-card-title v-text="card.shortName"></v-card-title>
                <v-spacer/>
                <v-btn
                        v-bind:color="buttonColor"
                        class="ma-4"
                        @click.stop="addOrRemoveCard"
                        @mouseover="btnMouseOver"
                        @mouseleave="btnMouseLeave"
                >
                    {{ buttonText }}
                </v-btn>
            </v-row>
        </v-img>
        <v-card-text>
            <ul>
                <li>Стоимость обслуживания в год, от: {{ card.minCostPerYear }}Р</li>
                <li>Кэшбек до {{ card.maxCashbackPercent }}%</li>
                <li>Кэшбек до {{ card.cashbackLimitInRubles }}Р в мес.</li>
            </ul>
        </v-card-text>
    </v-card>
</template>

<script>
    import {HTTP} from "@/http-common";

    export default {
        name: "CardSmall",
        data: () => ({
            buttonText: '',
            buttonColor: ''
        }),
        props: {
            card: Object
        },
        mounted() {
            this.buttonText = this.card.hasCurrentUser ? 'Добавлена' : 'Добавить';
            this.buttonColor = this.card.hasCurrentUser ? 'success' : 'primary';
        },
        methods: {
            addOrRemoveCard() {
                HTTP.post(`usercard/${this.card.hasCurrentUser ? 'delete' : 'add'}/${this.card.id}`)
                    .then(() => {
                        this.card.hasCurrentUser = !this.card.hasCurrentUser;
                        this.buttonText = this.card.hasCurrentUser ? 'Добавлена' : 'Добавить';
                        this.buttonColor = this.card.hasCurrentUser ? 'success' : 'primary';
                    });
            },
            openCardDetails() {
                this.$router.push(`carddetails/${this.card.id}`);
            },
            btnMouseOver() {
                if (!this.card.hasCurrentUser)
                    return;

                this.buttonText = 'Удалить';
                this.buttonColor = 'error';
            },
            btnMouseLeave() {
                if (!this.card.hasCurrentUser)
                    return;

                this.buttonText = 'Добавлена';
                this.buttonColor = 'success';
            }
        }
    }
</script>

<style scoped>

</style>