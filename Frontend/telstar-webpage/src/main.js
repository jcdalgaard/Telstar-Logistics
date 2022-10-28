import Vue from 'vue'
import App from './App.vue'
import router from './router'
import Axios from 'axios'
import { BootstrapVue } from 'bootstrap-vue'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import {
    faMagnifyingGlass,
    faPaperPlane,
    faSnowflake,
    faPaw,
    faMartiniGlass,
    faChevronRight,
    faX,
    faChevronDown,
    faPenToSquare,
    faPlus,
} from '@fortawesome/free-solid-svg-icons'

/* add icons to the library */
library.add(
    faMagnifyingGlass,
    faPaperPlane,
    faSnowflake,
    faPaw,
    faMartiniGlass,
    faChevronRight,
    faX,
    faChevronDown,
    faPenToSquare,
    faPlus
)

/* add font awesome icon component */
Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.use(BootstrapVue)

Vue.prototype.$http = Axios

Vue.config.productionTip = false

Vue.filter('currency', function (value) {
    if (typeof value !== 'number') {
        return value
    }
    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
    })
    return formatter.format(value)
})

new Vue({
    router,
    render: (h) => h(App),
}).$mount('#app')
