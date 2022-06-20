
import './App.css';
import AppRouter from "./components/AppRouter";
import Header from "./components/Header";
import Footer from "./components/Footer";
import User from "./models/User";
import React from "react";
import UserContext from "./context/UserContext";
import {BrowserRouter} from "react-router-dom";

// import 'bootstrap/dist/css/bootstrap.min.css';

function App() {




  return (
      <BrowserRouter>
          <UserContext.Provider value={User}>
              <div className="App" style={{padding: '10px'}}>
                  <Header />
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
