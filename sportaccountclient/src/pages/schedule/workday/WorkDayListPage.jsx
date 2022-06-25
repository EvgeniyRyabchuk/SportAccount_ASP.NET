import React, {useContext, useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import CoachService from "../../../service/CoachService";

import ScheduleService from "../../../service/ScheduleService";
import CoachCard from "../../../components/coach/CoachCard";
import {Button} from "react-bootstrap";
import AddWorkDay from "../../../components/modals/AddWorkDay";
import {dateWordFormat, timeOnly} from "../../../helpers/date";
import UserContext from "../../../context/UserContext";

const WorkDayListPage = () => {
    const { coachId } = useParams();
    const [coach, setCoach] = useState(null);
    const [workdays, setWorkdays] = useState(null);
    const [show, setShow] = useState(false);
    const {user, setUser} = useContext(UserContext);

    const getCoach = async () => {
        const res = await CoachService.show(coachId);
        const data = res.data;
        console.log(data);
        setCoach(data);
    }
    const getWorkDays = async () => {
        const res = await ScheduleService.GetWorkDaysByCoachId(coachId);
        const data = res.data;
        console.log(data);
        setWorkdays(data);
    }

    useEffect(() => {
        getCoach();
        getWorkDays();
    }, [])

    console.log(workdays)

    return (
        <div className='mt-5 px-5 py-5'>
            WorkDayListPage
            {
                coach ?
                    <CoachCard coach={coach} />
                : ''}

            <br/>
            {user ? user.isLoggenIn && user.role.name == 'Admin' ?
                <Button
                    style={{width: '500px'}}
                    variant='dark'
                    onClick={() => setShow(true)}
                >Add WorkDay</Button>
            : '' : '' }

            <AddWorkDay
                show={show}
                setShow={setShow}
                setWorkdays={(data) => setWorkdays([...data])}
            />

            <ul className='mt-5 px-3 py-3  border-bottom'>
                { workdays ? workdays.map(e =>
                    <li id={e.id} className='d-flex justify-content-between' id={e.id}>

                        <div>
                            <span className='field-title'>Day: </span>
                            <span className='field-value'> {dateWordFormat(e.date)}</span>
                        </div>

                        <div>
                            <span className='field-title'>Workday Start Time: </span>
                            <span className='field-value'> { timeOnly(e.startTime)} </span>
                        </div>
                        <div>
                            <span className='field-title'>Workday End Time: </span>
                            <span className='field-value'> {timeOnly(e.endTime)} </span>
                        </div>

                        <a className='btn btn-primary mx-1'
                           type='button'
                           href={`/coach/${coachId}/schedule/workday/${e.id}`}>
                            See Workouts
                        </a>
                    </li>
                ) : ''}
        </ul>

        </div>
    );
};

export default WorkDayListPage;