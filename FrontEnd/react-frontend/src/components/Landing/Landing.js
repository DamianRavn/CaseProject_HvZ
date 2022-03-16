import { useContext, useEffect} from "react";
import { useNavigate } from "react-router-dom";

const Landing = () => {

  const navigator = useNavigate()

  const gotoGameRegistration = () => {  
    navigator("/gamereg")
  }

  const gotoGame = () => {  
    navigator("/game")
  }

  const gotoAdmin = () => {  
    navigator("/admin")
  }

  return (
    <div className="default-class">
      <div className="title"><h1>Landing Page</h1></div>
      
      
      <button className="btn" onClick={gotoGameRegistration}>Game Registration Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoGame}>Game Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoAdmin}>Admin Page</button>
      
    </div>
  );
};

export default Landing;