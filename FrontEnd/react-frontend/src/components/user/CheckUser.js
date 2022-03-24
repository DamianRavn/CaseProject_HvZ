import { useGetUserByKeycloakIdQuery } from "../../features/apiSlice";
import { PostUser } from "./PostUser";
import KeycloakService from "../../services/KeycloakService";

export const CheckUser = () => {
  const {
    data: user,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUserByKeycloakIdQuery(KeycloakService.getId());

  if (isError) {
    return <PostUser></PostUser>;
  }
  return <></>;
};
