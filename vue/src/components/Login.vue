<template>
    <v-app id="login">
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
                                <v-toolbar-title>Войти</v-toolbar-title>
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
                                            id="password"
                                            label="Пароль"
                                            v-model="model.password"
                                            prepend-icon="mdi-lock"
                                            type="password"
                                    />
                                </v-form>
                            </v-card-text>
                            <v-card-actions>
                                <v-btn href="register" color="secondary">Регистрация</v-btn>
                                <v-spacer/>
                                <v-btn color="primary" v-on:click="tryLogin">Войти</v-btn>
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
    import {HTTP} from "@/http-common";
    import {mapState} from 'vuex';

    export default {
        name: 'Login',
        props: {
            source: String,
        },
        data: () => ({
            loading: false,
            model: {
                login: null,
                password: null
            }
        }),
        computed: mapState(['isLoggedIn']),
        methods: {
            tryLogin() {
                this.loading = true;
                HTTP.post('login', this.model).then(resp => {
                    localStorage.setItem('access_token', resp.data.access_token);
                    localStorage.setItem('username', resp.data.username);
                    localStorage.setItem('expires', resp.data.expires);
                    HTTP.defaults.headers.Authorization = `Bearer ${resp.data.access_token}`;
                    this.loading = false;
                    this.$store.dispatch('login', {
                        username: resp.data.username
                    });
                    this.$router.push('/');
                }).catch(err => {
                    console.log(err);
                    this.loading = false;
                });
            }
        }
    }
</script>