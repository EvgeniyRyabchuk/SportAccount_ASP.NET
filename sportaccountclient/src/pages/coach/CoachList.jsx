import React, {useEffect, useState} from 'react';
import CoachService from "../../service/CoachService";
import UserFullName from "../../components/UserFullName";


const CoachList = () => {

    const [coachList, setCoachList] = useState([]);

    const getCoachList = async () => {
        const res = await CoachService.index();
        const data = res.data;
        console.log(data);
        setCoachList(data);
    }


    useEffect(() => {
        getCoachList();
    }, []);

    console.log('123')
    return (
        <div style={{padding: '30px 40px'}}>
            Coach List
            <ul className={'mt-5'}>
                {coachList.length > 0 ? coachList.map(e =>
                    <li className='d-flex justify-content-between' id={e.id}>

                        <div>
                            <span className='field-title'>Full Cach Name: </span>
                            <span className='field-value'>
                                <UserFullName data={e}/>
                            </span>
                        </div>

                        <div>
                            <span className='field-title'>Specialization </span>
                            <span className='field-value'> {e.specialization.name} </span>
                        </div>

                        <div>
                            <a className='btn btn-info mx-1'
                               type='button'
                               href={`/coach/${e.id}`}>
                                View coach profile
                            </a>
                            <a className='btn btn-primary mx-1'
                               type='button'
                               href={`/coach/${e.id}/schedule/workday`}>
                                Show Schedule
                            </a>
                        </div>

                    </li>
                ) : ''}
            </ul>
        </div>
    );
};

export default CoachList;