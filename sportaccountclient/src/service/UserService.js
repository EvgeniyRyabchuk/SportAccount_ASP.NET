import $api, {API_URL} from "../http";

export default class UserService {

    static async Index()  {
        return $api.get(`${API_URL}/user/coach`)
    }

    static async Show(id) {
        return $api.get( `${API_URL}/user/${id}`)
    }

    static async Update(payload) {
        return $api.put(`${API_URL}/user`, payload)
    }

    static async Delete(id) {
        return $api.delete(`${API_URL}/user/${id}`)
    }

}