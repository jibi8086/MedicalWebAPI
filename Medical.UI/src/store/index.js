import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

import state from './state'
import * as mutations from './mutations'
import * as actions from './actions'
Vue.use(Vuex)

export default new Vuex.Store({
    plugins: [createPersistedState({
        storage: window.sessionStorage,
    })],
    state () {
        return { ...state }
    },
    mutations,
    actions,
    modules: {
    },
})
