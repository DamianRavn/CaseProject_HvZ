import { useNavigate } from "react-router-dom";
import KeycloakService from "../services/KeycloakService";
import { GameList } from "../components/game/GameList";

const CreateNewGamePage = (props) => {


  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem("access-token", KeycloakService.getToken());
    return (
      <div className="default-class">
      <div className="font-semibold text-center">
        <div className="text-4xl">
          <h1>Create new Game</h1>
        </div>
      </div>
      <div className="bg-blue w-full p-8 flex justify-center">  
        <div className="rounded-md bg-grey-light w-64 p-2 border border-black">
          <div className="text-center mt-2 border-b rounded">
            <h2>Game name goes here</h2>
            <input type="text" className="border-b"></input>
          </div>
          <div className="text-center mt-2">
            <div className="bg-white p-2 rounded mt-1 border-b border-grey">
              <p>
                something to edit
              </p>
            </div>

            <div className="bg-white p-2 rounded mt-1 border-b border-grey">
              <p>
                something to edit
              </p>
            </div>

            <div className="bg-white p-2 rounded mt-1">
              <div className="text-grey-darker mt-2 ml-2 flex justify-between items-start"></div>
              <button className="btn">Create</button>
            </div>
          </div>
        </div>
      </div>
      </div>
    );
  }

  return (
    <div className="bg-blue w-full p-8 flex justify-center">
      <div className="rounded-md bg-grey-light p-2 border border-black">
        <h1><b>Please login to create a new game</b></h1>
      </div>
    </div>
  );
};

export default CreateNewGamePage;
