import { useNavigate } from 'react-router-dom'
import { GameList } from '../components/game/GameList'
import { UserList } from '../components/user/UserList'

import GameRegistrationPage from './GameRegistrationPage'
import KeycloakService from '../services/KeycloakService'
import {
  useAddNewUserMutation,
  useGetUserByKeycloakId,
} from '../features/apiSlice'

const LandingPage = () => {
  const navigator = useNavigate()
  const gotoLogin = () => {
    navigator('/login')
  }

  const gotoCreateAccount = () => {
    navigator('/signup')
  }

  if (KeycloakService.isLoggedIn()) {
    localStorage.setItem('access-token', KeycloakService.getToken())

    // if (isError) {
    //   console.log(error)
    //   try {
    //     await addNewUser({
    //       firstName: KeycloakService.getFirstName(),
    //       lastName: KeycloakService.getLastName(),
    //       userName: KeycloakService.getUsername(),
    //       keycloakId: KeycloakService.getId(),
    //     })
    //   } catch (error) {
    //     console.log(error)
    //   }
    // }

    return <><GameRegistrationPage /><UserList /></>
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl">
          <h1>Landing Page</h1>
        </div>
      </div>
      <br></br>

      <button className="btn" onClick={gotoLogin}>
        Login
      </button>

      <button className="btn" onClick={gotoCreateAccount}>
        Create Account
      </button>

      <br></br>
      <GameList></GameList>
    </div>
  )
}

export default LandingPage
