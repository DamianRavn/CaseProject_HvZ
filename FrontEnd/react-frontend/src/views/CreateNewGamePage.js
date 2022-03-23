import { useNavigate } from "react-router-dom";

const CreateNewGamePage = () => {

  const navigator = useNavigate();

  const goBack = () => {
    navigator("/gamereg");
  };

  const handleCreateNewGame = () => {
    alert("Create New Game button has been pushed.")
    //navigator("/");
  };

  

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Create New Game Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={goBack}>
        Go Back
      </button>
      <div className="divider" />
      <button className="btn" onClick={handleCreateNewGame}>
        Create Game
      </button>
      


    </div>
  );
};

export default CreateNewGamePage;
