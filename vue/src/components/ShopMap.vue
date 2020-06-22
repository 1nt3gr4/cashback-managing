<template>
    <v-container v-if="isLoggedIn">
        <h2>Магазины с кэшбэком поблизости:</h2>
        <div id="map" style="width: 600px; height: 400px"></div>
    </v-container>
</template>

<script>
    /* eslint no-undef: 0 */
    import {HTTP} from "@/http-common";
    import {mapState} from "vuex";

    export default {
        name: "ShopMap",
        computed: mapState(['isLoggedIn', 'username']),
        props: {
            card: Object
        },
        mounted: function () {
            const me = this;
            this.isLoggedIn && ymaps.ready(function () {
                const location = ymaps.geolocation.get(),
                    map = new ymaps.Map("map", {
                        center: [55.78670137, 49.12091617],
                        zoom: 12
                    });

                location.then(function (result) {
                    map.geoObjects.add(result.geoObjects);
                    map.setCenter(result.geoObjects.position);
                    return HTTP.post('shop/list' + (me.card ? `/${me.card.id}` : ''), result.geoObjects.position);
                }).then(function (result) {
                    const objects = result.data;
                    objects.forEach(obj =>
                        map.geoObjects
                            .add(new ymaps.Placemark([obj.position[0], obj.position[1]], {
                                hintContent: me.card
                                    ? `<b>${obj.name}</b><br/>Кэшбэк по карте: до ${obj.cardCashbacks[0].cashbackPercentTo}%`
                                    : `<b>${obj.name}</b><br/>Карты с кэшбэком:<ul>` +
                                    obj.cardCashbacks.map(c => `<li>${c.cardName}: до ${c.cashbackPercentTo}%</li>`)
                                        .join(';') + '<ul/>'
                            })));
                });
            });
        }
    }
</script>

<style scoped>

</style>