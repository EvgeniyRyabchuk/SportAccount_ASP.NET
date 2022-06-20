import React, {useEffect, useState} from 'react';
import {useParams} from "react-router-dom";
import GroupService from "../../service/GroupService";
import UserService from "../../service/UserService";
import getAge from "../../helpers/date";

const Profile = () => {
    const { userId } = useParams();

    const [ user, setUser ] = useState(null);

    const getUser =  async () => {
        const res = await UserService.Show(userId);
        const data = res.data;
        console.log(data);
        setUser(data);
    }

    useEffect(() => {
        getUser();
    }, [])
    return (
        <div>
            <h1>Profile</h1>
            <br/>
            <br/>
            <br/>
            {
                user ?
                    <div>
                        <h2> {
                            `${user.firstName} 
                            ${user.lastName}
                            ${user.middleName}`
                        }
                        </h2>
                        <p>
                            Sex: {user.sex.name}
                        </p>
                        {user.role.name == 'Coach' ?
                                <div>
                                    <p>
                                        Spec: {user.specialization.name}
                                    </p>
                                    <p>
                                        Status: 1
                                    </p>
                                </div>
                            : ''
                        }
                        <p>
                            Age: {getAge(user.birthDate)}
                        </p>
                        <p>
                            Phones:

                            <ul className='mx-auto' style={{width: '200px'}}>
                                {
                                    user.phones.map(e =>

                                        <li id={e.id}>
                                            {e.number}
                                        </li>)
                                }
                            </ul>

                        </p>
                    </div>
                    : ''
            }

        </div>
    );
};

export default Profile;