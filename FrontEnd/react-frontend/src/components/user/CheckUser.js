import { useGetUserByKeycloakIdQuery } from '../../features/apiSlice'
import { PostUser } from './PostUser'
import KeycloakService from '../../services/KeycloakService'
import { useEffect } from 'react'

export const CheckUser = () => {
  const {
    data: user,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUserByKeycloakIdQuery(KeycloakService.getId())

  if (isError) {
    return <PostUser></PostUser>
  }
  if (isSuccess) {
    localStorage.setItem('user-id', user.id)
    localStorage.setItem('access-token', KeycloakService.getToken())
  }
  return <></>
}
