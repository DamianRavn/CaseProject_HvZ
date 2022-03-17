import "./App.css";
import React from "react";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import keycloak from "./keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Nav from "./components/Nav";
import { UserList } from "./components/Lists/UserList";
import { GameList } from "./components/Lists/GameList";
import LandingPage from "./Views/LandingPage";
import AdminPage from "./Views/AdminPage";
import GamePage from "./Views/GamePage";
import GameRegistrationPage from "./Views/GameRegistrationPage";
import LoginPage from "./Views/LoginPage";
import CreateAccountPage from "./Views/CreateAccountPage";
import PrivateRoute from "./helpers/PrivateRoute";
import { Game } from "./components/Game/Game";
import { AddGame } from "./components/Game/AddGame";

function App() {
  return (
    <div>
      <ReactKeycloakProvider authClient={keycloak}>
        <Nav />
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<LandingPage />} />
            <Route path="/admin" element={<AdminPage />} />
            <Route
              path="/game"
              element={
                <PrivateRoute>
                  <GamePage />
                </PrivateRoute>
              }
            />
            <Route exact path="/games/:gameId" element={<Game />} />
            <Route path="/addgame" element={<AddGame />} />
            <Route path="/gamereg" element={<GameRegistrationPage />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/signup" element={<CreateAccountPage />} />
          </Routes>
        </BrowserRouter>
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;
