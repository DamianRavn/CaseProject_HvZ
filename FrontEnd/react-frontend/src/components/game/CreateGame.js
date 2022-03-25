import { useAddNewGameMutation } from "../../features/apiSlice";
import { GetUser } from "../user/GetUser";
import { GetAdmin } from "../admin/GetAdmin";
import { useNavigate } from "react-router-dom";

export const CreateGame = (gameName) => {
    //const navigator = useNavigate()

    console.log("Inside CreateAdmin.js")
    console.log(gameName)

    const userId = GetUser()
    
    const adminId = GetAdmin(userId)

    const {
        data: admin,
        isLoading,
        isSuccess,
        isError,
        error,
    } = useAddNewGameMutation({name: gameName, gameState: "Registration", adminId: adminId});

  if (isSuccess) {
    console.log("CreateGame.js Success")
    navigator("/")


  }
  else {
      console.log("Error CreateGame.js")
  }
};


// const [addNewUser, { isLoading }] = useAddNewUserMutation();

//   useEffect(() => {
//     console.log("addNewUser fired");
//     addNewUser({
//       firstName: KeycloakService.getFirstName(),
//       lastName: KeycloakService.getLastName(),
//       userName: KeycloakService.getUsername(),
//       keycloakId: KeycloakService.getId(),
//     });
//   }, []);
    




//   let content;
//   if (isLoading) {
//     content = <h1>Loading games</h1>;
//   } else if (isSuccess) {
//     content = games.map((game) => <GameItem key={game.id} game={game} />);
//   } else if (isError) {
//     content = <h1>{error.toString()}</h1>;
//   }

  //return <div></div>;

