import Home from "../pages/Home";
import Profiles from "../pages/user/Profile";
import error_404 from "../pages/ERR_404";
import Err404 from "../pages/ERR_404";
import EditUser from "../pages/user/EditUser";
import GroupView from "../pages/user/GroupView";
import Login from "../pages/auth/Login";
import Register from "../pages/auth/Register";
import GroupListPage from "../pages/group/GroupListPage";
import GroupShowPage from "../pages/group/GroupShowPage";
import RoomListPage from "../pages/room/RoomListPage";
import RoomShowPage from "../pages/room/RoomShowPage";
import WorkDayListPage from "../pages/schedule/workday/WorkDayListPage";
import WorkOutListPage from "../pages/schedule/workout/WorkOutListPage";
import WorkOutShowPage from "../pages/schedule/workout/WorkOutShowPage";
import WorkDayShowPage from "../pages/schedule/workday/WorkDayShowPage";
import CoachShow from "../pages/coach/CoachShow";
import CoachList from "../pages/coach/CoachList";



export const routes = [
    {path: '/notfound', component: <Err404 />, exact: true },
    {path: '/home', component: <Home />, exact: true },
    {path: '/profile/:userId', component: <Profiles />, exact: true },

    {path: '/user', component: Profiles, exact: true },
    {path: '/user/:userId/edit', component: <EditUser />, exact: true },
    {path: '/user/:userId/group', component: <GroupView />, exact: true },

    {path: '/coach/', component: <CoachList />, exact: true },
    {path: '/coach/:coachId', component: <CoachShow />, exact: true },

    {path: '/login', component: <Login /> , exact: true },
    {path: '/register', component: <Register />, exact: true },

    {path: '/group', component: <GroupListPage />, exact: true },
    {path: '/group/:groupId', component: <GroupShowPage />, exact: true },

    {path: '/room', component: <RoomListPage />, exact: true },
    {path: '/room/{roomId}', component: <RoomShowPage />, exact: true },

    // workdays adn workouts for all coaches
    {path: 'coach/schedule/workday', component: <WorkDayListPage />, exact: true },
    {path: 'coach/schedule/workout', component: <WorkOutListPage />, exact: true },

    // workdays adn workouts for one coach
    {path: 'coach/:coachId/schedule/workday', component: <WorkDayListPage />, exact: true },
    {path: 'coach/:coachId/schedule/workout', component: <WorkOutListPage />, exact: true },

    {path: 'coach/:coachId/schedule/workday/:workdayId', component:  <WorkDayShowPage />, exact: true },
    {path: 'coach/:coachId/schedule/workout/:workoutId', component:  <WorkOutShowPage />, exact: true },

]
