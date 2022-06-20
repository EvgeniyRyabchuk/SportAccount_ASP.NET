import React, {useEffect, useState} from 'react';

import {useParams} from "react-router-dom";
import CoachService from "../../service/CoachService";
import CoachCard from "../../components/coach/CoachCard";

const CoachShow = () => {

    const { coachId } = useParams();
    const [coach, setCoach] = useState(null);

    const getCoach = async () => {
        const res = await CoachService.show(coachId);
        const data = res.data;
        console.log(data);
        setCoach(data);
    }

    useEffect(() => {
        getCoach();
    }, [])


    return (
        <div className='mt-5 px-5 py-5'>
            WorkDayListPage
            {
                coach ?
                    <CoachCard coach={coach} />
                    : ''
            }


        </div>
    );
};

export default CoachShow;