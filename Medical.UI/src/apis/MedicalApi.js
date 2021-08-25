import axios from "axios";
import store from "../store"

const BASEURL = process.env.VUE_APP_RECRUITMENTAPI_URL;


const recruitmentApi = axios.create({
    baseURL: BASEURL
});

recruitmentApi.interceptors.request.use(
    config => {
        if (!config.url.includes('AuthenticateADUser')) {
            const token = localStorage.getItem("token");
            config.headers = {
                'Authorization': 'Bearer ' + token
            }
        }
        return config;
    }
)

recruitmentApi.interceptors.response.use(null, function (error) {
    if (error.response.status == 401 || error.response.status == 403) {
        localStorage.removeItem("token");
        store.commit("RESET_USER_TOKEN");
        window.location.href = '#/';
    }
}
)

export default recruitmentApi;
