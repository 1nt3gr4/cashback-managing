import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        isLoggedIn: Boolean(localStorage.getItem('access_token')) &&
            new Date(localStorage.getItem('expires')) >= Date.now(),
        username: localStorage.getItem('username')
    },
    getters: {
        isLoggedIn: state => state.isLoggedIn,
        username: state => state.username
    },
    mutations: {
        updateIsLoggedIn(state, isLoggedIn) {
            if (!isLoggedIn) {
                localStorage.removeItem('access_token');
                localStorage.removeItem('username');
            }
            Vue.set(state, 'isLoggedIn', isLoggedIn);
        },
        updateUsername(state, username) {
            Vue.set(state, 'username', username);
        }
    },
    actions: {
        login({ commit }, username) {
            commit('updateIsLoggedIn', true);
            commit('updateUsername', username);
        },
        logout({ commit }) {
            commit('updateIsLoggedIn', false);
            commit('updateUsername', null);
        }
    }
});