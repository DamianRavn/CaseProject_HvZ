// import { useAddNewAdminMutation } from "../../features/apiSlice";

// export const CreateAdmin = (userId) => { 
//   console.log("CreateAdmin, input = " + userId)
//   const {
//     data: admin,
//     isLoading,
//     isSuccess,
//     isError,
//     error,
//   } = useAddNewAdminMutation(userId);

//   if (isSuccess) {
//     console.log("Success CreateAdmin.js")
//     console.log("admin.id =  " + admin.id)
//     return admin.id

//   }
//   else {
//       console.log("Error CreateAdmin.js")
//       return undefined
//   }
//   return admin
// };


import { useAddNewAdminMutation } from "../../features/apiSlice";
import { useEffect } from "react";

export const CreateAdmin = (userId) => {
  console.log("CreateAdmin, input = " )
  console.log(userId)
  const [addNewAdmin, { isLoading }] = useAddNewAdminMutation();

  useEffect(() => {
    console.log("addNewAdmin useEffect");
    addNewAdmin({
      user: userId,
    });
  }, []);

  console.log("CreateAdmin.js End of ")
  return <></>
};