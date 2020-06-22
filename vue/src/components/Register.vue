<template>
    <v-app id="register">
        <v-content>
            <v-container
                    class="fill-height"
                    fluid
            >
                <v-row
                        align="center"
                        justify="center"
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
                                <v-toolbar-title>Регистрация</v-toolbar-title>
                            </v-toolbar>
                            <v-card-text>
                                <v-form>
                                    <v-text-field
                                            label="Логин"
                                            v-model="model.login"
                                            prepend-icon="mdi-account"
                                            type="text"
                                    />
                                    <v-text-field
                                            label="E-mail"
                                            v-model="model.email"
                                            prepend-icon="mdi-at"
                                            type="text"
                                    />
                                    <v-text-field
                                            id="password-confirm"
                                            label="Пароль"
                                            v-model="model.password"
                                            prepend-icon="mdi-lock"
                                            type="password"
                                    />
                                    <v-text-field
                                            id="password"
                                            label="Подтверждение пароля"
                                            v-model="model.passwordConfirm"
                                            prepend-icon="mdi-lock"
                                            type="password"
                                    />
                                </v-form>
                            </v-card-text>
                            <v-card-actions>
                                <v-btn href="/" color="secondary">На главную</v-btn>
                                <v-spacer/>
                                <v-btn color="primary" v-on:click="submit">Зарегистрироваться</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-col>
                </v-row>
            </v-container>
        </v-content>
        <v-overlay :value="loading">
            <v-progress-circular indeterminate size="64"></v-progress-circular>
        </v-overlay>
    </v-app>
</template>

<script>
    import axios from "axios";

    export default {
        name: "Register",
        data: () => ({
            loading: false,
            model: {
                login: null,
                email: null,
                password: null,
                passwordConfirm: null
            }
        }),
        methods: {
            submit() {
                this.loading = true;
                axios.post('https://localhost:5001/account/register', this.model).then(resp => {
                    console.log(resp);
                    this.loading = false;
                }).catch(err => {
                    console.log(err);
                    this.loading = false;
                });
            }
        }
    }
</script>