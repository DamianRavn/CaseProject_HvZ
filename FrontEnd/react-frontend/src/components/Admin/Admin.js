import { useContext } from "react"
import { useNavigate } from "react-router-dom"


const Admin = () => {


  const navigator = useNavigate()
  

  const gotoGameRegistration = () => {  
    navigator("/gamereg")
  }

  const gotoLanding = () => {  
    navigator("/")
  }

  const gotoGame = () => {  
    navigator("/game")
  }

  return (
    <div className="default-class">
      <div className="title"><h1>Admin Page</h1></div>
      
      <button className="btn" onClick={gotoGameRegistration}>Game Registration Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoGame}>Game Page</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoLanding}>Landing Page</button>
      
    </div>
  );


}

export default Admin