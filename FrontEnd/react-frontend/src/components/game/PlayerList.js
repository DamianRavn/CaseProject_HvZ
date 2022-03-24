import { useGetPlayerNonAdminQuery } from "../../features/apiSlice";
import { PlayerListItem } from "./PlayerListItem";

export const PlayerList = (props) => {
  let content;
  content = props.ids.map((id) => <PlayerListItem key={id} id={id} />);
  return <>{content}</>;
};
