import React, {useEffect, useState} from 'react';
import MemberList from "../../components/MemberList";
import GroupService from "../../service/GroupService";
import {Button, Table} from "react-bootstrap";
import AddGroupModal from "../../components/modals/AddGroupModal";

const GroupListPage = () => {

    const [groups, setGroupList] = useState();
    const [show, setShow] = useState(false);

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
            <Button
                style={{width: '500px'}}
                variant='dark'
                onClick={() => setShow(true)}
            >Add group</Button>

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
                                <a className='btn btn-primary mx-1'
                                   type='button'
                                   href={`/group/${e.group.id}`}>
                                    See Group Members
                                </a>
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
                            </td>
                        </tr>
                    ) : ''}

                </tbody>
            </Table>

        </div>
    );
};

export default GroupListPage;