import axios from 'axios'
// import store from '../store'

const BASEURL = process.env.VUE_APP_MEDICALAPI_URL

const medicalApi = axios.create({
    baseURL: BASEURL,
})
console.log(BASEURL)
// medicalApi.interceptors.request.use(
//     config => {
//         if (!config.url.includes('AuthenticateADUser')) {
//             const token = localStorage.getItem('token')
//             config.headers = {
//                 Authorization: 'Bearer ' + token,
//             }
//         }
//         return config
//     },
// )

// medicalApi.interceptors.response.use(null, function (error) {
//     if (error.response.status === 401 || error.response.status === 403) {
//         localStorage.removeItem('token')
//         store.commit('RESET_USER_TOKEN')
//         window.location.href = '#/'
//     }
// },
// )

export default medicalApi
