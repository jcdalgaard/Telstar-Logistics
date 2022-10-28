import Vue from 'vue'

export const login = Vue.observable({
    isLoggedIn: false,
    loggedInUser: '',
})

export const language = Vue.observable({
    current: 'English',
})
