import React, {useContext} from 'react';
import UserContext from "../context/UserContext";
import {Button, Card, Col, Row} from "react-bootstrap";
import {Container} from "../components/FooterStyles";
import {useNavigate} from "react-router-dom";

const Home = () => {

    const user = useContext(UserContext);
    const navigator = useNavigate();

    const goTo = (index) => {
        console.log(index)

        switch (index) {
            case 1:
                navigator('/group');
                break;
            case 2:
                navigator('/room');
                break;
            case 3:
                navigator('/coach');
                break;
        }
    }

    return (
        <div >

            <h1>Home</h1>
            <br />
            <br />
            <br />

            {
                user.isLoggenIn ?
                    <div>
                        <h3>Hello there</h3>
                        <h1>{user.first_name} {user.last_name} </h1>
                    </div>
                   : ''
            }
            <Container>
                <Row>
                    <Col>
                        <Card style={{ width: '18rem' }}>
                            <Card.Body>
                                <Card.Title>Groups</Card.Title>
                                <Card.Text>
                                    Some quick example text to build on the card title and make up the
                                    bulk of the card's content.
                                </Card.Text>
                                <Button variant="primary" onClick={() => goTo(1)}>Go groups page</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card style={{ width: '18rem' }}>
                            <Card.Body>
                                <Card.Title>Rooms</Card.Title>
                                <Card.Text>
                                    Some quick example text to build on the card title and make up the
                                    bulk of the card's content.
                                </Card.Text>
                                <Button variant="primary" onClick={() => goTo(2)}>Go rooms page</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    <Col>
                        <Card style={{ width: '18rem' }}>
                            <Card.Body>
                                <Card.Title>Coaches</Card.Title>
                                <Card.Text>
                                    Some quick example text to build on the card title and make up the
                                    bulk of the card's content.
                                </Card.Text>
                                <Button variant="primary" onClick={() => goTo(3)}>Go coach list page</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>


            </Container>


        </div>
    );
};

export default Home;