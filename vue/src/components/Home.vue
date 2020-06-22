<template>
    <v-app id="home">
        <v-navigation-drawer
                v-model="drawer"
                app
        >
            <v-list dense v-if="isLoggedIn">
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-home-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/main">Главная</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-credit-card-multiple-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/cards">Все карты</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-credit-card-check-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/usercards">Мои карты</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-numeric</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/mcccodes">Категории (MCC-коды)</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-store-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/shops">Магазины по категориям</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-credit-card-plus-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/addcard">Добавить новую карту</router-link>
                    </v-list-item-content>
                </v-list-item>
                <v-list-item link>
                    <v-list-item-action>
                        <v-icon>mdi-home-plus-outline</v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <router-link to="/home/addshop">Добавить магазин</router-link>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>

        <v-app-bar
                app
                color="indigo"
                dark
        >
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"/>
            <v-spacer/>
            <v-btn href="/login" color="primary" v-if="!isLoggedIn">Войти</v-btn>
            <v-btn v-on:click="logout" color="primary" v-if="isLoggedIn">Выйти</v-btn>
        </v-app-bar>
        <router-view></router-view>
        <v-footer
                color="indigo"
                app
        >
            <span class="white--text">&copy; 2020</span>
        </v-footer>
    </v-app>
</template>

<script>
    /* eslint no-undef: 0 */
    import {mapState} from 'vuex';

    export default {
        props: {
            source: String,
        },
        data: () => ({
            drawer: null
        }),
        computed: mapState(['isLoggedIn', 'username']),
        methods: {
            logout() {
                this.$store.dispatch('logout');
            }
        },

    }
</script>