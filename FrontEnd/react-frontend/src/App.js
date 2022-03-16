import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { UserList } from "./components/Lists/UserList";
import { GameList } from "./components/Lists/GameList";
import LandingPage from './Views/LandingPage'
import AdminPage from './Views/AdminPage'
import GamePage from './Views/GamePage'
import GameRegistrationPage from './Views/GameRegistrationPage'
import LoginPage from './Views/LoginPage'
import CreateAccountPage from './Views/CreateAccountPage'

function App() {
  return (
    <BrowserRouter>
     <div>
      <Routes>
        <Route path='/' element={<LandingPage />} />
        <Route path='/admin' element={<AdminPage />} />
        <Route path='/game' element={<GamePage />} />
        <Route path='/gamereg' element={<GameRegistrationPage />} />
        <Route path='/login' element={<LoginPage />} />
        <Route path='/signup' element={<CreateAccountPage />} />
     </Routes>
     </div>
    </BrowserRouter>
  );
}

export default App;



{/* //<UserList></UserList>
      //<GameList></GameList> */}
