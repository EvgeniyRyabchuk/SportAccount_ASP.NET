import React from 'react';
import {Navigate, Route, Routes } from "react-router-dom";
import { routes } from '../router/route';
import Home from "../pages/Home";

const AppRouter = () => {
    
    return (
        <Routes>
            <Route path="/" element={ <Home /> } />

            {routes.map(e =>
                <Route
                    key={e.path}
                    path={e.path}
                    element={e.component}
                    >
                </Route>
            )}

            <Route
                path="*"
                element={<Navigate to="/notfound" replace />}
            />
        </Routes>
    );
};

export default AppRouter; 