import { useNavigate } from "react-router-dom";

const AdminPage = () => {
  const navigator = useNavigate();

  const gotoGameRegistration = () => {
    navigator("/gamereg");
  };

  const gotoLanding = () => {
    navigator("/");
  };

  const gotoGame = () => {
    navigator("/game");
  };

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Admin Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoGameRegistration}>
        Game Registration Page
      </button>
      <div className="divider" />
      <button className="btn" onClick={gotoGame}>
        Game Page
      </button>
      <div className="divider" />
      <button className="btn" onClick={gotoLanding}>
        Landing Page
      </button>
    </div>
  );
};

export default AdminPage;
