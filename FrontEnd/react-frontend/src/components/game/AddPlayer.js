import { useAddNewPlayerMutation } from '../../features/apiSlice'
import { useEffect } from 'react'
import { parseWithOptions } from 'date-fns/fp'

export const AddPlayer = (props) => {
  const [addNewPlayer, { isLoading }] = useAddNewPlayerMutation()

  useEffect(() => {
    addNewPlayer({
      isHuman: true,
      user: localStorage.getItem('user-id'),
      game: props.gameId,
    })
  }, [])

  return <p>Joined game!</p>
}
