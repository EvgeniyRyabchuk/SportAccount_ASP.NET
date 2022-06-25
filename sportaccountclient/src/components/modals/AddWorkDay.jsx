import React, {useState} from 'react';
import {Button, Form, Modal} from "react-bootstrap";
import {useParams} from "react-router-dom";
import ScheduleService from "../../service/ScheduleService";

const AddWorkDay = ({setShow, show, setWorkdays}) => {

    const { coachId } = useParams();

    const handleClose = () => setShow(false);


    const [startTimeWorkDate, setStartTimeWorkDate] = useState(null);
    const [endTimeWorkDate, setEndTimeWorkDate] = useState(null);

    const [date, setDate] = useState(null);

    console.log(date)

    const handle = async () => {
        console.log('create new workday')

        const payload = {
            Date: `${date}T00:00:00.149Z`,
            StartTime: `${date}T${startTimeWorkDate}:00`,
            EndTime:`${date}T${endTimeWorkDate}:00`,
        };

        const data = await ScheduleService.AddWorkDay(coachId, payload);
        setWorkdays(data);
        handleClose();
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
                            className="mb-3">
                            <Form.Group controlId="dob">
                                <Form.Label>Select Date</Form.Label>
                                <Form.Control
                                    type="date"
                                    value={date}
                                    placeholder="Workday Date"
                                    onChange={(e) => setDate(e.target.value) }
                                />
                            </Form.Group>
                        </Form.Group>

                        <Form.Group
                            className="mb-3">
                            <Form.Group controlId="dob">
                                    <Form.Label>Select Start Time</Form.Label>
                                    <Form.Control
                                        type="time"
                                        value={startTimeWorkDate}
                                        placeholder="Start workday time"
                                        onChange={(e) => setStartTimeWorkDate(e.target.value) }
                                    />
                            </Form.Group>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Group controlId="dob">
                                <Form.Label>Select End Time</Form.Label>
                                <Form.Control
                                    type="time"
                                    placeholder="End workday time"
                                    value={endTimeWorkDate}
                                    onChange={(e) => setEndTimeWorkDate(e.target.value) }
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
                        Add Work Day
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default AddWorkDay;