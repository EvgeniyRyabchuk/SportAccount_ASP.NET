import React, {useEffect, useState} from 'react';
import {Button, Col, Form, Modal} from "react-bootstrap";
import {Container, Row} from "../FooterStyles";
import UserService from "../../service/UserService";
import UserFullName from "../UserFullName";

const AddUserToGroupModal = ({groupId, show, setShow, membersListChange, members}) => {
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [userNameText, setUserNameText] = useState('');

    const [users, setUsers] = useState();

    const addToGroup = async (userId) => {
        const data = await UserService.AddToGroup(groupId, userId);
        // setUsers([...data]);
        membersListChange(data);
    }

    const getUsers = async () => {
        const data = await UserService.Index();
        setUsers([...data]);
    }

    useEffect(() => {
        console.log('123')
        getUsers();
    }, [])

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Add user to group</Modal.Title>
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
                                value={userNameText}
                                defaultValue={userNameText}
                                placeholder="Start time"
                                onChange={
                                    (e) => setUserNameText(e.target.value)
                                }
                            />
                        </Form.Group>
                    </Form.Group>
                </Form>
                <Container>
                    { users ? users.map(e =>
                        e.role.name == 'Client' ?
                        <Row>
                            <Col>
                                <UserFullName data={e}/>
                            </Col>
                            <Col>
                                { members ? members.filter(member => member.id == e.id )[0] ?
                                    <Button disabled variant="primary">
                                        Add to Group
                                    </Button>
                                    :
                                    <Button variant="primary" onClick={() => addToGroup(e.id)}>
                                        Add to Group
                                    </Button>
                                    : ''
                                }

                            </Col>
                        </Row>
                            : ''
                    ) : '' }



                </Container>

            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default AddUserToGroupModal;