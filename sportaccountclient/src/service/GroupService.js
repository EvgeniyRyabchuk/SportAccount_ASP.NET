import $api, {API_URL} from "../http";

export default class GroupService {

    static async Index()  {
        return await $api.get(`${API_URL}/group`);
    }

    static async Show(id) {
        return $api.get( `${API_URL}/group/${id}`)
    }

    static async Update(payload) {
        return $api.put(`${API_URL}/user`, payload)
    }

    static async Delete(id) {
        return $api.delete(`${API_URL}/user/${id}`)
    }

}