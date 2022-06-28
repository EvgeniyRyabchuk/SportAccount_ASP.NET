import axios from 'axios';
import UserContext from "../context/UserContext";

 export const API_URL = `https://localhost:44313/api`;
//export const API_URL = `https://sportaccountapi20220622105333.azurewebsites.net/api`;

const $api = axios;

// const $api = axios.create({
//     withCredentials: true,
//     baseURL: API_URL
// })

$api.interceptors.request.use((config) => {
    config.withCredentials = true;
    config.headers.Authorization = `Bearer ${localStorage.getItem('token')}`;
    config.headers.cacheControl = 'no-cache';
    config.headers.pragma = 'no-cache';

    return config;
})

//TODO: check if cookie exist
function isCookieExist(cookieName) {
    console.log('123');
    const theCookies = document.cookie.split(';');
    for (let i of theCookies) {
        if(i == cookieName)
            return true;
    }
    return false;
}

$api.interceptors.response.use((config) => {
    return config;
},async (error) => {
    const originalRequest = error.config;
    if (error.response.status == 401 && error.config && !error.config._isRetry) {
        originalRequest._isRetry = true;
        try {

            const response = await fetch(`${API_URL}/auth/refresh-token`,
                {
                    credentials: "include",
                    method: 'POST'
                }
            );
            const data = await response.json();
            localStorage.setItem('token', data.accessToken);


            return $api.request(originalRequest);
        } catch (e) {
            if (error.response.status == 401) {
                // redirect to login form
                console.log('НЕ АВТОРИЗОВАН')
                throw new Error('Not auth');
            }
            throw e;
        }
    }
    throw error;
})

export default $api;
