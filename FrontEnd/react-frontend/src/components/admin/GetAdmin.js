import { useGetAdminsQuery } from "../../features/apiSlice";
import { CreateAdmin } from "./CreateAdmin";

export const GetAdmin = (userId) => {
  console.log("GetAdmin.js input = " + userId)
  const {
    data: admins,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetAdminsQuery();

  if (isSuccess) {
    console.log("GetAdmin.js Success")
    console.log(admins)

    admins.forEach(admin => {
      console.log("admin.user = " + admin.user + " === " + userId + " = userId.") 
      if(admin.user === userId){
        console.log("MATCH !!!")
        return admin.id
        console.log("OR maybe NOT")
      }
    });
    
    //return <CreateAdmin></CreateAdmin>
    //return CreateAdmin(userId)
    return -1
  }
  else{ 
    console.log("GetAdmin.js not Successful")
    
  }
  return undefined
  
  
};
