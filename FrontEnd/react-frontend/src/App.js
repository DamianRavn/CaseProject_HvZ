import "./App.css";
import React from "react";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import keycloak from "./keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Nav from "./components/Nav";
import LandingPage from "./views/LandingPage";
import AdminPage from "./views/AdminPage";
import GamePage from "./views/GamePage";
import GameRegistrationPage from "./views/GameRegistrationPage";
import LoginPage from "./views/LoginPage";
import CreateAccountPage from "./views/CreateAccountPage";
import PrivateRoute from "./helpers/PrivateRoute";
import { Game } from "./components/game/Game";
import { AddGame } from "./components/game/AddGame";

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
