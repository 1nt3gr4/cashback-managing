import Register from "./components/Register";
import Vue from 'vue';
import VueRouter from 'vue-router';
import Login from "@/components/Login";
import Home from "@/components/Home";
import Cards from "@/components/Cards";
import CardDetails from "@/components/CardDetails";
import UserCards from "@/components/UserCards";
import MccCodes from "@/components/MccCodes";
import AddCard from "@/components/AddCard";
import Main from "@/components/Main";

Vue.use(VueRouter);

const router = new VueRouter({
    mode: 'history',
    base: __dirname,
    routes: [
        { path: '/', redirect: '/home/main' },
        {
            path: '/home', component: Home,
            children: [
                { path: 'main', component: Main },
                { path: 'cards', component: Cards },
                { path: 'usercards', component: UserCards },
                { path: 'carddetails/:id', component: CardDetails, props: true },
                { path: 'mcccodes', component: MccCodes },
                { path: 'addcard', component: AddCard }
            ]
        },
        { path: '/login', component: Login },
        { path: '/register', component: Register }
    ]
})

export default router;