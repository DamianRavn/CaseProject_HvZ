import { useNavigate } from "react-router-dom";
import { GameList } from "../components/game/GameList";
import { UserList } from "../components/user/UserList";
import KeycloakService from "../services/KeycloakService";
import { useGetUserByKeycloakIdQuery } from "../features/apiSlice";
import { CheckUser } from "../components/user/CheckUser";

const LandingPage = () => {
  const navigator = useNavigate();
  const gotoLogin = () => {
    navigator("/login");
  };

  const gotoCreateAccount = () => {
    navigator("/signup");
  };

  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem("access-token", KeycloakService.getToken());
    return (
      <div className="default-class">
        <div className="font-semibold">
          <div className="text-4xl">
            <h1>Landing Page</h1>
          </div>
        </div>
        <GameList></GameList>
        <CheckUser></CheckUser>
      </div>
    );
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Landing Page</h1>
        </div>
      </div>
      <GameList></GameList>
    </div>
  );
};

export default LandingPage;
