import { useNavigate } from 'react-router-dom'
import { GameList } from '../components/game/GameList'
import { UserList } from '../components/user/UserList'
import KeycloakService from '../services/KeycloakService'
import {
  useAddNewUserMutation,
  useGetUserByKeycloakId,
} from '../features/apiSlice'

const LandingPage = () => {
  const navigator = useNavigate()

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

    return <UserList />
  }

  return (
    <div className="default-class">
      <div className="font-semibold">
        <div className="text-4xl text-center">
          <h1>Landing Page</h1>
        </div>
      </div>
      <br></br>

      <button class="btn absolute top-13 right-12" onClick={gotoCreateAccount}>
        Create Account
      </button>

      <br></br>
      <GameList></GameList>
    </div>
  )
}

export default LandingPage
