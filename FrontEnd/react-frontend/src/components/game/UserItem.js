import { useGetUserQuery } from "../../features/apiSlice";
export const UserItem = (props) => {
  const {
    data: user,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUserQuery(props.id);

  if (isSuccess) {
    return (
      <ul>
        <li>{user.userName}</li>
      </ul>
    );
  } else {
    return <p>Could not get user.</p>;
  }
};
