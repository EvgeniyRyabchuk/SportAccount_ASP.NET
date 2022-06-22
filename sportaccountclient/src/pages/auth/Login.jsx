import React, {useContext, useState} from 'react';
import {Button, Form} from "react-bootstrap";
import AuthService from "../../service/AuthService";
import {useNavigate} from "react-router-dom";
import UserContext from "../../context/UserContext";
import UserService from "../../service/UserService";

const Login = () => {
    const navigate = useNavigate();
    const {user, setUser} = useContext(UserContext);

    const [email, setEmail] = useState();
    const [password, setPassword] = useState();

    const getCurUser = async () => {
        const res = await AuthService.current();
        const data = res.data;
        const newUser = {};
        newUser.id = data.id;
        newUser.firstName = data.firstName;
        newUser.lastName = data.lastName;
        newUser.middleName = data.middleName;
        newUser.role = data.role;
        setUser({...newUser, isLoggenIn: true});
        return newUser
    }

    const submit = async () => {
        console.log('asd')
        const payload = {
            "login": email,
            "password": password,
        }
        try {
            const result = await AuthService.login(payload);
            const data = result.data;
            console.log(data);

            localStorage.setItem('token', data.accessToken);
            const newUser = await getCurUser();

            navigate(`/profile/${newUser.id}`);

        }
        catch (ex) {
            console.error(ex)
        }
    }

    return (
        <div style={{marginTop: '100px'}}>
            <div className={'shadow-box'} style={{width: '500px', margin: '0px auto', padding: '50px'}}>
                <h1>
                    Log in
                </h1>
                <Form>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Email address</Form.Label>
                        <Form.Control

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


                    <Form.Group className="mb-3" controlId="formBasicCheckbox">
                        <Form.Check type="checkbox" label="Check me out" />
                    </Form.Group>
                    <Button variant="primary" type="button" onClick={submit}>
                        Submit
                    </Button>
                </Form>
            </div>
        </div>
    );
};

export default Login;