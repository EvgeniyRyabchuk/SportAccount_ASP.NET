import React, {useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import CoachService from "../service/CoachService";
import GroupService from "../service/GroupService";
import UserFullName from "./UserFullName";

const MemberList = () => {
    const { groupId } = useParams();

    const [ group, setGroup ] = useState(null);


    const getGroup =  async () => {
        const res = await GroupService.Show(groupId);
        const data = res.data;
        console.log(data);
        setGroup(data);
    }

    useEffect(() => {
        getGroup();
    }, [])
    return (
        <div>
            <h1>Group Name: {group ? group.group.name : ''}</h1>
            <ul className={'my-5 mx-auto'} style={{width: '200px'}}>
                {
                    group ? group.users.map(e =>
                        <li>
                            <Link to={`/profile/${e.id}`}>
                                <UserFullName data={e}/>
                            </Link>

                        </li>
                    )
                        : ''

                }
            </ul>
        </div>
    );
};

export default MemberList;