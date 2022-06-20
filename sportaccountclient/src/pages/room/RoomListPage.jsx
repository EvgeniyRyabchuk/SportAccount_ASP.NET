import React, {useEffect, useState} from 'react';
import RoomService from "../../service/RoomService";

const RoomListPage = () => {

    const [data, setData] = useState([]);

    const fetchData = async () => {
        const response = await RoomService.Index();
        const data = response.data;
        setData([...data]);
        console.log(data);
    };

    useEffect( () => {
        fetchData();
    }, [])

    return (
        <div>
            RoomListPage
            <ul>
                {data.length > 0 ? data.map(e =>
                    <li id={e.id}>
                        {e.name}
                    </li>
                ) : 'no items'}
            </ul>
        </div>
    );
};

export default RoomListPage;