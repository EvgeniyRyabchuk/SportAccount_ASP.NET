import React, {useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import CoachService from "../../../service/CoachService";
import ScheduleService from "../../../service/ScheduleService";
import {dateOnly, dateWordFormat, timeOnly} from "../../../helpers/date";
import UserFullName from "../../../components/UserFullName";

const WorkDayShowPage = () => {

    const { coachId, workdayId } = useParams();
    const [coach, setCoach] = useState(null);
    const [workdays, setWorkdays] = useState(null);
    const [workdouts, setWorkouts] = useState(null);

    const getCoach = async () => {
        const res = await CoachService.show(coachId);
        const data = res.data;
        console.log(data);
        setCoach(data);
    }

    const getWorkDay = async () => {
        const res = await ScheduleService.GetWorkDayById(coachId, workdayId);
        const data = res.data;
        console.log(data);
        setWorkdays(data);
    }

    const getWorkOuts = async () => {
        const res = await ScheduleService.GetWorkOutsByCoachId(coachId, workdayId);
        const data = res.data;
        console.log(data);
        setWorkouts(data);
    }

    useEffect(() => {
        getCoach();
        getWorkDay();
        getWorkOuts();
    }, [])


    return (
        <div className='px-3 py-3'>
            Work Day
            <div className='mt-5'>
                {
                    workdays ?
                           <h3> {dateWordFormat(workdays.date) } </h3> : ''
                }
                { coach ?
                    <p>
                        for {` ${coach.firstName} 
                        ${coach.lastName} 
                        ${coach.middleName}`}
                    </p> : ''}

                <ul className='mt-5 px-3 py-3'>
                    { workdouts ? workdouts.map(e =>
                        <li
                            style={{padding: '20px', border: '1px solid black'}}
                            id={e.id}
                            className='my-3 d-flex justify-content-between'
                            id={e.id}>
                            <div>
                                <span className='field-title'>Workday Start Time: </span>
                                <span className='field-value'> { timeOnly(e.start)} </span>
                            </div>
                            <div>
                                <span className='field-title'>Workday End Time: </span>
                                <span className='field-value'> {timeOnly(e.end)} </span>
                            </div>

                            { e.client ?
                                <div >
                                    <span className='field-title'> For Client Full Name: </span>
                                    <span className='field-value'>
                                        <Link to={`/profile/${e.client.id}`}>
                                            <UserFullName data={e.client}/>
                                        </Link>
                                    </span>
                                </div>
                            :
                                <div>
                                    <div>
                                        <span className='field-title'>For Group: </span>
                                        <span className='field-value'> {e.group.name} </span>
                                    </div>

                                    <a className='btn btn-primary mx-1'
                                        type='button'
                                        href={`/group/${e.group.id}`}>
                                        See Group Members
                                    </a>
                                </div>
                            }




                        </li>
                    ) : ''}
                </ul>

            </div>


        </div>
    );
};

export default WorkDayShowPage;