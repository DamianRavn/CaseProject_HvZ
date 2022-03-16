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
      <div className="font-semibold">
      <div className="text-4xl" ><h1>Game Page</h1></div>
      </div>
      <br></br>

      
      
      <button className="btn" onClick={gotoGameRegistration}>Game Registration Page</button>
      <div className="divider"/>
      <button className="btn" onClick={gotoAdmin}>Admin Page</button>
      <div className="divider"/>
      <button className="btn" onClick={gotoLanding}>Landing Page</button>
      
    </div>
  );


}

export default Game