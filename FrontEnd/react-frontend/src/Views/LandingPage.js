import { useNavigate } from "react-router-dom";
import Landing from "../components/Landing/Landing.js";
import { GameList } from "../components/Lists/GameList.js";
import { UserList } from "../components/Lists/UserList.js";

const LandingPage = () => {
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
