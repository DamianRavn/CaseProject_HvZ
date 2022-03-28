import { useNavigate } from 'react-router-dom'
import { GameList } from '../components/game/GameList'
import KeycloakService from '../services/KeycloakService'
import { CheckUser } from '../components/user/CheckUser'

const LandingPage = () => {
  const navigator = useNavigate()
  const gotoLogin = () => {
    navigator('/login')
  }

  const gotoCreateAccount = () => {
    navigator('/signup')
  }

  const gotoCreateNewGamePage = () => {
    navigator('/newgame')
  }

  if (KeycloakService.isLoggedIn()) {
    return (
      <div className="default-class">
        <div className="font-semibold">
          <div className="text-4xl">
            <h1>Landing Page</h1>
          </div>
          <button className="btn" onClick={gotoCreateNewGamePage}>
            Create New Game
          </button>
        </div>
        <GameList></GameList>
        <CheckUser></CheckUser>
      </div>
    )
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl text-center">
          <h1>Landing Page</h1>
        </div>
      </div>
      <GameList></GameList>
    </div>
  )
}

export default LandingPage
