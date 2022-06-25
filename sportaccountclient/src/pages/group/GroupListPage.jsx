import React, {useContext, useEffect, useState} from 'react';
import MemberList from "../../components/MemberList";
import GroupService from "../../service/GroupService";
import {Button, Table} from "react-bootstrap";
import AddGroupModal from "../../components/modals/AddGroupModal";
import UserContext from "../../context/UserContext";

const GroupListPage = () => {

    const [groups, setGroupList] = useState();
    const [show, setShow] = useState(false);
    const {user, setUser} = useContext(UserContext);

    console.log(groups)
    const getGroups = async () => {
        const res = await GroupService.Index();
        setGroupList([...res.data]);
        console.log(res);
    }

    const deleteGroup = async (gId) => {
        const data = await GroupService.Delete(gId);
        setGroupList([...data]);
    }


    useEffect(() => {
        getGroups();
    }, [])

    return (
        <div>
            GroupListPage
            <br/>
            {user ? user.isLoggenIn && user.role.name == 'Admin' ?
                <Button
                    style={{width: '500px'}}
                    variant='dark'
                    onClick={() => setShow(true)}
                >Add group</Button>
            : '' : '' }

            <AddGroupModal
                show={show}
                setShow={setShow}
                setGroups={ (data) => setGroupList([...data] )}
            />

            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Members</th>
                    <th>Action</th>
                </tr>
                </thead>
                <tbody>
                    { groups ? groups.map(e =>
                        <tr id={e.id}>
                            <td>{e.group.id}</td>
                            <td>{e.group.name}</td>
                            <td>{e.count}</td>
                            <td>
                                <div className='d-flex justify-content-center'>
                                    <a className='btn btn-primary mx-1'
                                       type='button'
                                       href={`/group/${e.group.id}`}>
                                        See Group Members
                                    </a>
                                    {user ? user.isLoggenIn && user.role.name == 'Admin' ?
                                        <div>
                                            <Button
                                                className='btn btn-warning mx-1'
                                                type='button'
                                            >
                                                Edit
                                            </Button>
                                            <Button
                                                className='btn btn-danger mx-1'
                                                type='button'
                                                onClick={() => deleteGroup(e.group.id)}
                                            >
                                                Delete
                                            </Button>
                                        </div> : '' : ''
                                    }
                                </div>

                            </td>
                        </tr>
                    ) : ''}

                </tbody>
            </Table>

        </div>
    );
};

export default GroupListPage;