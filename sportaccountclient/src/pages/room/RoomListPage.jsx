import React, {useEffect, useState} from 'react';
import RoomService from "../../service/RoomService";
import {Button, Table} from "react-bootstrap";
import AddRoomModal from "../../components/modals/AddRoomModal";

const RoomListPage = () => {

    const [room, setRoom] = useState([]);
    const [show, setShow] = useState(false);

    const fetchData = async () => {
        const response = await RoomService.Index();
        const data = response.data;
        setRoom([...data]);
        console.log(data);
    };

    const deleteRoom = () => {

    }

    useEffect( () => {
        fetchData();
    }, [])

    return (
        <div>
            RoomListPage

            <br/>
            <Button
                style={{width: '500px'}}
                variant='dark'
                onClick={() => setShow(true)}
            >Add room</Button>

            <AddRoomModal
                show={show}
                setShow={setShow}
                setRooms={(data) => setRoom([...data])} 

            />

            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>#</th>
                    <th>Room Name</th>
                    <th>Room Number</th>
                    <th>Room Area Size</th>
                    <th>Room Floor</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {room ? room.map(e =>
                    <tr id={e.id}>
                        <td>{e.id}</td>
                        <td>{e.name}</td>
                        <td>{e.number}</td>
                        <td>{e.areaSize} M <sup><small>3</small></sup></td>
                        <td>{e.floor}</td>
                        <td>
                            <Button
                                variant='btn btn-warning'
                            >
                                Edit
                            </Button>
                            <Button
                            variant='danger'
                            onClick={() => deleteRoom}
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

export default RoomListPage;