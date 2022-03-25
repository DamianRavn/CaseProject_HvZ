import { useAddNewAdminMutation } from "../../features/apiSlice";

export const CreateAdmin = (props) => {
  const {
    data: admin,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useAddNewAdminMutation(props.id);

  if (isSuccess) {
    return admin.id
  }
  else {
      console.log("Error CreateAdmin.js")
  }
};

