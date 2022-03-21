import { useNavigate } from "react-router-dom";

const LoginPage = () => {

  const navigator = useNavigate();

  const gotoSignIn = () => {
    navigator("/gamereg");
  };

  const gotoLandingPage = () => {
    navigator("/");
  };

  

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Login Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoLandingPage}>
        Go Back
      </button>
      <div className="divider" />
      <button className="btn" onClick={gotoSignIn}>
        Sign in
      </button>


    </div>
  );
};

export default LoginPage;
