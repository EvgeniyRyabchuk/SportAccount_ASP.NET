import Home from "../pages/home";
import Profiles from "../pages/profiles/profiles.jsx";
import error_404 from "../pages/error_404";


export const publicRoutes = [
    {path: '/home', component: Home, exact: true },
    {path: '/profile', component: Profiles, exact: true },
    {path: '/pagenotfound', component: error_404, exact: true },
]
