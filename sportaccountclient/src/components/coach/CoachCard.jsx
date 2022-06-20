import React from 'react';
import getAge from "../../helpers/date";

const CoachCard = ({coach}) => {
    return (
        <div  className='mt-5 shadow-box'>
            <h3>
                Full Name:
                {` ${coach.firstName} 
                        ${coach.lastName} 
                        ${coach.middleName}`}
            </h3>
            <p>
                Sex: {coach.sex.name}
            </p>
            <p>
                Spec: {coach.specialization.name}
            </p>
            <p>
                Age: {getAge(coach.birthDate)}
            </p>
            <p>
                Phones:

                <ul className='mx-auto' style={{width: '200px'}}>
                    {
                        coach.phones.map(e =>

                            <li id={e.id}>
                                {e.number}
                            </li>)
                    }
                </ul>

            </p>
        </div>
    );
};

export default CoachCard;