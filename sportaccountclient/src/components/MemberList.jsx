import React, {useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import CoachService from "../service/CoachService";
import GroupService from "../service/GroupService";
import UserFullName from "./UserFullName";
import {Button} from "react-bootstrap";
import UserService from "../service/UserService";

const MemberList = ({members, setMembers}) => {

    const { groupId } = useParams();
    const [ group, setGroup ] = useState(null);

    useEffect(() => {
        if(group && members) {
            console.log('members')
            group.users = members;
            setGroup({...group});
        }
    }, [members])

    const getGroup =  async () => {
        const res = await GroupService.Show(groupId);
        const data = res.data;
        console.log(data);
        setGroup({...data});
        setMembers(data.users);
    }

    const deleteUserFromGroup = async (userId) => {
        console.log(123)
        const data = await UserService.DeleteGroup(groupId, userId);
        setMembers(data);
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
                        <li className='d-flex' style={{minWidth: '500px'}}>
                            <Link className='px-3' to={`/profile/${e.id}`}>
                                <UserFullName data={e}/>
                            </Link>
                            <Button
                                className='px-3 ml-5'
                                variant='danger'
                                onClick={() => deleteUserFromGroup(e.id)}
                            >
                                Delete
                            </Button>
                        </li>
                    )
                        : ''
                }
            </ul>
        </div>
    );
};

export default MemberList;