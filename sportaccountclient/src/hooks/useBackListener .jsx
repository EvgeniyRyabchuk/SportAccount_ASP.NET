import React, {useContext, useEffect} from 'react';

import { UNSAFE_NavigationContext } from "react-router-dom";

const useBackListener = (callback) => {
    const navigator = useContext(UNSAFE_NavigationContext).navigator;

    useEffect(() => {
        const listener = ({ location, action }) => {
            console.log("listener", { location, action });
            if (action === "POP" || action === "PUSH") {
                callback({ location, action });
            }
        };

        const unlisten = navigator.listen(listener);
        return unlisten;
    }, [callback, navigator]);
};

export default useBackListener;