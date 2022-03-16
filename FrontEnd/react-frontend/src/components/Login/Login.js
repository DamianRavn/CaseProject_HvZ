import { useContext } from "react"
import { useNavigate } from "react-router-dom"


const Login = () => {


  const navigator = useNavigate()
  

  const gotoSignIn = () => {  
    alert("Sign In: button pressed")
    
    //navigator("/game")
  }

  const gotoCreateAccount = () => {  
    navigator("/signup")
  }

  const gotoHelp = () => {  
    alert("Help: button pressed.")
    
    //navigator("/admin")
  }

  const gotoLandingPage = () => {  
    navigator("/")
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
      <div className="text-4xl" ><h1>Login Page</h1></div>
      </div>
      <br></br>
      
      <button className="btn" onClick={gotoLandingPage}>Go Back</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoSignIn}>Sign in</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoCreateAccount}>Greate Account</button>
      <div class="divider"/>
      <button className="btn" onClick={gotoHelp}>Help</button>
      
    </div>
  );


}

export default Login