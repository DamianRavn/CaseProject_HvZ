import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
// omit other imports
import { fetchUsers, selectAllUsers } from "../features/userSlice";

export const UserList = () => {
  const dispatch = useDispatch();
  const users = useSelector(selectAllUsers);

  const userStatus = useSelector((state) => state.users.value.status);

  useEffect(() => {
    if (userStatus === "idle") {
      dispatch(fetchUsers());
    }
  }, [userStatus, dispatch]);

  return <h1>{userStatus}</h1>;
};
