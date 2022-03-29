import KeycloakService from '../services/KeycloakService'
import { Navigate, Route } from 'react-router-dom'

const ProtectedRoute = (props) => {
  return KeycloakService.isLoggedIn() ? (
    props.children
  ) : (
    <Navigate to="/" replace />
  )
}
export default ProtectedRoute
