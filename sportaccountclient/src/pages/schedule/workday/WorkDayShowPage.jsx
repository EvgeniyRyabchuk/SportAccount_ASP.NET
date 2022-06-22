import React, {useContext, useEffect, useRef, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import CoachService from "../../../service/CoachService";
import ScheduleService from "../../../service/ScheduleService";
import {dateOnly, dateWordFormat, timeOnly} from "../../../helpers/date";
import UserFullName from "../../../components/UserFullName";
import {Button, Form, Modal} from "react-bootstrap";
import UserContext from "../../../context/UserContext";

const WorkDayShowPage = () => {

    const { coachId, workdayId } = useParams();


    const [coach, setCoach] = useState(null);
    const [workday, setWorkday] = useState(null);
    const [workouts, setWorkouts] = useState(null);
    const {user, setUser} = useContext(UserContext);
    const [show, setShow] = useState(false);

    const [startTimeWorkout, setStartTimeWorkout] = useState(null);
    const [endTimeWorkout, setEndTimeWorkout] = useState(null);

    const handleClose = () => setShow(false);
    const handleShow = () => {
        setShow(true);

    }

    const startEl = useRef();
    const endEl = useRef();

    const getCoach = async () => {
        const res = await CoachService.show(coachId);
        const data = res.data;
        console.log(data);
        setCoach(data);
    }

    const getWorkDay = async () => {
        const res = await ScheduleService.GetWorkDayById(coachId, workdayId);
        const data = res.data;
        console.log(data);

        setStartTimeWorkout(timeOnly(data.startTime));
        setEndTimeWorkout(timeOnly(data.endTime));
        setWorkday(data);

    }

    const getWorkOuts = async () => {
        const res = await ScheduleService.GetWorkOutsByCoachId(coachId, workdayId);
        const data = res.data;
        console.log(data);
        setWorkouts(data);
    }

    useEffect(() => {
        getCoach();
        getWorkDay();
        getWorkOuts();


    }, [])


    const sigUp = async () => {
        //TODO: restrictions time check
        console.log(startTimeWorkout);
        console.log(endTimeWorkout);

        console.log(workday.startTime)
        console.log(workday.endTime)

        console.log(startEl)


        const payload = {
            clientId: user.id,
            roomId: 1,
            workoutTypeId: 2,
            start: `2022-06-22T${startTimeWorkout}:00.149Z`,
            end: `2022-06-22T${endTimeWorkout}:00.149Z`
        }

        const res = await ScheduleService.AddWorkOuts(coachId, workday.id, payload);

        setWorkouts([...res.data]);

        handleClose();
    }

    return (
        <div className='px-3 py-3'>
            Work Day
            <div className='mt-5'>
                {
                    workday ?
                           <h3> {dateWordFormat(workday.date) } </h3> : ''
                }
                { coach ?
                    <p>
                        for {` ${coach.firstName} 
                        ${coach.lastName} 
                        ${coach.middleName}`}
                    </p> : ''}

                <br/>
                {
                    user.isLoggenIn && user.role.name == 'Client' ?
                        <Button variant="dark" onClick={handleShow}>Sign up for a workout</Button>
                    : ''
                }

                <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
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

                <ul className='mt-5 px-3 py-3'>
                    { workouts ? workouts.map(e =>
                        <li
                            style={{padding: '20px', border: '1px solid black'}}
                            id={e.id}
                            className='my-3 d-flex justify-content-between'
                            id={e.id}>
                            <div>
                                <span className='field-title'>Workday Start Time: </span>
                                <span className='field-value'> { timeOnly(e.start)} </span>
                            </div>
                            <div>
                                <span className='field-title'>Workday End Time: </span>
                                <span className='field-value'> {timeOnly(e.end)} </span>
                            </div>

                            { e.client ?
                                <div >
                                    <span className='field-title'> For Client Full Name: </span>
                                    <span className='field-value'>
                                        <Link to={`/profile/${e.client.id}`}>
                                            <UserFullName data={e.client}/>
                                        </Link>
                                    </span>
                                </div>
                            :
                                <div>
                                    <div>
                                        <span className='field-title'>For Group: </span>
                                        <span className='field-value'> {e.group.name} </span>
                                    </div>

                                    <a className='btn btn-primary mx-1'
                                        type='button'
                                        href={`/group/${e.group.id}`}>
                                        See Group Members
                                    </a>
                                </div>
                            }




                        </li>
                    ) : ''}
                </ul>

            </div>


        </div>
    );
};

export default WorkDayShowPage;