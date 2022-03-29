import { useGetUserByKeycloakIdQuery } from "../../features/apiSlice";


export const GetUser = (keycloakId) => {
    console.log("GetUser.js Start of function, input = " )
  const {
    data: user,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUserByKeycloakIdQuery(keycloakId); 

   if (isSuccess) {     
     return user
   }

  return <></>;
};


