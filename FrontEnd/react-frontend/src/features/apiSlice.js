import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const apiSlice = createApi({
  reducerPath: 'api',
  baseQuery: fetchBaseQuery({
    baseUrl: 'https://localhost:44389/api',
  }),
  endpoints: (builder) => ({
    getUsers: builder.query({
      query: () => ({
        url: '/Users',
        method: 'GET',
        headers: new Headers({
          Authorization: 'Bearer ' + localStorage.getItem('access-token'),
        }),
      }),
    }),
    getUser: builder.query({
      query: (userId) => ({
        url: `/Users/${userId}`,
        headers: new Headers({
          Authorization: 'Bearer ' + localStorage.getItem('access-token'),
        }),
      }),
    }),
    getUserByKeycloakId: builder.query({
      query: (keycloakId) => `/Users/keycloak/${keycloakId}`,
    }),
    addNewUser: builder.mutation({
      query: (initialUser) => ({
        url: '/Users',
        method: 'POST',
        body: initialUser,
      }),
    }),
    getPlayer: builder.query({
      query: (player) => ({
        url: `/Players/${player}`,
        headers: new Headers({
          Authorization: 'Bearer ' + localStorage.getItem('access-token'),
        }),
      }),
    }),
    getPlayerNonAdmin: builder.query({
      query: () => '/Players/non-admin',
    }),
    getGames: builder.query({
      query: () => '/game',
    }),
    getGame: builder.query({
      query: (gameId) => `/game/${gameId}`,
    }),
    addNewGame: builder.mutation({
      query: (initialGame) => ({
        url: '/game',
        method: 'POST',
        body: initialGame,
      }),
    }),
  }),
})

export const {
  useGetUsersQuery,
  useGetUserQuery,
  useGetPlayerNonAdminQuery,
  useGetGamesQuery,
  useGetGameQuery,
  useAddNewGameMutation,
  useAddNewUserMutation,
  useGetUserByKeycloakIdQuery,
  useGetPlayerQuery,
} = apiSlice
