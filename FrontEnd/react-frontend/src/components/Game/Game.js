import { useContext } from "react"
import { useNavigate } from "react-router-dom"


const Game = () => {


  const navigator = useNavigate()
  

  const gotoGameRegistration = () => {  
    navigator("/gamereg")
  }

  const gotoLanding = () => {  
    navigator("/")
  }

  const gotoAdmin = () => {  
    navigator("/admin")
  }

  return (
    <div className="default-class">
      <div className="title"><h1>Game Page</h1></div>
      
      <button className="btn" onClick={gotoGameRegistration}>Game Registration Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoAdmin}>Admin Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoLanding}>Landing Page</button>
      
    </div>
  );


}

export default Game