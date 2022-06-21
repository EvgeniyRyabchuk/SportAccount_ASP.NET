import React, {useContext, useEffect, useState} from 'react';
import {Nav, NavDropdown} from 'react-bootstrap';
import {Link, matchPath, useLocation, useNavigate} from "react-router-dom";
import UserContext from "../context/UserContext";
import AuthService from "../service/AuthService";

const Header = () => {
    const navigate = useNavigate();
    const [activeKey, setActiveKey] = useState(0);
    const {user, setUser} = useContext(UserContext);
    const [isLoggedIn, setISLoggedIn] = useState(false);
    const { pathname } = useLocation();

    console.log(123)

    const getCurUser = async () => {
        const res = await AuthService.current();
        const data = res.data;
        const user = {};
        user.id = data.id;
        user.firstName = data.firstName;
        user.lastName = data.lastName;
        user.middleName = data.middleName;
        user.isLoggenIn = true;
        setUser(user);

    }


    useEffect(() => {
        getCurUser();

        switch (pathname) {
            case '/':
                setActiveKey(1);
            break;
            case '/group':
                setActiveKey(2);
                break;
            case '/room':
                setActiveKey(3);
                break;
        }

    }, [])

    console.log(user);

    const handleSelect = async (eventKey) => {
        switch (eventKey) {
            case '4.1':
                navigate(`/profile/${user.id}`);
            break;
            case '4.2':
                navigate('/profile');
            break;
            case '4.3':
                navigate('/profile');
            break;
            case '4.4':
                if(user.isLoggenIn) {
                    const res = await AuthService.logout();
                    user.isLoggenIn = false;
                    // console.log(res);
                    setUser({...user})
                    localStorage.removeItem('token');
                    navigate(`/`);
                }

            break;
            case '1':
                setActiveKey(1);
                navigate('/');
                break;
            case '2':
                setActiveKey(2);
                navigate('/group');
                break;
            case '3':
                setActiveKey(3);
                navigate('/room');
                break;
            case '4':
                setActiveKey(4);
                navigate('/coach');
                break;
        }
    };

    return (
        <header>
            <Nav variant="pills" activeKey={activeKey} onSelect={handleSelect}>
                <Nav.Item>
                    <Nav.Link eventKey="1">
                        Home
                    </Nav.Link>
                </Nav.Item>

                <Nav.Item>
                    <Nav.Link eventKey="2">
                        Groups
                    </Nav.Link>
                </Nav.Item>

                <Nav.Item>
                    <Nav.Link eventKey="3">
                        Room
                    </Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link eventKey="4">
                        Coach List
                    </Nav.Link>
                </Nav.Item>

                <div style={{display: 'flex',}} className={'flex-grow-1 justify-content-end'}>
                    { user.isLoggenIn ?
                        <NavDropdown title={user.firstName + ' ' + user.lastName} id="nav-dropdown">
                            <NavDropdown.Item eventKey="4.1">
                                Profile
                            </NavDropdown.Item>
                            <NavDropdown.Item eventKey="4.2">Another action</NavDropdown.Item>
                            <NavDropdown.Item eventKey="4.3">Something else here</NavDropdown.Item>
                            <NavDropdown.Divider />

                            <NavDropdown.Item eventKey="4.4">Log out</NavDropdown.Item>
                        </NavDropdown> :

                        <div className={'d-flex justify-content-between align-content-center'} style={{fontSize: '19px'}}>
                            <Link className={'custom-link'} to={'/login'}>Log in</Link>
                            <Link className={'custom-link'} to={'/register'}>Register</Link>
                        </div>

                    }

                </div>
            </Nav>
        </header>
    );
};

export default Header;