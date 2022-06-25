import React, {useContext, useEffect, useRef, useState} from 'react';
import {Alert, Button, Form, Modal} from "react-bootstrap";
import ScheduleService from "../../service/ScheduleService";
import UserContext from "../../context/UserContext";
import {useParams} from "react-router-dom";
import Select from 'react-select'
import GroupService from "../../service/GroupService";
import RoomService from "../../service/RoomService";

const SignUpForWorkoutModal = ({
       setShow, show, setWorkouts, workday, workoutType
    }) => {

    const { coachId, workdayId } = useParams();
    const {user, setUser} = useContext(UserContext);
    const [startTimeWorkout, setStartTimeWorkout] =
        useState(workday ? workday.startTime : '');
    const [endTimeWorkout, setEndTimeWorkout] =
        useState(workday ? workday.endTime : '');

    const [groups, setGroupList] = useState();
    const [rooms, setRoomsList] = useState();

    const groupSelect = useRef();
    const roomSelect = useRef();

    const handleClose = () => setShow(false);

    const startEl = useRef();
    const endEl = useRef();

    const dangerAlertActive = useRef();
    const successAlertActive = useRef();

    const getGroups = async () => {
        const res = await GroupService.Index();
        const options = [];
        for(let i of res.data) {
            options.push({ value: i.group.id, label: i.group.name + ` (${i.count})` })
        }
        setGroupList([...options]);
        console.log(options);
    }

    const getRooms = async () => {
        const res = await RoomService.Index();
        const options = [];
        for(let i of res.data) {
            options.push({ value: i.id, label: i.name + ` (${i.number})` })
        }
        setRoomsList([...options]);
        console.log(options);
    }

    const showAlert = (_alert, msg) => {
        _alert.current.innerText = msg; ;
        _alert.current.style.display = 'block';
        setTimeout(() => _alert.current.style.display = 'none', 5000);
    }

    const sigUp = async () => {
        //TODO: restrictions time check
        console.log(startTimeWorkout);
        console.log(endTimeWorkout);

        const payload = {
            clientId: workoutType == 'Group' ? null : user.id,
            groupId: workoutType == 'Group' ?  groupSelect.current.getValue()[0].value : null,
            roomId: roomSelect.current.getValue()[0].value,
            workoutTypeId: workoutType == 'Group' ? 1 : 2,
            start: `2022-06-22T${startTimeWorkout}:00`,
            end: `2022-06-22T${endTimeWorkout}:00`
        }
        try {
            const res = await ScheduleService.AddWorkOuts(coachId, workday.id, payload);
            setWorkouts([...res.data]);
            handleClose();
            showAlert(successAlertActive, "workout added successfully");
        }
        catch (ex) {
           showAlert(dangerAlertActive, ex.response.data);
        }
    }

    useEffect(() => {
        getGroups();
        getRooms();
    }, [])

    return (
        <div>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    WorkOutType = {workoutType == 'Group' ? 'Group' : 'Personal'}
                    <Modal.Title>Sign up to workout</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group
                            className="mb-3"
                            controlId="formBasicPassword"
                        >
                            <Form.Group controlId="dob">
                                <Form.Label>Select Start Time</Form.Label>
                                <Form.Control
                                    ref={startEl}
                                    type="time"
                                    name="dob"
                                    value={startTimeWorkout}
                                    defaultValue={startTimeWorkout}
                                    placeholder="Start time"
                                    onChange={(e) => setStartTimeWorkout(e.target.value) }
                                />
                            </Form.Group>
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Group controlId="dob">
                                <Form.Label>Select End Time</Form.Label>
                                <Form.Control
                                    ref={endEl}
                                    type="time"
                                    name="dfob"
                                    placeholder="End time"
                                    value={endTimeWorkout}
                                    defaultValue={endTimeWorkout}
                                    onChange={(e) => setEndTimeWorkout(e.target.value) }
                                />
                            </Form.Group>
                        </Form.Group>
                        { workoutType == 'Group' ?
                            <Select options={groups} ref={groupSelect}/> : ''
                        }
                        <Form.Label>Select Room</Form.Label>
                        <Select options={rooms} ref={roomSelect}/>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={sigUp}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>


            <Alert className='alert-custom' key='success' variant='success' ref={successAlertActive}>
                This is a success alert—check it out!
            </Alert>

            <Alert className='alert-custom' key='danger' variant='danger' ref={dangerAlertActive}>
                This is a danger alert—check it out!
            </Alert>
        </div>
    );
};

export default SignUpForWorkoutModal;