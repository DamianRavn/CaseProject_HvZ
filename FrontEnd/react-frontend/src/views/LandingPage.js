import { useNavigate } from "react-router-dom";
import { GameList } from "../components/game/GameList";
import { UserList } from "../components/user/UserList";
import KeycloakService from "../services/KeycloakService";
import { useGetUserByKeycloakIdQuery } from "../features/apiSlice";
import { CheckUser } from "../components/user/CheckUser";

const LandingPage = () => {
  const navigator = useNavigate();
  const gotoGameRegistration = () => {
    //navigator("/gamereg");
    navigator("/newgame");
  };

  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem("access-token", KeycloakService.getToken());
    return (
      <div className="default-class">
        <div className="font-semibold text-center">
          <div className="text-4xl">
            <h1>Landing Page</h1>
          </div>
        </div>
        <div className="default-class">
          <GameList></GameList>
          <CheckUser></CheckUser>
        </div>
        <div className="default-class text-center mb-10">
          <button className="btn" onClick={gotoGameRegistration}>Create Game</button>
        </div>
      </div>
    );
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl text-center">
          <h1>Landing Page</h1>
        </div>
      </div>
      <GameList></GameList>
    </div>
  );
};

export default LandingPage;
