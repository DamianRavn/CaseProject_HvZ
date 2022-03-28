import { useAddNewUserMutation } from '../../features/apiSlice'
import KeycloakService from '../../services/KeycloakService'
import { useEffect } from 'react'

export const PostUser = () => {
  const [addNewUser, { isLoading, isSuccess }] = useAddNewUserMutation()

  useEffect(() => {
    console.log('addNewUser fired')
    addNewUser({
      firstName: KeycloakService.getFirstName(),
      lastName: KeycloakService.getLastName(),
      userName: KeycloakService.getUsername(),
      keycloakId: KeycloakService.getId(),
    })
  }, [])

  if (isSuccess) {
    localStorage.setItem('access-token', KeycloakService.getToken())
    localStorage.setItem('user-id', addNewUser.id)
  }

  return <></>
}
