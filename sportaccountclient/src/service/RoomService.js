import $api, {API_URL} from "../http";

export default class RoomService {

    static async Index()  {
        return await $api.get(`${API_URL}/room`);
    }

    static async Show(id) {
        return $api.get( `${API_URL}/room/${id}`)
    }

    static async Add(payload) {
        const res = await $api.post( `${API_URL}/room`,
            JSON.stringify(payload),
            {
                headers: {'Content-Type': 'application/json'}})
        return res.data;
    }

    static async Update(payload) {
        return $api.put(`${API_URL}/room`, payload)
    }

    static async Delete(id) {
        return $api.delete(`${API_URL}/room/${id}`)
    }

}