import axios from 'axios';
import UserContext from "../context/UserContext";

export const API_URL = `https://localhost:44313/api`;

const $api = axios;

// const $api = axios.create({
//     withCredentials: true,
//     baseURL: API_URL
// })

$api.interceptors.request.use((config) => {
    config.withCredentials = true;
    config.headers.Authorization = `Bearer ${localStorage.getItem('token')}`
    return config;
})

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
            //TODO: check if cookie exist
            const response = await fetch(`${API_URL}/auth/refresh-token`,
                {
                    credentials: "include",
                    method: 'POST'
                }
            );
            const data = await response.json();
            localStorage.setItem('token', data.accessToken);
            originalRequest.headers.Authorization = `Bearer ${localStorage.getItem('token')}`;

            return $api.request(originalRequest);
        } catch (e) {

            console.log('НЕ АВТОРИЗОВАН')
            throw new Error('Not auth');
        }
    }
    throw error;
})

export default $api;
