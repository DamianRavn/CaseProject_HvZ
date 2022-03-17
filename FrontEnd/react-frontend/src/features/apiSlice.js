import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hvzapi.azurewebsites.net/api",
  }),
  endpoints: (builder) => ({
    getUsers: builder.query({
      query: () => "/Users",
    }),
    getUser: builder.query({
      query: (userId) => `/Users/${userId}`,
    }),
    getGames: builder.query({
      query: () => "/game",
    }),
    getGame: builder.query({
      query: (gameId) => `/game/${gameId}`,
    }),
    addNewGame: builder.mutation({
      query: (initialGame) => ({
        url: "/game",
        method: "POST",
        body: initialGame,
      }),
    }),
  }),
});

export const {
  useGetUsersQuery,
  useGetUserQuery,
  useGetGamesQuery,
  useGetGameQuery,
  useAddNewGameMutation,
} = apiSlice;
