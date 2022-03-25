import { useGetAdminsQuery } from "../../features/apiSlice";
import { CreateAdmin } from "./CreateAdmin";

export const GetAdmin = (props) => {
  const {
    data: admins,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetAdminsQuery();

  if (isSuccess) {
    admins.forEach(admin => {
      if(admin.id === props.id){
        return admin.id
      }
    });
  }
  else{ 
    console.log("GetAdmin.js Error")
  }
  
  return CreateAdmin(props.id)
};
