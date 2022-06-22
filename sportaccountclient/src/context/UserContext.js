import React from "react";


const UserContext = React.createContext({
    id: null,
    first_name: null,
    last_name: null,
    middle_name: null,
    role: null,
    login: null,
    birthDate: null,
    isLoggenIn: false
});
export default UserContext;
