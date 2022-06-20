import $api, {API_URL} from "../http";

export default class AuthService {

    static async current()  {
        return $api.get(`${API_URL}/auth/current`)
    }

    static async login(payload)  {
        return $api.post(`${API_URL}/auth/login`, payload)
    }

    static async registration(payload) {
        return $api.post( `${API_URL}/auth/register`, payload)
    }

    static async logout() {
        return $api.post(`${API_URL}/auth/logout`)
    }

}