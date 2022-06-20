import React, {useRef, useState} from 'react';
import {Button, Form} from "react-bootstrap";
import AuthService from "../../service/AuthService";
import axios from "axios";
import data from "bootstrap/js/src/dom/data";
import {useNavigate} from "react-router-dom";

const Register = () => {

    const navigate = useNavigate();

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [middleName, setMiddleName] = useState('');

    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    const [repeatPassword, setRepeatPassword] = useState();

    const [birthDate, setBirthDate] = useState(null);
    const [sex, setSex] = useState(null);


    const submit = async () => {

        const payload = {
            "firstName": firstName,
            "lastName": lastName,
            "middletName": middleName,
            "login": email,
            "password": password,
            "birthDate": birthDate,
            "roleId": 1,
            "specializationId": 1,
            "statusId": 1,
            "sexId": sex
        }
        // const res = await fetch('https://localhost:44313/api/group');
        // const data = await res.json();
        // console.log(data);

        // const res = await axios.post('https://localhost:44313/api/auth/register', payload);
        // console.log(res);
        try {
            const result = await AuthService.registration(payload);
            console.log(result);
            navigate('/login');
        }
        catch (ex) {
            console.error(ex)
        }
    }

    return (
        <div className={'mt-5'}>
            <div className={'shadow-box'} style={{width: '800px', margin: '0px auto', padding: '50px'}}>
                <h1 className={'mb-5 '}>
                    Register
                </h1>
                <b> For </b>
                <h5>
                    Full name: {firstName}   {lastName}   {middleName}
                </h5>
                <Form className={'mt-5'}>
                    <div className={'d-flex justify-content-center my-5'}>
                        <div className={'d-flex'}>
                            <Form.Group className="mb-3 px-3" controlId="formBasicEmail">
                                <Form.Label>First Name</Form.Label>
                                <Form.Control
                                    className={'input-cursor-center'}
                                    type="text"
                                    placeholder="Enter First Name"
                                    value={firstName}
                                    onChange={(e) => setFirstName(e.target.value) }
                                />
                            </Form.Group>

                            <Form.Group className="mb-3 px-3" controlId="formBasicEmail">
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control
                                    className={'input-cursor-center'}
                                    type="text"
                                    placeholder="Enter Last Name"
                                    value={lastName}
                                    onChange={(e) => setLastName(e.target.value) }
                                />

                            </Form.Group>

                            <Form.Group className="mb-3 px-3" controlId="formBasicEmail">
                                <Form.Label>Middle Name</Form.Label>
                                <Form.Control
                                    className={'input-cursor-center'}
                                    type="text"
                                    placeholder="Enter Middle Name"
                                    value={middleName}
                                    onChange={(e) => setMiddleName(e.target.value) }
                                />

                            </Form.Group>
                        </div>
                    </div>


                    <div style={{width: '500px', margin: 'auto'}}>
                        <Form.Group className="mb-3" controlId="formBasicEmail">
                            <Form.Label>Email address</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="Enter email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value) }
                            />
                            <Form.Text className="text-muted">
                                We'll never share your email with anyone else.
                            </Form.Text>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder="Password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value) }
                            />
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                            <Form.Label>Password repeat</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder="Repeat password"
                                value={repeatPassword}
                                onChange={(e) => setRepeatPassword(e.target.value) }
                            />
                        </Form.Group>

                        <p>
                            {birthDate}
                        </p>

                        <Form.Group className="mb-3" controlId="formBasicPassword">
                                <Form.Group controlId="dob">
                                    <Form.Label>Select Date</Form.Label>
                                    <Form.Control
                                        type="date"
                                        name="dob"
                                        placeholder="Date of Birth"
                                        onChange={(e) => setBirthDate(e.target.value) }
                                    />
                                </Form.Group>
                        </Form.Group>

                        <Form.Group className="mb-3" controlId="formBasicCheckbox">
                            <Form.Check type="checkbox" label="Check me out" />
                        </Form.Group>
                    </div>

                    <h5>{sex}</h5>
                        <div key={`inline-radio`} className="mb-3" style={{fontSize: '18px'}}>

                            <Form.Check
                                inline
                                label="Male"
                                value='1'
                                name="group1"
                                type='radio'
                                id={`inline-radio-1`}
                                onChange={(e) => setSex(e.target.value) }
                            />
                            <Form.Check
                                inline
                                label="Female"
                                value='2'
                                name="group1"
                                type='radio'
                                id={`inline-radio-2`}
                                onChange={(e) => setSex(e.target.value) }
                            />
                        </div>


                    <Button variant="primary" type="button" onClick={submit}>
                        Submit
                    </Button>
                </Form>
            </div>
        </div>
    );
};

export default Register;