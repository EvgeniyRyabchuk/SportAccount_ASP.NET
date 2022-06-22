
import './App.css';
import AppRouter from "./components/AppRouter";
import Header from "./components/Header";
import Footer from "./components/Footer";
import React, {useState} from "react";
import UserContext from "./context/UserContext";
import {BrowserRouter} from "react-router-dom";

// import 'bootstrap/dist/css/bootstrap.min.css';

function App() {

    const [user, setUser] = useState({
        id: null,
        first_name: null,
        last_name: null,
        middle_name: null,
        role: null,
        login: null,
        birthDate: null,
        isLoggenIn: false
    });


  return (
      <BrowserRouter>
          <UserContext.Provider value={{user, setUser}}>
              <div className="App" style={{padding: '0px'}}>
                  <Header   />
                  <main style={{minHeight: '90vh', marginTop: '10px'}}>
                      <AppRouter />
                  </main>
                  <Footer />
              </div>
          </UserContext.Provider>
      </BrowserRouter>

  );
}

export default App;
