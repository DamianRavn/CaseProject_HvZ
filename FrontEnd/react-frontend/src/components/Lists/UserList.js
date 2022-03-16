import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
// omit other imports
// import { fetchUsers, selectAllUsers } from "../../features/userSlice";

import { useGetUsersQuery } from "../../features/apiSlice";

export const UserList = () => {
  const {
    data: users,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUsersQuery();

  return <h1>UserList</h1>;
};

// export const UserList = () => {
//   const dispatch = useDispatch();
//   const users = useSelector(selectAllUsers);

//   const userStatus = useSelector((state) => state.users.status);

//   useEffect(() => {
//     if (userStatus === "idle") {
//       dispatch(fetchUsers());
//     }
//   }, [userStatus, dispatch]);

//   return <h1>{userStatus}</h1>;
// };
