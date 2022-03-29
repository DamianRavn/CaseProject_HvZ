import { useAddNewGameMutation } from "../../features/apiSlice";
import { GetUser } from "../user/GetUser";
import { GetAdmin } from "../admin/GetAdmin";
import { CreateAdmin } from "../admin/CreateAdmin";
import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
import KeycloakService from "../../services/KeycloakService";



export const CreateGame = (gameName, userId, userAdminId) => {
    //const navigator = useNavigate()

    // let [userId, setUserId] = useState(-1) //GetUser()
    
    // let [adminId, setAdminId] = useState(-1) //GetAdmin(userId)

    // setUserId(GetUser())
    // while(userId === null){

    // }
    
    // setAdminId(GetAdmin(userId))
    // while(adminId === null)
    // {

    // }
    console.log(`gameName: ${gameName} \nuserId: ${userId} \nuserAdminId: ${userAdminId} \n`)

    if(userAdminId === -1)
    {
      console.log("Admin doesn't exist, will call CreateAdmin(userId)")
      userAdminId = CreateAdmin(userId)
    }

    console.log("Inside CreateGame.js")
    console.log(gameName)



    // keycloakId = KeycloakService.getId()
    // console.log("keycloakId: " + keycloakId)
    // console.log(typeof(keycloakId) )

    //user = GetUser(keycloakId)
    //GetUser()
    console.log("userId: ")


    //.then(userId =>  GetUserId(keycloakId))

    



    // Promise.all([
    //     userId =  GetUser()
    //     .then(adminId =  GetAdmin(userId))
    //   ]);

    

    // const userId =  GetUser()
    // const adminId =  GetAdmin(userId)

//     const {
//         data: admin,
//         isLoading,
//         isSuccess,
//         isError,
//         error,
//     } = useAddNewGameMutation({name: gameName, gameState: "Registration", adminId: adminId});

//   if (isSuccess) {
//     console.log("CreateGame.js Success")
//     navigator("/")


//   }
//   else {
//       console.log("Error CreateGame.js")
//   }
}

