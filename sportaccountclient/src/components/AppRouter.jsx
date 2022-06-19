import React from 'react';
import {Redirect, Route, Switch} from "react-router-dom";
import { publicRoutes } from '../router/route';

const AppRouter = () => {
    
    return (
        <Switch>
            {publicRoutes.map(e =>
                <Route
                    key={e.path}
                    path={e.path}
                    component={e.component}
                    exact={e.exact}>
                </Route>
            )}
            <Redirect exact from="/" to="/home"/>
            <Redirect exact to="/pagenotfound"/> 
        </Switch>
    );
};

export default AppRouter; 