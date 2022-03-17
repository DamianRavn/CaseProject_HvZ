import { useNavigate } from "react-router-dom";

const CreateAccountPage = () => {
  const navigator = useNavigate();

  const handleCreateAccountBtn = () => {
    navigator("/gamereg");
  };

  const gotoLoginPage = () => {
    navigator("/login");
  };

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Create Account Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoLoginPage}>
        Go Back
      </button>
      <div className="divider" />
      <button className="btn" onClick={handleCreateAccountBtn}>
        Create Account
      </button>
    </div>
  );
};

export default CreateAccountPage;
