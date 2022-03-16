import { useContext } from "react"
import { useNavigate } from "react-router-dom"


const GameRegistration = () => {


  const navigator = useNavigate()
  

  const gotoGame = () => {  
    navigator("/game")
  }

  const gotoLanding = () => {  
    navigator("/")
  }

  const gotoAdmin = () => {  
    navigator("/admin")
  }

  return (
    <div className="default-class">
      <div className="title"><h1>Game Registration Page</h1></div>
      
      
      <button className="btn" onClick={gotoGame}>Game Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoAdmin}>Admin Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoLanding}>Landing Page</button>
      
    </div>
  );


}

export default GameRegistration