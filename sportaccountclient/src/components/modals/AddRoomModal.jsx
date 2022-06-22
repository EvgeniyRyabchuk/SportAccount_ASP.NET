import React, {useState} from 'react';
import {Button, Form, Modal} from "react-bootstrap";
import GroupService from "../../service/GroupService";
import RoomService from "../../service/RoomService";

const AddRoomModal = ({setShow, show, setRooms}) => {

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [roomName, setRoomName] = useState();
    const [number, setNumber] = useState();
    const [areaSize, setAreaSize] = useState();
    const [floor, setFloor] = useState();

    const handle = async () => {
        const payload = {
            number,
            name: roomName,
            areaSize,
            floor
        };

        const data = await RoomService.Add(payload);
        setRooms(data);
    }



    return (
        <div>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Add Group Modal</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group
                            className="mb-3"
                            controlId="formBasicPassword">

                            <Form.Group controlId="dob">
                                <Form.Label>Enter Room Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="dob"
                                    value={roomName}
                                    placeholder="Start time"
                                    onChange={
                                        (e) => setRoomName(e.target.value)
                                    }
                                />
                            </Form.Group>

                            <Form.Group controlId="dob">
                                <Form.Label>Enter Number of Room</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={number}
                                    placeholder="Start time"
                                    onChange={
                                        (e) => setNumber(e.target.value)
                                    }
                                />
                            </Form.Group>

                            <Form.Group controlId="dob">
                                <Form.Label>Enter Room Area Size</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={areaSize}
                                    placeholder="Start time"
                                    onChange={
                                        (e) => setAreaSize(e.target.value)
                                    }
                                />
                            </Form.Group>

                            <Form.Group controlId="dob">
                                <Form.Label>Enter Room Floor</Form.Label>
                                <Form.Control
                                    type="text"
                                    value={floor}
                                    placeholder="Start time"
                                    onChange={
                                        (e) => setFloor(e.target.value)
                                    }
                                />
                            </Form.Group>

                        </Form.Group>
                    </Form>


                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handle}>
                        Add Room
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default AddRoomModal;