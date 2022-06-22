import $api, {API_URL} from "../http";
import data from "bootstrap/js/src/dom/data";

export default class ScheduleService {

    static async GetWorkDaysByCoachId(coachid)  {
        return await $api.get(`${API_URL}/schedule/coach/${coachid}/workday`);
    }

    static async GetWorkDayById(coachid, workdayId)  {
        return await $api.get(`${API_URL}/schedule/coach/${coachid}/workday/${workdayId}`);
    }

    static async GetWorkOutsByCoachId(coachid, workdayId)  {
        return await $api.get
        (`${API_URL}/schedule/coach/${coachid}/workday/${workdayId}/workout`);
    }

    static async AddWorkOuts(coachid, workdayId, payload)  {
        return await $api.post
        (`${API_URL}/schedule/coach/${coachid}/workday/${workdayId}/workout`,
            JSON.stringify(payload), { headers: {
                    'Content-Type': 'application/json',
                }}
        );
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