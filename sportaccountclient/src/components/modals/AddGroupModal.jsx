import React, {useState} from 'react';
import {Button, Col, Form, Modal} from "react-bootstrap";
import {Container, Row} from "../FooterStyles";
import UserFullName from "../UserFullName";
import GroupService from "../../service/GroupService";

const AddGroupModal = ({setShow, show, setGroups}) => {

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [groupName, setGroupName] = useState('');

    const handle = async () => {
        const payload = { Name: groupName }
        const data = await GroupService.Add(payload);
        setGroups(data);
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
                                <Form.Label>Enter user name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="dob"
                                    value={groupName}
                                    placeholder="Start time"
                                    onChange={
                                        (e) => setGroupName(e.target.value)
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
                        Add Group
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
};

export default AddGroupModal;