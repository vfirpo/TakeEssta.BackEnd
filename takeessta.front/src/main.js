
import { createApp } from 'vue'
import App from './App.vue'
import 'jquery'
import 'popper.js'
import 'bootstrap'
import './assets/app.css'
import 'vue-router'

export const eventBus = createApp(App)

createApp(App).mount('#appmenu')

///------------------------------------------

