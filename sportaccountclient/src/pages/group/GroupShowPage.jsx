import React, {useContext, useState} from 'react';
import MemberList from "../../components/MemberList";
import {Button, Form, Modal} from "react-bootstrap";
import AddUserToGroupModal from "../../components/modals/AddUserToGroupModal";
import {useParams} from "react-router-dom";
import UserContext from "../../context/UserContext";

const GroupShowPage = () => {

    const { groupId } = useParams();
    const [show, setShow] = useState(false);
    const [members, setMembers] = useState();
    const {user, setUser} = useContext(UserContext);

    const usersListChange = (members) => {
        console.log('change')
        setMembers([...members])
    }

    return (
        <div>
            GroupShowPage
            {user ? user.isLoggenIn && user.role.name == 'Admin' ?
                <div>
                    <div>
                        <Button variant='primary' onClick={() => setShow(true)}>Add User To Group</Button>
                    </div>

                    <AddUserToGroupModal
                        groupId={groupId}
                        show={show}
                        setShow={setShow}
                        membersListChange={usersListChange}
                        members={members}
                    />
                </div>

            : "" : "" }
            <MemberList
                members={members}
                setMembers={usersListChange}
            />
        </div>
    );
};

export default GroupShowPage;