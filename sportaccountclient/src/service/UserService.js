import $api, {API_URL} from "../http";

export default class UserService {

    static async Index()  {
        const res = await $api.get(`${API_URL}/user`);
        return res.data;
    }
    static async IndexCoach()  {
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

    static async AddToGroup(groupId, userId) {
        const res = await $api.post(`${API_URL}/user/${userId}/group/${groupId}`);
        return res.data;
    }

    static async DeleteGroup(groupId, userId) {
        const res = await $api.delete(`${API_URL}/user/${userId}/group/${groupId}`);
        return res.data;
    }
}