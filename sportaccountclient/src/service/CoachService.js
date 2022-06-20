import $api, {API_URL} from "../http";

export default class CoachService {

    static async index(payload)  {
        return $api.get(`${API_URL}/user/coach`);
    }

    static async show(id)  {
        return $api.get(`${API_URL}/user/coach/${id}`);
    }

}