import { waitFor } from '@testing-library/react';
import { useGetPlayerQuery, useUpdateGameMutation, useUpdatePlayerMutation } from '../../features/apiSlice'

const StartGame = (game)=>
{
    //set game to in progress.
    game.GameState = "InProgress";
    const [startGame] = useUpdateGameMutation(game);
    
    //Choose one player to be patient 0
    const patientZeroID = game.players[Math.floor(Math.random() * game.players.length)];

    //Get Player
    const [patientZero] = useGetPlayerQuery(patientZeroID);
    patientZero.IsPatientZero = true;
    //Set player in db
    const [updatedPatientZero] = useUpdatePlayerMutation(patientZero);
}

const StartGameButton = (prop) => {
  return (
    <div>
      <button className='btn' onClick={StartGame(prop.game)}>
          Start Game
      </button>
    </div>
  )
}
export default StartGameButton
