import React from 'react';

const UserFullName = ({data}) => {
    return (
        <span>
            {
             ` ${data.firstName} 
             ${data.lastName} 
             ${data.middleName ?? ''}`
            }
        </span>
    );
};

export default UserFullName;