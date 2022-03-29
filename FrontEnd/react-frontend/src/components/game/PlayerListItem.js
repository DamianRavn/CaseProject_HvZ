import { useGetPlayerQuery } from "../../features/apiSlice";
import { UserItem } from "./UserItem";

export const PlayerListItem = (props) => {
  const {
    data: player,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetPlayerQuery(props.id);
  if (isSuccess) {
    return <UserItem id={player.user}></UserItem>;
  } else {
    return <p>Get player failed.</p>;
  }
};
