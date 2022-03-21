import { useNavigate } from "react-router-dom";
import { GameList } from "../components/game/GameList";
import { UserList } from "../components/user/UserList";
import KeycloakService from "../services/KeycloakService";

const LandingPage = () => {
  const navigator = useNavigate();
  const gotoLogin = () => {
    navigator("/login");
  };

  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem("access-token", KeycloakService.getToken());
    return <UserList />;
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Landing Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoLogin}>
        Login Page
      </button>

      <br></br>
      <GameList></GameList>
    </div>
  );
};

export default LandingPage;
