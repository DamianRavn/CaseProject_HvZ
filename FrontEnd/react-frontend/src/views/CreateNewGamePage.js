import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form"
import { CreateGame } from "../components/game/CreateGame";
import { GetUser } from "../components/user/GetUser";
import { GetAdmin } from "../components/admin/GetAdmin";
import { CreateAdmin } from "../components/admin/CreateAdmin";
import KeycloakService from "../services/KeycloakService";

const CreateNewGamePage = () => {

  const navigator = useNavigate();

  const goBack = () => {
    navigator("/");
  };



  
  const {register, handleSubmit} = useForm()
  const onSubmit = (d) => {
    //alert("Create game button was pushed. \ngameName: "+d.gameName + "\ngameRules: "+ d.gameRules +"\n" + JSON.stringify(d))
    //CreateGame(d.gameName, user.id, userAdminId)
    
    if(userAdminId === -1)
    {
      console.log("Admin doesn't exist, will call CreateAdmin(userId)")
      userAdminId = CreateAdmin(user.id)
    }
    userAdminId = CreateAdmin(user.id)
  }

  let keycloakId = KeycloakService.getId()
  let user = GetUser(keycloakId)
  console.log("keycloakId = " + keycloakId)
  console.log(`user: `)
  console.log(user.id)

  let userAdminId = GetAdmin(user.id)

  console.log("userAdminId = " + userAdminId)
  
  

  

  

    
  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Create New Game Page</h1>
        </div>
      </div>
      <br></br>

      <br></br>

      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
        <label>
          Game name:
          <input className="appearance-none block w-100 bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white" {...register("gameName")} />
        </label>
        
        <label>
          Input 2:
          <input className="appearance-none block w-100 bg-gray-200 text-gray-700 border border-red-500 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white" {...register("gameRules")} />
        </label>
        </div>
        <br></br>
        <button type="submit" className="btn">
          Create Game
        </button>
      </form>

      <button className="btn" onClick={goBack}>
        Go Back
      </button>
      <div className="divider" />
    </div>
  );
};

export default CreateNewGamePage;
