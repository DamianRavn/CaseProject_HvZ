import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import gameSlice from "./features/gameSlice";
import userSlice from "./features/userSlice";

const store = configureStore({
  reducer: {
    users: userSlice,
    games: gameSlice,
  },
});

setupListeners(store.dispatch);

export default store;
