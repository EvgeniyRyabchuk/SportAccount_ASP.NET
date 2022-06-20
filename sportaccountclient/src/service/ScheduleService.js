import $api, {API_URL} from "../http";

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