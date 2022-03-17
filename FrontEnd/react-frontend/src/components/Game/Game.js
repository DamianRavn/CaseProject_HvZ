import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { useGetGameQuery } from "../../features/apiSlice";
import { useParams } from "react-router-dom";

export const Game = () => {
  const { gameId } = useParams();

  const { data: game, isFetching, isSuccess } = useGetGameQuery(gameId);

  let content;
  if (isFetching) {
    content = <h1>Loading game data</h1>;
  } else if (isSuccess) {
    content = (
      <div>
        <h1>Game name: {game.name}</h1>
        <h1>Game status: {game.gameState}</h1>
        <h1>Game admin: {game.admin}</h1>
      </div>
    );
  }
  return <div>{content}</div>;
};

// import { useContext } from "react"
// import { useNavigate } from "react-router-dom"

// const Game = () => {

//   const navigator = useNavigate()

//   const gotoGameRegistration = () => {
//     navigator("/gamereg")
//   }

//   const gotoLanding = () => {
//     navigator("/")
//   }

//   const gotoAdmin = () => {
//     navigator("/admin")
//   }

//   return (
//     <div className="default-class">
//       <div className="font-semibold">
//       <div className="text-4xl" ><h1>Game Page</h1></div>
//       </div>
//       <br></br>

//       <button className="btn" onClick={gotoGameRegistration}>Game Registration Page</button>
//       <div className="divider"/>
//       <button className="btn" onClick={gotoAdmin}>Admin Page</button>
//       <div className="divider"/>
//       <button className="btn" onClick={gotoLanding}>Landing Page</button>

//     </div>
//   );

// }

// export default Game
