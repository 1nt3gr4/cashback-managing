<template>
    <v-form v-model="valid">
        <v-container
                class="fill-height"
                fluid
        >
            <v-row
            >
                <v-col
                        cols="12"
                        sm="8"
                        md="4"
                >
                    <v-card class="elevation-12">
                        <v-toolbar
                                color="primary"
                                dark
                                flat
                        >
                            <v-toolbar-title>Добавить новую карту</v-toolbar-title>
                        </v-toolbar>
                        <v-card-text>
                            <v-form>
                                <v-text-field
                                        id="shortName"
                                        label="Наименование"
                                        v-model="model.shortName"
                                        type="text"
                                />
                                <v-text-field
                                        id="minCostPerYear"
                                        label="Стоимость обслуживания в рублях в год, от"
                                        v-model="model.minCostPerYear"
                                        type="text"
                                />
                                <v-file-input
                                        v-model="model.file"
                                        label="Фотография"
                                        accept="image/*"
                                />
                            </v-form>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn type="button" @click="submit" color="primary">Добавить</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        <v-overlay :value="loading">
            <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>
    </v-form>
</template>

<script>
    import {HTTP} from "@/http-common";

    export default {
        name: "AddCard",
        data: () => ({
            loading: false,
            valid: true,
            model: {
                shortName: null,
                minCostPerYear: null,
                cashbackLimitInRubles: null,
                file: null,
                base64Image: null
            }
        }),
        methods: {
            submit: function () {
                const me = this;
                this.loading = true;

                if (this.model.file) {
                    const promise = this.getBase64(this.model.file);
                    promise.then(function (result) {
                        me.model.base64Image = result;
                        HTTP.post('card/create', me.model)
                            .then(() => {
                                me.loading = false;
                                me.$router.push('home/cards');
                            })
                            .catch(() => me.loading = false);
                    })
                } else {
                    HTTP.post('card/create', this.model)
                        .then(() => {
                            me.loading = false;
                            me.$router.push('home/cards');
                        })
                        .catch(() => me.loading = false);
                }
            },
            getBase64: function (file) {
                return new Promise(function (resolve, reject) {
                    const reader = new FileReader();
                    reader.onload = function () { resolve(reader.result) };
                    reader.onerror = reject;
                    reader.readAsDataURL(file);
                });
            }
        },
    }
</script>

<style scoped>

</style>