import React, {useContext} from 'react';
import UserContext from "../context/UserContext";

const Home = () => {

    const user = useContext(UserContext);

    return (
        <div >

            <h1>Home</h1>

            {
                user.isLoggenIn ?
                    <div>
                        <h3>Hello there</h3>
                        <h1>{user.first_name} {user.last_name} </h1>
                    </div>
                   : ''
            }

        </div>
    );
};

export default Home;