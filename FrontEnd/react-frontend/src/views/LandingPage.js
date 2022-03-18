import { useNavigate } from "react-router-dom";
import { GameList } from "../components/game/GameList.js";
import { UserList } from "../components/user/UserList.js";
import { useKeycloak } from "@react-keycloak/web";
import { useEffect } from "react";

const LandingPage = () => {
  const { keycloak, initialized } = useKeycloak();

  useEffect(() => {
    localStorage.setItem("authenticated", keycloak.authenticated);
    localStorage.setItem("access-token", keycloak.token);
  });

  const navigator = useNavigate();
  const gotoLogin = () => {
    navigator("/login");
  };

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
      <UserList />
    </div>
  );
};

export default LandingPage;
