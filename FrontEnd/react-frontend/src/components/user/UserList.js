import { useGetUsersQuery } from "../../features/apiSlice";

export const UserList = () => {
  const {
    data: users,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUsersQuery();

  return (
    <>
      <h1>User list:</h1>
      <p>{JSON.stringify(users)}</p>
    </>
  );
};
