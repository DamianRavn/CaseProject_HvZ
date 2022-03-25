import { useGetUserByKeycloakIdQuery } from "../../features/apiSlice";
import KeycloakService from "../../services/KeycloakService";

export const GetUser = () => {
  const {
    data: user,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUserByKeycloakIdQuery(KeycloakService.getId());

  if (isSuccess) {

    return user
    //return <GetAdmins id="{user.id}"></GetAdmins>
  }
  else{
      console.log("GetUser.js Error")
  }
};
