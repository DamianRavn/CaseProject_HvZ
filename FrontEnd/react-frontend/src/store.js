import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import gameSlice from "./features/gameSlice";
import userSlice from "./features/userSlice";
import { apiSlice } from "./features/apiSlice";

const store = configureStore({
  reducer: {
    users: userSlice,
    games: gameSlice,
    [apiSlice.reducerPath]: apiSlice.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(apiSlice.middleware),
});

setupListeners(store.dispatch);

export default store;
