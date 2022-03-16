import { useContext } from "react"
import { useNavigate } from "react-router-dom"


const CreateAccount = () => {


  const navigator = useNavigate()
  
  const handleCreateAccountBtn = () => {  
    alert("Create Account: button pressed")
    //navigator("/game")
  }

  const gotoLoginPage = () => {  
    navigator("/login")
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
      <div className="text-4xl" ><h1>Create Account Page</h1></div>
      </div>
      <br></br>
      
      <button className="btn" onClick={gotoLoginPage}>Go Back</button>
      <div class="divider"/>
      <button className="btn" onClick={handleCreateAccountBtn}>Create Account</button>
      
    </div>
  );


}

export default CreateAccount