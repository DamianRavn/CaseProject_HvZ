import { useNavigate } from 'react-router-dom'
import KeycloakService from '../services/KeycloakService'
import { useEffect } from 'react'

const WithKeycloak = (props) => {
  const navigator = useNavigate()

  useEffect(() => {
    if (!KeycloakService.isLoggedIn()) {
      navigator('/')
    }
  })

  return props.children
}
export default WithKeycloak
