import Vue from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import router from './Router';
import store from './store/user';

Vue.config.productionTip = false

new Vue({
    vuetify,
    render: h => h(App),
    router: router,
    store
}).$mount('#app')