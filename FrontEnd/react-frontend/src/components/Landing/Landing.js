import { useContext, useEffect} from "react";
import { useNavigate } from "react-router-dom";

const Landing = () => {

  const navigator = useNavigate()

  const gotoLogin = () => {  
    navigator("/login")
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
      <div className="text-4xl" ><h1>Landing Page</h1></div>
      </div>
      <br></br>
      
      <button className="btn" onClick={gotoLogin}>Login Page</button>
      
    </div>
    
  );
};

export default Landing;