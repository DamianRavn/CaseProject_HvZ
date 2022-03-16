import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { UserList } from "./components/Lists/UserList";
import { GameList } from "./components/Lists/GameList";
import LandingPage from "./views/LandingPage";
import AdminPage from "./views/AdminPage";
import GamePage from "./views/GamePage";
import GameRegistrationPage from "./views/GameRegistrationPage";
import LoginPage from "./views/LoginPage";
import CreateAccountPage from "./views/CreateAccountPage";

function App() {
  return (
    <BrowserRouter>
      <div>
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/admin" element={<AdminPage />} />
          <Route path="/game" element={<GamePage />} />
          <Route path="/gamereg" element={<GameRegistrationPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/signup" element={<CreateAccountPage />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
